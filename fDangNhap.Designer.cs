namespace baocao
{
    partial class fDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLogin = new Guna.UI2.WinForms.Guna2Panel();
            btnCircle = new Guna.UI2.WinForms.Guna2CircleButton();
            labelLogin = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            labelError = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            labelTitle = new Label();
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            panel1 = new Panel();
            panelLogin.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.AutoRoundedCorners = true;
            panelLogin.BackColor = Color.Transparent;
            panelLogin.BackgroundImageLayout = ImageLayout.None;
            panelLogin.BorderRadius = 295;
            panelLogin.Controls.Add(btnCircle);
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(labelError);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(labelTitle);
            panelLogin.CustomizableEdges = customizableEdges8;
            panelLogin.Location = new Point(742, 3);
            panelLogin.Name = "panelLogin";
            panelLogin.ShadowDecoration.CustomizableEdges = customizableEdges9;
            panelLogin.Size = new Size(592, 782);
            panelLogin.TabIndex = 6;
            // 
            // btnCircle
            // 
            btnCircle.BorderColor = Color.OrangeRed;
            btnCircle.BorderThickness = 1;
            btnCircle.DisabledState.BorderColor = Color.OrangeRed;
            btnCircle.DisabledState.CustomBorderColor = Color.OrangeRed;
            btnCircle.DisabledState.FillColor = Color.Transparent;
            btnCircle.DisabledState.ForeColor = Color.Transparent;
            btnCircle.FillColor = Color.Transparent;
            btnCircle.Font = new Font("Segoe UI", 9F);
            btnCircle.ForeColor = Color.White;
            btnCircle.Location = new Point(229, 133);
            btnCircle.Name = "btnCircle";
            btnCircle.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnCircle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnCircle.Size = new Size(120, 120);
            btnCircle.TabIndex = 27;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = Color.Black;
            labelLogin.Location = new Point(264, 293);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(59, 25);
            labelLogin.TabIndex = 25;
            labelLogin.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.Animated = true;
            btnLogin.AutoRoundedCorners = true;
            btnLogin.CustomizableEdges = customizableEdges2;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.OrangeRed;
            btnLogin.FillColor2 = Color.Gold;
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            btnLogin.Location = new Point(178, 475);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnLogin.Size = new Size(235, 45);
            btnLogin.TabIndex = 26;
            btnLogin.Text = "Log In";
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseDown += btnLogin_MouseDown;
            btnLogin.MouseUp += btnLogin_MouseUp;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(178, 445);
            labelError.Name = "labelError";
            labelError.Size = new Size(235, 15);
            labelError.TabIndex = 23;
            labelError.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.AutoRoundedCorners = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.Empty;
            txtPassword.BorderRadius = 21;
            txtPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtPassword.BorderThickness = 0;
            txtPassword.CustomizableEdges = customizableEdges4;
            txtPassword.DefaultText = "12345678";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = SystemColors.ButtonFace;
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(130, 397);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = SystemColors.ControlDark;
            txtPassword.PlaceholderText = "Mật Khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtPassword.Size = new Size(333, 45);
            txtPassword.TabIndex = 21;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.AutoRoundedCorners = true;
            txtUsername.BackColor = Color.Transparent;
            txtUsername.BorderColor = Color.Empty;
            txtUsername.BorderRadius = 21;
            txtUsername.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtUsername.BorderThickness = 0;
            txtUsername.CustomizableEdges = customizableEdges6;
            txtUsername.DefaultText = "ngocbui2701";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FillColor = SystemColors.ButtonFace;
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(130, 336);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = SystemColors.ControlDark;
            txtUsername.PlaceholderText = "Tên Đăng Nhập";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtUsername.Size = new Size(333, 45);
            txtUsername.TabIndex = 20;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.None;
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(229, 256);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(127, 37);
            labelTitle.TabIndex = 19;
            labelTitle.Text = "Welcome";
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ControlDark;
            btnExit.ImageSize = new Size(30, 30);
            btnExit.Location = new Point(1337, 2);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(30, 30);
            btnExit.TabIndex = 0;
            btnExit.Text = "X";
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.bg;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(panelLogin);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 788);
            panel1.TabIndex = 11;
            // 
            // fDangNhap
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnExit;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += login_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelLogin;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private Label labelLogin;
        private Label labelError;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Label labelTitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2CircleButton btnCircle;
        private Panel panel1;
    }
}
