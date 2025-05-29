using System;
using System.Data;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlTK : UserControl
    {
        private readonly Database db = new();
        private DataTable dtTK;
        private DataView viewTK;
        private enum Mode { View, Add, ChangePass }
        private Mode mode = Mode.View;

        public UserControlTK()
        {
            InitializeComponent();
            Load += UserControlTK_Load;
        }

        public void UserControlTK_Load(object? sender, EventArgs e)
        {
            LoadGrid();
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            textBoxSearch.TextChanged += buttonSearch_Click;
            comboBoxGV.DisplayMember = "TenGV";
            comboBoxGV.ValueMember = "MaGV";
            comboBoxGV.DataSource = db.GetAll<GiangVien>();

            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void LoadGrid()
        {
            string filter = viewTK?.RowFilter ?? "";
            dtTK = db.GetAll<TaiKhoan>();
            viewTK = new DataView(dtTK) { RowFilter = filter };
            dataGridView.DataSource = viewTK;
            dataGridView.Columns["Username"].HeaderText = "Tên đăng nhập";
            dataGridView.Columns["Password"].HeaderText = "Mật khẩu";
            dataGridView.Columns["Role"].HeaderText = "Phân quyền";
            dataGridView.Columns["TenGV"].HeaderText = "Giảng viên";
            dataGridView.Columns["MaGV"].Visible = false;
            dataGridView.Columns["MaKhoa"].Visible = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["Username"].FillWeight = 25;
            dataGridView.Columns["Password"].FillWeight = 25;
            dataGridView.Columns["Role"].FillWeight = 20;
            dataGridView.Columns["TenGV"].FillWeight = 30;
        }

        private void DataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;
            textBox1.Text = row["Username"].ToString();
            textBox2.Text = row["Password"].ToString();
            textBox3.Text = row["Role"].ToString();
            comboBoxGV.Text = row["TenGV"].ToString();
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            viewTK.RowFilter = string.IsNullOrEmpty(kw) ? "" : $"Username LIKE '%{kw}%' OR Role LIKE '%{kw}%'";
        }

        private void buttonThem_Click(object? sender, EventArgs e)
        {
            mode = Mode.Add;
            ClearInput();
            ToggleEdit(true);
        }

        private void buttonDMK_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            mode = Mode.ChangePass;

            ToggleEdit(true);
        }

        private void buttonHuy_Click(object? sender, EventArgs e)
        {
            mode = Mode.View;
            ToggleEdit(false);
            buttonXN.Visible = buttonHuy.Visible = false;
            buttonThem.Enabled = buttonXoa.Enabled = buttonDMK.Enabled = true;
            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void ButtonXoa_Click(object? s, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            string user = textBox1.Text.Trim();

            if (MessageBox.Show($"Xoá tài khoản \"{user}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            bool ok = db.Delete<TaiKhoan>(user);

            if (ok)
            {
                MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không xóa được tài khoản. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrid();
        }


        private void ToggleEdit(bool enable)
        {
            dataGridView.Enabled = !enable;
            textBox1.Enabled = (mode == Mode.Add);
            textBox2.Enabled = enable;
            textBox3.Enabled = (mode == Mode.Add);
            comboBoxGV.Enabled = (mode == Mode.Add);
            buttonXN.Visible = enable;
            buttonHuy.Visible = enable;
            buttonThem.Visible = !enable;
            buttonXoa.Visible = !enable;
            buttonDMK.Visible = !enable;
        }

        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void buttonXN_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (mode == Mode.Add)
            {
                if (db.Exist<TaiKhoan>(textBox1.Text))
                {
                    MessageBox.Show("Username đã tồn tại!");
                    return;
                }
                var tk = new TaiKhoan
                {
                    Username = textBox1.Text.Trim(),
                    Password = textBox2.Text.Trim(),
                    Role = textBox3.Text.Trim(),
                    MaGV = comboBoxGV.SelectedValue?.ToString(),
                    MaKhoa = null
                };
                ok = db.Insert<TaiKhoan>(tk);
            }
            else if (mode == Mode.ChangePass)
            {
                ok = db.UpdatePassword(textBox1.Text.Trim(), textBox2.Text.Trim());
            }

            MessageBox.Show(ok ? "Thành công" : "Không thành công");
            buttonHuy_Click(null!, EventArgs.Empty);
            LoadGrid();
        }
    }
}
