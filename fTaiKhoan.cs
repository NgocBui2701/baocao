using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DTO;
using baocao.DAO;

namespace baocao
{
    public partial class fTaiKhoan : Form
    {
        private Account loginAccount;
        public Account GetLoginAccount()
        {
            return loginAccount;
        }
        public void SetLoginAccount(Account acc)
        {
            loginAccount = acc;
            changeAccount(loginAccount);
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhoneNumber.Enabled = false;
            labelPassword.Visible = false;
            labelNewPassword.Visible = false;
            labelConfirmPassword.Visible = false;
            txtPassword.Visible = false;
            txtNewPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnChangePassword.Visible = true;
            btnChangeInfo.Visible = true;
            btnAdmin.Enabled = loginAccount.VaiTro == "Quản trị viên";
            btnLogout.Enabled = true;
        }
        public fTaiKhoan(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            SetLoginAccount(loginAccount);
        }
        private void changeAccount(Account acc)
        {
            labelUserName.Text = acc.TenDangNhap;
            labelRole.Text = acc.VaiTro;
            txtID.Text = acc.MaNguoiDung;
            txtName.Text = acc.Ten;
            txtEmail.Text = acc.Email;
            txtPhoneNumber.Text = acc.Sdt;
        }
        private void updateAccount()
        {
            string username = loginAccount.TenDangNhap;
            string id = txtID.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhoneNumber.Text;
            string password = txtPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Mật khẩu mới không khớp");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, id, name, email, phone, password, newPassword))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (loginAccount.TenDangNhap.Equals(username))
                    {
                        loginAccount = AccountDAO.Instance.GetAccountByUsername(username);
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
        public void enableAdmin(bool isAdmin)
        {
            btnAdmin.Enabled = isAdmin;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void updateMode()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnChangeInfo.Visible = false;
            btnChangePassword.Visible = false;
            txtPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            btnAdmin.Enabled = false;
            btnLogout.Enabled = false;
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = true;
            labelNewPassword.Visible = true;
            labelConfirmPassword.Visible = true;
            txtPassword.Visible = true;
            txtNewPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            updateMode();
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhoneNumber.Enabled = true;
            labelPassword.Visible = true;
            txtPassword.Visible = true;
            updateMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetLoginAccount(loginAccount);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
