using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_MonAn
    {
        private int mamon;
        private string tenmon;
        private string donvitinh;
        private float dongia;
        private string hinhanh;
        private int tinhtrang;
        private string tendanhmuc;
        public int MaMon { get => mamon; set => mamon = value; }
        public string TenMon { get => tenmon; set => tenmon = value; }
        public string DonViTinh { get => donvitinh; set => donvitinh = value; }
        public float DonGia { get => dongia; set => dongia = value; }
        public string HinhAnh { get => hinhanh; set => hinhanh = value; }
        public int TinhTrang { get => tinhtrang; set => tinhtrang = value; }
        public string TenDanhMuc { get => tendanhmuc; set => tendanhmuc = value; }
        public DTO_MonAn(int mamon, string tenmon, string donvitinh, float dongia, string hinhanh, int tinhtrang, string tendanhmuc)
        {
            this.mamon = mamon;
            this.tenmon = tenmon;
            this.donvitinh = donvitinh;
            this.dongia = dongia;
            this.hinhanh = hinhanh;
            this.tinhtrang = tinhtrang;
            this.tendanhmuc = tendanhmuc;
        }
        public DTO_MonAn(string tenmon, string donvitinh, float dongia, string hinhanh, int tinhtrang, string tendanhmuc)
        {

            this.tenmon = tenmon;
            this.donvitinh = donvitinh;
            this.dongia = dongia;
            this.hinhanh = hinhanh;
            this.tinhtrang = tinhtrang;
            this.tendanhmuc = tendanhmuc;
        }
        public DTO_MonAn()
        {

        }
    }
}
