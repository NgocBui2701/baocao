using baocao.DTO;
using baocao.DAO;
using System.Globalization;

namespace baocao
{
    public partial class fDonHangEdit : Form
    {
        private bool isEdit = false;
        private DonHang curr = null;
        public fDonHangEdit(DonHang DonHang = null)
        {
            InitializeComponent();
            if (DonHang != null)
            {
                isEdit = true;
                curr = DonHang;
            }
            else cbbMaHD.SelectedIndex = -1;
            loadData();
            LoadMaHopDongToComboBox();
        }
        #region Methods
        private DonHang getFormData()
        {
            return new DonHang(
                cbbMaHD.SelectedItem?.ToString() ?? string.Empty,
                txtMaDH.Text?.Trim() ?? string.Empty,
                dtpNLM.Value,
                dtpNKQ.Value,
                int.Parse(txtQuy.Text),
                txtTrangthai.Text
            );
        }
        private void loadData()
        {
            txtMaDH.Text = isEdit ? curr.MaDH : DonHangDAO.Instance.GenerateMaDonHang();
            cbbMaHD.SelectedItem = isEdit ? curr.MaHD : string.Empty;
            dtpNLM.Value = isEdit ? curr.NgayLM : DateTime.Now;
            dtpNKQ.Value = isEdit ? curr.NgayKQ : DateTime.Now.AddDays(7);
            txtQuy.Text = isEdit ? curr.Quy.ToString() : ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
            txtTrangthai.Text = isEdit ? curr.Trangthai : "Đang xử lý";
            txtMaDH.Enabled = false;
            txtQuy.Enabled = false;
            txtTrangthai.Enabled = false;
        }
        private bool validate(DonHang data)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaDH) || data.NgayLM == DateTime.MinValue || data.NgayKQ == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (data.NgayLM > data.NgayKQ)
            {
                MessageBox.Show("Ngày lập hợp đồng không thể sau ngày kết quả!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!DonHangDAO.Instance.CheckMaHopDongExists(data.MaHD))
            {
                MessageBox.Show("Mã hợp đồng không tồn tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (DonHangDAO.Instance.CheckDuplicateDonHang(data.MaHD, data.Quy, data.NgayLM.Year))
            {
                MessageBox.Show("Hợp đồng này đã có đơn hàng trong quý này!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool saveData()
        {
            DonHang data = getFormData();
            if (!validate(data))
            {
                return false;
            }
            bool success;
            if (isEdit)
            {
                success = DonHangDAO.Instance.updateDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
            }
            else
            {
                success = DonHangDAO.Instance.insertDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
            }
            if (success)
            {
                MessageBox.Show(isEdit ? "Cập nhật thành công!" : "Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }
        private void LoadMaHopDongToComboBox()
        {
            List<string> danhSachMaHD = DonHangDAO.Instance.GetAllMaHopDong();

            if (danhSachMaHD.Count > 0)
            {
                cbbMaHD.DataSource = danhSachMaHD;
            }
        }
        #endregion
        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnSave_Click(sender, e);
            }
            else if (result == DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void dtpNLM_ValueChanged(object sender, EventArgs e)
        {
            txtQuy.Text = ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
        }
        #endregion
    }
}
