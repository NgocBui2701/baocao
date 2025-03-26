using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fNguoiDungEdit : EditForm<Account>
    {
        private bool seePass = false;
        public fNguoiDungEdit(Account acc = null) : base(acc)
        {
            InitializeComponent();
            if (acc != null)
            {
                labelTitle.Text = "Chỉnh sửa thông tin nhân viên";
            }
            LoadVaiTro();
            LoadData();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }
        private void LoadVaiTro()
        {
            cbVaiTro.Items.Add("Quản trị viên");
            cbVaiTro.Items.Add("Phòng kinh doanh");
            cbVaiTro.Items.Add("Phòng quan trắc");
            cbVaiTro.Items.Add("Phòng phân tích");
            cbVaiTro.Items.Add("Phòng kế hoạch");
            cbVaiTro.Items.Add("Phòng xuất kết quả");
        }
        protected override Account GetFormData()
        {
            return new Account(
                txtMaND.Text.Trim(),
                txtHoTen.Text.Trim(),
                cbVaiTro.SelectedItem?.ToString() ?? "",
                txtTenDangNhap.Text.Trim(),
                txtEmail.Text.Trim(),
                txtSdt.Text.Trim()
            );
        }
        protected override void LoadData()
        {
            txtMaND.Text = isEdit ? curr.MaNguoiDung : AccountBLL.Instance.GenerateMaNguoiDung();
            txtHoTen.Text = isEdit ? curr.Ten : "";
            cbVaiTro.SelectedItem = isEdit ? curr.VaiTro : "";
            txtTenDangNhap.Text = isEdit ? curr.TenDangNhap : "";
            txtMatKhau.Text = isEdit ? curr.MatKhau : "12345678";
            txtEmail.Text = isEdit ? curr.Email : "";
            txtSdt.Text = isEdit ? curr.Sdt : "";
        }
        protected override bool ValidateData(Account data)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vai trò không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        protected override bool SaveData(Account data)
        {
            if (isEdit)
            {
                return AccountBLL.Instance.UpdateAccount(data.MaNguoiDung, data.Ten, data.VaiTro, data.TenDangNhap, data.Email, data.Sdt);
            }
            else
            {
                return AccountBLL.Instance.InsertAccount(data.MaNguoiDung, data.Ten, data.VaiTro, data.TenDangNhap, data.Email, data.Sdt);
            }
        }
        private void btnSeePass_Click(object sender, EventArgs e)
        {
            if (seePass)
            {
                txtMatKhau.UseSystemPasswordChar = true;
                btnSeePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                seePass = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
                btnSeePass.IconChar = FontAwesome.Sharp.IconChar.Eye;
                seePass = true;
            }
        }
    }
}
