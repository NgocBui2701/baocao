using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Printing;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fDonHang : PagedForm<DonHang>
    {
        public event Action<string> OnOpenViTri;
        private bool isSelectingFromNotification = false;
        private string initialOrderId;
        protected override string id => "MaDH";
        public fDonHang(string orderId = null)
        {
            InitializeComponent();
            InitializePagedForm(dgvDonHang, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
            this.initialOrderId = orderId;
            if (!string.IsNullOrEmpty(initialOrderId))
            {
                isSelectingFromNotification = true;
                SelectOrderById(initialOrderId);
            }
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
            if (dgvMain.Columns.Contains("MaHD"))
                dgvMain.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            if (dgvMain.Columns.Contains("MaDH"))
                dgvMain.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            if (dgvMain.Columns.Contains("NgayLM"))
                dgvMain.Columns["NgayLM"].HeaderText = "Ngày bắt đầu lấy mẫu";
            if (dgvMain.Columns.Contains("NgayKQ"))
                dgvMain.Columns["NgayKQ"].HeaderText = "Ngày trả kết quả dự kiến";
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
                dgvDonHang.CellContentClick += dgvDonHang_CellContentClick;
            }
        }
        protected override void SetColumnHeaders()
        {
            dgvDonHang.Columns.Clear();
            dgvMain.Columns.Add("MaHD", "Mã hợp đồng");
            dgvMain.Columns.Add("MaDH", "Mã đơn hàng");
            dgvMain.Columns.Add("NgayLM", "Ngày bắt đầu lấy mẫu");
            dgvMain.Columns.Add("NgayKQ", "Ngày trả kết quả dự kiến");
            dgvMain.Columns.Add("Quy", "Quý");
            dgvMain.Columns.Add("Trangthai", "Trạng thái");
            dgvMain.Columns.Add("Thông số môi trường", "Thông số môi trường");
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

        private void fDonHang_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDonHang.Columns["Thông số môi trường"].Index)
            {
                int index = dgvDonHang.Rows[e.RowIndex].Index;
                DonHang selected = (DonHang)dgvDonHang.Rows[index].DataBoundItem;
                OnOpenViTri?.Invoke(selected.MaDH);
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
    }
}