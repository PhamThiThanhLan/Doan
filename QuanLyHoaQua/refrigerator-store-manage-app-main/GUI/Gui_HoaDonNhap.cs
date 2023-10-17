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
    public partial class Gui_HoaDonNhap : Form
    {
        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_HoaDonNhap bus_hd = new BUS_HoaDonNhap();
        BUS_SanPham bus_sp = new BUS_SanPham();
        BUS_CTHDN bus_cthdn = new BUS_CTHDN();
        void loadcbbNV()
        {
            cbbNV.DataSource = bus_nv.getData();
            cbbNV.DisplayMember = "TenNV";
            cbbNV.ValueMember = "MaNV";
            cbb_tenhoaqua.DataSource = bus_sp.getData();
            cbb_tenhoaqua.DisplayMember = "TenSanPham";
            cbb_tenhoaqua.ValueMember = "MaSanPham";
        }
        void loaddgvHoaDonBan()
        {
            dgvHoaDonBan.DataSource = bus_hd.getData();
            dgvHoaDonBan.Columns[0].HeaderText = "Mã hoá đơn";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã nhân viên";
            dgvHoaDonBan.Columns[2].HeaderText = "Ngày nhập";
            dgvHoaDonBan.Columns[3].HeaderText = "Nhà Cung Cấp";

        }
        void loadcbbNCC()
        {

            cbbNcc.DataSource = bus_ncc.getData();
            cbbNcc.DisplayMember = "TenNhaCungCap";
            cbbNcc.ValueMember = "NhaCungCapID";
        }
        public Gui_HoaDonNhap()
        {
            InitializeComponent();
            loadcbbNV();
            loadcbbNCC();
            loaddgvHoaDonBan();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HoaDonNhap hd = new HoaDonNhap();
            hd.MaHDN = Int32.Parse( txtMaHDB.Text);
            hd.MaNV = cbbNV.SelectedValue.ToString();
            hd.NhaCungCapID = cbbNcc.SelectedValue.ToString();
            string datebirthday = string.Format("{0}/{1}/{2}", dtNgayBan.Value.Day, dtNgayBan.Value.Month, dtNgayBan.Value.Year);
            hd.NgayNhap = datebirthday;

            if (bus_hd.kiemtramatrung(txtMaHDB.Text) > 0)
            {
                MessageBox.Show("Mã hoá đơn đã tồn tại! Vui lòng nhập mã khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_hd.ThemKH(hd))
                {
                    MessageBox.Show("Thêm thành công!!!");
                    loaddgvHoaDonBan();
                }
            }
        }

        void loaddgvChiTietHDB(string ma)
        {
            dgvcthdb.DataSource = bus_cthdn.getData(ma);
            dgvcthdb.Columns[0].HeaderText = "Mã hoá đơn";
            dgvcthdb.Columns[1].HeaderText = "Số sản phẩm";
            dgvcthdb.Columns[2].HeaderText = "Đơn giá";
           
            dgvcthdb.Columns[3].HeaderText = "Thành tiền";
        }
        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaHDB.Text = dgvHoaDonBan[0, i].Value.ToString();
            loaddgvChiTietHDB(dgvHoaDonBan[0, i].Value.ToString());
            cbbNV.Text = bus_nv.valuecbbNV(dgvHoaDonBan[1, i].Value.ToString());
            cbbNcc.Text = bus_ncc.valuecbbNCC(dgvHoaDonBan[3, i].Value.ToString());
            dtNgayBan.Text = dgvHoaDonBan[2, i].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonNhap hd = new HoaDonNhap();
                hd.MaHDN = Int32.Parse(txtMaHDB.Text);
                hd.MaNV = cbbNV.SelectedValue.ToString();
                hd.NhaCungCapID = cbbNcc.SelectedValue.ToString();
                string datebirthday = string.Format("{0}/{1}/{2}", dtNgayBan.Value.Day, dtNgayBan.Value.Month, dtNgayBan.Value.Year);
                hd.NgayNhap = datebirthday;


                if (bus_hd.SuaKH(hd))
                {
                    MessageBox.Show("Sửa thành công!!!");
                    loaddgvHoaDonBan();
                }
            }catch(Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin");
            }
           
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaHDB.Text;
                DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này ? Nếu hóa đơn có giá trị bên bảng chi tiết sẽ không xóa được !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == System.Windows.Forms.DialogResult.Yes)
                {
                    if (bus_hd.XoaKH(ma))
                    {
                        MessageBox.Show("Xóa thành công ");
                        loaddgvHoaDonBan();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin");
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHDN hd = new ChiTietHDN();
                HoaDon hdb = new HoaDon();
                hd.MaHDN = Int32.Parse(txtMaHDB.Text);
                hd.MaSanPham = cbb_tenhoaqua.SelectedValue.ToString();
            hd.DonGia = Int32.Parse(txtdongia.Text);
            hd.SoLuong = Int32.Parse(tb_sl.Text);
            hd.TongTien = hd.SoLuong * hd.DonGia;


            if (bus_cthdn.ThemCTHDB(hd))
                {
                    MessageBox.Show("Thêm thành công!!!");
                    //loaddgvChiTietHDB(txtMaHDB.Text);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường dữ liệu hoặc sản phẩm trên đã thuộc hóa đơn nhập này !!");
            }
        }

        private void dgvcthdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
          
            
            cbb_tenhoaqua.Text =  bus_sp.valuecbbNV(dgvcthdb[1, i].Value.ToString());
            txtdongia.Text = dgvcthdb[3, i].Value.ToString();
            tb_sl.Text = dgvcthdb[2, i].Value.ToString();
           
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHDN hd = new ChiTietHDN();
                HoaDon hdb = new HoaDon();
                hd.MaHDN = Int32.Parse(txtMaHDB.Text);
                hd.MaSanPham = cbb_tenhoaqua.SelectedValue.ToString();
                hd.DonGia = Int32.Parse(txtdongia.Text);
                hd.SoLuong = Int32.Parse(tb_sl.Text);
                hd.TongTien = hd.SoLuong * hd.DonGia;


                if (bus_cthdn.SuaCTHDB(hd))
                {
                    MessageBox.Show("Sửa thành công!!!");
                    //loaddgvChiTietHDB(txtMaHDB.Text);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường dữ liệu hoặc sản phẩm trên đã thuộc hóa đơn nhập này !!");
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            string ma = cbb_tenhoaqua.SelectedValue.ToString();
            string mahd = txtMaHDB.Text;
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_cthdn.XoaCTHDB(ma, mahd))
                {
                    MessageBox.Show("Xóa thành công ");
                    loaddgvHoaDonBan();
                }
            }
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

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmCanHo = new GUI_KhachHang();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmCanHo = new GUI_NhanVien();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmCanHo = new GUI_HoaDon();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_SanPham frmCanHo = new GUI_SanPham();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmCanHo = new GUI_TimKiem();
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
