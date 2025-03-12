namespace baocao
{
    partial class fMain
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
            components = new System.ComponentModel.Container();
            panelMain = new Panel();
            panelBody = new Panel();
            panelPage = new Panel();
            btnNoti = new FontAwesome.Sharp.IconButton();
            labelPage = new Label();
            btnPage = new FontAwesome.Sharp.IconButton();
            panelNavbar = new Panel();
            labelName = new Label();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnRestoreDown = new FontAwesome.Sharp.IconButton();
            btnExit = new FontAwesome.Sharp.IconButton();
            panelMenu = new Panel();
            btnCaiDat = new FontAwesome.Sharp.IconButton();
            btnThongKe = new FontAwesome.Sharp.IconButton();
            btnDonHang = new FontAwesome.Sharp.IconButton();
            btnHopDong = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panelExpand = new Panel();
            btnMenu = new FontAwesome.Sharp.IconButton();
            btnLogo = new FontAwesome.Sharp.IconButton();
            menuTimer = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            panelPage.SuspendLayout();
            panelNavbar.SuspendLayout();
            panelMenu.SuspendLayout();
            panelExpand.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.Controls.Add(panelBody);
            panelMain.Controls.Add(panelPage);
            panelMain.Controls.Add(panelNavbar);
            panelMain.Controls.Add(panelMenu);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(900, 550);
            panelMain.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.Transparent;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Font = new Font("Segoe UI", 12F);
            panelBody.Location = new Point(250, 69);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(650, 481);
            panelBody.TabIndex = 0;
            // 
            // panelPage
            // 
            panelPage.Controls.Add(btnNoti);
            panelPage.Controls.Add(labelPage);
            panelPage.Controls.Add(btnPage);
            panelPage.Dock = DockStyle.Top;
            panelPage.Location = new Point(250, 25);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(650, 44);
            panelPage.TabIndex = 0;
            // 
            // btnNoti
            // 
            btnNoti.BackColor = Color.Transparent;
            btnNoti.Cursor = Cursors.Hand;
            btnNoti.Dock = DockStyle.Right;
            btnNoti.FlatAppearance.BorderSize = 0;
            btnNoti.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnNoti.FlatStyle = FlatStyle.Flat;
            btnNoti.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNoti.ForeColor = Color.White;
            btnNoti.IconChar = FontAwesome.Sharp.IconChar.Bell;
            btnNoti.IconColor = Color.DarkOrange;
            btnNoti.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnNoti.IconSize = 25;
            btnNoti.Location = new Point(625, 0);
            btnNoti.Name = "btnNoti";
            btnNoti.Size = new Size(25, 44);
            btnNoti.TabIndex = 4;
            btnNoti.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNoti.UseVisualStyleBackColor = false;
            btnNoti.Click += btnNoti_Click;
            btnNoti.MouseEnter += btnNoti_MouseEnter;
            btnNoti.MouseLeave += btnNoti_MouseLeave;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelPage.ForeColor = Color.FromArgb(30, 30, 30);
            labelPage.Location = new Point(26, 14);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(63, 15);
            labelPage.TabIndex = 0;
            labelPage.Text = "Trang chủ";
            // 
            // btnPage
            // 
            btnPage.BackColor = Color.Transparent;
            btnPage.Cursor = Cursors.Hand;
            btnPage.Dock = DockStyle.Left;
            btnPage.FlatAppearance.BorderSize = 0;
            btnPage.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnPage.FlatStyle = FlatStyle.Flat;
            btnPage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPage.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnPage.IconColor = Color.FromArgb(30, 30, 30);
            btnPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPage.IconSize = 20;
            btnPage.Location = new Point(0, 0);
            btnPage.Name = "btnPage";
            btnPage.Size = new Size(20, 44);
            btnPage.TabIndex = 0;
            btnPage.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPage.UseVisualStyleBackColor = false;
            // 
            // panelNavbar
            // 
            panelNavbar.BackColor = Color.Transparent;
            panelNavbar.Controls.Add(labelName);
            panelNavbar.Controls.Add(btnMinimize);
            panelNavbar.Controls.Add(btnRestoreDown);
            panelNavbar.Controls.Add(btnExit);
            panelNavbar.Dock = DockStyle.Top;
            panelNavbar.ForeColor = Color.Transparent;
            panelNavbar.Location = new Point(250, 0);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(650, 25);
            panelNavbar.TabIndex = 0;
            panelNavbar.MouseDown += PanelNavbar_MouseDown;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.Transparent;
            labelName.Font = new Font("Century Gothic", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelName.ForeColor = Color.FromArgb(30, 30, 30);
            labelName.Location = new Point(6, 5);
            labelName.Name = "labelName";
            labelName.Size = new Size(77, 16);
            labelName.TabIndex = 0;
            labelName.Text = "Tên Công Ty";
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnMinimize.IconColor = Color.DarkOrange;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMinimize.IconSize = 25;
            btnMinimize.Location = new Point(575, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(25, 25);
            btnMinimize.TabIndex = 1;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnRestoreDown
            // 
            btnRestoreDown.Dock = DockStyle.Right;
            btnRestoreDown.FlatAppearance.BorderSize = 0;
            btnRestoreDown.FlatStyle = FlatStyle.Flat;
            btnRestoreDown.IconChar = FontAwesome.Sharp.IconChar.CircleStop;
            btnRestoreDown.IconColor = Color.DarkOrange;
            btnRestoreDown.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnRestoreDown.IconSize = 25;
            btnRestoreDown.Location = new Point(600, 0);
            btnRestoreDown.Name = "btnRestoreDown";
            btnRestoreDown.Size = new Size(25, 25);
            btnRestoreDown.TabIndex = 2;
            btnRestoreDown.UseVisualStyleBackColor = false;
            btnRestoreDown.Click += btnRestoreDown_Click;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.DarkOrange;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(625, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(25, 25);
            btnExit.TabIndex = 3;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DarkOrange;
            panelMenu.Controls.Add(btnCaiDat);
            panelMenu.Controls.Add(btnThongKe);
            panelMenu.Controls.Add(btnDonHang);
            panelMenu.Controls.Add(btnHopDong);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Controls.Add(panelExpand);
            panelMenu.Controls.Add(btnLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(250, 550);
            panelMenu.TabIndex = 0;
            // 
            // btnCaiDat
            // 
            btnCaiDat.BackColor = Color.DarkOrange;
            btnCaiDat.Cursor = Cursors.Hand;
            btnCaiDat.Dock = DockStyle.Top;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnCaiDat.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCaiDat.ForeColor = Color.White;
            btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnCaiDat.IconColor = Color.White;
            btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCaiDat.IconSize = 40;
            btnCaiDat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaiDat.Location = new Point(0, 365);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Padding = new Padding(5, 0, 20, 0);
            btnCaiDat.Size = new Size(250, 65);
            btnCaiDat.TabIndex = 11;
            btnCaiDat.Text = "Cài đặt";
            btnCaiDat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCaiDat.UseVisualStyleBackColor = false;
            btnCaiDat.Click += btnCaiDat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.DarkOrange;
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            btnThongKe.IconColor = Color.White;
            btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThongKe.IconSize = 40;
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(0, 300);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Padding = new Padding(5, 0, 20, 0);
            btnThongKe.Size = new Size(250, 65);
            btnThongKe.TabIndex = 9;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnDonHang
            // 
            btnDonHang.BackColor = Color.DarkOrange;
            btnDonHang.Cursor = Cursors.Hand;
            btnDonHang.Dock = DockStyle.Top;
            btnDonHang.FlatAppearance.BorderSize = 0;
            btnDonHang.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnDonHang.FlatStyle = FlatStyle.Flat;
            btnDonHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDonHang.ForeColor = Color.White;
            btnDonHang.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            btnDonHang.IconColor = Color.White;
            btnDonHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDonHang.IconSize = 40;
            btnDonHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnDonHang.Location = new Point(0, 235);
            btnDonHang.Name = "btnDonHang";
            btnDonHang.Padding = new Padding(5, 0, 20, 0);
            btnDonHang.Size = new Size(250, 65);
            btnDonHang.TabIndex = 8;
            btnDonHang.Text = "Danh sách đơn hàng";
            btnDonHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDonHang.UseVisualStyleBackColor = false;
            btnDonHang.Click += btnDonHang_Click;
            // 
            // btnHopDong
            // 
            btnHopDong.BackColor = Color.DarkOrange;
            btnHopDong.Cursor = Cursors.Hand;
            btnHopDong.Dock = DockStyle.Top;
            btnHopDong.FlatAppearance.BorderSize = 0;
            btnHopDong.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnHopDong.FlatStyle = FlatStyle.Flat;
            btnHopDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHopDong.ForeColor = Color.White;
            btnHopDong.IconChar = FontAwesome.Sharp.IconChar.EnvelopesBulk;
            btnHopDong.IconColor = Color.White;
            btnHopDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHopDong.IconSize = 40;
            btnHopDong.ImageAlign = ContentAlignment.MiddleLeft;
            btnHopDong.Location = new Point(0, 170);
            btnHopDong.Name = "btnHopDong";
            btnHopDong.Padding = new Padding(5, 0, 20, 0);
            btnHopDong.Size = new Size(250, 65);
            btnHopDong.TabIndex = 7;
            btnHopDong.Text = "Danh sách hợp đồng";
            btnHopDong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHopDong.UseVisualStyleBackColor = false;
            btnHopDong.Click += btnHopDong_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.DarkOrange;
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnHome.IconColor = Color.White;
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 40;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 105);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(5, 0, 20, 0);
            btnHome.Size = new Size(250, 65);
            btnHome.TabIndex = 6;
            btnHome.Text = "Trang chủ";
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelExpand
            // 
            panelExpand.BackColor = Color.Transparent;
            panelExpand.Controls.Add(btnMenu);
            panelExpand.Dock = DockStyle.Top;
            panelExpand.ForeColor = Color.Transparent;
            panelExpand.Location = new Point(0, 65);
            panelExpand.Name = "panelExpand";
            panelExpand.Size = new Size(250, 40);
            panelExpand.TabIndex = 20;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.DarkOrange;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Dock = DockStyle.Right;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenu.ForeColor = Color.White;
            btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            btnMenu.IconColor = Color.White;
            btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenu.IconSize = 40;
            btnMenu.Location = new Point(210, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(40, 40);
            btnMenu.TabIndex = 5;
            btnMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnLogo
            // 
            btnLogo.BackColor = Color.DarkOrange;
            btnLogo.Cursor = Cursors.Hand;
            btnLogo.Dock = DockStyle.Top;
            btnLogo.FlatAppearance.BorderSize = 0;
            btnLogo.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnLogo.FlatStyle = FlatStyle.Flat;
            btnLogo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogo.ForeColor = Color.White;
            btnLogo.IconChar = FontAwesome.Sharp.IconChar.Cat;
            btnLogo.IconColor = Color.White;
            btnLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogo.IconSize = 50;
            btnLogo.Location = new Point(0, 0);
            btnLogo.Name = "btnLogo";
            btnLogo.Size = new Size(250, 65);
            btnLogo.TabIndex = 0;
            btnLogo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogo.UseVisualStyleBackColor = false;
            // 
            // menuTimer
            // 
            menuTimer.Interval = 30;
            menuTimer.Tick += menuTimer_Tick;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 550);
            Controls.Add(panelMain);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "fMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += fMain_Load;
            BackColorChanged += home_BackColorChanged;
            Resize += fMain_Resize;
            panelMain.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelPage.PerformLayout();
            panelNavbar.ResumeLayout(false);
            panelNavbar.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelExpand.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMain;
        private Panel panelExpand;
        private Panel panelNavbar;
        private Panel panelPage;
        private Panel panelBody;
        private Label labelName;
        private Label labelPage;
        private FontAwesome.Sharp.IconButton btnPage;
        private FontAwesome.Sharp.IconButton btnNoti;
        private FontAwesome.Sharp.IconButton btnLogo;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnHopDong;
        private FontAwesome.Sharp.IconButton btnDonHang;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private System.Windows.Forms.Timer menuTimer;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnRestoreDown;
        private Panel panelMenu;
    }
}