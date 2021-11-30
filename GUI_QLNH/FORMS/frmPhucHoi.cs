using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLNH;

namespace GUI_QLNH.FORMS
{
    public partial class frmPhucHoi : Form
    {
        private string _Title;
        public frmPhucHoi()
        {
            InitializeComponent();
        }
        public frmPhucHoi(string title) : this()
        {
            _Title = title;
        }
        BUS_Ban busBan = new BUS_Ban();
        BUS_MonAn busMonAn = new BUS_MonAn();
        BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        void loadBanDaXoa()
        {// hiển thị danh sách bàn đã xóa
            dtgvPhucHoi.DataSource = busBan.BanDaXoa();
        }
        void loadMonAnDaXoa()
        {//hiển thị danh sách món ăn đã xóa
            dtgvPhucHoi.DataSource = busMonAn.MonAnDaXoa();
        }
        void loadDmDaXoa()
        {// heienr thị danh sách danh mục đã xóa
            dtgvPhucHoi.DataSource = busDanhMuc.DmDaXoa();
        }
        void loadNvDaXoa()
        {// hiển thị danh sách nhân viên đã xóa
            dtgvPhucHoi.DataSource = busNhanVien.NvDaXoa();
        }
        void ReSetValue()
        {
            txtEmail.Enabled = false;
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtTen.Text = "";
            txtEmail.Text = "";
            txtMa.Text = "";
            btnPhucHoi.Enabled = false;
        }
        private void btnPhucHoi_Click(object sender, EventArgs e)
        {//phục hồi sẽ xét theo tiêu đề của form 
            if (lbTilte.Text == "Danh Sách Bàn Đã Xóa")
            {
                if (Utils.XacNhan("Bạn muốn phục hồi " + txtTen.Text))
                {
                    if (busBan.PhucHoiBan(int.Parse(txtMa.Text)))
                    {
                        Utils.HienThongBao("Phục hồi " + txtTen.Text + " thành công");
                        ReSetValue();
                        loadBanDaXoa();
                    }
                }
            }
            else if (lbTilte.Text == "Danh Sách Món Ăn Đã Xóa")
            {
                if (Utils.XacNhan("Bạn muốn phục hồi " + txtTen.Text))
                {
                    if (busMonAn.PhucHoiMon(int.Parse(txtMa.Text)))
                    {
                        Utils.HienThongBao("Phục hồi " + txtTen.Text + " thành công");
                        ReSetValue();
                        loadMonAnDaXoa();
                    }
                }
            }
            else if (lbTilte.Text == "Danh Sách Danh Mục Đã Xóa")
            {
                if (Utils.XacNhan("Bạn muốn phục hồi " + txtTen.Text))
                {
                    if (busDanhMuc.PhucHoiDM(int.Parse(txtMa.Text)))
                    {
                        Utils.HienThongBao("Phục hồi " + txtTen.Text + " thành công");
                        ReSetValue();
                        loadDmDaXoa();
                    }
                }
            }
            else
            {
                if (Utils.XacNhan("Bạn muốn phục hồi " + txtTen.Text))
                {
                    if (busNhanVien.PhucHoiNV(txtMa.Text))
                    {
                        Utils.HienThongBao("Phục hồi " + txtTen.Text + " thành công");
                        ReSetValue();
                        loadNvDaXoa();
                    }
                }
            }    
        }

        private void frmPhucHoi_Load(object sender, EventArgs e)
        {
            // hiển thị danh sách dựa theo tiêu đề của form
            lbTilte.Text = _Title;
            if(lbTilte.Text== "Danh Sách Bàn Đã Xóa")
            {
                loadBanDaXoa();
                lbMa.Text = "Mã Bàn: ";
                lbTen.Text = "Tên Bàn: ";
                lbEmail.Visible = false;
                txtEmail.Visible = false;
            }    
            else if(lbTilte.Text == "Danh Sách Món Ăn Đã Xóa")
            {
                loadMonAnDaXoa();
                lbMa.Text = "Mã Món: ";
                lbTen.Text = "Tên Món: ";
                lbEmail.Visible = false;
                txtEmail.Visible = false;
            }
            else if (lbTilte.Text == "Danh Sách Danh Mục Đã Xóa")
            {
                loadDmDaXoa();
                lbMa.Text = "Mã Danh Mục: ";
                lbTen.Text = "Tên Danh Mục: ";
                lbEmail.Visible = false;
                txtEmail.Visible = false;
            }
            else
            {
                loadNvDaXoa();
                lbMa.Text = "Mã Nhân Viên: ";
                lbTen.Text = "Tên Nhân Viên: ";
                lbEmail.Text = "Email: ";
            }    
        }

        private void dtgvPhucHoi_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {// hiển thị thông tin ra các vị trí tương ứng khi click vào tùy theo tiêu đề form
            if (e.RowIndex > -1)
            {
                DataGridViewRow rows = this.dtgvPhucHoi.Rows[e.RowIndex];
                if (rows.Cells[1].Value.ToString().Count() == 0)
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                    ReSetValue();
                }
                else
                {
                    if (lbTilte.Text == "Danh Sách Bàn Đã Xóa")
                    {
                        btnPhucHoi.Enabled = true;
                        txtMa.Text = rows.Cells[0].Value.ToString();
                        txtTen.Text = rows.Cells[1].Value.ToString();
                    }
                    else if (lbTilte.Text == "Danh Sách Món Ăn Đã Xóa")
                    {
                        btnPhucHoi.Enabled = true;
                        txtMa.Text = rows.Cells[0].Value.ToString();
                        txtTen.Text = rows.Cells[1].Value.ToString();
                    }
                    else if (lbTilte.Text == "Danh Sách Danh Mục Đã Xóa")
                    {
                        btnPhucHoi.Enabled = true;
                        txtMa.Text = rows.Cells[0].Value.ToString();
                        txtTen.Text = rows.Cells[1].Value.ToString();
                    }
                    else
                    {
                        btnPhucHoi.Enabled = true;
                        txtMa.Text = rows.Cells[0].Value.ToString();
                        txtTen.Text = rows.Cells[1].Value.ToString();
                        txtEmail.Text= rows.Cells[2].Value.ToString();
                    }
                    
                }
            }
        }
    }
}
