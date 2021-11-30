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
        DateTime _TuNgay, _DenNgay;
        string _MaNV, _Ca;
        public frmBieuDoChart(DateTime tungay, DateTime denngay,string manv,string ca) : this()
        {
            _TuNgay = tungay;
            _DenNgay = denngay;
            _MaNV = manv;
            _Ca = ca;
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
                    e.Text = dataPoint.XValue.ToString() + dataPoint.YValues[0].ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";
                }
                else
                {
                    e.Text = "";
                }    
            }
        }

        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        private void frmBieuDoChart_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            if (frmThongKeTheoNgay.TrangThai)
            {
                DataTable ds = busHoaDon.ThongKeTongHop(_TuNgay, _DenNgay, _MaNV, _Ca);
                //Giá trị cao nhất trục tung
                chart1.ChartAreas[0].AxisY.Maximum = 3000000;
                chart1.ChartAreas[0].AxisY.Minimum = 100;
                for(int i=0;i<ds.Rows.Count;i++)
                {
                    chart1.Series["Số tiền"].Points.Add(Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()));
                    //chart1.Series["Số tiền"].Points[i].Label = ds.Rows[i]["Tổng tiền"].ToString();
                    if (Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()) <=200000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Red;
                    }
                    else if(Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()) > 200000 &&
                        Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()) <= 1000000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Yellow;
                    }
                    else if (Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()) > 1000000 &&
                        Convert.ToDouble(ds.Rows[i]["Tổng tiền"].ToString()) <= 2000000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Green;
                    }
                    else
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Blue;
                    }    
                    chart1.Series["Số tiền"].Points[i].AxisLabel= ds.Rows[i]["Ngày Lập Hóa Đơn"].ToString();
                }    
            }    
            else
            {
                DataTable ds = busHoaDon.ThongKeChiTiet(_TuNgay, _DenNgay);
                //Giá trị cao nhất trục tung
                chart1.ChartAreas[0].AxisY.Maximum = 10000000;
                //Giá trị nhỏ nhất trục tung
                chart1.ChartAreas[0].AxisY.Minimum = 100;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    chart1.Series["Số tiền"].Points.Add(Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()));
                    //chart1.Series["Số tiền"].Points[i].Label = ds.Rows[i]["Tổng Tiền Có VAT"].ToString();
                    if (Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()) <= 200000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Red;
                    }
                    else if (Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()) > 200000 &&
                        Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()) <= 1000000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Yellow;
                    }
                    else if (Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()) > 100000 &&
                        Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString()) <= 2000000)
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Green;
                    }
                    else
                    {
                        chart1.Series["Số tiền"].Points[i].Color = Color.Blue;
                    }
                    chart1.Series["Số tiền"].Points[i].AxisLabel = ds.Rows[i]["Ngày Lập Hóa Đơn"].ToString();
                }
            }    
            
        }
    }
}
