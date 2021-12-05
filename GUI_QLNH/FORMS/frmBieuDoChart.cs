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
using System.Windows.Forms.DataVisualization.Charting;
using BUS_QLNH;

namespace GUI_QLNH.FORMS
{
    public partial class frmBieuDoChart : Form
    {
        public frmBieuDoChart()
        {
            InitializeComponent();
        }
        private void chart1_MouseHover(object sender, EventArgs e)
        {

        }
        private void chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {

                DataPoint dataPoint = (DataPoint)e.HitTestResult.Object;
                if (e.HitTestResult.Series != null)
                {
                    e.Text = dataPoint.YValues[0].ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";
                }
                else
                {
                    e.Text = "";
                }
            }
        }

        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        BUS_HoaDonChiTiet busHoDonChiTiet = new BUS_HoaDonChiTiet();

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable ds = busHoaDon.ThongKeChiTiet(dttuNgay.Value, dtDenNgay.Value);
            //Giá trị cao nhất trục tung
            chart1.ChartAreas[0].AxisY.Maximum = 10000000;
            //Giá trị nhỏ nhất trục tung
            chart1.ChartAreas[0].AxisY.Minimum = 100;
            chart1.DataSource = ds;
            chart1.Series["Số tiền"].YValueMembers = "Tổng Tiền Có VAT";
            chart1.Series["Số tiền"].XValueMember = "Ngày Lập Hóa Đơn";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Biểu Đồ Doanh Thu Từ " + dttuNgay.Value.ToString("dd/MM/yyyy") + " Đến Ngày " + dtDenNgay.Value.ToString("dd/MM/yyyy");
        }

        private void frmBieuDoChart_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 50000000;
            //Giá trị nhỏ nhất trục tung
            chart1.ChartAreas[0].AxisY.Minimum = 1000000;
            HienNam();
            
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 15, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            dttuNgay.Value = DateTime.Now.AddDays(-7).Date;
            int year = DateTime.Now.Year;
            DataTable dt = busHoDonChiTiet.ThongKeTheoNam(year);
            chart1.DataSource = dt;
            chart1.Series["Số tiền"].YValueMembers = "Tổng Tiền";
            chart1.Series["Số tiền"].XValueMember = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Biểu Đồ Doanh Thu Năm " + year;
        }
        void HienNam()
        {
            cbNam.DataSource = busHoDonChiTiet.HienNam();
            cbNam.DisplayMember = "Năm";
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {//button hiển thị chart theo năm
            //Giá trị cao nhất trục tung
            chart1.ChartAreas[0].AxisY.Maximum = 50000000;
            //Giá trị nhỏ nhất trục tung
            chart1.ChartAreas[0].AxisY.Minimum = 1000000;
            DataTable dt = busHoDonChiTiet.ThongKeTheoNam(Convert.ToInt32(cbNam.Text));
            chart1.DataSource = dt;
            chart1.Series["Số tiền"].YValueMembers = "Tổng Tiền";
            chart1.Series["Số tiền"].XValueMember = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Biểu Đồ Doanh Thu Năm " + cbNam.Text;
        }
    }
}
