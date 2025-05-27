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

        /// <summary>Trả về bản ghi TaiKhoan hợp lệ, null nếu sai.</summary>
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
                dt.Load(reader);     // DataTable tự “hút” toàn bộ dữ liệu
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

        /// <summary>Lấy tên trường khóa chính (hoặc các trường khóa chính) của loại đối tượng T.</summary>
        private string[] GetPrimaryKeyNames(Type t)
        {
            if (t == typeof(Diem)) return new[] { "MaSV", "MaMH" };
            if (t == typeof(TaiKhoan)) return new[] { "Username" };
            if (t == typeof(SinhVien)) return new[] { "MaSV" };
            if (t == typeof(GiangVien)) return new[] { "MaGV" };
            if (t == typeof(MonHoc)) return new[] { "MaMH" };
            if (t == typeof(Khoa)) return new[] { "MaKhoa" };
            if (t == typeof(Lop)) return new[] { "MaLop" };
            // Mặc định: chọn thuộc tính đầu tiên làm khóa chính
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            return props.Length > 0 ? new[] { props[0].Name } : Array.Empty<string>();
        }

        /// <summary>Thêm một bản ghi đối tượng T vào cơ sở dữ liệu.</summary>
        /// <summary>
        /// Thêm một bản ghi đối tượng T vào cơ sở dữ liệu.
        /// </summary>
        public bool Insert<T>(T obj)
        {
            Type type = typeof(T);
            string table = type.Name;

            // 1) Lấy danh sách cột thực của bảng
            List<string> tableCols = GetTableColumns(table);

            // 2) Chọn tất cả property của T có tên khớp với cột trong bảng
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

            // 3) Sinh câu SQL INSERT
            string columns = string.Join(", ", props.Select(p => p.Name));
            string parameters = string.Join(", ", props.Select(p => "@" + p.Name));
            string sql = $"INSERT INTO {table} ({columns}) VALUES ({parameters});";

            // 4) Tạo mảng parameter tuples (string name, object value)
            (string, object)[] prms = props
                .Select(p => (
                    "@" + p.Name,
                    p.GetValue(obj) as object ?? DBNull.Value
                ))
                .ToArray();

            // 5) Thực thi
            return Exec(sql, prms) > 0;
        }




        /// <summary>
        /// Updates an existing record of type T in the database, based on its primary key(s).
        /// </summary>
        public bool Update<T>(T obj)
        {
            string table = typeof(T).Name;

            // 1) Discover all public properties on T
            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties().Where(p => p.CanRead && p.CanWrite).ToArray();

            // 2) Figure out primary key names for T (e.g. ["MaMH"] or ["MaGV","MaMH"])
            string[] keyNames = GetPrimaryKeyNames(typeof(T));
            if (keyNames.Length == 0)
                throw new InvalidOperationException($"[Update<{table}>] No primary key defined.");

            // 3) Load actual table columns via PRAGMA, so we only update real columns
            List<string> tableCols = GetTableColumns(table);
            // (internally runs: PRAGMA table_info({table}); and pulls the "name" field)

            // 4) Split props into SET vs WHERE
            System.Reflection.PropertyInfo[] setProps = props.Where(p => tableCols.Contains(p.Name, StringComparer.OrdinalIgnoreCase) && !keyNames.Contains(p.Name, StringComparer.OrdinalIgnoreCase)).ToArray();
            if (setProps.Length == 0)
                throw new InvalidOperationException($"[Update<{table}>] No updatable columns. Table columns: {string.Join(",", tableCols)}");

            System.Reflection.PropertyInfo[] whereProps = props.Where(p => keyNames.Contains(p.Name, StringComparer.OrdinalIgnoreCase)).ToArray();
            if (whereProps.Length != keyNames.Length)
                throw new InvalidOperationException($"[Update<{table}>] Mismatch between primary keys and model properties.");

            // 5) Build SQL
            string setClause = string.Join(", ", setProps.Select(p => $"{p.Name}=@{p.Name}"));
            string whereClause = string.Join(" AND ", whereProps.Select(p => $"{p.Name}=@{p.Name}"));
            string sql = $"UPDATE {table} SET {setClause} WHERE {whereClause};";

            // 6) Build parameters (use DBNull.Value for nulls)
            (string, object)[] prms = setProps.Concat(whereProps).Select(p => ("@" + p.Name, p.GetValue(obj) ?? DBNull.Value)).ToArray();

            // 7) Debug log (optional)
            Console.WriteLine($"[DEBUG] Update<{table}> SQL: {sql}");
            foreach ((string name, object value) in prms)
                Console.WriteLine($"[DEBUG]   Param {name} = {value}");

            // 8) Execute and return success
            return Exec(sql, prms) > 0;
        }

        public bool UpdateDiem(Diem diem)
        {
            const string sql = @"UPDATE Diem SET DiemCC = @cc, DiemTX = @tx, DiemThi = @thi, DiemHP = @hp WHERE MaSV = @sv AND MaMH = @mh;";
            return Exec(sql, ("@cc", diem.DiemCC), ("@tx", diem.DiemTX), ("@thi", diem.DiemTHI), ("@hp", diem.DiemHP), ("@sv", diem.MaSV), ("@mh", diem.MaMH)) > 0;
        }

        /// <summary>Xóa bản ghi đối tượng T theo khóa chính.</summary>
        public bool Delete<T>(params object[] keys)
        {
            string table = typeof(T).Name;
            string[] keyNames = GetPrimaryKeyNames(typeof(T));
            if (keys.Length != keyNames.Length) return false;

            // Xử lý trường hợp đặc biệt: cần xóa liên quan ở bảng khác (đảm bảo toàn vẹn dữ liệu)
            if (typeof(T) == typeof(SinhVien))
            {
                // Xóa điểm của sinh viên trước, sau đó xóa sinh viên
                Exec("DELETE FROM Diem WHERE MaSV=@id;", ("@id", keys[0]));
                return Exec("DELETE FROM SinhVien WHERE MaSV=@id;", ("@id", keys[0])) > 0;
            }
            if (typeof(T) == typeof(GiangVien))
            {
                // Xóa các bản ghi GiangDay liên quan đến giảng viên trước
                Exec("DELETE FROM GiangDay WHERE MaGV=@id;", ("@id", keys[0]));
                return Exec("DELETE FROM GiangVien WHERE MaGV=@id;", ("@id", keys[0])) > 0;
            }
            if (typeof(T) == typeof(Lop))
            {
                // Xóa tất cả sinh viên (và điểm của họ) thuộc lớp này, xóa giảng dạy liên quan, sau đó xóa lớp
                Exec(@"DELETE FROM Diem WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE MaLop=@lop);", ("@lop", keys[0]));
                Exec("DELETE FROM SinhVien WHERE MaLop=@lop;", ("@lop", keys[0]));
                Exec("DELETE FROM GiangDay WHERE MaLop=@lop;", ("@lop", keys[0]));
                return Exec("DELETE FROM Lop WHERE MaLop=@lop;", ("@lop", keys[0])) > 0;
            }
            if (typeof(T) == typeof(MonHoc))
            {
                // Xóa điểm và giảng dạy liên quan đến môn học, bỏ liên kết môn học ở bảng GiangVien, sau đó xóa môn
                Exec("DELETE FROM Diem WHERE MaMH=@mh;", ("@mh", keys[0]));
                Exec("DELETE FROM GiangDay WHERE MaMH=@mh;", ("@mh", keys[0]));
                Exec("UPDATE GiangVien SET MaMH=NULL WHERE MaMH=@mh;", ("@mh", keys[0]));
                return Exec("DELETE FROM MonHoc WHERE MaMH=@mh;", ("@mh", keys[0])) > 0;
            }
            if (typeof(T) == typeof(Khoa))
            {
                // Xóa tất cả dữ liệu liên quan đến khoa (điểm, giảng dạy, giảng viên, môn) trước khi xóa khoa
                Exec(@"DELETE FROM Diem WHERE MaMH IN (SELECT MaMH FROM MonHoc WHERE MaKhoa=@k);", ("@k", keys[0]));
                Exec(@"DELETE FROM GiangDay WHERE MaMH IN (SELECT MaMH FROM MonHoc WHERE MaKhoa=@k);", ("@k", keys[0]));
                Exec(@"DELETE FROM GiangDay WHERE MaGV IN (SELECT MaGV FROM GiangVien WHERE MaKhoa=@k);", ("@k", keys[0]));
                Exec("DELETE FROM GiangVien WHERE MaKhoa=@k;", ("@k", keys[0]));
                Exec("DELETE FROM MonHoc WHERE MaKhoa=@k;", ("@k", keys[0]));
                return Exec("DELETE FROM Khoa WHERE MaKhoa=@k;", ("@k", keys[0])) > 0;
            }
            if (typeof(T) == typeof(TaiKhoan))
            {
                return Exec("DELETE FROM TaiKhoan WHERE Username=@u;", ("@u", keys[0])) > 0;
            }
            if (typeof(T) == typeof(Diem))
            {
                // Xóa một bản ghi điểm (nếu cần sử dụng)
                return Exec("DELETE FROM Diem WHERE MaSV=@sv AND MaMH=@mh;", ("@sv", keys[0]), ("@mh", keys[1])) > 0;
            }

            // Mặc định: xóa theo khóa chính
            string whereClause = string.Join(" AND ", keyNames.Select((k, i) => $"{k}=@key{i}"));
            List<(string, object)> prms = new();
            for (int i = 0; i < keyNames.Length; i++)
                prms.Add(($"@key{i}", keys[i] ?? DBNull.Value));
            string sql = $"DELETE FROM {table} WHERE {whereClause};";
            return Exec(sql, prms.ToArray()) > 0;
        }

        /// <summary>Kiểm tra sự tồn tại của bản ghi T theo khóa chính.</summary>
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

        /// <summary>Lấy toàn bộ bảng dữ liệu ứng với lớp đối tượng T.</summary>
        public DataTable GetAll<T>()
        {
            string table = typeof(T).Name;
            // Truy vấn tùy chỉnh cho một số bảng có khóa ngoại để lấy tên thay vì mã
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
            // Mặc định: SELECT * (không có tùy chỉnh đặc biệt)
            return GetDataTable($"SELECT * FROM {table};");
        }

        // ==== CÁC HÀM LẤY DỮ LIỆU ĐẶC BIỆT (không thuộc nhóm CRUD chung) ====
        public DataTable GetMonHocByKhoa(string maKhoa)
        {
            const string sql = @"SELECT MaMH, TenMH FROM MonHoc WHERE MaKhoa=@mk ORDER BY TenMH;";
            return GetDataTable(sql, ("@mk", maKhoa));
        }

        /// <summary>
        /// Lấy danh sách lớp mà giảng viên maGV đang dạy.
        /// </summary>
        public DataTable GetLopByGiangVien(string maGV)
        {
            const string sql = @"
        SELECT gd.MaLop,
               l.TenLop,
               gd.MaMH
        FROM   GiangDay gd
        JOIN   Lop      l ON l.MaLop  = gd.MaLop
        WHERE  gd.MaGV  = @gv;";
            return GetDataTable(sql,
                                ("@gv", maGV));
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

        /// <summary>
        /// Trả về danh sách các giảng viên đã được phân công dạy môn maMH.
        /// </summary>
        /// <summary>
        /// Trả về danh sách các giảng viên đã được phân công dạy môn maMH.
        /// </summary>
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
