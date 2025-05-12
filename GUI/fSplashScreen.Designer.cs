namespace baocao.GUI
{
    partial class fSplashScreen
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            timer1 = new System.Windows.Forms.Timer(components);
            HexaTech = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)HexaTech).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += Timer1_Tick;
            // 
            // HexaTech
            // 
            HexaTech.BackColor = Color.Transparent;
            HexaTech.BackgroundImage = Properties.Resources.HexaTech;
            HexaTech.BackgroundImageLayout = ImageLayout.Stretch;
            HexaTech.CustomizableEdges = customizableEdges1;
            HexaTech.FillColor = Color.Transparent;
            HexaTech.ImageRotate = 0F;
            HexaTech.Location = new Point(196, -2);
            HexaTech.Name = "HexaTech";
            HexaTech.ShadowDecoration.CustomizableEdges = customizableEdges2;
            HexaTech.Size = new Size(1212, 652);
            HexaTech.TabIndex = 0;
            HexaTech.TabStop = false;
            // 
            // fSplashScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.logonhom_filled_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1200, 650);
            ControlBox = false;
            Controls.Add(HexaTech);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "fSplashScreen";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Timer1_Tick;
            ((System.ComponentModel.ISupportInitialize)HexaTech).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2PictureBox HexaTech;
    }
}