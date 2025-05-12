using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static baocao.GUI.fAITiengViet;

namespace baocao.GUI
{
    public partial class fQuanLyPhanQuyen : PagedForm<Account> 
    {
        private LanguageManager langManager = LanguageManager.Instance;
        protected override string id => "MaNguoiDung";
        public fQuanLyPhanQuyen()
        {
            InitializeComponent();
            InitializePagedForm(dgvQuanLyPhanQuyen, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            btnMic.Visible = false;
            LoadData();
            langManager.LanguageChanged += LangManager_LanguageChanged;
            UpdateLanguageTexts();
        }
        protected override List<Account> LoadFullData()
        {
            return AccountBLL.Instance.LoadData() ?? new List<Account>();
        }
        protected override List<Account> SearchData(string keyword)
        {
            return AccountBLL.Instance.SearchAccount(keyword) ?? new List<Account>();
        }
        protected override void ConfigureDataGridViewColumns()
        {
            if (dgvMain.Columns.Contains("MatKhau"))
            {
                dgvMain.Columns.Remove("MatKhau");
            }
            if (dgvMain.Columns.Contains("MaNguoiDung"))
                dgvMain.Columns["MaNguoiDung"].HeaderText = "Mã nhân viên";
            if (dgvMain.Columns.Contains("Ten"))
            {
                dgvMain.Columns["Ten"].HeaderText = "Họ tên";
                dgvMain.Columns["Ten"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("VaiTro"))
            {
                dgvMain.Columns["VaiTro"].HeaderText = "Phòng ban";
                dgvMain.Columns["VaiTro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("TenDangNhap"))
            {
                dgvMain.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                dgvMain.Columns["TenDangNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("Email"))
            {
                dgvMain.Columns["Email"].HeaderText = "Email";
                dgvMain.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("Sdt"))
            {
                dgvMain.Columns["sdt"].DisplayIndex = 2;
                dgvMain.Columns["Sdt"].HeaderText = "Số điện thoại";
            }
            UpdateLanguageTexts();
        }
        protected override void SetColumnHeaders()
        {
            dgvMain.Columns.Add("MaNguoiDung", "Mã nhân viên");
            dgvMain.Columns.Add("Ten", "Họ tên");
            dgvMain.Columns.Add("Sdt", "Số điện thoại");
            dgvMain.Columns.Add("VaiTro", "Phòng ban");
            dgvMain.Columns.Add("TenDangNhap", "Tên đăng nhập");
            dgvMain.Columns.Add("Email", "Email");
            UpdateLanguageTexts();
        }
        protected override bool DeleteItem(string id)
        {
            return AccountBLL.Instance.DeleteAccount(id);
        }
        protected override Form CreateEditForm(Account item)
        {
            return new fNguoiDungEdit(item);
        }
        private void fQuanLyPhanQuyen_Load(object sender, EventArgs e)
        {
            btnDel.Visible = false;
            btnEdit.Visible = false;
            btnInsert.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManagePermissions);
            if (dgvMain.Columns.Contains("MatKhau"))
            {
                dgvMain.Columns.Remove("MatKhau");
            }
            UpdateLanguageTexts();
        }
        protected override void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit != null && btnDel != null && dgvMain.SelectedRows.Count > 0)
            {
                btnEdit.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManagePermissions);
                btnDel.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManagePermissions);
            }
        }
        private void UpdateLanguageTexts()
        {
            this.Text = langManager.Translate("permission_management");
            txtSearch.PlaceholderText = langManager.Translate("search");
            foreach (DataGridViewColumn col in dgvQuanLyPhanQuyen.Columns)
            {
                switch (col.Name)
                {
                    case "MaNguoiDung":
                        col.HeaderText = langManager.Translate("user_id"); // "Mã nhân viên"
                        break;
                    case "Ten":
                        col.HeaderText = langManager.Translate("full_name"); // "Họ tên"
                        break;
                    case "Sdt":
                        col.HeaderText = langManager.Translate("phone_number"); // "Số điện thoại"
                        break;
                    case "VaiTro":
                        col.HeaderText = langManager.Translate("role"); // "Vai trò"
                        break;
                    case "TenDangNhap":
                        col.HeaderText = langManager.Translate("username"); // "Tên đăng nhập"
                        break;
                    case "Email":
                        col.HeaderText = langManager.Translate("email"); // "Email"
                        break;
                }
            }
            foreach (DataGridViewRow row in dgvQuanLyPhanQuyen.Rows)
            {
                if (row.Cells["VaiTro"].Value != null)
                {
                    string roleValue = row.Cells["VaiTro"].Value.ToString();
                    row.Cells["VaiTro"].Value = TranslateRole(roleValue);
                }
            }
        }
        private string TranslateRole(string role)
        {
            switch (role)
            {
                case "Quản trị viên":
                case "Administrator":
                    return langManager.Translate("role_admin");
                case "Phòng kinh doanh":
                case "Sales Department":
                    return langManager.Translate("role_sales");
                case "Phòng quan trắc":
                case "Inspection Department":
                    return langManager.Translate("role_inspection");
                case "Phòng phân tích":
                case "Analysis Department":
                    return langManager.Translate("role_analysis");
                case "Phòng kế hoạch":
                case "Planning Department":
                    return langManager.Translate("role_planning");
                case "Phòng xuất kết quả":
                case "Results Department":
                    return langManager.Translate("role_results");
                default:
                    return role;
            }
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
    }
}
