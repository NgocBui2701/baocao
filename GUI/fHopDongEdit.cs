using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fHopDongEdit : EditForm<HopDong>
    {
        public fHopDongEdit(HopDong HopDong = null) : base(HopDong)
        {
            InitializeComponent();
            if (HopDong != null)
            {
                labelTitle.Text = "Chỉnh sửa hợp đồng";
            }
            LoadMaCT();
            LoadData();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }
        protected override HopDong GetFormData()
        {
            return new HopDong(
                txtMaHD.Text.Trim(),
                cbMaCT.SelectedItem?.ToString() ?? "",
                txtTenCT.Text.Trim(),
                txtKyHieuCT.Text.Trim(),
                dtpNgayHD.Value,
                txtTenDaiDien.Text.Trim(),
                txtSdt.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }
        private void LoadMaCT()
        {
            cbMaCT.DataSource = CongTyBLL.Instance.GetAllMaCongTy();
            cbMaCT.SelectedIndexChanged += CbMaCT_SelectedIndexChanged;
        }

        private void CbMaCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maCT = cbMaCT.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(maCT)) return;

            var congTy = CongTyBLL.Instance.GetCongTyByMaCongTy(maCT);
            if (congTy != null)
            {
                txtTenCT.Text = congTy.TenCT;
                txtKyHieuCT.Text = congTy.KyHieuCT;
                txtTenDaiDien.Text = congTy.TenDaiDien;
                txtSdt.Text = congTy.Sdt;
                txtDiaChi.Text = congTy.DiaChi;
            }
        }

        protected override void LoadData()
        {
            txtMaHD.Text = isEdit ? curr.MaHD : HopDongBLL.Instance.GenerateMaHopDong();
            cbMaCT.SelectedItem = isEdit ? curr.MaCT : string.Empty;
            txtTenCT.Text = isEdit ? curr.TenCT : string.Empty;
            txtKyHieuCT.Text = isEdit ? curr.KyHieuCT : string.Empty;
            dtpNgayHD.Value = isEdit ? curr.NgayHD : DateTime.Now;
            txtTenDaiDien.Text = isEdit ? curr.TenDaiDien : string.Empty;
            txtSdt.Text = isEdit ? curr.Sdt : string.Empty;
            txtDiaChi.Text = isEdit ? curr.DiaChi : string.Empty;
        }

        protected override bool ValidateData(HopDong data)
        {
            if (string.IsNullOrEmpty(data.MaHD) || string.IsNullOrEmpty(data.MaCT))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(HopDong data)
        {
            if (isEdit)
            {
                return HopDongBLL.Instance.UpdateHopDong(data.MaHD, data.MaCT, data.NgayHD);
            }
            else
            {
                return HopDongBLL.Instance.InsertHopDong(data.MaHD, data.MaCT, data.NgayHD);
            }
        }
        private void cbMaCT_TextChanged(object sender, EventArgs e)
        {
            CongTy congTy = CongTyBLL.Instance.GetCongTyByMaCongTy(cbMaCT.Text);

            if (congTy != null)
            {
                txtTenCT.Text = congTy.TenCT;
                txtKyHieuCT.Text = congTy.KyHieuCT;
                txtTenDaiDien.Text = congTy.TenDaiDien;
                txtSdt.Text = congTy.Sdt;
                txtDiaChi.Text = congTy.DiaChi;
            }
            else
            {
                txtTenCT.Text = "";
                txtKyHieuCT.Text = "";
                txtTenDaiDien.Text = "";
                txtSdt.Text = "";
                txtDiaChi.Text = "";
            }
        }

    }
}
