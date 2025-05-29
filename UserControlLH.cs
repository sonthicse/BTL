using System.Data;

namespace BTL
{
    public partial class UserControlLH : UserControl
    {
        private readonly Database _db = new();
        private DataTable _dtLop;
        private DataView _viewLop;
        private enum Mode { View, Add, Edit }
        private Mode _mode = Mode.View;

        public UserControlLH()
        {
            InitializeComponent();
            Load += UserControlLH_Load;
        }

        public void UserControlLH_Load(object? sender, EventArgs e)
        {
            _dtLop = _db.GetAll<Lop>();
            _viewLop = _dtLop.DefaultView;
            dataGridView.DataSource = _viewLop;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            if (dataGridView.Columns.Contains("MaLop"))
                dataGridView.Columns["MaLop"].HeaderText = "Mã lớp";
            if (dataGridView.Columns.Contains("TenLop"))
                dataGridView.Columns["TenLop"].HeaderText = "Tên lớp";
            if (dataGridView.Columns.Contains("TenKhoa"))
                dataGridView.Columns["TenKhoa"].HeaderText = "Khoa";

            if (dataGridView.Columns.Contains("MaKhoa"))
                dataGridView.Columns["MaKhoa"].Visible = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["MaLop"].FillWeight = 30;
            dataGridView.Columns["TenLop"].FillWeight = 70;

            textBoxSearch.TextChanged += buttonSearch_Click;

            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null, EventArgs.Empty);
        }

        private void DataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            DataRow row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;
            textBoxMaLop.Text = row["MaLop"].ToString();
            textBoxTenLop.Text = row["TenLop"].ToString();
            string maLop = row["MaLop"].ToString();
            dataGridViewSV.DataSource = _db.GetSinhVienByLop(maLop);
            dataGridViewSV.Columns["MaSV"].HeaderText = "Mã sinh viên";
            dataGridViewSV.Columns["TenSV"].HeaderText = "Họ và tên";
            dataGridViewSV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridViewSV.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridViewSV.Columns["NgaySinh"].Visible = false;
            dataGridViewSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewMH.DataSource = _db.GetMonByLop(maLop);
            dataGridViewMH.Columns["MaMH"].HeaderText = "Mã môn học";
            dataGridViewMH.Columns["TenMH"].HeaderText = "Tên môn học";
            dataGridViewMH.Columns["TenGV"].HeaderText = "Giảng viên";
            dataGridViewMH.Columns["MaGV"].Visible = false;
            dataGridViewMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            _viewLop.RowFilter = string.IsNullOrEmpty(kw) ? string.Empty : $"MaLop LIKE '%{kw}%' OR TenLop LIKE '%{kw}%'";
        }

        private void buttonThem_Click(object? sender, EventArgs e)
        {
            _mode = Mode.Add;
            ClearInput();
            ToggleEdit(true);
        }

        private void buttonSua_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            _mode = Mode.Edit;
            ToggleEdit(true);
        }

        private void buttonHuy_Click(object? sender, EventArgs e)
        {
            _mode = Mode.View;
            ToggleEdit(false);
            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void buttonXacNhan_Click(object? sender, EventArgs e)
        {
            Lop lp = new()
            {
                MaLop = textBoxMaLop.Text.Trim(),
                TenLop = textBoxTenLop.Text.Trim()
            };
            bool ok = false;
            if (_mode == Mode.Add)
            {
                if (_db.Exist<Lop>(lp.MaLop))
                {
                    MessageBox.Show("Mã lớp đã tồn tại!");
                    textBoxMaLop.Focus();
                    return;
                }
                ok = _db.Insert<Lop>(lp);
            }
            else if (_mode == Mode.Edit)
            {
                ok = _db.Update<Lop>(lp);
            }
            MessageBox.Show(ok ? "Lưu thành công" : "Thao tác thất bại!");
            RefreshGrid();
            buttonHuy_Click(null!, EventArgs.Empty);
        }

        private void buttonXoa_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string ma = textBoxMaLop.Text;
            if (MessageBox.Show($"Xoá lớp {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _db.Delete<Lop>(ma);
                RefreshGrid();
            }
        }

        private void buttonMH_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string maLop = textBoxMaLop.Text;
            using FormThemMH f = new(_db, maLop);
            if (f.ShowDialog() == DialogResult.OK)
                dataGridViewMH.DataSource = _db.GetMonByLop(maLop);
        }

        private void RefreshGrid()
        {
            string filter = _viewLop.RowFilter;
            _dtLop = _db.GetAll<Lop>();
            _viewLop = new DataView(_dtLop) { RowFilter = filter };
            dataGridView.DataSource = _viewLop;
        }

        private void ClearInput()
        {
            textBoxMaLop.Clear();
            textBoxTenLop.Clear();
        }

        private void ToggleEdit(bool enable)
        {
            dataGridView.Enabled = !enable;
            dataGridViewMH.Enabled = !enable;
            dataGridViewSV.Enabled = !enable;
            textBoxTenLop.Enabled = enable;
            textBoxMaLop.Enabled = (_mode == Mode.Add);
            buttonXacNhan.Visible = buttonHuy.Visible = enable;
            buttonThem.Visible = buttonSua.Visible = buttonXoa.Visible = !enable;
        }
    }
}
