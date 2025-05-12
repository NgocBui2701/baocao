using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fDonHangEdit : EditForm<DonHang>
    {
        private LanguageManager langManager = LanguageManager.Instance;
        public fDonHangEdit(DonHang donHang = null) : base(donHang)
        {
            InitializeComponent();
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
            labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //Fore Color
            labelTitle.ForeColor = DarkModeManager.GetBackgroundColor();
            buttonLuu.ForeColor = DarkModeManager.GetBackgroundColor();
            buttonHuy.ForeColor = DarkModeManager.GetBackgroundColor();
            //Border Color
            panelBody.BorderColor = DarkModeManager.GetBackgroundColor();
            //Fill Color
            panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 50);
            //label Fore Color
            labelNLM.ForeColor = DarkModeManager.GetForeColor();
            labelMaHD.ForeColor = DarkModeManager.GetForeColor();
            labelTrangthai.ForeColor = DarkModeManager.GetForeColor();
            labelMaDH.ForeColor = DarkModeManager.GetForeColor();
            labelQuy.ForeColor = DarkModeManager.GetForeColor();
            labelNKQ.ForeColor = DarkModeManager.GetForeColor();
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
                //Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyLight;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
                buttonLuu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                buttonHuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                // Label Back Color
                labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                //Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                buttonLuu.ForeColor = DarkModeManager.GetForeColor();
                buttonHuy.ForeColor = DarkModeManager.GetForeColor();
                //Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();
                //Fill Color
                buttonLuu.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
                //label Fore Color
                labelNLM.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaHD.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTrangthai.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaDH.ForeColor = DarkModeManager.GetBackgroundColor();
                labelQuy.ForeColor = DarkModeManager.GetBackgroundColor();
                labelNKQ.ForeColor = DarkModeManager.GetBackgroundColor();
            }
            else
            {
                //Back Color
                this.BackColor = DarkModeManager.GetBackgroundColor();
                this.BackgroundImage = Properties.Resources.panelBodyDark;
                labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
                panelBody.BackgroundImage = Properties.Resources.panelBodyDark;
                buttonLuu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                buttonHuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                // Label Back Color
                labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                //Fore Color
                labelTitle.ForeColor = DarkModeManager.GetForeColor();
                buttonLuu.ForeColor = DarkModeManager.GetForeColor();
                buttonHuy.ForeColor = DarkModeManager.GetBackgroundColor();
                //Border Color
                panelBody.BorderColor = DarkModeManager.GetForeColor();
                //Fill Color
                buttonLuu.FillColor = DarkModeManager.GetBackgroundColor();
                panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
                panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
                //label Fore Color
                labelNLM.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaHD.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTrangthai.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaDH.ForeColor = DarkModeManager.GetBackgroundColor();
                labelQuy.ForeColor = DarkModeManager.GetBackgroundColor();
                labelNKQ.ForeColor = DarkModeManager.GetBackgroundColor();
            }

            if (donHang == null)
            {
                cbbMaHD.SelectedIndex = -1;
            } 
            LoadMaHopDongToComboBox();
            LoadData();
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {

            labelMaHD.Text = langManager.Translate("contract_code1");
            labelMaDH.Text = langManager.Translate("order_code1");
            labelNLM.Text = langManager.Translate("sample_start_date");
            labelNKQ.Text = langManager.Translate("estimated_result_date");
            buttonLuu.Text = langManager.Translate("save");
            buttonHuy.Text = langManager.Translate("cancel");
            labelQuy.Text = langManager.Translate("quarter1");
            labelTrangthai.Text = langManager.Translate("status1");
            txtTrangthai.Text = langManager.Translate("in_progress");
            labelTitle.Text = (isEdit) ? langManager.Translate("edit_order") : langManager.Translate("add_order");

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
        public Color ChangeOpacityByPercentage(Color baseColor, int opacityPercentage)
        {
            // Ensure percentage is within valid range (0% to 100%)
            opacityPercentage = Math.Max(0, Math.Min(100, opacityPercentage));

            // Calculate alpha from the percentage
            int alpha = (int)((opacityPercentage / 100.0) * 255);

            // Return a new transparent color
            return Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
        }

        protected override DonHang GetFormData()
        {
            return new DonHang(
                cbbMaHD.SelectedItem?.ToString() ?? string.Empty,
                txtMaDH.Text?.Trim() ?? string.Empty,
                dtpNLM.Value,
                dtpNKQ.Value,
                int.Parse(txtQuy.Text),
                txtTrangthai.Text
            );
        }

        protected override void LoadData()
        {
            try
            {
                txtMaDH.Text = isEdit ? curr.MaDH : DonHangBLL.Instance.GenerateMaDonHang();
                cbbMaHD.SelectedItem = isEdit ? curr.MaHD : string.Empty;
                dtpNLM.Value = isEdit ? curr.NgayLM : DateTime.Now;
                dtpNKQ.Value = isEdit ? curr.NgayKQ : DateTime.Now.AddDays(7);
                txtQuy.Text = isEdit ? curr.Quy.ToString() : ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
                txtTrangthai.Text = isEdit ? curr.Trangthai : "Đang xử lý";

                txtMaDH.Enabled = false;
                txtQuy.Enabled = false;
                txtTrangthai.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override bool ValidateData(DonHang data)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaDH) || data.NgayLM == DateTime.MinValue || data.NgayKQ == DateTime.MinValue)
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_order_fields"),
                    LanguageManager.Instance.Translate("input_error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(DonHang data)
        {
            try
            {
                if (isEdit)
                {
                    return DonHangBLL.Instance.UpdateDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
                }
                else
                {
                    return DonHangBLL.Instance.InsertDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void LoadMaHopDongToComboBox()
        {
            List<string> danhSachMaHD = HopDongBLL.Instance.GetAllMaHopDong();
            if (danhSachMaHD.Count > 0)
            {
                cbbMaHD.DataSource = danhSachMaHD;
            }
        }

        private void dtpNLM_ValueChanged(object sender, EventArgs e)
        {
            txtQuy.Text = ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
        }
    }
}