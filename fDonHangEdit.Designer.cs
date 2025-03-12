namespace baocao
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
            txtTSMT = new TextBox();
            dtpNKQ = new DateTimePicker();
            dtpNLM = new DateTimePicker();
            cbbMaHD = new ComboBox();
            buttonLuu = new Button();
            buttonHuy = new Button();
            labelQuy = new Label();
            labelTSMT = new Label();
            txtQuy = new TextBox();
            txtTrangthai = new TextBox();
            labelTrangthai = new Label();
            btnExit = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // labelMaHD
            // 
            labelMaHD.AutoSize = true;
            labelMaHD.Location = new Point(133, 28);
            labelMaHD.Name = "labelMaHD";
            labelMaHD.Size = new Size(79, 15);
            labelMaHD.TabIndex = 0;
            labelMaHD.Text = "Mã hợp đồng";
            // 
            // labelMaDH
            // 
            labelMaDH.AutoSize = true;
            labelMaDH.Location = new Point(452, 28);
            labelMaDH.Name = "labelMaDH";
            labelMaDH.Size = new Size(78, 15);
            labelMaDH.TabIndex = 0;
            labelMaDH.Text = "Mã đơn hàng";
            // 
            // labelNLM
            // 
            labelNLM.AutoSize = true;
            labelNLM.Location = new Point(133, 91);
            labelNLM.Name = "labelNLM";
            labelNLM.Size = new Size(123, 15);
            labelNLM.TabIndex = 0;
            labelNLM.Text = "Ngày bắt đầu lấy mẫu";
            // 
            // labelNKQ
            // 
            labelNKQ.AutoSize = true;
            labelNKQ.Location = new Point(452, 91);
            labelNKQ.Name = "labelNKQ";
            labelNKQ.Size = new Size(136, 15);
            labelNKQ.TabIndex = 0;
            labelNKQ.Text = "Ngày trả kết quả dự kiến";
            // 
            // txtMaDH
            // 
            txtMaDH.Location = new Point(452, 46);
            txtMaDH.Name = "txtMaDH";
            txtMaDH.Size = new Size(100, 23);
            txtMaDH.TabIndex = 1;
            // 
            // txtTSMT
            // 
            txtTSMT.Location = new Point(452, 182);
            txtTSMT.Name = "txtTSMT";
            txtTSMT.Size = new Size(106, 23);
            txtTSMT.TabIndex = 7;
            // 
            // dtpNKQ
            // 
            dtpNKQ.Location = new Point(452, 108);
            dtpNKQ.Name = "dtpNKQ";
            dtpNKQ.Size = new Size(211, 23);
            dtpNKQ.TabIndex = 8;
            // 
            // dtpNLM
            // 
            dtpNLM.Location = new Point(133, 108);
            dtpNLM.Name = "dtpNLM";
            dtpNLM.Size = new Size(211, 23);
            dtpNLM.TabIndex = 9;
            dtpNLM.ValueChanged += dtpNLM_ValueChanged;
            // 
            // cbbMaHD
            // 
            cbbMaHD.FormattingEnabled = true;
            cbbMaHD.Location = new Point(133, 46);
            cbbMaHD.Name = "cbbMaHD";
            cbbMaHD.Size = new Size(100, 23);
            cbbMaHD.TabIndex = 0;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(265, 283);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(78, 20);
            buttonLuu.TabIndex = 11;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += btnSave_Click;
            // 
            // buttonHuy
            // 
            buttonHuy.Location = new Point(452, 283);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(78, 20);
            buttonHuy.TabIndex = 12;
            buttonHuy.Text = "Hủy";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Click += btnCancel_Click;
            // 
            // labelQuy
            // 
            labelQuy.AutoSize = true;
            labelQuy.Location = new Point(133, 165);
            labelQuy.Name = "labelQuy";
            labelQuy.Size = new Size(29, 15);
            labelQuy.TabIndex = 13;
            labelQuy.Text = "Quý";
            // 
            // labelTSMT
            // 
            labelTSMT.AutoSize = true;
            labelTSMT.Location = new Point(452, 165);
            labelTSMT.Name = "labelTSMT";
            labelTSMT.Size = new Size(237, 15);
            labelTSMT.TabIndex = 14;
            labelTSMT.Text = "Thông số môi trường (Đất,Nước,Không khí)";
            // 
            // txtQuy
            // 
            txtQuy.Location = new Point(133, 183);
            txtQuy.Name = "txtQuy";
            txtQuy.Size = new Size(89, 23);
            txtQuy.TabIndex = 20;
            // 
            // txtTrangthai
            // 
            txtTrangthai.Location = new Point(305, 235);
            txtTrangthai.Name = "txtTrangthai";
            txtTrangthai.Size = new Size(142, 23);
            txtTrangthai.TabIndex = 22;
            // 
            // labelTrangthai
            // 
            labelTrangthai.AutoSize = true;
            labelTrangthai.Location = new Point(305, 217);
            labelTrangthai.Name = "labelTrangthai";
            labelTrangthai.Size = new Size(59, 15);
            labelTrangthai.TabIndex = 21;
            labelTrangthai.Text = "Trạng thái";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.DarkOrange;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(773, 1);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(25, 25);
            btnExit.TabIndex = 23;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnCancel_Click;
            // 
            // fDonHangEdit
            // 
            AcceptButton = buttonLuu;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(txtTrangthai);
            Controls.Add(labelTrangthai);
            Controls.Add(txtQuy);
            Controls.Add(labelTSMT);
            Controls.Add(labelQuy);
            Controls.Add(buttonHuy);
            Controls.Add(buttonLuu);
            Controls.Add(cbbMaHD);
            Controls.Add(dtpNLM);
            Controls.Add(dtpNKQ);
            Controls.Add(txtTSMT);
            Controls.Add(txtMaDH);
            Controls.Add(labelNKQ);
            Controls.Add(labelNLM);
            Controls.Add(labelMaDH);
            Controls.Add(labelMaHD);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "fDonHangEdit";
            Text = "fDSDHEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMaHD;
        private Label labelMaDH;
        private Label labelNLM;
        private Label labelNKQ;
        private TextBox txtMaDH;
        private TextBox txtTSMT;
        private DateTimePicker dtpNKQ;
        private DateTimePicker dtpNLM;
        private ComboBox cbbMaHD;
        private Button buttonLuu;
        private Button buttonHuy;
        private Label labelQuy;
        private Label labelTSMT;
        private TextBox txtQuy;
        private TextBox txtTrangthai;
        private Label labelTrangthai;
        private FontAwesome.Sharp.IconButton btnExit;
    }
}