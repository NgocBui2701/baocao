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
            cboNam2 = new ComboBox();
            cboDot = new ComboBox();
            cboNam = new ComboBox();
            cboQuy = new ComboBox();
            panelFooter = new Panel();
            splitContainerBody = new SplitContainer();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerBody).BeginInit();
            splitContainerBody.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(cboNam2);
            panelHeader.Controls.Add(cboDot);
            panelHeader.Controls.Add(cboNam);
            panelHeader.Controls.Add(cboQuy);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1143, 68);
            panelHeader.TabIndex = 0;
            // 
            // cboNam2
            // 
            cboNam2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboNam2.Location = new Point(1010, 12);
            cboNam2.Name = "cboNam2";
            cboNam2.Size = new Size(121, 33);
            cboNam2.TabIndex = 4;
            cboNam2.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
            // 
            // cboDot
            // 
            cboDot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboDot.Items.AddRange(new object[] { "1", "2" });
            cboDot.Location = new Point(883, 12);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(121, 33);
            cboDot.TabIndex = 5;
            cboDot.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
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
            panelFooter.Location = new Point(0, 600);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1143, 150);
            panelFooter.TabIndex = 2;
            // 
            // splitContainerBody
            // 
            splitContainerBody.Dock = DockStyle.Fill;
            splitContainerBody.Location = new Point(0, 68);
            splitContainerBody.Name = "splitContainerBody";
            // 
            // splitContainerBody.Panel1
            // 
            splitContainerBody.Panel1.BackColor = Color.Transparent;
            splitContainerBody.Panel1.ForeColor = Color.Transparent;
            // 
            // splitContainerBody.Panel2
            // 
            splitContainerBody.Panel2.BackColor = Color.Transparent;
            splitContainerBody.Panel2.ForeColor = Color.Transparent;
            splitContainerBody.Size = new Size(1143, 532);
            splitContainerBody.SplitterDistance = 300;
            splitContainerBody.TabIndex = 3;
            splitContainerBody.SizeChanged += splitContainerBody_SizeChanged;
            // 
            // fThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(splitContainerBody);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fThongKe";
            Text = "Form6";
            ForeColorChanged += fThongKe_ForeColorChanged;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerBody).EndInit();
            splitContainerBody.ResumeLayout(false);
            ResumeLayout(false);
            //
            // chartQuy
            //
            chartQuy = new Chart();
            chartQuy.Dock = DockStyle.Fill;
            splitContainerBody.Panel1.Controls.Add(chartQuy);
            chartQuy.BackColor = this.BackColor;
            chartQuy.Titles.Add("Biểu đồ trạng thái đơn hàng theo quý");
            chartQuy.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chartQuy.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            chartQuy.Titles[0].IsDockedInsideChartArea = true;
            chartQuy.MouseClick += ChartQuy_MouseClick;
            //
            // chartDot
            //
            chartDot = new Chart();
            chartDot.Dock = DockStyle.Fill;
            splitContainerBody.Panel2.Controls.Add(chartDot);
            chartDot.BackColor = this.BackColor;
            chartDot.Titles.Add("Biểu đồ trạng thái đơn hàng theo đợt");
            chartDot.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chartDot.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            chartDot.Titles[0].IsDockedInsideChartArea = true;
            chartDot.MouseClick += ChartDot_MouseClick;
        }

        #endregion

        private Panel panelHeader;
        private Panel panelFooter;
        private ComboBox cboNam2;
        private ComboBox cboDot;
        private SplitContainer splitContainerBody;
    }
}