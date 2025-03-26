namespace baocao.GUI
{
    partial class fHopDongEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cbMaCT = new ComboBox();
            txtTenCT = new TextBox();
            txtKyHieuCT = new TextBox();
            txtTenDaiDien = new TextBox();
            txtSdt = new TextBox();
            txtDiaChi = new TextBox();
            labelMaCT = new Label();
            labelTenCT = new Label();
            labelKyHieuCT = new Label();
            labelNgayHD = new Label();
            labelTenDaiDien = new Label();
            labelSdt = new Label();
            labelDiaChi = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            labelMaHD = new Label();
            txtMaHD = new TextBox();
            dtpNgayHD = new DateTimePicker();
            btnExit = new FontAwesome.Sharp.IconButton();
            panelNavbar = new Panel();
            labelTitle = new Label();
            panelNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // cbMaCT
            // 
            cbMaCT.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaCT.Location = new Point(442, 125);
            cbMaCT.Margin = new Padding(4, 5, 4, 5);
            cbMaCT.Name = "cbMaCT";
            cbMaCT.Size = new Size(246, 33);
            cbMaCT.TabIndex = 0;
            cbMaCT.TextChanged += cbMaCT_TextChanged;
            // 
            // txtTenCT
            // 
            txtTenCT.Enabled = false;
            txtTenCT.Location = new Point(87, 199);
            txtTenCT.Margin = new Padding(4, 5, 4, 5);
            txtTenCT.Name = "txtTenCT";
            txtTenCT.Size = new Size(309, 31);
            txtTenCT.TabIndex = 1;
            // 
            // txtKyHieuCT
            // 
            txtKyHieuCT.Enabled = false;
            txtKyHieuCT.Location = new Point(442, 199);
            txtKyHieuCT.Margin = new Padding(4, 5, 4, 5);
            txtKyHieuCT.Name = "txtKyHieuCT";
            txtKyHieuCT.Size = new Size(246, 31);
            txtKyHieuCT.TabIndex = 2;
            // 
            // txtTenDaiDien
            // 
            txtTenDaiDien.Enabled = false;
            txtTenDaiDien.Location = new Point(87, 275);
            txtTenDaiDien.Margin = new Padding(4, 5, 4, 5);
            txtTenDaiDien.Name = "txtTenDaiDien";
            txtTenDaiDien.Size = new Size(309, 31);
            txtTenDaiDien.TabIndex = 4;
            // 
            // txtSdt
            // 
            txtSdt.Enabled = false;
            txtSdt.Location = new Point(442, 275);
            txtSdt.Margin = new Padding(4, 5, 4, 5);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(246, 31);
            txtSdt.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Enabled = false;
            txtDiaChi.Location = new Point(87, 355);
            txtDiaChi.Margin = new Padding(4, 5, 4, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(309, 31);
            txtDiaChi.TabIndex = 6;
            // 
            // labelMaCT
            // 
            labelMaCT.AutoSize = true;
            labelMaCT.Location = new Point(442, 97);
            labelMaCT.Margin = new Padding(4, 0, 4, 0);
            labelMaCT.Name = "labelMaCT";
            labelMaCT.Size = new Size(102, 25);
            labelMaCT.TabIndex = 0;
            labelMaCT.Text = "Mã công ty";
            // 
            // labelTenCT
            // 
            labelTenCT.AutoSize = true;
            labelTenCT.Location = new Point(87, 169);
            labelTenCT.Margin = new Padding(4, 0, 4, 0);
            labelTenCT.Name = "labelTenCT";
            labelTenCT.Size = new Size(103, 25);
            labelTenCT.TabIndex = 0;
            labelTenCT.Text = "Tên công ty";
            // 
            // labelKyHieuCT
            // 
            labelKyHieuCT.Location = new Point(442, 169);
            labelKyHieuCT.Margin = new Padding(4, 0, 4, 0);
            labelKyHieuCT.Name = "labelKyHieuCT";
            labelKyHieuCT.Size = new Size(143, 38);
            labelKyHieuCT.TabIndex = 0;
            labelKyHieuCT.Text = "Ký hiệu công ty";
            // 
            // labelNgayHD
            // 
            labelNgayHD.AutoSize = true;
            labelNgayHD.Location = new Point(442, 325);
            labelNgayHD.Margin = new Padding(4, 0, 4, 0);
            labelNgayHD.Name = "labelNgayHD";
            labelNgayHD.Size = new Size(162, 25);
            labelNgayHD.TabIndex = 0;
            labelNgayHD.Text = "Ngày ký hợp đồng";
            // 
            // labelTenDaiDien
            // 
            labelTenDaiDien.Location = new Point(87, 245);
            labelTenDaiDien.Margin = new Padding(4, 0, 4, 0);
            labelTenDaiDien.Name = "labelTenDaiDien";
            labelTenDaiDien.Size = new Size(143, 38);
            labelTenDaiDien.TabIndex = 0;
            labelTenDaiDien.Text = "Tên đại diện";
            // 
            // labelSdt
            // 
            labelSdt.Location = new Point(442, 245);
            labelSdt.Margin = new Padding(4, 0, 4, 0);
            labelSdt.Name = "labelSdt";
            labelSdt.Size = new Size(143, 38);
            labelSdt.TabIndex = 0;
            labelSdt.Text = "Số điện thoại";
            // 
            // labelDiaChi
            // 
            labelDiaChi.Location = new Point(87, 325);
            labelDiaChi.Margin = new Padding(4, 0, 4, 0);
            labelDiaChi.Name = "labelDiaChi";
            labelDiaChi.Size = new Size(143, 38);
            labelDiaChi.TabIndex = 0;
            labelDiaChi.Text = "Địa chỉ";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(252, 420);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 38);
            btnSave.TabIndex = 15;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(426, 420);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 38);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelMaHD
            // 
            labelMaHD.Location = new Point(87, 95);
            labelMaHD.Margin = new Padding(4, 0, 4, 0);
            labelMaHD.Name = "labelMaHD";
            labelMaHD.Size = new Size(143, 38);
            labelMaHD.TabIndex = 0;
            labelMaHD.Text = "Mã hợp đồng";
            // 
            // txtMaHD
            // 
            txtMaHD.Enabled = false;
            txtMaHD.Location = new Point(87, 125);
            txtMaHD.Margin = new Padding(4, 5, 4, 5);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(309, 31);
            txtMaHD.TabIndex = 0;
            // 
            // dtpNgayHD
            // 
            dtpNgayHD.Format = DateTimePickerFormat.Short;
            dtpNgayHD.Location = new Point(442, 355);
            dtpNgayHD.Margin = new Padding(4, 5, 4, 5);
            dtpNgayHD.Name = "dtpNgayHD";
            dtpNgayHD.Size = new Size(246, 31);
            dtpNgayHD.TabIndex = 18;
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
            btnExit.Size = new Size(36, 38);
            btnExit.TabIndex = 19;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnCancel_Click;
            // 
            // panelNavbar
            // 
            panelNavbar.Controls.Add(btnExit);
            panelNavbar.Dock = DockStyle.Top;
            panelNavbar.Location = new Point(0, 0);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(800, 38);
            panelNavbar.TabIndex = 20;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(12, 41);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(228, 38);
            labelTitle.TabIndex = 21;
            labelTitle.Text = "Thêm hợp đồng";
            // 
            // FormTest
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(labelTitle);
            Controls.Add(panelNavbar);
            Controls.Add(txtMaHD);
            Controls.Add(cbMaCT);
            Controls.Add(txtTenCT);
            Controls.Add(txtKyHieuCT);
            Controls.Add(dtpNgayHD);
            Controls.Add(txtTenDaiDien);
            Controls.Add(txtSdt);
            Controls.Add(txtDiaChi);
            Controls.Add(labelMaHD);
            Controls.Add(labelMaCT);
            Controls.Add(labelTenCT);
            Controls.Add(labelKyHieuCT);
            Controls.Add(labelNgayHD);
            Controls.Add(labelTenDaiDien);
            Controls.Add(labelSdt);
            Controls.Add(labelDiaChi);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fDSHDEdit";
            panelNavbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaHD;
        private ComboBox cbMaCT;
        private TextBox txtTenCT;
        private TextBox txtKyHieuCT;
        private TextBox txtTenDaiDien;
        private TextBox txtSdt;
        private TextBox txtDiaChi;
        private Label labelMaHD;
        private Label labelMaCT;
        private Label labelTenCT;
        private Label labelKyHieuCT;
        private Label labelNgayHD;
        private Label labelTenDaiDien;
        private Label labelSdt;
        private Label labelDiaChi;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpNgayHD;
        private FontAwesome.Sharp.IconButton btnExit;
        private Panel panelNavbar;
        private Label labelTitle;
    }
}