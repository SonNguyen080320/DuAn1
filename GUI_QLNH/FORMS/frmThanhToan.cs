using BUS_QLNH;
using DTO_QLNH;
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
namespace GUI_QLNH.FORMS
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
            load();
        }
        BUS_HoaDonChiTiet bushoadonchitiet = new BUS_HoaDonChiTiet();
        BUS_HoaDon bushoadon = new BUS_HoaDon();
        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void load()
        {// hiển thị thông tin của hóa đơn muốn thanh toán
            var tb = bushoadonchitiet.TenBan(frmOrderMonAn.maBanHienTai);
            lbTenBan.Text = tb;
            dtgvHoaDon.DataSource = bushoadonchitiet.BillInfo(frmOrderMonAn.maBanHienTai);
            double tongtien = 0;
            for (int i = 0; i < dtgvHoaDon.Rows.Count - 1; i++)
            {
                double tien = Convert.ToDouble(dtgvHoaDon.Rows[i].Cells["Thành tiền"].Value);
                tongtien += tien;
            }
            txtThanhTien.Text = tongtien.ToString("#,#", CultureInfo.InvariantCulture);
            txtTongTien.Text = (tongtien + tongtien * 0.1).ToString("#,#", CultureInfo.InvariantCulture);
            this.dtgvHoaDon.Columns["Đơn giá"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgvHoaDon.Columns["Thành tiền"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgvHoaDon.Columns["Số lượng"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {// thanh toán hóa đơn
            if (Utils.XacNhan("Bạn muốn thanh toán hóa đơn " + lbTenBan.Text + " ?"))
            {
                if (bushoadon.ThanhToan(frmOrderMonAn.maBanHienTai, float.Parse(txtTongTien.Text), float.Parse(txtThanhTien.Text)))
                {
                    Utils.HienThongBao("Thanh toán thành công");
                    frmOrderMonAn.isCoNguoi = false;
                    this.Close();
                }
            }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {

        }
    }
}
