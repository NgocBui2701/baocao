using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Printing;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;
using System.Data;
using static baocao.GUI.fAITiengViet;

namespace baocao.GUI
{
    public partial class fDonHang : PagedForm<DonHang>, ITextUpdatable
    {
        private LanguageManager langManager = LanguageManager.Instance;  //4/5/2025
        public event Action<DonHang> OnOpenViTri;
        private bool isSelectingFromNotification = false;
        private string initialOrderId;
        protected override string id => "MaDH";
        public fDonHang(string orderId = null)
        {
            InitializeComponent();
            btnMic.Click += btnTranslate_Click;
            InitializePagedForm(dgvDonHang, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
            this.initialOrderId = orderId;
            if (!string.IsNullOrEmpty(initialOrderId))
            {
                isSelectingFromNotification = true;
                SelectOrderById(initialOrderId);
            }
            langManager.LanguageChanged += LangManager_LanguageChanged; //4/5/2025
            this.Load += fDonHang_Load; //4/5/2025

        }
        //public override void LoadData()
        //{
        //    ApplyDarkMode(DarkModeManager.IsDarkMode);
        //    dgvMain.Columns.Clear();
        //    fullData = LoadFullData() ?? new List<DonHang>();
        //    totalPages = (int)Math.Ceiling((double)fullData.Count / pageSize);
        //    LoadPage(1);
        //    dgvDonHang.CellContentClick -= dgvDonHang_CellContentClick;
        //    dgvDonHang.CellContentClick += dgvDonHang_CellContentClick;
        //}
        protected override void OnFormClosing(FormClosingEventArgs e)  //4/5/2025
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)  //4/5/2025
        {
            UpdateLanguageTexts();
        }
        private void UpdateLanguageTexts()  //4/5/2025
        {
            txtSearch.PlaceholderText = LanguageManager.Instance.Translate("search");
            if (dgvDonHang.Columns.Contains("TenCT"))
                dgvDonHang.Columns["TenCT"].HeaderText = LanguageManager.Instance.Translate("company_name");
            if (dgvDonHang.Columns.Contains("MaHD"))
                dgvDonHang.Columns["MaHD"].HeaderText = LanguageManager.Instance.Translate("contract_code");
            if (dgvDonHang.Columns.Contains("MaDH"))
                dgvDonHang.Columns["MaDH"].HeaderText = LanguageManager.Instance.Translate("order_code");
            if (dgvDonHang.Columns.Contains("NgayLM"))
                dgvDonHang.Columns["NgayLM"].HeaderText = LanguageManager.Instance.Translate("created_date");
            if (dgvDonHang.Columns.Contains("NgayKQ"))
                dgvDonHang.Columns["NgayKQ"].HeaderText = LanguageManager.Instance.Translate("result_date");
            if (dgvDonHang.Columns.Contains("Quy"))
                dgvDonHang.Columns["Quy"].HeaderText = LanguageManager.Instance.Translate("quarter");
            if (dgvDonHang.Columns.Contains("Trangthai"))
                dgvDonHang.Columns["Trangthai"].HeaderText = LanguageManager.Instance.Translate("status");


            if (dgvDonHang.Columns.Contains("Thông số môi trường"))
            {
                DataGridViewButtonColumn btnColumn = dgvDonHang.Columns["Thông số môi trường"] as DataGridViewButtonColumn;
                if (btnColumn != null)
                {
                    btnColumn.HeaderText = LanguageManager.Instance.Translate("environmental_parameters");
                    btnColumn.Text = LanguageManager.Instance.Translate("view");
                    btnColumn.UseColumnTextForButtonValue = true;
                }
            }
            //4/5/2025
            foreach (DataGridViewRow row in dgvDonHang.Rows)
            {
                var cell = row.Cells["Trangthai"];
                string key = cell.Tag as string;

                if (string.IsNullOrEmpty(key))
                {
                    var currentValue = cell.Value?.ToString();
                    switch (currentValue)
                    {
                        case "Quá hạn":
                        case "overdue":
                            key = "overdue";
                            break;
                        case "Đang xử lý":
                        case "in_progress":
                            key = "in_progress";
                            break;
                        case "Hoàn thành":
                        case "completed":
                            key = "completed";
                            break;
                        default:
                            key = currentValue;
                            break;
                    }
                    cell.Tag = key;
                }
                cell.Value = LanguageManager.Instance.Translate(key);
                if (key == "overdue")
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    cell.Style.ForeColor = dgvDonHang.DefaultCellStyle.ForeColor;
                    cell.Style.Font = dgvDonHang.DefaultCellStyle.Font;
                }
            }
            dgvDonHang.Refresh();
        }

