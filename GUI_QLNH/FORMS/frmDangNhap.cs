﻿using BUS_QLNH;
using DTO_QLNH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNH.FORMS
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public static string Email;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            bool result = Utils.XacNhan("Bạn có chắc chắn muốn thoát hay không ?");

            if (result) Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            // Kiểm tra textbox có rỗng hay không ?
            if (!Utils.KiemTraTextBox(txtEmail, "email")
                || !Utils.KiemTraTextBox(txtMatKhau, "mật khẩu")) return;
            
            DTO_NhanVien nv = new DTO_NhanVien
            {
                Email = txtEmail.Text,
                MatKhau = Utils.MaHoa(txtMatKhau.Text),
                

            };
            if (chkGhiNhoTaiKhoan.Checked == true)
            {
                Properties.Settings.Default.TaiKhoan = txtEmail.Text;
                Properties.Settings.Default.MatKhau = txtMatKhau.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.TaiKhoan = "";
                Properties.Settings.Default.MatKhau = "";
                Properties.Settings.Default.Save();
            }
            bool result_from_bus = busNhanVien.NhanVienDangNhap(nv);
            
            if (result_from_bus)
            {
                
                Email = txtEmail.Text;
                frmGiaoDien fGiaoDien = new frmGiaoDien(txtEmail.Text);

                this.Hide();
                fGiaoDien.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại email hoặc mật khẩu.");
                txtEmail.Focus();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Properties.Settings.Default.TaiKhoan;
            txtMatKhau.Text = Properties.Settings.Default.MatKhau;
            chkGhiNhoTaiKhoan.Checked = true;
            this.txtMatKhau.PasswordChar = '*';
            btnHien.Show();
            btnAn.Hide();
            //this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
            //              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            this.txtMatKhau.PasswordChar = '*';
            btnAn.Hide();
            btnHien.Show();
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            this.txtMatKhau.PasswordChar = '\0';
            btnAn.Show();
            btnHien.Hide();
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder buider = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                buider.Append(ch);

            }
            if (lowerCase)
                return buider.ToString().ToLower();
            return buider.ToString();
        }
        public int randomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static void sendEmail(string email, string matkhau) // gửi email
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential("sonnqps18832@fpt.edu.vn", "son080320");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("sonnqps18832@fpt.edu.vn");
                Msg.To.Add(email);
                Msg.Subject = "Cập nhật mật khẩu";
                Msg.Body = "Chào anh/chị. Mật khẩu để truy cập phần mềm là :" + matkhau;
                client.Credentials = cred;
                client.Send(Msg);
                MessageBox.Show("Một Email mật khẩu đã được gởi đi!");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(randomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = Utils.MaHoa(builder.ToString());
                    busNhanVien.TaoMatKhau(txtEmail.Text, matkhaumoi);
                    sendEmail(txtEmail.Text, builder.ToString());

                }
                else
                {
                    MessageBox.Show("email không tồn tại, vui lòng nhập lại email !");

                }
            }
            else
            {
                MessageBox.Show("bạn cần nhập email nhận thông tin khôi phục mật khẩu");
            }
        }
    }
}
