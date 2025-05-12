using baocao.BLL;
using System;
using baocao.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using System.Windows.Forms;

namespace baocao.GUI
{
    public partial class fDangNhap : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private bool showPassword = false;
        public fDangNhap()
        {
            InitializeComponent();
            ImageAnimator.Animate(gifIntro.BackgroundImage, OnFrameChanged);
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            lLabelForgotPass.LinkColor = DarkModeManager.GetForeColor();
            lLabelForgotPass.VisitedLinkColor = DarkModeManager.GetForeColor();
            langManager.LanguageChanged += LangManager_LanguageChanged;
            this.Load += login_Load;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        #region Methods
        bool Login(string userName, string password)
        {
            return AccountBLL.Instance.Login(userName, password);
        }
        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            if (txtUsername != null && txtPassword != null)
            {
                txtUsername.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
                btnLogin.ForeColor = DarkModeManager.GetForeColor();
                labelError.ForeColor = Color.Red;
            }
            if (gifTakeABreak != null)
            {
                gifTakeABreak.BackColor = Color.White;
            }
            if (gifIntro2 != null)
            {
                gifIntro2.BackColor = Color.FromArgb(33, 49, 90);
            }
            if (btnShowPass != null)
            {
                btnShowPass.BackColor = txtPassword.FillColor;
            }
        }
        #endregion
        #region Events
        private void login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                chbRemember.Checked = true;
            }
            else
            {
                chbRemember.Checked = false;
            }
            labelError.Visible = false;
            txtUsername.Focus();
            UpdateLanguageTexts();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void activeLoginEffect(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                btnLogin.FillColor = DarkModeManager.GetBackgroundColor();
                btnLogin.ForeColor = DarkModeManager.GetForeColor();
                btnLogin.HoverState.FillColor = DarkModeManager.GetBackgroundColor();
                gifLoginButton1.Visible = false;
                gifLoginButton1.BackColor = DarkModeManager.GetBackgroundColor();
                gifLoginButton2.Visible = false;
                gifLoginButton2.BackColor = DarkModeManager.GetBackgroundColor();
                gifIntro.Visible = true;
                gifIntro2.Visible = false;
                labelLogin.Visible = true;
                labelLoginReady.Visible = false;
            }
            else
            {
                btnLogin.FillColor = DarkModeManager.GetForeColor();
                btnLogin.ForeColor = DarkModeManager.GetBackgroundColor();
                btnLogin.HoverState.FillColor = DarkModeManager.GetForeColor();
                gifLoginButton1.Visible = true;
                gifLoginButton1.BackColor = DarkModeManager.GetForeColor();
                gifLoginButton2.Visible = true;
                gifLoginButton2.BackColor = DarkModeManager.GetForeColor();
                gifIntro.Visible = false;
                gifIntro2.Visible = true;
                labelLogin.Visible = false;
                labelLoginReady.Visible = true;
            }
        }
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.FillColor = DarkModeManager.GetForeColor();
            btnLogin.ForeColor = DarkModeManager.GetBackgroundColor();
            btnLogin.HoverState.FillColor = DarkModeManager.GetForeColor();
            gifLoginButton1.Visible = true;
            gifLoginButton1.BackColor = DarkModeManager.GetForeColor();
            gifLoginButton2.Visible = true;
            gifLoginButton2.BackColor = DarkModeManager.GetForeColor();
            gifIntro.Visible = false;
            gifIntro2.Visible = true;
            labelLogin.Visible = false;
            labelLoginReady.Visible = true;

        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.FillColor = DarkModeManager.GetBackgroundColor();
            gifLoginButton1.Visible = false;
            gifLoginButton1.BackColor = DarkModeManager.GetBackgroundColor();
            gifLoginButton2.Visible = false;
            gifLoginButton2.BackColor = DarkModeManager.GetBackgroundColor();
            btnLogin.HoverState.FillColor = DarkModeManager.GetBackgroundColor();
            btnLogin.ForeColor = DarkModeManager.GetForeColor();
            gifIntro.Visible = true;
            gifIntro2.Visible = false;
            labelLogin.Visible = true;
            labelLoginReady.Visible = false;
        }
        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            gifLoginButton1.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(168, 166, 143) : Color.FromArgb(2, 57, 70);
            gifLoginButton2.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(168, 166, 143) : Color.FromArgb(2, 57, 70);
        }
        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            gifLoginButton1.BackColor = DarkModeManager.GetForeColor();
            gifLoginButton2.BackColor = DarkModeManager.GetForeColor();
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.IconColor = Color.White;
            btnExit.BackColor = Color.Red;
            gifIntro.Visible = false;
            gifIntro2.Visible = false;
            gifTakeABreak.Visible = true;
        }
        private void btnExit_Leave(object sender, EventArgs e)
        {
            btnExit.IconColor = DarkModeManager.GetForeColor();
            btnExit.BackColor = Color.Transparent;
            gifIntro.Visible = true;
            gifIntro2.Visible = false;
            gifTakeABreak.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login(userName, password))
            {
                Account loginAccount = AccountBLL.Instance.GetAccountByUsername(userName);
                PermissionManager.SetRole(loginAccount.VaiTro);
                if (chbRemember.Checked)
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.RememberMe = true;
                }
                else
                {
                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.RememberMe = false;
                }
                Properties.Settings.Default.Save();
                this.Hide();
                fMain homeF = new fMain(loginAccount);
                homeF.ShowDialog();
            }
            else
            {
                labelError.Visible = true;
            }
        }
        private void UpdateLanguageTexts()
        {

            labelLoginReady.Text = langManager.Translate("login_ready");
            lLabelForgotPass.Text = langManager.Translate("forgot_password");
            labelLogin.Text = langManager.Translate("login");
            labelError.Text = langManager.Translate("login_error");
            txtPassword.PlaceholderText = langManager.Translate("password_placeholder");
            txtUsername.PlaceholderText = langManager.Translate("username_placeholder");
            btnLogin.Text = langManager.Translate("btn_login");
            chbRemember.Text = langManager.Translate("remember");

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void OnFrameChanged(Object sender, EventArgs e)
        {
            ImageAnimator.UpdateFrames();
            gifIntro.Invalidate();
        }
        private void lLabelForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fOTP fOTP = new fOTP();
            this.Hide();
            fOTP.ShowDialog();
            this.Show();
        }
        #endregion

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (showPassword)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                showPassword = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
                showPassword = true;
            }
        }

    }
}
