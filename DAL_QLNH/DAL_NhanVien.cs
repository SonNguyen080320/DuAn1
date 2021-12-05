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
    public class DAL_NhanVien : DB_Connect
    {
        public DataTable TenNVGoiY()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TenNVGoiY";
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
        public DataTable NvDaXoa()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_NVDaXoa";
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
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("email", nv.Email),
                    new SqlParameter("pass", nv.MatKhau)
                };

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_DangNhap",
                };

                cmd.Parameters.AddRange(parameters);

                int db_result = Convert.ToInt32(cmd.ExecuteScalar());

                if (db_result > 0) return true;
            }
            catch (Exception) { }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public bool VaiTro(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_VaiTroNV"
                };
                cmd.Parameters.AddWithValue("Email", email);
                if(Convert.ToInt32(cmd.ExecuteScalar())>0)
                {
                    return true;
                } 
                else
                {
                    return false;
                }    
            }
            finally { conn.Close(); }
        }
        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ThemNV";
                cmd.Parameters.AddWithValue("TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("Email", nv.Email);
                cmd.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("SDT", nv.SoDT);
                cmd.Parameters.AddWithValue("Vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("TrangThai", nv.TrangThai);
                cmd.Parameters.AddWithValue("HinhAnh", nv.HinhAnh);
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
        public DataTable DanhSachNhanVien()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_DanhSachNV"
                };
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public DataTable TimKiemNhanVien(string Ten)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_TimKiemNV"
                };
                cmd.Parameters.AddWithValue("TenNV", Ten);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { conn.Close(); }
        }
        public bool XoaNhanVien(string MaNV)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_XoaNhanVien"
                };
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                if(Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }    
            }
            finally { conn.Close(); }
            return false;
        }
        public bool PhucHoiNV(string MaNV)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_PhucHoiNV"
                };
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { conn.Close(); }
            return false;
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SuaNV";
                cmd.Parameters.AddWithValue("MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("Email", nv.Email);
                cmd.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("Diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("SDT", nv.SoDT);
                cmd.Parameters.AddWithValue("vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("TrangThai", nv.TrangThai);
                cmd.Parameters.AddWithValue("HinhAnh", nv.HinhAnh);
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
        public bool DoiMatKhau(string email, string MatKhauCu, string MatKhauMoi)
        {
            try
            {
                conn.Open();
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("email",email),
                    new SqlParameter("MatKhauCu",MatKhauCu),
                    new SqlParameter("MatKhauMoi",MatKhauMoi)
                };
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_DoiMatKhau"
                };
                cmd.Parameters.AddRange(para);
                if(Convert.ToInt32(cmd.ExecuteScalar())>0)
                {
                    return true;
                }    
            }
            finally { conn.Close(); }
            return false;
        }
        public string HinhAnh(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_Hinh"
                };
                cmd.Parameters.AddWithValue("email", Email);
                string hinh = cmd.ExecuteScalar().ToString();
                return hinh;
            }
            finally { conn.Close(); }
        }
        public string HienTen(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HienTenNV"
                };
                cmd.Parameters.AddWithValue("email", Email);
                string tenNhanVien = cmd.ExecuteScalar().ToString();
                return tenNhanVien;
            }
            finally { conn.Close(); }
        }
        public string HienNgaySinh(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HienNgaySinh"
                };
                cmd.Parameters.AddWithValue("email", Email);
                string NgaySinh = cmd.ExecuteScalar().ToString();
                return NgaySinh;
            }
            finally { conn.Close(); }
        }
        public string HienDiaChi(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HienDiaChi"
                };
                cmd.Parameters.AddWithValue("email", Email);
                string DiaChi = cmd.ExecuteScalar().ToString();
                return DiaChi;
            }
            finally { conn.Close(); }
        }
        public string HienSdt(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_HienSdt"
                };
                cmd.Parameters.AddWithValue("email", Email);
                string Sdt = cmd.ExecuteScalar().ToString();
                return Sdt;
            }
            finally { conn.Close(); }
        }
        public bool CapNhatProFile(string Email,string TenNV,DateTime? NgaySinh,string DiaChi,string sdt,string Hinh)
        {
            try
            {
                conn.Open();
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("email",Email),
                    new SqlParameter("TenNv",TenNV),
                    new SqlParameter("NgaySinh",NgaySinh),
                    new SqlParameter("DiaChi",DiaChi),
                    new SqlParameter("Sdt",sdt),
                    new SqlParameter("HinhAnh",Hinh)
                };
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_UpdateProfile"
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
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_KiêmTraNhanVien";
                cmd.Parameters.AddWithValue("Email", email);
               // cmd.Parameters.AddWithValue("MatKhau", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool TaoMatKhau(string email, string matkhaumoi)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Matkhau", matkhaumoi);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
