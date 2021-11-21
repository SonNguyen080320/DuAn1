using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNH
{
    public partial class frmGiaoDien : Form
    {
        // private Form activeForm;

        public static string _Email;

        public frmGiaoDien()
        {
            InitializeComponent();
            PanelMacDinh();
        }
        public frmGiaoDien(string email)
        {
            _Email = email;
            InitializeComponent();
            PanelMacDinh();
        }
        private void frmGiaoDien_Load(object sender, EventArgs e)
        {
            if(_Email=="Admin"||_Email=="admin")
            {
                btndoimatkhau.Hide();
            }    
            this.WindowState = FormWindowState.Maximized;
            lbchao.Text = "Chào: " + _Email;
            timer1.Start();
            lbGio.Text = DateTime.Now.ToString();

        }
        private void PanelMacDinh()// panel mặc định
        {
            pnlquanlythucpham.Visible = false;
            pnlthongke.Visible = false;
        }
        private void AnPanel()//ẩn panel
        {
            if (pnlquanlythucpham.Visible == true)
            {
                pnlquanlythucpham.Visible = false;
            }
            if (pnlthongke.Visible==true)
            {
                pnlthongke.Visible = false;
            }
        }
        private void HienPanel(Panel quanlythucpham)// hiển thị panel
        {
            if (quanlythucpham.Visible == false)
            {
                AnPanel();
                quanlythucpham.Visible = true;
            }
            else
            {
                quanlythucpham.Visible = false;
            }
        }
        private Form activeForm = null;
        private void MoForm(Form childForm)//mở form
        {
            if (activeForm != null)
            {
                activeForm.Close();
                
            }
           
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlchinh.Controls.Add(childForm);
            this.pnlchinh.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        

        private void btnquanlythucpham_Click(object sender, EventArgs e)
        {
            HienPanel(pnlquanlythucpham);

        }

        private void btndanhmucmonan_Click(object sender, EventArgs e)
        {
            //code
            lbtitel.Text = "DANH MỤC MÓN ĂN";
            MoForm(new FORMS.frmQuanLyDanhMucMonAn());
           // panelmacdinhkhiloadform();
        }

        private void btnmonan_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "MÓN ĂN";
            MoForm(new FORMS.frmQuanLyMonAn());
            //code
           // panelmacdinhkhiloadform();
        }

        private void bnquanlythongke_Click(object sender, EventArgs e)
        {
            HienPanel(pnlthongke);
        }

       

        private void btnthongketheongay_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "THỐNG KÊ THEO NGÀY";
            MoForm(new FORMS.frmThongKeTheoNgay());
            //code
           // panelmacdinhkhiloadform();
        }

        private void btnquanlynhanvien_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "QUẢN LÝ NHÂN VIÊN";
            MoForm(new FORMS.frmQuanLyNhanVien());
            //code
            PanelMacDinh();
        }

        private void btnban_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "BÀN";
            MoForm(new FORMS.frmQuanLyBan());
            //code
            PanelMacDinh();
        }

        private void btndatmon_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "ĐẶT MÓN";
            MoForm(new FORMS.frmOrderMonAn());
            //code
            PanelMacDinh();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "HOME";
            if (activeForm != null)
            {
                activeForm.Close();
                PanelMacDinh();
            }
            //code
            PanelMacDinh();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParan);


        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnphongto_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btthoattamthoi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bnthongtinnhanvien_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "ProFile";
            MoForm(new FORMS.frmThongTinCaNhan(_Email));
            //code
            PanelMacDinh();
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            lbtitel.Text = "Đổi mật khẩu";
            MoForm(new FORMS.frmDoiMatKhau(_Email));
            //code
            PanelMacDinh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGio.Text = DateTime.Now.ToString();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            if (Utils.XacNhan("Bạn muốn đăng xuất?"))
            {
                this.Close();
            }
        }
    }
}
