namespace baocao
{
    partial class fCaiDat
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelSetting = new Panel();
            darkMode = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelSetting.SuspendLayout();
            SuspendLayout();
            // 
            // panelSetting
            // 
            panelSetting.BackColor = Color.Transparent;
            panelSetting.Controls.Add(darkMode);
            panelSetting.Controls.Add(button6);
            panelSetting.Controls.Add(button5);
            panelSetting.Controls.Add(button4);
            panelSetting.Controls.Add(button3);
            panelSetting.Controls.Add(button2);
            panelSetting.Controls.Add(button1);
            panelSetting.Dock = DockStyle.Fill;
            panelSetting.ForeColor = Color.Transparent;
            panelSetting.Location = new Point(0, 0);
            panelSetting.Name = "panelSetting";
            panelSetting.Size = new Size(800, 450);
            panelSetting.TabIndex = 0;
            // 
            // darkMode
            // 
            darkMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            darkMode.BackColor = Color.Transparent;
            darkMode.CheckedState.BorderColor = Color.LawnGreen;
            darkMode.CheckedState.BorderThickness = 2;
            darkMode.CheckedState.FillColor = Color.Transparent;
            darkMode.CheckedState.InnerBorderColor = Color.Transparent;
            darkMode.CheckedState.InnerColor = Color.LawnGreen;
            darkMode.CustomizableEdges = customizableEdges1;
            darkMode.Location = new Point(705, 43);
            darkMode.Name = "darkMode";
            darkMode.ShadowDecoration.CustomizableEdges = customizableEdges2;
            darkMode.Size = new Size(35, 20);
            darkMode.TabIndex = 14;
            darkMode.UncheckedState.BorderColor = Color.DarkOrange;
            darkMode.UncheckedState.BorderThickness = 2;
            darkMode.UncheckedState.FillColor = Color.Transparent;
            darkMode.UncheckedState.InnerBorderColor = Color.Transparent;
            darkMode.UncheckedState.InnerColor = Color.DarkOrange;
            darkMode.CheckedChanged += darkMode_CheckedChanged;
            // 
            // button6
            // 
            button6.Location = new Point(22, 329);
            button6.Name = "button6";
            button6.Size = new Size(223, 23);
            button6.TabIndex = 13;
            button6.Text = "Chính sách bảo mật";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(22, 283);
            button5.Name = "button5";
            button5.Size = new Size(223, 23);
            button5.TabIndex = 12;
            button5.Text = "Thông tin phiên bản và cập nhật";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(22, 224);
            button4.Name = "button4";
            button4.Size = new Size(223, 23);
            button4.TabIndex = 11;
            button4.Text = "Hệ thống";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(22, 167);
            button3.Name = "button3";
            button3.Size = new Size(223, 23);
            button3.TabIndex = 10;
            button3.Text = "Dữ liệu";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(22, 103);
            button2.Name = "button2";
            button2.Size = new Size(223, 23);
            button2.TabIndex = 9;
            button2.Text = "Phương thức thanh toán";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(22, 40);
            button1.Name = "button1";
            button1.Size = new Size(223, 23);
            button1.TabIndex = 8;
            button1.Text = "Cài đặt đơn hàng";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelSetting);
            FormBorderStyle = FormBorderStyle.None;
            Name = "setting";
            Text = "Form1";
            Load += setting_Load;
            panelSetting.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSetting;
        private Guna.UI2.WinForms.Guna2ToggleSwitch darkMode;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}