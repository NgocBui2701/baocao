namespace baocao.GUI
{
    partial class fDonHangEdit
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
            labelMaHD = new Label();
            labelMaDH = new Label();
            labelNLM = new Label();
            labelNKQ = new Label();
            txtMaDH = new TextBox();
            dtpNKQ = new DateTimePicker();
            dtpNLM = new DateTimePicker();
            cbbMaHD = new ComboBox();
            buttonLuu = new Button();
            buttonHuy = new Button();
            labelQuy = new Label();
            txtQuy = new TextBox();
            txtTrangthai = new TextBox();
            labelTrangthai = new Label();
            btnExit = new FontAwesome.Sharp.IconButton();
            panelNavbar = new Panel();
            labelTitle = new Label();
            panelNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // labelMaHD
            // 
            labelMaHD.AutoSize = true;
            labelMaHD.Location = new Point(55, 105);
            labelMaHD.Margin = new Padding(4, 0, 4, 0);
            labelMaHD.Name = "labelMaHD";
            labelMaHD.Size = new Size(122, 25);
            labelMaHD.TabIndex = 0;
            labelMaHD.Text = "Mã hợp đồng";
            // 
            // labelMaDH
            // 
            labelMaDH.AutoSize = true;
            labelMaDH.Location = new Point(436, 107);
            labelMaDH.Margin = new Padding(4, 0, 4, 0);
            labelMaDH.Name = "labelMaDH";
            labelMaDH.Size = new Size(119, 25);
            labelMaDH.TabIndex = 0;
            labelMaDH.Text = "Mã đơn hàng";
            // 
            // labelNLM
            // 
            labelNLM.AutoSize = true;
            labelNLM.Location = new Point(55, 197);
            labelNLM.Margin = new Padding(4, 0, 4, 0);
            labelNLM.Name = "labelNLM";
            labelNLM.Size = new Size(187, 25);
            labelNLM.TabIndex = 0;
            labelNLM.Text = "Ngày bắt đầu lấy mẫu";
            // 
            // labelNKQ
            // 
            labelNKQ.AutoSize = true;
            labelNKQ.Location = new Point(436, 197);
            labelNKQ.Margin = new Padding(4, 0, 4, 0);
            labelNKQ.Name = "labelNKQ";
            labelNKQ.Size = new Size(208, 25);
            labelNKQ.TabIndex = 0;
            labelNKQ.Text = "Ngày trả kết quả dự kiến";
            // 
            // txtMaDH
            // 
            txtMaDH.Location = new Point(436, 137);
            txtMaDH.Margin = new Padding(4, 5, 4, 5);
            txtMaDH.Name = "txtMaDH";
            txtMaDH.Size = new Size(303, 31);
            txtMaDH.TabIndex = 1;
            // 
            // dtpNKQ
            // 
            dtpNKQ.Location = new Point(436, 225);
            dtpNKQ.Margin = new Padding(4, 5, 4, 5);
            dtpNKQ.Name = "dtpNKQ";
            dtpNKQ.Size = new Size(303, 31);
            dtpNKQ.TabIndex = 8;
            // 
            // dtpNLM
            // 
            dtpNLM.Location = new Point(55, 225);
            dtpNLM.Margin = new Padding(4, 5, 4, 5);
            dtpNLM.Name = "dtpNLM";
            dtpNLM.Size = new Size(303, 31);
            dtpNLM.TabIndex = 9;
            dtpNLM.ValueChanged += dtpNLM_ValueChanged;
            // 
            // cbbMaHD
            // 
            cbbMaHD.FormattingEnabled = true;
            cbbMaHD.Location = new Point(55, 135);
            cbbMaHD.Margin = new Padding(4, 5, 4, 5);
            cbbMaHD.Name = "cbbMaHD";
            cbbMaHD.Size = new Size(303, 33);
            cbbMaHD.TabIndex = 0;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(260, 396);
            buttonLuu.Margin = new Padding(4, 5, 4, 5);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(111, 33);
            buttonLuu.TabIndex = 11;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += btnSave_Click;
            // 
            // buttonHuy
            // 
            buttonHuy.Location = new Point(423, 396);
            buttonHuy.Margin = new Padding(4, 5, 4, 5);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(111, 33);
            buttonHuy.TabIndex = 12;
            buttonHuy.Text = "Hủy";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Click += btnCancel_Click;
            // 
            // labelQuy
            // 
            labelQuy.AutoSize = true;
            labelQuy.Location = new Point(55, 283);
            labelQuy.Margin = new Padding(4, 0, 4, 0);
            labelQuy.Name = "labelQuy";
            labelQuy.Size = new Size(45, 25);
            labelQuy.TabIndex = 13;
            labelQuy.Text = "Quý";
            // 
            // txtQuy
            // 
            txtQuy.Location = new Point(55, 313);
            txtQuy.Margin = new Padding(4, 5, 4, 5);
            txtQuy.Name = "txtQuy";
            txtQuy.Size = new Size(303, 31);
            txtQuy.TabIndex = 20;
            // 
            // txtTrangthai
            // 
            txtTrangthai.Location = new Point(436, 313);
            txtTrangthai.Margin = new Padding(4, 5, 4, 5);
            txtTrangthai.Name = "txtTrangthai";
            txtTrangthai.Size = new Size(303, 31);
            txtTrangthai.TabIndex = 22;
            // 
            // labelTrangthai
            // 
            labelTrangthai.AutoSize = true;
            labelTrangthai.Location = new Point(436, 283);
            labelTrangthai.Margin = new Padding(4, 0, 4, 0);
            labelTrangthai.Name = "labelTrangthai";
            labelTrangthai.Size = new Size(89, 25);
            labelTrangthai.TabIndex = 21;
            labelTrangthai.Text = "Trạng thái";
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.SpringGreen;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(764, 0);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 41);
            btnExit.TabIndex = 23;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnCancel_Click;
            // 
            // panelNavbar
            // 
            panelNavbar.Controls.Add(btnExit);
            panelNavbar.Dock = DockStyle.Top;
            panelNavbar.Location = new Point(0, 0);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(800, 41);
            panelNavbar.TabIndex = 24;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(12, 44);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(226, 38);
            labelTitle.TabIndex = 25;
            labelTitle.Text = "Thêm đơn hàng";
            // 
            // FormTest
            // 
            AcceptButton = buttonLuu;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(labelTitle);
            Controls.Add(panelNavbar);
            Controls.Add(txtTrangthai);
            Controls.Add(labelTrangthai);
            Controls.Add(txtQuy);
            Controls.Add(labelQuy);
            Controls.Add(buttonHuy);
            Controls.Add(buttonLuu);
            Controls.Add(cbbMaHD);
            Controls.Add(dtpNLM);
            Controls.Add(dtpNKQ);
            Controls.Add(txtMaDH);
            Controls.Add(labelNKQ);
            Controls.Add(labelNLM);
            Controls.Add(labelMaDH);
            Controls.Add(labelMaHD);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fDSDHEdit";
            panelNavbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMaHD;
        private Label labelMaDH;
        private Label labelNLM;
        private Label labelNKQ;
        private TextBox txtMaDH;
        private DateTimePicker dtpNKQ;
        private DateTimePicker dtpNLM;
        private ComboBox cbbMaHD;
        private Button buttonLuu;
        private Button buttonHuy;
        private Label labelQuy;
        private TextBox txtQuy;
        private TextBox txtTrangthai;
        private Label labelTrangthai;
        private FontAwesome.Sharp.IconButton btnExit;
        private Panel panelNavbar;
        private Label labelTitle;
    }
}