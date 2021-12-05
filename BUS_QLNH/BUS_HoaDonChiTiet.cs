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
    public class BUS_HoaDonChiTiet
    {
        DAL_HoaDonChiTiet dalHoaDonCT = new DAL_HoaDonChiTiet();
        public bool ThemHoaDonChiTiet(DTO_HoaDonChiTiet hdct)
        {
            return dalHoaDonCT.ThemHoaDonChiTiet(hdct);
        }
        public DataTable BillInfo(int maBan)
        {
            return dalHoaDonCT.BillInfo(maBan);
        }
        public bool CapNhatHoaDon(int maBan, string tenMon, int soLuong,float tong)
        {
            return dalHoaDonCT.ThemMon(maBan, tenMon, soLuong,tong);
        }

        public string TenBan(int maBan)
        {
            return dalHoaDonCT.TenBan(maBan);
        }
        public DataTable HienNam()
        {
            return dalHoaDonCT.HienNam();
        }
        public DataTable ThongKeTheoNam(int nam)
        {
            return dalHoaDonCT.ThongKeTheoNam(nam);
        }
    }
}
