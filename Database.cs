using Microsoft.Data.Sqlite;
using System.Data;

namespace BTL
{
    public class Database
    {
        private readonly string connectionString =
            $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\PMQLSVDH.db;";
        private SqliteConnection? _conn;

        private void Open()
        {
            _conn ??= new SqliteConnection(connectionString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
        }
        private void Close()
        {
            if (_conn?.State == ConnectionState.Open) _conn.Close();
        }

        public TaiKhoan? CheckLogin(string username, string password)
        {
            try
            {
                Open();
                const string sql = @"SELECT * FROM TaiKhoan
                                     WHERE Username = @u AND Password = @p";
                using SqliteCommand cmd = new(sql, _conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using SqliteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new TaiKhoan
                    {
                        Username = rd["Username"].ToString(),
                        Password = rd["Password"].ToString(),
                        Role = rd["Role"].ToString(),
                        MaGV = rd["MaGV"].ToString(),
                        MaKhoa = rd["MaKhoa"].ToString()
                    };
                }
                return null;
            }
            finally { Close(); }
        }

        public DataTable GetDataTable(string sql, params (string name, object value)[] prms)
        {
            DataTable dt = new();
            try
            {
                Open();
                using SqliteCommand cmd = new(sql, _conn);
                foreach ((string name, object value) p in prms)
                    cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);

                using SqliteDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);     
            }
            finally { Close(); }

            return dt;
        }

        private List<string> GetTableColumns(string tableName)
        {
            List<string> cols = new();
            using DataTable dt = GetDataTable($"PRAGMA table_info({tableName});");
            foreach (DataRow r in dt.Rows)
                cols.Add(r["name"].ToString());
            return cols;
        }

