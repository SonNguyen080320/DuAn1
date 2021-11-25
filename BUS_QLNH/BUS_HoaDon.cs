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
        public bool ThanhToan(int maBan, float TongTien, float ThanhTien)
        {
            return dalHoaDon.ThanhToan(maBan,TongTien,ThanhTien);
        }
        public bool ChuyenBan(int banmacdinh,string banmuonchuyen)
        {
            return dalHoaDon.ChuyenBan(banmacdinh,banmuonchuyen);
        }
        public bool GopBan(int MaBanHienTai, string TenBanMuonGop)
        {
            return dalHoaDon.GopBan(MaBanHienTai, TenBanMuonGop);
        }
        public DataTable ThongKeTongHop(DateTime TuNgay, DateTime DenNgay, string MaNV,string Ca)
        {
            return dalHoaDon.ThongKeTongHop(TuNgay, DenNgay, MaNV,Ca);
        }
        public DataTable ThongKeChiTiet(DateTime TuNgay, DateTime DenNgay)
        {
            return dalHoaDon.ThongKeChiTiet(TuNgay, DenNgay);
        }
        public bool XoaMonAn(string TenMon, int MaBan)
        {
            return dalHoaDon.XoaMonAn(TenMon,MaBan);
        }
        public bool CapNhatMonAn(string TenMon, int MaBan, int SoLuong)
        {
            return dalHoaDon.CapNhatMonAn(TenMon, MaBan, SoLuong);
        }
    }
}
