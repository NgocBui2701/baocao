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
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    //Updated by DevUI 19:38 02/04/2025
    public partial class FormTest : DarkModeForm
    {
        public FormTest()
        {
            //    InitializeComponent();
            //    ApplyDarkMode(DarkModeManager.IsDarkMode);

            //    //Back Color
            //    this.BackColor = DarkModeManager.GetBackgroundColor();

            //    this.BackgroundImage = Properties.Resources.panelBodyLight;
            //    labelTitle.BackColor = DarkModeManager.GetForeColor();
            //    panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            //    panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
            //    // Label Back Color
            //    labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 0);
            //    //Fore Color
            //    labelTitle.ForeColor = DarkModeManager.GetBackgroundColor();
            //    buttonLuu.ForeColor = DarkModeManager.GetBackgroundColor();
            //    buttonHuy.ForeColor = DarkModeManager.GetBackgroundColor();
            //    //Border Color
            //    panelBody.BorderColor = DarkModeManager.GetBackgroundColor();
            //    //Fill Color
            //    panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            //    panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetBackgroundColor(), 50);
            //    //label Fore Color
            //    labelNLM.ForeColor = DarkModeManager.GetForeColor();
            //    labelMaHD.ForeColor = DarkModeManager.GetForeColor();
            //    labelTrangthai.ForeColor = DarkModeManager.GetForeColor();
            //    labelMaDH.ForeColor = DarkModeManager.GetForeColor();
            //    labelQuy.ForeColor = DarkModeManager.GetForeColor();
            //    labelNKQ.ForeColor = DarkModeManager.GetForeColor();
            //    foreach (Control ctrl in panelBody.Controls)
            //    {
            //        if (ctrl is Guna.UI2.WinForms.Guna2TextBox txt)
            //        {
            //            txt.ForeColor = DarkModeManager.GetDark();
            //            txt.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        }
            //        if (ctrl is Guna.UI2.WinForms.Guna2DateTimePicker dtp)
            //        {
            //            dtp.ForeColor = DarkModeManager.GetDark();
            //            dtp.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        }
            //        if (ctrl is Guna.UI2.WinForms.Guna2ComboBox cbb)
            //        {
            //            cbb.ForeColor = DarkModeManager.GetDark();
            //            cbb.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        }
            //    }
            //    if (DarkModeManager.IsDarkMode)
            //    {
            //        //Back Color
            //        this.BackColor = DarkModeManager.GetBackgroundColor();
            //        this.BackgroundImage = Properties.Resources.panelBodyLight;
            //        labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            //        panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            //        panelBody.BackgroundImage = Properties.Resources.panelBodyLight;
            //        buttonLuu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        buttonHuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        // Label Back Color
            //        labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        //Fore Color
            //        labelTitle.ForeColor = DarkModeManager.GetForeColor();
            //        buttonLuu.ForeColor = DarkModeManager.GetForeColor();
            //        buttonHuy.ForeColor = DarkModeManager.GetForeColor();
            //        //Border Color
            //        panelBody.BorderColor = DarkModeManager.GetForeColor();
            //        //Fill Color
            //        buttonLuu.FillColor = DarkModeManager.GetBackgroundColor();
            //        panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            //        panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
            //        //label Fore Color
            //        labelNLM.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelMaHD.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelTrangthai.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelMaDH.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelQuy.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelNKQ.ForeColor = DarkModeManager.GetBackgroundColor();
            //    }
            //    else
            //    {
            //        //Back Color
            //        this.BackColor = DarkModeManager.GetBackgroundColor();
            //        this.BackgroundImage = Properties.Resources.panelBodyDark;
            //        labelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            //        panelTitle.BackColor = DarkModeManager.GetBackgroundColor();
            //        panelBody.BackgroundImage = Properties.Resources.panelBodyDark;
            //        buttonLuu.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        buttonHuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        // Label Back Color
            //        labelNLM.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelMaHD.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelTrangthai.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelMaDH.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelQuy.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        labelNKQ.BackColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 0);
            //        //Fore Color
            //        labelTitle.ForeColor = DarkModeManager.GetForeColor();
            //        buttonLuu.ForeColor = DarkModeManager.GetForeColor();
            //        buttonHuy.ForeColor = DarkModeManager.GetBackgroundColor();
            //        //Border Color
            //        panelBody.BorderColor = DarkModeManager.GetForeColor();
            //        //Fill Color
            //        buttonLuu.FillColor = DarkModeManager.GetBackgroundColor();
            //        panelTitle.FillColor = DarkModeManager.GetBackgroundColor();
            //        panelBody.FillColor = ChangeOpacityByPercentage(DarkModeManager.GetForeColor(), 50);
            //        //label Fore Color
            //        labelNLM.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelMaHD.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelTrangthai.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelMaDH.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelQuy.ForeColor = DarkModeManager.GetBackgroundColor();
            //        labelNKQ.ForeColor = DarkModeManager.GetBackgroundColor();
            //    }
        }

        public Color ChangeOpacityByPercentage(Color baseColor, int opacityPercentage)
        {
            // Ensure percentage is within valid range (0% to 100%)
            opacityPercentage = Math.Max(0, Math.Min(100, opacityPercentage));

            // Calculate alpha from the percentage
            int alpha = (int)((opacityPercentage / 100.0) * 255);

            // Return a new transparent color
            return Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu thành công");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpNLM_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbMaCT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeePass_Click(object sender, EventArgs e)
        {

        }

        private void labelMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void labelVaiTro_Click(object sender, EventArgs e)
        {

        }

        private void labelMaND_Click(object sender, EventArgs e)
        {

        }

        private void labelMaHD_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
