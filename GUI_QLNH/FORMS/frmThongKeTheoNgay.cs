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
    public partial class frmThongKeTheoNgay : Form
    {
        public frmThongKeTheoNgay()
        {
            InitializeComponent();
        }
        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        private void frmThongKeTheoNgay_Load(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = false;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = true;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeTongHop(dtpTuNgay.Value, dtpDenNgay.Value, "1",cbCa.Text);
            }
            else
            {
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeTongHop(dtpTuNgay.Value, dtpDenNgay.Value, txtMaNV.Text,cbCa.Text);
            }
            double tongtien = 0;
            for (int i = 0; i < dtgvThongKeTheoNgay.Rows.Count - 1; i++)
            {
                double tien = Convert.ToDouble(dtgvThongKeTheoNgay.Rows[i].Cells["Tổng tiền"].Value);
                tongtien += tien;
            }
            txtTongTien.Text = tongtien.ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";

        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = true;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeChiTiet(dtpTuNgay.Value, dtpDenNgay.Value, "1",cbCa.Text);
            }
            else
            {
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeChiTiet(dtpTuNgay.Value, dtpDenNgay.Value, txtMaNV.Text,cbCa.Text);
            }
            double tongtien = 0;
            for (int i = 0; i < dtgvThongKeTheoNgay.Rows.Count - 1; i++)
            {
                double tien = Convert.ToDouble(dtgvThongKeTheoNgay.Rows[i].Cells["Thành Tiền"].Value);
                tongtien += tien;
            }
            txtTongTien.Text = tongtien.ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (Utils.XacNhan("Bạn muốn xuất thống kê ra file excel?"))
            {
                Utils excel = new Utils();
                // Lấy về nguồn dữ liệu cần Export là 1 DataTable
                // gán trực tiếp vào DataGridView thì ép kiểu DataSource
                DataTable dt = (DataTable)dtgvThongKeTheoNgay.DataSource;
                excel.Export(dtgvThongKeTheoNgay, dt, "Thống kê", "Thống kê doanh thu");
            }
        }
    } 
}
    
    
