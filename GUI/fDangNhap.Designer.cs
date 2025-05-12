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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangNhap));
            panelLogin = new Guna.UI2.WinForms.Guna2Panel();
            btnShowPass = new FontAwesome.Sharp.IconButton();
            labelLoginReady = new Label();
            gifLoginButton1 = new PictureBox();
            pictureBox1 = new PictureBox();
            lLabelForgotPass = new LinkLabel();
            chbRemember = new CheckBox();
            btnExit = new FontAwesome.Sharp.IconButton();
            labelLogin = new Label();
            labelError = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            gifLoginButton2 = new PictureBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            gifIntro = new Guna.UI2.WinForms.Guna2PictureBox();
            gifIntro2 = new Guna.UI2.WinForms.Guna2PictureBox();
            gifTakeABreak = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gifLoginButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifLoginButton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifIntro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifIntro2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifTakeABreak).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.AutoRoundedCorners = true;
            panelLogin.BackColor = Color.Transparent;
            panelLogin.BackgroundImageLayout = ImageLayout.None;
            panelLogin.BorderRadius = 413;
            panelLogin.Controls.Add(btnShowPass);
            panelLogin.Controls.Add(labelLoginReady);
            panelLogin.Controls.Add(gifLoginButton1);
            panelLogin.Controls.Add(pictureBox1);
            panelLogin.Controls.Add(lLabelForgotPass);
            panelLogin.Controls.Add(chbRemember);
            panelLogin.Controls.Add(btnExit);
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(labelError);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(gifLoginButton2);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.CustomizableEdges = customizableEdges7;
            panelLogin.Location = new Point(692, 0);
            panelLogin.Margin = new Padding(4, 5, 4, 5);
            panelLogin.Name = "panelLogin";
            panelLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelLogin.Size = new Size(854, 828);
            panelLogin.TabIndex = 6;
            // 
            // btnShowPass
            // 
            btnShowPass.BackColor = SystemColors.ButtonFace;
            btnShowPass.FlatAppearance.BorderSize = 0;
            btnShowPass.FlatStyle = FlatStyle.Flat;
            btnShowPass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            btnShowPass.IconColor = Color.Black;
            btnShowPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnShowPass.Location = new Point(600, 385);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.Size = new Size(52, 45);
            btnShowPass.TabIndex = 35;
            btnShowPass.UseVisualStyleBackColor = false;
            btnShowPass.Click += btnShowPass_Click;
            // 
            // labelLoginReady
            // 
            labelLoginReady.Anchor = AnchorStyles.None;
            labelLoginReady.AutoSize = true;
            labelLoginReady.BackColor = Color.Transparent;
            labelLoginReady.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLoginReady.ForeColor = Color.Black;
            labelLoginReady.Location = new Point(328, 205);
            labelLoginReady.Margin = new Padding(4, 0, 4, 0);
            labelLoginReady.Name = "labelLoginReady";
            labelLoginReady.Size = new Size(191, 54);
            labelLoginReady.TabIndex = 34;
            labelLoginReady.Text = "Sẵn sàng";
            labelLoginReady.TextAlign = ContentAlignment.MiddleCenter;
            labelLoginReady.Visible = false;
            // 
            // gifLoginButton1
            // 
            gifLoginButton1.BackColor = Color.White;
            gifLoginButton1.Image = Properties.Resources.giphy;
            gifLoginButton1.Location = new Point(325, 528);
            gifLoginButton1.Margin = new Padding(4);
            gifLoginButton1.Name = "gifLoginButton1";
            gifLoginButton1.Size = new Size(41, 50);
            gifLoginButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            gifLoginButton1.TabIndex = 30;
            gifLoginButton1.TabStop = false;
            gifLoginButton1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.logonhom_filled_1_shadow;
            pictureBox1.Location = new Point(261, 8);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 194);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // lLabelForgotPass
            // 
            lLabelForgotPass.Anchor = AnchorStyles.None;
            lLabelForgotPass.AutoSize = true;
            lLabelForgotPass.LinkColor = Color.FromArgb(28, 87, 101);
            lLabelForgotPass.Location = new Point(536, 482);
            lLabelForgotPass.Margin = new Padding(2, 0, 2, 0);
            lLabelForgotPass.Name = "lLabelForgotPass";
            lLabelForgotPass.Size = new Size(134, 25);
            lLabelForgotPass.TabIndex = 28;
            lLabelForgotPass.TabStop = true;
            lLabelForgotPass.Text = "Quên mật khẩu";
            lLabelForgotPass.LinkClicked += lLabelForgotPass_LinkClicked;
            // 
            // chbRemember
            // 
            chbRemember.Anchor = AnchorStyles.None;
            chbRemember.AutoSize = true;
            chbRemember.Checked = true;
            chbRemember.CheckState = CheckState.Checked;
            chbRemember.Location = new Point(221, 481);
            chbRemember.Margin = new Padding(2);
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
            btnExit.ForeColor = Color.Red;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.X;
            btnExit.IconColor = Color.Black;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnExit.IconSize = 25;
            btnExit.Location = new Point(814, 0);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 42);
            btnExit.TabIndex = 7;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_Leave;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = Color.Black;
            labelLogin.Location = new Point(308, 205);
            labelLogin.Margin = new Padding(4, 0, 4, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(230, 54);
            labelLogin.TabIndex = 25;
            labelLogin.Text = "Đăng nhập";
            labelLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelError
            // 
            labelError.Anchor = AnchorStyles.None;
            labelError.AutoSize = true;
            labelError.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(269, 452);
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
            txtPassword.CustomizableEdges = customizableEdges1;
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
            txtPassword.Location = new Point(196, 370);
            txtPassword.Margin = new Padding(6, 8, 6, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderForeColor = SystemColors.ControlDark;
            txtPassword.PlaceholderText = "Mật Khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPassword.Size = new Size(476, 75);
            txtPassword.TabIndex = 21;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += activeLoginEffect;
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
            txtUsername.CustomizableEdges = customizableEdges3;
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
            txtUsername.Location = new Point(196, 280);
            txtUsername.Margin = new Padding(6, 8, 6, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = SystemColors.ControlDark;
            txtUsername.PlaceholderText = "Tên Đăng Nhập";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtUsername.Size = new Size(476, 75);
            txtUsername.TabIndex = 20;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            txtUsername.TextChanged += activeLoginEffect;
            // 
            // gifLoginButton2
            // 
            gifLoginButton2.BackColor = Color.White;
            gifLoginButton2.Image = Properties.Resources.giphy;
            gifLoginButton2.Location = new Point(528, 528);
            gifLoginButton2.Margin = new Padding(4);
            gifLoginButton2.Name = "gifLoginButton2";
            gifLoginButton2.Size = new Size(41, 50);
            gifLoginButton2.SizeMode = PictureBoxSizeMode.StretchImage;
            gifLoginButton2.TabIndex = 33;
            gifLoginButton2.TabStop = false;
            gifLoginButton2.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderRadius = 29;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.Transparent;
            btnLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(28, 87, 101);
            btnLogin.HoverState.FillColor = Color.FromArgb(28, 87, 101);
            btnLogin.Location = new Point(310, 518);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(281, 70);
            btnLogin.TabIndex = 31;
            btnLogin.Text = "Đăng nhập";
            btnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseDown += btnLogin_MouseDown;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            btnLogin.MouseUp += btnLogin_MouseUp;
            // 
            // gifIntro
            // 
            gifIntro.BackColor = Color.Transparent;
            gifIntro.CustomizableEdges = customizableEdges9;
            gifIntro.FillColor = Color.Transparent;
            gifIntro.Image = Properties.Resources.gifAnim;
            gifIntro.ImageRotate = 0F;
            gifIntro.Location = new Point(0, 0);
            gifIntro.Margin = new Padding(4);
            gifIntro.Name = "gifIntro";
            gifIntro.ShadowDecoration.CustomizableEdges = customizableEdges10;
            gifIntro.Size = new Size(684, 750);
            gifIntro.SizeMode = PictureBoxSizeMode.StretchImage;
            gifIntro.TabIndex = 7;
            gifIntro.TabStop = false;
            // 
            // gifIntro2
            // 
            gifIntro2.BackColor = Color.FromArgb(33, 49, 90);
            gifIntro2.CustomizableEdges = customizableEdges11;
            gifIntro2.FillColor = Color.Transparent;
            gifIntro2.Image = Properties.Resources.earth2dmotion;
            gifIntro2.ImageRotate = 0F;
            gifIntro2.Location = new Point(0, 0);
            gifIntro2.Margin = new Padding(4);
            gifIntro2.Name = "gifIntro2";
            gifIntro2.ShadowDecoration.CustomizableEdges = customizableEdges12;
            gifIntro2.Size = new Size(684, 750);
            gifIntro2.SizeMode = PictureBoxSizeMode.Zoom;
            gifIntro2.TabIndex = 8;
            gifIntro2.TabStop = false;
            gifIntro2.Visible = false;
            // 
            // gifTakeABreak
            // 
            gifTakeABreak.BackColor = Color.White;
            gifTakeABreak.CustomizableEdges = customizableEdges13;
            gifTakeABreak.FillColor = Color.Transparent;
            gifTakeABreak.Image = Properties.Resources.takeABreak;
            gifTakeABreak.ImageRotate = 0F;
            gifTakeABreak.Location = new Point(0, 0);
            gifTakeABreak.Margin = new Padding(4);
            gifTakeABreak.Name = "gifTakeABreak";
            gifTakeABreak.ShadowDecoration.CustomizableEdges = customizableEdges14;
            gifTakeABreak.Size = new Size(684, 862);
            gifTakeABreak.SizeMode = PictureBoxSizeMode.Zoom;
            gifTakeABreak.TabIndex = 9;
            gifTakeABreak.TabStop = false;
            gifTakeABreak.Visible = false;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // fDangNhap
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1541, 750);
            Controls.Add(panelLogin);
            Controls.Add(gifIntro2);
            Controls.Add(gifIntro);
            Controls.Add(gifTakeABreak);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "fDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Load += login_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gifLoginButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifLoginButton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifIntro).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifIntro2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifTakeABreak).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelLogin;
        private Label labelLogin;
        private Label labelError;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private FontAwesome.Sharp.IconButton btnExit;
        private CheckBox chbRemember;
        private LinkLabel lLabelForgotPass;
        private Guna.UI2.WinForms.Guna2PictureBox gifIntro;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox gifIntro2;
        private Guna.UI2.WinForms.Guna2PictureBox gifTakeABreak;
        private PictureBox gifLoginButton1;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private PictureBox gifLoginButton2;
        private Label labelLoginReady;
        private FontAwesome.Sharp.IconButton btnShowPass;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
