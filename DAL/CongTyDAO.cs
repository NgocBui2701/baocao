using System;
using System.Collections.Generic;
using System.Data;
using baocao.DTO;

namespace baocao.DAO
{
    public class CongTyDAO
    {
        private static CongTyDAO instance;
        public static CongTyDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CongTyDAO();
                return CongTyDAO.instance;
            }
            private set
            {
                CongTyDAO.instance = value;
            }
        }

        private CongTyDAO() { }

        public List<CongTy> LoadData()
        {
            List<CongTy> list = new List<CongTy>();
            string query = "USP_GetCongTyList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { }, true);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    CongTy congTy = new CongTy(row);
                    list.Add(congTy);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi tạo đối tượng CongTy từ dữ liệu: " + ex.Message, ex);
                }
            }
            return list;
        }

        public List<CongTy> SearchCongTy(string keyword)
        {
            List<CongTy> list = new List<CongTy>();
            string query = "USP_SearchCongTy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    CongTy congTy = new CongTy(row);
                    list.Add(congTy);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi tạo đối tượng CongTy từ dữ liệu: " + ex.Message, ex);
                }
            }
            return list;
        }

        public List<string> GetAllMaCongTy()
        {
            List<string> list = new List<string>();
            string query = "SELECT ma_cong_ty FROM CongTy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    string maCongTy = row["ma_cong_ty"]?.ToString();
                    if (!string.IsNullOrEmpty(maCongTy))
                    {
                        list.Add(maCongTy);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy mã công ty: " + ex.Message, ex);
                }
            }
            return list;
        }

        public CongTy GetCongTyByMaCongTy(string maCT)
        {
            if (string.IsNullOrEmpty(maCT))
            {
                throw new ArgumentException("Mã công ty không được để trống.", nameof(maCT));
            }

            string query = "USP_GetCongTyByMaCongTy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maCT }, true);

            if (data.Rows.Count > 0)
            {
                try
                {
                    return new CongTy(data.Rows[0]);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi tạo đối tượng CongTy từ mã công ty {maCT}: " + ex.Message, ex);
                }
            }
            return null;
        }

        public bool InsertCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
            {
                throw new ArgumentException("Mã công ty và tên công ty không được để trống.");
            }

            string query = "EXEC USP_InsertCongTy @maCT , @tenCT , @kyHieuCT , @tenDaiDien , @sdt , @diaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi });

            if (result < 0)
            {
                throw new Exception("Thêm công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }

        public bool UpdateCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
            {
                throw new ArgumentException("Mã công ty và tên công ty không được để trống.");
            }

            string query = "EXEC USP_UpdateCongTy @maCT , @tenCT , @kyHieuCT , @tenDaiDien , @sdt , @diaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi });

            if (result < 0)
            {
                throw new Exception("Cập nhật công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }

        public bool DeleteCongTy(string maCT)
        {
            if (string.IsNullOrEmpty(maCT))
            {
                throw new ArgumentException("Mã công ty không được để trống.", nameof(maCT));
            }

            string query = "EXEC USP_DeleteCongTy @maCT";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT });

            if (result < 0)
            {
                throw new Exception("Xóa công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }
    }
}