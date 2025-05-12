using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace baocao.GUI
{
    partial class fQuanLyPhanQuyen
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
            txtPage = new TextBox();
            panelFooter = new Panel();
            labelPage = new Label();
            dgvQuanLyPhanQuyen = new Guna.UI2.WinForms.Guna2DataGridView();
            ma_nguoi_dung = new DataGridViewTextBoxColumn();
            ten = new DataGridViewTextBoxColumn();
            sdt = new DataGridViewTextBoxColumn();
            vai_tro = new DataGridViewTextBoxColumn();
            ten_dang_nhap = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            panelHeader = new Panel();
            btnMic = new FontAwesome.Sharp.IconButton();
            txtSearch = new TextBox();
            btnInsert = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnSearch = new FontAwesome.Sharp.IconButton();
            btnNextPage = new FontAwesome.Sharp.IconButton();
            btnPrevPage = new FontAwesome.Sharp.IconButton();
            btnLastPage = new FontAwesome.Sharp.IconButton();
            btnFirstPage = new FontAwesome.Sharp.IconButton();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuanLyPhanQuyen).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Transparent;
            btnInsert.FlatAppearance.BorderSize = 0;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnInsert.IconColor = Color.FromArgb(3, 82, 101);
            btnInsert.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInsert.IconSize = 35;
            btnInsert.Location = new Point(27, 45);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(45, 31);
            btnInsert.TabIndex = 31;
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnEdit.IconColor = Color.FromArgb(3, 82, 101);
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.IconSize = 35;
            btnEdit.Location = new Point(89, 45);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(45, 31);
            btnEdit.TabIndex = 29;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtPage
            // 
            txtPage.Anchor = AnchorStyles.None;
            txtPage.Location = new Point(659, 25);
            txtPage.Margin = new Padding(4, 5, 4, 5);
            txtPage.Name = "txtPage";
            txtPage.PlaceholderText = "...";
            txtPage.Size = new Size(55, 31);
            txtPage.TabIndex = 19;
            txtPage.TextAlign = HorizontalAlignment.Center;
            txtPage.Click += OnForm_Click;
            txtPage.TextChanged += txtPage_TextChanged;
            txtPage.KeyDown += txtPage_KeyDown;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.None;
            btnPrevPage.BackColor = Color.Transparent;
            btnPrevPage.FlatAppearance.BorderSize = 0;
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            btnPrevPage.IconColor = Color.FromArgb(3, 82, 101);
            btnPrevPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrevPage.IconSize = 35;
            btnPrevPage.Location = new Point(579, 25);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(45, 31);
            btnPrevPage.TabIndex = 33;
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += this.btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.BackColor = Color.Transparent;
            btnNextPage.FlatAppearance.BorderSize = 0;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            btnNextPage.IconColor = Color.FromArgb(3, 82, 101);
            btnNextPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNextPage.IconSize = 35;
            btnNextPage.Location = new Point(741, 25);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(45, 31);
            btnNextPage.TabIndex = 34;
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += this.btnNextPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.None;
            btnFirstPage.BackColor = Color.Transparent;
            btnFirstPage.FlatAppearance.BorderSize = 0;
            btnFirstPage.FlatStyle = FlatStyle.Flat;
            btnFirstPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            btnFirstPage.IconColor = Color.FromArgb(3, 82, 101);
            btnFirstPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFirstPage.IconSize = 35;
            btnFirstPage.Location = new Point(528, 27);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(45, 31);
            btnFirstPage.TabIndex = 35;
            btnFirstPage.UseVisualStyleBackColor = false;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(labelPage);
            panelFooter.Controls.Add(btnLastPage);
            panelFooter.Controls.Add(txtPage);
            panelFooter.Controls.Add(btnFirstPage);
            panelFooter.Controls.Add(btnPrevPage);
            panelFooter.Controls.Add(btnNextPage);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(14, 617);
            panelFooter.Margin = new Padding(4, 5, 4, 5);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1339, 83);
            panelFooter.TabIndex = 20;
            panelFooter.Click += OnForm_Click;
            // 
            // labelPage
            // 
            labelPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPage.AutoSize = true;
            labelPage.Location = new Point(27, 33);
            labelPage.Margin = new Padding(4, 0, 4, 0);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(55, 25);
            labelPage.TabIndex = 21;
            labelPage.Text = "Trang";
            labelPage.Click += OnForm_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.None;
            btnLastPage.BackColor = Color.Transparent;
            btnLastPage.FlatAppearance.BorderSize = 0;
            btnLastPage.FlatStyle = FlatStyle.Flat;
            btnLastPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            btnLastPage.IconColor = Color.FromArgb(3, 82, 101);
            btnLastPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLastPage.IconSize = 35;
            btnLastPage.Location = new Point(792, 25);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(45, 31);
            btnLastPage.TabIndex = 32;
            btnLastPage.UseVisualStyleBackColor = false;
            btnLastPage.Click += this.btnLastPage_Click;
            // 
            // dgvQuanLyPhanQuyen
            // 
            dgvQuanLyPhanQuyen.AccessibleRole = AccessibleRole.Table;
            dgvQuanLyPhanQuyen.AllowUserToAddRows = false;
            dgvQuanLyPhanQuyen.AllowUserToDeleteRows = false;
            dgvQuanLyPhanQuyen.AllowUserToResizeColumns = false;
            dgvQuanLyPhanQuyen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvQuanLyPhanQuyen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuanLyPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvQuanLyPhanQuyen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuanLyPhanQuyen.EnableHeadersVisualStyles = false;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 93, 114);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(4, 93, 114);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvQuanLyPhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvQuanLyPhanQuyen.ColumnHeadersHeight = 36;
            dgvQuanLyPhanQuyen.Columns.AddRange(new DataGridViewColumn[] { ma_nguoi_dung, ten, sdt, vai_tro, ten_dang_nhap, email });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 10, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Chocolate;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvQuanLyPhanQuyen.DefaultCellStyle = dataGridViewCellStyle3;
            dgvQuanLyPhanQuyen.Dock = DockStyle.Fill;
            dgvQuanLyPhanQuyen.GridColor = Color.White;
            dgvQuanLyPhanQuyen.Location = new Point(10, 112);
            dgvQuanLyPhanQuyen.Margin = new Padding(10, 5, 10, 5);
            dgvQuanLyPhanQuyen.MultiSelect = false;
            dgvQuanLyPhanQuyen.Name = "dgvQuanLyPhanQuyen";
            dgvQuanLyPhanQuyen.ReadOnly = true;
            dgvQuanLyPhanQuyen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuanLyPhanQuyen.RowHeadersVisible = false;
            dgvQuanLyPhanQuyen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuanLyPhanQuyen.RowTemplate.Height = 25;
            dgvQuanLyPhanQuyen.ShowEditingIcon = false;
            dgvQuanLyPhanQuyen.Size = new Size(1347, 505);
            dgvQuanLyPhanQuyen.TabIndex = 22;
            dgvQuanLyPhanQuyen.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvQuanLyPhanQuyen.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvQuanLyPhanQuyen.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvQuanLyPhanQuyen.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvQuanLyPhanQuyen.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvQuanLyPhanQuyen.ThemeStyle.BackColor = Color.White;
            dgvQuanLyPhanQuyen.ThemeStyle.GridColor = Color.White;
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvQuanLyPhanQuyen.ThemeStyle.HeaderStyle.Height = 36;
            dgvQuanLyPhanQuyen.ThemeStyle.ReadOnly = true;
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.Height = 25;
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 237, 204);
            dgvQuanLyPhanQuyen.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dgvQuanLyPhanQuyen.CellClick += dgvMain_CellClick;
            // 
            // ma_nguoi_dung
            // 
            ma_nguoi_dung.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ma_nguoi_dung.Frozen = false;
            ma_nguoi_dung.HeaderText = "Mã nhân viên";
            ma_nguoi_dung.MinimumWidth = 8;
            ma_nguoi_dung.Name = "ma_nguoi_dung";
            ma_nguoi_dung.ReadOnly = true;
            ma_nguoi_dung.Width = 173;
            // 
            // ten
            // 
            ten.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ten.Frozen = false;
            ten.HeaderText = "Họ tên";
            ten.MinimumWidth = 8;
            ten.Name = "ten";
            ten.ReadOnly = true;
            ten.Width = 176;
            // 
            // sdt
            // 
            sdt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            sdt.Frozen = false;
            sdt.HeaderText = "Số điện thoại";
            sdt.MinimumWidth = 8;
            sdt.Name = "sdt";
            sdt.ReadOnly = true;
            sdt.Width = 132;
            // 
            // vai_tro
            // 
            vai_tro.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            vai_tro.Frozen = false;
            vai_tro.HeaderText = "Vai trò";
            vai_tro.MinimumWidth = 8;
            vai_tro.Name = "vai_tro";
            vai_tro.ReadOnly = true;
            vai_tro.Width = 213;
            // 
            // ten_dang_nhap
            // 
            ten_dang_nhap.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ten_dang_nhap.Frozen = false;
            ten_dang_nhap.HeaderText = "Tên đăng nhập";
            ten_dang_nhap.MinimumWidth = 8;
            ten_dang_nhap.Name = "ten_dang_nhap";
            ten_dang_nhap.ReadOnly = true;
            ten_dang_nhap.Width = 242;
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            email.Frozen = false;
            email.HeaderText = "Email";
            email.MinimumWidth = 8;
            email.Name = "email";
            email.ReadOnly = true;
            email.Width = 192;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.Transparent;
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.FromArgb(3, 82, 101);
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.IconSize = 35;
            btnDel.Location = new Point(157, 45);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(45, 31);
            btnDel.TabIndex = 30;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnMic);
            panelHeader.Controls.Add(btnSearch);
            panelHeader.Controls.Add(btnDel);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.Controls.Add(btnEdit);
            panelHeader.Controls.Add(btnInsert);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(14, 0);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1339, 112);
            panelHeader.TabIndex = 25;
            panelHeader.Click += OnForm_Click;
            // 
            // btnMic
            // 
            btnMic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMic.FlatAppearance.BorderSize = 0;
            btnMic.FlatStyle = FlatStyle.Flat;
            btnMic.IconChar = FontAwesome.Sharp.IconChar.Microphone;
            btnMic.IconColor = Color.FromArgb(3, 82, 101);
            btnMic.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMic.IconSize = 35;
            btnMic.Location = new Point(1175, 36);
            btnMic.Margin = new Padding(4, 5, 4, 5);
            btnMic.Name = "btnMic";
            btnMic.Size = new Size(56, 38);
            btnMic.TabIndex = 27;
            btnMic.UseVisualStyleBackColor = true;
            btnMic.Click += OnForm_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.Transparent;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.FromArgb(3, 82, 101);
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 35;
            btnSearch.Location = new Point(1123, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(45, 31);
            btnSearch.TabIndex = 28;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(885, 40);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm";
            txtSearch.Size = new Size(231, 31);
            txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.TabIndex = 25;
            txtSearch.Click += OnForm_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.FromArgb(3, 82, 101);
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.IconSize = 35;
            btnRefresh.ImageAlign = ContentAlignment.MiddleCenter;
            btnRefresh.Location = new Point(828, 40);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 31);
            btnRefresh.TabIndex = 29;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // fQuanLyPhanQuyen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1367, 700);
            Controls.Add(dgvQuanLyPhanQuyen);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fQuanLyPhanQuyen";
            Padding = new Padding(14, 0, 14, 0);
            Text = "fQuanLyPhanQuyen";
            Load += fQuanLyPhanQuyen_Load;
            Click += OnForm_Click;
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuanLyPhanQuyen).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        private FontAwesome.Sharp.IconButton btnSearch;
        private FontAwesome.Sharp.IconButton btnInsert;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnFirstPage;
        private FontAwesome.Sharp.IconButton btnNextPage;
        private FontAwesome.Sharp.IconButton btnPrevPage;
        private FontAwesome.Sharp.IconButton btnLastPage;
        private TextBox txtPage;
        private Panel panelFooter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuanLyPhanQuyen;
        private DataGridViewTextBoxColumn ma_nguoi_dung;
        private DataGridViewTextBoxColumn ten;
        private DataGridViewTextBoxColumn sdt;
        private DataGridViewTextBoxColumn vai_tro;
        private DataGridViewTextBoxColumn ten_dang_nhap;
        private DataGridViewTextBoxColumn email;
        private Panel panelHeader;
        private TextBox txtSearch;
        private Label labelPage;
        private FontAwesome.Sharp.IconButton btnMic;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}