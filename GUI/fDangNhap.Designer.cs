namespace baocao.GUI
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLogin = new Guna.UI2.WinForms.Guna2Panel();
            chbRemember = new CheckBox();
            btnExit = new FontAwesome.Sharp.IconButton();
            labelLogin = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            labelError = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            picGIF = new PictureBox();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGIF).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.AutoRoundedCorners = true;
            panelLogin.BackColor = Color.Transparent;
            panelLogin.BackgroundImageLayout = ImageLayout.None;
            panelLogin.BorderRadius = 412;
            panelLogin.Controls.Add(chbRemember);
            panelLogin.Controls.Add(btnExit);
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(labelError);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.CustomizableEdges = customizableEdges7;
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(643, 0);
            panelLogin.Margin = new Padding(4, 5, 4, 5);
            panelLogin.Name = "panelLogin";
            panelLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelLogin.Size = new Size(898, 827);
            panelLogin.TabIndex = 6;
            // 
            // chbRemember
            // 
            chbRemember.Anchor = AnchorStyles.None;
            chbRemember.AutoSize = true;
            chbRemember.Checked = true;
            chbRemember.CheckState = CheckState.Checked;
            chbRemember.Location = new Point(245, 456);
            chbRemember.Name = "chbRemember";
            chbRemember.Size = new Size(178, 29);
            chbRemember.TabIndex = 27;
            chbRemember.Text = "Ghi nhớ tài khoản";
            chbRemember.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnExit.IconColor = Color.FromArgb(73, 253, 205);
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(858, 5);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 42);
            btnExit.TabIndex = 7;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = Color.Black;
            labelLogin.Location = new Point(339, 205);
            labelLogin.Margin = new Padding(4, 0, 4, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(230, 54);
            labelLogin.TabIndex = 25;
            labelLogin.Text = "Đăng nhập";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.Animated = true;
            btnLogin.AutoRoundedCorners = true;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(0, 192, 0);
            btnLogin.FillColor2 = Color.FromArgb(0, 181, 136);
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            btnLogin.Location = new Point(289, 509);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(336, 75);
            btnLogin.TabIndex = 26;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseDown += btnLogin_MouseDown;
            btnLogin.MouseUp += btnLogin_MouseUp;
            // 
            // labelError
            // 
            labelError.Anchor = AnchorStyles.None;
            labelError.AutoSize = true;
            labelError.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(271, 589);
            labelError.Margin = new Padding(4, 0, 4, 0);
            labelError.Name = "labelError";
            labelError.Size = new Size(354, 25);
            labelError.TabIndex = 23;
            labelError.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.AutoRoundedCorners = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.Empty;
            txtPassword.BorderRadius = 36;
            txtPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtPassword.BorderThickness = 0;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = SystemColors.ButtonFace;
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(217, 370);
            txtPassword.Margin = new Padding(6, 8, 6, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = SystemColors.ControlDark;
            txtPassword.PlaceholderText = "Mật Khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(476, 75);
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
            txtUsername.BorderRadius = 36;
            txtUsername.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtUsername.BorderThickness = 0;
            txtUsername.CustomizableEdges = customizableEdges5;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FillColor = SystemColors.ButtonFace;
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(217, 279);
            txtUsername.Margin = new Padding(6, 8, 6, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = SystemColors.ControlDark;
            txtUsername.PlaceholderText = "Tên Đăng Nhập";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUsername.Size = new Size(476, 75);
            txtUsername.TabIndex = 20;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // picGIF
            // 
            picGIF.Dock = DockStyle.Left;
            picGIF.Location = new Point(0, 0);
            picGIF.Name = "picGIF";
            picGIF.Size = new Size(643, 827);
            picGIF.SizeMode = PictureBoxSizeMode.CenterImage;
            picGIF.TabIndex = 7;
            picGIF.TabStop = false;
            // 
            // fDangNhap
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1541, 827);
            Controls.Add(panelLogin);
            Controls.Add(picGIF);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Load += login_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGIF).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelLogin;
        private Label labelLogin;
        private Label labelError;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private FontAwesome.Sharp.IconButton btnExit;
        private CheckBox chbRemember;
        private PictureBox picGIF;
    }
}
