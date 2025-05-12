using System.ComponentModel;
using baocao.GUI.Managers;

namespace baocao.GUI.BaseForm
{
    public class PagedForm<T> : DarkModeForm where T : class
    {
        private LanguageManager langManager = LanguageManager.Instance;
        protected DataGridView dgvMain;
        protected TextBox txtSearch;
        protected Label labelPage;
        protected Button btnFirstPage, btnPrevPage, btnNextPage, btnLastPage;
        protected Button btnInsert, btnEdit, btnDel;
        protected TextBox txtPage;
        protected List<T> fullData = new List<T>();
        protected int pageSize = 40;
        private int currentPage = 1;
        protected int totalPages = 0;
        protected virtual string id { get; }
        protected PagedForm()
        {
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()
        {
            if (labelPage != null)
            {
                labelPage.Text = $"{langManager.Translate("page")} {currentPage}/{totalPages}";
            }
        }

        protected void InitializePagedForm(DataGridView dataGridView, TextBox searchBox, Label pageLabel,
            Button firstPageButton, Button prevPageButton, Button nextPageButton, Button lastPageButton, TextBox pageTextBox,
            Button insertButton, Button editButton, Button delButton) 
        {
            dgvMain = dataGridView;
            txtSearch = searchBox;
            labelPage = pageLabel;
            btnFirstPage = firstPageButton;
            btnPrevPage = prevPageButton;
            btnNextPage = nextPageButton;
            btnLastPage = lastPageButton;
            btnInsert = insertButton;
            btnEdit = editButton;
            btnDel = delButton;
            txtPage = pageTextBox;

            dgvMain.CellClick += dgvMain_CellClick;
        }
        protected virtual List<T> LoadFullData() { return new List<T>(); }
        protected virtual List<T> SearchData(string keyword) { return new List<T>(); }
        protected virtual void ConfigureDataGridViewColumns() { }
        protected virtual void SetColumnHeaders() { }
        protected virtual void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e) { }
        protected virtual bool DeleteItem(string id) { return false; }
        protected virtual Form CreateEditForm(T item) { return null; }

        protected virtual void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }
            fullData = SearchData(keyword) ?? new List<T>();
            totalPages = Math.Max(1, (int)Math.Ceiling((double)fullData.Count / pageSize));
            currentPage = 1;
            LoadPage(currentPage);
        }

        public virtual void LoadData()
        {
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            dgvMain.Columns.Clear();
            fullData = LoadFullData() ?? new List<T>();
            totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
            LoadPage(1);
        }

        protected void RefreshData()
        {
            txtSearch.Text = string.Empty;
            currentPage = 1;
            LoadData();
        }

        protected virtual void LoadPage(int page)
        {
            ClearManualColumns();
            if (fullData == null || fullData.Count == 0)
            {
                dgvMain.DataSource = null;
                totalPages = 1;
                currentPage = 1;
                labelPage.Text = "Trang 0/0";
                btnFirstPage.Visible = btnPrevPage.Visible = btnNextPage.Visible = btnLastPage.Visible = txtPage.Visible = false;
                ConfigureDataGridViewColumns();
                SetColumnHeaders();
                return;
            }
            totalPages = Math.Max(1, (int)Math.Ceiling((double)fullData.Count / pageSize));
            currentPage = Math.Max(1, Math.Min(page, totalPages));
            int start = (currentPage - 1) * pageSize;
            var pageData = fullData.Skip(start).Take(pageSize).ToList();
            dgvMain.DataSource = new BindingList<T>(pageData);
            ConfigureDataGridViewColumns();

            labelPage.Text = $"{langManager.Translate("page")} {currentPage}/{totalPages}";
            txtPage.Visible = totalPages > 1;
            txtPage.Text = currentPage.ToString();
            btnFirstPage.Visible = btnPrevPage.Visible = (currentPage > 1);
            btnNextPage.Visible = btnLastPage.Visible = (currentPage < totalPages);
            dgvMain.ClearSelection();
        }

        private void ClearManualColumns()
        {
            for (int i = dgvMain.Columns.Count - 1; i >= 0; i--)
            {
                if (!dgvMain.Columns[i].IsDataBound)
                {
                    dgvMain.Columns.RemoveAt(i);
                }
            }
        }

        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            if (dgvMain != null)
            {
                dgvMain.ColumnHeadersDefaultCellStyle.BackColor = DarkModeManager.GetDark();
                dgvMain.ColumnHeadersDefaultCellStyle.SelectionBackColor = DarkModeManager.GetDark();   
                dgvMain.ForeColor = Color.White;
                dgvMain.DefaultCellStyle.BackColor = Color.White;
                dgvMain.DefaultCellStyle.ForeColor = Color.Black;
                dgvMain.DefaultCellStyle.SelectionBackColor = DarkModeManager.GetLight();
                dgvMain.DefaultCellStyle.SelectionForeColor = DarkModeManager.GetDark();
                dgvMain.AlternatingRowsDefaultCellStyle.BackColor = dgvMain.DefaultCellStyle.BackColor;
            }
            if (txtSearch != null)
            {
                txtSearch.BackColor = DarkModeManager.GetLight();
                txtSearch.ForeColor = DarkModeManager.GetDark();
            }
        }

        #region Common Event Handlers
        protected void OnForm_Click(object sender, EventArgs e)
        {
            dgvMain.ClearSelection();
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            Form editForm = CreateEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                int index = dgvMain.SelectedRows[0].Index;
                T selected = (T)dgvMain.Rows[index].DataBoundItem;
                Form editForm = CreateEditForm(selected);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                int index = dgvMain.SelectedRows[0].Index;
                T selected = (T)dgvMain.Rows[index].DataBoundItem;
                string Id = selected.GetType().GetProperty(id).GetValue(selected).ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteItem(Id))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            RefreshData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            PerformSearch();
        }

        protected void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            LoadPage(1);
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            currentPage--;
            LoadPage(currentPage);
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            currentPage++;
            LoadPage(currentPage);
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            LoadPage(totalPages);
        }

        protected void txtPage_TextChanged(object sender, EventArgs e)
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

        protected void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPage_TextChanged(sender, e);
            }
        }
        #endregion
    }
}