using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fCongTy : PagedForm<CongTy>
    {
        protected override string id => "MaCT";
        public fCongTy()
        {
            InitializeComponent();
            InitializePagedForm(dgvCongTy, txtSearch, labelPage, btnFirstPage, btnPrevPage, btnNextPage, btnLastPage, txtPage, btnInsert, btnEdit, btnDel);
            LoadData();
        }

        protected override List<CongTy> LoadFullData()
        {
            return CongTyBLL.Instance.LoadData();
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
        }
        protected override void SetColumnHeaders()
        {
            dgvMain.Columns.Add("MaCT", "Mã công ty");
            dgvMain.Columns.Add("TenCT", "Tên công ty");
            dgvMain.Columns.Add("KyHieuCT", "Ký hiệu công ty");
            dgvMain.Columns.Add("TenDaiDien", "Tên người đại diện");
            dgvMain.Columns.Add("Sdt", "Số điện thoại");
            dgvMain.Columns.Add("DiaChi", "Địa chỉ");
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
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}