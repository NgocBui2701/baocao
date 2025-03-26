namespace baocao
{
    partial class fDSHD
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
            textBox1 = new TextBox();
            button8 = new Button();
            button7 = new Button();
            textBox2 = new TextBox();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            panel2 = new Panel();
            lvDSHD = new ListView();
            MaCT = new ColumnHeader();
            TenCT = new ColumnHeader();
            KyHieuCT = new ColumnHeader();
            NgayKyHD = new ColumnHeader();
            TenDaiDien = new ColumnHeader();
            SDT = new ColumnHeader();
            DiaChi = new ColumnHeader();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Location = new Point(268, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(80, 23);
            textBox1.TabIndex = 10;
            textBox1.Text = "search ";
            // 
            // button8
            // 
            button8.Location = new Point(15, 24);
            button8.Name = "button8";
            button8.Size = new Size(60, 23);
            button8.TabIndex = 9;
            button8.Text = "insert";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(434, 14);
            button7.Name = "button7";
            button7.Size = new Size(66, 51);
            button7.TabIndex = 8;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(322, 13);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(40, 23);
            textBox2.TabIndex = 19;
            textBox2.Text = "...";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.None;
            button11.Location = new Point(237, 12);
            button11.Name = "button11";
            button11.Size = new Size(38, 23);
            button11.TabIndex = 18;
            button11.Text = "2";
            button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.None;
            button10.Location = new Point(278, 12);
            button10.Name = "button10";
            button10.Size = new Size(38, 23);
            button10.TabIndex = 17;
            button10.Text = "3";
            button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.None;
            button9.Location = new Point(196, 12);
            button9.Name = "button9";
            button9.Size = new Size(38, 23);
            button9.TabIndex = 16;
            button9.Text = "1";
            button9.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom;
            panel2.Controls.Add(button9);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(button11);
            panel2.Controls.Add(button10);
            panel2.Location = new Point(-2, 368);
            panel2.Name = "panel2";
            panel2.Size = new Size(587, 50);
            panel2.TabIndex = 20;
            // 
            // lvDSHD
            // 
            lvDSHD.AllowColumnReorder = true;
            lvDSHD.AllowDrop = true;
            lvDSHD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvDSHD.BackColor = Color.White;
            lvDSHD.Columns.AddRange(new ColumnHeader[] { MaCT, TenCT, KyHieuCT, NgayKyHD, TenDaiDien, SDT, DiaChi });
            lvDSHD.ForeColor = Color.Black;
            lvDSHD.FullRowSelect = true;
            lvDSHD.HoverSelection = true;
            lvDSHD.ImeMode = ImeMode.NoControl;
            lvDSHD.LabelWrap = false;
            lvDSHD.Location = new Point(12, 102);
            lvDSHD.MultiSelect = false;
            lvDSHD.Name = "lvDSHD";
            lvDSHD.Size = new Size(560, 260);
            lvDSHD.TabIndex = 21;
            lvDSHD.UseCompatibleStateImageBehavior = false;
            lvDSHD.View = View.Details;
            lvDSHD.ItemActivate += lvDSHD_ItemActivate;
            // 
            // MaCT
            // 
            MaCT.Text = "Mã công ty";
            MaCT.Width = 100;
            // 
            // TenCT
            // 
            TenCT.Text = "Tên công ty";
            TenCT.Width = 170;
            // 
            // KyHieuCT
            // 
            KyHieuCT.Text = "Ký hiệu công ty";
            KyHieuCT.Width = 120;
            // 
            // NgayKyHD
            // 
            NgayKyHD.Text = "Ngày ký hợp đồng";
            NgayKyHD.Width = 150;
            // 
            // TenDaiDien
            // 
            TenDaiDien.Text = "Tên người đại diện";
            TenDaiDien.Width = 140;
            // 
            // SDT
            // 
            SDT.Text = "Số điện thoại";
            SDT.TextAlign = HorizontalAlignment.Center;
            SDT.Width = 120;
            // 
            // DiaChi
            // 
            DiaChi.Text = "Địa chỉ";
            DiaChi.Width = 320;
            // 
            // fDSHD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 420);
            Controls.Add(lvDSHD);
            Controls.Add(panel2);
            Controls.Add(textBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fDSHD";
            Text = "CM";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Button button8;
        private Button button7;
        private TextBox textBox2;
        private Button button11;
        private Button button10;
        private Button button9;
        private Panel panel2;
        private ListView lvDSHD;
        private ColumnHeader MaCT;
        private ColumnHeader TenCT;
        private ColumnHeader KyHieuCT;
        private ColumnHeader NgayKyHD;
        private ColumnHeader TenDaiDien;
        private ColumnHeader SDT;
        private ColumnHeader DiaChi;
    }
}