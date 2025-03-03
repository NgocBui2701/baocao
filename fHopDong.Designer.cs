namespace baocao
{
    partial class fHopDong
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnInsert = new Button();
            btnEdit = new Button();
            txtPage = new TextBox();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            btnFirstPage = new Button();
            panel2 = new Panel();
            labelPage = new Label();
            btnLastPage = new Button();
            dgvHopDong = new Guna.UI2.WinForms.Guna2DataGridView();
            MaCT = new DataGridViewTextBoxColumn();
            TenCT = new DataGridViewTextBoxColumn();
            KyHieuCT = new DataGridViewTextBoxColumn();
            NgayHD = new DataGridViewTextBoxColumn();
            TenDaiDien = new DataGridViewTextBoxColumn();
            Sdt = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            btnDel = new Button();
            panel1 = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(6, 32);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(60, 23);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Thêm";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Location = new Point(149, 32);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(66, 23);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtPage
            // 
            txtPage.Anchor = AnchorStyles.None;
            txtPage.Location = new Point(694, 12);
            txtPage.Name = "txtPage";
            txtPage.PlaceholderText = "...";
            txtPage.Size = new Size(40, 23);
            txtPage.TabIndex = 19;
            txtPage.TextAlign = HorizontalAlignment.Center;
            txtPage.TextChanged += txtPage_TextChanged;
            txtPage.KeyDown += txtPage_KeyDown;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.None;
            btnPrevPage.Location = new Point(649, 12);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(38, 23);
            btnPrevPage.TabIndex = 18;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.Location = new Point(740, 12);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(38, 23);
            btnNextPage.TabIndex = 17;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.None;
            btnFirstPage.Location = new Point(572, 12);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(71, 23);
            btnFirstPage.TabIndex = 16;
            btnFirstPage.Text = "Trang đầu";
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelPage);
            panel2.Controls.Add(btnLastPage);
            panel2.Controls.Add(txtPage);
            panel2.Controls.Add(btnFirstPage);
            panel2.Controls.Add(btnPrevPage);
            panel2.Controls.Add(btnNextPage);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 370);
            panel2.Name = "panel2";
            panel2.Size = new Size(957, 50);
            panel2.TabIndex = 20;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Location = new Point(436, 15);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(36, 15);
            labelPage.TabIndex = 21;
            labelPage.Text = "Trang";
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.None;
            btnLastPage.Location = new Point(784, 12);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(75, 23);
            btnLastPage.TabIndex = 20;
            btnLastPage.Text = "Trang cuối";
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // dgvHopDong
            // 
            dgvHopDong.AllowUserToAddRows = false;
            dgvHopDong.AllowUserToDeleteRows = false;
            dgvHopDong.AllowUserToResizeColumns = false;
            dgvHopDong.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvHopDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHopDong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(0, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHopDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHopDong.ColumnHeadersHeight = 36;
            dgvHopDong.Columns.AddRange(new DataGridViewColumn[] { MaCT, TenCT, KyHieuCT, NgayHD, TenDaiDien, Sdt, DiaChi });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHopDong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHopDong.Dock = DockStyle.Fill;
            dgvHopDong.GridColor = Color.FromArgb(231, 229, 255);
            dgvHopDong.Location = new Point(0, 67);
            dgvHopDong.MultiSelect = false;
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.ReadOnly = true;
            dgvHopDong.RowHeadersVisible = false;
            dgvHopDong.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvHopDong.Size = new Size(957, 303);
            dgvHopDong.TabIndex = 22;
            dgvHopDong.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvHopDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvHopDong.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvHopDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvHopDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvHopDong.ThemeStyle.BackColor = Color.White;
            dgvHopDong.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvHopDong.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvHopDong.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHopDong.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvHopDong.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvHopDong.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHopDong.ThemeStyle.HeaderStyle.Height = 36;
            dgvHopDong.ThemeStyle.ReadOnly = true;
            dgvHopDong.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvHopDong.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHopDong.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvHopDong.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvHopDong.ThemeStyle.RowsStyle.Height = 25;
            dgvHopDong.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvHopDong.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvHopDong.CellClick += dgvHopDong_CellClick;
            // 
            // MaCT
            // 
            MaCT.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            MaCT.Frozen = true;
            MaCT.HeaderText = "Mã công ty";
            MaCT.Name = "MaCT";
            MaCT.ReadOnly = true;
            MaCT.Width = 86;
            // 
            // TenCT
            // 
            TenCT.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            TenCT.Frozen = true;
            TenCT.HeaderText = "Tên công ty";
            TenCT.Name = "TenCT";
            TenCT.ReadOnly = true;
            TenCT.Width = 89;
            // 
            // KyHieuCT
            // 
            KyHieuCT.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            KyHieuCT.Frozen = true;
            KyHieuCT.HeaderText = "Ký hiệu công ty";
            KyHieuCT.Name = "KyHieuCT";
            KyHieuCT.ReadOnly = true;
            KyHieuCT.Width = 110;
            // 
            // NgayHD
            // 
            NgayHD.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NgayHD.Frozen = true;
            NgayHD.HeaderText = "Ngày ký hợp đồng";
            NgayHD.Name = "NgayHD";
            NgayHD.ReadOnly = true;
            NgayHD.Width = 109;
            // 
            // TenDaiDien
            // 
            TenDaiDien.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            TenDaiDien.Frozen = true;
            TenDaiDien.HeaderText = "Tên người đại diện";
            TenDaiDien.Name = "TenDaiDien";
            TenDaiDien.ReadOnly = true;
            TenDaiDien.Width = 116;
            // 
            // Sdt
            // 
            Sdt.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Sdt.Frozen = true;
            Sdt.HeaderText = "Số điện thoại";
            Sdt.Name = "Sdt";
            Sdt.ReadOnly = true;
            Sdt.Width = 109;
            // 
            // DiaChi
            // 
            DiaChi.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DiaChi.Frozen = true;
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.Name = "DiaChi";
            DiaChi.ReadOnly = true;
            DiaChi.Width = 57;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDel.Location = new Point(77, 32);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(66, 23);
            btnDel.TabIndex = 23;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnInsert);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(957, 67);
            panel1.TabIndex = 25;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(803, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 26;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(634, 24);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm";
            txtSearch.Size = new Size(163, 23);
            txtSearch.TabIndex = 25;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // fHopDong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(957, 420);
            Controls.Add(dgvHopDong);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fHopDong";
            Text = "CM";
            Load += fHopDong_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnLastPage;
        private Button btnInsert;
        private Button btnEdit;
        private TextBox txtPage;
        private Button btnPrevPage;
        private Button btnNextPage;
        private Button btnFirstPage;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHopDong;
        private Button btnDel;
        private DataGridViewTextBoxColumn MaCT;
        private DataGridViewTextBoxColumn TenCT;
        private DataGridViewTextBoxColumn KyHieuCT;
        private DataGridViewTextBoxColumn NgayHD;
        private DataGridViewTextBoxColumn TenDaiDien;
        private DataGridViewTextBoxColumn Sdt;
        private DataGridViewTextBoxColumn DiaChi;
        private Panel panel1;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label labelPage;
    }
}