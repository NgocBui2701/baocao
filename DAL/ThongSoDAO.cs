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

        public List<ThongSo> GetAllThongSo()
        {
            List<ThongSo> list = new List<ThongSo>();
            string query = "SELECT * FROM ThongSoMoiTruong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    ThongSo ts = new ThongSo(row);
                    list.Add(ts);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi convert DataRow sang ThongSo: " + ex.Message);
                }
            }
            return list;
        }

        public List<string> GetAllMaDonHang()
        {
            List<string> list = new List<string>();
            string query = "SELECT ma_don_hang FROM DonHang";  // Chỉ lấy cột ma_don_hang
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(row["ma_don_hang"].ToString());
            }
            return list;
        }

        public bool InsertThongSo(ThongSo ts)
        {
            string query = @"INSERT INTO ThongSoMoiTruong 
                            (ma_thong_so, ma_don_hang, ma_vi_tri, ten_thong_so, don_vi, ket_qua, an_lan_quan_trac, loai, nguoi_phan_tich, gia_tri_quy_chuan_TCVN, ket_luan)
                             VALUES 
                            (@ma_thong_so, @ma_don_hang, @ma_vi_tri, @ten_thong_so, @don_vi, @ket_qua, @an_lan_quan_trac, @loai, @nguoi_phan_tich, @gia_tri_quy_chuan_TCVN, @ket_luan)";
            object[] parameters = new object[]
            {
                ts.MaTS,
                ts.MaDH,
                ts.MaVT,
                ts.TenTS,
                ts.DonVi,
                ts.KetQua,
                ts.AnLanQuanTrac,
                ts.Loai,
                ts.NguoiPhanTich,
                ts.GiaTriQuyChuanTCVN,
                string.IsNullOrEmpty(ts.KetLuan) ? DBNull.Value : (object)ts.KetLuan
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateThongSo(ThongSo ts)
        {
            string query = @"UPDATE ThongSoMoiTruong
                             SET 
                                ma_don_hang = @ma_don_hang,
                                ma_vi_tri = @ma_vi_tri,
                                ten_thong_so = @ten_thong_so,
                                don_vi = @don_vi,
                                ket_qua = @ket_qua,
                                an_lan_quan_trac = @an_lan_quan_trac,
                                loai = @loai,
                                nguoi_phan_tich = @nguoi_phan_tich,
                                gia_tri_quy_chuan_TCVN = @gia_tri_quy_chuan_TCVN,
                                ket_luan = @ket_luan
                             WHERE ma_thong_so = @ma_thong_so";
            object[] parameters = new object[]
            {
                ts.MaDH,
                ts.MaVT,
                ts.TenTS,
                ts.DonVi,
                ts.KetQua,
                ts.AnLanQuanTrac,
                ts.Loai,
                ts.NguoiPhanTich,
                ts.GiaTriQuyChuanTCVN,
                string.IsNullOrEmpty(ts.KetLuan) ? DBNull.Value : (object)ts.KetLuan,
                ts.MaTS
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteThongSo(string maTS)
        {
            string query = "DELETE FROM ThongSoMoiTruong WHERE ma_thong_so = @ma_thong_so";
            object[] parameters = new object[] { maTS };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
