using System;
using System.Data;

namespace baocao.DTO
{
    public class ThongSo
    {
        public ThongSo(int stt, string maDH, string maVT, string maTS, string tenTS, string donVi, string ketQua, bool anLanQuanTrac, string loai, string nguoiPhanTich, string giatriQuyChuanTCVN, string ketLuan)
        {
            this.STT = stt;
            this.MaDH = maDH;
            this.MaVT = maVT;
            this.MaTS = maTS;
            this.TenTS = tenTS;
            this.DonVi = donVi;
            this.KetQua = ketQua;
            this.AnLanQuanTrac = anLanQuanTrac;
            this.Loai = loai;
            this.NguoiPhanTich = nguoiPhanTich;
            this.GiaTriQuyChuanTCVN = giatriQuyChuanTCVN;
            this.KetLuan = ketLuan;
        }

        public ThongSo(DataRow row)
        {
            if (!row.Table.Columns.Contains("ma_thong_so"))
            {
                MessageBox.Show("Cột 'ma_thong_so' không tồn tại trong DataTable.");
            }

            this.MaTS = row["ma_thong_so"]?.ToString();

            if (row.Table.Columns.Contains("ma_don_hang"))
                this.MaDH = row["ma_don_hang"]?.ToString();

            if (row.Table.Columns.Contains("ma_vi_tri"))
                this.MaVT = row["ma_vi_tri"]?.ToString();

            if (row.Table.Columns.Contains("STT"))
                this.STT = row["STT"] == DBNull.Value ? 0 : Convert.ToInt32(row["STT"]);

            if (row.Table.Columns.Contains("ten_thong_so"))
                this.TenTS = row["ten_thong_so"]?.ToString();

            if (row.Table.Columns.Contains("don_vi"))
                this.DonVi = row["don_vi"]?.ToString();

            if (row.Table.Columns.Contains("ket_qua"))
                this.KetQua = row["ket_qua"]?.ToString();

            if (row.Table.Columns.Contains("an_lan_quan_trac"))
                this.AnLanQuanTrac = row["an_lan_quan_trac"] == DBNull.Value ? false : Convert.ToBoolean(row["an_lan_quan_trac"]);

            if (row.Table.Columns.Contains("loai"))
                this.Loai = row["loai"]?.ToString();

            if (row.Table.Columns.Contains("nguoi_phan_tich"))
                this.NguoiPhanTich = row["nguoi_phan_tich"]?.ToString();

            if (row.Table.Columns.Contains("gia_tri_quy_chuan_TCVN"))
                this.GiaTriQuyChuanTCVN = row["gia_tri_quy_chuan_TCVN"]?.ToString();

            if (row.Table.Columns.Contains("ket_luan"))
                this.KetLuan = row["ket_luan"]?.ToString();
        }

        private string maTS;
        private string maDH;
        private string maVT;
        private int stt;
        private string tenTS;
        private string donVi;
        private string ketQua;
        private bool anLanQuanTrac;
        private string loai;
        private string nguoiPhanTich;
        private string giatriQuyChuanTCVN;
        private string ketLuan;
        public string MaTS { get => maTS; set => maTS = value; }
        public string MaDH { get => maDH; set => maDH = value; }
        public string MaVT { get => maVT; set => maVT = value; }
        public int STT { get => stt; set => stt = value; }
        public string TenTS { get => tenTS; set => tenTS = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public string KetQua { get => ketQua; set => ketQua = value; }
        public bool AnLanQuanTrac { get => anLanQuanTrac; set => anLanQuanTrac = value; }
        public string Loai { get => loai; set => loai = value; }
        public string NguoiPhanTich { get => nguoiPhanTich; set => nguoiPhanTich = value; }
        public string GiaTriQuyChuanTCVN { get => giatriQuyChuanTCVN; set => giatriQuyChuanTCVN = value; }
        public string KetLuan { get => ketLuan; set => ketLuan = value; }
    }
}
