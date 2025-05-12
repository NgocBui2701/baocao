namespace baocao.GUI
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
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
            btnManage = new FontAwesome.Sharp.IconButton();
            btnGuide = new FontAwesome.Sharp.IconButton();
            btnCaiDat = new FontAwesome.Sharp.IconButton();
            btnThongKe = new FontAwesome.Sharp.IconButton();
            btnDonHang = new FontAwesome.Sharp.IconButton();
            btnHopDong = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panelExpand = new Panel();
            btnMenu = new FontAwesome.Sharp.IconButton();
            panelUser = new Panel();
            btnUser = new FontAwesome.Sharp.IconButton();
            labelUser = new Label();
            panelLogo = new Panel();
            picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            menuTimer = new System.Windows.Forms.Timer(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panelMain.SuspendLayout();
            panelPage.SuspendLayout();
            panelNavbar.SuspendLayout();
            panelMenu.SuspendLayout();
            panelExpand.SuspendLayout();
            panelUser.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
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
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1714, 1000);
            panelMain.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.Transparent;
            panelBody.BackgroundImage = Properties.Resources.logo60Opa;
            panelBody.BackgroundImageLayout = ImageLayout.Zoom;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Font = new Font("Segoe UI", 12F);
            panelBody.Location = new Point(357, 115);
            panelBody.Margin = new Padding(4, 5, 4, 5);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1357, 885);
            panelBody.TabIndex = 0;
            // 
            // panelPage
            // 
            panelPage.Controls.Add(btnNoti);
            panelPage.Controls.Add(labelPage);
            panelPage.Controls.Add(btnPage);
            panelPage.Dock = DockStyle.Top;
            panelPage.Location = new Point(357, 42);
            panelPage.Margin = new Padding(4, 5, 4, 5);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1357, 73);
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
            btnNoti.IconColor = Color.FromArgb(240, 237, 204);
            btnNoti.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnNoti.IconSize = 50;
            btnNoti.Location = new Point(1171, 0);
            btnNoti.Margin = new Padding(4, 5, 4, 5);
            btnNoti.Name = "btnNoti";
            btnNoti.Size = new Size(186, 73);
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
            labelPage.ForeColor = Color.FromArgb(240, 237, 204);
            labelPage.Location = new Point(45, 3);
            labelPage.Margin = new Padding(4, 0, 4, 0);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(98, 25);
            labelPage.TabIndex = 0;
            labelPage.Text = "Trang chủ";
            // 
            // btnPage
            // 
            btnPage.BackColor = Color.Transparent;
            btnPage.Cursor = Cursors.Hand;
            btnPage.FlatAppearance.BorderSize = 0;
            btnPage.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnPage.FlatStyle = FlatStyle.Flat;
            btnPage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPage.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnPage.IconColor = Color.FromArgb(240, 237, 204);
            btnPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPage.IconSize = 20;
            btnPage.Location = new Point(8, 5);
            btnPage.Margin = new Padding(4, 5, 4, 5);
            btnPage.Name = "btnPage";
            btnPage.Size = new Size(29, 25);
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
            panelNavbar.Location = new Point(357, 0);
            panelNavbar.Margin = new Padding(4, 5, 4, 5);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(1357, 42);
            panelNavbar.TabIndex = 0;
            panelNavbar.MouseDown += PanelNavbar_MouseDown;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.Transparent;
            labelName.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelName.ForeColor = Color.FromArgb(240, 237, 204);
            labelName.Location = new Point(8, 9);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(99, 28);
            labelName.TabIndex = 0;
            labelName.Text = "ECOTEST";
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnMinimize.IconColor = Color.FromArgb(240, 237, 204);
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMinimize.IconSize = 25;
            btnMinimize.Location = new Point(1249, 0);
            btnMinimize.Margin = new Padding(4, 5, 4, 5);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(36, 42);
            btnMinimize.TabIndex = 1;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            btnMinimize.MouseEnter += btnNoti_MouseEnter;
            // 
            // btnRestoreDown
            // 
            btnRestoreDown.Dock = DockStyle.Right;
            btnRestoreDown.FlatAppearance.BorderSize = 0;
            btnRestoreDown.FlatStyle = FlatStyle.Flat;
            btnRestoreDown.IconChar = FontAwesome.Sharp.IconChar.CircleStop;
            btnRestoreDown.IconColor = Color.FromArgb(240, 237, 204);
            btnRestoreDown.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnRestoreDown.IconSize = 25;
            btnRestoreDown.Location = new Point(1285, 0);
            btnRestoreDown.Margin = new Padding(4, 5, 4, 5);
            btnRestoreDown.Name = "btnRestoreDown";
            btnRestoreDown.Size = new Size(36, 42);
            btnRestoreDown.TabIndex = 2;
            btnRestoreDown.UseVisualStyleBackColor = false;
            btnRestoreDown.Click += btnRestoreDown_Click;
            btnRestoreDown.MouseEnter += btnNoti_MouseEnter;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.FromArgb(240, 237, 204);
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(1321, 0);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 42);
            btnExit.TabIndex = 3;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnNoti_MouseEnter;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(240, 237, 204);
            panelMenu.Controls.Add(btnManage);
            panelMenu.Controls.Add(btnGuide);
            panelMenu.Controls.Add(btnCaiDat);
            panelMenu.Controls.Add(btnThongKe);
            panelMenu.Controls.Add(btnDonHang);
            panelMenu.Controls.Add(btnHopDong);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Controls.Add(panelExpand);
            panelMenu.Controls.Add(panelUser);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.ForeColor = Color.FromArgb(3, 82, 101);
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(357, 1000);
            panelMenu.TabIndex = 0;
            // 
            // btnManage
            // 
            btnManage.AllowDrop = true;
            btnManage.AutoEllipsis = true;
            btnManage.BackColor = Color.FromArgb(240, 237, 204);
            btnManage.Cursor = Cursors.Hand;
            btnManage.Dock = DockStyle.Top;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManage.ForeColor = Color.FromArgb(3, 82, 101);
            btnManage.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            btnManage.IconColor = Color.FromArgb(3, 82, 101);
            btnManage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManage.IconSize = 40;
            btnManage.ImageAlign = ContentAlignment.MiddleLeft;
            btnManage.Location = new Point(0, 734);
            btnManage.Margin = new Padding(4, 5, 4, 5);
            btnManage.Name = "btnManage";
            btnManage.Padding = new Padding(14, 0, 29, 0);
            btnManage.Size = new Size(357, 79);
            btnManage.TabIndex = 22;
            btnManage.Text = "Quản lý và phân quyền";
            btnManage.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManage.UseVisualStyleBackColor = false;
            btnManage.Click += btnManage_Click;
            // 
            // btnGuide
            // 
            btnGuide.AllowDrop = true;
            btnGuide.AutoEllipsis = true;
            btnGuide.BackColor = Color.FromArgb(240, 237, 204);
            btnGuide.Cursor = Cursors.Hand;
            btnGuide.Dock = DockStyle.Top;
            btnGuide.FlatAppearance.BorderSize = 0;
            btnGuide.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnGuide.FlatStyle = FlatStyle.Flat;
            btnGuide.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuide.ForeColor = Color.FromArgb(3, 82, 101);
            btnGuide.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnGuide.IconColor = Color.FromArgb(3, 82, 101);
            btnGuide.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuide.IconSize = 40;
            btnGuide.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuide.Location = new Point(0, 655);
            btnGuide.Margin = new Padding(4, 5, 4, 5);
            btnGuide.Name = "btnGuide";
            btnGuide.Padding = new Padding(14, 0, 29, 0);
            btnGuide.Size = new Size(357, 79);
            btnGuide.TabIndex = 21;
            btnGuide.Text = "Hướng dẫn sử dụng";
            btnGuide.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuide.UseVisualStyleBackColor = false;
            btnGuide.Click += btnGuide_Click;
            // 
            // btnCaiDat
            // 
            btnCaiDat.AllowDrop = true;
            btnCaiDat.AutoEllipsis = true;
            btnCaiDat.BackColor = Color.FromArgb(240, 237, 204);
            btnCaiDat.Cursor = Cursors.Hand;
            btnCaiDat.Dock = DockStyle.Bottom;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnCaiDat.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCaiDat.ForeColor = Color.FromArgb(3, 82, 101);
            btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnCaiDat.IconColor = Color.FromArgb(3, 82, 101);
            btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCaiDat.IconSize = 40;
            btnCaiDat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaiDat.Location = new Point(0, 921);
            btnCaiDat.Margin = new Padding(4, 5, 4, 5);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Padding = new Padding(14, 0, 29, 0);
            btnCaiDat.Size = new Size(357, 79);
            btnCaiDat.TabIndex = 11;
            btnCaiDat.Text = "Cài đặt";
            btnCaiDat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCaiDat.UseVisualStyleBackColor = false;
            btnCaiDat.Click += btnCaiDat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.AllowDrop = true;
            btnThongKe.AutoEllipsis = true;
            btnThongKe.BackColor = Color.FromArgb(240, 237, 204);
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.FromArgb(3, 82, 101);
            btnThongKe.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            btnThongKe.IconColor = Color.FromArgb(3, 82, 101);
            btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThongKe.IconSize = 40;
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(0, 576);
            btnThongKe.Margin = new Padding(4, 5, 4, 5);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Padding = new Padding(14, 0, 29, 0);
            btnThongKe.Size = new Size(357, 79);
            btnThongKe.TabIndex = 9;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnDonHang
            // 
            btnDonHang.AllowDrop = true;
            btnDonHang.AutoEllipsis = true;
            btnDonHang.BackColor = Color.FromArgb(240, 237, 204);
            btnDonHang.Cursor = Cursors.Hand;
            btnDonHang.Dock = DockStyle.Top;
            btnDonHang.FlatAppearance.BorderSize = 0;
            btnDonHang.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnDonHang.FlatStyle = FlatStyle.Flat;
            btnDonHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDonHang.ForeColor = Color.FromArgb(3, 82, 101);
            btnDonHang.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            btnDonHang.IconColor = Color.FromArgb(3, 82, 101);
            btnDonHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDonHang.IconSize = 40;
            btnDonHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnDonHang.Location = new Point(0, 497);
            btnDonHang.Margin = new Padding(4, 5, 4, 5);
            btnDonHang.Name = "btnDonHang";
            btnDonHang.Padding = new Padding(14, 0, 29, 0);
            btnDonHang.Size = new Size(357, 79);
            btnDonHang.TabIndex = 8;
            btnDonHang.Text = "Danh sách đơn hàng";
            btnDonHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDonHang.UseVisualStyleBackColor = false;
            btnDonHang.Click += btnDonHang_Click;
            // 
            // btnHopDong
            // 
            btnHopDong.AllowDrop = true;
            btnHopDong.AutoEllipsis = true;
            btnHopDong.BackColor = Color.FromArgb(240, 237, 204);
            btnHopDong.Cursor = Cursors.Hand;
            btnHopDong.Dock = DockStyle.Top;
            btnHopDong.FlatAppearance.BorderSize = 0;
            btnHopDong.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnHopDong.FlatStyle = FlatStyle.Flat;
            btnHopDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHopDong.ForeColor = Color.FromArgb(3, 82, 101);
            btnHopDong.IconChar = FontAwesome.Sharp.IconChar.EnvelopesBulk;
            btnHopDong.IconColor = Color.FromArgb(3, 82, 101);
            btnHopDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHopDong.IconSize = 40;
            btnHopDong.ImageAlign = ContentAlignment.MiddleLeft;
            btnHopDong.Location = new Point(0, 418);
            btnHopDong.Margin = new Padding(4, 5, 4, 5);
            btnHopDong.Name = "btnHopDong";
            btnHopDong.Padding = new Padding(14, 0, 29, 0);
            btnHopDong.Size = new Size(357, 79);
            btnHopDong.TabIndex = 7;
            btnHopDong.Text = "Danh sách hợp đồng";
            btnHopDong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHopDong.UseVisualStyleBackColor = false;
            btnHopDong.Click += btnHopDong_Click;
            // 
            // btnHome
            // 
            btnHome.AllowDrop = true;
            btnHome.AutoEllipsis = true;
            btnHome.BackColor = Color.FromArgb(240, 237, 204);
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHome.ForeColor = Color.FromArgb(3, 82, 101);
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnHome.IconColor = Color.FromArgb(3, 82, 101);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 40;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 339);
            btnHome.Margin = new Padding(4, 5, 4, 5);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(14, 0, 29, 0);
            btnHome.Size = new Size(357, 79);
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
            panelExpand.Location = new Point(0, 272);
            panelExpand.Margin = new Padding(4, 5, 4, 5);
            panelExpand.Name = "panelExpand";
            panelExpand.Size = new Size(357, 67);
            panelExpand.TabIndex = 20;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(240, 237, 204);
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Dock = DockStyle.Right;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenu.ForeColor = Color.FromArgb(3, 82, 101);
            btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            btnMenu.IconColor = Color.FromArgb(3, 82, 101);
            btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenu.IconSize = 40;
            btnMenu.Location = new Point(270, 0);
            btnMenu.Margin = new Padding(4, 5, 4, 5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(87, 67);
            btnMenu.TabIndex = 5;
            btnMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(btnUser);
            panelUser.Controls.Add(labelUser);
            panelUser.Dock = DockStyle.Top;
            panelUser.Location = new Point(0, 115);
            panelUser.Name = "panelUser";
            panelUser.Padding = new Padding(100, 0, 100, 0);
            panelUser.Size = new Size(357, 157);
            panelUser.TabIndex = 23;
            // 
            // btnUser
            // 
            btnUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            btnUser.IconColor = Color.FromArgb(3, 82, 101);
            btnUser.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnUser.IconSize = 130;
            btnUser.Location = new Point(100, 0);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(157, 112);
            btnUser.TabIndex = 8;
            btnUser.UseVisualStyleBackColor = true;
            // 
            // labelUser
            // 
            labelUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelUser.AutoSize = true;
            labelUser.BackColor = Color.Transparent;
            labelUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUser.ForeColor = Color.FromArgb(3, 82, 101);
            labelUser.Location = new Point(96, 124);
            labelUser.Margin = new Padding(4, 0, 0, 0);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(161, 28);
            labelUser.TabIndex = 7;
            labelUser.Text = "Tên người dùng";
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.Transparent;
            panelLogo.Controls.Add(picLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(357, 115);
            panelLogo.TabIndex = 24;
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackgroundImage = Properties.Resources.logonhom_filled_1_shadow1;
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.CustomizableEdges = customizableEdges1;
            picLogo.FillColor = Color.Transparent;
            picLogo.Image = Properties.Resources.logonhom_filled_1_shadow1;
            picLogo.ImageRotate = 0F;
            picLogo.Location = new Point(85, 0);
            picLogo.Name = "picLogo";
            picLogo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picLogo.Size = new Size(186, 115);
            picLogo.TabIndex = 25;
            picLogo.TabStop = false;
            // 
            // menuTimer
            // 
            menuTimer.Interval = 10;
            menuTimer.Tick += menuTimer_Tick;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(3, 82, 101);
            ClientSize = new Size(1714, 1000);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "fMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            FormClosed += fMain_FormClosed;
            Load += fMain_Load;
            Resize += fMain_Resize;
            panelMain.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelPage.PerformLayout();
            panelNavbar.ResumeLayout(false);
            panelNavbar.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelExpand.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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
        private FontAwesome.Sharp.IconButton btnManage;
        private FontAwesome.Sharp.IconButton btnGuide;
        private Panel panelUser;
        private Label labelUser;
        private FontAwesome.Sharp.IconButton btnUser;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Panel panelLogo;
    }
}