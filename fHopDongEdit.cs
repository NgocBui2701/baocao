using baocao.DTO;
using baocao.DAO;
using System.Globalization;

namespace baocao
{
    public partial class fHopDongEdit : Form
    {
        private bool isEdit = false;
        private HopDong curr = null;
        public fHopDongEdit(HopDong HopDong = null)
        {
            InitializeComponent();
            if (HopDong != null)
            {
                isEdit = true;
                curr = HopDong;
                loadData();
            }
        }
        #region Methods
        private HopDong getFormData()
        {
            return new HopDong(
                txtMaHD.Text.Trim(),
                txtMaCT.Text.Trim(),
                txtTenCT.Text.Trim(),
                txtKyHieuCT.Text.Trim(),
                txtNgayHD.Text.Trim(),
                txtTenDaiDien.Text.Trim(),
                txtSdt.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }
        private void loadData()
        {
            txtMaHD.Text = curr.MaHD;
            txtMaCT.Text = curr.MaCT;
            txtTenCT.Text = curr.TenCT;
            txtKyHieuCT.Text = curr.KyHieuCT;
            txtNgayHD.Text = curr.NgayHD;
            txtTenDaiDien.Text = curr.TenDaiDien;
            txtSdt.Text = curr.Sdt;
            txtDiaChi.Text = curr.DiaChi;
            txtMaCT.Enabled = false;
            txtMaHD.Enabled = false;
        }
        private bool validate(HopDong data, out string formattedDate)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaCT) || string.IsNullOrEmpty(data.TenCT) || string.IsNullOrEmpty(data.KyHieuCT) || string.IsNullOrEmpty(data.NgayHD) || string.IsNullOrEmpty(data.TenDaiDien) || string.IsNullOrEmpty(data.Sdt) || string.IsNullOrEmpty(data.DiaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                formattedDate = null;
                return false;
            }
            DateTime parsedDate;
            bool isValidDate = DateTime.TryParseExact(data.NgayHD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            if (!isValidDate)
            {
                MessageBox.Show("Ngày ký hợp đồng không hợp lệ! Nhập theo định dạng dd/MM/yyyy", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                formattedDate = null;
                return false;
            }
            formattedDate = parsedDate.ToString("yyyy-MM-dd");
            return true;
        }
        private bool saveData()
        {
            HopDong data = getFormData();
            if (!validate(data, out string formattedDate))
            {
                return false;
            }
            bool success;
            if (isEdit)
            {
                success = HopDongDAO.Instance.updateHopDong(data.MaHD, data.MaCT, data.TenCT, data.KyHieuCT, formattedDate, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
            else
            {
                success = HopDongDAO.Instance.insertHopDong(data.MaHD, data.MaCT, data.TenCT, data.KyHieuCT, formattedDate, data.TenDaiDien, data.Sdt, data.DiaChi);
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
        #endregion
    }
}
