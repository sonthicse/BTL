using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL
{
    public partial class UserControlDiem : UserControl
    {
        private readonly Database db = new();
        private DataTable dtSV = new();
        private DataView viewSV;

        public string maGV = "";

        private readonly Dictionary<string, string> lop_maMH = new();

        public UserControlDiem()
        {
            InitializeComponent();
            Load += UC_Load;
        }

        private void UC_Load(object? sender, EventArgs e)
        {
            var dtLop = db.GetLopByGiangVien(maGV);
            comboBoxLop.DisplayMember = "TenLop";
            comboBoxLop.ValueMember = "MaLop";
            comboBoxLop.DataSource = dtLop;
            foreach (DataRow r in dtLop.Rows)
                lop_maMH[r["MaLop"].ToString()] = r["MaMH"].ToString();
            comboBoxLop.SelectedIndexChanged += comboBoxLop_SelectedIndexChanged;

            foreach (var tb in new[] { textBoxDiemCC, textBoxDiemTX, textBoxDiemTHI })
            {
                tb.KeyPress += OnlyNumber_KeyPress;
                tb.Leave += Diem_Leave;
            }

            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            textBoxSearch.TextChanged += buttonSearch_Click;

            if (comboBoxLop.Items.Count > 0)
                comboBoxLop_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private static float Round05(float x) =>
            (float)(Math.Round(x * 2, MidpointRounding.AwayFromZero) / 2.0);

        private void Diem_Leave(object? sender, EventArgs e)
        {
            var tb = (System.Windows.Forms.TextBox) sender!;
            if (float.TryParse(tb.Text, out var v))
                tb.Text = Round05(v).ToString("0.0");
        }

        private void OnlyNumber_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            var tb = (System.Windows.Forms.TextBox) sender!;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !tb.Text.Contains('.')) return;
            e.Handled = true;
        }

        private void comboBoxLop_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxLop.SelectedValue == null) return;
            string maLop = comboBoxLop.SelectedValue.ToString();
            string maMH = lop_maMH[maLop];
            dtSV = db.GetSV_Diem_ByLop(maLop, maMH);
            viewSV = dtSV.DefaultView;
            dataGridView.DataSource = viewSV;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.Columns["MaSV"].HeaderText = "Mã SV";
            dataGridView.Columns["MaSV"].FillWeight = 10;
            dataGridView.Columns["TenSV"].HeaderText = "Họ và Tên";
            dataGridView.Columns["TenSV"].FillWeight = 25;   
            dataGridView.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView.Columns["DiaChi"].FillWeight = 25;   
            dataGridView.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dataGridView.Columns["NgaySinh"].FillWeight = 10;   
            dataGridView.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dataGridView.Columns["GioiTinh"].FillWeight = 10;   
            dataGridView.Columns["DiemCC"].HeaderText = "Điểm CC";
            dataGridView.Columns["DiemCC"].FillWeight = 5;   
            dataGridView.Columns["DiemTX"].HeaderText = "Điểm TX";
            dataGridView.Columns["DiemTX"].FillWeight = 5;   
            dataGridView.Columns["DiemTHI"].HeaderText = "Điểm Thi";
            dataGridView.Columns["DiemTHI"].FillWeight = 5;   
            dataGridView.Columns["DiemHP"].HeaderText = "Điểm HP";
            dataGridView.Columns["DiemHP"].FillWeight = 5;   

            if (dataGridView.Rows.Count > 0)
                dataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void dataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var r = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;
            textBoxMaSV.Text = r["MaSV"].ToString();
            textBoxTenSV.Text = r["TenSV"].ToString();
            textBoxDiaChi.Text = r["DiaChi"].ToString();
            dateTimePickerNgaySinh.Value = DateTime.TryParse(r["NgaySinh"].ToString(), out var d) ? d : DateTime.Today;
            var gt = r["GioiTinh"].ToString().Trim().ToLower();
            radioButtonNam.Checked = gt == "nam";
            radioButtonNu.Checked = !radioButtonNam.Checked;
            textBoxDiemCC.Text = r["DiemCC"]?.ToString();
            textBoxDiemTX.Text = r["DiemTX"]?.ToString();
            textBoxDiemTHI.Text = r["DiemTHI"]?.ToString();
            textBoxDiemHP.Text = r["DiemHP"]?.ToString();
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            viewSV.RowFilter = string.IsNullOrEmpty(kw)? "": $"MaSV LIKE '%{kw}%' OR TenSV LIKE '%{kw}%'";
        }

        private void ToggleEdit(bool enable)
        {
            textBoxDiemCC.Enabled = textBoxDiemTX.Enabled = textBoxDiemTHI.Enabled = enable;
            dataGridView.Enabled = !enable;
            buttonHuy.Visible = buttonXacNhan.Visible = enable;
            buttonSua.Visible = !enable;
        }

        private void buttonSua_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            ToggleEdit(true);
        }

        private void buttonHuy_Click(object? sender, EventArgs e)
        {
            ToggleEdit(false);
            dataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            var maSV = textBoxMaSV.Text.Trim();
            var maMH = lop_maMH[comboBoxLop.SelectedValue.ToString()];

            if (!float.TryParse(textBoxDiemCC.Text, out float diemCC) ||
                !float.TryParse(textBoxDiemTX.Text, out float diemTX) ||
                !float.TryParse(textBoxDiemTHI.Text, out float diemTHI))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho tất cả các ô điểm.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;     
            }

            float diemHP = (float)Math.Round((diemCC * 0.1f) + (diemTX * 0.3f) + (diemTHI * 0.6f), 1);         
            textBoxDiemHP.Text = diemHP.ToString("0.0");

            var d = new Diem
            {
                MaSV = maSV,
                MaMH = maMH,
                DiemCC = diemCC,
                DiemTX = diemTX,
                DiemTHI = diemTHI,
                DiemHP = diemHP
            };

            bool existed = db.Exist<Diem>(d.MaSV, d.MaMH);
            bool ok = existed ? db.UpdateDiem(d) : db.Insert<Diem>(d); 
            MessageBox.Show(ok ? "Lưu điểm thành công!" : "Lỗi khi lưu điểm.", "Thông báo", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            comboBoxLop_SelectedIndexChanged(this, EventArgs.Empty);
            ToggleEdit(false);
        }
    }
}
