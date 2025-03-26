namespace baocao.GUI
{
    partial class fThongBao
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
            listViewNotifications = new ListView();
            SuspendLayout();
            // 
            // listViewNotifications
            // 
            listViewNotifications.Location = new Point(12, 12);
            listViewNotifications.Name = "listViewNotifications";
            listViewNotifications.Size = new Size(776, 426);
            listViewNotifications.TabIndex = 0;
            listViewNotifications.UseCompatibleStateImageBehavior = false;
            // 
            // fThongBao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewNotifications);
            Name = "fThongBao";
            Text = "Thông báo";
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewNotifications;
    }
}