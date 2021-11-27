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
    public class BUS_MonAn
    {

        DAL_MonAn dalmonan = new DAL_MonAn();
        public DataTable HienThiMonAN()
        {
            return dalmonan.HienThiMonAN();
        }
        public bool ThemMonAn(DTO_MonAn monan)
        {
            return dalmonan.ThemMonAn(monan);
        }
        public bool SuaMonAn(DTO_MonAn monan)
        {
            return dalmonan.SuaMonAn(monan);
        }
        public bool XoaMonAn(int mamon)
        {
            return dalmonan.XoaMonAn(mamon);
        }
        public DataTable TimMonAn(string tenmon)
        {
            return dalmonan.TimMonAn(tenmon);
        }
        public DataTable TenMon(string tenDM)
        {
            return dalmonan.TenMon(tenDM);
        }
        public string GiaMon(string tenMon)
        {
            return dalmonan.GiaMon(tenMon);
        }
        public DataTable TenDM(string tenMon)
        {
            return dalmonan.TenDM(tenMon);
        }
        public DataTable TenMonAnGoiY()
        {
            return dalmonan.TenMonAnGoiY();
        }
        public DataTable MonAnDaXoa()
        {
            return dalmonan.MonAnDaXoa();
        }
        public bool PhucHoiMon(int mamon)
        {
            return dalmonan.PhucHoiMon(mamon);
        }    
    }
}
