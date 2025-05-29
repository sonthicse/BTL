namespace BTL
{
    partial class UserControlCD
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
            buttonHuy = new Button();
            buttonDMK = new Button();
            buttonXacNhan = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(buttonHuy);
            panel1.Controls.Add(buttonDMK);
            panel1.Controls.Add(buttonXacNhan);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1344, 841);
            panel1.TabIndex = 4;
            // 
            // buttonHuy
            // 
            buttonHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonHuy.Location = new Point(500, 252);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(100, 30);
            buttonHuy.TabIndex = 7;
            buttonHuy.Text = "HỦY";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Visible = false;
            // 
            // buttonDMK
            // 
            buttonDMK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDMK.Location = new Point(653, 252);
            buttonDMK.Name = "buttonDMK";
            buttonDMK.Size = new Size(163, 30);
            buttonDMK.TabIndex = 5;
            buttonDMK.Text = "ĐỔI MẬT KHẨU";
            buttonDMK.UseVisualStyleBackColor = true;
            // 
            // buttonXacNhan
            // 
            buttonXacNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonXacNhan.Location = new Point(696, 252);
            buttonXacNhan.Name = "buttonXacNhan";
            buttonXacNhan.Size = new Size(120, 30);
            buttonXacNhan.TabIndex = 6;
            buttonXacNhan.Text = "XÁC NHẬN";
            buttonXacNhan.UseVisualStyleBackColor = true;
            buttonXacNhan.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.8125F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.1875F));
            tableLayoutPanel1.Controls.Add(textBoxPassword, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxUsername, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Location = new Point(464, 146);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(384, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Enabled = false;
            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(129, 53);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(252, 29);
            textBoxPassword.TabIndex = 14;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Dock = DockStyle.Fill;
            textBoxUsername.Enabled = false;
            textBoxUsername.Font = new Font("Segoe UI", 12F);
            textBoxUsername.Location = new Point(129, 3);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(252, 29);
            textBoxUsername.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 50);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // UserControlCD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlCD";
            Size = new Size(1384, 861);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Label label1;
        private Label label2;
        private Button buttonHuy;
        private Button buttonDMK;
        private Button buttonXacNhan;
    }
}
