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
    public partial class fCaiDat : Form
    {
        private bool isDarkMode = Properties.Settings.Default.DarkMode;
        public event EventHandler TaiKhoanButtonClicked;
        public fCaiDat()
        {
            InitializeComponent();
        }

        private void setting_Load(object sender, EventArgs e)
        {
            btnDarkMode.IconChar = isDarkMode ? FontAwesome.Sharp.IconChar.ToggleOn : FontAwesome.Sharp.IconChar.ToggleOff;
            btnDarkMode.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            Properties.Settings.Default.DarkMode = isDarkMode;
            Properties.Settings.Default.Save();
            btnDarkMode.IconChar = isDarkMode ? FontAwesome.Sharp.IconChar.ToggleOn : FontAwesome.Sharp.IconChar.ToggleOff;
            btnDarkMode.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            this.ActiveControl = null;
            if (this.ParentForm != null)
            {
                this.ParentForm.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                this.ParentForm.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            }
        }

        private void btnDarkMode_MouseEnter(object sender, EventArgs e)
        {
            btnDarkMode.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }

        private void btnDarkMode_MouseDown(object sender, MouseEventArgs e)
        {
            btnDarkMode.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
