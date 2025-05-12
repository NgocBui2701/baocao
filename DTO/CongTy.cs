using System.Data;

namespace baocao.DTO
{
    public class CongTy
    {
        public CongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
            {
                MessageBox.Show("Mã công ty và tên công ty không được để trống.");
            }
            this.MaCT = maCT;
            this.TenCT = tenCT;
            this.KyHieuCT = kyHieuCT;
            this.TenDaiDien = tenDaiDien;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
        }

        public CongTy(DataRow row)
        {
            if (!row.Table.Columns.Contains("MaCT"))
            {
                MessageBox.Show("Cột 'MaCT' không tồn tại trong DataTable.");
            }

            this.MaCT = row["MaCT"]?.ToString();
            this.TenCT = row["TenCT"]?.ToString();
            this.KyHieuCT = row["KyHieuCT"]?.ToString();
            this.TenDaiDien = row["TenDaiDien"]?.ToString();
            this.Sdt = row["Sdt"]?.ToString();
            this.DiaChi = row["DiaChi"]?.ToString();

            if (string.IsNullOrEmpty(this.MaCT) || string.IsNullOrEmpty(this.TenCT))
            {
                MessageBox.Show("Mã công ty hoặc tên công ty không được để trống sau khi ánh xạ.");
            }
        }

        private string maCT;
        private string tenCT;
        private string kyHieuCT;
        private string tenDaiDien;
        private string sdt;
        private string diaChi;

        public string MaCT { get => maCT; set => maCT = value; }
        public string TenCT { get => tenCT; set => tenCT = value; }
        public string KyHieuCT { get => kyHieuCT; set => kyHieuCT = value; }
        public string TenDaiDien { get => tenDaiDien; set => tenDaiDien = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}