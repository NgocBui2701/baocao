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
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fViTri : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance; //4/5/2025
        private Form formChild;
        private DonHang _donHang;
        private fThongSoMoiTruong fThongSoMoiTruong1;
        private fThongSoMoiTruong fThongSoMoiTruong2;
        private fThongSoMoiTruong fThongSoMoiTruong3;
        private fThongSoMoiTruong fThongSoMoiTruong4;
        private bool checkStatus;
        private string currentLoaiVT = "ĐẤT";
        public fViTri(DonHang donHang)
        {
            InitializeComponent();
            this._donHang = donHang;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            if (ckbStatus != null && (_donHang.Trangthai == "Hoàn thành" || _donHang.Trangthai == "Completed"))
            {
                checkStatus = true;
                ckbStatus.Checked = true;
            }
            else
            {
                checkStatus = false;
                ckbStatus.Checked = false;
            }
            fThongSoMoiTruong1 = new fThongSoMoiTruong(donHang, "Đất");
            fThongSoMoiTruong2 = new fThongSoMoiTruong(donHang, "Nước");
            fThongSoMoiTruong3 = new fThongSoMoiTruong(donHang, "Không khí");
            fThongSoMoiTruong4 = new fThongSoMoiTruong(donHang, "Khí thải");
            LoadData();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            langManager.LanguageChanged += LangManager_LanguageChanged;
            this.Load += fViTri_Load;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e) //4/5/2025
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts() //4/5/2025
        {
            labelTypeStats.Text = TranslateLoaiVT(currentLoaiVT);
        }
        private string TranslateLoaiVT(string original)
        {
            // Nếu đang là tiếng Anh, chuyển đổi theo yêu cầu
            if (LanguageManager.Instance.CurrentLanguage == "en")
            {
                switch (original)
                {
                    case "ĐẤT":
                        return "Soil";
                    case "NƯỚC":
                        return "Water";
                    case "KHÔNG KHÍ":
                        return "Air";
                    case "KHÍ THẢI":
                        return "Emission";
                    default:
                        return original;
                }
            }
            else // Nếu tiếng Việt, giữ nguyên
            {
                return original;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e) //4/5/2025
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        #region methods
        protected override void ApplyDarkMode(bool darkMode)
        {
            //base.ApplyDarkMode(darkMode);
            if (panelBody != null && panelPage != null && panelMenu != null)
            {
                this.BackColor = DarkModeManager.GetForeColor();
                panelPage.BackColor = DarkModeManager.GetForeColor();
                panelBody.BackColor = DarkModeManager.GetForeColor();
                panelMenu.BackColor = DarkModeManager.GetBackgroundColor();
                panelTitle.BackColor = DarkModeManager.GetForeColor();

                //Fore Color
                labelTypeStats.ForeColor = DarkModeManager.GetBackgroundColor();
                labelPage.ForeColor = DarkModeManager.GetBackgroundColor();
                labelCongTy.ForeColor = DarkModeManager.GetBackgroundColor();
                labelDonHang.ForeColor = DarkModeManager.GetBackgroundColor();
                ckbStatus.ForeColor = DarkModeManager.GetBackgroundColor();
            }
        }
        public void openChildForm(Form childForm)
        {
            //if (formChild != null)
            //{
            //    formChild.Close();
            //    panelBody.Controls.Remove(formChild);
            //    formChild.Dispose();
            //}
            formChild = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = this.BackColor;
            //this.BackColorChanged += (s, e) =>
            //{
            //    childForm.BackColor = this.BackColor;
            //    childForm.ForeColor = this.ForeColor;
            //};
            panelBody.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void buttonControl(FontAwesome.Sharp.IconButton btn)
        {
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is FontAwesome.Sharp.IconButton button)
                {
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.BackColor = DarkModeManager.GetBackgroundColor();
                    button.IconColor = DarkModeManager.GetForeColor();
                }
            }
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.BackColor = DarkModeManager.GetForeColor();
            btn.IconColor = DarkModeManager.GetBackgroundColor();
        }
        private void LoadData()
        {
            labelDonHang.Text = _donHang.MaDH.ToString();
            labelCongTy.Text = _donHang.TenCT.ToString();
        }
        #endregion
        #region events
        // Remove the first fViTri_Load method (around line 100)
        // Keep only this implementation in the #region events section
        private async void fViTri_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    this.Invoke((MethodInvoker)(() => openChildForm(fThongSoMoiTruong1)));
                    this.Invoke((MethodInvoker)(() => openChildForm(fThongSoMoiTruong2)));
                    this.Invoke((MethodInvoker)(() => openChildForm(fThongSoMoiTruong3)));
                    this.Invoke((MethodInvoker)(() => openChildForm(fThongSoMoiTruong4)));
                });

                this.Invoke((MethodInvoker)(() =>
                {
                    fThongSoMoiTruong2.Hide();
                    fThongSoMoiTruong3.Hide();
                    fThongSoMoiTruong4.Hide();
                    btnDat_Click(sender, e);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnDat_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong1.Show();
            fThongSoMoiTruong1.BringToFront();
            buttonControl(btnDat);
            currentLoaiVT = "ĐẤT";
            labelTypeStats.Text = TranslateLoaiVT(currentLoaiVT);
            //labelPage.Text = "Đất";
        }
        private void btnNuoc_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong2.Show();
            fThongSoMoiTruong2.BringToFront();
            buttonControl(btnNuoc);
            currentLoaiVT = "NƯỚC";
            labelTypeStats.Text = TranslateLoaiVT(currentLoaiVT);
            //labelPage.Text = "Nước";
        }
        private void btnKhongKhi_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong3.Show();
            fThongSoMoiTruong3.BringToFront();
            buttonControl(btnKhongKhi);
            currentLoaiVT = "KHÔNG KHÍ";
            labelTypeStats.Text = TranslateLoaiVT(currentLoaiVT);
            //labelPage.Text = "Không khí";
        }
        private void btnKhiThai_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong4.Show();
            fThongSoMoiTruong4.BringToFront();
            buttonControl(btnKhiThai);
            currentLoaiVT = "KHÍ THẢI";
            labelTypeStats.Text = TranslateLoaiVT(currentLoaiVT);
            //labelPage.Text = "Khí thải";
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fViTri_FormClosing(object sender, FormClosingEventArgs e)
        {
            fThongSoMoiTruong1.Close();
            fThongSoMoiTruong2.Close();
            fThongSoMoiTruong3.Close();
            fThongSoMoiTruong4.Close();
        }
        private void ckbStatus_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbStatus.Checked)
            {
                checkStatus = true;
                _donHang.Trangthai = "Hoàn thành";
            }
            else
            {
                checkStatus = false;

                if (_donHang.NgayKQ < DateTime.Now)
                {
                    _donHang.Trangthai = "Quá hạn";
                }
                else
                {
                    _donHang.Trangthai = "Đang xử lý";
                }
            }
            DonHangBLL.Instance.SetStatus(_donHang.MaDH, _donHang.Trangthai);
        }
        #endregion

    }
}
