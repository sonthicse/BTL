namespace BTL
{
    partial class UserControlKhoa
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            panel2 = new Panel();
            buttonXN = new Button();
            buttonHuy = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.TabIndex = 5;
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
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 19);
            label4.Name = "label4";
            label4.Size = new Size(153, 21);
            label4.TabIndex = 5;
            label4.Text = "DANH SÁCH KHOA";
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.6208534F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.37915F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
            tableLayoutPanel1.Location = new Point(434, 86);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(422, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã Khoa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 50);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 1;
            label3.Text = "Khoa:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Enabled = false;
            textBox1.Location = new Point(128, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(291, 29);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Enabled = false;
            textBox2.Location = new Point(128, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(291, 29);
            textBox2.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(buttonXN);
            panel2.Controls.Add(buttonHuy);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Location = new Point(20, 440);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 401);
            panel2.TabIndex = 6;
            // 
            // buttonXN
            // 
            buttonXN.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXN.Location = new Point(619, 217);
            buttonXN.Name = "buttonXN";
            buttonXN.Size = new Size(120, 30);
            buttonXN.TabIndex = 8;
            buttonXN.Text = "XÁC NHẬN";
            buttonXN.UseVisualStyleBackColor = true;
            buttonXN.Visible = false;
            // 
            // buttonHuy
            // 
            buttonHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonHuy.Location = new Point(538, 217);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(75, 30);
            buttonHuy.TabIndex = 7;
            buttonHuy.Text = "HỦY";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Visible = false;
            // 
            // UserControlKhoa
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlKhoa";
            Size = new Size(1384, 861);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonThem;
        private Label label4;
        private TextBox textBoxSearch;
        private Label label2;
        public DataGridView dataGridView;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel2;
        private Button buttonXoa;
        private Button buttonXN;
        private Button buttonHuy;
    }
}
