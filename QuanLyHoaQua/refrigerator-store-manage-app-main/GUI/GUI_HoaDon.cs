using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BUS;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using GUI;
using System.Globalization;

namespace ThanhLan
{
    public partial class GUI_HoaDon : Form
    {

        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        BUS_SanPham bus_ch = new BUS_SanPham();

        void loaddgvHoaDonBan()
        {
            dgvHoaDonBan.DataSource = bus_hd.getData();
            dgvHoaDonBan.Columns[0].HeaderText = "Mã hoá đơn";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã nhân viên";
            dgvHoaDonBan.Columns[2].HeaderText = "Mã khách hàng";
            dgvHoaDonBan.Columns[3].HeaderText = "Ngày bán";
            
        }
        void loaddgvChiTietHDB(string ma)
        {
            dgvcthdb.DataSource = bus_cthdb.getData(ma);
            dgvcthdb.Columns[0].HeaderText = "Mã hoá đơn";
            dgvcthdb.Columns[1].HeaderText = "Số sản phẩm";
            dgvcthdb.Columns[2].HeaderText = "Đơn giá";
            dgvcthdb.Columns[3].HeaderText = "Giảm giá";
            dgvcthdb.Columns[4].HeaderText = "Thành tiền";
        }
        void loadcbbNV()
        {
            cbbNV.DataSource = bus_nv.getData();
            cbbNV.DisplayMember = "TenNV";
            cbbNV.ValueMember = "MaNV";
        }
        void loadcbbKH()
        {
            cbbKH.DataSource = bus_kh.getData();
            cbbKH.DisplayMember = "TenKH";
            cbbKH.ValueMember = "MaKH";
        }
        void loaddgvCanHo(string ma,  string gb = "")
        {
            dgvcthdb.DataSource = bus_ch.TimKiem(ma,  gb);
            dgvcthdb.Columns[0].HeaderText = "Mã sản phẩm";
            dgvcthdb.Columns[1].HeaderText = "Tên sản phẩm";
            dgvcthdb.Columns[2].HeaderText = "Hàng tồn";
            dgvcthdb.Columns[3].HeaderText = "Giá bán";
            dgvcthdb.Columns[4].HeaderText = "Tình trạng";
            dgvcthdb.Columns[5].HeaderText = "Mã loại sản phẩm";
        }
        public GUI_HoaDon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            loaddgvHoaDonBan();
            loadcbbNV();
            loadcbbKH();
           
        }

