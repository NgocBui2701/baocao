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
        public fDangNhap()
        {
            InitializeComponent();
            ImageAnimator.Animate(picGIF.Image, OnFrameChanged);
            ApplyDarkMode(DarkModeManager.IsDarkMode);
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
                btnLogin.ForeColor = Color.White;
                labelError.ForeColor = Color.Red;
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
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login(userName, password))
            {
                Account loginAccount = AccountBLL.Instance.GetAccountByUsername(userName);
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
        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            btnLogin.Size = new Size(329, 70);
        }
        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.Size = new Size(336, 75);
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            picGIF.Invalidate();
        }
        #endregion

    }
}
