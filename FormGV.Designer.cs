namespace BTL
{
    partial class FormGV
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
            buttonCD = new Button();
            buttonTC = new Button();
            buttonSV = new Button();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            tableLayoutPanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.Highlight;
            panelMenu.Controls.Add(buttonDX);
            panelMenu.Controls.Add(pictureBoxLogo);
            panelMenu.Controls.Add(tableLayoutPanelMenu);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 861);
            panelMenu.TabIndex = 1;
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
            tableLayoutPanelMenu.Controls.Add(buttonCD, 0, 2);
            tableLayoutPanelMenu.Controls.Add(buttonTC, 0, 0);
            tableLayoutPanelMenu.Controls.Add(buttonSV, 0, 1);
            tableLayoutPanelMenu.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLayoutPanelMenu.Location = new Point(0, 200);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 3;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelMenu.Size = new Size(200, 200);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // buttonCD
            // 
            buttonCD.Dock = DockStyle.Fill;
            buttonCD.Location = new Point(3, 135);
            buttonCD.Name = "buttonCD";
            buttonCD.Size = new Size(194, 62);
            buttonCD.TabIndex = 2;
            buttonCD.Text = "CÀI ĐẶT";
            buttonCD.UseVisualStyleBackColor = true;
            buttonCD.Click += buttonCD_Click;
            // 
            // buttonTC
            // 
            buttonTC.Dock = DockStyle.Fill;
            buttonTC.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTC.Location = new Point(3, 3);
            buttonTC.Name = "buttonTC";
            buttonTC.Size = new Size(194, 60);
            buttonTC.TabIndex = 0;
            buttonTC.Text = "TRANG CHỦ";
            buttonTC.UseVisualStyleBackColor = true;
            buttonTC.Click += buttonTC_Click;
            // 
            // buttonSV
            // 
            buttonSV.Dock = DockStyle.Fill;
            buttonSV.Location = new Point(3, 69);
            buttonSV.Name = "buttonSV";
            buttonSV.Size = new Size(194, 60);
            buttonSV.TabIndex = 1;
            buttonSV.Text = "SINH VIÊN";
            buttonSV.UseVisualStyleBackColor = true;
            buttonSV.Click += buttonSV_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ButtonHighlight;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1384, 861);
            panelContent.TabIndex = 2;
            // 
            // FormGV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FormGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGV";
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            tableLayoutPanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button buttonDX;
        private PictureBox pictureBoxLogo;
        private TableLayoutPanel tableLayoutPanelMenu;
        private Button buttonTC;
        private Button buttonSV;
        private Button buttonCD;
        private Panel panelContent;
    }
}