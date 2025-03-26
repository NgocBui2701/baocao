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
    public partial class userProfile : Form
    {
        public userProfile()
        {
            InitializeComponent();
        }
        public void enableAdmin(bool isAdmin)
        {
            btnAdmin.Enabled = isAdmin;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
