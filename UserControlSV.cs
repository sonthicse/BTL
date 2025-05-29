using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlSV : UserControl
    {
        private readonly Database _db = new();
        private DataTable _dtSinhVien = new();
        private DataView _viewSinhVien;
        private enum Mode { View, Add, Edit }
        private Mode _mode = Mode.View;

        public UserControlSV()
        {
            InitializeComponent();
            Load += UserControlSV_Load;
        }

        private void UserControlSV_Load(object? sender, EventArgs e)
        {
            comboBoxLop.DisplayMember = "TenLop";
            comboBoxLop.ValueMember = "MaLop";
            comboBoxLop.DataSource = _db.GetAll<Lop>();

            _dtSinhVien = _db.GetAll<SinhVien>();
            _viewSinhVien = _dtSinhVien.DefaultView;
            dataGridView.DataSource = _viewSinhVien;

            dataGridView.Columns["MaSV"].HeaderText = "Mã sinh viên";
            dataGridView.Columns["TenSV"].HeaderText = "Họ và tên";
            dataGridView.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridView.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView.Columns["LopHoc"].HeaderText = "Lớp học";

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridView.Columns["MaSV"].FillWeight = 10;    
            dataGridView.Columns["TenSV"].FillWeight = 30;   
            dataGridView.Columns["NgaySinh"].FillWeight = 15;   
            dataGridView.Columns["GioiTinh"].FillWeight = 10;   
            dataGridView.Columns["DiaChi"].FillWeight = 20;   
            dataGridView.Columns["LopHoc"].FillWeight = 15;    

            if (dataGridView.Columns.Contains("MaLop"))
                dataGridView.Columns["MaLop"].Visible = false;

            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            textBoxSearch.TextChanged += buttonSearch_Click;
            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void DataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            dataGridView.SelectionChanged -= DataGridView_SelectionChanged;

            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;
            textBoxMaSV.Text = row["MaSV"].ToString();
            textBoxTenSV.Text = row["TenSV"].ToString();
            textBoxDiaChi.Text = row["DiaChi"].ToString();
            dateTimePickerNgaySinh.Value = DateTime.TryParse(row["NgaySinh"].ToString(), out var d) ? d : DateTime.Today;
            var gt = row["GioiTinh"].ToString()?.Trim().ToLower();
            radioButtonNam.Checked = gt == "nam";
            radioButtonNu.Checked = !radioButtonNam.Checked;
            comboBoxLop.SelectedValue = row["MaLop"];

            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            if (string.IsNullOrEmpty(kw))
            {
                _viewSinhVien.RowFilter = "";    
            }
            else
            {
                _viewSinhVien.RowFilter =
                    $"MaSV LIKE '%{kw}%' OR TenSV LIKE '%{kw}%'";
            }
            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void ClearInput()
        {
            textBoxMaSV.Clear();
            textBoxTenSV.Clear();
            textBoxDiaChi.Clear();
            dateTimePickerNgaySinh.Value = DateTime.Today;
            radioButtonNam.Checked = true;
            comboBoxLop.SelectedIndex = 0;
        }

        private void ToggleEdit(bool enable)
        {
            dataGridView.Enabled = !enable;
            textBoxTenSV.Enabled = textBoxDiaChi.Enabled = dateTimePickerNgaySinh.Enabled = radioButtonNam.Enabled = radioButtonNu.Enabled = comboBoxLop.Enabled = enable;
            textBoxMaSV.Enabled = (_mode == Mode.Add);
            buttonHuy.Visible = buttonXacNhan.Visible = enable;
            buttonSua.Visible = buttonXoa.Visible = buttonThem.Visible = !enable;
        }

        private void buttonThem_Click(object? sender, EventArgs e)
        {
            _mode = Mode.Add;
            ClearInput();
            ToggleEdit(true);
            buttonXacNhan.Visible = buttonHuy.Visible = true;
            buttonSua.Visible = buttonXoa.Visible = false;
            buttonThem.Enabled = buttonSua.Enabled = buttonXoa.Enabled = false;
        }

        private void buttonSua_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            _mode = Mode.Edit;
            ToggleEdit(true);
            buttonXacNhan.Visible = buttonHuy.Visible = true;
            buttonSua.Visible = buttonXoa.Visible = false;
            dataGridView.Enabled = false;
            buttonThem.Enabled = buttonXoa.Enabled = buttonSua.Enabled = false;
        }

        private void buttonHuy_Click(object? sender, EventArgs e)
        {
            _mode = Mode.View;
            ToggleEdit(false);
            buttonXacNhan.Visible = buttonHuy.Visible = false;
            buttonSua.Visible = buttonXoa.Visible = true;
            buttonThem.Enabled = buttonSua.Enabled = buttonXoa.Enabled = true;
            dataGridView.Enabled = true;
            DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void buttonXacNhan_Click(object? sender, EventArgs e)
        {
            var sv = new SinhVien
            {
                MaSV = textBoxMaSV.Text.Trim(),
                TenSV = textBoxTenSV.Text.Trim(),
                NgaySinh = dateTimePickerNgaySinh.Value.ToString("yyyy-MM-dd"),
                GioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ",
                DiaChi = textBoxDiaChi.Text.Trim(),
                MaLop = comboBoxLop.SelectedValue?.ToString()
            };

            bool ok = false;
            if (_mode == Mode.Add)
            {
                if (_db.Exist<SinhVien>(sv.MaSV) || String.IsNullOrEmpty(textBoxMaSV.Text))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại, hãy nhập mã khác!",
                                    "Trùng khóa chính", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    textBoxMaSV.Focus();
                    return;
                }
                ok = _db.Insert<SinhVien>(sv);
            }
            else if (_mode == Mode.Edit)
            {
                ok = _db.Update<SinhVien>(sv);
            }
            MessageBox.Show(ok ? "Lưu thành công!" : "Thao tác thất bại!");
            buttonHuy_Click(null!, EventArgs.Empty);
            LoadGrid();
        }

        private void buttonXoa_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string ma = textBoxMaSV.Text;
            if (MessageBox.Show($"Xoá sinh viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _db.Delete<SinhVien>(ma);
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            string filter = _viewSinhVien?.RowFilter ?? "";
            _dtSinhVien = _db.GetAll<SinhVien>();
            _viewSinhVien = new DataView(_dtSinhVien) { RowFilter = filter };
            dataGridView.DataSource = _viewSinhVien;
        }
    }
}
