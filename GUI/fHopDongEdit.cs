using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fHopDongEdit : EditForm<HopDong>
    {
        private LanguageManager langManager = LanguageManager.Instance;
        public fHopDongEdit(HopDong HopDong = null) : base(HopDong)
        {
            InitializeComponent();

            ApplyDarkMode(DarkModeManager.IsDarkMode);

            //Back Color
            this.BackColor = DarkModeManager.GetBackgroundColor();
            this.BackgroundImage = Properties.Resources.panelBodyLight;
            labelTitle.BackColor = DarkModeManager.GetForeColor();
            panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            panelBody.BackgroundImage = Properties.Resources.panelBodyLight;

            // Label Back Color
            // Sử dụng cùng giá trị cho tất cả các label (đặt BackColor bằng 0% opacity của BackgroundColor)
            Color labelBack = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTenCT.BackColor = labelBack;
            labelMaHD.BackColor = labelBack;
            labelSdt.BackColor = labelBack;
            labelMaCT.BackColor = labelBack;
            labelDiaChi.BackColor = labelBack;
            labelKyHieuCT.BackColor = labelBack;
            labelTenDaiDien.BackColor = labelBack;
            labelNgayHD.BackColor = labelBack;

            // Label Fore Color
            labelTitle.ForeColor = DarkModeManager.GetBackgroundColor();
            btnSave.ForeColor = DarkModeManager.GetBackgroundColor();
            btnCancel.ForeColor = DarkModeManager.GetBackgroundColor();

            // Border Color
            panelBody.BorderColor = DarkModeManager.GetBackgroundColor();

            // Fill Color
            panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 50);

            // Label Fore Color (cho các label nội dung)
            labelTenCT.ForeColor = DarkModeManager.GetForeColor();
            labelMaHD.ForeColor = DarkModeManager.GetForeColor();
            labelSdt.ForeColor = DarkModeManager.GetForeColor();
            labelMaCT.ForeColor = DarkModeManager.GetForeColor();
            labelDiaChi.ForeColor = DarkModeManager.GetForeColor();
            labelKyHieuCT.ForeColor = DarkModeManager.GetForeColor();
            labelTenDaiDien.ForeColor = DarkModeManager.GetForeColor();
            labelNgayHD.ForeColor = DarkModeManager.GetForeColor();
            foreach (Control ctrl in panelBody.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.ForeColor = DarkModeManager.GetDark();
                    txt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                }
                if (ctrl is Guna.UI2.WinForms.Guna2DateTimePicker dtp)
                {
                    dtp.ForeColor = DarkModeManager.GetDark();
                    dtp.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                }
                if (ctrl is Guna.UI2.WinForms.Guna2ComboBox cbb)
                {
                    cbb.ForeColor = DarkModeManager.GetDark();
                    cbb.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                }
            }
            if (DarkModeManager.IsDarkMode)
            {
                // Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyLight;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
                btnSave.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                btnCancel.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);

                // Label Back Color
                // Sử dụng cùng giá trị cho tất cả các label
                Color labelBackDark = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenCT.BackColor = labelBackDark;
                labelMaHD.BackColor = labelBackDark;
                labelSdt.BackColor = labelBackDark;
                labelMaCT.BackColor = labelBackDark;
                labelDiaChi.BackColor = labelBackDark;
                labelKyHieuCT.BackColor = labelBackDark;
                labelTenDaiDien.BackColor = labelBackDark;
                labelNgayHD.BackColor = labelBackDark;

                // Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                btnSave.ForeColor = DarkModeManager.GetForeColor();
                btnCancel.ForeColor = DarkModeManager.GetForeColor();

                // Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();

                // Fill Color
                btnSave.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);

                // Label Fore Color (cho các label nội dung)
                Color labelForeDark = DarkModeManager.GetBackgroundColor();
                labelTenCT.ForeColor = labelForeDark;
                labelMaHD.ForeColor = labelForeDark;
                labelSdt.ForeColor = labelForeDark;
                labelMaCT.ForeColor = labelForeDark;
                labelDiaChi.ForeColor = labelForeDark;
                labelKyHieuCT.ForeColor = labelForeDark;
                labelTenDaiDien.ForeColor = labelForeDark;
                labelNgayHD.ForeColor = labelForeDark;
            }
            else
            {
                // Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyDark;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyDark;
                btnSave.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                btnCancel.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);

                // Label Back Color
                Color labelBackLight = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenCT.BackColor = labelBackLight;
                labelMaHD.BackColor = labelBackLight;
                labelSdt.BackColor = labelBackLight;
                labelMaCT.BackColor = labelBackLight;
                labelDiaChi.BackColor = labelBackLight;
                labelKyHieuCT.BackColor = labelBackLight;
                labelTenDaiDien.BackColor = labelBackLight;
                labelNgayHD.BackColor = labelBackLight;

                // Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                btnSave.ForeColor = DarkModeManager.GetForeColor();
                btnCancel.ForeColor = DarkModeManager.GetBackgroundColor();

                // Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();

                // Fill Color
                btnSave.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);

                // Label Fore Color
                Color labelForeLight = DarkModeManager.GetBackgroundColor();
                labelTenCT.ForeColor = labelForeLight;
                labelMaHD.ForeColor = labelForeLight;
                labelSdt.ForeColor = labelForeLight;
                labelMaCT.ForeColor = labelForeLight;
                labelDiaChi.ForeColor = labelForeLight;
                labelKyHieuCT.ForeColor = labelForeLight;
                labelTenDaiDien.ForeColor = labelForeLight;
                labelNgayHD.ForeColor = labelForeLight;
            }
            if (HopDong != null)
            {
                labelTitle.Text = "Chỉnh sửa hợp đồng";
            }
            LoadMaCT();
            LoadData();
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
        }

        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }

        protected virtual void OnLanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void UpdateLanguageTexts()
        {
            this.Text = langManager.Translate("order_edit_form_title");
            labelTitle.Text = langManager.Translate("add_order1");
            labelMaHD.Text = langManager.Translate("contract_code1");
            labelMaCT.Text = langManager.Translate("company_code1");
            labelTenCT.Text = langManager.Translate("company_name1");
            labelKyHieuCT.Text = langManager.Translate("company_symbol1");
            labelNgayHD.Text = langManager.Translate("contract_date1");
            labelTenDaiDien.Text = langManager.Translate("representative1");
            labelSdt.Text = langManager.Translate("phone_number1");
            labelDiaChi.Text = langManager.Translate("address1");
            btnSave.Text = langManager.Translate("save");
            btnCancel.Text = langManager.Translate("cancel");
            labelTitle.Text = (isEdit) ? langManager.Translate("edit_contract") : langManager.Translate("add_contract");
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

        protected override HopDong GetFormData()
        {
            return new HopDong(
                txtMaHD.Text.Trim(),
                txtMaCT.Text.Trim(),
                cbTenCT.SelectedItem?.ToString() ?? "",
                txtKyHieuCT.Text.Trim(),
                dtpNgayHD.Value,
                txtTenDaiDien.Text.Trim(),
                txtSdt.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }
        private void LoadMaCT()
        {
            cbTenCT.DataSource = CongTyBLL.Instance.GetAllTenCongTy();
            cbTenCT.SelectedIndex = -1;
            cbTenCT.SelectedIndexChanged += cbTenCT_SelectedIndexChanged;
        }

        private void cbTenCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenCT = cbTenCT.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tenCT)) return;

            var congTy = CongTyBLL.Instance.GetCongTyByTenCongTy(tenCT);
            if (congTy != null)
            {
                txtMaCT.Text = congTy.MaCT;
                txtKyHieuCT.Text = congTy.KyHieuCT;
                txtTenDaiDien.Text = congTy.TenDaiDien;
                txtSdt.Text = congTy.Sdt;
                txtDiaChi.Text = congTy.DiaChi;
            }
        }

        protected override void LoadData()
        {
            txtMaHD.Text = isEdit ? curr.MaHD : HopDongBLL.Instance.GenerateMaHopDong();
            txtMaCT.Text = isEdit ? curr.MaCT : string.Empty;
            cbTenCT.SelectedItem = isEdit ? curr.TenCT : string.Empty;
            txtKyHieuCT.Text = isEdit ? curr.KyHieuCT : string.Empty;
            dtpNgayHD.Value = isEdit ? curr.NgayHD : DateTime.Now;
            txtTenDaiDien.Text = isEdit ? curr.TenDaiDien : string.Empty;
            txtSdt.Text = isEdit ? curr.Sdt : string.Empty;
            txtDiaChi.Text = isEdit ? curr.DiaChi : string.Empty;
            txtMaHD.Enabled = false;
            txtMaCT.Enabled = false;
            txtKyHieuCT.Enabled = false;
            txtTenDaiDien.Enabled = false;
            txtSdt.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        protected override bool ValidateData(HopDong data)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaCT))
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_contract_fields"),
                    LanguageManager.Instance.Translate("input_error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(HopDong data)
        {
            if (isEdit)
            {
                return HopDongBLL.Instance.UpdateHopDong(data.MaHD, data.MaCT, data.NgayHD);
            }
            else
            {
                return HopDongBLL.Instance.InsertHopDong(data.MaHD, data.MaCT, data.NgayHD);
            }
        }
        private void cbTenCT_TextChanged(object sender, EventArgs e)
        {
            CongTy congTy = CongTyBLL.Instance.GetCongTyByTenCongTy(cbTenCT.Text);

            if (congTy != null)
            {
                txtMaCT.Text = congTy.MaCT;
                txtKyHieuCT.Text = congTy.KyHieuCT;
                txtTenDaiDien.Text = congTy.TenDaiDien;
                txtSdt.Text = congTy.Sdt;
                txtDiaChi.Text = congTy.DiaChi;
            }
            else
            {
                txtMaCT.Text = "";
                txtKyHieuCT.Text = "";
                txtTenDaiDien.Text = "";
                txtSdt.Text = "";
                txtDiaChi.Text = "";
            }
        }

    }
}
