using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLNH;
using DTO_QLNH;

namespace GUI_QLNH.FORMS
{
    public partial class frmOrderMonAn : Form
    {
        public frmOrderMonAn()
        {
            InitializeComponent();
            HienButtonBan();
            pnlDatMon.Enabled = false;
        }
        
        BUS_DanhMuc busDanhMucMonAn = new BUS_DanhMuc();
        BUS_Ban busban = new BUS_Ban();
        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        BUS_HoaDonChiTiet busHoaDonCT = new BUS_HoaDonChiTiet();
        string tenDm;
        BUS_MonAn busMonAn = new BUS_MonAn();

        private void frmOrderMonAn_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (lblBanHienTai.Text == cbBan.Text)// kiểm tra bàn muốn chuyển đến có phải bàn hiện tại
            {
                Utils.HienError("Đang ở bàn hiện tại. Vui lòng chọn bàn trống để chuyển");
            }
            else
            {
                if (Utils.XacNhan("Bạn muốn chuyển " + lblBanHienTai.Text + " sang " + cbBan.Text))//xác nhận chuyển bàn
                {
                    if (busHoaDon.ChuyenBan(maBanHienTai, cbBan.Text)) //bàn thứ 2 trống 
                    {
                        Utils.HienThongBao("Chuyển bàn thành công");
                        flpTable.Controls.Clear();
                        HienButtonBan();
                        //loadDtgvOrder();
                        load();
                    }
                    else // bàn thứ 2 có người 
                    {
                        MessageBox.Show("Bàn đã có người !!!");
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmThanhToan ftt = new frmThanhToan(); 
            if (ftt.ShowDialog() == DialogResult.Cancel)// mở form thanh toán và nếu form đóng
            {
                if (busban.TrangThaiBan(lblBanHienTai.Text)==false)// cập nhật lại trạng thái bàn khi thanh toán
                { 
                    flpTable.Controls.Clear();
                    HienButtonBan();
                    loadDtgvOrder();
                }
            }
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (isCoNguoi) // nếu bàn đã có người cập nhật lại hóa đơn khi thêm món
            {
                busHoaDonCT.CapNhatHoaDon(maBanHienTai, cbMonAn.Text, Convert.ToInt32(numSoLuong.Text),float.Parse(txtTongTien.Text));
                loadDtgvOrder();
            }
            else // thêm mới hoá đơn khi bàn không có người
            {
                DTO_HoaDon hd = new DTO_HoaDon(txtTongTien.Text, maBanHienTai, frmGiaoDien._Email, 0, 10);
                if (busHoaDon.ThemHoaDon(hd))
                {
                    busban.BanCoNguoi(maBanHienTai);
                    DTO_HoaDonChiTiet hdct = new DTO_HoaDonChiTiet(cbMonAn.Text, Convert.ToInt32(numSoLuong.Text));
                    busHoaDonCT.ThemHoaDonChiTiet(hdct);
                    loadDtgvOrder();
                    flpTable.Controls.Clear();
                    HienButtonBan();
                    
                }
            }
            isCoNguoi = true;
            btnChuyenBan.Enabled = true;
            btnGopBan.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        void load()
        {
            cbBan.DisplayMember = "TenBan";
            cbBan.ValueMember = "MaBan";
            cbBan.DataSource = busban.HienBan();// hiển thị combobox danh sách bàn

            cbDanhMucMonAn.DisplayMember = "TenDM";
            cbDanhMucMonAn.ValueMember = "MaDM";
            cbDanhMucMonAn.DataSource = busDanhMucMonAn.HienThiDanhMucMonAN(); // hiển thị combobox danh sách danh mục

            dtgvOrder.Columns.Clear();
            dtgvOrder.Columns.Add("tenMon", "Tên món");
            dtgvOrder.Columns.Add("SoLuong", "Số lượng");
            dtgvOrder.Columns.Add("DonGia", "Đơn giá");
            dtgvOrder.Columns.Add("ThanhTien", "Thành tiền");
            txtTongTien.Text = "0";
            txtThanhTien.Text = "0";
            btnCapNhatMon.Enabled = false;
            btnXoaMon.Enabled = false;

            
        }
        void loadDtgvOrder()
        {
            // hiển thị hóa đơn chi tiết của bàn được chọn
            dtgvOrder.Columns.Clear();
            dtgvOrder.DataSource=busHoaDonCT.BillInfo(maBanHienTai);
            double tongtien = 0;
            for (int i = 0; i < dtgvOrder.Rows.Count - 1; i++)
            {
                double tien = Convert.ToDouble(dtgvOrder.Rows[i].Cells["Thành tiền"].Value);
                tongtien += tien;
            }
            txtThanhTien.Text = tongtien.ToString("#,#", CultureInfo.InvariantCulture) ;
            txtTongTien.Text = (tongtien + tongtien * 0.1).ToString("#,#", CultureInfo.InvariantCulture);
        }
        private void cbDanhMucMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            // hiển thị combobox danh sách món ăn. thay đổi khi danh mục thay đổi
            tenDm = cbDanhMucMonAn.Text;
            busMonAn.TenMon(tenDm);
            cbMonAn.DisplayMember = "TenMon";
            cbMonAn.DataSource = busMonAn.TenMon(tenDm);
        }

        void HienButtonBan()
        {
            // hiển thị bàn ra flowlayerpanel
            List<DTO_Ban> LTB = busban.HienButtonsBan();//lấy danh sách bàn

            foreach (DTO_Ban banTuDB in LTB)
            {
                Button btn = new Button()//tạo các button
                {
                    Width = busban.tablewidth,
                    Height = busban.tableheight
                };
                btn.Text = banTuDB.TenBan + Environment.NewLine + (banTuDB.TrangThai == 0 ? "Trống" : "Có Người");// xét trạng thái

                btn.Click += btnBan_Click;

                btn.Tag = banTuDB;//lưu thông tin của bàn đang chọn

                if (banTuDB.TrangThai == 1)
                {
                    btn.BackColor = Color.GreenYellow;// có người sẽ hiển thị màu vàng
                }

                flpTable.Controls.Add(btn);// add các button vào flowlayerpanel
            }
        }

        public static int maBanHienTai;
        public static bool isCoNguoi;

        private void btnBan_Click(object sender, EventArgs e)
        {
            // sự kiện xảy ra khi click vào button các bàn
            btnXoaMon.Enabled = false;
            btnCapNhatMon.Enabled = false;
            btnThemMon.Enabled = true;
            pnlDatMon.Enabled = true;
            
            var buttonHienTai = ((sender as Button).Tag as DTO_Ban);

            maBanHienTai = buttonHienTai.Maban;//lấy mã bàn đang chọn

            isCoNguoi= Convert.ToBoolean(buttonHienTai.TrangThai);

            lblBanHienTai.Text = buttonHienTai.TenBan;// lấy trạng thái bàn đang chọn

            if (isCoNguoi == true)
            {// nếu bàn có hóa đơn sẽ cho phép dùng các button sau
                btnChuyenBan.Enabled = true;
                btnGopBan.Enabled = true;
                btnThanhToan.Enabled = true;
                loadDtgvOrder();
                btnBoQua.Enabled = false;
            }  
            else
            {// bàn không có người sẽ khóa các button sau
                btnBoQua.Enabled = false;
                btnThanhToan.Enabled = false;
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
                load();
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (lblBanHienTai.Text == cbBan.Text)
            {//kiểm tra xem có phải gộp đến bàn hiện tại không
                Utils.HienError("Đang ở bàn hiện tại. Vui lòng chọn bàn để gộp");
            }
            else
            {
                if (Utils.XacNhan("Bạn muốn gộp " + lblBanHienTai.Text + " sang " + cbBan.Text))
                {
                    if (busban.TrangThaiBan(cbBan.Text))//nếu bàn 2 có hóa đơn sẽ cho gộp bàn
                    {
                        for (int i = 1; i <= dtgvOrder.Rows.Count; i++)
                        {
                            busHoaDon.GopBan(maBanHienTai, cbBan.Text);
                        }
                        Utils.HienThongBao("Gộp bàn thành công");
                        flpTable.Controls.Clear();
                        HienButtonBan();
                        load();
                        loadDtgvOrder();
                    }
                    else
                    {// bàn không có hóa đơn sẽ không cho gộp
                        Utils.HienError(cbBan.Text + " không có hóa đơn để gộp. Chỉ có thể chuyển bàn");
                    }
                }
            }   
        }
        private void dtgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow rows = this.dtgvOrder.Rows[e.RowIndex];
                if (rows.Cells[0].Value == null)//kiểm tra row click có dữ liệu hay không
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                }
                else
                {// không cho phép thêm món và thanh toán
                    btnBoQua.Enabled = true;
                    btnThemMon.Enabled = false;
                    btnCapNhatMon.Enabled = true;
                    btnXoaMon.Enabled = true;
                    // hiển thị các dữ liệu lên các vị trí tương ứng
                    cbMonAn.Text = rows.Cells[0].Value.ToString();
                    numSoLuong.Text = rows.Cells[1].Value.ToString();
                    busMonAn.TenDM(cbMonAn.Text);
                    cbDanhMucMonAn.DisplayMember = "TenDM";
                    cbDanhMucMonAn.DataSource = busMonAn.TenDM(cbMonAn.Text);
                }
            }
        }

