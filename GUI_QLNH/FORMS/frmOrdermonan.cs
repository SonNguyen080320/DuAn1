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
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            load();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (Utils.XacNhan("Bạn muốn chuyển "+ lblBanHienTai.Text +" sang " + cbBan.Text))
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(Utils.XacNhan("Bạn muốn thanh toán hóa đơn?"))
            {
                if (busHoaDon.ThanhToan(maBanHienTai,txtTongTien.Text,txtThanhTien.Text))
                {
                    Utils.HienThongBao("Thanh toán thành công");
                    load();
                    flpTable.Controls.Clear();
                    HienButtonBan();
                }
            }    
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (isCoNguoi) // cập nhật hoá đơn
            {
                busHoaDonCT.CapNhatHoaDon(maBanHienTai, cbMonAn.Text, Convert.ToInt32(numSoLuong.Text), txtTongTien.Text);
                loadDtgvOrder();
            }
            else // thêm mới hoá đơn
            {
                isCoNguoi = true;
                DTO_HoaDon hd = new DTO_HoaDon("0", maBanHienTai, frmGiaoDien._Email, 0, 10);
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
            txtThanhTien.Text = tongtien.ToString();
            txtTongTien.Text = (tongtien + tongtien * 0.1).ToString();
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
            pnlDatMon.Enabled = true;

            var buttonHienTai = ((sender as Button).Tag as DTO_Ban);

            maBanHienTai = buttonHienTai.Maban;

            isCoNguoi= Convert.ToBoolean(buttonHienTai.TrangThai);

            lblBanHienTai.Text = buttonHienTai.TenBan;

            if (isCoNguoi == true)
                loadDtgvOrder();
            else
                load();
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            //busHoaDon.GopBan(IDBan, cbBan.Text);
            //flpTable.Controls.Clear();
            //HienButtonBan();
            //load();
            //loadgridview();
        }
    }
}
