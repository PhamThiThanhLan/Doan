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
    public partial class GUI_TimKiem : Form
    {
        BUS_SanPham bus_sp = new BUS_SanPham();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        public GUI_TimKiem()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        void loaddgvTimKiemSP(string sonha,  string giaban)
        {
            dgvTimKiem.DataSource = bus_sp.TimKiem(sonha,  giaban);
            if (dgvTimKiem.DataSource == null)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm sản phẩm!!!");
            }
            else
            {
                dgvTimKiem.Columns[0].HeaderText = "Tên sản phẩm";
                dgvTimKiem.Columns[1].HeaderText = "Dung tích";
                dgvTimKiem.Columns[2].HeaderText = "Giá bán";
                dgvTimKiem.Columns[3].HeaderText = "Tình trạng";
                dgvTimKiem.Columns[4].HeaderText = "Mã loại";
            }
        }
        void loaddgvTimKiemNV(string manv, string tennv, string diachi)
        {
            dgvTimKiem.DataSource = bus_nv.TimKiem(manv, tennv, diachi);
            if(dgvTimKiem.DataSource == null)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm nhân viên!!!");
            }
            else
            {
                dgvTimKiem.Columns[0].HeaderText = "Mã NV";
                dgvTimKiem.Columns[1].HeaderText = "Tên NV";
                dgvTimKiem.Columns[2].HeaderText = "Địa chỉ";
                dgvTimKiem.Columns[3].HeaderText = "Số điện thoại";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtmanv.Text;
                string tennv = txttennv.Text;
                string diachi = txtdiachi.Text;
                loaddgvTimKiemNV(manv, tennv, diachi);
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            }
            
        }
        void loaddgvTimKiemHDB(string mahdb, string manv, string makh)
        {
            dgvTimKiem.DataSource = bus_hd.TimKiem(mahdb, manv, makh);
            dgvTimKiem.Columns[0].HeaderText = "Mã HDB";
            dgvTimKiem.Columns[1].HeaderText = "Mã NV";
            dgvTimKiem.Columns[2].HeaderText = "Mã KH";
            dgvTimKiem.Columns[3].HeaderText = "Ngày bán";
            dgvTimKiem.Columns[4].HeaderText = "Tổng tiền";
        }
        private void btnTimKiemHDB_Click(object sender, EventArgs e)
        {
            try
            {
                string mahdb = txtmahdb.Text;
                string manv = txttmanv_hdb.Text;
                string makh = txtmakh_hdb.Text;
                loaddgvTimKiemHDB(mahdb, manv, makh);
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            }
           
        }
        void loaddgvTimKiemCTHDB(string mahd, string masp)
        {
            dgvTimKiem.DataSource = bus_cthdb.TimKiem(mahd, masp);
            dgvTimKiem.Columns[0].HeaderText = "Mã HDB";
            dgvTimKiem.Columns[1].HeaderText = "Số nhà";
            dgvTimKiem.Columns[2].HeaderText = "Đơn giá";
            dgvTimKiem.Columns[3].HeaderText = "Giảm giá";
            dgvTimKiem.Columns[4].HeaderText = "Thành tiền";
        }
        private void btnTimKiemCTHDB_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = txtmacthdb.Text;
                string masp = txtmasp_cthdb.Text;
                loaddgvTimKiemCTHDB(mahd, masp);
            }catch(Exception)
            {
                MessageBox.Show("Lỗi");
            }
          
        }

        private void GUI_TimKiem_Load(object sender, EventArgs e)
        {
            
           
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sonha = txtmasp.Text;
               
                string giaban = txtGiaBan.Text;
                loaddgvTimKiemSP(sonha,  giaban);
            }catch(Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng giá trị");
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

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //GUI_ frmNhanVien = new GUI_NhanVien();
            //this.Hide();
            //frmNhanVien.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }

        private void txtmasp_TextChanged(object sender, EventArgs e)
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

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap frmCanHo = new GUI_NhaCungCap();
            this.Hide();
            frmCanHo.ShowDialog();
        }
    }
}
