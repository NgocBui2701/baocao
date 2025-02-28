using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baocao.DTO
{
    [Serializable]
    public class Account
    {
        public Account(string ma_nguoi_dung, string ten, string vai_tro, string ten_dang_nhap, string email, string sdt, string mat_khau = null)
        {
            this.MaNguoiDung = ma_nguoi_dung;
            this.Ten = ten;
            this.VaiTro = vai_tro;
            this.TenDangNhap = ten_dang_nhap;
            this.MatKhau = mat_khau;
            this.Email = email;
            this.Sdt = sdt;
        }
        public Account (DataRow dataRow)
        {
            this.MaNguoiDung = dataRow["ma_nguoi_dung"].ToString();
            this.Ten = dataRow["ten"].ToString();
            this.VaiTro = dataRow["vai_tro"].ToString();
            this.TenDangNhap = dataRow["ten_dang_nhap"].ToString();
            this.MatKhau = dataRow["mat_khau"].ToString();
            this.Email = dataRow["email"].ToString();
            this.Sdt = dataRow["sdt"].ToString();
        }
        private string ma_nguoi_dung;
        private string ten;
        private string vai_tro;
        private string ten_dang_nhap;
        private string mat_khau;
        private string email;
        private string sdt;
        public string MaNguoiDung { get => ma_nguoi_dung; set => ma_nguoi_dung = value; }
        public string Ten { get => ten; set => ten = value; }
        public string VaiTro { get => vai_tro; set => vai_tro = value; }
        public string TenDangNhap { get => ten_dang_nhap; set => ten_dang_nhap = value; }
        public string MatKhau { get => mat_khau; set => mat_khau = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }

    }
}
