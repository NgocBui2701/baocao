namespace baocao.GUI
{
    partial class fAITiengViet
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
            btnStart = new Button();
            btnStop = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 20F);
            btnStart.Location = new Point(101, 170);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(207, 107);
            btnStart.TabIndex = 0;
            btnStart.Text = "Bắt đầu";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Segoe UI", 20F);
            btnStop.Location = new Point(481, 170);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(207, 107);
            btnStop.TabIndex = 1;
            btnStop.Text = "Kết thúc";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // fAITiengViet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "fAITiengViet";
            Text = "fAITiengViet";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
    }
}