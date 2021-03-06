using DAL_QLNH;
using DTO_QLNH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNH
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();

        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.ThemNhanVien(nv);
        }
        public DataTable DanhSachNhanVien()
        {
            return dalNhanVien.DanhSachNhanVien();
        }
        public DataTable TimKiemNhanVien(string Ten)
        {
            return dalNhanVien.TimKiemNhanVien(Ten);
        }
        public bool XoaNhanVien(string MaNV)
        { return dalNhanVien.XoaNhanVien(MaNV); }
        public bool SuaNhanVien(DTO_NhanVien nv)
        { return dalNhanVien.SuaNhanVien(nv); }
        public bool DoiMatKhau(string email, string MatKhauCu, string MatKhauMoi)
        {
            return dalNhanVien.DoiMatKhau(email, MatKhauCu, MatKhauMoi);
        }
        public string HinhAnh(string Email)
        {
            return dalNhanVien.HinhAnh(Email);
        }
        public string HienTen(string Email)
        {
            return dalNhanVien.HienTen(Email);
        }
        public string HienNgaySinh(string Email)
        {
            return dalNhanVien.HienNgaySinh(Email);
        }
        public string HienDiaChi(string Email)
        {
            return dalNhanVien.HienDiaChi(Email);
        }
        public string HienSdt(string Email)
        {
            return dalNhanVien.HienSdt(Email);
        }
        public bool CapNhatProFile(string Email, string TenNV, DateTime? NgaySinh, string DiaChi, string sdt, string Hinh)
        {
            return dalNhanVien.CapNhatProFile(Email, TenNV, NgaySinh, DiaChi, sdt, Hinh);
        }    
    }
}
