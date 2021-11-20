using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_HoaDon
    {
        private int maHD;
        private DateTime timeCheckIn;
        private DateTime timeCheckOut;
        private float thanhtien;
        private int thuevat;
        private string tongTien;
        private int maBan;
        private string email;
        private bool trangThai;

        public DTO_HoaDon(int maHD, DateTime timeCheckIn, DateTime timeCheckOut,float thanhtien,int thuevat, string tongTien, int maBan, string email, bool trangThai)
        {
            this.maHD = maHD;
            this.timeCheckIn = timeCheckIn;
            this.timeCheckOut = timeCheckOut;
            this.thanhtien = thanhtien;
            this.thuevat = thuevat;
            this.tongTien = tongTien;
            this.maBan = maBan;
            this.email = email;
            this.trangThai = trangThai;
        }
        public DTO_HoaDon(string tongTien, int maBan, string email)
        {
            this.tongTien = tongTien;
            this.maBan = maBan;
            this.email = email;
        }
        public DTO_HoaDon(string tongTien, int maBan, string email,float ThanhTien,int VAT)
        {
            this.tongTien = tongTien;
            this.maBan = maBan;
            this.email = email;
            this.thanhtien = ThanhTien;
            this.thuevat = VAT;
        }
        public DTO_HoaDon(DateTime timeCheckIn, DateTime timeCheckOut,float thanhtien, int thuevat, string tongTien, int maBan, string email, bool trangThai)
        {
            this.timeCheckIn = timeCheckIn;
            this.timeCheckOut = timeCheckOut;
            this.thanhtien = thanhtien;
            this.thuevat = thuevat;
            this.tongTien = tongTien;
            this.maBan = maBan;
            this.email = email;
            this.trangThai = trangThai;
        }
        public DTO_HoaDon()
        {
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public DateTime TimeCheckIn { get => timeCheckIn; set => timeCheckIn = value; }
        public DateTime TimeCheckOut { get => timeCheckOut; set => timeCheckOut = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        public int MaBan { get => maBan; set => maBan = value; }
        public string Email{ get => email; set => email = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public float ThanhTien{ get => thanhtien; set => thanhtien = value; }
        public int ThueVAT { get => thuevat; set => thuevat = value; }
    }
}
