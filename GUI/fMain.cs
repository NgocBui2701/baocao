using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using FontAwesome.Sharp;

namespace baocao.GUI
{
    public partial class fMain : DarkModeForm
    {
        private Form currentChildForm;
        private LanguageManager langManager = LanguageManager.Instance; //4/5/2025
        private Account loginAccount;
        private Form formChild = null;
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        bool menuExpand = true;
        fTrangChu fTrangChu = new fTrangChu();
        fHopDong fHopDong = new fHopDong();
        fDonHang fDonHang = new fDonHang();
        fThongKe fThongKe = new fThongKe();
        fHuongDan fHuongDan = new fHuongDan();
        fQuanLyPhanQuyen fQuanLyPhanQuyen = new fQuanLyPhanQuyen();
        fCaiDat fCaiDat;
        private fTaiKhoan _fTaiKhoan;
        private fCongTy _fCongTy;
        private fBackupRestore _fBackupRestore;
        public fMain(Account acc) : base()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            btnGuide.Visible = false;
            this.loginAccount = acc;
            fCaiDat = new fCaiDat(acc);
            SetLoginAccount(loginAccount);
            labelUser.Text = loginAccount.Ten;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            fDonHang.OnOpenViTri += (donHang) =>
            {
                try
                {
                    // Safely check for existing forms
                    fViTri existingForm = null;
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is fViTri && !form.IsDisposed)
                        {
                            existingForm = (fViTri)form;
                            break;
                        }
                    }

                    if (existingForm != null)
                    {
                        existingForm.BringToFront();
                        return;
                    }

