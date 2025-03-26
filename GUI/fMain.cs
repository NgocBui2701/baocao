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
        fCaiDat fCaiDat = new fCaiDat();
        private fTaiKhoan _fTaiKhoan;
        private fCongTy _fCongTy;
        public fMain(Account acc) : base()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.loginAccount = acc;
            SetLoginAccount(loginAccount);
            labelUser.Text = loginAccount.Ten;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            fDonHang.OnOpenViTri += (maDH) =>
            {
                openChildForm(new fViTri(maDH));
            };
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
            btnManage.Visible = vai_tro == "Quản trị viên";
        }
        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            if (panelMenu != null)
            {
                panelMenu.BackColor = DarkModeManager.GetForeColor();
                panelMenu.ForeColor = DarkModeManager.GetBackgroundColor();
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
                // Nếu form con hiện tại là fDonHang, chỉ cần cuộn đến dòng
                donHangForm.SelectOrderById(orderId);
            }
            else
            {
                // Nếu không, mở form mới và cuộn đến dòng
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
            btnLogo.Enabled = false;
            btnPage.Enabled = false;
            this.ActiveControl = null;
            openChildForm(fTrangChu);
            openChildForm(fHopDong);
            openChildForm(fDonHang);
            openChildForm(fThongKe);
            openChildForm(fHuongDan);
            if (loginAccount.VaiTro == "Quản trị viên") openChildForm(fQuanLyPhanQuyen);
            openChildForm(fCaiDat);
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            btnHome_Click(sender, e);
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            //((Button)sender).ForeColor = DarkModeManager.GetAccentColor();
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            //((Button)sender).ForeColor = this.ForeColor;
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
            fTrangChu.BringToFront();
            currentChildForm = fTrangChu;
            buttonControl(btnHome);
            this.ActiveControl = null;
        }
        private void btnHopDong_Click(object sender, EventArgs e)
        {
            fHopDong.BringToFront();
            currentChildForm = fHopDong; 
            buttonControl(btnHopDong);
            this.ActiveControl = null;
        }
        private void btnDonHang_Click(object sender, EventArgs e)
        {
            fDonHang.BringToFront();
            currentChildForm = fDonHang;
            buttonControl(btnDonHang);
            this.ActiveControl = null;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            fThongKe.BringToFront();
            currentChildForm = fThongKe;
            buttonControl(btnThongKe);
            this.ActiveControl = null;
        }
        private void btnGuide_Click(object sender, EventArgs e)
        {
            fHuongDan.BringToFront();
            currentChildForm = fHuongDan;
            buttonControl(btnGuide);
            this.ActiveControl = null;
        }
        private void btnManage_Click(object sender, EventArgs e)
        {
            fQuanLyPhanQuyen.BringToFront();
            currentChildForm = fQuanLyPhanQuyen;
            buttonControl(btnManage);
            this.ActiveControl = null;
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
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
            fCaiDat.TaiKhoanButtonClicked += fCaiDat_TaiKhoanButtonClicked;
            fCaiDat.CongTyButtonClicked += fCaiDat_CongTyButtonClicked;
            fCaiDat.DarkModeChanged += fCaiDat_DarkModeChanged;
            _fTaiKhoan.VisibleChanged += fTaiKhoan_VisibleChanged;
            _fCongTy.VisibleChanged += fTaiKhoan_VisibleChanged;
            this.ActiveControl = null;
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
            labelPage.Text = "Tài khoản";
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
            labelPage.Text = "Công ty";
            btnPage.IconChar = FontAwesome.Sharp.IconChar.Briefcase;
        }
        private void fCaiDat_DarkModeChanged(object sender, EventArgs e)
        {
            buttonControl(btnCaiDat);
        }
        private void btnNoti_Click(object sender, EventArgs e)
        {
            fThongBao frmThongBao = new fThongBao();
            frmThongBao.ShowDialog();
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
                    if (ctrl is FontAwesome.Sharp.IconButton button && button != btnLogo)
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
                        if (ctrl is FontAwesome.Sharp.IconButton button && button != btnLogo)
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

        private void btnMenu_MouseEnter(object sender, EventArgs e)
        {
            //btnMenu.IconColor = DarkModeManager.GetAccentColor();
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            //btnMenu.IconColor = DarkModeManager.GetForeColor();
        }
    }
}