        private void cbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {// quay lại trạng thái cho phép thêm món 
            btnBoQua.Enabled = false;
            btnThemMon.Enabled = true;
            btnXoaMon.Enabled = false;
            btnCapNhatMon.Enabled = false;
            cbDanhMucMonAn.DisplayMember = "TenDM";
            cbDanhMucMonAn.ValueMember = "MaDM";
            cbDanhMucMonAn.DataSource = busDanhMucMonAn.HienThiDanhMucMonAN();
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (Utils.XacNhan("Bạn muốn xóa món ăn này khỏi hóa đơn?"))
            {//xóa món ăn khỏi hóa đơn
                if (busHoaDon.XoaMonAn(cbMonAn.Text, maBanHienTai))
                {
                    if (dtgvOrder.Rows.Count == 2)
                    {
                        Utils.HienThongBao("Xóa món ăn thành công");
                        flpTable.Controls.Clear();
                        HienButtonBan();
                        load();
                    }
                    else
                    {
                        Utils.HienThongBao("Xóa món ăn thành công");
                        loadDtgvOrder();
                    }
                }

            }
        }

        private void btnCapNhatMon_Click(object sender, EventArgs e)
        {
            if(Utils.XacNhan("Bạn muốn sửa số lượng món ăn?"))
            {// chỉnh sửa số lượng món ăn
                if(busHoaDon.CapNhatMonAn(cbMonAn.Text,maBanHienTai,Convert.ToInt32(numSoLuong.Value)))
                {
                    Utils.HienThongBao("Cập nhật thành công");
                    loadDtgvOrder();
                }    
            }    
        }
    }
}
