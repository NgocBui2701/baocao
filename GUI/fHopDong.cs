using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fHopDong : PagedForm<HopDong>
    {
        protected override string id => "MaHD";
        public fHopDong()
        {
            InitializeComponent();
            InitializePagedForm(dgvHopDong, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
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
            btnDel.Visible = false;
            btnEdit.Visible = false;
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
