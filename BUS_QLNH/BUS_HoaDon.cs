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
    public class BUS_HoaDon
    {
        DAL_HoaDon dalHoaDon = new DAL_HoaDon();
        public bool ThemHoaDon(DTO_HoaDon hd)
        {
            return dalHoaDon.ThemHoaDon(hd);
        }
        public bool ThanhToan(int maBan, string TongTien, string ThanhTien)
        {
            return dalHoaDon.ThanhToan(maBan,TongTien,ThanhTien);
        }
        public bool ChuyenBan(int banmacdinh,string banmuonchuyen)
        {
            return dalHoaDon.ChuyenBan(banmacdinh,banmuonchuyen);
        }
        public bool GopBan(int banmacdinh, string banmuongop)
        {
            return dalHoaDon.GopBan(banmacdinh, banmuongop);
        }
    }
}
