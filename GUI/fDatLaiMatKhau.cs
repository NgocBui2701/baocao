using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.BLL;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fDatLaiMatKhau : Form
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private string userEmail;
        public fDatLaiMatKhau(string email)
        {
            InitializeComponent();
            userEmail = email;
            langManager.LanguageChanged += LangManager_LanguageChanged;
            this.BackColor = Color.White;
            this.Load += fDatLaiMatKhau_Load;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {

            labelNewPass.Text = langManager.Translate("new_password");
            labelConfirmPass.Text = langManager.Translate("confirm_password");
            btnVerify.Text = langManager.Translate("btn_confirm");

            txtNewPass.PlaceholderText = langManager.Translate("new_password_placeholder");
            txtConfirmPass.PlaceholderText = langManager.Translate("confirm_password_placeholder");
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text;
            string confirmNewPass = txtConfirmPass.Text;
            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmNewPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPass != confirmNewPass)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AccountBLL.Instance.ResetPassword(userEmail, newPass))
            {
                MessageBox.Show("Mật khẩu đã được đặt lại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi đặt lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fDatLaiMatKhau_Load(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
    }
}
