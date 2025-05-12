using System.Net;
using System.Net.Mail;
using baocao.BLL;
using baocao.GUI.Managers;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fOTP : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private string generatedOTP;
        public fOTP()
        {
            InitializeComponent();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            //4/5/2025
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
        }
        protected void ApplyDarkMode(bool IsDarkMode)
        {
            picForgotPass.BackColor = Color.FromArgb(196, 255, 253);
        }
        private void btnOTP_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AccountBLL.Instance.IsEmailExist(userEmail))
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            generatedOTP = GenerateOTP();
            if (SendOTPEmail(userEmail, generatedOTP))
            {
                MessageBox.Show("Mã OTP đã được gửi. Vui lòng kiểm tra email!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể gửi OTP. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
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
            labelEmail.Text = langManager.Translate("email");
            label1.Text = langManager.Translate("keep_your_password");
            label2.Text = langManager.Translate("forgot_password");
            btnOTP.Text = langManager.Translate("send_otp");
            btnVerify.Text = langManager.Translate("verify");
        }

        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            if (iconBackButton != null)
            {
                iconBackButton.IconColor = Color.FromArgb(255, 28, 87, 101);
                iconBackButton.BackColor = Color.FromArgb(255, 240, 237, 204);
                iconBackButton.ForeColor = Color.FromArgb(255, 240, 237, 204);
            }
        }
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private bool SendOTPEmail(string recipientEmail, string otp)
        {
            try
            {
                string senderEmail = "ngocbui27012109@gmail.com";
                string senderPassword = "mwgk gvla raav fqcc";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Mã OTP đặt lại mật khẩu";
                mail.Body = $"Mã OTP của bạn là: {otp}. Vui lòng không chia sẻ với ai!";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text == generatedOTP)
            {
                MessageBox.Show("OTP hợp lệ! Bạn có thể đặt lại mật khẩu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fDatLaiMatKhau fDatLaiMatKhau = new fDatLaiMatKhau(txtEmail.Text);
                fDatLaiMatKhau.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
