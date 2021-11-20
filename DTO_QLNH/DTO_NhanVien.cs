using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_NhanVien
    {
        private string maNV;
        private string tenNV;
        private string email;
        private DateTime? ngaySinh;
        private int gioiTinh;
        private string diaChi;
        private string soDT;
        private int vaiTro;
        private int trangThai;
        private string hinhAnh;
        private string matKhau;

        public DTO_NhanVien()
        {

        }

        public DTO_NhanVien(string tenNV, string email, DateTime? ngaySinh, int gioiTinh,
           string diaChi, string soDT, int vaiTro, int trangThai, string hinhAnh)
        {
            this.TenNV = tenNV;
            this.Email = email;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.SoDT = soDT;
            this.VaiTro = vaiTro;
            this.TrangThai = trangThai;
            this.HinhAnh = hinhAnh;
        }
        public DTO_NhanVien(string maNV,string tenNV, string email, DateTime? ngaySinh, int gioiTinh,
           string diaChi, string soDT, int vaiTro, int trangThai, string hinhAnh)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.email = email;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.soDT = soDT;
            this.vaiTro = vaiTro;
            this.trangThai = trangThai;
            this.hinhAnh = hinhAnh;
        }

        public DTO_NhanVien(string tenNV, string email, DateTime? ngaySinh, int gioiTinh,
            string diaChi, string soDT, int vaiTro, int trangThai, string hinhAnh,
            string matKhau)
        {
            this.TenNV = tenNV;
            this.Email = email;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.SoDT = soDT;
            this.VaiTro = vaiTro;
            this.TrangThai = trangThai;
            this.HinhAnh = hinhAnh;
            this.MatKhau = matKhau;
        }

        public string TenNV { get => tenNV; set => tenNV = value; }
        public string Email { get => email; set => email = value; }
        public DateTime? NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public int VaiTro { get => vaiTro; set => vaiTro = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaNV { get => maNV; set => maNV = value; }
    }
}
