using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baocao
{
    public partial class fCaiDat : Form
    {
        public fCaiDat()
        {
            InitializeComponent();
        }

        private void darkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.BackColor = darkMode.Checked ? Color.FromArgb(30, 30, 30) : Color.White;
                this.ParentForm.ForeColor = darkMode.Checked ? Color.White : Color.FromArgb(30, 30, 30);
            }
        }

        private void setting_Load(object sender, EventArgs e)
        {
            bool isDarkMode = this.ParentForm.BackColor == Color.FromArgb(30, 30, 30);
            darkMode.Checked = isDarkMode;
        }
    }
}
