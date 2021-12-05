using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLNH;
using DTO_QLNH;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            dtpTuNgay.Value = DateTime.Now.AddDays(-7).Date;// ngày bắt đầu được trừ đi 7 ngày
            btnPDF.Enabled = false;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = true;
            btnPDF.Enabled = true;
            if (txtMaNV.Text.Trim().Length == 0)
            {// hiển thị thống kê chi tiết theo ngày và theo ca
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeTongHop(dtpTuNgay.Value, dtpDenNgay.Value, "1",cbCa.Text);
                this.dtgvThongKeTheoNgay.Columns["Thành Tiền"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dtgvThongKeTheoNgay.Columns["Thuế VAT"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dtgvThongKeTheoNgay.Columns["Tổng tiền"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {// hiển thị thống kê chi tiết theo ngày theo ca và theo mã nhân viên
                dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeTongHop(dtpTuNgay.Value, dtpDenNgay.Value, txtMaNV.Text,cbCa.Text);
                this.dtgvThongKeTheoNgay.Columns["Thành Tiền"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dtgvThongKeTheoNgay.Columns["Thuế VAT"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dtgvThongKeTheoNgay.Columns["Tổng tiền"].DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            double tongtien = 0;
            for (int i = 0; i < dtgvThongKeTheoNgay.Rows.Count; i++)
            {// hiển thị tổng doanh thu 
                double tien = Convert.ToDouble(dtgvThongKeTheoNgay.Rows[i].Cells["Tổng tiền"].Value);
                tongtien += tien;
            }
            txtTongTien.Text = tongtien.ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";

        }
        
        private void btnChiTiet_Click(object sender, EventArgs e)
        {// hiển thị thống kê tổng hợp theo ngày
            btnXuatExcel.Enabled = true;
            btnPDF.Enabled = true;
            dtgvThongKeTheoNgay.DataSource = busHoaDon.ThongKeChiTiet(dtpTuNgay.Value, dtpDenNgay.Value);
            this.dtgvThongKeTheoNgay.Columns["Tổng Số Hóa Đơn"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgvThongKeTheoNgay.Columns["Tổng Tiền Không VAT"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgvThongKeTheoNgay.Columns["Tổng VAT"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgvThongKeTheoNgay.Columns["Tổng Tiền Có VAT"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
            double tongtien = 0;
            DataTable ds= busHoaDon.ThongKeChiTiet(dtpTuNgay.Value, dtpDenNgay.Value);
            for (int i = 0; i < ds.Rows.Count; i++)
            {// hiển thị tổng doanh thu có thuế
                double tien = Convert.ToDouble(ds.Rows[i]["Tổng Tiền Có VAT"].ToString());
                tongtien += tien;
            }
            txtTongTien.Text =tongtien.ToString("#,#", CultureInfo.InvariantCulture) + " VNĐ";
            
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {// xuất file excel
            Utils excel = new Utils();
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // gán trực tiếp vào DataGridView thì ép kiểu DataSource
            DataTable dt = (DataTable)dtgvThongKeTheoNgay.DataSource;
            excel.Export(dtgvThongKeTheoNgay, dt, "Thống kê", "Thống kê doanh thu");
        }
        public void xuatpdf(DataGridView dgw, string filename) 
        {// xuát file PDF
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);// chọn font chữ
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);// tạo size và vị trí của file 
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);// tạo font chữ
            iTextSharp.text.Font text1 = new iTextSharp.text.Font(bf,25, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            text1.SetColor(0, 140, 94);// tạo màu chữ
            text2.SetColor(223 , 0  , 41);
            foreach (DataGridViewColumn column in dgw.Columns)
            {// chèn headertext cho bảng và backgroundcolor
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(24, 250, 240);
                pdftable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgw.Rows)
            {// chèn dữ liệu cho bảng
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;//tên file muốn lưu
            savefiledialoge.DefaultExt = ".pdf";// khi sale sẽ chọn đuôi pdf
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();

                    // chèn email người xuất
                    string NguoiXuat = frmGiaoDien._Email;
                    // chèn thời gian xuất file
                    DateTime time = DateTime.Now;
                    Chunk Time = new Chunk("Thời gian xuất file : "+time.ToString() + "                                        Nhân viên xuất: " + NguoiXuat , text2);
                    Phrase p3 = new Phrase(Time); 
                    Paragraph timePDF = new Paragraph();
                    timePDF.IndentationLeft = 30;
                    timePDF.Add(p3);

                    // chèn tên nhà hàng
                    string Name = "\n\nNhà hàng Flames\n\n";
                    Chunk cName = new Chunk(Name, text);
                    Phrase name = new Phrase(cName);
                    Paragraph pName = new Paragraph();
                    pName.IndentationLeft = 60;
                    pName.Add(name);

                    // chèn website
                    string sWebsite = "Website: http://www.Nhahangflames.com.vn\n\n";
                    Chunk website = new Chunk(sWebsite, text);
                    Phrase web = new Phrase(website);
                    Paragraph pAddresse = new Paragraph();
                    pAddresse.IndentationLeft = 60;
                    pAddresse.Add(web);

                    // chèn tên facebook
                    string fb = "Facebook: Facebook.com//Nhahangflames\n\n";
                    Chunk facebook = new Chunk(fb, text);
                    Phrase fbc = new Phrase(facebook);
                    Paragraph fbook = new Paragraph();
                    fbook.IndentationLeft = 60;
                    fbook.Add(fbc);

                    // chèn tiêu đề
                    string sText = "\nThống kê doanh thu\n\n\n";
                    Chunk beginning = new Chunk(sText,text1);
                    Phrase p1 = new Phrase(beginning);
                    Paragraph pCompanyName = new Paragraph();
                    pCompanyName.IndentationLeft = 180;
                    pCompanyName.Add(p1);

                    // toognr tiền
                    string TT = "\n Tổng Tiền : "+txtTongTien.Text;
                    Chunk begin = new Chunk(TT, text2);
                    Phrase p2 = new Phrase(begin);
                    Paragraph tongtien = new Paragraph();
                    tongtien.IndentationLeft = 420;
                    tongtien.Add(p2);

                    // chèn hình 
                    string saveDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    string ImagePath = saveDirectory + "\\Resources\\logo.png";
                    string logoFb = saveDirectory + "\\Resources\\fb.jpg";
                    string logoweb = saveDirectory + "\\Resources\\wb.png";
                    iTextSharp.text.Image pdfimageFb = iTextSharp.text.Image.GetInstance(logoFb);
                    pdfimageFb.ScaleToFit(50, 25);

                    iTextSharp.text.Image pdfImageWeb = iTextSharp.text.Image.GetInstance(logoweb);
                    pdfImageWeb.ScaleToFit(50, 25);
                    pdfimageFb.Alignment = iTextSharp.text.Image.HEADER;
                    pdfimageFb.SetAbsolutePosition(35f,695f);
                    pdfdoc.Add(pdfimageFb);


                    pdfImageWeb.Alignment = iTextSharp.text.Image.HEADER;
                    pdfImageWeb.SetAbsolutePosition(35f, 730f);
                    pdfdoc.Add(pdfImageWeb);

                    float PositionX = 35f;
                    float PositionY = 760f;
                    if (File.Exists(ImagePath))
                    {
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ImagePath);
                        pdfImage.ScaleToFit(50, 25);
                        pdfImage.Alignment = iTextSharp.text.Image.HEADER;
                        pdfImage.SetAbsolutePosition(PositionX, PositionY);
                        pdfdoc.Add(pdfImage);
                    }
                    pdfdoc.Add(timePDF);
                    pdfdoc.Add(pName);
                    pdfdoc.Add(pAddresse);
                    pdfdoc.Add(fbook);
                    pdfdoc.Add(pCompanyName);
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(tongtien);
                    pdfdoc.Close();
                    stream.Close();
                    MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                }
            }
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {//xuất file excel
            xuatpdf(dtgvThongKeTheoNgay, "hoadon");
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            frmBieuDoChart f1 = new frmBieuDoChart();
            if (f1.ShowDialog() == DialogResult.Cancel)
            {

            }
        }
    } 
}
    
    
