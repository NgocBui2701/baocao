using baocao.DTO;
using baocao.DAO;
using System.Globalization;

namespace baocao
{
    public partial class fDSHDEdit : Form
    {
        private bool isEdit = false;
        private Dshd curr = null;
        public fDSHDEdit(Dshd dshd = null)
        {
            InitializeComponent();
            if (dshd != null)
            {
                isEdit = true;
                curr = dshd;
                loadData();
            }
        }
        #region Methods
        private Dshd getFormData()
        {
            return new Dshd(
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
        private bool validate(Dshd data, out string formattedDate)
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
            Dshd data = getFormData();
            if (!validate(data, out string formattedDate))
            {
                return false;
            }
            bool success;
            if (isEdit)
            {
                success = DshdDAO.Instance.updateDshd(data.MaHD, data.MaCT, data.TenCT, data.KyHieuCT, formattedDate, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
            else
            {
                success = DshdDAO.Instance.insertDshd(data.MaHD, data.MaCT, data.TenCT, data.KyHieuCT, formattedDate, data.TenDaiDien, data.Sdt, data.DiaChi);
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
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.FillColor = Color.Red;
            btnExit.ForeColor = Color.White;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.FillColor = Color.Transparent;
            btnExit.ForeColor = Color.DarkGray;
        }
        #endregion
    }
}
