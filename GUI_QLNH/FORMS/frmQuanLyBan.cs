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
    public partial class frmQuanLyBan : Form
    {
        public frmQuanLyBan()
        {
            InitializeComponent();
            goiytenban();
        }
        BUS_Ban busBan = new BUS_Ban();
        private void frmQuanLyBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_Ban();
        }
        private void loadgridview_Ban()
        {// hiển thị danh sách bàn ra datagridview
            txtMaBan.Enabled = false;
            dtgvQLBanAn.DataSource = busBan.HienBan();
            dtgvQLBanAn.Columns[0].HeaderText = "MÃ  BÀN";
            dtgvQLBanAn.Columns[1].HeaderText = "TÊN BÀN";
            dtgvQLBanAn.Columns[2].HeaderText = "TRẠNG THÁI";

        }
        private void ResetValues()
        {
            txtMaBan.Text = null;
            txtTenBan.Text = null;
            txtMaBan.Enabled = false;
            txtTenBan.Enabled = false;
            rdoDaDat.Enabled = false;
            rdoTrong.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {// khi bấm button thêm các dữ liệu sẽ được xóa trắng 
            txtMaBan.Text = null;
            txtTenBan.Text = null;
            txtTenBan.Enabled = true;
            
            rdoDaDat.Enabled = false;
            rdoTrong.Enabled = false;
            rdoTrong.Checked = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenBan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int tinhtrang;
            if (rdoDaDat.Checked)
            {
                tinhtrang = 1;
            }// kiểm tra tình trạng
            else
            {
                tinhtrang = 0;
            }
            if (txtTenBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên bàn nhé !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenBan.Focus();
                return;

            }//kiểm tra có trống không

            if (rdoDaDat.Checked == false && rdoTrong.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn tình trạng của bàn nha !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenBan.Focus();
                return;
            }

            else
            {
                DTO_Ban b = new DTO_Ban(txtTenBan.Text, tinhtrang);//truyền dữ liệu cho DTO
                if (MessageBox.Show("Bạn muốn thêm bàn này ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busBan.ThemBan(b))//kiểm tra thêm bàn thành công hay không
                    {
                        MessageBox.Show("Thêm bàn thành công");
                        ResetValues();
                        loadgridview_Ban();
                    }
                    else
                    {
                        Utils.HienWarning("Tên bàn đã tồn tại. Vui lòng nhập tên khác");// tên bàn trùng sẽ không cho thêm
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maban = Convert.ToInt32(txtMaBan.Text);
            if (txtMaBan.Text.Trim().Length == 0)//kiểm tra đã chọn bàn cần xóa
            {
                MessageBox.Show("Bạn cần chọn bàn cần xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busBan.XoaBan(maban))//xóa bàn
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        ResetValues();
                        loadgridview_Ban();
                    }
                    else//bàn có người sẽ k cho xóa
                    {
                        Utils.HienWarning("Bàn đang có người. Không được xóa");
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
            if (txtTenBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên Bàn !", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenBan.Focus();
                return;
            }// kiểm tra trống 
            else
            {
                int tinhtrang;
                if (rdoDaDat.Checked)
                {
                    tinhtrang = 1;

                }// lấy tình trạng
                else
                {
                    tinhtrang = 0;
                }
                DTO_Ban ban = new DTO_Ban(Convert.ToInt32(txtMaBan.Text), txtTenBan.Text, tinhtrang);// truyền dữ liệu cho DTO
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busBan.SuaBan(ban))//cập nhật thông tin bàn
                    {
                        MessageBox.Show("Update thành công");
                        loadgridview_Ban();
                    }
                    else//tên bàn đã tồn tại sẽ không cho cập nhật
                    {
                        Utils.HienWarning("Tên bàn đã tồn tại. Vui lòng nhập tên mới");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")// kiểm tra trống
            {
                MessageBox.Show("vui lòng nhập tên bàn cần tìm");
            }
            else
            {
                string tenbantim = txtTimKiem.Text;
                DataTable ds = busBan.TimBan(tenbantim);//tìm kiếm bàn
                if (ds.Rows.Count > 0)
                {
                    dtgvQLBanAn.DataSource = ds;//hiển thị danh sách bàn theo tên cần tìm
                    dtgvQLBanAn.Columns[0].HeaderText = "ID";
                    dtgvQLBanAn.Columns[1].HeaderText = "TÊN BÀN";
                    dtgvQLBanAn.Columns[2].HeaderText = "TRẠNG THÁI";

                }
                else
                {//không tên bàn trùng
                    MessageBox.Show("Không Tìm Thấy Bàn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimKiem.Focus();
                }
                txtTimKiem.BackColor = Color.LightGray;
                ResetValues();
            }
        }

        private void dtgvQLBanAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {//hiển thị thông tin lên các vị trí tương ứng khi click
                DataGridViewRow rows = this.dtgvQLBanAn.Rows[e.RowIndex];
                if (rows.Cells[1].Value.ToString().Count() == 0)//kiểm tra row đnag chọn có dữ liệu hay không
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                    ResetValues();
                }
                else
                {
                    txtTenBan.Enabled = true;
                    rdoDaDat.Enabled = false;
                    rdoTrong.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    txtMaBan.Text = rows.Cells[0].Value.ToString();
                    txtTenBan.Text = rows.Cells[1].Value.ToString();

                    if (rows.Cells[2].Value.ToString() == "True")
                    {
                        rdoDaDat.Checked = true;
                    }
                    else
                    {
                        rdoTrong.Checked = true;
                    }
                }
            }
        }
        void goiytenban()
        {//gợi ý tên bàn khi nhập tìm kiếm
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Append;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            DataTable dtb = busBan.TenBanGoiY();
            string tenban;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                tenban = dtb.Rows[i]["TenBan"].ToString();
                auto1.Add(tenban);
            }
            txtTimKiem.AutoCompleteCustomSource = auto1;
        }

        private void button1_Click(object sender, EventArgs e)
        {//button bỏ qua.
            ResetValues();
            loadgridview_Ban();
            txtTimKiem.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {// button phục hồi bàn
            frmPhucHoi f1 = new frmPhucHoi("Danh Sách Bàn Đã Xóa");
            if(f1.ShowDialog()==DialogResult.Cancel)
            {
                ResetValues();
                loadgridview_Ban();
            }    
        }
    }
}
