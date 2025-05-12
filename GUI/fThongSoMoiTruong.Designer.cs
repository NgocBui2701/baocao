using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    partial class fThongSoMoiTruong
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tabctrlTSMT = new TabControl();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            panelTitle = new Panel();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnExport = new FontAwesome.Sharp.IconButton();
            btnDelVT = new FontAwesome.Sharp.IconButton();
            btnAddVT = new FontAwesome.Sharp.IconButton();
            labelTenVT = new Label();
            panelFooter = new Panel();
            btnDelTS = new FontAwesome.Sharp.IconButton();
            btnInsertTS = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            panelTitle.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // tabctrlTSMT
            // 
            tabctrlTSMT.Appearance = TabAppearance.FlatButtons;
            tabctrlTSMT.Dock = DockStyle.Fill;
            tabctrlTSMT.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabctrlTSMT.Location = new Point(0, 60);
            tabctrlTSMT.Margin = new Padding(4, 5, 4, 5);
            tabctrlTSMT.Name = "tabctrlTSMT";
            tabctrlTSMT.SelectedIndex = 0;
            tabctrlTSMT.Size = new Size(1142, 618);
            tabctrlTSMT.SizeMode = TabSizeMode.Fixed;
            tabctrlTSMT.TabIndex = 0;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            guna2DataGridView1.Dock = DockStyle.Fill;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(4, 5);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 62;
            guna2DataGridView1.Size = new Size(1126, 642);
            guna2DataGridView1.TabIndex = 0;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 33;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(btnSave);
            panelTitle.Controls.Add(btnEdit);
            panelTitle.Controls.Add(btnExport);
            panelTitle.Controls.Add(btnDelVT);
            panelTitle.Controls.Add(btnAddVT);
            panelTitle.Controls.Add(labelTenVT);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1142, 60);
            panelTitle.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 35;
            btnSave.Location = new Point(933, 0);
            btnSave.Margin = new Padding(3, 3, 15, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(41, 60);
            btnSave.TabIndex = 5;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Right;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEdit.IconColor = Color.White;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.IconSize = 35;
            btnEdit.Location = new Point(974, 0);
            btnEdit.Margin = new Padding(3, 3, 15, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(41, 60);
            btnEdit.TabIndex = 4;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnExport
            // 
            btnExport.Dock = DockStyle.Right;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnExport.IconColor = Color.White;
            btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExport.IconSize = 35;
            btnExport.Location = new Point(1015, 0);
            btnExport.Margin = new Padding(3, 3, 15, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(41, 60);
            btnExport.TabIndex = 3;
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Visible = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnDelVT
            // 
            btnDelVT.Dock = DockStyle.Right;
            btnDelVT.FlatAppearance.BorderSize = 0;
            btnDelVT.FlatStyle = FlatStyle.Flat;
            btnDelVT.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDelVT.IconColor = Color.White;
            btnDelVT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelVT.IconSize = 35;
            btnDelVT.Location = new Point(1056, 0);
            btnDelVT.Margin = new Padding(3, 3, 15, 3);
            btnDelVT.Name = "btnDelVT";
            btnDelVT.Size = new Size(41, 60);
            btnDelVT.TabIndex = 2;
            btnDelVT.UseVisualStyleBackColor = true;
            btnDelVT.Click += btnDelVT_Click;
            // 
            // btnAddVT
            // 
            btnAddVT.Dock = DockStyle.Right;
            btnAddVT.FlatAppearance.BorderSize = 0;
            btnAddVT.FlatStyle = FlatStyle.Flat;
            btnAddVT.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAddVT.IconColor = Color.White;
            btnAddVT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddVT.IconSize = 35;
            btnAddVT.Location = new Point(1097, 0);
            btnAddVT.Margin = new Padding(3, 3, 15, 3);
            btnAddVT.Name = "btnAddVT";
            btnAddVT.Size = new Size(45, 60);
            btnAddVT.TabIndex = 1;
            btnAddVT.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddVT.UseVisualStyleBackColor = true;
            btnAddVT.Click += btnAddVT_Click;
            // 
            // labelTenVT
            // 
            labelTenVT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTenVT.AutoSize = true;
            labelTenVT.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenVT.ForeColor = SystemColors.ControlLightLight;
            labelTenVT.Location = new Point(12, 14);
            labelTenVT.Name = "labelTenVT";
            labelTenVT.Size = new Size(114, 32);
            labelTenVT.TabIndex = 0;
            labelTenVT.Text = "Tên vị trí";
            labelTenVT.DoubleClick += labelTenVT_DoubleClick;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(btnDelTS);
            panelFooter.Controls.Add(btnInsertTS);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 678);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1142, 72);
            panelFooter.TabIndex = 2;
            // 
            // btnDelTS
            // 
            btnDelTS.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDelTS.IconColor = Color.Black;
            btnDelTS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelTS.Location = new Point(273, 8);
            btnDelTS.Name = "btnDelTS";
            btnDelTS.Size = new Size(232, 61);
            btnDelTS.TabIndex = 1;
            btnDelTS.Text = "Xóa thông số";
            btnDelTS.UseVisualStyleBackColor = true;
            btnDelTS.Visible = false;
            btnDelTS.Click += btnDelTS_Click;
            // 
            // btnInsertTS
            // 
            btnInsertTS.IconChar = FontAwesome.Sharp.IconChar.None;
            btnInsertTS.IconColor = Color.Black;
            btnInsertTS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInsertTS.Location = new Point(35, 8);
            btnInsertTS.Name = "btnInsertTS";
            btnInsertTS.Size = new Size(232, 61);
            btnInsertTS.TabIndex = 0;
            btnInsertTS.Text = "Thêm thông số";
            btnInsertTS.UseVisualStyleBackColor = true;
            btnInsertTS.Visible = false;
            btnInsertTS.Click += btnInsertTS_Click;
            // 
            // fThongSoMoiTruong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 237, 204);
            ClientSize = new Size(1142, 750);
            Controls.Add(tabctrlTSMT);
            Controls.Add(panelFooter);
            Controls.Add(panelTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fThongSoMoiTruong";
            Text = "fThongSoMoiTruong";
            FormClosing += fThongSoMoiTruong_FormClosing;
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);


        }

        #endregion
        private TabControl tabctrlTSMT;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Panel panelTitle;
        private Label labelTenVT;
        private FontAwesome.Sharp.IconButton btnDelVT;
        private FontAwesome.Sharp.IconButton btnAddVT;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnEdit;
        private Panel panelFooter;
        private FontAwesome.Sharp.IconButton btnDelTS;
        private FontAwesome.Sharp.IconButton btnInsertTS;

    }
}