        private void pbThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
        } 
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmNhanVien = new GUI_NhanVien();
            this.Hide();
            frmNhanVien.ShowDialog();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmKhachHang = new GUI_KhachHang();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtMaHDB.Text = dgvHoaDonBan[0, i].Value.ToString();
                loaddgvChiTietHDB(dgvHoaDonBan[0, i].Value.ToString());
                cbbNV.Text = bus_nv.valuecbbNV(dgvHoaDonBan[1, i].Value.ToString());
                cbbKH.Text = bus_kh.valuecbbKH(dgvHoaDonBan[2, i].Value.ToString());
                dtNgayBan.Text = dgvHoaDonBan[3, i].Value.ToString();
              
            }catch(Exception)
            {
              
            }
           
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.MaHDB = txtMaHDB.Text;
                hd.NhanVien = cbbNV.SelectedValue.ToString();
                hd.KhachHang = cbbKH.SelectedValue.ToString();
            string datebirthday = string.Format("{0}/{1}/{2}", dtNgayBan.Value.Day, dtNgayBan.Value.Month, dtNgayBan.Value.Year);
            hd.NgayBan = DateTime.Parse(datebirthday);
            if (bus_hd.kiemtramatrung(txtMaHDB.Text) > 0)
                {
                    MessageBox.Show("Mã hoá đơn đã tồn tại! Vui lòng nhập mã khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bus_hd.ThemHD(hd))
                    {
                        MessageBox.Show("Thêm thành công!!!");
                        loaddgvHoaDonBan();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI: " + ex.Message);
            }
        }

       
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.MaHDB = txtMaHDB.Text;
                hd.NhanVien = cbbNV.SelectedValue.ToString();
                hd.KhachHang = cbbKH.SelectedValue.ToString();

                DateTime ngayBan;
                if (DateTime.TryParse(dtNgayBan.Text, out ngayBan))
                {
                    hd.NgayBan = ngayBan;

                    if (bus_hd.SuaHD(hd))
                    {
                        MessageBox.Show("Sửa thành công!!!");
                        loaddgvHoaDonBan();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Ngày bán không hợp lệ!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI: " + ex.Message);
            }
        }

      

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaHDB.Text;
                DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == System.Windows.Forms.DialogResult.Yes)
                {
                    if (bus_hd.XoaHD(ma))
                    {
                        MessageBox.Show("Xóa thành công ");
                        loaddgvHoaDonBan();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
           
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDonBan hd = new ChiTietHoaDonBan();
                HoaDon hdb = new HoaDon();
                hd.MaHDB = txtMaHDB.Text;
                hd.MaSanPham = txtSoNha.Text;
                hd.DonGia = float.Parse(txtdongia.Text);
                hd.GiamGia = float.Parse(txtgiamgia.Text);
                hd.ThanhTien = float.Parse(txtthanhtien.Text);
                hd.SoLuongBan = Int32.Parse(tb_sl.Text);

                if (bus_cthdb.ThemCTHDB(hd))
                    {
                        MessageBox.Show("Thêm thành công!!!");
                        loaddgvChiTietHDB(txtMaHDB.Text);
                    }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường dữ liệu hoặc mã sản phẩm đã tồn tại trong chi tiết !!");
            }

        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDonBan hd = new ChiTietHoaDonBan();
                hd.MaHDB = txtMaHDB.Text;
                hd.MaSanPham = txtSoNha.Text;
                hd.DonGia = float.Parse(txtdongia.Text);
                hd.GiamGia = float.Parse(txtgiamgia.Text);
                hd.ThanhTien = float.Parse(txtthanhtien.Text);
                hd.SoLuongBan = Int32.Parse(tb_sl.Text);

                if (bus_cthdb.SuaCTHDB(hd))
                {
                    MessageBox.Show("Sửa thành công!!!");
                    loaddgvChiTietHDB(txtMaHDB.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng dữ liệu");
            }

        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            string ma = txtSoNha.Text;
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_cthdb.XoaCTHDB(ma))
                {
                    MessageBox.Show("Xóa thành công ");
                    loaddgvHoaDonBan();
                }
            }
        }

        private void dgvcthdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                try
                {
                    int rowIndex = e.RowIndex;
                    if (rowIndex >= 0 && rowIndex < dgvcthdb.Rows.Count)
                    {
                        DataGridViewRow row = dgvcthdb.Rows[rowIndex];
                        if (row.Cells[1].Value != null)
                            txtSoNha.Text = row.Cells[1].Value.ToString();
                        else
                            txtSoNha.Text = string.Empty;

                        if (row.Cells[2].Value != null)
                            txtdongia.Text = row.Cells[2].Value.ToString();
                        else
                            txtdongia.Text = string.Empty;

                        if (row.Cells[3].Value != null)
                            txtgiamgia.Text = row.Cells[3].Value.ToString();
                        else
                            txtgiamgia.Text = string.Empty;

                        if (row.Cells[4].Value != null)
                            txtthanhtien.Text = row.Cells[4].Value.ToString();
                        else
                            txtthanhtien.Text = string.Empty;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }


        

        private void txtSoNha_TextChanged(object sender, EventArgs e)
        {
            string ma = txtSoNha.Text;
            if (ma != "")
                loaddgvCanHo(ma);
        }
        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            string giamgia = txtgiamgia.Text;
            float dongia = float.Parse(txtdongia.Text);
            if (float.TryParse(giamgia, out float giamgiaValue))
            {
                txtthanhtien.Text = (dongia - giamgiaValue).ToString();
            }
            else
            {
                // Chuỗi không thể chuyển đổi thành số thực, xử lý lỗi
                // ...
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn nút X không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Gọi hàm Exit để đóng ứng dụng
                System.Windows.Forms.Application.Exit();
            }

            base.OnFormClosing(e);
        }

        private void dgvcthdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtSoNha.Text = dgvcthdb[1, i].Value.ToString();
                txtdongia.Text = dgvcthdb[2, i].Value.ToString();
                txtgiamgia.Text = (0).ToString();
                txtthanhtien.Text = dgvcthdb[2, i].Value.ToString();
            }catch(Exception ex)
            {
               
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvHoaDonBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtthanhtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tb_sl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dtNgayBan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvtthdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHDB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void mnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator7_Click(object sender, EventArgs e)
        {

        }

        private void mnQuanLy_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator8_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui_HoaDonNhap frmCanHo = new Gui_HoaDonNhap();
            this.Hide();
            frmCanHo.ShowDialog();
        }


        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                // Hiển thị hộp thoại lưu tệp
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Chọn vị trí và tên tệp Excel";
                saveFileDialog.FileName = "ten_tep_excel.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Tạo một đối tượng ExcelPackage mới
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Tạo một Sheet mới trong tệp Excel
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        // Đổ dữ liệu từ DataGridView vào Sheet Excel
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                            worksheet.Column(i + 1).AutoFit();
                        }

                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                            }
                        }

                        // Lưu tệp Excel
                        FileInfo excelFile = new FileInfo(filePath);
                        excelPackage.SaveAs(excelFile);
                    }

                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        
            // Gọi hàm xuất dữ liệu với DataGridView
           
       
        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvcthdb);
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frmCanHo = new GUI_ThongKe_BaoCao();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap frmCanHo = new GUI_NhaCungCap ();
            this.Hide();
            frmCanHo.ShowDialog();
        }
    }
}
