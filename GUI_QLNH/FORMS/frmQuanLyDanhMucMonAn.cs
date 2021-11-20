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
    public partial class frmQuanLyDanhMucMonAn : Form
    {
        public frmQuanLyDanhMucMonAn()
        {
            InitializeComponent();
        }

        private void frmQuanLyDanhMucMonAn_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            loadgridview_DanhMucMonAn();
            ResetValues();
        }
        BUS_DanhMuc busdanhmucmonan = new BUS_DanhMuc();
        private void loadgridview_DanhMucMonAn()
        {
            dtgvDanhMuc.DataSource = busdanhmucmonan.HienThiDanhMucMonAN();
            dtgvDanhMuc.Columns[0].HeaderText = "MÃ  DANH MUC";
            dtgvDanhMuc.Columns[1].HeaderText = "TÊN DANH MỤC";
        }
        private void ResetValues()
        {
            txtMaDanhMuc.Text = null;
            txtTenDanhMuc.Text = null;
            txtMaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dtgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhMuc.Rows.Count > 1)
            {
                txtTenDanhMuc.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                txtMaDanhMuc.Text = dtgvDanhMuc.CurrentRow.Cells[0].Value.ToString();
                txtTenDanhMuc.Text = dtgvDanhMuc.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Danh mục nhé !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDanhMuc.Focus();
                return;

            }
            else
            {
                DTO_DanhMuc dm = new DTO_DanhMuc(txtTenDanhMuc.Text);
                if (MessageBox.Show("Bạn muốn thêm danh mục này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busdanhmucmonan.ThemDanhMucMonAn(dm))
                    {
                        MessageBox.Show("Thêm thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();

                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = null;
            txtMaDanhMuc.Text = null;
            txtTenDanhMuc.Text = null;
            txtTenDanhMuc.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDanhMuc.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int madanhmuc = Convert.ToInt32(txtMaDanhMuc.Text);
            if (txtMaDanhMuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần chọn danh mục cần xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busdanhmucmonan.XoaDanhMuc(madanhmuc))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtTenDanhMuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên Danh mục !", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDanhMuc.Focus();
                return;
            }

            else
            {

                DTO_DanhMuc dm = new DTO_DanhMuc(Convert.ToInt32(txtMaDanhMuc.Text), txtTenDanhMuc.Text);
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busdanhmucmonan.SuaDanhMuc(dm))
                    {
                        MessageBox.Show("Update thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();
                    }
                    else
                    {
                        MessageBox.Show("Update không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("vui lòng nhập tên Danh mục cần tìm");
            }
            else
            {
                string tendanhmuc = txttimkiem.Text;
                DataTable ds = busdanhmucmonan.TimDanhMuc(tendanhmuc);
                if (ds.Rows.Count > 0)
                {
                    dtgvDanhMuc.DataSource = ds;
                    dtgvDanhMuc.Columns[0].HeaderText = "MÃ DANH MỤC";
                    dtgvDanhMuc.Columns[1].HeaderText = "TÊN DANH MỤC";
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Danh mục món Ăn Này  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txttimkiem.BackColor = Color.LightGray;
                ResetValues();
            }
        }
    }
}