        private int Exec(string sql, params (string p, object v)[] prms)
        {
            try
            {
                Open();
                using SqliteCommand cmd = new(sql, _conn);
                foreach ((string p, object v) t in prms)
                    cmd.Parameters.AddWithValue(t.p, t.v ?? DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
            finally { Close(); }
        }

        private string[] GetPrimaryKeyNames(Type t)
        {
            if (t == typeof(Diem)) return new[] { "MaSV", "MaMH" };
            if (t == typeof(TaiKhoan)) return new[] { "Username" };
            if (t == typeof(SinhVien)) return new[] { "MaSV" };
            if (t == typeof(GiangVien)) return new[] { "MaGV" };
            if (t == typeof(MonHoc)) return new[] { "MaMH" };
            if (t == typeof(Khoa)) return new[] { "MaKhoa" };
            if (t == typeof(Lop)) return new[] { "MaLop" };
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            return props.Length > 0 ? new[] { props[0].Name } : Array.Empty<string>();
        }

        public bool Insert<T>(T obj)
        {
            Type type = typeof(T);
            string table = type.Name;
            List<string> tableCols = GetTableColumns(table);
            List<System.Reflection.PropertyInfo> props = type.GetProperties()
                            .Where(p => tableCols
                                .Contains(p.Name, StringComparer.OrdinalIgnoreCase))
                            .ToList();

            if (!props.Any())
            {
                throw new InvalidOperationException(
                    $"[Insert<{table}>] No matching properties to insert. Table columns: {string.Join(",", tableCols)}"
                );
            }

            string columns = string.Join(", ", props.Select(p => p.Name));
            string parameters = string.Join(", ", props.Select(p => "@" + p.Name));
            string sql = $"INSERT INTO {table} ({columns}) VALUES ({parameters});";

            (string, object)[] prms = props.Select(p => ("@" + p.Name,p.GetValue(obj) as object ?? DBNull.Value)).ToArray();

            return Exec(sql, prms) > 0;
        }

        public bool Update<T>(T obj)
        {
            string table = typeof(T).Name;

            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties().Where(p => p.CanRead && p.CanWrite).ToArray();

            string[] keyNames = GetPrimaryKeyNames(typeof(T));
            if (keyNames.Length == 0)
                throw new InvalidOperationException($"[Update<{table}>] No primary key defined.");

            List<string> tableCols = GetTableColumns(table);

            System.Reflection.PropertyInfo[] setProps = props.Where(p => tableCols.Contains(p.Name, StringComparer.OrdinalIgnoreCase) && !keyNames.Contains(p.Name, StringComparer.OrdinalIgnoreCase)).ToArray();
            if (setProps.Length == 0)
                throw new InvalidOperationException($"[Update<{table}>] No updatable columns. Table columns: {string.Join(",", tableCols)}");

            System.Reflection.PropertyInfo[] whereProps = props.Where(p => keyNames.Contains(p.Name, StringComparer.OrdinalIgnoreCase)).ToArray();
            if (whereProps.Length != keyNames.Length)
                throw new InvalidOperationException($"[Update<{table}>] Mismatch between primary keys and model properties.");

            string setClause = string.Join(", ", setProps.Select(p => $"{p.Name}=@{p.Name}"));
            string whereClause = string.Join(" AND ", whereProps.Select(p => $"{p.Name}=@{p.Name}"));
            string sql = $"UPDATE {table} SET {setClause} WHERE {whereClause};";

            (string, object)[] prms = setProps.Concat(whereProps).Select(p => ("@" + p.Name, p.GetValue(obj) ?? DBNull.Value)).ToArray();

            return Exec(sql, prms) > 0;
        }

        public bool UpdateDiem(Diem diem)
        {
            const string sql = @"UPDATE Diem SET DiemCC = @cc, DiemTX = @tx, DiemThi = @thi, DiemHP = @hp WHERE MaSV = @sv AND MaMH = @mh;";
            return Exec(sql, ("@cc", diem.DiemCC), ("@tx", diem.DiemTX), ("@thi", diem.DiemTHI), ("@hp", diem.DiemHP), ("@sv", diem.MaSV), ("@mh", diem.MaMH)) > 0;
        }

        public bool Delete<T>(params object[] keys)
        {
            string table = typeof(T).Name;
            string[] keyNames = GetPrimaryKeyNames(typeof(T));
            if (keys.Length != keyNames.Length) return false;

            if (typeof(T) == typeof(SinhVien))
            {
                Exec("DELETE FROM Diem WHERE MaSV=@id;", ("@id", keys[0]));
                return Exec("DELETE FROM SinhVien WHERE MaSV=@id;", ("@id", keys[0])) > 0;
            }
            if (typeof(T) == typeof(GiangVien))
            {
                var maGV = keys[0];

                Exec(@"DELETE FROM Diem WHERE (MaMH, MaSV) IN (
                       SELECT GD.MaMH, SV.MaSV
                       FROM GiangDay GD
                       JOIN SinhVien SV ON SV.MaLop = GD.MaLop
                       WHERE GD.MaGV = @maGV);", ("@maGV", maGV));

                Exec("DELETE FROM GiangDay WHERE MaGV = @maGV;", ("@maGV", maGV));

                Exec("DELETE FROM TaiKhoan WHERE MaGV = @maGV;", ("@maGV", maGV));

                return Exec("DELETE FROM GiangVien WHERE MaGV = @maGV;", ("@maGV", maGV)) > 0;
            }
            if (typeof(T) == typeof(Lop))
            {
                Exec(@"DELETE FROM Diem WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE MaLop=@lop);", ("@lop", keys[0]));
                Exec("DELETE FROM SinhVien WHERE MaLop=@lop;", ("@lop", keys[0]));
                Exec("DELETE FROM GiangDay WHERE MaLop=@lop;", ("@lop", keys[0]));
                return Exec("DELETE FROM Lop WHERE MaLop=@lop;", ("@lop", keys[0])) > 0;
            }
            if (typeof(T) == typeof(MonHoc))
            {
                Exec("DELETE FROM GiangDay WHERE MaMH=@mh;", ("@mh", keys[0]));
                Exec("UPDATE GiangVien SET MaMH=NULL WHERE MaMH=@mh;", ("@mh", keys[0]));
                return Exec("DELETE FROM MonHoc WHERE MaMH=@mh;", ("@mh", keys[0])) > 0;
            }
            if (typeof(T) == typeof(Khoa))
            {
                var maKhoa = (string)keys[0];
                Exec("PRAGMA foreign_keys = ON;");
                return Exec(@"DELETE FROM Khoa WHERE MaKhoa = @maKhoa;", ("@maKhoa", maKhoa)) > 0;
            }


            if (typeof(T) == typeof(TaiKhoan))
            {
                return Exec("DELETE FROM TaiKhoan WHERE Username=@u;", ("@u", keys[0])) > 0;
            }
            if (typeof(T) == typeof(Diem))
            {
                return Exec("DELETE FROM Diem WHERE MaSV=@sv AND MaMH=@mh;", ("@sv", keys[0]), ("@mh", keys[1])) > 0;
            }

            string whereClause = string.Join(" AND ", keyNames.Select((k, i) => $"{k}=@key{i}"));
            List<(string, object)> prms = new();
            for (int i = 0; i < keyNames.Length; i++)
                prms.Add(($"@key{i}", keys[i] ?? DBNull.Value));
            string sql = $"DELETE FROM {table} WHERE {whereClause};";
            return Exec(sql, prms.ToArray()) > 0;
        }

        public bool Exist<T>(params object[] keys)
        {
            string table = typeof(T).Name;
            string[] keyNames = GetPrimaryKeyNames(typeof(T));
            if (keys.Length != keyNames.Length) return false;
            string whereClause = string.Join(" AND ", keyNames.Select((k, i) => $"{k}=@key{i}"));
            string sql = $"SELECT 1 FROM {table} WHERE {whereClause} LIMIT 1;";
            List<(string, object)> prms = new();
            for (int i = 0; i < keyNames.Length; i++)
                prms.Add(($"@key{i}", keys[i] ?? DBNull.Value));
            return GetDataTable(sql, prms.ToArray()).Rows.Count > 0;
        }

        public DataTable GetAll<T>()
        {
            string table = typeof(T).Name;
            if (typeof(T) == typeof(SinhVien))
            {
                const string sql = @"SELECT sv.MaSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, l.TenLop AS LopHoc, sv.MaLop
                                     FROM   SinhVien sv
                                     LEFT JOIN Lop l ON l.MaLop = sv.MaLop
                                     ORDER BY sv.MaSV;";
                return GetDataTable(sql);
            }
            if (typeof(T) == typeof(GiangVien))
            {
                const string sql = @"SELECT gv.MaGV, gv.TenGV, k.TenKhoa, gv.MaKhoa, mh.TenMH, gv.MaMH
                                     FROM   GiangVien gv
                                     LEFT JOIN Khoa   k  ON k.MaKhoa = gv.MaKhoa
                                     LEFT JOIN MonHoc mh ON mh.MaMH  = gv.MaMH
                                     ORDER BY gv.MaGV;";
                return GetDataTable(sql);
            }
            if (typeof(T) == typeof(MonHoc))
            {
                const string sql = @"SELECT mh.MaMH, mh.TenMH, mh.TinChi, mh.MaKhoa, k.TenKhoa
                                     FROM   MonHoc mh
                                     LEFT JOIN Khoa k ON k.MaKhoa = mh.MaKhoa
                                     ORDER BY mh.TenMH;";
                return GetDataTable(sql);
            }
            if (typeof(T) == typeof(Khoa))
                return GetDataTable("SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa;");
            if (typeof(T) == typeof(Lop))
                return GetDataTable("SELECT MaLop, TenLop FROM Lop ORDER BY TenLop;");
            if (typeof(T) == typeof(TaiKhoan))
            {
                const string sql = @"SELECT tk.Username, tk.Password, tk.Role, tk.MaGV, gv.TenGV, tk.MaKhoa
                                     FROM   TaiKhoan tk
                                     LEFT JOIN GiangVien gv ON gv.MaGV = tk.MaGV
                                     ORDER BY tk.Username;";
                return GetDataTable(sql);
            }
            if (typeof(T) == typeof(Diem))
                return GetDataTable("SELECT * FROM Diem;");
  
            return GetDataTable($"SELECT * FROM {table};");
        }

        public DataTable GetMonHocByKhoa(string maKhoa)
        {
            const string sql = @"SELECT MaMH, TenMH FROM MonHoc WHERE MaKhoa=@mk ORDER BY TenMH;";
            return GetDataTable(sql, ("@mk", maKhoa));
        }
       
        public DataTable GetLopByGiangVien(string maGV)
        {
            const string sql = @"SELECT gd.MaLop, l.TenLop, gd.MaMH
                                 FROM   GiangDay gd
                                 JOIN   Lop l ON l.MaLop  = gd.MaLop
                                 WHERE  gd.MaGV  = @gv;";
            return GetDataTable(sql, ("@gv", maGV));
        }

        public DataTable GetSinhVienByLop(string maLop)
        {
            const string sql = @"SELECT MaSV, TenSV, GioiTinh, NgaySinh FROM SinhVien WHERE MaLop = @lop;";
            return GetDataTable(sql, ("@lop", maLop));
        }

        public DataTable GetMonByLop(string maLop)
        {
            const string sql = @"SELECT gd.MaMH, mh.TenMH, gd.MaGV, gv.TenGV
                                 FROM   GiangDay gd
                                 JOIN   MonHoc  mh ON mh.MaMH = gd.MaMH
                                 JOIN   GiangVien gv ON gv.MaGV = gd.MaGV
                                 WHERE  gd.MaLop = @lop;";
            return GetDataTable(sql, ("@lop", maLop));
        }

        public bool InsertGiangDay(string maLop, string maMH, string maGV)
        {
            const string sql = "INSERT INTO GiangDay(MaGV, MaMH, MaLop) VALUES(@gv,@mh,@lop);";
            return Exec(sql, ("@gv", maGV), ("@mh", maMH), ("@lop", maLop)) > 0;
        }
        public bool DeleteGiangDay(string maLop, string maMH)
            => Exec("DELETE FROM GiangDay WHERE MaLop=@lop AND MaMH=@mh;", ("@lop", maLop), ("@mh", maMH)) > 0;

        public DataTable GetGiangVienByMon(string maMH)
        {
            const string sql = "SELECT MaGV, TenGV FROM GiangVien WHERE MaMH=@mh;";
            return GetDataTable(sql, ("@mh", maMH));
        }

        public DataTable GetSV_Diem_ByLop(string maLop, string maMH)
        {
            const string sql = @"SELECT  sv.MaSV, sv.TenSV, sv.GioiTinh, sv.NgaySinh, sv.DiaChi, d.DiemCC, d.DiemTX, d.DiemTHI, d.DiemHP
                                 FROM    SinhVien sv
                                 LEFT JOIN Diem d
                                 ON      d.MaSV = sv.MaSV AND d.MaMH = @mh
                                 WHERE   sv.MaLop = @lop
                                 ORDER BY sv.MaSV;";
            return GetDataTable(sql, ("@lop", maLop), ("@mh", maMH));
        }

        public bool UpdatePassword(string user, string newPass)
        {
            return Exec("UPDATE TaiKhoan SET Password=@p WHERE Username=@u;", ("@p", newPass), ("@u", user)) > 0;
        }
    }
}
