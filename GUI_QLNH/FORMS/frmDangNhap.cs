using BUS_QLNH;
using DTO_QLNH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
