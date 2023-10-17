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
    public partial class GUI_DangNhap : Form
    {
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        public GUI_DangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                e.Cancel = true;
                txtUser.Focus();
                errUser.SetError(txtUser, "Ban cần nhập username!!!");
            }
            else
            {
                e.Cancel = false;
                errUser.SetError(txtUser, "");
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                e.Cancel = true;
                txtPass.Focus();
                errPass.SetError(txtPass, "Bạn cần nhập Password!!!");

            }
            else
            {
                e.Cancel = false;
                errPass.SetError(txtPass, "");
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
                txtPass.PasswordChar = (char)0;
            else
                txtPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string password = txtPass.Text;

            // Kiểm tra đăng nhập
            bool isValidLogin = bus_tk.KiemTraDangNhap(userName, password);

            if (isValidLogin)
            {
                // Thực hiện chuyển trang hoặc hiển thị dữ liệu tương ứng
                // Ví dụ:
                Gui_Menu frmCanHo = new Gui_Menu();
                this.Hide();
                frmCanHo.ShowDialog(); // Ẩn form hiện tại
                                       // ...
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!");
            }
        }

        private void GUI_DangNhap_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI_DangKy frmdangKy = new GUI_DangKy();
            this.Hide();
            frmdangKy.ShowDialog();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
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
    }
}
