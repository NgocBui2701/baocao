using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DAO;
using baocao.DTO;

namespace baocao
{
    public partial class fDonHang : Form
    {
        private List<DonHang> fullData = new List<DonHang>();
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPages = 0;
        bool isDarkMode = Properties.Settings.Default.DarkMode;
        public fDonHang()
        {
            InitializeComponent();
            loadData();
        }
        #region Methods
        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                loadData();
                return;
            }
            List<DonHang> data = DonHangDAO.Instance.searchDonHang(keyword);
            if (data == null || data.Count == 0)
            {
                data = new List<DonHang>();
            }
            dgvDonHang.DataSource = new BindingList<DonHang>(data);
            totalPages = Math.Max(1, (int)Math.Ceiling((double)data.Count / pageSize));
            currentPage = 1;
            LoadPage(currentPage, data);
        }
        private void loadData()
        {
            dgvDonHang.Columns.Clear();
            fullData = DonHangDAO.Instance.loadData();
            if (fullData == null || fullData.Count == 0)
            {
                fullData = new List<DonHang>();
            }
            totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
            LoadPage(1, fullData);
        }
        private void LoadPage(int page, List<DonHang> data = null)
        {
            ClearManualColumns();
            if (data != null)
            {
                fullData = data;
                totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
                currentPage = 1;
            }
            if (fullData == null || fullData.Count == 0)
            {
                dgvDonHang.DataSource = null;
                totalPages = 1;
                currentPage = 1;
                labelPage.Text = "Trang 0/0";
                btnFirstPage.Visible = btnPrevPage.Visible = false;
                btnNextPage.Visible = btnLastPage.Visible = false;
                SetColumnHeaders();
                return;
            }
            totalPages = Math.Max(1, (int)Math.Ceiling((double)fullData.Count / pageSize));
            currentPage = Math.Max(1, Math.Min(page, totalPages));
            int start = (currentPage - 1) * pageSize;
            var pageData = fullData.Skip(start).Take(pageSize).ToList();
            dgvDonHang.DataSource = new BindingList<DonHang>(pageData);
            dgvDonHang.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            dgvDonHang.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            dgvDonHang.Columns["NgayLM"].HeaderText = "Ngày bắt đầu lấy mẫu";
            dgvDonHang.Columns["NgayKQ"].HeaderText = "Ngày trả kết quả dự kiến";
            dgvDonHang.Columns["Quy"].HeaderText = "Quý";
            dgvDonHang.Columns["Trangthai"].HeaderText = "Trạng thái";
            dgvDonHang.Columns["NgayLM"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDonHang.Columns["NgayKQ"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDonHang.Columns["Trangthai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (!dgvDonHang.Columns.Contains("Thông số môi trường"))
            {
                DataGridViewButtonColumn tsmtColumn = new DataGridViewButtonColumn();
                tsmtColumn.Name = "Thông số môi trường";
                tsmtColumn.HeaderText = "Thông số môi trường";
                tsmtColumn.Text = "TSMT";
                tsmtColumn.UseColumnTextForButtonValue = true;
                dgvDonHang.Columns.Add(tsmtColumn);
            }
            labelPage.Text = $"Trang {currentPage}/{totalPages}";
            btnFirstPage.Visible = btnPrevPage.Visible = (currentPage > 1);
            btnNextPage.Visible = btnLastPage.Visible = (currentPage < totalPages);
            AdjustGuna2DataGridViewHeight();
            dgvDonHang.ClearSelection();
        }
        private void SetColumnHeaders()
        {
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MaHD", HeaderText = "Mã hợp đồng" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MaDH", HeaderText = "Mã đơn hàng" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayLM", HeaderText = "Ngày bắt đầu lấy mẫu" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayKQ", HeaderText = "Ngày trả kết quả dự kiến" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Quy", HeaderText = "Quý" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Trangthai", HeaderText = "Trạng thái" });
            dgvDonHang.Columns["Trangthai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ClearManualColumns()
        {
            for (int i = dgvDonHang.Columns.Count - 1; i >= 0; i--)
            {
                if (!dgvDonHang.Columns[i].IsDataBound)
                {
                    dgvDonHang.Columns.RemoveAt(i);
                }
            }
        }
        private void AdjustGuna2DataGridViewHeight()
        {
            int rowCount = dgvDonHang.Rows.Count;
            int rowHeight = dgvDonHang.RowTemplate.Height;
            int headerHeight = dgvDonHang.ColumnHeadersHeight;
            int newHeight = headerHeight + (rowHeight * rowCount) + 10;
            int minHeight = 100;
            int maxHeight = 400;
            dgvDonHang.Height = Math.Min(Math.Max(newHeight, minHeight), maxHeight);
        }
        #endregion
        #region Events
        private void fDonHang_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDel.Visible = false;
            loadData();
            dgvDonHang.BackgroundColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            dgvDonHang.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            dgvDonHang.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDonHang.ClearSelection();
        }
        private void fDonHang_Click(object sender, EventArgs e)
        {
            dgvDonHang.ClearSelection();
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            fDonHangEdit form = new fDonHangEdit(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                int index = dgvDonHang.SelectedRows[0].Index;
                DonHang selected = (DonHang)dgvDonHang.Rows[index].DataBoundItem;
                fDonHangEdit form = new fDonHangEdit(selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                int index = dgvDonHang.SelectedRows[0].Index;
                DonHang selected = (DonHang)dgvDonHang.Rows[index].DataBoundItem;
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DonHangDAO.Instance.deleteDonHang(selected.MaDH))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = dgvDonHang.SelectedRows.Count > 0;
            btnDel.Visible = dgvDonHang.SelectedRows.Count > 0;
        }
        private void dgvDonHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvDonHang.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            dgvDonHang.Rows[e.RowIndex].DefaultCellStyle.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            dgvDonHang.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            PerformSearch();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            LoadPage(1);
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            currentPage--;
            LoadPage(currentPage);
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            currentPage++;
            LoadPage(currentPage);
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            fDonHang_Click(sender, e);
            LoadPage(totalPages);
        }
        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPage.Text, out int page) || page <= 0)
            {
                currentPage = 1;
            }
            if (page != currentPage)
            {
                currentPage = page;
                LoadPage(currentPage);
            }
        }
        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPage_TextChanged(sender, e);
            }
        }
        #endregion
    }
}
