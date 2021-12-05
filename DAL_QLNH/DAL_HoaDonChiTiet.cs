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
    public class DAL_HoaDonChiTiet : DB_Connect
    {
        public bool ThemHoaDonChiTiet(DTO_HoaDonChiTiet hdct)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HoaDonChiTiet"
                };
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("tenMon",hdct.TenMon),
                    new SqlParameter("SoLuong",hdct.SoLuong)
                };
                cmd.Parameters.AddRange(para);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public DataTable BillInfo(int maBan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_Billinfo"
                };
                cmd.Parameters.AddWithValue("MaBan", maBan);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public bool ThemMon(int maBan,string tenMon,int soLuong,float tong)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_UpdateHDCT"
                };
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("maBan",maBan),
                    new SqlParameter("tenMon",tenMon),
                    new SqlParameter("SoLuong",soLuong),
                    new SqlParameter("tong",tong)
                };
                cmd.Parameters.AddRange(para);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public string TenBan(int maBan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_TenBan"
                };
                cmd.Parameters.AddWithValue("mabanhientai", maBan);
                string tenNhanVien = cmd.ExecuteScalar().ToString();
                return tenNhanVien;
            }
            finally { conn.Close(); }
        }
        public DataTable HienNam()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HienNam"
                };
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public DataTable ThongKeTheoNam(int nam)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_DoanhThuCacThangTheoNam"
                };
                cmd.Parameters.AddWithValue("Nam", nam);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }    
    }
}
