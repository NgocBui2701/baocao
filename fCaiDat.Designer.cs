namespace baocao
{
    partial class fCaiDat
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
            panelSetting = new Panel();
            btnDarkMode = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            label1 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            btnTaiKhoan = new FontAwesome.Sharp.IconButton();
            panelSetting.SuspendLayout();
            SuspendLayout();
            // 
            // panelSetting
            // 
            panelSetting.BackColor = Color.Transparent;
            panelSetting.Controls.Add(btnTaiKhoan);
            panelSetting.Controls.Add(btnDarkMode);
            panelSetting.Controls.Add(label2);
            panelSetting.Controls.Add(label1);
            panelSetting.Controls.Add(button5);
            panelSetting.Controls.Add(button4);
            panelSetting.Controls.Add(button3);
            panelSetting.Controls.Add(button1);
            panelSetting.Dock = DockStyle.Fill;
            panelSetting.ForeColor = Color.Transparent;
            panelSetting.Location = new Point(0, 0);
            panelSetting.Name = "panelSetting";
            panelSetting.Size = new Size(800, 450);
            panelSetting.TabIndex = 0;
            // 
            // btnDarkMode
            // 
            btnDarkMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDarkMode.BackColor = Color.White;
            btnDarkMode.Cursor = Cursors.Hand;
            btnDarkMode.FlatAppearance.BorderColor = Color.Black;
            btnDarkMode.FlatAppearance.BorderSize = 0;
            btnDarkMode.FlatStyle = FlatStyle.Flat;
            btnDarkMode.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            btnDarkMode.IconColor = Color.DarkOrange;
            btnDarkMode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDarkMode.IconSize = 40;
            btnDarkMode.Location = new Point(748, 12);
            btnDarkMode.Name = "btnDarkMode";
            btnDarkMode.Size = new Size(40, 40);
            btnDarkMode.TabIndex = 17;
            btnDarkMode.UseVisualStyleBackColor = true;
            btnDarkMode.Click += btnDarkMode_Click;
            btnDarkMode.MouseDown += btnDarkMode_MouseDown;
            btnDarkMode.MouseEnter += btnDarkMode_MouseEnter;
            btnDarkMode.MouseLeave += btnDarkMode_MouseEnter;
            btnDarkMode.MouseMove += btnDarkMode_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(283, 171);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 16;
            label2.Text = "Sao lưu/ khôi phục dữ liệu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(283, 44);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 15;
            label1.Text = "Thông báo cập nhật đơn hàng";
            // 
            // button5
            // 
            button5.BackColor = Color.DarkOrange;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(22, 283);
            button5.Name = "button5";
            button5.Size = new Size(223, 23);
            button5.TabIndex = 12;
            button5.Text = "Thông tin phiên bản và cập nhật";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkOrange;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(22, 224);
            button4.Name = "button4";
            button4.Size = new Size(223, 23);
            button4.TabIndex = 11;
            button4.Text = "Hệ thống";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(22, 167);
            button3.Name = "button3";
            button3.Size = new Size(223, 23);
            button3.TabIndex = 10;
            button3.Text = "Dữ liệu";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 40);
            button1.Name = "button1";
            button1.Size = new Size(223, 23);
            button1.TabIndex = 8;
            button1.Text = "Cài đặt đơn hàng";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.BackColor = Color.DarkOrange;
            btnTaiKhoan.Cursor = Cursors.Hand;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaiKhoan.ForeColor = Color.White;
            btnTaiKhoan.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            btnTaiKhoan.IconColor = Color.White;
            btnTaiKhoan.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTaiKhoan.IconSize = 40;
            btnTaiKhoan.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.Location = new Point(22, 83);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Padding = new Padding(10, 0, 20, 0);
            btnTaiKhoan.Size = new Size(250, 65);
            btnTaiKhoan.TabIndex = 18;
            btnTaiKhoan.Text = "Tài khoản";
            btnTaiKhoan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTaiKhoan.UseVisualStyleBackColor = false;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            // 
            // fCaiDat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelSetting);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fCaiDat";
            Text = "fCaiDat";
            Load += setting_Load;
            panelSetting.ResumeLayout(false);
            panelSetting.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSetting;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnDarkMode;
        private FontAwesome.Sharp.IconButton btnTaiKhoan;
    }
}