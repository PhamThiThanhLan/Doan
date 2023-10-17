using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entities;
using GUI;

namespace ThanhLan
{
    public partial class GUI_SanPham : Form
    {
        BUS_SanPham bus_ch = new BUS_SanPham();
        BUS_LoaiSanPham bus_dch = new BUS_LoaiSanPham();
        void loaddgv()
        {
            dgvSanPham.DataSource = bus_ch.getData();
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Hàng tồn kho";
            dgvSanPham.Columns[3].HeaderText = "Giá bán";
            dgvSanPham.Columns[4].HeaderText = "Tình trạng";
            dgvSanPham.Columns[5].HeaderText = "Mã loại sản phẩm";
            dgvSanPham.Columns[6].HeaderText = "Đơn vị tính";
        }
        void loadcbb()
        {
            cbbDayCH.DataSource = bus_dch.getData();
            cbbDayCH.DisplayMember = "TenLoaiSanPham";
            cbbDayCH.ValueMember = "MaLoaiSanPham";
        }
        
        public GUI_SanPham()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void FormSP_Load(object sender, EventArgs e)
        {
            loaddgv();
            loadcbb();
           
            
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtsanpham.Text = dgvSanPham[0, i].Value.ToString();
                cbbDayCH.Text = bus_dch.valuecbbDCH(dgvSanPham[5, i].Value.ToString());
                txtTT.Text = dgvSanPham[4, i].Value.ToString();
                txtDG.Text = dgvSanPham[3, i].Value.ToString();
                tb_donvitinh.Text = dgvSanPham[6, i].Value.ToString();
                txtTen.Text = dgvSanPham[1, i].Value.ToString();
                tb_hangtonkho.Text = dgvSanPham[2, i].Value.ToString();
            }catch(Exception)
            {

            }
           
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is TextBox || ctr is ComboBox || ctr is DateTimePicker)
                {
                    ctr.Text = "";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham ch = new SanPham();
                ch.MaSanPham = txtsanpham.Text;
                ch.TenSanPham = txtTen.Text;
                ch.MaLoaiSanPham = cbbDayCH.SelectedValue.ToString();
                ch.HangTonKho = Int32.Parse(tb_hangtonkho.Text);
                ch.TinhTrang = txtTT.Text;
                ch.GiaBan = float.Parse(txtDG.Text);
                ch.DonViTinh = tb_donvitinh.Text;
               
                if (bus_ch.kiemtramatrung(txtsanpham.Text) == 1)
                {
                    MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bus_ch.ThemCH(ch) == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        loaddgv();
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                SanPham ch = new SanPham();
                ch.MaSanPham = txtsanpham.Text;
                ch.TenSanPham = txtTen.Text;
                ch.MaLoaiSanPham = cbbDayCH.SelectedValue.ToString();
                ch.HangTonKho = Int32.Parse(tb_hangtonkho.Text);
                ch.TinhTrang = txtTT.Text;
                ch.GiaBan = float.Parse(txtDG.Text);
                ch.DonViTinh = tb_donvitinh.Text;
                if (bus_ch.SuaCH(ch) == true)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    loaddgv();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtsanpham.Text;
                if (bus_ch.XoaCH(ma) == true)
                {
                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    loaddgv();
                }
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
        void loaddgvTimKiemSP(string masp,  string giaban)
        {
            try

            {
                dgvSanPham.DataSource = bus_ch.TimKiem(masp,  giaban);
                if (dgvSanPham.DataSource == null)
                {
                    MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm sản phẩm!!!");
                }
                else
                {
                    //dgvSanPham.DataSource = bus_ch.getData();
                    dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                    dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                    dgvSanPham.Columns[2].HeaderText = "Dung tích";
                    dgvSanPham.Columns[3].HeaderText = "Giá bán";
                    dgvSanPham.Columns[4].HeaderText = "Tình trạng";
                    dgvSanPham.Columns[5].HeaderText = "Mã loại sản phẩm";
                }
            }catch(Exception)
            {
                MessageBox.Show("Nhập thông tin sản phẩm");
            }
           
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void pbThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmNhanVien = new GUI_NhanVien();
            this.Hide();
            frmNhanVien.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmKhachHang = new GUI_KhachHang();
            this.Hide();
            frmKhachHang.ShowDialog();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
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

        private void txtDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoNha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Tim_Enter(object sender, EventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frmCanHo = new GUI_ThongKe_BaoCao();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui_HoaDonNhap frmCanHo = new Gui_HoaDonNhap();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap frmCanHo = new GUI_NhaCungCap();
            this.Hide();
            frmCanHo.ShowDialog();
        }
    }
}
