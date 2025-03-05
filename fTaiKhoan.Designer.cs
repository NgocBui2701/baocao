namespace baocao
{
    partial class fTaiKhoan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            panel2 = new Panel();
            btnCancel = new Button();
            btnUpdate = new Button();
            txtID = new TextBox();
            btnChangePassword = new Button();
            txtName = new TextBox();
            txtConfirmPassword = new TextBox();
            labelID = new Label();
            btnChangeInfo = new Button();
            labelConfirmPassword = new Label();
            labelNewPassword = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtNewPassword = new TextBox();
            labelPassword = new Label();
            labelName = new Label();
            txtPhoneNumber = new TextBox();
            labelPhoneNumber = new Label();
            labelEmail = new Label();
            btnLogout = new Button();
            btnAdmin = new Button();
            guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            labelRole = new Label();
            labelUserName = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnAdmin);
            panel1.Controls.Add(guna2CircleButton1);
            panel1.Controls.Add(labelRole);
            panel1.Controls.Add(labelUserName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(txtID);
            panel2.Controls.Add(btnChangePassword);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(txtConfirmPassword);
            panel2.Controls.Add(labelID);
            panel2.Controls.Add(btnChangeInfo);
            panel2.Controls.Add(labelConfirmPassword);
            panel2.Controls.Add(labelNewPassword);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txtNewPassword);
            panel2.Controls.Add(labelPassword);
            panel2.Controls.Add(labelName);
            panel2.Controls.Add(txtPhoneNumber);
            panel2.Controls.Add(labelPhoneNumber);
            panel2.Controls.Add(labelEmail);
            panel2.Location = new Point(124, 72);
            panel2.Name = "panel2";
            panel2.Size = new Size(481, 321);
            panel2.TabIndex = 17;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(322, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 31);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(151, 274);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(124, 31);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtID.Font = new Font("Segoe UI", 9F);
            txtID.Location = new Point(151, 21);
            txtID.Name = "txtID";
            txtID.Size = new Size(295, 23);
            txtID.TabIndex = 2;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePassword.Location = new Point(151, 274);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(124, 31);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.Location = new Point(151, 54);
            txtName.Name = "txtName";
            txtName.Size = new Size(295, 23);
            txtName.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Location = new Point(151, 234);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(295, 23);
            txtConfirmPassword.TabIndex = 14;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // labelID
            // 
            labelID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelID.Location = new Point(50, 24);
            labelID.Name = "labelID";
            labelID.Size = new Size(82, 15);
            labelID.TabIndex = 0;
            labelID.Text = "Mã nhân viên:";
            // 
            // btnChangeInfo
            // 
            btnChangeInfo.Anchor = AnchorStyles.Top;
            btnChangeInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangeInfo.Location = new Point(322, 274);
            btnChangeInfo.Name = "btnChangeInfo";
            btnChangeInfo.Size = new Size(124, 31);
            btnChangeInfo.TabIndex = 7;
            btnChangeInfo.Text = "Sửa thông tin";
            btnChangeInfo.UseVisualStyleBackColor = true;
            btnChangeInfo.Click += btnChangeInfo_Click;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelConfirmPassword.Location = new Point(25, 237);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(107, 15);
            labelConfirmPassword.TabIndex = 13;
            labelConfirmPassword.Text = "Nhập lại mật khẩu:";
            // 
            // labelNewPassword
            // 
            labelNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNewPassword.AutoSize = true;
            labelNewPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelNewPassword.Location = new Point(48, 201);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(84, 15);
            labelNewPassword.TabIndex = 11;
            labelNewPassword.Text = "Mật khẩu mới:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(151, 163);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(295, 23);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(151, 89);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(295, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.Font = new Font("Segoe UI", 9F);
            txtNewPassword.Location = new Point(151, 198);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(295, 23);
            txtNewPassword.TabIndex = 12;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelPassword.Location = new Point(72, 166);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(60, 15);
            labelPassword.TabIndex = 9;
            labelPassword.Text = "Mật khẩu:";
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelName.Location = new Point(86, 57);
            labelName.Name = "labelName";
            labelName.Size = new Size(46, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Họ tên:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Font = new Font("Segoe UI", 9F);
            txtPhoneNumber.Location = new Point(151, 126);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(295, 23);
            txtPhoneNumber.TabIndex = 5;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelPhoneNumber.Location = new Point(52, 129);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(80, 15);
            labelPhoneNumber.TabIndex = 0;
            labelPhoneNumber.Text = "Số điện thoại:";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(93, 92);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.Location = new Point(680, 409);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(108, 29);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatAppearance.MouseDownBackColor = Color.Green;
            btnAdmin.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAdmin.Location = new Point(493, 30);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(258, 36);
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = "phân quyền và quản lý nhân viên";
            btnAdmin.UseVisualStyleBackColor = true;
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.Font = new Font("Segoe UI", 9F);
            guna2CircleButton1.ForeColor = Color.White;
            guna2CircleButton1.Location = new Point(12, 12);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(81, 71);
            guna2CircleButton1.TabIndex = 2;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelRole.Location = new Point(99, 41);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(29, 15);
            labelRole.TabIndex = 0;
            labelRole.Text = "Role";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserName.Location = new Point(99, 16);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(62, 25);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "Name";
            // 
            // fTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fTaiKhoan";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Label labelRole;
        private Label labelUserName;
        private Button btnChangePassword;
        private Label label10;
        private Label label8;
        private Label label6;
        private Button btnAdmin;
        private Button btnLogout;
        private TextBox textBox6;
        private TextBox textBox5;
        private Button btnChangeInfo;
        private Button btnCancel;
        private Button btnUpdate;
        private Panel panel2;
        private Label labelID;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtPassword;
        private Label labelNewPassword;
        private Label labelName;
        private TextBox txtEmail;
        private Label labelPassword;
        private TextBox txtNewPassword;
        private TextBox txtPhoneNumber;
        private Label labelEmail;
        private Label labelConfirmPassword;
        private Label labelPhoneNumber;
        private TextBox txtConfirmPassword;
    }
}