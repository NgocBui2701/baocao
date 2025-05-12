using System;
using System.Data;

namespace baocao.DTO
{
    public class ThongSo
    {
        public ThongSo()
        {
        }

        public ThongSo(string maTS, string tenTS, string donVi, string loai, string nguoiPhanTich, string giaTriQuyChuanTCVN, string ketQua = null, string ketQuaTruoc = "N/A", bool anLanQuanTrac = false, string ketLuan = null)
        {
            MaTS = maTS;
            TenTS = tenTS;
            DonVi = donVi;
            KetQua = ketQua;
            KetQuaTruoc = ketQuaTruoc;
            AnLanQuanTrac = anLanQuanTrac;
            Loai = loai;
            NguoiPhanTich = nguoiPhanTich;
            GiaTriQuyChuanTCVN = giaTriQuyChuanTCVN;
            KetLuan = ketLuan;
        }

        public ThongSo(DataRow row)
        {
            if (!row.Table.Columns.Contains("MaTS"))
            {
                throw new Exception("Cột 'MaTS' không tồn tại!");
            }
            MaTS = row["MaTS"].ToString();
            TenTS = row["TenTS"].ToString();
            DonVi = row["DonVi"].ToString();
            KetQua = row.Table.Columns.Contains("KetQua") && row["KetQua"] != DBNull.Value ? row["KetQua"].ToString() : null;
            if (row.Table.Columns.Contains("ket_qua_truoc"))
                KetQuaTruoc = row["ket_qua_truoc"]?.ToString();
            else
                KetQuaTruoc = "N/A";
            AnLanQuanTrac = row.Table.Columns.Contains("AnLanQuanTrac") && row["AnLanQuanTrac"] != DBNull.Value && Convert.ToBoolean(row["AnLanQuanTrac"]);
            Loai = row.Table.Columns.Contains("Loai") ? row["Loai"].ToString() : null;
            NguoiPhanTich = row.Table.Columns.Contains("NguoiPT") ? row["NguoiPT"].ToString() : null;
            GiaTriQuyChuanTCVN = row.Table.Columns.Contains("TCVN") && row["TCVN"] != DBNull.Value ? row["TCVN"].ToString() : null;
            KetLuan = row.Table.Columns.Contains("KetLuan") && row["KetLuan"] != DBNull.Value ? row["KetLuan"].ToString() : null;
        }

        public string MaTS { get; set; }
        public string TenTS { get; set; }
        public string DonVi { get; set; }
        public string KetQua { get; set; }
        public string KetQuaTruoc { get; set; }
        public bool AnLanQuanTrac { get; set; }
        public string Loai { get; set; }
        public string NguoiPhanTich { get; set; }
        public string GiaTriQuyChuanTCVN { get; set; }
        public string KetLuan { get; set; }
        public string MaViTri { get; set; }
    }
}
