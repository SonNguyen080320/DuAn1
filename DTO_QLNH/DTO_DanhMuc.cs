using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLNH
{
    public class DTO_DanhMuc
    {
        private int madanhmuc;
        private string tendanhmuc;
        public int MaDanhMuc { get => madanhmuc; set => madanhmuc = value; }
        public string TenDanhMuc { get => tendanhmuc; set => tendanhmuc = value; }
        public DTO_DanhMuc(int madanhmuc, string tendanhmuc)
        {

            this.madanhmuc = madanhmuc;
            this.tendanhmuc = tendanhmuc;
        }
        public DTO_DanhMuc(string tendanhmuc)
        {
            this.tendanhmuc = tendanhmuc;
        }
        public DTO_DanhMuc()
        {

        }
    }
}
