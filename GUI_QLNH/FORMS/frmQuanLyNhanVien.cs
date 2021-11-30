using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DTO_QLNH;
using BUS_QLNH;
using System.Net.Mail;
using System.Net;

namespace GUI_QLNH.FORMS
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            goiyten();
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        DTO_NhanVien dtoNhanVien = new DTO_NhanVien();
        void goiyten()
        {// gợi ý tên nhân viên khi tìm kiếm
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Append;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            DataTable dtb = busNhanVien.TenNVGoiY();
            string tenban;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                tenban = dtb.Rows[i]["TenNV"].ToString();
                auto1.Add(tenban);
            }
            txtTimKiem.AutoCompleteCustomSource = auto1;
        }
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
            dtNgaySinh.Value = new DateTime(2000, 01, 01);
        }
        string checkurlimage;
        string filename;
        string fileaddress="Images";
        string hinh;
        string txtHinh;
        static string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
        string filesavepath = saveDirectory + "\\Images\\" + "macdinh.jpg";
        private void btnMoHinh_Click(object sender, EventArgs e)
        {// xem chú thích ở button mở hình form món ăn
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (.jpg, *.jpeg, *.jpe, *.jfif, *.png)|.jpg; .jpeg; *.jpe; *.jfif; *.png|All files (.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                fileaddress = openFile.FileName;
                picnhanvien.Image = Image.FromFile(fileaddress);
                filename = Path.GetFileName(openFile.FileName);
                saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filesavepath = saveDirectory + "\\Images\\" + filename;
                if (File.Exists(filesavepath))
                {
                    Utils.HienWarning("Hình đã tồn tại. Vui lòng chọn hình mới");
                }
                else
                {
                    txtHinh = "\\Images\\" + filename;
                    picnhanvien.Image = Image.FromFile(fileaddress);
                }
            }
        }
        void ResetValue()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
            txtTimKiem.Text = "";
            txtHinh = null;
            rdoAdmin.Checked = false;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            rdoNV.Checked = false;
            rdoHoatDong.Checked = false;
            rdoNgungHoatDong.Checked = false;
            picnhanvien.Image = null;

            txtDiaChi.Enabled =false;
            txtEmail.Enabled =  false;
            txtMaNV.Enabled =false;
            txtSDT.Enabled = false;
            txtTenNV.Enabled = false;
            txtTimKiem.Enabled = true;
            rdoAdmin.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            rdoNV.Enabled = false;
            rdoHoatDong.Enabled = false;
            rdoNgungHoatDong.Enabled = false;
            picnhanvien.Image = null;

            btnLuu.Enabled = false;
            btnMoHinh.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = false;
            dtNgaySinh.Enabled = false;
        }
        public void LoadGridView()
        {// hiển thi danh sách nhân viên lên datagridview
            dtgvQLNhanVien.DataSource = busNhanVien.DanhSachNhanVien();
            dtgvQLNhanVien.Columns[0].HeaderText = "Mã NV";
            dtgvQLNhanVien.Columns[1].HeaderText = "Tên NV";
            dtgvQLNhanVien.Columns[2].HeaderText = "Email";
            dtgvQLNhanVien.Columns[3].HeaderText = "Ngày Sinh";
            dtgvQLNhanVien.Columns[4].HeaderText = "Giới Tính";
            dtgvQLNhanVien.Columns[5].HeaderText = "Địa Chỉ";
            dtgvQLNhanVien.Columns[6].HeaderText = "SĐT";
            dtgvQLNhanVien.Columns[7].HeaderText = "Vai Trò";
            dtgvQLNhanVien.Columns[8].HeaderText = "Trạng Thái";
            dtgvQLNhanVien.Columns[9].HeaderText = "Hình Ảnh";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (Utils.KiemTraTextBox(txtTimKiem, "Tên nhân viên"))// kiểm tra trống
            {// hiển thị danh sách nhân viên tìm kiếm
                dtgvQLNhanVien.DataSource = busNhanVien.TimKiemNhanVien(txtTimKiem.Text);
                dtgvQLNhanVien.Columns[0].HeaderText = "Mã NV";
                dtgvQLNhanVien.Columns[1].HeaderText = "Tên NV";
                dtgvQLNhanVien.Columns[2].HeaderText = "Email";
                dtgvQLNhanVien.Columns[3].HeaderText = "Ngày Sinh";
                dtgvQLNhanVien.Columns[4].HeaderText = "Giới Tính";
                dtgvQLNhanVien.Columns[5].HeaderText = "Địa Chỉ";
                dtgvQLNhanVien.Columns[6].HeaderText = "SĐT";
                dtgvQLNhanVien.Columns[7].HeaderText = "Vai Trò";
                dtgvQLNhanVien.Columns[8].HeaderText = "Trạng Thái";
                dtgvQLNhanVien.Columns[9].HeaderText = "Hình Ảnh";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
            txtTimKiem.Text = "";
            dtNgaySinh.Value = new DateTime(2000, 01, 01);
            rdoNam.Checked = true;
            rdoNV.Checked = true;
            rdoHoatDong.Checked = true;
            picnhanvien.Image = null;

            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtMaNV.Enabled = false;
            txtSDT.Enabled = true;
            txtTenNV.Enabled = true;
            txtTimKiem.Enabled = false;
            rdoAdmin.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            rdoNV.Enabled = true;
            rdoHoatDong.Enabled = true;
            rdoNgungHoatDong.Enabled = true;
            picnhanvien.Image = null;

            btnLuu.Enabled = true;
            btnMoHinh.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
            dtNgaySinh.Enabled = true;

            txtEmail.Focus();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
            txtTimKiem.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // kiểm tra trống và lấy vai tro giới tính, trạng thái
            if (!Utils.KiemTraTextBox(txtEmail, "Email") || !Utils.KiemTraTextBox(txtTenNV, "Tên nhân viên")
                || !Utils.KiemTraTextBox(txtDiaChi, "Địa chỉ") || !Utils.KiemTraTextBox(txtSDT, "Số điện thoại")) return;
            int GioiTinh = 1;
            if(rdoNu.Checked==true)
            {
                GioiTinh = 0;
            }
            int VaiTro = 1;
            if(rdoNV.Checked==true)
            {
                VaiTro = 0;
            }
            int TrangThai = 1;
            if(rdoNgungHoatDong.Checked==true)
            {
                TrangThai = 0;
            }    
            if(rdoAdmin.Checked==false && rdoNV.Checked==false)
            {
                Utils.HienError("Vui lòng chọn vai trò");
            }    
            else if(rdoNu.Checked==false&&rdoNam.Checked==false)
            {
                Utils.HienError("Vui lòng chọn giới tính");
            }    
            else if(rdoHoatDong.Checked==false&&rdoNgungHoatDong.Checked==false)
            {
                Utils.HienError("Vui lòng chọn trạng thái");
            }       
            else if(!IsValidEmail(txtEmail.Text))
            {
                Utils.HienError("Email không chính xác");
            }// kiểm tra email đúng định dạng
            else if(txtSDT.Text.Trim().Length<10)
            {
                Utils.HienError("SĐT không chính xác");
            }    
            else
            {   
                if(txtHinh==null)//nếu không chọn hình sẽ cho hình mặc định
                {
                    txtHinh = @"\Images\macdinh.jpg";
                }    
                if(Utils.XacNhan("Bạn muốn thêm nhân viên này?"))
                {
                    dtoNhanVien = new DTO_NhanVien(txtTenNV.Text, txtEmail.Text, dtNgaySinh.Value, 
                                                   GioiTinh, txtDiaChi.Text, txtSDT.Text, VaiTro, TrangThai,  txtHinh);
                    if (busNhanVien.ThemNhanVien(dtoNhanVien))// thêm nhân viên vào database
                    {
                        if (File.Exists(filesavepath))
                        {
                            Utils.HienWarning("Hình ảnh đã tồn tại. Vui lòng chọn ảnh khác");
                        }
                        else
                        {
                            sendEmail(dtoNhanVien.Email, "abc123");
                            Utils.HienThongBao("Thêm nhân viên thành công");
                            if (txtHinh != @"\Images\macdinh.jpg")
                            {
                                File.Copy(fileaddress, filesavepath, true);
                            }
                            ResetValue();
                            LoadGridView();
                        }
                    }
                    else
                    {// email trùng sẽ không được thêm
                        Utils.HienThongBao("Email đã tồn tại");
                    }
                }    

            }    
        }
        public static void sendEmail(string email, string matkhau) // gửi email
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential("sonnqps18832@fpt.edu.vn", "son080320");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("sonnqps18832@fpt.edu.vn");
                Msg.To.Add(email);
                Msg.Subject = "Cập nhật mật khẩu";
                Msg.Body = "Chào anh/chị. Mật khẩu để truy cập phần mềm là :" + matkhau;
                client.Credentials = cred;
                client.Send(Msg);
                MessageBox.Show("Một Email mật khẩu đã được gởi đi!");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        public bool IsValidEmail(string email)
        {// kiểm tra email đúng định dạng
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text.Trim().Length==0)// kiêm tra trống
            {
                Utils.HienError("Vui lòng chọn nhân viên cần xóa");
            }    
            if(Utils.XacNhan("Bạn muốn xóa nhân viên này"))
            {
                if(busNhanVien.XoaNhanVien(txtMaNV.Text))// xóa nhân viên 
                {
                    Utils.HienThongBao("Xóa nhân viên thành công");
                    ResetValue();
                    LoadGridView();
                }
                else
                {// nhân viên có hóa đơn chưa thanh toán không cho xóa
                    Utils.HienWarning("Nhân viên đang có hóa đơn chưa thanh toán. Không được xóa");
                }    
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống và lấy vai trò , trạng thái , giới tính
            if (!Utils.KiemTraTextBox(txtEmail, "Email") || !Utils.KiemTraTextBox(txtTenNV, "Tên nhân viên")
               || !Utils.KiemTraTextBox(txtDiaChi, "Địa chỉ") || !Utils.KiemTraTextBox(txtSDT, "Số điện thoại")) return;
            int GioiTinh = 1;
            if (rdoNu.Checked == true)
            {
                GioiTinh = 0;
            }
            int VaiTro = 1;
            if (rdoNV.Checked == true)
            {
                VaiTro = 0;
            }
            int TrangThai = 1;
            if (rdoNgungHoatDong.Checked == true)
            {
                TrangThai = 0;
            }
            if (rdoAdmin.Checked == false && rdoNV.Checked == false)
            {
                Utils.HienError("Vui lòng chọn vai trò");
            }
            else if (rdoNu.Checked == false && rdoNam.Checked == false)
            {
                Utils.HienError("Vui lòng chọn giới tính");
            }
            else if (rdoHoatDong.Checked == false && rdoNgungHoatDong.Checked == false)
            {
                Utils.HienError("Vui lòng chọn trạng thái");
            }
            else if(txtSDT.Text.Trim().Length<10)
            {
                Utils.HienError("SĐT không chính xác");
            }    
            else
            {
                string MaNV = txtMaNV.Text;
                if(Utils.XacNhan("Bạn muốn cập nhật nhân viên này"))
                {
                    dtoNhanVien = new DTO_NhanVien(MaNV, txtTenNV.Text, txtEmail.Text,  dtNgaySinh.Value,
                                                        GioiTinh, txtDiaChi.Text, txtSDT.Text, VaiTro, TrangThai, txtHinh);
                    if(busNhanVien.SuaNhanVien(dtoNhanVien))// cập nhật thông tin nhân viên
                    {
                        if (txtHinh != checkurlimage)// lưu hình ảnh mới nếu có
                        {
                            File.Copy(fileaddress, filesavepath, true);
                        }
                        Utils.HienThongBao("Cập nhật nhân viên thành công");
                        ResetValue();
                        LoadGridView();
                    }
                    else
                    {
                        Utils.HienError("Cập nhật thất bại");
                    }    
                }    
            }    
        }

        private void dtgvQLNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            {// hiển thị thông tin lên các vị trí tương ứng
                DataGridViewRow rows = this.dtgvQLNhanVien.Rows[e.RowIndex];
                if (rows.Cells[1].Value.ToString().Count() == 0)
                {
                    MessageBox.Show("Không tồn tại dữ liệu");
                    ResetValue();
                }
                else
                {
                    if (rows.Cells[0].Value.ToString() == "Admin")
                    {
                        txtDiaChi.Enabled = false;
                        txtEmail.Enabled = false;
                        txtMaNV.Enabled = false;
                        txtSDT.Enabled = false;
                        txtTenNV.Enabled = false;
                        txtTimKiem.Enabled = true;
                        rdoAdmin.Enabled = false;
                        rdoNam.Enabled = false;
                        rdoNu.Enabled = false;
                        rdoNV.Enabled = false;
                        rdoHoatDong.Enabled = false;
                        rdoNgungHoatDong.Enabled = false;
                        btnMoHinh.Enabled = false;
                        btnSua.Enabled = false;
                        btnThem.Enabled = true;
                        btnTimKiem.Enabled = false;
                        btnXoa.Enabled = false;
                        dtNgaySinh.Enabled = false;
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        string emailXoa = rows.Cells[2].Value.ToString().Substring(0, 1).ToUpper() + rows.Cells[2].Value.ToString().Substring(1).ToLower();
                        if (rows.Cells[2].Value.ToString() == frmGiaoDien._Email ||
                                emailXoa == frmGiaoDien._Email)
                        {
                            btnXoa.Enabled = false;
                        }
                        else
                        {
                            btnXoa.Enabled = true;
                        }
                        txtDiaChi.Enabled = true;
                        txtEmail.Enabled = false;
                        txtMaNV.Enabled = false;
                        txtSDT.Enabled = true;
                        txtTenNV.Enabled = true;
                        txtTimKiem.Enabled = true;
                        rdoAdmin.Enabled = true;
                        rdoNam.Enabled = true;
                        rdoNu.Enabled = true;
                        rdoNV.Enabled = true;
                        rdoHoatDong.Enabled = true;
                        rdoNgungHoatDong.Enabled = true;
                        btnLuu.Enabled = false;
                        btnMoHinh.Enabled = true;
                        btnSua.Enabled = true;
                        btnThem.Enabled = true;
                        btnTimKiem.Enabled = true;
                        dtNgaySinh.Enabled = true;
                    }
                    txtMaNV.Text = rows.Cells[0].Value.ToString();
                    txtTenNV.Text = rows.Cells[1].Value.ToString();
                    txtEmail.Text = rows.Cells[2].Value.ToString();
                    dtNgaySinh.Text = rows.Cells[3].Value.ToString();
                    if (bool.Parse(rows.Cells[4].Value.ToString()) == true)
                    {
                        rdoNam.Checked = true;
                    }
                    else
                    {
                        rdoNu.Checked = true;
                    }
                    txtDiaChi.Text = rows.Cells[5].Value.ToString();
                    txtSDT.Text = rows.Cells[6].Value.ToString();
                    if (bool.Parse(rows.Cells[7].Value.ToString()) == true)
                    {
                        rdoAdmin.Checked = true;
                    }
                    else
                    {
                        rdoNV.Checked = true;
                    }
                    if (bool.Parse(rows.Cells[8].Value.ToString()) == true)
                    {
                        rdoHoatDong.Checked = true;
                    }
                    else
                    {
                        rdoNgungHoatDong.Checked = true;
                    }
                    hinh = rows.Cells[9].Value.ToString();
                    txtHinh = hinh;
                    checkurlimage = hinh;
                    picnhanvien.Image = Image.FromFile(saveDirectory + hinh);
                }
            }    
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
           /* if (txtSDT.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtSDT.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Số SDT không được nhập kí tự nhé !", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Text = "";
                    txtSDT.Focus();
                    return;
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {// button phục hồi nhân viên đã xóa
            frmPhucHoi f1 = new frmPhucHoi("Danh Sách Nhân Viên Đã Xóa");
            if(f1.ShowDialog()==DialogResult.Cancel)
            {
                ResetValue();
                LoadGridView();
                txtTimKiem.Text = "";
            }    
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {// chỉ cho phép nhập từ 0 đến 9 và phím backspace
            if ((e.KeyChar < '0') || (e.KeyChar > '9')) e.Handled = true;
            if (e.KeyChar == 8) e.Handled = false;

        }
    }
}
