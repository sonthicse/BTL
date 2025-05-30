﻿using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace BTL
{
    public partial class UserControlMH : UserControl
    {
        private readonly Database db = new();
        private DataTable dtMH;
        private DataView viewMH;
        private enum Mode { View, Add, Edit }
        private Mode mode = Mode.View;

        public UserControlMH()
        {
            InitializeComponent();
            Load += UserControlMH_Load;
        }

        public void UserControlMH_Load(object? sender, EventArgs e)
        {
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "MaKhoa";
            comboBoxKhoa.DataSource = db.GetAll<Khoa>();

            dtMH = db.GetAll<MonHoc>();
            viewMH = dtMH.DefaultView;
            dataGridView.DataSource = viewMH;
            dataGridView.Columns["MaMH"].HeaderText = "Mã môn học";
            dataGridView.Columns["TenMH"].HeaderText = "Tên môn học";
            dataGridView.Columns["TinChi"].HeaderText = "Tín chỉ";
            dataGridView.Columns["TenKhoa"].HeaderText = "Khoa";
            if (dataGridView.Columns.Contains("MaKhoa"))
                dataGridView.Columns["MaKhoa"].Visible = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["MaMH"].FillWeight = 15;
            dataGridView.Columns["TenMH"].FillWeight = 45;
            dataGridView.Columns["TinChi"].FillWeight = 20;
            dataGridView.Columns["TenKhoa"].FillWeight = 20;

            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            dataGridView.CurrentCellChanged += DataGridView_SelectionChanged;
            dataGridView.RowEnter += DataGridView_SelectionChanged;

            textBoxSearch.TextChanged += buttonSearch_Click;

            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
                return;

            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row;

            textBoxMaMH.Text = row["MaMH"].ToString();
            textBoxTenMH.Text = row["TenMH"].ToString();
            textBoxTC.Text = row["TinChi"].ToString();
            comboBoxKhoa.SelectedValue = row["MaKhoa"]?.ToString() ?? string.Empty;

            var dt = db.GetGiangVienByMon(row["MaMH"].ToString());

            dataGridViewGV.SuspendLayout();
            dataGridViewGV.Columns.Clear();
            dataGridViewGV.AutoGenerateColumns = true;
            dataGridViewGV.DataSource = dt;
            dataGridViewGV.ResumeLayout();
            dataGridViewGV.Refresh();

            if (dataGridViewGV.Columns.Contains("MaGV"))
                dataGridViewGV.Columns["MaGV"].HeaderText = "Mã giảng viên";
            if (dataGridViewGV.Columns.Contains("TenGV"))
                dataGridViewGV.Columns["TenGV"].HeaderText = "Họ và tên";

            dataGridViewGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridViewGV.Columns.Contains("MaGV"))
                dataGridViewGV.Columns["MaGV"].FillWeight = 10;
            if (dataGridViewGV.Columns.Contains("TenGV"))
                dataGridViewGV.Columns["TenGV"].FillWeight = 40;
        }

        private void buttonSearch_Click(object? s, EventArgs e)
        {
            string kw = textBoxSearch.Text.Replace("'", "''").Trim();
            viewMH.RowFilter = string.IsNullOrEmpty(kw) ? string.Empty : $"MaMH LIKE '%{kw}%' OR TenMH LIKE '%{kw}%'";
        }

        private void ToggleEdit(bool editing)
        {
            textBoxTenMH.Enabled = textBoxTC.Enabled = editing;
            textBoxMaMH.Enabled = comboBoxKhoa.Enabled = (mode == Mode.Add);
            buttonXacNhan.Visible = buttonHuy.Visible = editing;
            buttonThem.Visible = buttonSua.Visible = buttonXoa.Visible = !editing;
            dataGridView.Enabled = !editing;
            dataGridViewGV.Enabled = !editing;
        }

        private void ClearInput()
        {
            textBoxMaMH.Clear();
            textBoxTenMH.Clear();
            textBoxTC.Clear();
            comboBoxKhoa.SelectedIndex = 0;
        }

        private void buttonThem_Click(object? s, EventArgs e)
        {
            mode = Mode.Add;
            ClearInput();
            ToggleEdit(true);
        }

        private void buttonSua_Click(object? s, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            mode = Mode.Edit;
            ToggleEdit(true);
        }

        private void buttonHuy_Click(object? s, EventArgs e)
        {
            mode = Mode.View;
            ToggleEdit(false);
            DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }

        private void buttonXoa_Click(object? s, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string ma = textBoxMaMH.Text;
            if (MessageBox.Show($"Xoá môn {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.Delete<MonHoc>(ma);
                LoadGrid();
            }
        }

        private void buttonXacNhan_Click(object? s, EventArgs e)
        {
            var mh = new MonHoc
            {
                MaMH = textBoxMaMH.Text.Trim(),
                TenMH = textBoxTenMH.Text.Trim(),
                TinChi = int.TryParse(textBoxTC.Text, out var tc) ? tc : 0,
                MaKhoa = comboBoxKhoa.SelectedValue?.ToString()
            };
            if (mode == Mode.Add)
            {
                if (db.Exist<MonHoc>(mh.MaMH))
                {
                    MessageBox.Show("Mã MH trùng!");
                    return;
                }
                db.Insert<MonHoc>(mh);
            }
            else if (mode == Mode.Edit)
            {
                db.Update<MonHoc>(mh);
            }
            buttonHuy_Click(null!, EventArgs.Empty);
            LoadGrid();
        }

        private void LoadGrid()
        {
            string filter = viewMH.RowFilter;
            dtMH = db.GetAll<MonHoc>();
            viewMH = new DataView(dtMH) { RowFilter = filter };
            dataGridView.DataSource = viewMH;
            if (dataGridView.Rows.Count > 0)
                DataGridView_SelectionChanged(null!, EventArgs.Empty);
        }
    }
}
