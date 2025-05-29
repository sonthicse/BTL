using System;
using System.Data;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlCD : UserControl
    {
        private readonly Database _db = new();
        private string _username = "";
        private string _origPassword = "";

        public UserControlCD()
        {
            InitializeComponent();
            buttonDMK.Click += ButtonDMK_Click;
            buttonXacNhan.Click += ButtonXacNhan_Click;
            buttonHuy.Click += ButtonHuy_Click;
        }

        public void LoadAccount(string maGV)
        {
            _username = _db.GetDataTable("SELECT Username FROM TaiKhoan WHERE MaGV=@g", ("@g", maGV) ).Rows[0]["Username"].ToString() ?? "";

            textBoxUsername.Text = _username;

            var dt = _db.GetDataTable("SELECT Password FROM TaiKhoan WHERE Username=@u", ("@u", _username) );
            if (dt.Rows.Count > 0)
            {
                _origPassword = dt.Rows[0]["Password"].ToString() ?? "";
                textBoxPassword.Text = _origPassword;
            }
            else
            {
                _origPassword = textBoxPassword.Text = "";
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

            bool ok = _db.UpdatePassword(_username, newPass);
            if (ok)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _origPassword = newPass;
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
            textBoxPassword.Text = _origPassword;
            textBoxPassword.Enabled = false;
            buttonXacNhan.Visible = false;
            buttonHuy.Visible = false;
            buttonDMK.Visible = true;
        }
    }
}
