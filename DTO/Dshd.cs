using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace baocao.DTO
{
    public class Dshd
    {
        public Dshd(string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            this.MaCT = maCT;
            this.TenCT = tenCT;
            this.KyHieuCT = kyHieuCT;
            this.NgayHD = ngayHD;
            this.TenDaiDien = tenDaiDien;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
        }
        public Dshd(DataRow row)
        {
            if (!row.Table.Columns.Contains("MaCT"))
            {
                throw new ArgumentException("Cột 'MaCT' không tồn tại trong DataTable.");
            }

            this.MaCT = row["MaCT"].ToString();
            this.TenCT = row["TenCT"].ToString();
            this.KyHieuCT = row["KyHieuCT"].ToString();
            this.NgayHD = row["NgayHD"].ToString(); 
            this.TenDaiDien = row["TenDaiDien"].ToString();
            this.Sdt = row["Sdt"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
        }

        private string maCT;
        private string tenCT;
        private string kyHieuCT;
        private string ngayHD;
        private string tenDaiDien;
        private string sdt;
        private string diaChi;
        public string MaCT { get => maCT; set => maCT = value; }
        public string TenCT { get => tenCT; set => tenCT = value; }
        public string KyHieuCT { get => kyHieuCT; set => kyHieuCT = value; }
        public string NgayHD { get => ngayHD; set => ngayHD = value; }
        public string TenDaiDien { get => tenDaiDien; set => tenDaiDien = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

    }
}
