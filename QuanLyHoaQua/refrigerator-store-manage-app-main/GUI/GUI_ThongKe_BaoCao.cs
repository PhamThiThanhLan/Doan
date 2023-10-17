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
    public partial class GUI_ThongKe_BaoCao : Form
    {
        BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        public GUI_ThongKe_BaoCao()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        void loaddgvHDBTheoThang(string thang, string nam)
        {
           
          
        }
        void loaddgvHDBTheoNam(string nam)
        {
            
        }

        private void GUI_ThongKe_BaoCao_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                string thang = txtThang.Text;
                string nam = txtNam1.Text;
                double doanhthu = bus_cthdb.ThongKeDoanhThuTheoThang(thang, nam);
                lblDoanhThuThang.Text = doanhthu.ToString();
                loaddgvHDBTheoThang(thang, nam);
            }    catch(Exception)
            {
                MessageBox.Show("Dữ liệu không đúng hoặc tháng trên không có hóa đơn");
            }
         
        }
        private void btnThongKeTheoNam_Click(object sender, EventArgs e)
        {
            try
            {
                string nam = txtNam3.Text;
                double doanhthu = bus_cthdb.ThongKeDoanhThuTheoNam(nam);
                lblDoanhThuNam.Text = doanhthu.ToString();
                loaddgvHDBTheoNam(nam);
            }catch(Exception)
            {
                MessageBox.Show("Dữ liệu không đúng hoặc năm trên không có hóa đơn");            }
           
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

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frm_KhachHang = new GUI_KhachHang();
            this.Hide();
            frm_KhachHang.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
