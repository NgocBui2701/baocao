using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private bool dragging = false;
        bool menuExpand = true;

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
            MessageBox.Show($"Vai trò của user: {loginAccount.VaiTro}");
            changeAccount(loginAccount.VaiTro);
            btnCM.Enabled = loginAccount.VaiTro == "Admin";
            btnReports.Enabled = loginAccount.VaiTro == "Admin";
            btnSM.Enabled = loginAccount.VaiTro == "Admin";
        }
        void changeAccount(string vai_tro)
        {
            if (formChild is fTaiKhoan child)
            {
                child.enableAdmin(vai_tro == "Admin");
            }
        }
        private void openChildForm(Form childForm)
        {
            if (formChild != null)
            {
                formChild.Close();
                panelBody.Controls.Remove(formChild);
                formChild.Dispose();
            }
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
        private void buttonControl(Guna.UI2.WinForms.Guna2Button btn)
        {
            labelPage.Text = btn.Text;
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button button)
                {
                    button.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    button.BackColor = Color.Transparent;
                    button.ForeColor = this.BackColor;
                    button.FillColor = Color.Transparent;
                }
            }
            btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btn.BackColor = dragging ? Color.DarkSlateGray : Color.White;
            btn.ForeColor = dragging ? Color.White : Color.Chocolate;
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else this.WindowState = FormWindowState.Maximized;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new fTrangChu());
            buttonControl(btnHome);
        }
        private void btnCM_Click(object sender, EventArgs e)
        {
            openChildForm(new fHopDong());
            buttonControl(btnCM);
        }
        private void btnSM_Click(object sender, EventArgs e)
        {
            openChildForm(new fDonHang());
            buttonControl(btnSM);
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            openChildForm(new fThongKe());
            buttonControl(btnReports);
        }
        private void btnUP_Click(object sender, EventArgs e)
        {
            openChildForm(new fTaiKhoan());
            buttonControl(btnUP);
            changeAccount(loginAccount.VaiTro);
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            openChildForm(new fCaiDat());
            buttonControl(btnSetting);
        }
        private void menuTimer_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                panelMenu.Width -= 10;
                foreach (Control ctrl in panelMenu.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button && ctrl != btnMenu)
                    {
                        ctrl.Hide();
                    }
                }
                btnNoti.Hide();
                if (panelMenu.Width == 30)
                {
                    menuExpand = false;
                    menuTimer.Stop();
                }
            }
            else
            {
                panelMenu.Width += 10;
                foreach (Control ctrl in panelMenu.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button && ctrl != btnMenu)
                    {
                        ctrl.Show();
                    }
                }
                btnNoti.Show();
                if (panelMenu.Width == 210)
                {
                    menuExpand = true;
                    menuTimer.Stop();
                }
            }
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuTimer.Start();
        }
        private void home_BackColorChanged(object sender, EventArgs e)
        {
            dragging = !dragging;
            if (dragging)
            {
                panelMenu.BackColor = Color.LawnGreen;
                panelMenu.ForeColor = Color.FromArgb(30, 30, 30);
            }
            else
            {
                panelMenu.BackColor = Color.DarkOrange;
                panelMenu.ForeColor = Color.White;
            }
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.ForeColor = this.BackColor;
                    btn.DisabledState.ForeColor = this.BackColor;
                }
            }
            foreach (Control ctrl in panelNavbar.Controls)
            {
                if (ctrl is Label || ctrl is Button)
                {
                    ctrl.ForeColor = dragging ? Color.White : Color.Black;
                }
            }
            buttonControl(btnSetting);
        }
        #endregion
    }
}
