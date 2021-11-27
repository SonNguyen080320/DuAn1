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
    public class BUS_Ban
    {
        DAL_Ban dalBan = new DAL_Ban();
        public DataTable HienBan()
        {
            return dalBan.HienThiBan();
        }
        public bool ThemBan(DTO_Ban ban)
        {
            return dalBan.ThemBan(ban);
        }
        public bool SuaBan(DTO_Ban ban)
        {
            return dalBan.SuaBan(ban);
        }
        public bool XoaBan(int maban)
        {
            return dalBan.XoaBan(maban);
        }
        public DataTable TimBan(string tenban)
        {
            return dalBan.TimBan(tenban);
        }
        public List<DTO_Ban> HienButtonsBan()
        {
            List<DTO_Ban> tableList = new List<DTO_Ban>();

            DataTable data = dalBan.HienThiBan();

            foreach (DataRow item in data.Rows)
            {
                DTO_Ban table = new DTO_Ban(item);
                tableList.Add(table);

            }
            return tableList;
        }
        public int tablewidth = 100;
        public int tableheight = 100;
        public bool BanCoNguoi(int maban)
        {
            return dalBan.BanCoNguoi(maban);
        }
        public bool TrangThaiBan(string TenBan)
        {
            return dalBan.TrangThaiBan(TenBan);
        }
        public DataTable TenBanGoiY()
        {
            return dalBan.TenBanGoiY();
        }
        public DataTable BanDaXoa()
        {
            return dalBan.BanDaXoa();
        }
        public bool PhucHoiBan(int MaBan)
        {
            return dalBan.PhucHoiBan(MaBan);
        }
    }
}
