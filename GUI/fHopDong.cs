using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using static baocao.GUI.fAITiengViet;

namespace baocao.GUI
{
    public partial class fHopDong : PagedForm<HopDong>, ITextUpdatable
    {
        private LanguageManager langManager = LanguageManager.Instance;
        protected override string id => "MaHD";
        public fHopDong()
        {
            InitializeComponent();
            InitializePagedForm(dgvHopDong, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
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
            this.Text = langManager.Translate("contract_form_title");
            txtSearch.PlaceholderText = langManager.Translate("search");

            foreach (DataGridViewColumn col in dgvHopDong.Columns)
            {
                switch (col.Name)
                {
                    case "MaHD":
                        col.HeaderText = langManager.Translate("contract_code");
                        break;
                    case "MaCT":
                        col.HeaderText = langManager.Translate("company_code");
                        break;
                    case "TenCT":
                        col.HeaderText = langManager.Translate("company_name");
                        break;
                    case "KyHieuCT":
                        col.HeaderText = langManager.Translate("company_symbol");
                        break;
                    case "NgayHD":
                        col.HeaderText = langManager.Translate("contract_date");
                        break;
                    case "TenDaiDien":
                        col.HeaderText = langManager.Translate("representative");
                        break;
                    case "Sdt":
                        col.HeaderText = langManager.Translate("phone_number");
                        break;
                    case "DiaChi":
                        col.HeaderText = langManager.Translate("address");
                        break;
                }
            }
        }
        protected override List<HopDong> LoadFullData()
        {
            return HopDongBLL.Instance.LoadData() ?? new List<HopDong>();
        }
        protected override List<HopDong> SearchData(string keyword)
        {
            return HopDongBLL.Instance.SearchHopDong(keyword) ?? new List<HopDong>();
        }
        protected override void ConfigureDataGridViewColumns()
        {
            if (dgvMain.Columns.Contains("MaHD"))
                dgvMain.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            if (dgvMain.Columns.Contains("MaCT"))
                dgvMain.Columns["MaCT"].HeaderText = "Mã công ty";
            if (dgvMain.Columns.Contains("TenCT"))
            {
                dgvMain.Columns["TenCT"].HeaderText = "Tên công ty";
                dgvMain.Columns["TenCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("KyHieuCT"))
            {
                dgvMain.Columns["KyHieuCT"].HeaderText = "Ký hiệu công ty";
            }
            if (dgvMain.Columns.Contains("NgayHD"))
            {
                dgvMain.Columns["NgayHD"].HeaderText = "Ngày ký hợp đồng";
                dgvMain.Columns["NgayHD"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            dgvMain.Columns.Add("MaHD", "Mã hợp đồng");
            dgvMain.Columns.Add("MaCT", "Mã công ty");
            dgvMain.Columns.Add("TenCT", "Tên công ty");
            dgvMain.Columns.Add("KyHieuCT", "Ký hiệu công ty");
            dgvMain.Columns.Add("NgayHD", "Ngày ký hợp đồng");
            dgvMain.Columns.Add("TenDaiDien", "Tên người đại diện");
            dgvMain.Columns.Add("Sdt", "Số điện thoại");
            dgvMain.Columns.Add("DiaChi", "Địa chỉ");
            UpdateLanguageTexts();
        }
        protected override void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit != null && btnDel != null && dgvMain.SelectedRows.Count > 0)
            {
                btnEdit.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageContracts);
                btnDel.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageContracts);
            }
        }
        protected override bool DeleteItem(string id)
        {
            return HopDongBLL.Instance.DeleteHopDong(id);
        }
        protected override Form CreateEditForm(HopDong item)
        {
            return new fHopDongEdit(item);
        }
        private void fHopDong_Load(object sender, EventArgs e)
        {
            btnInsert.Visible = false;
            btnDel.Visible = false;
            btnEdit.Visible = false;
            if (PermissionManager.HasPermission(PermissionManager.Permissions.ManageContracts))
            {
                btnInsert.Visible = true;
            }
            UpdateLanguageTexts();
        }
        public void UpdateText(string text)
        {
            txtSearch.Text = text;
        }
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            OnForm_Click(sender, e);
            fAITiengViet formVietnamese = new fAITiengViet(this);
            formVietnamese.Show();
        }
    }
} // ?????? má khó r, thấy lỗi gì kì kì k