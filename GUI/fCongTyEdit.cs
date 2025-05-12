using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fCongTyEdit : EditForm<CongTy>
    {
        private LanguageManager langManager = LanguageManager.Instance;
        public fCongTyEdit(CongTy congTy = null) : base(congTy)
        {
            InitializeComponent();
            if (congTy != null)
            {
                labelTitle.Text = "Chỉnh sửa công ty";
                LoadData();
            }
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
            //Back Color
            this.BackColor = DarkModeManager.GetBackgroundColor();

            this.BackgroundImage = Properties.Resources.panelBodyLight;
            labelTitle.BackColor = DarkModeManager.GetForeColor();
            panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
            // Label Back Color
            labelKyHieuCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelMaCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTenCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelDiaChi.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTenDaiDien.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //Fore Color
            labelTitle.ForeColor = DarkModeManager.GetBackgroundColor();
            btnSave.ForeColor = DarkModeManager.GetBackgroundColor();
            btnCancel.ForeColor = DarkModeManager.GetBackgroundColor();
            //Border Color
            panelBody.BorderColor = DarkModeManager.GetBackgroundColor();
            //Fill Color
            panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 50);
            //label Fore Color
            labelKyHieuCT.ForeColor = DarkModeManager.GetForeColor();
            labelMaCT.ForeColor = DarkModeManager.GetForeColor();
            labelSdt.ForeColor = DarkModeManager.GetForeColor();
            labelTenCT.ForeColor = DarkModeManager.GetForeColor();
            labelDiaChi.ForeColor = DarkModeManager.GetForeColor();
            labelTenDaiDien.ForeColor = DarkModeManager.GetForeColor();
            foreach (Control ctrl in panelBody.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.ForeColor = DarkModeManager.GetDark();
                    txt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                }
            }

            if (DarkModeManager.IsDarkMode)
            {
                //Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyLight;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
                btnSave.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                btnCancel.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                // Label Back Color
                labelKyHieuCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelDiaChi.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenDaiDien.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                //Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                btnSave.ForeColor = DarkModeManager.GetForeColor();
                btnCancel.ForeColor = DarkModeManager.GetForeColor();
                //Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();
                //Fill Color
                btnSave.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
                //label Fore Color
                labelKyHieuCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelSdt.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelDiaChi.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenDaiDien.ForeColor = DarkModeManager.GetBackgroundColor();
            }
            else
            {
                //Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyDark;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyDark;
                btnSave.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                btnCancel.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                // Label Back Color
                labelKyHieuCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenCT.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelDiaChi.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenDaiDien.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                //Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                btnSave.ForeColor = DarkModeManager.GetForeColor();
                btnCancel.ForeColor = DarkModeManager.GetBackgroundColor();
                //Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();
                //Fill Color
                btnSave.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
                //label Fore Color
                labelKyHieuCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelSdt.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenCT.ForeColor = DarkModeManager.GetBackgroundColor();
                labelDiaChi.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenDaiDien.ForeColor = DarkModeManager.GetBackgroundColor();
            }
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
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {

            labelMaCT.Text = langManager.Translate("company_code1");
            labelTenCT.Text = langManager.Translate("company_name1");
            labelKyHieuCT.Text = langManager.Translate("company_symbol1");
            labelTenDaiDien.Text = langManager.Translate("representative1");
            labelSdt.Text = langManager.Translate("phone_number1");
            labelDiaChi.Text = langManager.Translate("address1");
            btnSave.Text = langManager.Translate("save");
            btnCancel.Text = langManager.Translate("cancel");
            labelTitle.Text = (isEdit) ? langManager.Translate("edit_company") : langManager.Translate("add_company");

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        protected override CongTy GetFormData()
        {
            return new CongTy(
                txtMaCT.Text.Trim(),
                txtTenCT.Text.Trim(),
                txtKyHieuCT.Text.Trim(),
                txtTenDaiDien.Text.Trim(),
                txtSdt.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }

        protected override void LoadData()
        {
            if (isEdit)
            {
                txtMaCT.Text = curr.MaCT;
                txtMaCT.ReadOnly = true;
                txtTenCT.Text = curr.TenCT;
                txtKyHieuCT.Text = curr.KyHieuCT;
                txtTenDaiDien.Text = curr.TenDaiDien;
                txtSdt.Text = curr.Sdt;
                txtDiaChi.Text = curr.DiaChi;
            }
        }

        protected override bool ValidateData(CongTy data)
        {
            if (string.IsNullOrEmpty(data.MaCT) || string.IsNullOrEmpty(data.TenCT))
            {
                MessageBox.Show(LanguageManager.Instance.Translate("empty_company_fields"),
                            LanguageManager.Instance.Translate("input_error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(CongTy data)
        {
            if (isEdit)
            {
                return CongTyBLL.Instance.UpdateCongTy(data.MaCT, data.TenCT, data.KyHieuCT, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
            else
            {
                return CongTyBLL.Instance.InsertCongTy(data.MaCT, data.TenCT, data.KyHieuCT, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
        }
    }
}