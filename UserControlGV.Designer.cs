namespace BTL
{
    partial class UserControlGV
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            buttonThem = new Button();
            label4 = new Label();
            textBoxSearch = new TextBox();
            label2 = new Label();
            dataGridView = new DataGridView();
            panel2 = new Panel();
            label3 = new Label();
            dataGridViewLH = new DataGridView();
            buttonXoa = new Button();
            buttonHuy = new Button();
            buttonSua = new Button();
            buttonXacNhan = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            label5 = new Label();
            label8 = new Label();
            label11 = new Label();
            textBoxMaGV = new TextBox();
            textBoxTenGV = new TextBox();
            comboBoxKhoa = new ComboBox();
            comboBoxMH = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLH).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(buttonThem);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxSearch);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1344, 400);
            panel1.TabIndex = 2;
            // 
            // buttonThem
            // 
            buttonThem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonThem.Location = new Point(1250, 10);
            buttonThem.Name = "buttonThem";
            buttonThem.Size = new Size(75, 30);
            buttonThem.TabIndex = 6;
            buttonThem.Text = "THÊM";
            buttonThem.UseVisualStyleBackColor = true;
            buttonThem.Click += buttonThem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 19);
            label4.Name = "label4";
            label4.Size = new Size(201, 21);
            label4.TabIndex = 5;
            label4.Text = "DANH SÁCH GIẢNG VIÊN";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 12F);
            textBoxSearch.Location = new Point(40, 80);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(230, 29);
            textBoxSearch.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(40, 50);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 1;
            label2.Text = "Tìm kiếm:";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Location = new Point(300, 50);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1024, 330);
            dataGridView.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dataGridViewLH);
            panel2.Controls.Add(buttonXoa);
            panel2.Controls.Add(buttonHuy);
            panel2.Controls.Add(buttonSua);
            panel2.Controls.Add(buttonXacNhan);
            panel2.Controls.Add(tableLayoutPanel);
            panel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(20, 440);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 401);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(525, 20);
            label3.Name = "label3";
            label3.Size = new Size(210, 21);
            label3.TabIndex = 6;
            label3.Text = "DANH SÁCH CÁC LỚP DẠY";
            // 
            // dataGridViewLH
            // 
            dataGridViewLH.AllowUserToAddRows = false;
            dataGridViewLH.AllowUserToDeleteRows = false;
            dataGridViewLH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLH.Location = new Point(525, 58);
            dataGridViewLH.MultiSelect = false;
            dataGridViewLH.Name = "dataGridViewLH";
            dataGridViewLH.ReadOnly = true;
            dataGridViewLH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLH.Size = new Size(800, 298);
            dataGridViewLH.TabIndex = 5;
            // 
            // buttonXoa
            // 
            buttonXoa.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXoa.Location = new Point(154, 326);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(75, 30);
            buttonXoa.TabIndex = 1;
            buttonXoa.Text = "XÓA";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // buttonHuy
            // 
            buttonHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHuy.Location = new Point(154, 326);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(75, 30);
            buttonHuy.TabIndex = 4;
            buttonHuy.Text = "HỦY";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Visible = false;
            buttonHuy.Click += buttonHuy_Click;
            // 
            // buttonSua
            // 
            buttonSua.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonSua.Location = new Point(370, 326);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(100, 30);
            buttonSua.TabIndex = 2;
            buttonSua.Text = "SỬA";
            buttonSua.UseVisualStyleBackColor = true;
            buttonSua.Click += buttonSua_Click;
            // 
            // buttonXacNhan
            // 
            buttonXacNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXacNhan.Location = new Point(350, 326);
            buttonXacNhan.Name = "buttonXacNhan";
            buttonXacNhan.Size = new Size(120, 30);
            buttonXacNhan.TabIndex = 3;
            buttonXacNhan.Text = "XÁC NHẬN";
            buttonXacNhan.UseVisualStyleBackColor = true;
            buttonXacNhan.Visible = false;
            buttonXacNhan.Click += buttonXacNhan_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel.Controls.Add(label1, 0, 0);
            tableLayoutPanel.Controls.Add(label5, 0, 1);
            tableLayoutPanel.Controls.Add(label8, 0, 2);
            tableLayoutPanel.Controls.Add(label11, 0, 3);
            tableLayoutPanel.Controls.Add(textBoxMaGV, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxTenGV, 1, 1);
            tableLayoutPanel.Controls.Add(comboBoxKhoa, 1, 2);
            tableLayoutPanel.Controls.Add(comboBoxMH, 1, 3);
            tableLayoutPanel.Location = new Point(20, 20);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9999962F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9999962F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(450, 300);
            tableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã Giảng viên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(3, 75);
            label5.Name = "label5";
            label5.Size = new Size(79, 21);
            label5.TabIndex = 3;
            label5.Text = "Họ và tên:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(3, 149);
            label8.Name = "label8";
            label8.Size = new Size(48, 21);
            label8.TabIndex = 6;
            label8.Text = "Khoa:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(3, 223);
            label11.Name = "label11";
            label11.Size = new Size(74, 21);
            label11.TabIndex = 9;
            label11.Text = "Môn học:";
            // 
            // textBoxMaGV
            // 
            textBoxMaGV.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaGV.Dock = DockStyle.Fill;
            textBoxMaGV.Enabled = false;
            textBoxMaGV.Font = new Font("Segoe UI", 12F);
            textBoxMaGV.Location = new Point(133, 3);
            textBoxMaGV.Name = "textBoxMaGV";
            textBoxMaGV.Size = new Size(314, 29);
            textBoxMaGV.TabIndex = 12;
            // 
            // textBoxTenGV
            // 
            textBoxTenGV.BorderStyle = BorderStyle.FixedSingle;
            textBoxTenGV.Dock = DockStyle.Fill;
            textBoxTenGV.Enabled = false;
            textBoxTenGV.Font = new Font("Segoe UI", 12F);
            textBoxTenGV.Location = new Point(133, 78);
            textBoxTenGV.Name = "textBoxTenGV";
            textBoxTenGV.Size = new Size(314, 29);
            textBoxTenGV.TabIndex = 13;
            // 
            // comboBoxKhoa
            // 
            comboBoxKhoa.Dock = DockStyle.Fill;
            comboBoxKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKhoa.Enabled = false;
            comboBoxKhoa.FormattingEnabled = true;
            comboBoxKhoa.Location = new Point(133, 152);
            comboBoxKhoa.Name = "comboBoxKhoa";
            comboBoxKhoa.Size = new Size(314, 29);
            comboBoxKhoa.TabIndex = 14;
            // 
            // comboBoxMH
            // 
            comboBoxMH.Dock = DockStyle.Fill;
            comboBoxMH.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMH.Enabled = false;
            comboBoxMH.FormattingEnabled = true;
            comboBoxMH.Location = new Point(133, 226);
            comboBoxMH.Name = "comboBoxMH";
            comboBoxMH.Size = new Size(314, 29);
            comboBoxMH.TabIndex = 15;
            // 
            // UserControlGV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlGV";
            Size = new Size(1384, 861);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLH).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonThem;
        private Label label4;
        private TextBox textBoxSearch;
        private Label label2;
        public DataGridView dataGridView;
        private Panel panel2;
        private Button buttonXoa;
        private Button buttonHuy;
        private Button buttonSua;
        private Button buttonXacNhan;
        private TableLayoutPanel tableLayoutPanel;
        private Label label1;
        private Label label5;
        private Label label8;
        private Label label11;
        private TextBox textBoxMaGV;
        private TextBox textBoxTenGV;
        private ComboBox comboBoxKhoa;
        private ComboBox comboBoxMH;
        private Label label3;
        private DataGridView dataGridViewLH;
    }
}
