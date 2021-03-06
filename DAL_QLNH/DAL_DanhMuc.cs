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
    public class DAL_DanhMuc : DB_Connect
    {
        public DataTable HienThiDanhMucMonAN()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DanhSachDanhMuc";
                cmd.Connection = conn;
                DataTable dtdanhmucmonan = new DataTable();
                dtdanhmucmonan.Load(cmd.ExecuteReader());
                return dtdanhmucmonan;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ThemDanhMuc(DTO_DanhMuc danhmuc)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ThemDanhMuc";
                cmd.Parameters.AddWithValue("TenDM", danhmuc.TenDanhMuc);
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
        public bool SuaDanhMuc(DTO_DanhMuc danhmuc)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CapNhatDanhMuc";
                cmd.Parameters.AddWithValue("ID", danhmuc.MaDanhMuc);
                cmd.Parameters.AddWithValue("TenDM", danhmuc.TenDanhMuc);
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
        public bool XoaDanhMuc(int madanhmuc)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_XoaDanhMuc";
                cmd.Parameters.AddWithValue("ID", madanhmuc);
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
        public DataTable TimDanhMuc(string tendanhmuc)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TimKiemDanhMuc";
                cmd.Parameters.AddWithValue("TenDM", tendanhmuc);
                cmd.Connection = conn;
                DataTable dtdanhmucmonan = new DataTable();
                dtdanhmucmonan.Load(cmd.ExecuteReader());
                return dtdanhmucmonan;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
