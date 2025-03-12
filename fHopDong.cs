using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DAO;
using baocao.DTO;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace baocao
{
    public partial class fHopDong : Form
    {
        private List<HopDong> fullData = new List<HopDong>();
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPages = 0;
        bool isDarkMode = Properties.Settings.Default.DarkMode;
        public fHopDong()
        {
            InitializeComponent();
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
            List<HopDong> data = HopDongDAO.Instance.searchHopDong(keyword);
            if (data == null || data.Count == 0)
            {
                data = new List<HopDong>();
            }
            dgvHopDong.DataSource = new BindingList<HopDong>(data);
            totalPages = Math.Max(1, (int)Math.Ceiling((double)data.Count / pageSize));
            currentPage = 1;
            LoadPage(currentPage, data);
        }
        private void loadData()
        {
            dgvHopDong.Columns.Clear();
            fullData = HopDongDAO.Instance.loadData();
            if (fullData == null || fullData.Count == 0)
            {
                fullData = new List<HopDong>();
            }
            totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
            LoadPage(1, fullData);
        }
        private void LoadPage(int page, List<HopDong> data = null)
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
                dgvHopDong.DataSource = null;
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
            dgvHopDong.DataSource = new BindingList<HopDong>(pageData);
            dgvHopDong.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            dgvHopDong.Columns["MaCT"].HeaderText = "Mã công ty";
            dgvHopDong.Columns["TenCT"].HeaderText = "Tên công ty";
            dgvHopDong.Columns["KyHieuCT"].HeaderText = "Ký hiệu công ty";
            dgvHopDong.Columns["NgayHD"].HeaderText = "Ngày ký hợp đồng";
            dgvHopDong.Columns["TenDaiDien"].HeaderText = "Tên người đại diện";
            dgvHopDong.Columns["Sdt"].HeaderText = "Số điện thoại";
            dgvHopDong.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvHopDong.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            labelPage.Text = $"Trang {currentPage}/{totalPages}";
            btnFirstPage.Visible = btnPrevPage.Visible = (currentPage > 1);
            btnNextPage.Visible = btnLastPage.Visible = (currentPage < totalPages);
            AdjustGuna2DataGridViewHeight();
            dgvHopDong.ClearSelection();
        }
        private void SetColumnHeaders()
        {
            dgvHopDong.Columns.Add("MaHD", "Mã hợp đồng");
            dgvHopDong.Columns.Add("MaCT", "Mã công ty");
            dgvHopDong.Columns.Add("TenCT", "Tên công ty");
            dgvHopDong.Columns.Add("KyHieuCT", "Ký hiệu công ty");
            dgvHopDong.Columns.Add("NgayHD", "Ngày ký hợp đồng");
            dgvHopDong.Columns.Add("TenDaiDien", "Tên người đại diện");
            dgvHopDong.Columns.Add("Sdt", "Số điện thoại");
            dgvHopDong.Columns.Add("DiaChi", "Địa chỉ");
            dgvHopDong.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ClearManualColumns()
        {
            for (int i = dgvHopDong.Columns.Count - 1; i >= 0; i--)
            {
                if (!dgvHopDong.Columns[i].IsDataBound)
                {
                    dgvHopDong.Columns.RemoveAt(i);
                }
            }
        }
        private void AdjustGuna2DataGridViewHeight()
        {
            int rowCount = dgvHopDong.Rows.Count; 
            int rowHeight = dgvHopDong.RowTemplate.Height;
            int headerHeight = dgvHopDong.ColumnHeadersHeight;
            int newHeight = headerHeight + (rowHeight * rowCount) + 10; 
            int minHeight = 100; 
            int maxHeight = 400;  
            dgvHopDong.Height = Math.Min(Math.Max(newHeight, minHeight), maxHeight);
        }
        #endregion
        #region Events
        private void fHopDong_Load(object sender, EventArgs e)
        {
            btnDel.Visible = false;
            btnEdit.Visible = false;
            loadData();
            dgvHopDong.BackgroundColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            dgvHopDong.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            dgvHopDong.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvHopDong.ClearSelection();
        }
        private void fHopDong_Click(object sender, EventArgs e)
        {
            dgvHopDong.ClearSelection();
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
            fHopDongEdit form = new fHopDongEdit(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                int index = dgvHopDong.SelectedRows[0].Index;
                HopDong selected = (HopDong)dgvHopDong.Rows[index].DataBoundItem;
                fHopDongEdit form = new fHopDongEdit(selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                int index = dgvHopDong.SelectedRows[0].Index;
                HopDong selected = (HopDong)dgvHopDong.Rows[index].DataBoundItem;
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (HopDongDAO.Instance.deleteHopDong(selected.MaHD))
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
        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = dgvHopDong.SelectedRows.Count > 0;
            btnDel.Visible = dgvHopDong.SelectedRows.Count > 0;
        }
        private void dgvHopDong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvHopDong.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            dgvHopDong.Rows[e.RowIndex].DefaultCellStyle.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
            dgvHopDong.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
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
            fHopDong_Click(sender, e);
            PerformSearch();
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
            LoadPage(1);
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
            currentPage--;
            LoadPage(currentPage);
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
            currentPage++;
            LoadPage(currentPage);
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            fHopDong_Click(sender, e);
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
        //public void UpdateText(string text)
        //{
        //    txtSearch.Text = text;
        //}
        //private void btnTranslate_Click(object sender, EventArgs e)
        //{
        //    fHopDong_Click(sender, e);
        //    fAITiengViet formVietnamese = new fAITiengViet(this);
        //    formVietnamese.Show();
        //}
        #endregion


    }
}
