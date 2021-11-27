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
    public class BUS_DanhMuc
    {
        DAL_DanhMuc daldanhmucmonan = new DAL_DanhMuc();
        public DataTable HienThiDanhMucMonAN()
        {
            return daldanhmucmonan.HienThiDanhMucMonAN();
        }
        public bool ThemDanhMucMonAn(DTO_DanhMuc danhmuc)
        {
            return daldanhmucmonan.ThemDanhMuc(danhmuc);
        }
        public bool SuaDanhMuc(DTO_DanhMuc danhmuc)
        {
            return daldanhmucmonan.SuaDanhMuc(danhmuc);
        }
        public bool XoaDanhMuc(int madanhmuc)
        {
            return daldanhmucmonan.XoaDanhMuc(madanhmuc);
        }
        public DataTable TimDanhMuc(string tendanhmuc)
        {
            return daldanhmucmonan.TimDanhMuc(tendanhmuc);
        }
        public DataTable TenDMGoiY()
        {
            return daldanhmucmonan.TenDMGoiY();
        }
        public DataTable DmDaXoa()
        {
            return daldanhmucmonan.DmDaXoa();
        }
        public bool PhucHoiDM(int madanhmuc)
        {
            return daldanhmucmonan.PhucHoiDM(madanhmuc);
        }
    }
}
