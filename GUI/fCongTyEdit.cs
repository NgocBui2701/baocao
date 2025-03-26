using System;
using System.Collections.Generic;
using System.Windows.Forms;
using baocao.BLL;
using baocao.DTO;
using baocao.GUI.BaseForm;
using baocao.GUI.Managers;

namespace baocao.GUI
{
    public partial class fCongTyEdit : EditForm<CongTy>
    {
        public fCongTyEdit(CongTy congTy = null) : base(congTy)
        {
            InitializeComponent();
            if (congTy != null)
            {
                labelTitle.Text = "Chỉnh sửa công ty";
                LoadData();
            }
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }

        protected override CongTy GetFormData()
        {
            return new CongTy(
                txtMaCT.Text.Trim(),
                txtTenCT.Text.Trim(),
                txtKyHieuCT.Text.Trim(),
                txtTenDaiDien.Text.Trim(),
                txtSdt.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }

        protected override void LoadData()
        {
            if (isEdit)
            {
                txtMaCT.Text = curr.MaCT;
                txtMaCT.ReadOnly = true;
                txtTenCT.Text = curr.TenCT;
                txtKyHieuCT.Text = curr.KyHieuCT;
                txtTenDaiDien.Text = curr.TenDaiDien;
                txtSdt.Text = curr.Sdt;
                txtDiaChi.Text = curr.DiaChi;
            }
        }

        protected override bool ValidateData(CongTy data)
        {
            if (string.IsNullOrEmpty(data.MaCT) || string.IsNullOrEmpty(data.TenCT))
            {
                MessageBox.Show("Mã công ty và tên công ty không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected override bool SaveData(CongTy data)
        {
            if (isEdit)
            {
                return CongTyBLL.Instance.UpdateCongTy(data.MaCT, data.TenCT, data.KyHieuCT, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
            else
            {
                return CongTyBLL.Instance.InsertCongTy(data.MaCT, data.TenCT, data.KyHieuCT, data.TenDaiDien, data.Sdt, data.DiaChi);
            }
        }
    }
}