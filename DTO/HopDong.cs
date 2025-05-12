using System.Data;

namespace baocao.DTO
{
    public class HopDong
    {
        public HopDong(string maHD, string maCT, string tenCT, string kyHieuCT, DateTime ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            this.MaHD = maHD;
            this.MaCT = maCT;
            this.TenCT = tenCT;
            this.KyHieuCT = kyHieuCT;
            this.NgayHD = ngayHD;
            this.TenDaiDien = tenDaiDien;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
        }

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
