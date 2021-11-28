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
    public class DAL_MonAn : DB_Connect
    {
        public DataTable HienThiMonAN()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DanhSachMonAn";
                cmd.Connection = conn;
                DataTable dtmonan = new DataTable();
                dtmonan.Load(cmd.ExecuteReader());
                return dtmonan;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ThemMonAn(DTO_MonAn monan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ThemMonAn";
                cmd.Parameters.AddWithValue("TenMon", monan.TenMon);
                cmd.Parameters.AddWithValue("DonViTinh", monan.DonViTinh);
                cmd.Parameters.AddWithValue("DonGia", monan.DonGia);
                cmd.Parameters.AddWithValue("HinhAnh", monan.HinhAnh);
                cmd.Parameters.AddWithValue("TinhTrang", monan.TinhTrang);
                cmd.Parameters.AddWithValue("TenDM", monan.TenDanhMuc);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
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
        public bool SuaMonAn(DTO_MonAn monan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SuaMonAn";
                cmd.Parameters.AddWithValue("ID", monan.MaMon);
                cmd.Parameters.AddWithValue("TenMon", monan.TenMon);
                cmd.Parameters.AddWithValue("DonViTinh", monan.DonViTinh);
                cmd.Parameters.AddWithValue("DonGia", monan.DonGia);
                cmd.Parameters.AddWithValue("HinhAnh", monan.HinhAnh);
                cmd.Parameters.AddWithValue("TinhTrang", monan.TinhTrang);
                cmd.Parameters.AddWithValue("TenDM", monan.TenDanhMuc);
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
        public bool XoaMonAn(int mamon)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_XoaMonAn";
                cmd.Parameters.AddWithValue("ID", mamon);
                cmd.Connection = conn;
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
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
        public DataTable TimMonAn(string tenmon)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TimKiemMonAn";
                cmd.Parameters.AddWithValue("TenMon", tenmon);

                cmd.Connection = conn;
                DataTable dtmonan = new DataTable();
                dtmonan.Load(cmd.ExecuteReader());
                return dtmonan;
            }
            finally
            {
                conn.Close();
            }

        }
        public DataTable TenMon(string tenDM)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_TenMonAnByIdDM"
                };
                cmd.Parameters.AddWithValue("TeDm", tenDM);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public DataTable TenDM(string tenMon)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_TenDMByTenMon"
                };
                cmd.Parameters.AddWithValue("TenMon", tenMon);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public string GiaMon(string tenMon)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_GiaMonAn"
                };
                cmd.Parameters.AddWithValue("TenMon", tenMon);
                string Gia = cmd.ExecuteScalar().ToString();
                return Gia;
            }
            finally { conn.Close(); }
        }
        public DataTable TenMonAnGoiY()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TenMonAnGoiY";
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable MonAnDaXoa()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_MonAnDaXoa";
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            finally
            {
                conn.Close();
            }
        }
        public bool PhucHoiMon(int mamon)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PhucHoiMonAn";
                cmd.Parameters.AddWithValue("MaMon", mamon);
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
    }
}
