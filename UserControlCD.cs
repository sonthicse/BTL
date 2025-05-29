using System;
using System.Data;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlCD : UserControl
    {
        private readonly Database db = new();
        private string username = "";
        private string origPassword = "";

        public UserControlCD()
        {
            InitializeComponent();
            buttonDMK.Click += ButtonDMK_Click;
            buttonXacNhan.Click += ButtonXacNhan_Click;
            buttonHuy.Click += ButtonHuy_Click;
        }

        public void LoadAccount(string maGV)
        {
            username = db.GetDataTable("SELECT Username FROM TaiKhoan WHERE MaGV=@g", ("@g", maGV) ).Rows[0]["Username"].ToString() ?? "";

            textBoxUsername.Text = username;

            var dt = db.GetDataTable("SELECT Password FROM TaiKhoan WHERE Username=@u", ("@u", username) );
            if (dt.Rows.Count > 0)
            {
                origPassword = dt.Rows[0]["Password"].ToString() ?? "";
                textBoxPassword.Text = origPassword;
            }
            else
            {
                origPassword = textBoxPassword.Text = "";
            }

            textBoxPassword.Enabled = false;
            buttonXacNhan.Visible = false;
            buttonHuy.Visible = false;
            buttonDMK.Visible = true;
        }

        private void ButtonDMK_Click(object? sender, EventArgs e)
        {
            textBoxPassword.Enabled = true;
            buttonXacNhan.Visible = true;
            buttonHuy.Visible = true;
            buttonDMK.Visible = false;
            textBoxPassword.Focus();
        }

        private void ButtonXacNhan_Click(object? sender, EventArgs e)
        {
            string newPass = textBoxPassword.Text.Trim();
            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return;
            }

            bool ok = db.UpdatePassword(username, newPass);
            if (ok)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                origPassword = newPass;
            }
            else
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBoxPassword.Enabled = false;
            buttonXacNhan.Visible = false;
            buttonHuy.Visible = false;
            buttonDMK.Visible = true;
        }

        private void ButtonHuy_Click(object? sender, EventArgs e)
        {
            textBoxPassword.Text = origPassword;
            textBoxPassword.Enabled = false;
            buttonXacNhan.Visible = false;
            buttonHuy.Visible = false;
            buttonDMK.Visible = true;
        }
    }
}
