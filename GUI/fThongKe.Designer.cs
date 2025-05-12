using System.Windows.Forms.DataVisualization.Charting;

namespace baocao.GUI
{
    partial class fThongKe
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
            panelHeader = new Panel();
            cboNam = new ComboBox();
            cboQuy = new ComboBox();
            panelFooter = new Panel();
            panelBody = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(cboNam);
            panelHeader.Controls.Add(cboQuy);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1143, 68);
            panelHeader.TabIndex = 0;
            // 
            // cboNam
            // 
            cboNam.Location = new Point(139, 12);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(121, 33);
            cboNam.TabIndex = 0;
            cboNam.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
            // 
            // cboQuy
            // 
            cboQuy.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cboQuy.Location = new Point(12, 12);
            cboQuy.Name = "cboQuy";
            cboQuy.Size = new Size(121, 33);
            cboQuy.TabIndex = 1;
            cboQuy.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
            // 
            // panelFooter
            // 
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 515);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1143, 235);
            panelFooter.TabIndex = 2;
            // 
            // panelBody
            // 
            panelBody.BackgroundImage = Properties.Resources.logo60Opa;
            panelBody.BackgroundImageLayout = ImageLayout.Zoom;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 68);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1143, 447);
            panelBody.TabIndex = 3;
            // 
            // fThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(panelBody);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fThongKe";
            Text = "Form6";
            ForeColorChanged += fThongKe_ForeColorChanged;
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            ////
            //// chartQuy
            ////
            chartQuy = new Chart();
            chartQuy.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chartQuy);
            chartQuy.BackColor = this.BackColor;
            chartQuy.Titles.Add("Biểu đồ trạng thái đơn hàng theo quý");
            chartQuy.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chartQuy.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            chartQuy.Titles[0].IsDockedInsideChartArea = true;
            chartQuy.MouseClick += ChartQuy_MouseClick;
        }
      

        #endregion

        private Panel panelHeader;
        private Panel panelFooter;
        private Panel panelBody;
    }
}