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

namespace baocao.GUI
{
    public partial class fViTri : Form
    {
        private Form formChild;
        private bool isDarkMode = Properties.Settings.Default.DarkMode;
        private string MaDH;
        private fThongSoMoiTruong fThongSoMoiTruong1 = new fThongSoMoiTruong(1);
        private fThongSoMoiTruong fThongSoMoiTruong2 = new fThongSoMoiTruong(2);
        private fThongSoMoiTruong fThongSoMoiTruong3 = new fThongSoMoiTruong(3);
        private fThongSoMoiTruong fThongSoMoiTruong4 = new fThongSoMoiTruong(4);
        public fViTri(string MaDH)
        {
            InitializeComponent();
            this.MaDH = MaDH;

        }
        #region methods
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
            childForm.BackColor = Color.Black;
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
                    button.BackColor = Color.White;
                    button.IconColor = Color.Black;
                }
            }
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.BackColor = Color.Black;
            btn.IconColor = Color.White;
        }
        #endregion
        #region events
        #endregion

        private void fViTri_Load(object sender, EventArgs e)
        {
            openChildForm(fThongSoMoiTruong1);
            openChildForm(fThongSoMoiTruong2);
            openChildForm(fThongSoMoiTruong3);
            openChildForm(fThongSoMoiTruong4);
            fThongSoMoiTruong2.Hide();
            fThongSoMoiTruong3.Hide();
            fThongSoMoiTruong4.Hide();
            btnDat_Click(sender, e);
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong1.Show();
            fThongSoMoiTruong1.BringToFront();
            buttonControl(btnDat);
            labelPage.Text = "Đất";
        }

        private void btnNuoc_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong2.Show();
            fThongSoMoiTruong2.BringToFront();
            buttonControl(btnNuoc);
            labelPage.Text = "Nước";
        }

        private void btnKhongKhi_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong3.Show();
            fThongSoMoiTruong3.BringToFront();
            buttonControl(btnKhongKhi);
            labelPage.Text = "Không khí";
        }

        private void btnKhiThai_Click(object sender, EventArgs e)
        {
            fThongSoMoiTruong4.Show();
            fThongSoMoiTruong4.BringToFront();
            buttonControl(btnKhiThai);
            labelPage.Text = "Khí thải";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnDat_Click(sender, e);
        }
    }
}
