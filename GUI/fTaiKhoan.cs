using baocao.DTO;
using baocao.BLL;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using FontAwesome.Sharp;
using Microsoft.IdentityModel.Tokens;

namespace baocao.GUI
{
    public partial class fTaiKhoan : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private Account loginAccount;
        public Account GetLoginAccount()
        {
            return loginAccount;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {
            this.Text = langManager.Translate("account_form_title");
            btnCancel.Text = langManager.Translate("cancel");
            btnUpdate.Text = langManager.Translate("update");
            labelID.Text = langManager.Translate("employee_id");
            btnChangePassword.Text = langManager.Translate("change_password");
            btnChangeInfo.Text = langManager.Translate("edit_info");
            labelConfirmNewPassword.Text = langManager.Translate("confirm_password");
            labelNewPassword.Text = langManager.Translate("new_password");
            labelPassword.Text = langManager.Translate("password");
            labelName.Text = langManager.Translate("full_name");
            labelPhoneNumber.Text = langManager.Translate("phone_number");
            labelEmail.Text = langManager.Translate("email");
            btnLogout.Text = langManager.Translate("logout");
        }
        public void SetLoginAccount(Account acc)
        {
            loginAccount = acc;
            changeAccount(loginAccount);
            labelPassword.Visible = false;
            labelNewPassword.Visible = false;
            labelConfirmNewPassword.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnChangePwd.Visible = true;
            btnUpdateInfo.Visible = true;
            btnLogout.Enabled = true;
        }
        public fTaiKhoan(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            SetLoginAccount(loginAccount);
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            labelName1.ForeColor = DarkModeManager.GetForeColor();
            labelNameUser.ForeColor = DarkModeManager.GetForeColor();
            labelEmail1.ForeColor = DarkModeManager.GetForeColor();
            labelEmailUser.ForeColor = DarkModeManager.GetForeColor();
            labelID1.ForeColor = DarkModeManager.GetForeColor();
            labelIDUser.ForeColor = DarkModeManager.GetForeColor();
            labelPhone1.ForeColor = DarkModeManager.GetForeColor();
            labelPhoneUser.ForeColor = DarkModeManager.GetForeColor();
            //Left
            labelUserName.Left = (this.Width - labelUserName.Width) / 2;
            labelRoleUser.Left = (this.Width - labelRoleUser.Width) / 2;
            avatar.Left = (this.Width - avatar.Width) / 2;
            //Bottom

        }
        private void changeAccount(Account acc)
        {
            labelUserName.Text = acc.TenDangNhap;
            labelRoleUser.Text = acc.VaiTro;
            labelIDUser.Text = acc.MaNguoiDung;
            labelNameUser.Text = acc.Ten;
            labelEmailUser.Text = acc.Email;
            labelPhoneUser.Text = acc.Sdt;
        }
        protected override void ApplyDarkMode(bool IsDarkMode)
        {
            if (labelUserName != null)
            {
                labelUserName.BackColor = Color.Transparent;
            }
        }
        private void updateAccount()
        {
            string username = loginAccount.TenDangNhap;
            string id = labelIDUser.Text;
            string name = textName.Text;
            string email = textEmail.Text;
            string phone = textPhone.Text;
            string password;
            string newPassword = textNewPassword.Text;
            string confirmPassword = textConfirmNewPassword.Text;
            if (!textUpdateInfoConfirmPassword.Text.IsNullOrEmpty() && textPassword.Text.IsNullOrEmpty())
            {
                password = textUpdateInfoConfirmPassword.Text.ToString().Trim();
                if (AccountBLL.Instance.UpdateOwnAccount(username, id, name, email, phone, password, newPassword))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (loginAccount.TenDangNhap.Equals(username))
                    {
                        loginAccount = AccountBLL.Instance.GetAccountByUsername(username);
                        SetLoginAccount(loginAccount);
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    SetLoginAccount(loginAccount);
                }
            }
            else if (textUpdateInfoConfirmPassword.Text.IsNullOrEmpty() && !textPassword.Text.IsNullOrEmpty())
            {
                password = textPassword.Text.ToString().Trim();
                if (!newPassword.Equals(confirmPassword) || newPassword.IsNullOrEmpty())
                {
                    MessageBox.Show("Mật khẩu mới không khớp");
                }
                else
                {
                    if (AccountBLL.Instance.UpdateOwnAccount(username, id, name, email, phone, password, newPassword))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        if (loginAccount.TenDangNhap.Equals(username))
                        {
                            loginAccount = AccountBLL.Instance.GetAccountByUsername(username);
                            SetLoginAccount(loginAccount);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                        SetLoginAccount(loginAccount);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void enableInfo()
        {
            textEmail.Visible = true;
            textName.Visible = true;
            textPhone.Visible = true;
            textName.Enabled = true;
            textEmail.Enabled = true;
            textPhone.Enabled = true;
            textName.Text = labelNameUser.Text;
            textEmail.Text = labelEmailUser.Text;
            textPhone.Text = labelPhoneUser.Text;
            textPassword.PasswordChar = '*';
        }
        private void updateMode()
        {
            labelNameUser.Visible = false;
            labelEmailUser.Visible = false;
            labelPhoneUser.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnUpdateInfo.Visible = false;
            btnChangePwd.Visible = false;
            textUpdateInfoConfirmPassword.Clear();
            textUpdateInfoConfirmPassword.UseSystemPasswordChar = true;
            textPassword.Clear();
            textNewPassword.Clear();
            textConfirmNewPassword.Clear();
            //labelPhone1.Location = new Point(497, 360);
            //textPhone.Location = new Point(602, 365);
            //labelEmail1.Location = new Point(59, 360);
            //textEmail.Location = new Point(161, 365);
            //txtPassword.Clear();
            //txtNewPassword.Clear();
            //txtConfirmPassword.Clear();

        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = true;
            labelNewPassword.Visible = true;
            labelConfirmNewPassword.Visible = true;
            textPassword.Visible = true;
            textNewPassword.Visible = true;
            textConfirmNewPassword.Visible = true;
            textName.Visible = false;
            labelName1.Visible = false;
            labelNameUser.Visible = false;
            labelEmail1.Visible = false;
            labelEmailUser.Visible = false;
            labelID1.Visible = false;
            labelIDUser.Visible = false;
            labelPhone1.Visible = false;
            labelPhoneUser.Visible = false;
            //textPassword.Location = new Point(292, 304);
            textPassword.UseSystemPasswordChar = true;
            textNewPassword.UseSystemPasswordChar = true;
            textConfirmNewPassword.UseSystemPasswordChar = true;
            textPassword.Clear();
            textNewPassword.Clear();
            textConfirmNewPassword.Clear();
            //labelPassword.Location = new Point(179, 304);
            updateMode();
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            enableInfo();
            labelUpdateInfoConfirmPassword.Visible = true;
            textUpdateInfoConfirmPassword.Visible = true;
            //if (labelEmail1 != null)
            //{
            //    labelEmail1.Location.
            //}
            textPassword.Clear();

            updateMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
            labelPassword.Visible = false;
            labelNewPassword.Visible = false;
            labelConfirmNewPassword.Visible = false;
            textPassword.Visible = false;
            textNewPassword.Visible = false;
            textConfirmNewPassword.Visible = false;
            labelUpdateInfoConfirmPassword.Visible = false;
            textUpdateInfoConfirmPassword.Visible = false;
            textEmail.Visible = false;
            textName.Visible = false;
            textPhone.Visible = false;
            labelName1.Visible = true;
            labelNameUser.Visible = true;
            labelEmail1.Visible = true;
            labelEmailUser.Visible = true;
            labelID1.Visible = true;
            labelIDUser.Visible = true;
            labelPhone1.Visible = true;
            labelPhoneUser.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateInfo.Visible = true;
            btnChangePwd.Visible = true;
            //labelPhone1.Location = new Point(497, 418);
            //labelPhoneUser.Location = new Point(597, 425);
            //labelEmail1.Location = new Point(59, 418);
            //labelEmailUser.Location = new Point(161, 425);
            labelPassword.Visible = false;
            textPassword.Visible = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetLoginAccount(loginAccount);
            labelPassword.Visible = false;
            labelNewPassword.Visible = false;
            labelConfirmNewPassword.Visible = false;
            textPassword.Visible = false;
            textNewPassword.Visible = false;
            textConfirmNewPassword.Visible = false;
            labelUpdateInfoConfirmPassword.Visible = false;
            textUpdateInfoConfirmPassword.Visible = false;
            textEmail.Visible = false;
            textName.Visible = false;
            textPhone.Visible = false;
            labelName1.Visible = true;
            labelNameUser.Visible = true;
            labelEmail1.Visible = true;
            labelEmailUser.Visible = true;
            labelID1.Visible = true;
            labelIDUser.Visible = true;
            labelPhone1.Visible = true;
            labelPhoneUser.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateInfo.Visible = true;
            btnChangePwd.Visible = true;
            //labelPhone1.Location = new Point(497, 418);
            //labelPhoneUser.Location = new Point(597, 425);
            //labelEmail1.Location = new Point(59, 418);
            //labelEmailUser.Location = new Point(161, 425);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
