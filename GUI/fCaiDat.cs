using System;
using System.Windows.Forms;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace baocao.GUI
{
    public partial class fCaiDat : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private Account currentAccount; ///////////////////////////////////////////
        public event EventHandler TaiKhoanButtonClicked;
        public event EventHandler CongTyButtonClicked;
        public event EventHandler DarkModeChanged;
        public event EventHandler HeThongButtonClicked;
        public event EventHandler NgonNguButtonClicked;

        public fCaiDat(Account acc)
        {
            InitializeComponent();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            currentAccount = acc;
            labelUsername.Text = acc.TenDangNhap;
            labelName.Text = acc.Ten;
            labelRole.Text = acc.VaiTro;
            btnDarkMode.IconChar = DarkModeManager.IsDarkMode ? FontAwesome.Sharp.IconChar.Moon : FontAwesome.Sharp.IconChar.Sun;
            UpdateLanguageTexts();
            langManager.LanguageChanged += LangManager_LanguageChanged;

            btnTaiKhoan.PressedColor = Color.Transparent;
            btnTaiKhoan.PressedDepth = 0;
            btnTaiKhoan.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnTaiKhoan.ForeColor = DarkModeManager.GetBackgroundColor();
            iconTaiKhoan.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconTaiKhoan.IconColor = DarkModeManager.GetBackgroundColor();

            btnCongTy.PressedColor = Color.Transparent;
            btnCongTy.PressedDepth = 0;
            btnCongTy.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            iconCongTy.IconColor = DarkModeManager.GetBackgroundColor();
            //iconCongTy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconCongTy.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(203, 214, 188) : Color.FromArgb(40, 105, 117);

            btnHeThong.PressedColor = Color.Transparent;
            btnHeThong.PressedDepth = 0;
            btnHeThong.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            iconHeThong.IconColor = DarkModeManager.GetBackgroundColor();
            iconHeThong.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);

            btnNgonNgu.PressedColor = Color.Transparent;
            btnNgonNgu.PressedDepth = 0;
            btnNgonNgu.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            iconNgonNgu.IconColor = DarkModeManager.GetBackgroundColor();
            iconNgonNgu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);

            if (!DarkModeManager.IsDarkMode)
            {
                //Back Color
                btnDarkMode.BackColor = Color.FromArgb(255, 229, 236, 191);
                panelTitle.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelUsername.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelRole.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelName.BackColor = Color.FromArgb(255, 229, 236, 191);
                avatarUser.BackColor = Color.FromArgb(255, 229, 236, 191);
                iconCloudSync.BackColor = Color.FromArgb(255, 229, 236, 191);
                iconBuildVersion.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelCloudSync.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelBuildVersion.BackColor = Color.FromArgb(255, 229, 236, 191);


                //Fore Color
                labelUsername.ForeColor = DarkModeManager.GetForeColor();
                labelRole.ForeColor = DarkModeManager.GetForeColor();
                labelName.ForeColor = DarkModeManager.GetForeColor();
                labelCloudSync.ForeColor = DarkModeManager.GetForeColor();
                labelBuildVersion.ForeColor = DarkModeManager.GetForeColor();
            }
            else
            {
                //Back Color
                btnDarkMode.BackColor = Color.FromArgb(255, 19, 56, 64);
                panelTitle.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelUsername.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelRole.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelName.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelCloudSync.BackColor = Color.FromArgb(255, 19, 56, 64);
                avatarUser.BackColor = Color.FromArgb(255, 19, 56, 64);
                iconCloudSync.BackColor = Color.FromArgb(255, 19, 56, 64);
                iconBuildVersion.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelBuildVersion.BackColor = Color.FromArgb(255, 19, 56, 64);
                //Fore Color
                labelUsername.ForeColor = DarkModeManager.GetForeColor();
                labelRole.ForeColor = DarkModeManager.GetForeColor();
                labelName.ForeColor = DarkModeManager.GetForeColor();
                labelCloudSync.ForeColor = DarkModeManager.GetForeColor();
                labelBuildVersion.ForeColor = DarkModeManager.GetForeColor();
            }
            UpdateLanguageTexts();
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {

            btnNgonNgu.Text = langManager.Translate("language");
            labelActiveDescriptionNgonNgu.Text = langManager.Translate("display_language_settings");
            TextActiveNgonNgu.Text = langManager.Translate("language");

            btnHeThong.Text = langManager.Translate("system");
            labelActiveDescriptionHeThong.Text = langManager.Translate("system_settings");
            TextActiveHeThong.Text = langManager.Translate("system");

            btnCongTy.Text = langManager.Translate("company");
            labelActiveDescriptionCongTy.Text = langManager.Translate("partner_company_info");
            TextActiveCongTy.Text = langManager.Translate("company");

            btnTaiKhoan.Text = langManager.Translate("account");
            labelActiveDescriptionTaiKhoan.Text = langManager.Translate("account_info_security");
            TextActiveTaiKhoanButton.Text = langManager.Translate("account");

            labelCloudSync.Text = langManager.Translate("cloudsync");
            labelBuildVersion.Text = langManager.Translate("buildversion");
            labelRole.Text = TranslateRole(currentAccount.VaiTro);
        }
        private string TranslateRole(string role)
        {
            switch (role)
            {
                case "Quản trị viên":
                case "Administrator":
                    return langManager.Translate("role_admin");
                case "Phòng kinh doanh":
                case "Sales Department":
                    return langManager.Translate("role_sales");
                case "Phòng quan trắc":
                case "Inspection Department":
                    return langManager.Translate("role_inspection");
                case "Phòng phân tích":
                case "Analysis Department":
                    return langManager.Translate("role_analysis");
                case "Phòng kế hoạch":
                case "Planning Department":
                    return langManager.Translate("role_planning");
                case "Phòng xuất kết quả":
                case "Results Department":
                    return langManager.Translate("role_results");
                default:
                    return role;
            }
        }

        //Event Enter and Leave
        private void btnTaiKhoan_MouseEnter(object sender, EventArgs e)
        {
            btnTaiKhoan.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            btnTaiKhoan.ForeColor = DarkModeManager.GetBackgroundColor();
            btnTaiKhoan.HoverState.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            iconTaiKhoan.IconColor = DarkModeManager.GetBackgroundColor();
            iconTaiKhoan.BackColor = DarkModeManager.GetForeColor();
            TextActiveTaiKhoanButton.Visible = true;
            TextActiveTaiKhoanButton.BackColor = DarkModeManager.GetForeColor();
            TextActiveTaiKhoanButton.ForeColor = DarkModeManager.GetBackgroundColor();
            btnTaiKhoan.Text = "";
            labelActiveDescriptionTaiKhoan.Visible = true;
            labelActiveDescriptionTaiKhoan.BackColor = DarkModeManager.GetForeColor();
            labelActiveDescriptionTaiKhoan.ForeColor = DarkModeManager.GetBackgroundColor();
            Cursor = Cursors.Hand;
        }
        private void btnTaiKhoan_MouseLeave(object sender, EventArgs e)
        {

            btnTaiKhoan.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnTaiKhoan.ForeColor = DarkModeManager.GetBackgroundColor();
            iconTaiKhoan.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            TextActiveTaiKhoanButton.Visible = false;
            btnTaiKhoan.Text = "Tài Khoản";
            btnTaiKhoan.Text = langManager.Translate("account");
            labelActiveDescriptionTaiKhoan.Visible = false;
        }
        private void btnCongTy_MouseEnter(object sender, EventArgs e)
        {
            btnCongTy.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            btnCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            btnCongTy.HoverState.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            iconCongTy.IconColor = DarkModeManager.GetBackgroundColor();
            iconCongTy.BackColor = DarkModeManager.GetForeColor();
            TextActiveCongTy.Visible = true;
            TextActiveCongTy.BackColor = DarkModeManager.GetForeColor();
            TextActiveCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            btnCongTy.Text = "";
            labelActiveDescriptionCongTy.Visible = true;
            labelActiveDescriptionCongTy.BackColor = DarkModeManager.GetForeColor();
            labelActiveDescriptionCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            Cursor = Cursors.Hand;
        }
        private void btnCongTy_MouseLeave(object sender, EventArgs e)
        {

            btnCongTy.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            //iconCongTy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconCongTy.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(203, 214, 188) : Color.FromArgb(40, 105, 117);
            TextActiveCongTy.Visible = false;
            btnCongTy.Text = "Danh Mục Khách Hàng";
            btnCongTy.Text = langManager.Translate("company");
            labelActiveDescriptionCongTy.Visible = false;
            Cursor = Cursors.Arrow;
        }
        private void btnHeThong_MouseEnter(object sender, EventArgs e)
        {
            btnHeThong.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            btnHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            btnHeThong.HoverState.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            iconHeThong.IconColor = DarkModeManager.GetBackgroundColor();
            iconHeThong.BackColor = DarkModeManager.GetForeColor();
            TextActiveHeThong.Visible = true;
            TextActiveHeThong.BackColor = DarkModeManager.GetForeColor();
            TextActiveHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            btnHeThong.Text = "";
            labelActiveDescriptionHeThong.Visible = true;
            labelActiveDescriptionHeThong.BackColor = DarkModeManager.GetForeColor();
            labelActiveDescriptionHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            Cursor = Cursors.Hand;
        }
        private void btnHeThong_MouseLeave(object sender, EventArgs e)
        {

            btnHeThong.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            iconHeThong.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            TextActiveHeThong.Visible = false;
            btnHeThong.Text = "Hệ Thống";
            btnHeThong.Text = langManager.Translate("system");
            labelActiveDescriptionHeThong.Visible = false;
            Cursor = Cursors.Arrow;
        }
        private void btnNgonNgu_MouseEnter(object sender, EventArgs e)
        {
            btnNgonNgu.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            btnNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            btnNgonNgu.HoverState.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 100);
            iconNgonNgu.IconColor = DarkModeManager.GetBackgroundColor();
            iconNgonNgu.BackColor = DarkModeManager.GetForeColor();
            TextActiveNgonNgu.Visible = true;
            TextActiveNgonNgu.BackColor = DarkModeManager.GetForeColor();
            TextActiveNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            btnNgonNgu.Text = "";
            labelActiveDescriptionNgonNgu.Visible = true;
            labelActiveDescriptionNgonNgu.BackColor = DarkModeManager.GetForeColor();
            labelActiveDescriptionNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            Cursor = Cursors.Hand;
        }
        private void btnNgonNgu_MouseLeave(object sender, EventArgs e)
        {

            btnNgonNgu.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            iconNgonNgu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            TextActiveNgonNgu.Visible = false;
            btnNgonNgu.Text = "Ngôn ngữ";
            btnNgonNgu.Text = langManager.Translate("language");
            labelActiveDescriptionNgonNgu.Visible = false;
            Cursor = Cursors.Arrow;
        }
        private void btnNgonNgu_MouseUp(object sender, MouseEventArgs e)
        {
            btnNgonNgu_MouseEnter(sender, e);
        }

        //Event Click
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan.PressedColor = Color.Transparent;
            btnTaiKhoan.PressedDepth = 0;
            Cursor = Cursors.Hand;
            TaiKhoanButtonClicked?.Invoke(this, EventArgs.Empty);

        }
        private void btnCongTy_Click(object sender, EventArgs e)
        {
            btnTaiKhoan.PressedColor = Color.Transparent;
            btnTaiKhoan.PressedDepth = 0;
            Cursor = Cursors.Hand;
            CongTyButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnHeThong_Click(object sender, EventArgs e)
        {
            btnHeThong.PressedColor = Color.Transparent;
            btnHeThong.PressedDepth = 0;
            Cursor = Cursors.Hand;
            HeThongButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnNgonNgu_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////
            if (langManager.CurrentLanguage == "vi")
                langManager.SetLanguage("en");
            else
                langManager.SetLanguage("vi");

            ////////////////////////////////////////
            UpdateLanguageTexts();
            btnNgonNgu.PressedColor = Color.Transparent;
            btnNgonNgu.PressedDepth = 0;
            Cursor = Cursors.Hand;
            NgonNguButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        //Btn Dark Mode
        private void btnDarkMode_MouseEnter(object sender, EventArgs e)
        {
            btnDarkMode.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(255, 19, 56, 64) : Color.FromArgb(255, 229, 236, 191);
            btnDarkMode.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }
        private void btnDarkMode_MouseLeave(object sender, EventArgs e)
        {
            btnDarkMode.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(255, 19, 56, 64) : Color.FromArgb(255, 229, 236, 191);
            btnDarkMode.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }
        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            DarkModeManager.IsDarkMode = !DarkModeManager.IsDarkMode;
            btnDarkMode.IconChar = DarkModeManager.IsDarkMode ? FontAwesome.Sharp.IconChar.Moon : FontAwesome.Sharp.IconChar.Sun;
            this.ActiveControl = null;
            DarkModeChanged?.Invoke(this, EventArgs.Empty);
            if (!DarkModeManager.IsDarkMode)
            {
                //Back Color
                panelTitle.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelUsername.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelRole.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelName.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelCloudSync.BackColor = Color.FromArgb(255, 229, 236, 191);
                avatarUser.BackColor = Color.FromArgb(255, 229, 236, 191);
                iconCloudSync.BackColor = Color.FromArgb(255, 229, 236, 191);
                iconBuildVersion.BackColor = Color.FromArgb(255, 229, 236, 191);
                labelBuildVersion.BackColor = Color.FromArgb(255, 229, 236, 191);


                //Fore Color
                labelUsername.ForeColor = DarkModeManager.GetForeColor();
                labelRole.ForeColor = DarkModeManager.GetForeColor();
                labelName.ForeColor = DarkModeManager.GetForeColor();
                labelCloudSync.ForeColor = DarkModeManager.GetForeColor();
                labelBuildVersion.ForeColor = DarkModeManager.GetForeColor();
            }
            else
            {
                //Back Color
                panelTitle.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelUsername.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelRole.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelName.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelCloudSync.BackColor = Color.FromArgb(255, 19, 56, 64);
                avatarUser.BackColor = Color.FromArgb(255, 19, 56, 64);
                iconCloudSync.BackColor = Color.FromArgb(255, 19, 56, 64);
                iconBuildVersion.BackColor = Color.FromArgb(255, 19, 56, 64);
                labelBuildVersion.BackColor = Color.FromArgb(255, 19, 56, 64);
                //Fore Color
                labelUsername.ForeColor = DarkModeManager.GetForeColor();
                labelRole.ForeColor = DarkModeManager.GetForeColor();
                labelName.ForeColor = DarkModeManager.GetForeColor();
                labelCloudSync.ForeColor = DarkModeManager.GetForeColor();
                labelBuildVersion.ForeColor = DarkModeManager.GetForeColor();
            }
            //Changing btnTaiKhoan
            btnTaiKhoan.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnTaiKhoan.ForeColor = DarkModeManager.GetBackgroundColor();
            iconTaiKhoan.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconTaiKhoan.IconColor = DarkModeManager.GetBackgroundColor();
            //Changing btnCongty
            btnCongTy.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
            //iconCongTy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconCongTy.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(203, 214, 188) : Color.FromArgb(40, 105, 117);
            iconCongTy.IconColor = DarkModeManager.GetBackgroundColor();
            //Changing btnHeThong
            btnHeThong.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnHeThong.ForeColor = DarkModeManager.GetBackgroundColor();
            iconHeThong.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconHeThong.IconColor = DarkModeManager.GetBackgroundColor();
            //Changing btnNgonNgu
            btnNgonNgu.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            btnNgonNgu.ForeColor = DarkModeManager.GetBackgroundColor();
            iconNgonNgu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 85);
            iconNgonNgu.IconColor = DarkModeManager.GetBackgroundColor();
        }
        private void btnDarkMode_MouseUp(object sender, MouseEventArgs e)
        {
            btnDarkMode.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(255, 19, 56, 64) : Color.FromArgb(255, 229, 236, 191);
        }
        private void btnDarkMode_MouseDown(object sender, MouseEventArgs e)
        {
            btnDarkMode.BackColor = DarkModeManager.IsDarkMode ? Color.FromArgb(255, 19, 56, 64) : Color.FromArgb(255, 229, 236, 191);
        }


        public Color ChangeOpacityByPercentage(Color baseColor, int opacityPercentage)
        {
            // Ensure percentage is within valid range (0% to 100%)
            opacityPercentage = Math.Max(0, Math.Min(100, opacityPercentage));

            // Calculate alpha from the percentage
            int alpha = (int)((opacityPercentage / 100.0) * 255);

            // Return a new transparent color
            return Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
    }
}
