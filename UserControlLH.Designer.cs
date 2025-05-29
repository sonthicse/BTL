namespace BTL
{
    partial class UserControlLH
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
            panel2 = new Panel();
            buttonMH = new Button();
            label6 = new Label();
            dataGridViewMH = new DataGridView();
            label3 = new Label();
            dataGridViewSV = new DataGridView();
            buttonXoa = new Button();
            buttonHuy = new Button();
            buttonSua = new Button();
            buttonXacNhan = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            label5 = new Label();
            textBoxMaLop = new TextBox();
            textBoxTenLop = new TextBox();
            dataGridView = new DataGridView();
            label2 = new Label();
            textBoxSearch = new TextBox();
            label4 = new Label();
            buttonThem = new Button();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSV).BeginInit();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(buttonMH);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dataGridViewMH);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dataGridViewSV);
            panel2.Controls.Add(buttonXoa);
            panel2.Controls.Add(buttonHuy);
            panel2.Controls.Add(buttonSua);
            panel2.Controls.Add(buttonXacNhan);
            panel2.Controls.Add(tableLayoutPanel);
            panel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(20, 440);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 401);
            panel2.TabIndex = 4;
            // 
            // buttonMH
            // 
            buttonMH.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonMH.Location = new Point(1250, 15);
            buttonMH.Name = "buttonMH";
            buttonMH.Size = new Size(75, 30);
            buttonMH.TabIndex = 9;
            buttonMH.Text = "THÊM";
            buttonMH.UseVisualStyleBackColor = true;
            buttonMH.Click += buttonMH_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(924, 20);
            label6.Name = "label6";
            label6.Size = new Size(221, 21);
            label6.TabIndex = 8;
            label6.Text = "DANH SÁCH CÁC MÔN HỌC";
            // 
            // dataGridViewMH
            // 
            dataGridViewMH.AllowUserToAddRows = false;
            dataGridViewMH.AllowUserToDeleteRows = false;
            dataGridViewMH.AllowUserToResizeRows = false;
            dataGridViewMH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMH.Location = new Point(924, 58);
            dataGridViewMH.Name = "dataGridViewMH";
            dataGridViewMH.ReadOnly = true;
            dataGridViewMH.RowHeadersVisible = false;
            dataGridViewMH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMH.Size = new Size(400, 298);
            dataGridViewMH.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(496, 20);
            label3.Name = "label3";
            label3.Size = new Size(189, 21);
            label3.TabIndex = 6;
            label3.Text = "DANH SÁCH SINH VIÊN";
            // 
            // dataGridViewSV
            // 
            dataGridViewSV.AllowUserToAddRows = false;
            dataGridViewSV.AllowUserToDeleteRows = false;
            dataGridViewSV.AllowUserToResizeRows = false;
            dataGridViewSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSV.Location = new Point(496, 58);
            dataGridViewSV.Name = "dataGridViewSV";
            dataGridViewSV.ReadOnly = true;
            dataGridViewSV.RowHeadersVisible = false;
            dataGridViewSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSV.Size = new Size(400, 298);
            dataGridViewSV.TabIndex = 5;
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
            tableLayoutPanel.Controls.Add(textBoxMaLop, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxTenLop, 1, 1);
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
            label1.Size = new Size(66, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã Lớp:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(3, 75);
            label5.Name = "label5";
            label5.Size = new Size(40, 21);
            label5.TabIndex = 3;
            label5.Text = "Lớp:";
            // 
            // textBoxMaLop
            // 
            textBoxMaLop.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaLop.Dock = DockStyle.Fill;
            textBoxMaLop.Enabled = false;
            textBoxMaLop.Font = new Font("Segoe UI", 12F);
            textBoxMaLop.Location = new Point(133, 3);
            textBoxMaLop.Name = "textBoxMaLop";
            textBoxMaLop.Size = new Size(314, 29);
            textBoxMaLop.TabIndex = 12;
            // 
            // textBoxTenLop
            // 
            textBoxTenLop.BorderStyle = BorderStyle.FixedSingle;
            textBoxTenLop.Dock = DockStyle.Fill;
            textBoxTenLop.Enabled = false;
            textBoxTenLop.Font = new Font("Segoe UI", 12F);
            textBoxTenLop.Location = new Point(133, 78);
            textBoxTenLop.Name = "textBoxTenLop";
            textBoxTenLop.Size = new Size(314, 29);
            textBoxTenLop.TabIndex = 13;
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
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 12F);
            textBoxSearch.Location = new Point(40, 80);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(230, 29);
            textBoxSearch.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 19);
            label4.Name = "label4";
            label4.Size = new Size(176, 21);
            label4.TabIndex = 5;
            label4.Text = "DANH SÁCH LỚP HỌC";
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
            panel1.TabIndex = 3;
            // 
            // UserControlLH
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlLH";
            Size = new Size(1384, 861);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMH).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSV).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void ButtonHuy_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Panel panel2;
        private Label label3;
        private DataGridView dataGridViewSV;
        private Button buttonXoa;
        private Button buttonHuy;
        private Button buttonSua;
        private Button buttonXacNhan;
        private TableLayoutPanel tableLayoutPanel;
        private Label label1;
        private Label label5;
        private TextBox textBoxMaLop;
        private TextBox textBoxTenLop;
        private Label label6;
        private DataGridView dataGridViewMH;
        private Button buttonMH;
        public DataGridView dataGridView;
        private Label label2;
        private TextBox textBoxSearch;
        private Label label4;
        private Button buttonThem;
        private Panel panel1;
    }
}
