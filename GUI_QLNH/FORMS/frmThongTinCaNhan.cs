using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLNH;
using BUS_QLNH;

namespace GUI_QLNH.FORMS
{
    public partial class frmThongTinCaNhan : Form
    {
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private string _Email;
        // private string _HoTen;
        string TenNhanVien;
        string NgaySinh;
        string DiaChi;
        string Sdt;
        public frmThongTinCaNhan(string email):this()
        {
            _Email = email;
           // _HoTen = hoten;
            txtHinh = busNhanVien.HinhAnh(_Email);
            checkurlimage = txtHinh;
            TenNhanVien = busNhanVien.HienTen(_Email);
            NgaySinh = busNhanVien.HienNgaySinh(_Email);
            DiaChi = busNhanVien.HienDiaChi(_Email);
            Sdt = busNhanVien.HienSdt(_Email);

        }    
        private void formThongTinCaNhan_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            loadForm();
            if(_Email=="Admin"||_Email=="admin")
            {
                btncapnhat.Hide();
                btnMoHinh.Hide();
            }
            dtNgaySinh.Value = new DateTime(2000, 01, 01);
        }
        string checkurlimage;
        string filename;
        string filesavepath;
        string fileaddress;
        string txtHinh;
        string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
        void loadForm()
        {
            pichinhcanhan.Image = Image.FromFile(saveDirectory + busNhanVien.HinhAnh(_Email));
            txtEmail.Text = _Email;
            txtHoTen.Text = TenNhanVien;
            txtDiaChi.Text = DiaChi;
            txtSDT.Text = Sdt;
            dtNgaySinh.Text = NgaySinh;
            txtEmail.Enabled = false;
            
        }
        
        private void btnMoHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = " Bitmap(*.bmp)|*.bmp|JPEG(*jpg)|*.jpg|GIF(*.gif)|*.gif|All Files(*.*)|*.*";
            dlgOpen.FilterIndex = 1;
            dlgOpen.Title = "Cập nhật hình ảnh";
            dlgOpen.RestoreDirectory = true;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileaddress = dlgOpen.FileName;
                
                filename = Path.GetFileName(dlgOpen.FileName);
                saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filesavepath = saveDirectory + "\\Images\\" + filename;
                if (File.Exists(filesavepath))
                {
                    Utils.HienWarning("Hình đã tồn tại. Vui lòng chọn hình mới");
                }
                else
                {
                    txtHinh = "\\Images\\" + filename;
                    pichinhcanhan.Image = Image.FromFile(fileaddress);
                }
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if(!Utils.KiemTraTextBox(txtEmail,"Email")||!Utils.KiemTraTextBox(txtHoTen,"Tên")||!Utils.KiemTraTextBox(txtDiaChi,"Địa chỉ")||
                   !Utils.KiemTraTextBox(txtSDT,"SDT"))
            {
                return;
            }
            if(Utils.XacNhan("Bạn muốn cập nhật thông tin của mình?"))
            {
                if(busNhanVien.CapNhatProFile(txtEmail.Text,txtHoTen.Text,dtNgaySinh.Value,txtDiaChi.Text,txtSDT.Text,txtHinh))
                {
                    if(checkurlimage!=txtHinh)
                    {
                        File.Copy(fileaddress, filesavepath, true);
                    }    
                    Utils.HienThongBao("Cập nhật thông tin thành công");
                }
            }    
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0') || (e.KeyChar > '9')) e.Handled = true;
            if (e.KeyChar == 8) e.Handled = false;
        }
    }
}
