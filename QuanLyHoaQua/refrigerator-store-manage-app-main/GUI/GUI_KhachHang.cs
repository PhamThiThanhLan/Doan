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
using GUI;

namespace ThanhLan
{
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        public GUI_KhachHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        void loaddgvKhachHang()
        {
            dgvKhachHang.DataSource = bus_kh.getData();
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Số điện thoại";
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

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            loaddgvKhachHang();
           
           
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = txtMaKH.Text;
                kh.TenKH = txtTenKH.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.SDT = txtSDT.Text;
                if (bus_kh.kiemtramatrung(txtMaKH.Text) > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (bus_kh.ThemKH(kh))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!!!");
                        loaddgvKhachHang();
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
                KhachHang kh = new KhachHang();
                kh.MaKH = txtMaKH.Text;
                kh.TenKH = txtTenKH.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.SDT = txtSDT.Text;
                if (bus_kh.SuaKH(kh))
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công !!");
                    loaddgvKhachHang();
                }
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            } 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaKH.Text;
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (bus_kh.XoaKH(ma))
                    {
                        MessageBox.Show("Xoá thành công!!!");
                        loaddgvKhachHang();
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
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

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaKH.Text = dgvKhachHang[0, i].Value.ToString();
            txtTenKH.Text = dgvKhachHang[1, i].Value.ToString();
            txtDiaChi.Text = dgvKhachHang[2, i].Value.ToString();
            txtSDT.Text = dgvKhachHang[3, i].Value.ToString();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
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

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap frmCanHo = new GUI_NhaCungCap();
            this.Hide();
            frmCanHo.ShowDialog();
        }
    }
}
