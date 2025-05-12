using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fCongTy : PagedForm<CongTy>
    {
        private LanguageManager langManager = LanguageManager.Instance;
        protected override string id => "MaCT";
        public fCongTy()
        {
            InitializeComponent();
            InitializePagedForm(dgvCongTy, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
            langManager.LanguageChanged += LangManager_LanguageChanged;
            this.Load += fCongTy_Load;
        }
        protected override List<CongTy> LoadFullData()
        {
            return CongTyBLL.Instance.LoadData();
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        protected override void OnFormClosing(FormClosingEventArgs e) 
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        protected override List<CongTy> SearchData(string keyword)
        {
            return CongTyBLL.Instance.SearchCongTy(keyword);
        }
        protected override void ConfigureDataGridViewColumns()
        {
            if (dgvMain.Columns.Contains("MaCT"))
            {
                dgvMain.Columns["MaCT"].HeaderText = "Mã công ty";
            }
            if (dgvMain.Columns.Contains("TenCT"))
            {
                dgvMain.Columns["TenCT"].HeaderText = "Tên công ty";
                dgvMain.Columns["TenCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("KyHieuCT"))
            {
                dgvMain.Columns["KyHieuCT"].HeaderText = "Ký hiệu công ty";
            }
            if (dgvMain.Columns.Contains("TenDaiDien"))
            {
                dgvMain.Columns["TenDaiDien"].HeaderText = "Tên người đại diện";
                dgvMain.Columns["TenDaiDien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("Sdt"))
            {
                dgvMain.Columns["Sdt"].HeaderText = "Số điện thoại";
            }
            if (dgvMain.Columns.Contains("DiaChi"))
            {
                dgvMain.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvMain.Columns["DiaChi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            UpdateLanguageTexts();
        }
        protected override void SetColumnHeaders()
        {
            dgvMain.Columns.Add("MaCT", "Mã công ty");
            dgvMain.Columns.Add("TenCT", "Tên công ty");
            dgvMain.Columns.Add("KyHieuCT", "Ký hiệu công ty");
            dgvMain.Columns.Add("TenDaiDien", "Tên người đại diện");
            dgvMain.Columns.Add("Sdt", "Số điện thoại");
            dgvMain.Columns.Add("DiaChi", "Địa chỉ");
            UpdateLanguageTexts();
        }
        protected override bool DeleteItem(string id)
        {
            return CongTyBLL.Instance.DeleteCongTy(id);
        }
        protected override Form CreateEditForm(CongTy item)
        {
            return new fCongTyEdit(item);
        }
        private void fCongTy_Load(object sender, EventArgs e)
        {
            btnDel.Visible = false;
            btnEdit.Visible = false;
            btnInsert.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageCustomers);
            UpdateLanguageTexts();
        }
        protected override void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit != null && btnDel != null && dgvMain.SelectedRows.Count > 0)
            {
                btnEdit.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageCustomers);
                btnDel.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageCustomers);
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void UpdateLanguageTexts() 
        {

            txtSearch.PlaceholderText = langManager.Translate("search");
            if (dgvCongTy.Columns.Contains("MaCT"))
                dgvCongTy.Columns["MaCT"].HeaderText = LanguageManager.Instance.Translate("company_code");
            if (dgvCongTy.Columns.Contains("TenCT"))
                dgvCongTy.Columns["TenCT"].HeaderText = LanguageManager.Instance.Translate("company_name");
            if (dgvCongTy.Columns.Contains("KyHieuCT"))
                dgvCongTy.Columns["KyHieuCT"].HeaderText = LanguageManager.Instance.Translate("company_symbol");
            if (dgvCongTy.Columns.Contains("TenDaiDien"))
                dgvCongTy.Columns["TenDaiDien"].HeaderText = LanguageManager.Instance.Translate("representative");
            if (dgvCongTy.Columns.Contains("Sdt"))
                dgvCongTy.Columns["Sdt"].HeaderText = LanguageManager.Instance.Translate("phone_number");
            if (dgvCongTy.Columns.Contains("DiaChi"))
                dgvCongTy.Columns["DiaChi"].HeaderText = LanguageManager.Instance.Translate("address");

            dgvCongTy.Refresh();

        }
    }
}