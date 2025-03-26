using System;
using System.Windows.Forms;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fCaiDat : DarkModeForm
    {
        public event EventHandler TaiKhoanButtonClicked;
        public event EventHandler CongTyButtonClicked;
        public event EventHandler DarkModeChanged;

        public fCaiDat()
        {
            InitializeComponent();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            btnDarkMode.IconChar = DarkModeManager.IsDarkMode ? FontAwesome.Sharp.IconChar.Moon : FontAwesome.Sharp.IconChar.Sun;
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            DarkModeManager.IsDarkMode = !DarkModeManager.IsDarkMode;
            btnDarkMode.IconChar = DarkModeManager.IsDarkMode ? FontAwesome.Sharp.IconChar.Moon : FontAwesome.Sharp.IconChar.Sun;
            this.ActiveControl = null;
            DarkModeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCongTy_Click(object sender, EventArgs e)
        {
            CongTyButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDarkMode_MouseEnter(object sender, EventArgs e)
        {
            btnDarkMode.BackColor = this.BackColor;
            btnDarkMode.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }
        private void btnDarkMode_MouseLeave(object sender, EventArgs e)
        {
            btnDarkMode.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }

        private void fCaiDat_BackColorChanged(object sender, EventArgs e)
        {
            btnDarkMode.BackColor = this.BackColor;
        }

    }
}
