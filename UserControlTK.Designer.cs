namespace BTL
{
    partial class UserControlTK
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
            panel1 = new Panel();
            buttonXoa = new Button();
            buttonThem = new Button();
            label4 = new Label();
            textBoxSearch = new TextBox();
            label2 = new Label();
            dataGridView = new DataGridView();
            panel2 = new Panel();
            buttonXN = new Button();
            buttonHuy = new Button();
            buttonDMK = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBoxGV = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(buttonXoa);
            panel1.Controls.Add(buttonThem);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxSearch);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1344, 400);
            panel1.TabIndex = 6;
            // 
            // buttonXoa
            // 
            buttonXoa.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXoa.Location = new Point(1169, 10);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(75, 30);
            buttonXoa.TabIndex = 7;
            buttonXoa.Text = "XÓA";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += ButtonXoa_Click;
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
            label4.Size = new Size(194, 21);
            label4.TabIndex = 5;
            label4.Text = "DANH SÁCH TÀI KHOẢN";
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
            panel2.Controls.Add(buttonXN);
            panel2.Controls.Add(buttonHuy);
            panel2.Controls.Add(buttonDMK);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Location = new Point(20, 440);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 401);
            panel2.TabIndex = 7;
            // 
            // buttonXN
            // 
            buttonXN.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXN.Location = new Point(625, 265);
            buttonXN.Name = "buttonXN";
            buttonXN.Size = new Size(120, 30);
            buttonXN.TabIndex = 9;
            buttonXN.Text = "XÁC NHẬN";
            buttonXN.UseVisualStyleBackColor = true;
            buttonXN.Visible = false;
            buttonXN.Click += buttonXN_Click;
            // 
            // buttonHuy
            // 
            buttonHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonHuy.Location = new Point(544, 265);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(75, 30);
            buttonHuy.TabIndex = 8;
            buttonHuy.Text = "HỦY";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Visible = false;
            buttonHuy.Click += buttonHuy_Click;
            // 
            // buttonDMK
            // 
            buttonDMK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDMK.Location = new Point(595, 265);
            buttonDMK.Name = "buttonDMK";
            buttonDMK.Size = new Size(150, 30);
            buttonDMK.TabIndex = 7;
            buttonDMK.Text = "ĐỔI MẬT KHẨU";
            buttonDMK.UseVisualStyleBackColor = true;
            buttonDMK.Click += buttonDMK_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.0132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.9868F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox3, 1, 2);
            tableLayoutPanel1.Controls.Add(comboBoxGV, 1, 3);
            tableLayoutPanel1.Location = new Point(445, 30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(413, 229);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 57);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 114);
            label5.Name = "label5";
            label5.Size = new Size(59, 21);
            label5.TabIndex = 2;
            label5.Text = "Quyền:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 171);
            label6.Name = "label6";
            label6.Size = new Size(87, 21);
            label6.TabIndex = 3;
            label6.Text = "Giảng viên:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Enabled = false;
            textBox1.Location = new Point(135, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(275, 29);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Enabled = false;
            textBox2.Location = new Point(135, 60);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(275, 29);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Enabled = false;
            textBox3.Location = new Point(135, 117);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(275, 29);
            textBox3.TabIndex = 6;
            // 
            // comboBoxGV
            // 
            comboBoxGV.Dock = DockStyle.Fill;
            comboBoxGV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGV.Enabled = false;
            comboBoxGV.FormattingEnabled = true;
            comboBoxGV.Location = new Point(135, 174);
            comboBoxGV.Name = "comboBoxGV";
            comboBoxGV.Size = new Size(275, 29);
            comboBoxGV.TabIndex = 7;
            // 
            // UserControlTK
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlTK";
            Size = new Size(1384, 861);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonXoa;
        private Button buttonThem;
        private Label label4;
        private TextBox textBoxSearch;
        private Label label2;
        public DataGridView dataGridView;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label3;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button buttonXN;
        private Button buttonHuy;
        private Button buttonDMK;
        private ComboBox comboBoxGV;
    }
}
