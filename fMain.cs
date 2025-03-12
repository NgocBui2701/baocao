using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DTO;

namespace baocao
{
    public partial class fMain : Form
    {
        private Account loginAccount;
        private Form formChild = null;
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        bool isDarkMode = Properties.Settings.Default.DarkMode;
        bool menuExpand = true;
        Color menuItemColor = Color.White;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        Color mainColor = Color.DarkOrange;
        public fMain(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            SetLoginAccount(loginAccount);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
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
        void changeAccount(string vai_tro)
        {
            if (formChild is fTaiKhoan child)
            {
                child.enableAdmin(vai_tro == "Quản trị viên");
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
                    button.BackColor = mainColor;
                    button.ForeColor = menuItemColor;
                    button.IconColor = menuItemColor;
                }
            }
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            btn.ForeColor = Color.Chocolate;
            btn.IconColor = Color.Chocolate;
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
            Color itemColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            Color backgroundColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            this.BackColor = backgroundColor;
            labelPage.ForeColor = itemColor;
            labelName.ForeColor = itemColor;
            btnPage.IconColor = itemColor;
            btnPage.BackColor = backgroundColor;
            btnNoti.BackColor = backgroundColor;
            btnMinimize.BackColor = btnRestoreDown.BackColor = btnExit.BackColor = backgroundColor;
            btnLogo.Enabled = false;
            btnPage.Enabled = false;
            this.ActiveControl = null;
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
            openChildForm(new fTrangChu());
            buttonControl(btnHome);
            this.ActiveControl = null;
        }
        private void btnHopDong_Click(object sender, EventArgs e)
        {
            openChildForm(new fHopDong());
            buttonControl(btnHopDong);
            this.ActiveControl = null;
        }
        private void btnDonHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fDonHang());
            buttonControl(btnDonHang);
            this.ActiveControl = null;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new fThongKe());
            buttonControl(btnThongKe);
            this.ActiveControl = null;
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            fCaiDat formCaiDat = new fCaiDat();
            formCaiDat.TaiKhoanButtonClicked += fCaiDat_TaiKhoanButtonClicked;
            openChildForm(formCaiDat);
            buttonControl(btnCaiDat);
            this.ActiveControl = null;
        }
        private void fCaiDat_TaiKhoanButtonClicked(object sender, EventArgs e)
        {
            openChildForm(new fTaiKhoan(loginAccount));
        }
        private void btnNoti_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        private void btnNoti_MouseEnter(object sender, EventArgs e)
        {
            btnNoti.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnNoti.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }
        private void btnNoti_MouseLeave(object sender, EventArgs e)
        {
            btnNoti.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }
        private void menuTimer_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                panelMenu.Width -= 20;
                foreach (Control ctrl in panelMenu.Controls)
                {
                    if (ctrl is FontAwesome.Sharp.IconButton button && button != btnLogo)
                    {
                        if (button.Tag == null) 
                            button.Tag = button.Text;

                        button.Text = "";
                    }
                }
                if (panelMenu.Width <= 60)
                {
                    menuExpand = false;
                    menuTimer.Stop();
                }
            }
            else
            {
                panelMenu.Width += 20;
                if (panelMenu.Width >= 250)
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
        private void home_BackColorChanged(object sender, EventArgs e)
        {
            isDarkMode = Properties.Settings.Default.DarkMode;
            Color itemColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            Color backgroundColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            labelName.ForeColor = itemColor;
            labelPage.ForeColor = btnPage.IconColor = itemColor;
            btnPage.BackColor = btnNoti.BackColor = backgroundColor;
            btnMinimize.BackColor = btnRestoreDown.BackColor = btnExit.BackColor = backgroundColor;
            buttonControl(btnCaiDat);
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
        #endregion

    }
}
