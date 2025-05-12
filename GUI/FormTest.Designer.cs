using System.Windows.Forms.DataVisualization.Charting;

namespace baocao.GUI
{
    partial class FormTest
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
        //Updated by DevUI 19:39 02/04/2025

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
            dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            TenCT = new DataGridViewTextBoxColumn();
            MaHD = new DataGridViewTextBoxColumn();
            MaDH = new DataGridViewTextBoxColumn();
            NgayLM = new DataGridViewTextBoxColumn();
            NgayKQ = new DataGridViewTextBoxColumn();
            Quy = new DataGridViewTextBoxColumn();
            Trangthai = new DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
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
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDonHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDonHang.EnableHeadersVisualStyles = false;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 93, 114);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(4, 93, 114);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDonHang.ColumnHeadersHeight = 36;
            dgvDonHang.Columns.AddRange(new DataGridViewColumn[] { MaDH, NgayLM, NgayKQ, Quy, Trangthai, TenCT });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 10, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Chocolate;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDonHang.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDonHang.Dock = DockStyle.Fill;
            dgvDonHang.GridColor = Color.White;
            dgvDonHang.Location = new Point(10, 112);
            dgvDonHang.Margin = new Padding(10, 5, 10, 5);
            dgvDonHang.MultiSelect = false;
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDonHang.RowHeadersVisible = false;
            dgvDonHang.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvDonHang.RowTemplate.Height = 25;
            dgvDonHang.ShowEditingIcon = false;
            dgvDonHang.Size = new Size(1347, 505);
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
            dgvDonHang.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 237, 204);
            dgvDonHang.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // TenCT
            // 
            TenCT.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TenCT.Frozen = false;
            TenCT.HeaderText = "Tên công ty";
            TenCT.MinimumWidth = 8;
            TenCT.Name = "TenCT";
            TenCT.ReadOnly = true;
            TenCT.Width = 300;
            // 
            // MaHD
            // 
            MaHD.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            MaHD.Frozen = false;
            MaHD.HeaderText = "Mã hợp đồng";
            MaHD.MinimumWidth = 8;
            MaHD.Name = "MaHD";
            MaHD.ReadOnly = true;
            MaHD.Width = 173;
            // 
            // MaDH
            // 
            MaDH.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            MaDH.Frozen = false;
            MaDH.HeaderText = "Mã đơn hàng";
            MaDH.MinimumWidth = 8;
            MaDH.Name = "MaDH";
            MaDH.ReadOnly = true;
            MaDH.Width = 176;
            // 
            // NgayLM
            // 
            NgayLM.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NgayLM.Frozen = false;
            NgayLM.HeaderText = "Ngày bắt đầu lấy mẫu";
            NgayLM.MinimumWidth = 8;
            NgayLM.Name = "NgayLM";
            NgayLM.ReadOnly = true;
            NgayLM.Width = 213;
            // 
            // NgayKQ
            // 
            NgayKQ.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NgayKQ.Frozen = false;
            NgayKQ.HeaderText = "Ngày trả kết quả dự kiến";
            NgayKQ.MinimumWidth = 8;
            NgayKQ.Name = "NgayKQ";
            NgayKQ.ReadOnly = true;
            NgayKQ.Width = 242;
            // 
            // Quy
            // 
            Quy.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Quy.Frozen = false;
            Quy.HeaderText = "Quý";
            Quy.MinimumWidth = 8;
            Quy.Name = "Quy";
            Quy.ReadOnly = true;
            Quy.Width = 192;
            // 
            // Trangthai
            // 
            Trangthai.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Trangthai.Frozen = false;
            Trangthai.HeaderText = "Trạng thái";
            Trangthai.MinimumWidth = 8;
            Trangthai.Name = "Trangthai";
            Trangthai.ReadOnly = true;
            Trangthai.Width = 132;
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
            // 
            // fDonHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1367, 700);
            Controls.Add(dgvDonHang);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fDonHang";
            Padding = new Padding(14, 0, 14, 0);
            Text = "fDonHang";
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private DataGridViewTextBoxColumn TenCT;
        private DataGridViewTextBoxColumn MaHD;
        private DataGridViewTextBoxColumn MaDH;
        private DataGridViewTextBoxColumn NgayLM;
        private DataGridViewTextBoxColumn NgayKQ;
        private DataGridViewTextBoxColumn Quy;
        private DataGridViewTextBoxColumn Trangthai;
        private Panel panelHeader;
        private TextBox txtSearch;
        private Label labelPage;
        private FontAwesome.Sharp.IconButton btnMic;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}
////
//// chartQuy
////
//chartQuy = new Chart();
//chartQuy.Dock = DockStyle.Fill;
//panelBody.Controls.Add(chartQuy);
//chartQuy.BackColor = this.BackColor;
//chartQuy.Titles.Add("Biểu đồ trạng thái đơn hàng theo quý");
//chartQuy.Titles[0].Font = new Font("Segoe UI", 16, FontStyle.Bold);
//chartQuy.Titles[0].Alignment = ContentAlignment.MiddleCenter;
//chartQuy.Titles[0].IsDockedInsideChartArea = true;
//chartQuy.MouseClick += ChartQuy_MouseClick;