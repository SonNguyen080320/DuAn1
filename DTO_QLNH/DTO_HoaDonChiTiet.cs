using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_HoaDonChiTiet
    {
        private int maHD;
        private string tenMon;
        private int soLuong;

        public DTO_HoaDonChiTiet(int maHD, string tenMon, int soLuong)
        {
            this.maHD = maHD;
            this.tenMon = tenMon;
            this.soLuong = soLuong;
        }
        public DTO_HoaDonChiTiet(string tenMon, int soLuong)
        {
            this.tenMon = tenMon;
            this.soLuong = soLuong;
        }
        public DTO_HoaDonChiTiet()
        {
        }
        public int MaHD { get => maHD; set => maHD = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
