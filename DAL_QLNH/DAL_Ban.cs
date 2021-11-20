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
    public class DAL_Ban : DB_Connect
    {
        public DataTable HienThiBan()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DanhSachBan";
                cmd.Connection = conn;
                DataTable dtban = new DataTable();
                dtban.Load(cmd.ExecuteReader());
                return dtban;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ThemBan(DTO_Ban ban)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ThemBan";
                cmd.Parameters.AddWithValue("TenBan", ban.TenBan);
                cmd.Parameters.AddWithValue("TrangThai", ban.TrangThai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool SuaBan(DTO_Ban ban)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CapNhatBan";
                cmd.Parameters.AddWithValue("ID", ban.Maban);
                cmd.Parameters.AddWithValue("TenBan", ban.TenBan);
                cmd.Parameters.AddWithValue("TrangThai", ban.TrangThai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                conn.Close();

            }
            return false;
        }
        public bool XoaBan(int maban)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_XoaBan";
                cmd.Parameters.AddWithValue("ID", maban);
                cmd.Connection = conn;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataTable TimBan(string tenban)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TimKiemBan";
                cmd.Parameters.AddWithValue("TenBan", tenban);
                cmd.Connection = conn;
                DataTable dtban = new DataTable();
                dtban.Load(cmd.ExecuteReader());
                return dtban;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool BanCoNguoi(int maban)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BanCoNguoi";
                cmd.Parameters.AddWithValue("MaBan", maban);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                conn.Close();

            }
            return false;
        }
    }
}
