namespace baocao
{
    partial class fDonHang
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
            dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            MaHD = new DataGridViewTextBoxColumn();
            MaDH = new DataGridViewTextBoxColumn();
            NgayLM = new DataGridViewTextBoxColumn();
            NgayKQ = new DataGridViewTextBoxColumn();
            Quy = new DataGridViewTextBoxColumn();
            Trangthai = new DataGridViewTextBoxColumn();
            btnDel = new Button();
            panel1 = new Panel();
            btnMic = new FontAwesome.Sharp.IconButton();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(27, 32);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(60, 23);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Thêm";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(170, 32);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(66, 23);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtPage
            // 
            txtPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtPage.Location = new Point(758, 15);
            txtPage.Name = "txtPage";
            txtPage.PlaceholderText = "...";
            txtPage.Size = new Size(40, 23);
            txtPage.TabIndex = 19;
            txtPage.TextAlign = HorizontalAlignment.Center;
            txtPage.Click += fDonHang_Click;
            txtPage.TextChanged += txtPage_TextChanged;
            txtPage.KeyDown += txtPage_KeyDown;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrevPage.Location = new Point(713, 15);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(38, 23);
            btnPrevPage.TabIndex = 18;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNextPage.Location = new Point(804, 15);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(38, 23);
            btnNextPage.TabIndex = 17;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFirstPage.Location = new Point(636, 15);
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
            panel2.Click += fDonHang_Click;
            // 
            // labelPage
            // 
            labelPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPage.AutoSize = true;
            labelPage.Location = new Point(12, 26);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(36, 15);
            labelPage.TabIndex = 21;
            labelPage.Text = "Trang";
            labelPage.Click += fDonHang_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLastPage.Location = new Point(848, 15);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(75, 23);
            btnLastPage.TabIndex = 20;
            btnLastPage.Text = "Trang cuối";
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // dgvDonHang
            // 
            dgvDonHang.AccessibleRole = AccessibleRole.Table;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.AllowUserToResizeColumns = false;
            dgvDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDonHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDonHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DarkOrange;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDonHang.ColumnHeadersHeight = 36;
            dgvDonHang.Columns.AddRange(new DataGridViewColumn[] { MaHD, MaDH, NgayLM, NgayKQ, Quy, Trangthai });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 10, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Chocolate;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDonHang.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDonHang.GridColor = Color.White;
            dgvDonHang.Location = new Point(19, 67);
            dgvDonHang.Margin = new Padding(10, 3, 10, 3);
            dgvDonHang.MultiSelect = false;
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDonHang.RowHeadersVisible = false;
            dgvDonHang.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvDonHang.ShowEditingIcon = false;
            dgvDonHang.Size = new Size(919, 303);
            dgvDonHang.TabIndex = 22;
            dgvDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvDonHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvDonHang.ThemeStyle.BackColor = Color.White;
            dgvDonHang.ThemeStyle.GridColor = Color.White;
            dgvDonHang.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvDonHang.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDonHang.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvDonHang.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDonHang.ThemeStyle.HeaderStyle.Height = 36;
            dgvDonHang.ThemeStyle.ReadOnly = true;
            dgvDonHang.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvDonHang.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDonHang.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvDonHang.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvDonHang.ThemeStyle.RowsStyle.Height = 25;
            dgvDonHang.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvDonHang.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            dgvDonHang.CellFormatting += dgvDonHang_CellFormatting;
            // 
            // MaHD
            // 
            MaHD.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            MaHD.Frozen = true;
            MaHD.HeaderText = "Mã công ty";
            MaHD.Name = "MaHD";
            MaHD.ReadOnly = true;
            MaHD.Width = 101;
            // 
            // MaDH
            // 
            MaDH.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            MaDH.Frozen = true;
            MaDH.HeaderText = "Tên công ty";
            MaDH.Name = "MaDH";
            MaDH.ReadOnly = true;
            MaDH.Width = 104;
            // 
            // NgayLM
            // 
            NgayLM.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NgayLM.Frozen = true;
            NgayLM.HeaderText = "Ký hiệu công ty";
            NgayLM.Name = "NgayLM";
            NgayLM.ReadOnly = true;
            NgayLM.Width = 125;
            // 
            // NgayKQ
            // 
            NgayKQ.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NgayKQ.Frozen = true;
            NgayKQ.HeaderText = "Ngày ký hợp đồng";
            NgayKQ.Name = "NgayKQ";
            NgayKQ.ReadOnly = true;
            NgayKQ.Width = 124;
            // 
            // Quy
            // 
            Quy.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Quy.Frozen = true;
            Quy.HeaderText = "Số điện thoại";
            Quy.Name = "Quy";
            Quy.ReadOnly = true;
            Quy.Width = 124;
            // 
            // Trangthai
            // 
            Trangthai.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Trangthai.Frozen = true;
            Trangthai.HeaderText = "Địa chỉ";
            Trangthai.Name = "Trangthai";
            Trangthai.ReadOnly = true;
            Trangthai.Width = 72;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(98, 32);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(66, 23);
            btnDel.TabIndex = 23;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMic);
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
            panel1.Click += fDonHang_Click;
            // 
            // btnMic
            // 
            btnMic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMic.FlatAppearance.BorderSize = 0;
            btnMic.FlatStyle = FlatStyle.Flat;
            btnMic.IconChar = FontAwesome.Sharp.IconChar.Microphone;
            btnMic.IconColor = Color.DarkOrange;
            btnMic.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMic.IconSize = 20;
            btnMic.Location = new Point(884, 23);
            btnMic.Name = "btnMic";
            btnMic.Size = new Size(39, 23);
            btnMic.TabIndex = 27;
            btnMic.UseVisualStyleBackColor = true;
            btnMic.Click += fDonHang_Click;
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
            txtSearch.Click += fDonHang_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // fDonHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(957, 420);
            Controls.Add(dgvDonHang);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fDonHang";
            Text = "fDonHang";
            Load += fDonHang_Load;
            Click += fDonHang_Click;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Button btnDel;
        private DataGridViewTextBoxColumn MaHD;
        private DataGridViewTextBoxColumn MaDH;
        private DataGridViewTextBoxColumn NgayLM;
        private DataGridViewTextBoxColumn NgayKQ;
        private DataGridViewTextBoxColumn Quy;
        private DataGridViewTextBoxColumn Trangthai;
        private Panel panel1;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label labelPage;
        private FontAwesome.Sharp.IconButton btnMic;
    }
}