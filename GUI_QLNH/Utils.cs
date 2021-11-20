using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNH
{
    public class Utils
    {
        // Kiểm tra xem textbox có rỗng hay ko
        // Rỗng thì hiển thị messagebox và focus => false
        // Đã nhập => true
        public static bool KiemTraTextBox(TextBox textBox, string name)
        {
            if (textBox.Text.Trim().Length == 0)
            {
                HienWarning($"Vui lòng nhập {name}");

                textBox.Focus();

                return false;
            }

            return true;
        }

        // Xác nhận như thoát, xoá, sửa
        public static bool XacNhan(string message)
        {
            DialogResult result = MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        public static void HienError(string message)
        {
            MessageBox.Show(message
                    , "Lỗi"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
        }

        public static void HienWarning(string message)
        {
            MessageBox.Show(message
                    , "Cảnh báo"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
        }

        public static void HienThongBao(string message)
        {
            MessageBox.Show(message
                    , "Thông báo"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
        }

        //----------------
        public static string MaHoa(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encrypdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encrypdata.Append(encrypt[i].ToString("X2"));

            }
            return encrypdata.ToString();
        }
    }
}
