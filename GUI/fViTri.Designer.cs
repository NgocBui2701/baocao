namespace baocao.GUI
{
    partial class fViTri
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
            panelPage = new Panel();
            labelTypeStats = new Label();
            btnReturn = new FontAwesome.Sharp.IconButton();
            labelPage = new Label();
            panelBody = new Panel();
            panelTitle = new Panel();
            ckbStatus = new Guna.UI2.WinForms.Guna2CheckBox();
            labelDonHang = new Label();
            labelCongTy = new Label();
            btnDat = new FontAwesome.Sharp.IconButton();
            btnNuoc = new FontAwesome.Sharp.IconButton();
            btnKhongKhi = new FontAwesome.Sharp.IconButton();
            btnKhiThai = new FontAwesome.Sharp.IconButton();
            panelMenu = new Panel();
            panelPage.SuspendLayout();
            panelTitle.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelPage
            // 
            panelPage.BackColor = Color.Black;
            panelPage.Controls.Add(labelTypeStats);
            panelPage.Controls.Add(btnReturn);
            panelPage.Controls.Add(labelPage);
            panelPage.Dock = DockStyle.Top;
            panelPage.Location = new Point(71, 0);
            panelPage.Margin = new Padding(4, 5, 4, 5);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1058, 65);
            panelPage.TabIndex = 1;
            // 
            // labelTypeStats
            // 
            labelTypeStats.AutoSize = true;
            labelTypeStats.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTypeStats.Location = new Point(8, 20);
            labelTypeStats.Name = "labelTypeStats";
            labelTypeStats.Size = new Size(63, 32);
            labelTypeStats.TabIndex = 2;
            labelTypeStats.Text = "ĐẤT";
            // 
            // btnReturn
            // 
            btnReturn.BackgroundImageLayout = ImageLayout.None;
            btnReturn.Dock = DockStyle.Right;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.ForeColor = Color.White;
            btnReturn.IconChar = FontAwesome.Sharp.IconChar.X;
            btnReturn.IconColor = Color.White;
            btnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReturn.IconSize = 35;
            btnReturn.Location = new Point(1002, 0);
            btnReturn.Margin = new Padding(4, 5, 4, 5);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(56, 65);
            btnReturn.TabIndex = 1;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // labelPage
            // 
            labelPage.Anchor = AnchorStyles.None;
            labelPage.AutoSize = true;
            labelPage.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPage.ForeColor = Color.White;
            labelPage.Location = new Point(365, 10);
            labelPage.Margin = new Padding(4, 0, 4, 0);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(341, 45);
            labelPage.TabIndex = 0;
            labelPage.Text = "Thông số môi trường";
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.Black;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(71, 104);
            panelBody.Margin = new Padding(4, 5, 4, 5);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1058, 646);
            panelBody.TabIndex = 2;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = SystemColors.ActiveCaptionText;
            panelTitle.Controls.Add(ckbStatus);
            panelTitle.Controls.Add(labelDonHang);
            panelTitle.Controls.Add(labelCongTy);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(71, 65);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1058, 39);
            panelTitle.TabIndex = 3;
            // 
            // ckbStatus
            // 
            ckbStatus.AutoSize = true;
            ckbStatus.Checked = true;
            ckbStatus.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ckbStatus.CheckedState.BorderRadius = 0;
            ckbStatus.CheckedState.BorderThickness = 0;
            ckbStatus.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ckbStatus.CheckState = CheckState.Checked;
            ckbStatus.Location = new Point(109, 5);
            ckbStatus.Name = "ckbStatus";
            ckbStatus.Size = new Size(134, 29);
            ckbStatus.TabIndex = 2;
            ckbStatus.Text = "Hoàn Thành";
            ckbStatus.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ckbStatus.UncheckedState.BorderRadius = 0;
            ckbStatus.UncheckedState.BorderThickness = 0;
            ckbStatus.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ckbStatus.CheckStateChanged += ckbStatus_CheckStateChanged;
            // 
            // labelDonHang
            // 
            labelDonHang.AutoSize = true;
            labelDonHang.ForeColor = SystemColors.ControlLightLight;
            labelDonHang.Location = new Point(7, 5);
            labelDonHang.Name = "labelDonHang";
            labelDonHang.Size = new Size(76, 25);
            labelDonHang.TabIndex = 1;
            labelDonHang.Text = "24.0001";
            // 
            // labelCongTy
            // 
            labelCongTy.AutoSize = true;
            labelCongTy.ForeColor = SystemColors.ControlLightLight;
            labelCongTy.Location = new Point(378, 7);
            labelCongTy.Name = "labelCongTy";
            labelCongTy.Size = new Size(108, 25);
            labelCongTy.TabIndex = 0;
            labelCongTy.Text = "Tên Công Ty";
            // 
            // btnDat
            // 
            btnDat.Anchor = AnchorStyles.Bottom;
            btnDat.BackColor = Color.Transparent;
            btnDat.FlatAppearance.BorderSize = 0;
            btnDat.FlatStyle = FlatStyle.Flat;
            btnDat.IconChar = FontAwesome.Sharp.IconChar.GlobeAsia;
            btnDat.IconColor = Color.Black;
            btnDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDat.IconSize = 40;
            btnDat.Location = new Point(-1, 276);
            btnDat.Margin = new Padding(4, 5, 4, 5);
            btnDat.Name = "btnDat";
            btnDat.Padding = new Padding(0, 17, 0, 17);
            btnDat.Size = new Size(57, 100);
            btnDat.TabIndex = 1;
            btnDat.UseVisualStyleBackColor = false;
            btnDat.Click += btnDat_Click;
            // 
            // btnNuoc
            // 
            btnNuoc.Anchor = AnchorStyles.Bottom;
            btnNuoc.BackColor = Color.Transparent;
            btnNuoc.FlatAppearance.BorderSize = 0;
            btnNuoc.FlatStyle = FlatStyle.Flat;
            btnNuoc.IconChar = FontAwesome.Sharp.IconChar.FaucetDrip;
            btnNuoc.IconColor = Color.Black;
            btnNuoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuoc.IconSize = 40;
            btnNuoc.Location = new Point(-1, 376);
            btnNuoc.Margin = new Padding(4, 5, 4, 5);
            btnNuoc.Name = "btnNuoc";
            btnNuoc.Padding = new Padding(0, 17, 0, 17);
            btnNuoc.Size = new Size(57, 100);
            btnNuoc.TabIndex = 2;
            btnNuoc.UseVisualStyleBackColor = false;
            btnNuoc.Click += btnNuoc_Click;
            // 
            // btnKhongKhi
            // 
            btnKhongKhi.Anchor = AnchorStyles.Bottom;
            btnKhongKhi.BackColor = Color.Transparent;
            btnKhongKhi.FlatAppearance.BorderSize = 0;
            btnKhongKhi.FlatStyle = FlatStyle.Flat;
            btnKhongKhi.IconChar = FontAwesome.Sharp.IconChar.Wind;
            btnKhongKhi.IconColor = Color.Black;
            btnKhongKhi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKhongKhi.IconSize = 40;
            btnKhongKhi.Location = new Point(-1, 476);
            btnKhongKhi.Margin = new Padding(4, 5, 4, 5);
            btnKhongKhi.Name = "btnKhongKhi";
            btnKhongKhi.Padding = new Padding(0, 17, 0, 17);
            btnKhongKhi.Size = new Size(57, 100);
            btnKhongKhi.TabIndex = 3;
            btnKhongKhi.UseVisualStyleBackColor = false;
            btnKhongKhi.Click += btnKhongKhi_Click;
            // 
            // btnKhiThai
            // 
            btnKhiThai.Anchor = AnchorStyles.Bottom;
            btnKhiThai.BackColor = Color.Transparent;
            btnKhiThai.FlatAppearance.BorderSize = 0;
            btnKhiThai.FlatStyle = FlatStyle.Flat;
            btnKhiThai.IconChar = FontAwesome.Sharp.IconChar.SkullCrossbones;
            btnKhiThai.IconColor = Color.Black;
            btnKhiThai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKhiThai.IconSize = 40;
            btnKhiThai.Location = new Point(-1, 576);
            btnKhiThai.Margin = new Padding(4, 5, 4, 5);
            btnKhiThai.Name = "btnKhiThai";
            btnKhiThai.Padding = new Padding(0, 17, 0, 17);
            btnKhiThai.Size = new Size(57, 100);
            btnKhiThai.TabIndex = 4;
            btnKhiThai.UseVisualStyleBackColor = false;
            btnKhiThai.Click += btnKhiThai_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.White;
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(btnKhiThai);
            panelMenu.Controls.Add(btnKhongKhi);
            panelMenu.Controls.Add(btnNuoc);
            panelMenu.Controls.Add(btnDat);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(14, 0);
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(57, 750);
            panelMenu.TabIndex = 0;
            // 
            // fViTri
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(panelBody);
            Controls.Add(panelTitle);
            Controls.Add(panelPage);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fViTri";
            Padding = new Padding(14, 0, 14, 0);
            Text = "fViTri";
            FormClosing += fViTri_FormClosing;
            Load += fViTri_Load;
            panelPage.ResumeLayout(false);
            panelPage.PerformLayout();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelPage;
        private Label labelPage;
        private FontAwesome.Sharp.IconButton btnReturn;
        private Panel panelBody;
        private Panel panelTitle;
        private Label labelDonHang;
        private Label labelCongTy;
        private Guna.UI2.WinForms.Guna2CheckBox ckbStatus;
        private Label labelTypeStats;
        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnKhiThai;
        private FontAwesome.Sharp.IconButton btnKhongKhi;
        private FontAwesome.Sharp.IconButton btnNuoc;
        private FontAwesome.Sharp.IconButton btnDat;
    }
}