using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fNguoiDungEdit : EditForm<Account>
    {
        private LanguageManager langManager = LanguageManager.Instance; //4/5/2025
        public fNguoiDungEdit(Account acc = null) : base(acc)
        {
            InitializeComponent();
            if (acc != null)
            {
                labelTitle.Text = "Chỉnh sửa thông tin nhân viên";
            }
            LoadVaiTro();
            LoadData();
            //4/5/2025
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            //Back Color
            this.BackColor = DarkModeManager.GetBackgroundColor();

            this.BackgroundImage = Properties.Resources.panelBodyLight;
            labelTitle.BackColor = DarkModeManager.GetForeColor();
            panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
            // Label Back Color
            labelEmail.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelMaND.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTenDangNhap.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelVaiTro.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            labelTen.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
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
            labelEmail.ForeColor = DarkModeManager.GetForeColor();
            labelMaND.ForeColor = DarkModeManager.GetForeColor();
            labelSdt.ForeColor = DarkModeManager.GetForeColor();
            labelTenDangNhap.ForeColor = DarkModeManager.GetForeColor();
            labelVaiTro.ForeColor = DarkModeManager.GetForeColor();
            labelTen.ForeColor = DarkModeManager.GetForeColor();
            foreach (Control ctrl in panelBody.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.ForeColor = DarkModeManager.GetDark();
                    txt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
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
                btnSave.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                btnCancel.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                // Label Back Color
                labelEmail.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaND.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenDangNhap.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelVaiTro.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTen.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
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
                labelEmail.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaND.ForeColor = DarkModeManager.GetBackgroundColor();
                labelSdt.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenDangNhap.ForeColor = DarkModeManager.GetBackgroundColor();
                labelVaiTro.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTen.ForeColor = DarkModeManager.GetBackgroundColor();
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
                labelEmail.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelMaND.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelSdt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTenDangNhap.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelVaiTro.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
                labelTen.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
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
                labelEmail.ForeColor = DarkModeManager.GetBackgroundColor();
                labelMaND.ForeColor = DarkModeManager.GetBackgroundColor();
                labelSdt.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTenDangNhap.ForeColor = DarkModeManager.GetBackgroundColor();
                labelVaiTro.ForeColor = DarkModeManager.GetBackgroundColor();
                labelTen.ForeColor = DarkModeManager.GetBackgroundColor();
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
        //4/5/2025
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
            labelMaND.Text = langManager.Translate("user_id1");
            labelTen.Text = langManager.Translate("full_name1");
            labelVaiTro.Text = langManager.Translate("role1");
            labelTenDangNhap.Text = langManager.Translate("username1");
            labelEmail.Text = langManager.Translate("email1");
            labelSdt.Text = langManager.Translate("phone_number1");
            labelTitle.Text = (isEdit) ? langManager.Translate("edit_user") : langManager.Translate("add_user");
            btnCancel.Text = langManager.Translate("cancel");
            btnSave.Text = langManager.Translate("save");
        }
        //4/5/2025
        private void LoadVaiTro()
        {
            var roles = new List<VaiTroItem>()
            {
                new VaiTroItem
                {
                    Key = "role_admin",
                    DbValue = "Quản trị viên",
                    DisplayText = langManager.Translate("role_admin")
                },
                    new VaiTroItem
                {
                    Key = "role_sales",
                    DbValue = "Phòng kinh doanh",
                    DisplayText = langManager.Translate("role_sales")
                },
                new VaiTroItem
                {
                    Key = "role_inspection",
                    DbValue = "Phòng quan trắc",
                    DisplayText = langManager.Translate("role_inspection")
                },
                new VaiTroItem
                {
                    Key = "role_analysis",
                    DbValue = "Phòng phân tích",
                    DisplayText = langManager.Translate("role_analysis")
                },
                new VaiTroItem
                {
                    Key = "role_planning",
                    DbValue = "Phòng kế hoạch",
                    DisplayText = langManager.Translate("role_planning")
                },
                new VaiTroItem
                {
                    Key = "role_results",
                    DbValue = "Phòng xuất kết quả",
                    DisplayText = langManager.Translate("role_results")
                }
            };
                cbVaiTro.DataSource = roles;
                cbVaiTro.DisplayMember = "DisplayText";
                cbVaiTro.ValueMember = "DbValue";
        }
        //4/6/2025
        protected override Account GetFormData()
        {
            var selectedRole = cbVaiTro.SelectedItem as VaiTroItem;
            string roleValue = selectedRole?.DbValue ?? ""; 

            return new Account(
                txtMaND.Text.Trim(),
                txtHoTen.Text.Trim(),
                roleValue,
                txtTenDangNhap.Text.Trim(),
                txtEmail.Text.Trim(),
                txtSdt.Text.Trim()
            );
        }
        protected override void LoadData()
        {
            txtMaND.Text = isEdit ? curr.MaNguoiDung : AccountBLL.Instance.GenerateMaNguoiDung();
            txtHoTen.Text = isEdit ? curr.Ten : "";
            foreach (VaiTroItem item in cbVaiTro.Items)
            {
                if (item.DbValue.Equals(isEdit ? curr.VaiTro : "", StringComparison.OrdinalIgnoreCase))
                {
                    cbVaiTro.SelectedItem = item;
                    break;
                }
            }
            txtTenDangNhap.Text = isEdit ? curr.TenDangNhap : "";
            txtEmail.Text = isEdit ? curr.Email : "";
            txtSdt.Text = isEdit ? curr.Sdt : "";
            txtMaND.Enabled = false;
        }
        //4/6/2025
        protected override bool ValidateData(Account data)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_fullname"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_username"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_email"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_phone"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show(
                    LanguageManager.Instance.Translate("empty_role"),
                    LanguageManager.Instance.Translate("notification"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        protected override bool SaveData(Account data)
        {
            if (isEdit)
            {
                return AccountBLL.Instance.UpdateAccount(data.MaNguoiDung, data.Ten, data.VaiTro, data.TenDangNhap, data.Email, data.Sdt);
            }
            else
            {
                return AccountBLL.Instance.InsertAccount(data.MaNguoiDung, data.Ten, data.VaiTro, data.TenDangNhap, data.Email, data.Sdt);
            }
        }
    }
}
