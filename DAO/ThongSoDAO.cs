using System;
using System.Collections.Generic;
using System.Data;
using baocao.DTO;

namespace baocao.DAO
{
    public class ThongSoDAO
    {
        private static ThongSoDAO instance;
        public static ThongSoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongSoDAO();
                return instance;
            }
        }
        private ThongSoDAO() { }
        public List<ThongSo> GetKetQuaList(string maDonHang, string maViTri)
        {
            List<ThongSo> list = new List<ThongSo>();
            string query = "USP_GetKetQuaList";
            object[] parameters = { maDonHang, maViTri };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters, true);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ThongSo(row));
            }
            return list;
        }
        public List<ThongSo> GetThongSoByLoaiViTri(string loaiViTri)
        {
            string query = "USP_GetThongSoByLoaiViTri";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { loaiViTri }, true);
            List<ThongSo> danhSachThongSo = new List<ThongSo>();
            if (data.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in data.Rows)
                    {
                        danhSachThongSo.Add(new ThongSo(row));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi tạo danh sách ThongSo từ loại vị trí {loaiViTri}: " + ex.Message, ex);
                }
            }
            return danhSachThongSo;
        }
        public DataTable GetNguoiDungByVaiTro(string vaiTro)
        {
            string query = "USP_GetNguoiDungByVaiTro";
            object[] parameters = { vaiTro };
            return DataProvider.Instance.ExecuteQuery(query, parameters, true);
        }
        public bool InsertKetQuaDefault(KetQua ketQua)
        {
            string query = "EXEC USP_InsertKetQuaDefault @MaHopDong, @MaDonHang, @MaViTri, @MaThongSo, @KetQuaGiaTri, @Loai, @NguoiPhanTich, @AnLanQuanTrac, @KetLuan";

            object[] parameters = new object[]
            {
                ketQua.MaHopDong,
                ketQua.MaDonHang,
                ketQua.MaViTri,
                ketQua.MaThongSo,
                (object)ketQua.KetQuaGiaTri ?? DBNull.Value,
                (object)ketQua.Loai ?? DBNull.Value,
                (object)ketQua.NguoiPhanTich ?? DBNull.Value,
                ketQua.AnLanQuanTrac,
                (object)ketQua.KetLuan ?? DBNull.Value
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result < 0;
        }
        public bool InsertOrUpdateKetQua(KetQua ketQua, string loaiViTri, string tenThongSo, string donVi, string giaTriQuyChuanTCVN, string maThongSoCu)
        {
            string ketQuaGiaTriInput = ketQua.KetQuaGiaTri;
            if (!string.IsNullOrEmpty(ketQuaGiaTriInput))
            {
                if (!double.TryParse(ketQuaGiaTriInput, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double ketQuaGiaTri) || ketQuaGiaTri < 0)
                {
                    MessageBox.Show("Kết quả không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            string query = @"EXEC USP_InsertOrUpdateKetQua 
                            @ma_hop_dong, @ma_don_hang, @ma_vi_tri, @loai_vi_tri, 
                            @ten_thong_so, @don_vi, @gia_tri_quy_chuan_TCVN, 
                            @ma_thong_so_cu, @ket_qua, @loai, @nguoi_phan_tich, 
                            @an_lan_quan_trac, @ket_luan";
            object[] parameters = new object[]
            {
                ketQua.MaHopDong,
                ketQua.MaDonHang,
                ketQua.MaViTri,
                loaiViTri,
                tenThongSo,
                donVi,
                giaTriQuyChuanTCVN,
                maThongSoCu,
                (object)ketQua.KetQuaGiaTri ?? DBNull.Value,
                (object)ketQua.Loai ?? DBNull.Value,
                (object)ketQua.NguoiPhanTich ?? DBNull.Value,
                ketQua.AnLanQuanTrac,
                (object)ketQua.KetLuan ?? DBNull.Value
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result < 0;
        }
        public bool DeleteKetQua(string maHopDong, string maDonHang, string maViTri, string maThongSo)
        {
            string query = "EXEC USP_DeleteKetQua @ma_hop_dong, @ma_don_hang, @ma_vi_tri, @ma_thong_so";

            object[] parameters = new object[]
            {
                maHopDong,
                maDonHang,
                maViTri,
                maThongSo
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result < 0;
        }
        ////////////////////////////////////////////////////////////////////
        public List<ThongSo> GetCombinedThongSo(string maViTri, string maHopDong, string maDonHang, string loaiViTri, int currentQuy)
        {
            // 1. Lấy danh sách kết quả đã lưu từ KetQua (hiện tại) bằng stored procedure USP_GetKetQuaList
            List<ThongSo> savedResults = GetKetQuaList(maDonHang, maViTri);

            // 2. Lấy danh sách thông số từ ThongSoMoiTruong theo vị trí, hợp đồng, đơn hàng, loại vị trí bằng stored procedure USP_GetThongSoByMaViTri
            string query = "dbo.USP_GetThongSoByMaViTri";
            object[] parameters = new object[] { maViTri, maHopDong, maDonHang, loaiViTri };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters, true);

            List<ThongSo> combinedList = new List<ThongSo>();
            foreach (DataRow row in dt.Rows)
            {
                // Tạo đối tượng thông số từ ThongSoMoiTruong
                ThongSo ts = new ThongSo(row);

                // Nếu có kết quả đã lưu cho thông số này, cập nhật các trường kết quả hiện tại
                ThongSo saved = savedResults.Find(x => x.MaTS == ts.MaTS);
                if (saved != null)
                {
                    ts.KetQua = saved.KetQua;
                    ts.AnLanQuanTrac = saved.AnLanQuanTrac;
                    ts.Loai = saved.Loai;
                    ts.NguoiPhanTich = saved.NguoiPhanTich;
                    ts.KetLuan = saved.KetLuan;
                }
                // 3. Cập nhật trường KetQuaTruoc cho thông số này bằng cách gọi stored procedure USP_GetKetQuaTruoc
                ts.KetQuaTruoc = GetKetQuaTruoc(ts.MaTS, maViTri, maHopDong, currentQuy);

                combinedList.Add(ts);
            }

            return combinedList;
        }

        // Phương thức GetKetQuaTruoc đã được cập nhật (gọi proc dbo.USP_GetKetQuaTruoc)
        public string GetKetQuaTruoc(string maThongSo, string maViTri, string maHopDong, int currentQuy)
        {
            string query = "USP_GetKetQuaTruoc";
            var parameters = new Dictionary<string, object>()
            {
                { "@MaThongSo", maThongSo },
                { "@MaViTri", maViTri },
                { "@MaHopDong", maHopDong },
                { "@CurrentQuy", currentQuy }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters, true);
            return result == null ? "N/A" : result.ToString();
        }
    }
}
