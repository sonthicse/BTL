namespace BTL
{
    partial class FormAdmin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            buttonDX = new Button();
            pictureBoxLogo = new PictureBox();
            tableLayoutPanelMenu = new TableLayoutPanel();
            buttonTC = new Button();
            buttonSV = new Button();
            buttonGV = new Button();
            buttonLH = new Button();
            buttonMH = new Button();
            buttonKhoa = new Button();
            buttonTK = new Button();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            tableLayoutPanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.MenuHighlight;
            panelMenu.Controls.Add(buttonDX);
            panelMenu.Controls.Add(pictureBoxLogo);
            panelMenu.Controls.Add(tableLayoutPanelMenu);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 861);
            panelMenu.TabIndex = 0;
            // 
            // buttonDX
            // 
            buttonDX.Dock = DockStyle.Bottom;
            buttonDX.FlatAppearance.BorderSize = 0;
            buttonDX.FlatStyle = FlatStyle.Flat;
            buttonDX.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDX.ForeColor = Color.White;
            buttonDX.Location = new Point(0, 811);
            buttonDX.Name = "buttonDX";
            buttonDX.Size = new Size(200, 50);
            buttonDX.TabIndex = 2;
            buttonDX.Text = "ĐĂNG XUẤT";
            buttonDX.UseVisualStyleBackColor = true;
            buttonDX.Click += buttonDX_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = SystemColors.ActiveBorder;
            pictureBoxLogo.Dock = DockStyle.Top;
            pictureBoxLogo.Image = Properties.Resources.Artboard_7_80_1;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(200, 200);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(buttonTC, 0, 0);
            tableLayoutPanelMenu.Controls.Add(buttonSV, 0, 1);
            tableLayoutPanelMenu.Controls.Add(buttonGV, 0, 2);
            tableLayoutPanelMenu.Controls.Add(buttonLH, 0, 3);
            tableLayoutPanelMenu.Controls.Add(buttonMH, 0, 4);
            tableLayoutPanelMenu.Controls.Add(buttonKhoa, 0, 5);
            tableLayoutPanelMenu.Controls.Add(buttonTK, 0, 6);
            tableLayoutPanelMenu.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLayoutPanelMenu.Location = new Point(0, 200);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 7;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.Size = new Size(200, 400);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // buttonTC
            // 
            buttonTC.Dock = DockStyle.Fill;
            buttonTC.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTC.Location = new Point(3, 3);
            buttonTC.Name = "buttonTC";
            buttonTC.Size = new Size(194, 51);
            buttonTC.TabIndex = 0;
            buttonTC.Text = "TRANG CHỦ";
            buttonTC.UseVisualStyleBackColor = true;
            buttonTC.Click += buttonTC_Click;
            // 
            // buttonSV
            // 
            buttonSV.Dock = DockStyle.Fill;
            buttonSV.Location = new Point(3, 60);
            buttonSV.Name = "buttonSV";
            buttonSV.Size = new Size(194, 51);
            buttonSV.TabIndex = 1;
            buttonSV.Text = "SINH VIÊN";
            buttonSV.UseVisualStyleBackColor = true;
            buttonSV.Click += buttonSV_Click;
            // 
            // buttonGV
            // 
            buttonGV.Dock = DockStyle.Fill;
            buttonGV.Location = new Point(3, 117);
            buttonGV.Name = "buttonGV";
            buttonGV.Size = new Size(194, 51);
            buttonGV.TabIndex = 2;
            buttonGV.Text = "GIẢNG VIÊN";
            buttonGV.UseVisualStyleBackColor = true;
            buttonGV.Click += buttonGV_Click;
            // 
            // buttonLH
            // 
            buttonLH.Dock = DockStyle.Fill;
            buttonLH.Location = new Point(3, 174);
            buttonLH.Name = "buttonLH";
            buttonLH.Size = new Size(194, 51);
            buttonLH.TabIndex = 3;
            buttonLH.Text = "LỚP HỌC";
            buttonLH.UseVisualStyleBackColor = true;
            buttonLH.Click += buttonLH_Click;
            // 
            // buttonMH
            // 
            buttonMH.Dock = DockStyle.Fill;
            buttonMH.Location = new Point(3, 231);
            buttonMH.Name = "buttonMH";
            buttonMH.Size = new Size(194, 51);
            buttonMH.TabIndex = 4;
            buttonMH.Text = "MÔN HỌC";
            buttonMH.UseVisualStyleBackColor = true;
            buttonMH.Click += buttonMH_Click;
            // 
            // buttonKhoa
            // 
            buttonKhoa.Dock = DockStyle.Fill;
            buttonKhoa.Location = new Point(3, 288);
            buttonKhoa.Name = "buttonKhoa";
            buttonKhoa.Size = new Size(194, 51);
            buttonKhoa.TabIndex = 5;
            buttonKhoa.Text = "KHOA";
            buttonKhoa.UseVisualStyleBackColor = true;
            buttonKhoa.Click += buttonKhoa_Click;
            // 
            // buttonTK
            // 
            buttonTK.Dock = DockStyle.Fill;
            buttonTK.Location = new Point(3, 345);
            buttonTK.Name = "buttonTK";
            buttonTK.Size = new Size(194, 52);
            buttonTK.TabIndex = 6;
            buttonTK.Text = "TÀI KHOẢN";
            buttonTK.UseVisualStyleBackColor = true;
            buttonTK.Click += buttonTK_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ButtonHighlight;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1384, 861);
            panelContent.TabIndex = 1;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            tableLayoutPanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private PictureBox pictureBoxLogo;
        private TableLayoutPanel tableLayoutPanelMenu;
        private Button buttonTC;
        private Button buttonSV;
        private Button buttonGV;
        private Button buttonLH;
        private Button buttonMH;
        private Button buttonKhoa;
        private Button buttonDX;
        private Button buttonTK;
        private Panel panelContent;
    }
}