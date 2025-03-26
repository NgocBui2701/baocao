using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fDonHangEdit : EditForm<DonHang>
    {
        public fDonHangEdit(DonHang donHang = null) : base(donHang)
        {
            InitializeComponent();

            if (donHang == null)
            {
                cbbMaHD.SelectedIndex = -1;
            } 
            if (donHang != null)
            {
                labelTitle.Text = "Chỉnh sửa đơn hàng";
            }
            LoadMaHopDongToComboBox();
            LoadData();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }

        protected override DonHang GetFormData()
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

        protected override void LoadData()
        {
            try
            {
                txtMaDH.Text = isEdit ? curr.MaDH : DonHangBLL.Instance.GenerateMaDonHang();
                cbbMaHD.SelectedItem = isEdit ? curr.MaHD : string.Empty;
                dtpNLM.Value = isEdit ? curr.NgayLM : DateTime.Now;
                dtpNKQ.Value = isEdit ? curr.NgayKQ : DateTime.Now.AddDays(7);
                txtQuy.Text = isEdit ? curr.Quy.ToString() : ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
                txtTrangthai.Text = isEdit ? curr.Trangthai : "Đang xử lý";

                txtMaDH.Enabled = false;
                txtQuy.Enabled = false;
                txtTrangthai.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override bool ValidateData(DonHang data)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaDH) || data.NgayLM == DateTime.MinValue || data.NgayKQ == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(DonHang data)
        {
            try
            {
                if (isEdit)
                {
                    return DonHangBLL.Instance.UpdateDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
                }
                else
                {
                    return DonHangBLL.Instance.InsertDonHang(data.MaHD, data.MaDH, data.NgayLM, data.NgayKQ, data.Quy, data.Trangthai);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void LoadMaHopDongToComboBox()
        {
            List<string> danhSachMaHD = HopDongBLL.Instance.GetAllMaHopDong();
            if (danhSachMaHD.Count > 0)
            {
                cbbMaHD.DataSource = danhSachMaHD;
            }
        }

        private void dtpNLM_ValueChanged(object sender, EventArgs e)
        {
            txtQuy.Text = ((dtpNLM.Value.Month - 1) / 3 + 1).ToString();
        }
    }
}