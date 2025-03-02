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
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace baocao
{
    public partial class fDSHD : Form
    {
        private List<Dshd> fullData = new List<Dshd>();
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPages = 0;
        public fDSHD()
        {
            InitializeComponent();
            loadData();
        }
        #region Methods
        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim();
            List<Dshd> data = DshdDAO.Instance.searchDshd(keyword);
            if (data == null || data.Count == 0)
            {
                data = new List<Dshd>();
            }
            dgvDshd.DataSource = new BindingList<Dshd>(data);
            totalPages = Math.Max(1, (int)Math.Ceiling((double)data.Count / pageSize));
            currentPage = 1;
            LoadPage(currentPage, data);
        }
        private void loadData()
        {
            dgvDshd.Columns.Clear();
            fullData = DshdDAO.Instance.loadData();
            if (fullData == null || fullData.Count == 0)
            {
                fullData = new List<Dshd>();
            }
            totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
            LoadPage(1, fullData);
        }
        private void LoadPage(int page, List<Dshd> data = null)
        {
            if (data != null)
            {
                fullData = data;
                totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize); 
                currentPage = 1; 
            }
            if (fullData == null || fullData.Count == 0)
            {
                dgvDshd.DataSource = null;
                totalPages = 1;
                currentPage = 1;
                labelPage.Text = "Trang 0/0";
                btnFirstPage.Visible = btnPrevPage.Visible = false;
                btnNextPage.Visible = btnLastPage.Visible = false;
                return;
            }
            totalPages = Math.Max(1, (int)Math.Ceiling((double)fullData.Count / pageSize)); 
            currentPage = Math.Max(1, Math.Min(page, totalPages));
            int start = (currentPage - 1) * pageSize;
            var pageData = fullData.Skip(start).Take(pageSize).ToList();
            dgvDshd.DataSource = new BindingList<Dshd>(pageData);
            dgvDshd.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            dgvDshd.Columns["MaCT"].HeaderText = "Mã công ty";
            dgvDshd.Columns["TenCT"].HeaderText = "Tên công ty";
            dgvDshd.Columns["KyHieuCT"].HeaderText = "Ký hiệu công ty";
            dgvDshd.Columns["NgayHD"].HeaderText = "Ngày ký hợp đồng";
            dgvDshd.Columns["TenDaiDien"].HeaderText = "Tên người đại diện";
            dgvDshd.Columns["Sdt"].HeaderText = "Số điện thoại";
            dgvDshd.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDshd.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            labelPage.Text = $"Trang {currentPage}/{totalPages}";
            btnFirstPage.Visible = btnPrevPage.Visible = (currentPage > 1);
            btnNextPage.Visible = btnLastPage.Visible = (currentPage < totalPages);
        }
        #endregion
        #region Events
        private void fDSHD_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            fDSHDEdit form = new fDSHDEdit(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDshd.SelectedRows.Count > 0)
            {
                int index = dgvDshd.SelectedRows[0].Index;
                Dshd selected = (Dshd)dgvDshd.Rows[index].DataBoundItem;
                fDSHDEdit form = new fDSHDEdit(selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvDshd.SelectedRows.Count > 0)
            {
                int index = dgvDshd.SelectedRows[0].Index;
                Dshd selected = (Dshd)dgvDshd.Rows[index].DataBoundItem;
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DshdDAO.Instance.deleteDshd(selected.MaHD))
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
        private void dgvDshd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDel.Visible = true;
                btnEdit.Visible = true;
            }
            else
            {
                btnDel.Visible = false;
                btnEdit.Visible = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
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
            LoadPage(1);
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPage(currentPage);
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage(currentPage);
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
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
