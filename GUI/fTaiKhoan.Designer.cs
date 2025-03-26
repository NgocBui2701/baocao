namespace baocao.GUI
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
            btnReturn = new FontAwesome.Sharp.IconButton();
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
            guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            labelRole = new Label();
            labelUserName = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.IconChar = FontAwesome.Sharp.IconChar.Reply;
            btnReturn.IconColor = Color.FromArgb(3, 82, 101);
            btnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReturn.IconSize = 25;
            btnReturn.Location = new Point(26, 30);
            btnReturn.Margin = new Padding(4, 5, 4, 5);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(40, 42);
            btnReturn.TabIndex = 24;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
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
            panel2.Location = new Point(203, 122);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(698, 554);
            panel2.TabIndex = 23;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(452, 463);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(177, 52);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(208, 463);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(177, 52);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtID.Font = new Font("Segoe UI", 9F);
            txtID.Location = new Point(207, 40);
            txtID.Margin = new Padding(4, 5, 4, 5);
            txtID.Name = "txtID";
            txtID.Size = new Size(422, 31);
            txtID.TabIndex = 2;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePassword.Location = new Point(208, 463);
            btnChangePassword.Margin = new Padding(4, 5, 4, 5);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(177, 52);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.Location = new Point(207, 95);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(422, 31);
            txtName.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Location = new Point(207, 395);
            txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(422, 31);
            txtConfirmPassword.TabIndex = 14;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // labelID
            // 
            labelID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelID.Location = new Point(71, 40);
            labelID.Margin = new Padding(4, 0, 4, 0);
            labelID.Name = "labelID";
            labelID.Size = new Size(128, 25);
            labelID.TabIndex = 0;
            labelID.Text = "Mã nhân viên:";
            // 
            // btnChangeInfo
            // 
            btnChangeInfo.Anchor = AnchorStyles.Top;
            btnChangeInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangeInfo.Location = new Point(452, 463);
            btnChangeInfo.Margin = new Padding(4, 5, 4, 5);
            btnChangeInfo.Name = "btnChangeInfo";
            btnChangeInfo.Size = new Size(177, 52);
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
            labelConfirmPassword.Location = new Point(36, 395);
            labelConfirmPassword.Margin = new Padding(4, 0, 4, 0);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(165, 25);
            labelConfirmPassword.TabIndex = 13;
            labelConfirmPassword.Text = "Nhập lại mật khẩu:";
            // 
            // labelNewPassword
            // 
            labelNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNewPassword.AutoSize = true;
            labelNewPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelNewPassword.Location = new Point(69, 335);
            labelNewPassword.Margin = new Padding(4, 0, 4, 0);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(130, 25);
            labelNewPassword.TabIndex = 11;
            labelNewPassword.Text = "Mật khẩu mới:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(207, 277);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(422, 31);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(207, 153);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(422, 31);
            txtEmail.TabIndex = 4;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.Font = new Font("Segoe UI", 9F);
            txtNewPassword.Location = new Point(207, 335);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(422, 31);
            txtNewPassword.TabIndex = 12;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelPassword.Location = new Point(103, 277);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(93, 25);
            labelPassword.TabIndex = 9;
            labelPassword.Text = "Mật khẩu:";
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelName.Location = new Point(123, 95);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(73, 25);
            labelName.TabIndex = 0;
            labelName.Text = "Họ tên:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Font = new Font("Segoe UI", 9F);
            txtPhoneNumber.Location = new Point(207, 215);
            txtPhoneNumber.Margin = new Padding(4, 5, 4, 5);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(422, 31);
            txtPhoneNumber.TabIndex = 5;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelPhoneNumber.Location = new Point(74, 215);
            labelPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(126, 25);
            labelPhoneNumber.TabIndex = 0;
            labelPhoneNumber.Text = "Số điện thoại:";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(133, 153);
            labelEmail.Margin = new Padding(4, 0, 4, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(60, 25);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.Location = new Point(963, 672);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(154, 48);
            btnLogout.TabIndex = 22;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.Font = new Font("Segoe UI", 9F);
            guna2CircleButton1.ForeColor = Color.White;
            guna2CircleButton1.Location = new Point(116, 50);
            guna2CircleButton1.Margin = new Padding(4, 5, 4, 5);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(79, 92);
            guna2CircleButton1.TabIndex = 21;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelRole.Location = new Point(203, 92);
            labelRole.Margin = new Padding(4, 0, 4, 0);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(46, 25);
            labelRole.TabIndex = 19;
            labelRole.Text = "Role";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserName.Location = new Point(203, 50);
            labelUserName.Margin = new Padding(4, 0, 4, 0);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(94, 40);
            labelUserName.TabIndex = 20;
            labelUserName.Text = "Name";
            // 
            // fTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnReturn);
            Controls.Add(panel2);
            Controls.Add(btnLogout);
            Controls.Add(guna2CircleButton1);
            Controls.Add(labelRole);
            Controls.Add(labelUserName);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fTaiKhoan";
            Text = "Form1";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label10;
        private Label label8;
        private Label label6;
        private TextBox textBox6;
        private TextBox textBox5;
        private FontAwesome.Sharp.IconButton btnReturn;
        private Panel panel2;
        private Button btnCancel;
        private Button btnUpdate;
        private TextBox txtID;
        private Button btnChangePassword;
        private TextBox txtName;
        private TextBox txtConfirmPassword;
        private Label labelID;
        private Button btnChangeInfo;
        private Label labelConfirmPassword;
        private Label labelNewPassword;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtNewPassword;
        private Label labelPassword;
        private Label labelName;
        private TextBox txtPhoneNumber;
        private Label labelPhoneNumber;
        private Label labelEmail;
        private Button btnLogout;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Label labelRole;
        private Label labelUserName;
    }
}