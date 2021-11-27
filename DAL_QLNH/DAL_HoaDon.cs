using DTO_QLNH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLNH
{
    public class DAL_HoaDon:DB_Connect
    {
       public bool ThemHoaDon(DTO_HoaDon hd)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HoaDon"
                };
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("TongTien",hd.TongTien),
                    new SqlParameter("MaBan",hd.MaBan),
                    new SqlParameter("email",hd.Email),
                     new SqlParameter("ThanhTien",hd.ThanhTien),
                      new SqlParameter("ThueVAT",hd.ThueVAT)
                };
                cmd.Parameters.AddRange(para);
                if(cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }    
            }
            finally { conn.Close(); }
            return false;
        }
        public bool XoaMonAn(string TenMon,int MaBan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_XoaMon"
                };

                cmd.Parameters.AddWithValue("TenMon", TenMon);
                cmd.Parameters.AddWithValue("MaBanHienTai", MaBan);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public bool CapNhatMonAn(string TenMon, int MaBan,int SoLuong)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_CapNhatMon"
                };

                cmd.Parameters.AddWithValue("TenMon", TenMon);
                cmd.Parameters.AddWithValue("MaBan", MaBan);
                cmd.Parameters.AddWithValue("SoLuong", SoLuong);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public bool ThanhToan(int maBan,float TongTien, float ThanhTien)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_ThanhToan"
                };
                cmd.Parameters.AddWithValue("maBan", maBan);
                cmd.Parameters.AddWithValue("TongTien", TongTien);
                cmd.Parameters.AddWithValue("ThanhTien", ThanhTien);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public bool ChuyenBan(int banmacdinh, string banmuonchuyen)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_ChuyenBan"
                };
                cmd.Parameters.AddWithValue("BanMacDinh", banmacdinh);
                cmd.Parameters.AddWithValue("TenBan", banmuonchuyen);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }

        /////////////////////////////
        public bool GopBan(int MaBanHienTai, string TenBanMuonGop)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_GopBan"
                };
                cmd.Parameters.AddWithValue("maBanHienTai", MaBanHienTai);
                cmd.Parameters.AddWithValue("tenBanMuonGop", TenBanMuonGop);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public DataTable ThongKeTongHop(DateTime TuNgay, DateTime DenNgay,string MaNV, string Ca)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_ThongKeTongHop"
                };
                cmd.Parameters.AddWithValue("TuNgay", TuNgay);
                cmd.Parameters.AddWithValue("DenNgay", DenNgay);
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("Ca", Ca);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public DataTable ThongKeChiTiet(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_ThongKeChiTiet"
                };
                cmd.Parameters.AddWithValue("TuNgay", TuNgay);
                cmd.Parameters.AddWithValue("DenNgay", DenNgay);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
    }
}
