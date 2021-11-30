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
            goiyten();
        }

        private void frmQuanLyDanhMucMonAn_Load(object sender, EventArgs e)
        {
            loadgridview_DanhMucMonAn();
            ResetValues();
        }
        BUS_DanhMuc busdanhmucmonan = new BUS_DanhMuc();
        private void loadgridview_DanhMucMonAn()
        {// hiển thị danh sách danh mục ra datagridview
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
        {//hiển thị thông tin ra vị trí tương ứng khi click
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
            if (txtTenDanhMuc.Text.Trim().Length == 0)//kiểm tra trống
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
                    if (busdanhmucmonan.ThemDanhMucMonAn(dm))//thêm danh mục vào database
                    {
                        MessageBox.Show("Thêm thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();

                    }
                    else//tên dnah mục đã tồn tại sẽ không cho thêm
                    {
                        Utils.HienWarning("Tên danh mục đã tồn tại. Vui lòng nhập tên mới");
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
            int madanhmuc = Convert.ToInt32(txtMaDanhMuc.Text);//lấy mã danh mục
            if (txtMaDanhMuc.Text.Trim().Length == 0)//kiểm tra trống
            {
                MessageBox.Show("Bạn cần chọn danh mục cần xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busdanhmucmonan.XoaDanhMuc(madanhmuc))//xóa danh mục 
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();
                    }
                    else
                    {//danh mục có món ăn trong hóa đơn chưa thanh toán không cho xóa
                        Utils.HienWarning("Danh mục đang có món ăn trong hóa đơn chưa thanh toán. không thể xóa");
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

            if (txtTenDanhMuc.Text.Trim().Length == 0)//kiểm tra trống
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
                    if (busdanhmucmonan.SuaDanhMuc(dm))//cập nhật danh mục dựa theo mã danh mục
                    {
                        MessageBox.Show("Update thành công");
                        ResetValues();
                        loadgridview_DanhMucMonAn();
                    }
                    else
                    {//tên danh mục đã tồn tại không cho cập nhật
                        Utils.HienWarning("Tên danh mục đã tồn tại. Vui lòng nhập tên mới");
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
            if (txttimkiem.Text == "")//kiểm tra trống
            {
                MessageBox.Show("vui lòng nhập tên Danh mục cần tìm");
            }
            else
            {
                string tendanhmuc = txttimkiem.Text;
                DataTable ds = busdanhmucmonan.TimDanhMuc(tendanhmuc);
                if (ds.Rows.Count > 0)
                {//hiển thị danh mục tương ứng ra datagridview
                    dtgvDanhMuc.DataSource = ds;
                    dtgvDanhMuc.Columns[0].HeaderText = "MÃ DANH MỤC";
                    dtgvDanhMuc.Columns[1].HeaderText = "TÊN DANH MỤC";
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Danh mục món Ăn Này  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttimkiem.Focus();
                }
                txttimkiem.BackColor = Color.LightGray;
                ResetValues();
            }
        }
        void goiyten()
        {//gợi ý tên danh mục khi nhập tên tìm kiếm
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txttimkiem.AutoCompleteMode = AutoCompleteMode.Append;
            txttimkiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txttimkiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            DataTable dtb = busdanhmucmonan.TenDMGoiY();
            string tenban;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                tenban = dtb.Rows[i]["TenDM"].ToString();
                auto1.Add(tenban);
            }
            txttimkiem.AutoCompleteCustomSource = auto1;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_DanhMucMonAn();
            txttimkiem.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {// button phục hồi
            frmPhucHoi f1 = new frmPhucHoi("Danh Sách Danh Mục Đã Xóa");
            if(f1.ShowDialog()==DialogResult.Cancel)
            {
                ResetValues();
                loadgridview_DanhMucMonAn();
                txttimkiem.Text = "";
            }    
        }
    }
}
