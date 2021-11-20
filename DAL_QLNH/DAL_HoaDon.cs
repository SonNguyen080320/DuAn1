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
        public bool ThanhToan(int maBan,string TongTien, string ThanhTien)
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
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }

        /////////////////////////////
        public bool GopBan(int banmacdinh, string banmuongop)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GroupTable"
                };
                cmd.Parameters.AddWithValue("idtable1", banmacdinh);
                cmd.Parameters.AddWithValue("tenBan2", banmuongop);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
    }
}
