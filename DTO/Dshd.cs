using System;
using System.Data;

namespace baocao.DTO
{
    public class Dshd
    {
<<<<<<< HEAD:DTO/HopDong.cs
        public HopDong(string maHD, string maCT, string tenCT, string kyHieuCT, DateTime ngayHD, string tenDaiDien, string sdt, string diaChi)
=======
        public Dshd(string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
>>>>>>> parent of 15cbd76 (sql):DTO/Dshd.cs
        {
            this.MaCT = maCT;
            this.TenCT = tenCT;
            this.KyHieuCT = kyHieuCT;
            this.NgayHD = ngayHD;
            this.TenDaiDien = tenDaiDien;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
        }
<<<<<<< HEAD:DTO/HopDong.cs

        public HopDong(DataRow row)
        {
            if (!row.Table.Columns.Contains("MaHD") || !row.Table.Columns.Contains("MaCT") || !row.Table.Columns.Contains("NgayHD"))
            {
                MessageBox.Show("Thiếu cột cần thiết trong DataTable.");
            }

            this.MaHD = row["MaHD"].ToString();
            this.MaCT = row["MaCT"].ToString();
            this.TenCT = row.Table.Columns.Contains("TenCT") ? row["TenCT"].ToString() : string.Empty;
            this.KyHieuCT = row.Table.Columns.Contains("KyHieuCT") ? row["KyHieuCT"].ToString() : string.Empty;
            this.NgayHD = row["NgayHD"] != DBNull.Value ? Convert.ToDateTime(row["NgayHD"]) : DateTime.MinValue;
            this.TenDaiDien = row.Table.Columns.Contains("TenDaiDien") ? row["TenDaiDien"].ToString() : string.Empty;
            this.Sdt = row.Table.Columns.Contains("Sdt") ? row["Sdt"].ToString() : string.Empty;
            this.DiaChi = row.Table.Columns.Contains("DiaChi") ? row["DiaChi"].ToString() : string.Empty;
        }
=======
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
>>>>>>> parent of 15cbd76 (sql):DTO/Dshd.cs

        public string MaHD { get; set; }
        public string MaCT { get; set; }
        public string TenCT { get; set; }
        public string KyHieuCT { get; set; }
        public DateTime NgayHD { get; set; }
        public string TenDaiDien { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
    }
}
