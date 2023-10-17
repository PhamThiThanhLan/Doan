using BUS;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanhLan
{
    public partial class GUI_NhaCungCap : Form
    {
        public GUI_NhaCungCap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
       
        void loaddgvNCC()
        {
            dgvNCC.DataSource = bus_ncc.getData();
            dgvNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns[1].HeaderText = "Tên nhà cung cấp ";
            dgvNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNCC.Columns[3].HeaderText = "Số điện thoại";
        }

        private void pbThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox2.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

      

     

     

      

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
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

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
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

        private void GUI_NhaCungCap_Load(object sender, EventArgs e)
        {
            loaddgvNCC();
            if (Program.code == 0)
            {

            }
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaNCC.Text = dgvNCC[0, i].Value.ToString();
            txtTenNCC.Text = dgvNCC[1, i].Value.ToString();
            txtDiaChi.Text = dgvNCC[2, i].Value.ToString();
            txtSDT.Text = dgvNCC[3, i].Value.ToString();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            try
            {
                string ma = txtMaNCC.Text;
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (bus_ncc.XoaNCC(ma))
                    {
                        MessageBox.Show("Xoá thành công!!!");
                        loaddgvNCC();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

            try
            {
                NhaCungCap kh = new NhaCungCap();
                kh.NhaCungCapID = txtMaNCC.Text;
                kh.TenNhaCungCap = txtTenNCC.Text;
                kh.DiaChiNhaCungCap = txtDiaChi.Text;
                kh.SoDienThoai = txtSDT.Text;
                if (bus_ncc.kiemtramatrung(txtMaNCC.Text) > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại! Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (bus_ncc.ThemNCC(kh))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công!!!");
                        loaddgvNCC();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                NhaCungCap kh = new NhaCungCap();
                kh.NhaCungCapID = txtMaNCC.Text;
                kh.TenNhaCungCap = txtTenNCC.Text;
                kh.DiaChiNhaCungCap = txtDiaChi.Text;
                kh.SoDienThoai = txtSDT.Text;
                if (bus_ncc.SuaNCC(kh))
                {
                    MessageBox.Show("Sửa thông tin nhà cung cấp thành công !!");
                    loaddgvNCC();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            GUI_HoaDon frmCanHo = new GUI_HoaDon();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem8_Click_1(object sender, EventArgs e)
        {
           GUI_NhanVien frmCanHo = new GUI_NhanVien();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmCanHo = new GUI_KhachHang();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Gui_HoaDonNhap frmCanHo = new Gui_HoaDonNhap();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void mnTimKiem_Click_1(object sender, EventArgs e)
        {
            GUI_TimKiem frmCanHo = new GUI_TimKiem();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frmCanHo = new GUI_ThongKe_BaoCao();
            this.Hide();
            frmCanHo.ShowDialog();
        }
    }
}

