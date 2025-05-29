using System;
using System.Data;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlKhoa : UserControl
    {
        private readonly Database db = new();
        private DataTable dt;
        private DataView view;
        private enum Mode { View, Add, Edit }
        private Mode mode = Mode.View;

        public UserControlKhoa()
        {
            InitializeComponent();
            Load += UserControlKhoa_Load;
        }

        public void UserControlKhoa_Load(object? sender, EventArgs e)
        {
            dt = db.GetAll<Khoa>();
            view = dt.DefaultView;
            dataGridView.DataSource = view;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView.Columns.Contains("MaKhoa"))
                dataGridView.Columns["MaKhoa"].HeaderText = "Mã khoa";
            if (dataGridView.Columns.Contains("TenKhoa"))
                dataGridView.Columns["TenKhoa"].HeaderText = "Tên khoa";

            dataGridView.Columns["MaKhoa"].FillWeight = 30;
            dataGridView.Columns["TenKhoa"].FillWeight = 70;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            textBoxSearch.TextChanged += Search;

            buttonThem.Click += BtnThem_Click;
            buttonXoa.Click += BtnXoa_Click;
            buttonXN.Click += BtnXN_Click;
            buttonHuy.Click += BtnHuy_Click;

            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void DataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;
            textBox1.Text = row["MaKhoa"].ToString();
            textBox2.Text = row["TenKhoa"].ToString();
        }

        private void Search(object? sender, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            view.RowFilter = string.IsNullOrEmpty(kw) ? "" : $"MaKhoa LIKE '%{kw}%' OR TenKhoa LIKE '%{kw}%'";
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            mode = Mode.Add;
            ToggleEdit(true);
            ClearInput();
        }

        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            mode = Mode.View;
            ToggleEdit(false);
            if (dataGridView.CurrentRow != null)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void BtnXN_Click(object? sender, EventArgs e)
        {
            var k = new Khoa { MaKhoa = textBox1.Text.Trim(), TenKhoa = textBox2.Text.Trim() };
            bool ok = false;
            if (mode == Mode.Add)
            {
                if (db.Exist<Khoa>(k.MaKhoa))
                {
                    MessageBox.Show("Mã khoa đã tồn tại");
                    return;
                }
                ok = db.Insert<Khoa>(k);
            }
            else if (mode == Mode.Edit)
            {
                ok = db.Update<Khoa>(k);
            }
            MessageBox.Show(ok ? "Lưu thành công" : "Không thành công");
            BtnHuy_Click(null!, EventArgs.Empty);
            LoadData();
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string ma = textBox1.Text;
            if (MessageBox.Show($"Xoá khoa {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.Delete<Khoa>(ma);
                LoadData();
            }
        }

        private void ToggleEdit(bool enable)
        {
            dataGridView.Enabled = !enable;
            textBox1.Enabled = textBox2.Enabled = (mode == Mode.Add);
            buttonXN.Visible = buttonHuy.Visible = enable;
            buttonThem.Visible = buttonXoa.Visible = !enable;
        }

        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void LoadData()
        {
            string filter = view?.RowFilter ?? "";
            dt = db.GetAll<Khoa>();
            view = new DataView(dt) { RowFilter = filter };
            dataGridView.DataSource = view;
        }
    }
}
