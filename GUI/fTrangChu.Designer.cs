using baocao.GUI.Managers;

namespace baocao.GUI
{
    partial class fTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTrangChu));
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            labelTitleCompany = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2BorderlessForm2
            // 
            guna2BorderlessForm2.BorderRadius = 30;
            guna2BorderlessForm2.ContainerControl = this;
            guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // labelTitleCompany
            // 
            labelTitleCompany.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTitleCompany.BackColor = Color.Transparent;
            labelTitleCompany.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitleCompany.ForeColor = Color.FromArgb(240, 247, 204);
            labelTitleCompany.Location = new Point(58, 302);
            labelTitleCompany.Margin = new Padding(4);
            labelTitleCompany.Name = "labelTitleCompany";
            labelTitleCompany.Size = new Size(336, 56);
            labelTitleCompany.TabIndex = 7;
            labelTitleCompany.Text = "EcoTest Company";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.AutoSizeHeightOnly = true;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.WhiteSmoke;
            guna2HtmlLabel1.Location = new Point(58, 393);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(911, 289);
            guna2HtmlLabel1.TabIndex = 9;
            guna2HtmlLabel1.Text = resources.GetString("guna2HtmlLabel1.Text");
            // 
            // fTrangChu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 237, 204);
            BackgroundImage = Properties.Resources.trangChu;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1345, 828);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(labelTitleCompany);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(0, -5);
            Margin = new Padding(4, 5, 4, 5);
            Name = "fTrangChu";
            Padding = new Padding(14, 0, 14, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelTitleCompany;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
