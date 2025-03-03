using baocao.DAO;
using System;
using baocao.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace baocao
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        #region Methods
        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        #endregion
        #region Events
        private void login_Load(object sender, EventArgs e)
        {
            labelError.Visible = false;
            btnCircle.Enabled = false;
            txtUsername.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.FillColor = Color.Red;
            btnExit.ForeColor = Color.White;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.FillColor = Color.Transparent;
            btnExit.ForeColor = Color.DarkGray;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login(userName, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUsername(userName);
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
            btnLogin.FillColor = Color.DarkOrange;
            btnLogin.FillColor2 = Color.Chocolate;
            btnLogin.Size = new Size(230, 40);
        }
        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.FillColor = Color.OrangeRed;
            btnLogin.FillColor2 = Color.Gold;
            btnLogin.Size = new Size(235, 45);
        }
        #endregion
    }
}
