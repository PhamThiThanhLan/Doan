
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
    public partial class Gui_Menu : Form
    {
        public Gui_Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmCanHo = new GUI_NhanVien();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmCanHo = new GUI_KhachHang();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui_HoaDonNhap frmCanHo = new Gui_HoaDonNhap();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void sốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmCanHo = new GUI_HoaDon();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frmCanHo = new GUI_ThongKe_BaoCao();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap frm = new GUI_NhaCungCap();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
