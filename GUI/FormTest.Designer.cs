using System.Windows.Forms.DataVisualization.Charting;

namespace baocao.GUI
{
    partial class FormTest
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
            btnExit = new FontAwesome.Sharp.IconButton();
            labelMaND = new Label();
            labelTen = new Label();
            labelVaiTro = new Label();
            labelTenDangNhap = new Label();
            labelEmail = new Label();
            labelSdt = new Label();
            txtMaND = new TextBox();
            txtHoTen = new TextBox();
            txtTenDangNhap = new TextBox();
            txtEmail = new TextBox();
            txtSdt = new TextBox();
            cbVaiTro = new ComboBox();
            btnCancel = new Button();
            btnSave = new Button();
            labelMatKhau = new Label();
            txtMatKhau = new TextBox();
            btnSeePass = new FontAwesome.Sharp.IconButton();
            panelNavbar = new Panel();
            labelTitle = new Label();
            panelNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.MediumSpringGreen;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(764, 0);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 36);
            btnExit.TabIndex = 20;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnCancel_Click;
            // 
            // labelMaND
            // 
            labelMaND.AutoSize = true;
            labelMaND.Location = new Point(70, 100);
            labelMaND.Name = "labelMaND";
            labelMaND.Size = new Size(118, 25);
            labelMaND.TabIndex = 21;
            labelMaND.Text = "Mã nhân viên";
            // 
            // labelTen
            // 
            labelTen.AutoSize = true;
            labelTen.Location = new Point(430, 100);
            labelTen.Name = "labelTen";
            labelTen.Size = new Size(66, 25);
            labelTen.TabIndex = 22;
            labelTen.Text = "Họ tên";
            // 
            // labelVaiTro
            // 
            labelVaiTro.AutoSize = true;
            labelVaiTro.Location = new Point(430, 172);
            labelVaiTro.Name = "labelVaiTro";
            labelVaiTro.Size = new Size(63, 25);
            labelVaiTro.TabIndex = 23;
            labelVaiTro.Text = "Vai trò";
            // 
            // labelTenDangNhap
            // 
            labelTenDangNhap.AutoSize = true;
            labelTenDangNhap.Location = new Point(70, 172);
            labelTenDangNhap.Name = "labelTenDangNhap";
            labelTenDangNhap.Size = new Size(129, 25);
            labelTenDangNhap.TabIndex = 24;
            labelTenDangNhap.Text = "Tên đăng nhập";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(70, 248);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(54, 25);
            labelEmail.TabIndex = 26;
            labelEmail.Text = "Email";
            // 
            // labelSdt
            // 
            labelSdt.AutoSize = true;
            labelSdt.Location = new Point(430, 248);
            labelSdt.Name = "labelSdt";
            labelSdt.Size = new Size(117, 25);
            labelSdt.TabIndex = 27;
            labelSdt.Text = "Số điện thoại";
            // 
            // txtMaND
            // 
            txtMaND.Enabled = false;
            txtMaND.Location = new Point(70, 128);
            txtMaND.Name = "txtMaND";
            txtMaND.Size = new Size(298, 31);
            txtMaND.TabIndex = 28;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(430, 128);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(298, 31);
            txtHoTen.TabIndex = 29;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(70, 200);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(298, 31);
            txtTenDangNhap.TabIndex = 30;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(70, 276);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(298, 31);
            txtEmail.TabIndex = 32;
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(430, 276);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(298, 31);
            txtSdt.TabIndex = 33;
            // 
            // cbVaiTro
            // 
            cbVaiTro.FormattingEnabled = true;
            cbVaiTro.Location = new Point(430, 200);
            cbVaiTro.Name = "cbVaiTro";
            cbVaiTro.Size = new Size(298, 33);
            cbVaiTro.TabIndex = 34;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(440, 394);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 38);
            btnCancel.TabIndex = 36;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(250, 394);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 38);
            btnSave.TabIndex = 35;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // labelMatKhau
            // 
            labelMatKhau.AutoSize = true;
            labelMatKhau.Location = new Point(184, 331);
            labelMatKhau.Name = "labelMatKhau";
            labelMatKhau.Size = new Size(86, 25);
            labelMatKhau.TabIndex = 37;
            labelMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Enabled = false;
            txtMatKhau.Location = new Point(276, 331);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(240, 31);
            txtMatKhau.TabIndex = 38;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnSeePass
            // 
            btnSeePass.FlatAppearance.BorderSize = 0;
            btnSeePass.FlatStyle = FlatStyle.Flat;
            btnSeePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            btnSeePass.IconColor = Color.Black;
            btnSeePass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSeePass.IconSize = 40;
            btnSeePass.Location = new Point(522, 334);
            btnSeePass.Name = "btnSeePass";
            btnSeePass.Size = new Size(52, 31);
            btnSeePass.TabIndex = 39;
            btnSeePass.UseVisualStyleBackColor = true;
            btnSeePass.Click += btnSeePass_Click;
            // 
            // panelNavbar
            // 
            panelNavbar.Controls.Add(btnExit);
            panelNavbar.Dock = DockStyle.Top;
            panelNavbar.Location = new Point(0, 0);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(800, 36);
            panelNavbar.TabIndex = 40;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(12, 39);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(228, 38);
            labelTitle.TabIndex = 41;
            labelTitle.Text = "Thêm nhân viên";
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(labelTitle);
            Controls.Add(panelNavbar);
            Controls.Add(btnSeePass);
            Controls.Add(txtMatKhau);
            Controls.Add(labelMatKhau);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbVaiTro);
            Controls.Add(txtSdt);
            Controls.Add(txtEmail);
            Controls.Add(txtTenDangNhap);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaND);
            Controls.Add(labelSdt);
            Controls.Add(labelEmail);
            Controls.Add(labelTenDangNhap);
            Controls.Add(labelVaiTro);
            Controls.Add(labelTen);
            Controls.Add(labelMaND);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fNguoiDungEdit";
            panelNavbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnExit;
        private Label labelMaND;
        private Label labelTen;
        private Label labelVaiTro;
        private Label labelTenDangNhap;
        private Label labelEmail;
        private Label labelSdt;
        private TextBox txtMaND;
        private TextBox txtHoTen;
        private TextBox txtTenDangNhap;
        private TextBox txtEmail;
        private TextBox txtSdt;
        private ComboBox cbVaiTro;
        private Button btnCancel;
        private Button btnSave;
        private Label labelMatKhau;
        private TextBox txtMatKhau;
        private FontAwesome.Sharp.IconButton btnSeePass;
        private Panel panelNavbar;
        private Label labelTitle;
    }
}
////
//// chartQuy
////
//chartQuy = new Chart();
//chartQuy.Dock = DockStyle.Fill;
//splitContainerBody.Panel1.Controls.Add(chartQuy);
//chartQuy.BackColor = this.BackColor;
//chartQuy.Titles.Add("Biểu đồ trạng thái đơn hàng theo quý");
//chartQuy.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
//chartQuy.Titles[0].ForeColor = this.ForeColor;
//chartQuy.Titles[0].Alignment = ContentAlignment.MiddleCenter;
//chartQuy.Titles[0].IsDockedInsideChartArea = true;
//chartQuy.MouseClick += ChartQuy_MouseClick;
////
//// chartDot
////
//chartDot = new Chart();
//chartDot.Dock = DockStyle.Fill;
//splitContainerBody.Panel2.Controls.Add(chartDot);
//chartDot.BackColor = this.BackColor;
//chartDot.Titles.Add("Biểu đồ trạng thái đơn hàng theo đợt");
//chartDot.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
//chartDot.Titles[0].ForeColor = this.ForeColor;
//chartDot.Titles[0].Alignment = ContentAlignment.MiddleCenter;
//chartDot.Titles[0].IsDockedInsideChartArea = true;
//chartDot.MouseClick += ChartDot_MouseClick;