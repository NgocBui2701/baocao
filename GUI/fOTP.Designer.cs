namespace baocao.GUI
{
    partial class fOTP
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            iconBackButton = new FontAwesome.Sharp.IconButton();
            labelEmail = new Label();
            labelOTP = new Label();
            btnOTP = new Button();
            btnVerify = new Button();
            picForgotPass = new PictureBox();
            labelInImage = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)picForgotPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // iconBackButton
            // 
            iconBackButton.BackColor = Color.Transparent;
            iconBackButton.FlatAppearance.BorderSize = 0;
            iconBackButton.FlatStyle = FlatStyle.Flat;
            iconBackButton.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconBackButton.IconColor = Color.FromArgb(28, 87, 101);
            iconBackButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBackButton.Location = new Point(15, 15);
            iconBackButton.Margin = new Padding(4);
            iconBackButton.Name = "iconBackButton";
            iconBackButton.Size = new Size(60, 52);
            iconBackButton.TabIndex = 35;
            iconBackButton.UseVisualStyleBackColor = false;
            iconBackButton.Click += BackButton_Click;
            iconBackButton.MouseEnter += BackButton_MouseEnter;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmail.ForeColor = Color.FromArgb(28, 87, 101);
            labelEmail.Location = new Point(88, 300);
            labelEmail.Margin = new Padding(2, 0, 2, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(76, 32);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email";
            // 
            // labelOTP
            // 
            labelOTP.AutoSize = true;
            labelOTP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelOTP.ForeColor = Color.FromArgb(28, 87, 101);
            labelOTP.Location = new Point(88, 412);
            labelOTP.Margin = new Padding(2, 0, 2, 0);
            labelOTP.Name = "labelOTP";
            labelOTP.Size = new Size(60, 32);
            labelOTP.TabIndex = 2;
            labelOTP.Text = "OTP";
            // 
            // btnOTP
            // 
            btnOTP.BackColor = Color.FromArgb(28, 87, 101);
            btnOTP.FlatAppearance.BorderSize = 0;
            btnOTP.FlatStyle = FlatStyle.Flat;
            btnOTP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOTP.ForeColor = Color.FromArgb(240, 237, 204);
            btnOTP.Location = new Point(605, 342);
            btnOTP.Margin = new Padding(2);
            btnOTP.Name = "btnOTP";
            btnOTP.Size = new Size(121, 44);
            btnOTP.TabIndex = 4;
            btnOTP.Text = "Gửi OTP";
            btnOTP.UseVisualStyleBackColor = false;
            btnOTP.Click += btnOTP_Click;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(28, 87, 101);
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.FromArgb(240, 247, 204);
            btnVerify.Location = new Point(308, 574);
            btnVerify.Margin = new Padding(2);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(121, 41);
            btnVerify.TabIndex = 5;
            btnVerify.Text = "Xác nhận";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // picForgotPass
            // 
            picForgotPass.Image = Properties.Resources.original_69aef49741307f10b2600bde3e86b205;
            picForgotPass.Location = new Point(756, -2);
            picForgotPass.Margin = new Padding(4);
            picForgotPass.Name = "picForgotPass";
            picForgotPass.Size = new Size(788, 750);
            picForgotPass.SizeMode = PictureBoxSizeMode.CenterImage;
            picForgotPass.TabIndex = 6;
            picForgotPass.TabStop = false;
            // 
            // labelInImage
            // 
            labelInImage.AutoSize = true;
            labelInImage.BackColor = Color.FromArgb(186, 255, 253);
            labelInImage.Font = new Font("Segoe UI", 16F);
            labelInImage.Location = new Point(889, 99);
            labelInImage.Margin = new Padding(4, 0, 4, 0);
            labelInImage.Name = "labelInImage";
            labelInImage.Size = new Size(527, 90);
            labelInImage.TabIndex = 7;
            labelInImage.Text = "Let’s your brain gets password, \ndon't let’s password gets your brain";
            labelInImage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(28, 87, 101);
            label1.Location = new Point(130, 166);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(447, 62);
            label1.TabIndex = 8;
            label1.Text = "Keep Your Password";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.logonhom_filled_1_shadow;
            pictureBox2.Location = new Point(194, -2);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(350, 194);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 30;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(28, 87, 101);
            label2.Location = new Point(275, 231);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(194, 32);
            label2.TabIndex = 31;
            label2.Text = "Forgot Password";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.AutoRoundedCorners = true;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.Empty;
            txtEmail.BorderRadius = 25;
            txtEmail.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtEmail.BorderThickness = 0;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.Gainsboro;
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(88, 342);
            txtEmail.Margin = new Padding(6, 8, 6, 8);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = SystemColors.ControlDark;
            txtEmail.PlaceholderText = "abcxyz@mail.com";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(488, 52);
            txtEmail.TabIndex = 33;
            // 
            // txtOTP
            // 
            txtOTP.Anchor = AnchorStyles.None;
            txtOTP.AutoRoundedCorners = true;
            txtOTP.BackColor = Color.Transparent;
            txtOTP.BorderColor = Color.Empty;
            txtOTP.BorderRadius = 25;
            txtOTP.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtOTP.BorderThickness = 0;
            txtOTP.CustomizableEdges = customizableEdges3;
            txtOTP.DefaultText = "";
            txtOTP.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtOTP.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtOTP.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtOTP.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtOTP.FillColor = Color.Gainsboro;
            txtOTP.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOTP.Font = new Font("Segoe UI", 9F);
            txtOTP.ForeColor = Color.Black;
            txtOTP.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOTP.Location = new Point(88, 455);
            txtOTP.Margin = new Padding(6, 8, 6, 8);
            txtOTP.Name = "txtOTP";
            txtOTP.PlaceholderForeColor = SystemColors.ControlDark;
            txtOTP.PlaceholderText = "abcxyz@mail.com";
            txtOTP.SelectedText = "";
            txtOTP.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtOTP.Size = new Size(488, 52);
            txtOTP.TabIndex = 34;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // fOTP
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 237, 204);
            ClientSize = new Size(1541, 750);
            Controls.Add(iconBackButton);
            Controls.Add(txtOTP);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(labelInImage);
            Controls.Add(picForgotPass);
            Controls.Add(btnVerify);
            Controls.Add(btnOTP);
            Controls.Add(labelOTP);
            Controls.Add(labelEmail);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "fOTP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quên mật khẩu";
            ((System.ComponentModel.ISupportInitialize)picForgotPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmail;
        private Label labelOTP;
        private Button btnOTP;
        private Button btnVerify;
        private PictureBox picForgotPass;
        private Label labelInImage;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private FontAwesome.Sharp.IconButton iconBackButton;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}