using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MaLop { get; set; }
    }

    public class Diem
    {
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public float DiemCC { get; set; }
        public float DiemTX { get; set; }
        public float DiemTHI { get; set; }
        public float DiemHP { get; set; }
    }

    public class Lop
    {
        public string? MaLop { get; set; }
        public string? TenLop { get; set; }
    }

    public class Khoa
    {
        public string? MaKhoa { get; set; }
        public string? TenKhoa { get; set; }
    }

    public class MonHoc
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int TinChi { get; set; }
        public string MaKhoa { get; set; }
    }

    public class GiangVien
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public string MaKhoa { get; set; }
        public string MaMH { get; set; }
    }

    public class GiangDay
    {
        public string? MaGV { get; set; }
        public string? MaMH { get; set; }
        public string? MaLop { get; set; }
    }

    public class TaiKhoan
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? MaGV { get; set; } 
        public string? MaKhoa { get; set; }
    }
}
