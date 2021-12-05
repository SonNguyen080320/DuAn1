using System;
using System.Collections.Generic;
using System.ComponentModel;
using BUS_QLNH;
using DTO_QLNH;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GUI_QLNH.FORMS
{
    public partial class frmQuanLyMonAn : Form
    {
        public frmQuanLyMonAn()
        {
            InitializeComponent();
            goiyten();
        }
        BUS_MonAn busMonAn = new BUS_MonAn();
        BUS_DanhMuc busDanhMucMonAn = new BUS_DanhMuc();
        private void frmQuanLyMonAn_Load(object sender, EventArgs e)
        {
            load();
            ResetValues();
            loadgridview_MonAn();
        }
        string checkurlimage;
        string filename;
        string filesavepath;
        string fileaddress;
        string hinh;
        string txtHinh;
        string saveDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = null;
            txtTenMon.Text = null;
            numGia.Text = "0";
            cbDonViTinh.Text = "";
            txtTenMon.Enabled = true;
            rdoConPhucVu.Enabled = true;
            rdoHet.Enabled = true;
            rdoConPhucVu.Checked = true;
            cbDonViTinh.Enabled = true;
            numGia.Enabled = true;
            txtHinh = null;
            picMonAn.Image = null;
            cbTenDM.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            rdoConPhucVu.Checked = true;
            btnMoHinh.Enabled = true;
            cbTenDM.Focus();
        }
        void load()
        {// hiển thị combobox danh sách danh mục món ăn
            busDanhMucMonAn.HienThiDanhMucMonAN();
            cbTenDM.DisplayMember = "TenDM";
            cbTenDM.ValueMember = "MaDM";
            cbTenDM.DataSource = busDanhMucMonAn.HienThiDanhMucMonAN();
        }
        private void loadgridview_MonAn()
        {// load dữ liệu danh sách món ăn lên datagridview
            txtMaMon.Enabled = false;
            dtgvMonAn.DataSource = busMonAn.HienThiMonAN();
            dtgvMonAn.Columns[0].HeaderText = "MÃ  MÓN";
            dtgvMonAn.Columns[1].HeaderText = "TÊN MÓN";
            dtgvMonAn.Columns[2].HeaderText = "ĐƠN VỊ TÍNH";
            dtgvMonAn.Columns[3].HeaderText = "ĐƠN GIÁ";
            dtgvMonAn.Columns[4].HeaderText = "HÌNH ẢNH";
            dtgvMonAn.Columns[5].HeaderText = "TÌNH TRẠNG";
            dtgvMonAn.Columns[6].HeaderText = "TÊN DANH MỤC";
            this.dtgvMonAn.Columns["dg"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;//đơn giá định dạng nằm bên phải
        }
        private void ResetValues()
        {
            txtMaMon.Text = null;
            txtTenMon.Text = null;
            txtMaMon.Enabled = false;
            txtTenMon.Enabled = false;
            cbDonViTinh.Enabled = false;
            numGia.Enabled = false;
            cbTenDM.Enabled = false;
            rdoConPhucVu.Enabled = false;
            rdoHet.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnMoHinh.Enabled = false;
            picMonAn.Image = null;
        }

        private void dtgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {//hiển thị các thông tin ra các vị trí tương ứng khi click 
                DataGridViewRow rows = this.dtgvMonAn.Rows[e.RowIndex];
                if (rows.Cells[1].Value.ToString().Count() == 0)
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                    ResetValues();
                }
                else
                {
                    txtTenMon.Enabled = true;
                    rdoConPhucVu.Enabled = true;
                    rdoHet.Enabled = true;
                    cbDonViTinh.Enabled = true;
                    numGia.Enabled = true;
                    cbTenDM.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    btnMoHinh.Enabled = true;

                    txtMaMon.Text = dtgvMonAn.CurrentRow.Cells[0].Value.ToString();
                    txtTenMon.Text = dtgvMonAn.CurrentRow.Cells[1].Value.ToString();
                    cbDonViTinh.Text = dtgvMonAn.CurrentRow.Cells[2].Value.ToString();
                    numGia.Text = dtgvMonAn.CurrentRow.Cells[3].Value.ToString();
                    hinh = dtgvMonAn.CurrentRow.Cells[4].Value.ToString();
                    txtHinh = hinh;
                    checkurlimage = hinh;
                    picMonAn.Image = Image.FromFile(saveDirectory + dtgvMonAn.CurrentRow.Cells[4].Value.ToString());
                    if (dtgvMonAn.CurrentRow.Cells[5].Value.ToString() == "True")
                    {
                        rdoConPhucVu.Checked = true;
                    }
                    else
                    {
                        rdoHet.Checked = true;
                    }
                    cbTenDM.Text = dtgvMonAn.CurrentRow.Cells[6].Value.ToString();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int tinhtrang;
            if (rdoConPhucVu.Checked)
            {
                tinhtrang = 1;
            }// lấy tình trạng món ăn
            else
            {
                tinhtrang = 0;
            }
            if (cbTenDM.Text.Trim().Length == 0)//kiểm tra trống
            {
                MessageBox.Show("Bạn phải nhập tên danh mục !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;

            }

            if (txtTenMon.Text.Trim().Length == 0)
            {

                MessageBox.Show("Bạn phải nhập tên món ăn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (cbDonViTinh.Text.Trim().Length == 0)
            {


                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbDonViTinh.Focus();
                return;
            }
            else if (numGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numGia.Focus();
                return;
            }
            else if (rdoConPhucVu.Checked == false && rdoHet.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái Món Ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (txtHinh == null)// kiểm tra troongs hình ảnh
            {
                MessageBox.Show("Bạn phải nhập hình ảnh hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else
            {
                string tenMon = txtTenMon.Text;
                string danhmuc = cbTenDM.Text;
                string donvitinh = cbDonViTinh.Text;
                float donGiaBan = float.Parse(numGia.Text);
                //string hinhAnh = Convert.ToString(piturehinh.ImageLocation);
                DTO_MonAn monan = new DTO_MonAn(tenMon, donvitinh, donGiaBan, "\\Images\\" +filename, tinhtrang, danhmuc);
                if (MessageBox.Show("Bạn muốn thêm món ăn này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busMonAn.ThemMonAn(monan))// thêm món ăn
                    {
                            Utils.HienThongBao("Thêm món thành công");
                            File.Copy(fileaddress, filesavepath, true);
                            ResetValues();
                            loadgridview_MonAn();
                    }
                    else
                    {
                        Utils.HienWarning("Thêm thất bại");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int tinhtrang;
            if (rdoConPhucVu.Checked)
            {
                tinhtrang = 1;
            }
            else
            {
                tinhtrang = 0;
            }
            if (cbTenDM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần chọn danh mục món ăn", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên Món Ăn", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (cbDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập đơn vị tính", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (numGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập đơn giá bán ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (rdoConPhucVu.Checked == false && rdoHet.Checked == false)
            {
                MessageBox.Show("Bạn cần chọn trạng thái món ăn", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }
            else if (txtHinh == null)
            {

                MessageBox.Show("Bạn phải nhập hình ảnh hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMon.Focus();
                return;
            }

            else
            {
                int mamon = int.Parse(txtMaMon.Text);
                string tenmonan = txtTenMon.Text;
                string danhmuc = cbTenDM.Text;
                string donvitinh = cbDonViTinh.Text;
                float donGiaBan = float.Parse(numGia.Text);
                string hinhAnh = txtHinh;
                string saveDirectory = Path.GetDirectoryName(Application.ExecutablePath); ;
                DTO_MonAn monan = new DTO_MonAn(mamon, tenmonan, donvitinh, donGiaBan, hinhAnh, tinhtrang, danhmuc);
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busMonAn.SuaMonAn(monan))
                    {
                        if (txtHinh != checkurlimage)
                        {
                            File.Copy(fileaddress, filesavepath, true);
                        }
                        MessageBox.Show("Update thành công");
                        ResetValues();
                        loadgridview_MonAn();
                    }
                    else
                    {
                        Utils.HienWarning("Cập nhật thất bại");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int mamon = Convert.ToInt32(txtMaMon.Text);
            if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busMonAn.XoaMonAn(mamon))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    loadgridview_MonAn();
                }
                else
                {// món ăn đang có trong hóa đơn chưa thanh toán khoogn cho xóa
                    Utils.HienWarning("Món ăn đang có trong hóa đơn chưa thanh toán. Không được xóa");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenmon = txtTimKiem.Text;
            DataTable ds = busMonAn.TimMonAn(tenmon);//load dữ liệu lên datatable khi tìm kiếm

            if (ds.Rows.Count > 0)
            {// load dữ liệu lên datagridview từ datatable ds
                dtgvMonAn.DataSource = ds;
                dtgvMonAn.Columns[0].HeaderText = "MÃ MÓN";
                dtgvMonAn.Columns[1].HeaderText = "TÊN  MÓN";
                dtgvMonAn.Columns[2].HeaderText = "ĐƠN VỊ TÍNH";
                dtgvMonAn.Columns[3].HeaderText = "ĐƠN GIÁ ";
                dtgvMonAn.Columns[4].HeaderText = "HÌNH ẢNH";
                dtgvMonAn.Columns[5].HeaderText = "TÌNH TRẠNG";
                dtgvMonAn.Columns[6].HeaderText = "TenDM";

            }
            else
            {
                MessageBox.Show("Không Tìm Thấy hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
            }
            txtTimKiem.BackColor = Color.LightGray;

            ResetValues();
        }

        private void btnMoHinh_Click(object sender, EventArgs e)
        {//chọn hình ảnh
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = " JPEG(*jpg)|*.jpg|Bitmap(*.bmp)|*.bmp|GIF(*.gif)|*.gif|All Files(*.*)|*.*";
            dlgOpen.FilterIndex = 1;//khi mở lên sẽ chọn đuôi file là jepg hoặc jpg
            dlgOpen.Title = "Chọn hình minh họa cho sản phẩm";//tiêu đề
            dlgOpen.RestoreDirectory = true;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileaddress = dlgOpen.FileName;
                filename = Path.GetFileName(dlgOpen.FileName);//tên file được chọn
                saveDirectory = Path.GetDirectoryName(Application.ExecutablePath); ;//vị trí của phần mềm
                filesavepath = saveDirectory + "\\Images\\" + filename;// lưu dữ liệu vào thư mục images
                if (File.Exists(filesavepath))
                {// nếu hình được chọn đã có trong hệ thống sẽ không cho. muốn chọn hình đó thì cần đổi tên
                    Utils.HienWarning("Hình đã tồn tại. Vui lòng chọn hình mới");
                }
                else
                { 
                    txtHinh = "\\Images\\" + filename;
                    picMonAn.Image = Image.FromFile(fileaddress);// hiển thị hình ảnh ra picturebox
                }
            }
        }
        void goiyten()
        {// gợi ý tên món ăn khi nhập tìm kiếm
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Append;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            DataTable dtb = busMonAn.TenMonAnGoiY();
            string tenban;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                tenban = dtb.Rows[i]["TenMon"].ToString();
                auto1.Add(tenban);
            }
            txtTimKiem.AutoCompleteCustomSource = auto1;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_MonAn();
            txtTimKiem.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {// button phục hồi
            frmPhucHoi f1 = new frmPhucHoi("Danh Sách Món Ăn Đã Xóa");
            if(f1.ShowDialog()==DialogResult.Cancel)
            {
                ResetValues();
                loadgridview_MonAn();
                txtTimKiem.Text = "";
            }    
        }

        private void numGia_KeyPress(object sender, KeyPressEventArgs e)
        {// chỉ cho phép nhập từ 0 đến 9 và nút backspace
            if ((e.KeyChar < '0') || (e.KeyChar > '9')) e.Handled = true;
            if (e.KeyChar == 8) e.Handled = false;
        }
    }
}
