namespace baocao.GUI
{
    partial class fDatLaiMatKhau
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
            labelNewPass = new Label();
            labelConfirmPass = new Label();
            btnVerify = new Button();
            txtNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            txtConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            labelTitle = new Label();
            pictureBox1 = new PictureBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelNewPass
            // 
            labelNewPass.AutoSize = true;
            labelNewPass.BackColor = Color.White;
            labelNewPass.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            labelNewPass.ForeColor = Color.FromArgb(125, 143, 153);
            labelNewPass.Location = new Point(559, 214);
            labelNewPass.Margin = new Padding(2, 0, 2, 0);
            labelNewPass.Name = "labelNewPass";
            labelNewPass.Size = new Size(146, 30);
            labelNewPass.TabIndex = 0;
            labelNewPass.Text = "Mật khẩu mới";
            // 
            // labelConfirmPass
            // 
            labelConfirmPass.AutoSize = true;
            labelConfirmPass.BackColor = Color.White;
            labelConfirmPass.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            labelConfirmPass.ForeColor = Color.FromArgb(125, 143, 153);
            labelConfirmPass.Location = new Point(473, 304);
            labelConfirmPass.Margin = new Padding(2, 0, 2, 0);
            labelConfirmPass.Name = "labelConfirmPass";
            labelConfirmPass.Size = new Size(228, 30);
            labelConfirmPass.TabIndex = 2;
            labelConfirmPass.Text = "       Confirm Password";
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(125, 143, 153);
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(790, 410);
            btnVerify.Margin = new Padding(2);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(152, 54);
            btnVerify.TabIndex = 5;
            btnVerify.Text = "Xác nhận";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // txtNewPass
            // 
            txtNewPass.Anchor = AnchorStyles.None;
            txtNewPass.AutoRoundedCorners = true;
            txtNewPass.BackColor = Color.White;
            txtNewPass.BorderColor = Color.Empty;
            txtNewPass.BorderRadius = 25;
            txtNewPass.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtNewPass.BorderThickness = 0;
            txtNewPass.CustomizableEdges = customizableEdges1;
            txtNewPass.DefaultText = "";
            txtNewPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNewPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNewPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNewPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNewPass.FillColor = Color.Gainsboro;
            txtNewPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNewPass.Font = new Font("Segoe UI", 9F);
            txtNewPass.ForeColor = Color.Black;
            txtNewPass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNewPass.Location = new Point(712, 201);
            txtNewPass.Margin = new Padding(6, 8, 6, 8);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PlaceholderForeColor = SystemColors.ControlDark;
            txtNewPass.PlaceholderText = "Nhập mật khẩu mới";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtNewPass.Size = new Size(358, 52);
            txtNewPass.TabIndex = 34;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Anchor = AnchorStyles.None;
            txtConfirmPass.AutoRoundedCorners = true;
            txtConfirmPass.BackColor = Color.White;
            txtConfirmPass.BorderColor = Color.Empty;
            txtConfirmPass.BorderRadius = 25;
            txtConfirmPass.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            txtConfirmPass.BorderThickness = 0;
            txtConfirmPass.CustomizableEdges = customizableEdges3;
            txtConfirmPass.DefaultText = "";
            txtConfirmPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtConfirmPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtConfirmPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmPass.FillColor = Color.Gainsboro;
            txtConfirmPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmPass.Font = new Font("Segoe UI", 9F);
            txtConfirmPass.ForeColor = Color.Black;
            txtConfirmPass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmPass.Location = new Point(712, 294);
            txtConfirmPass.Margin = new Padding(6, 8, 6, 8);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PlaceholderForeColor = SystemColors.ControlDark;
            txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới";
            txtConfirmPass.SelectedText = "";
            txtConfirmPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtConfirmPass.Size = new Size(358, 52);
            txtConfirmPass.TabIndex = 35;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.FromArgb(125, 143, 153);
            labelTitle.Location = new Point(739, 92);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(273, 41);
            labelTitle.TabIndex = 36;
            labelTitle.Text = "Tạo mật khẩu mới";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.original_b051d7f598e34fa2ba6c46d304fe0ecc;
            pictureBox1.Location = new Point(-134, -54);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(804, 625);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // fDatLaiMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 555);
            Controls.Add(labelTitle);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            Controls.Add(btnVerify);
            Controls.Add(labelConfirmPass);
            Controls.Add(labelNewPass);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "fDatLaiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quên mật khẩu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNewPass;
        private Label labelConfirmPass;
        private Button btnVerify;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPass;
        private Label labelTitle;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}