        protected override List<DonHang> LoadFullData()
        {
            return DonHangBLL.Instance.LoadData() ?? new List<DonHang>();
        }
        protected override List<DonHang> SearchData(string keyword)
        {
            return DonHangBLL.Instance.SearchDonHang(keyword) ?? new List<DonHang>();
        }
        protected override void ConfigureDataGridViewColumns()
        {
            if (dgvMain.Columns.Contains("TenCT"))
            {
                dgvMain.Columns["TenCT"].HeaderText = "Tên công ty";
                dgvMain.Columns["TenCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvMain.Columns.Contains("MaHD"))
            {
                dgvMain.Columns["MaHD"].Visible = false;
            }
            if (dgvMain.Columns.Contains("MaDH"))
                dgvMain.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            if (dgvMain.Columns.Contains("NgayLM"))
                dgvMain.Columns["NgayLM"].HeaderText = "Ngày lấy mẫu";
            if (dgvMain.Columns.Contains("NgayKQ"))
                dgvMain.Columns["NgayKQ"].HeaderText = "Ngày trả kết quả";
            if (dgvMain.Columns.Contains("Quy"))
                dgvMain.Columns["Quy"].HeaderText = "Quý";
            if (dgvMain.Columns.Contains("Trangthai"))
                dgvMain.Columns["Trangthai"].HeaderText = "Trạng thái";
            if (dgvMain.Columns.Contains("NgayLM"))
                dgvMain.Columns["NgayLM"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvMain.Columns.Contains("NgayKQ"))
                dgvMain.Columns["NgayKQ"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvMain.Columns.Contains("Trangthai"))
                dgvMain.Columns["Trangthai"].HeaderText = "Trạng thái";
            if (!dgvDonHang.Columns.Contains("Thông số môi trường"))
            {
                DataGridViewButtonColumn tsmtColumn = new DataGridViewButtonColumn
                {
                    Name = "Thông số môi trường",
                    HeaderText = "Thông số môi trường",
                    Text = "Xem",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true
                };
                dgvDonHang.Columns.Add(tsmtColumn);
            }
            UpdateLanguageTexts();
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMain.Columns[e.ColumnIndex].Name == "Trangthai")
            {
                string trangThai = e.Value?.ToString();
                if (trangThai == "Quá hạn")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        protected override void SetColumnHeaders()
        {
            dgvDonHang.Columns.Clear();
            dgvMain.Columns.Add("TenCT", "Tên công ty");
            dgvMain.Columns.Add("MaDH", "Mã đơn hàng");
            dgvMain.Columns.Add("NgayLM", "Ngày lấy mẫu");
            dgvMain.Columns.Add("NgayKQ", "Ngày trả kết quả");
            dgvMain.Columns.Add("Quy", "Quý");
            dgvMain.Columns.Add("Trangthai", "Trạng thái");
            dgvMain.Columns.Add("Thông số môi trường", "Thông số môi trường");
            UpdateLanguageTexts();
        }

        public void SelectOrderById(string orderId)
        {
            int index = LoadFullData().FindIndex(dh => dh.MaDH == orderId);
            if (index == -1) return;

            int page = (index / pageSize) + 1;
            LoadPage(page);
            Application.DoEvents();

            isSelectingFromNotification = true;
            SelectRowByOrderId(orderId);
            isSelectingFromNotification = false;
        }

        private void SelectRowByOrderId(string orderId)
        {
            foreach (DataGridViewRow row in dgvDonHang.Rows)
            {
                if (row.Cells["MaDH"].Value?.ToString() == orderId)
                {
                    dgvDonHang.ClearSelection();
                    row.Selected = true;
                    dgvDonHang.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        protected override bool DeleteItem(string id)
        {
            try
            {
                return DonHangBLL.Instance.DeleteDonHang(id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        protected override Form CreateEditForm(DonHang item)
        {
            return new fDonHangEdit(item);
        }
        bool isEventAttached = false;
        public void fDonHang_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDel.Visible = false;
            btnInsert.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageOrders);
            if (!isEventAttached)
            {
                dgvDonHang.CellContentClick += dgvDonHang_CellContentClick;
                isEventAttached = true;
            }

            //UpdateLanguageTexts();
        }

        protected override void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit != null && btnDel != null && dgvMain.SelectedRows.Count > 0)
            {
                btnEdit.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageOrders);
                btnDel.Visible = PermissionManager.HasPermission(PermissionManager.Permissions.ManageOrders);
            }
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDonHang.Columns["Thông số môi trường"].Index)
            {
                int index = dgvDonHang.Rows[e.RowIndex].Index;
                DonHang selected = (DonHang)dgvDonHang.Rows[index].DataBoundItem;


                List<Form> formsToClose = new List<Form>();
                foreach (Form form in Application.OpenForms)
                {
                    if (form is fViTri)
                    {
                        formsToClose.Add(form);
                    }
                }
                ;
                foreach (Form form in formsToClose)
                {
                    form.Close();
                }

                OnOpenViTri?.Invoke(selected);
            }
        }

        public event EventHandler DataRefreshed;

        protected override void LoadPage(int page)
        {
            base.LoadPage(page);
            DataRefreshed?.Invoke(this, EventArgs.Empty);
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
}
