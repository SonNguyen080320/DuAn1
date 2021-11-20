using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLNH;
using BUS_QLNH;

namespace GUI_QLNH.FORMS
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private string _Email;
        public frmDoiMatKhau(string email):this()
        {
            _Email = email;
            
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtXacNhanMatKhau.PasswordChar = '*';
            btnAn.Hide();
            btnHien.Show();
            txtEmail.Text = _Email;
            txtEmail.Enabled = false;
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private void btnHien_Click(object sender, EventArgs e)
        {
            this.txtMatKhauCu.PasswordChar = '\0';
            this.txtMatKhauMoi.PasswordChar = '\0';
            this.txtXacNhanMatKhau.PasswordChar = '\0';
            btnAn.Show();
            btnHien.Hide();
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtXacNhanMatKhau.PasswordChar = '*';
            btnHien.Show();
            btnAn.Hide();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!Utils.KiemTraTextBox(txtMatKhauCu, "Mật khẩu củ") || !Utils.KiemTraTextBox(txtMatKhauMoi, "Mật khẩu mới") ||
               !Utils.KiemTraTextBox(txtXacNhanMatKhau, "Xác nhận lại mật khẩu"))
            {
                return;
            }
            if(txtMatKhauMoi.Text.Trim().Length!=txtXacNhanMatKhau.Text.Trim().Length)
            {
                Utils.HienError("Xác nhận mật khẩu không khớp");
            }    
            else
            {
                string PassMoi = Utils.MaHoa(txtMatKhauMoi.Text);
                string PassCu = Utils.MaHoa(txtMatKhauCu.Text);
                if (Utils.XacNhan("Bạn muốn cập nhật mật khẩu"))
                {
                    if (busNhanVien.DoiMatKhau(txtEmail.Text, PassCu, PassMoi))
                    {
                        FORMS.frmQuanLyNhanVien.sendEmail(txtEmail.Text, txtMatKhauMoi.Text);
                        Utils.HienThongBao("Cập nhật mật khẩu thành công. Đăng nhập lại để sử dụng hệ thống");
                        Application.Restart();

                    }
                }   
            }    
        } 
    }
}
