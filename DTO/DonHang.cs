using System.Data;

namespace baocao.DTO
{
    public class DonHang
    {
        public DonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai, string tenCT = null)
        {
            this.TenCT = tenCT;
            this.MaHD = maHD;
            this.MaDH = maDH;
            this.NgayLM = ngayLM;
            this.NgayKQ = ngayKQ;
            this.Quy = quy;
            this.Trangthai = trangThai;
        }

        public DonHang(DataRow row)
        {
            if (!row.Table.Columns.Contains("MaDH"))
            {
                MessageBox.Show("Cột 'MaDH' không tồn tại trong DataTable.");
            }
            this.TenCT = row["TenCT"].ToString();
            this.MaHD = row["MaHD"].ToString();
            this.MaDH = row["MaDH"].ToString();
            this.NgayLM = row["NgayLM"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayLM"]);
            this.NgayKQ = row["NgayKQ"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayKQ"]);
            this.Quy =Convert.ToInt32(row["Quy"]);
            this.Trangthai = row["Trangthai"].ToString();
        }

        private string tenCT;
        private string maHD;
        private string maDH;
        private DateTime ngayLM;
        private DateTime ngayKQ;
        private int quy;
        private string trangThai;

        public string TenCT { get => tenCT; set => tenCT = value; }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaDH { get => maDH; set => maDH = value; }
        public DateTime NgayLM { get => ngayLM; set => ngayLM = value; }
        public DateTime NgayKQ { get => ngayKQ; set => ngayKQ = value; }
        public int Quy { get => quy; set => quy = value; }
        public string Trangthai { get => trangThai; set => trangThai = value; }
    }
}
