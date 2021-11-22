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
            if (lblBanHienTai.Text == cbBan.Text)
            {
                Utils.HienError("Đang ở bàn hiện tại. Vui lòng chọn bàn trống để chuyển");
            }
            else
            {
                if (Utils.XacNhan("Bạn muốn chuyển " + lblBanHienTai.Text + " sang " + cbBan.Text))
                {
                    if (busHoaDon.ChuyenBan(maBanHienTai, cbBan.Text))
                    {
                        Utils.HienThongBao("Chuyển bàn thành công");
                        flpTable.Controls.Clear();
                        HienButtonBan();
                        //loadDtgvOrder();
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Bàn đã có người !!!");
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(Utils.XacNhan("Bạn muốn thanh toán hóa đơn?"))
            {
                if (busHoaDon.ThanhToan(maBanHienTai,float.Parse(txtTongTien.Text),float.Parse(txtThanhTien.Text)))
                {
                    Utils.HienThongBao("Thanh toán thành công");
                    load();
                    flpTable.Controls.Clear();
                    HienButtonBan();
                    isCoNguoi = false;
                }
            }    
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (isCoNguoi) // cập nhật hoá đơn
            {
                busHoaDonCT.CapNhatHoaDon(maBanHienTai, cbMonAn.Text, Convert.ToInt32(numSoLuong.Text),float.Parse(txtTongTien.Text));
                loadDtgvOrder();
            }
            else // thêm mới hoá đơn
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
        }

        void load()
        {
            cbBan.DisplayMember = "TenBan";
            cbBan.ValueMember = "MaBan";
            cbBan.DataSource = busban.HienBan();

            cbDanhMucMonAn.DisplayMember = "TenDM";
            cbDanhMucMonAn.ValueMember = "MaDM";
            cbDanhMucMonAn.DataSource = busDanhMucMonAn.HienThiDanhMucMonAN();

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
            tenDm = cbDanhMucMonAn.Text;
            busMonAn.TenMon(tenDm);
            cbMonAn.DisplayMember = "TenMon";
            cbMonAn.DataSource = busMonAn.TenMon(tenDm);
        }

        void HienButtonBan()
        {
            List<DTO_Ban> LTB = busban.HienButtonsBan();

            foreach (DTO_Ban banTuDB in LTB)
            {
                Button btn = new Button()
                {
                    Width = busban.tablewidth,
                    Height = busban.tableheight
                };
                btn.Text = banTuDB.TenBan + Environment.NewLine + (banTuDB.TrangThai == 0 ? "Trống" : "Có Người");

                btn.Click += btnBan_Click;

                btn.Tag = banTuDB;

                if (banTuDB.TrangThai == 1)
                {
                    btn.BackColor = Color.GreenYellow;
                }

                flpTable.Controls.Add(btn);
            }
        }

        int maBanHienTai;
        bool isCoNguoi;

        private void btnBan_Click(object sender, EventArgs e)
        {
            
            btnXoaMon.Enabled = false;
            btnCapNhatMon.Enabled = false;
            btnThemMon.Enabled = true;
            pnlDatMon.Enabled = true;
            
            var buttonHienTai = ((sender as Button).Tag as DTO_Ban);

            maBanHienTai = buttonHienTai.Maban;

            isCoNguoi= Convert.ToBoolean(buttonHienTai.TrangThai);

            lblBanHienTai.Text = buttonHienTai.TenBan;

            if (isCoNguoi == true)
            {
                btnChuyenBan.Enabled = true;
                btnGopBan.Enabled = true;
                btnThanhToan.Enabled = true;
                loadDtgvOrder();
            }  
            else
            {
                btnThanhToan.Enabled = false;
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
                load();
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (lblBanHienTai.Text == cbBan.Text)
            {
                Utils.HienError("Đang ở bàn hiện tại. Vui lòng chọn bàn để gộp");
            }
            else
            {
                if (Utils.XacNhan("Bạn muốn gộp " + lblBanHienTai.Text + " sang " + cbBan.Text))
                {
                    if (busban.TrangThaiBan(cbBan.Text) == false)
                    {
                        Utils.HienError(cbBan.Text + " không có hóa đơn để gộp. Chỉ có thể chuyển bàn");
                    }
                    else
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
                }
            }   
        }
        private void dtgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow rows = this.dtgvOrder.Rows[e.RowIndex];
                if (rows.Cells[0].Value == null)
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                }
                else
                {
                    btnThemMon.Enabled = false;
                    btnCapNhatMon.Enabled = true;
                    btnXoaMon.Enabled = true;
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
        {
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
            {
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
            {
                if(busHoaDon.CapNhatMonAn(cbMonAn.Text,maBanHienTai,Convert.ToInt32(numSoLuong.Value)))
                {
                    Utils.HienThongBao("Cập nhật thành công");
                    loadDtgvOrder();
                }    
            }    
        }
    }
}
