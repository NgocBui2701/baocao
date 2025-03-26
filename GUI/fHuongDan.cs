using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.GUI.Managers;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fHuongDan : DarkModeForm
    {
        public fHuongDan()
        {
            InitializeComponent();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }
    }
}
