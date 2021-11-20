using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_Ban
    {
        private int maban;
        private string tenban;
        private int trangthai;
        public int Maban { get => maban; set => maban = value; }
        public string TenBan { get => tenban; set => tenban = value; }
        public int TrangThai { get => trangthai; set => trangthai = value; }
        public DTO_Ban(int id, string tenban, int trangthai)
        {
            this.Maban = id;
            this.TenBan = tenban;
            this.TrangThai = trangthai;
        }
        public DTO_Ban(string tenban, int trangthai)
        {
            this.TenBan = tenban;
            this.TrangThai = trangthai;
        }
        public DTO_Ban(DataRow row)
        {
            this.maban = Convert.ToInt32(row["MaBan"]);
            this.tenban = row["TenBan"].ToString();
            this.trangthai = Convert.ToInt32(row["TrangThai"]);
        }
        public DTO_Ban()
        {

        }
    }
}