                    fViTri f = new fViTri(donHang);
                    f.FormClosed += (s, e) =>
                    {
                        fDonHang.LoadData();
                    };
                    openChildForm(f);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            //4/5/2025
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
            this.Text = langManager.Translate("home");
            labelPage.Text = langManager.Translate("settings");
            btnHopDong.Text = langManager.Translate("contract_form_title");
            btnDonHang.Text = langManager.Translate("order_list");
            btnThongKe.Text = langManager.Translate("thong_ke");
            btnGuide.Text = langManager.Translate("guide");
            btnManage.Text = langManager.Translate("manage");
            btnCaiDat.Text = langManager.Translate("settings");
            btnHome.Text = langManager.Translate("home");
        }
        #region Methods
        public Account GetLoginAccount()
        {
            return loginAccount;
        }
        public void SetLoginAccount(Account value)
        {
            loginAccount = value;
            changeAccount(loginAccount.VaiTro);
        }
        private void changeAccount(string vai_tro)
        {
            // Hiển thị nút Quản lý chỉ khi có quyền quản lý phân quyền
            btnManage.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManagePermissions);
        }
        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            if (panelMenu != null)
            {
                panelMenu.BackColor = DarkModeManager.GetForeColor();
                panelMenu.ForeColor = DarkModeManager.GetBackgroundColor();
                picLogo.BackColor = panelMenu.BackColor;
                foreach (Control ctrl in panelMenu.Controls)
                {
                    if (ctrl is IconButton iconButton)
                    {
                        iconButton.IconColor = panelMenu.ForeColor;
                        iconButton.BackColor = panelMenu.BackColor;
                        iconButton.ForeColor = panelMenu.ForeColor;
                    }
                    if (ctrl is Panel)
                    {
                        ctrl.BackColor = panelMenu.BackColor;
                        ctrl.ForeColor = panelMenu.ForeColor;
                    }
                }
                btnUser.MouseEnter += (s, e) => btnUser.BackColor = panelMenu.BackColor;
                btnUser.MouseLeave += (s, e) => btnUser.BackColor = panelMenu.BackColor;
                labelUser.BackColor = panelMenu.BackColor;
                labelUser.ForeColor = panelMenu.ForeColor;
                btnMenu.IconColor = panelMenu.ForeColor;
                btnMenu.BackColor = panelMenu.BackColor;
                btnMenu.MouseEnter += (s, e) => btnMenu.BackColor = panelMenu.BackColor;
                btnMenu.MouseLeave += (s, e) => btnMenu.BackColor = panelMenu.BackColor;
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
            this.BackColorChanged += (s, e) =>
            {
                childForm.BackColor = this.BackColor;
                childForm.ForeColor = this.ForeColor;
            };
            panelBody.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void buttonControl(FontAwesome.Sharp.IconButton btn)
        {
            btnPage.IconChar = btn.IconChar;
            labelPage.Text = btn.Text;
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is FontAwesome.Sharp.IconButton button)
                {
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.BackColor = panelMenu.BackColor;
                    button.ForeColor = panelMenu.ForeColor;
                    button.IconColor = panelMenu.ForeColor;
                }
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is FontAwesome.Sharp.IconButton button2)
                    {
                        button2.BackColor = panelMenu.BackColor;
                        button2.IconColor = panelMenu.ForeColor;
                    }
                }
            }
            btn.BackColor = panelMenu.ForeColor;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.ForeColor = panelMenu.BackColor;
            btn.IconColor = panelMenu.BackColor;
        }
        public void OpenDonHangWithNotification(string orderId)
        {
            if (currentChildForm is fDonHang donHangForm)
            {
                donHangForm.SelectOrderById(orderId);
            }
            else
            {
                openChildForm(new fDonHang(orderId));
                if (btnDonHang != null)
                {
                    buttonControl(btnDonHang);
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));

                if (sizeGripRectangle.Contains(hitPoint))
                {
                    m.Result = new IntPtr(HTBOTTOMRIGHT);
                    return;
                }
            }
            base.WndProc(ref m);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelMain.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        #endregion
        #region Events
        private void fMain_Load(object sender, EventArgs e)
        {
            btnPage.Enabled = false;
            this.ActiveControl = null;
            openChildForm(fTrangChu);
            openChildForm(fHopDong);
            openChildForm(fDonHang);
            openChildForm(fThongKe);
            openChildForm(fHuongDan);
            labelUser.Left = (panelUser.Width -labelUser.Width)/2;
            if (fQuanLyPhanQuyen != null)
            {
                openChildForm(fQuanLyPhanQuyen);
            }
            
            openChildForm(fCaiDat);
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            btnHome_Click(sender, e);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Application.Exit();
        }
        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else this.WindowState = FormWindowState.Maximized;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ActiveControl = null;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
               f.Close();
            }
            fTrangChu.BringToFront();
            currentChildForm = fTrangChu;
            buttonControl(btnHome);
            this.ActiveControl = null;
        }
        private void btnHopDong_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            fHopDong.BringToFront();
            currentChildForm = fHopDong; 
            buttonControl(btnHopDong);
            this.ActiveControl = null;
        }
        private void btnDonHang_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            fDonHang.BringToFront();
            currentChildForm = fDonHang;
            buttonControl(btnDonHang);
            this.ActiveControl = null;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            fThongKe.BringToFront();
            currentChildForm = fThongKe;
            buttonControl(btnThongKe);
            this.ActiveControl = null;
        }
        private void btnGuide_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            fHuongDan.BringToFront();
            currentChildForm = fHuongDan;
            buttonControl(btnGuide);
            this.ActiveControl = null;
        }
        private void btnManage_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            if (fQuanLyPhanQuyen != null)
            {
                fQuanLyPhanQuyen.BringToFront();
                currentChildForm = fQuanLyPhanQuyen;
                buttonControl(btnManage);
            }
            this.ActiveControl = null;
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["fViTri"];
            if (f != null)
            {
                f.Close();
            }
            fCaiDat.BringToFront();
            currentChildForm = fCaiDat;
            buttonControl(btnCaiDat);
            if (_fTaiKhoan == null)
            {
                _fTaiKhoan = new fTaiKhoan(loginAccount);
                openChildForm(_fTaiKhoan);
                _fTaiKhoan.Hide();
            }

            if (_fCongTy == null)
            {
                _fCongTy = new fCongTy();
                openChildForm(_fCongTy);
                _fCongTy.Hide();
            }
            if (_fBackupRestore == null)
            {
                _fBackupRestore = new fBackupRestore();
                openChildForm(_fBackupRestore);
                _fBackupRestore.Hide();
            }
            fCaiDat.TaiKhoanButtonClicked += fCaiDat_TaiKhoanButtonClicked;
            fCaiDat.CongTyButtonClicked += fCaiDat_CongTyButtonClicked;
            fCaiDat.DarkModeChanged += fCaiDat_DarkModeChanged;
            fCaiDat.HeThongButtonClicked += fCaiDat_HeThongButtonClicked;
            _fTaiKhoan.VisibleChanged += fTaiKhoan_VisibleChanged;
            _fCongTy.VisibleChanged += fTaiKhoan_VisibleChanged;
            _fBackupRestore.VisibleChanged += fBackupRestore_VisibleChanged;
            this.ActiveControl = null;
        }
        private void fCaiDat_HeThongButtonClicked(object sender, EventArgs e)
        {
            if (_fBackupRestore != null)
            {
                _fBackupRestore.BringToFront();
                currentChildForm = _fBackupRestore;
                _fBackupRestore.Show();
            }
            labelPage.Text = "Hệ Thống";
            btnPage.IconChar = FontAwesome.Sharp.IconChar.Tools;
        }
        private void fBackupRestore_VisibleChanged(object sender, EventArgs e)
        {
            if (!_fBackupRestore.Visible)
            {
                btnCaiDat_Click(sender, e);
            }
        }
        private void fTaiKhoan_VisibleChanged(object sender, EventArgs e)
        {
            if (!_fTaiKhoan.Visible)
            {
                btnCaiDat_Click(sender, e);
            }
        }
        private void fCaiDat_TaiKhoanButtonClicked(object sender, EventArgs e)
        {
            if (_fTaiKhoan != null)
            {
                _fTaiKhoan.BringToFront();
                currentChildForm = _fTaiKhoan;
                _fTaiKhoan.Show();
            }
            labelPage.Text = langManager.Translate("account");
            btnPage.IconChar = FontAwesome.Sharp.IconChar.Vcard;
        }
        private void fCaiDat_CongTyButtonClicked(object sender, EventArgs e)
        {
            if (_fCongTy != null)
            {
                _fCongTy.BringToFront();
                currentChildForm = _fCongTy;
                _fCongTy.Show();
            }
            labelPage.Text = langManager.Translate("company");
            btnPage.IconChar = FontAwesome.Sharp.IconChar.Briefcase;
        }

        private void fCaiDat_DarkModeChanged(object sender, EventArgs e)
        {
            buttonControl(btnCaiDat);
        }
        private void btnNoti_Click(object sender, EventArgs e)
        {
            fThongBao frmThongBao = new fThongBao();
            frmThongBao.Show();
            this.ActiveControl = null;
        }
        private void btnNoti_MouseEnter(object sender, EventArgs e)
        {
            btnNoti.IconFont = ((IconButton)sender) == btnNoti ? FontAwesome.Sharp.IconFont.Regular : ((IconButton)sender).IconFont;
            ((IconButton)sender).BackColor = this.BackColor;
        }
        private void btnNoti_MouseLeave(object sender, EventArgs e)
        {
            btnNoti.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }
        private void menuTimer_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                panelMenu.Width -= 30;
                btnUser.Visible = false;
                labelUser.Visible = false;
                foreach (Control ctrl in panelMenu.Controls)
                {
                    if (ctrl is FontAwesome.Sharp.IconButton button)
                    {
                        if (button.Tag == null)
                            button.Tag = button.Text;

                        button.Text = "";
                    }
                }
                if (panelMenu.Width <= 87)
                {
                    menuExpand = false;
                    menuTimer.Stop();
                }
            }
            else
            {
                panelMenu.Width += 30;
                btnUser.Visible = true;
                labelUser.Visible = true;
                if (panelMenu.Width >= 357)
                {
                    foreach (Control ctrl in panelMenu.Controls)
                    {
                        if (ctrl is FontAwesome.Sharp.IconButton button)
                        {
                            if (button.Tag != null)
                            {
                                button.Text = button.Tag.ToString();
                            }
                        }
                    }
                    menuExpand = true;
                    menuTimer.Stop();
                }
            }
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuTimer.Start();
            this.ActiveControl = null;
        }
        private void fMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ActiveControl = null;
            }
        }
        private void PanelNavbar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
