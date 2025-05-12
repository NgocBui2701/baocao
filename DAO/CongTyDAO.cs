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
                    MessageBox.Show("Lỗi khi tạo đối tượng CongTy từ dữ liệu: " + ex.Message);
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
                    MessageBox.Show("Lỗi khi tạo đối tượng CongTy từ dữ liệu: " + ex.Message);
                }
            }
            return list;
        }

        public List<string> GetAllTenCongTy()
        {
            List<string> list = new List<string>();
            string query = "SELECT ten_cong_ty FROM CongTy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    string tenCongTy = row["ten_cong_ty"]?.ToString();
                    if (!string.IsNullOrEmpty(tenCongTy))
                    {
                        list.Add(tenCongTy);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy mã công ty: " + ex.Message);
                }
            }
            return list;
        }

        public CongTy GetCongTyByTenCongTy(string tenCT)
        {
            string query = "USP_GetCongTyByTenCongTy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenCT }, true);
            if (data.Rows.Count > 0)
            {
                try
                {
                    return new CongTy(data.Rows[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo đối tượng CongTy từ mã công ty {tenCT}: " + ex.Message);
                }
            }
            return null;
        }

        public bool InsertCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
            {
                MessageBox.Show("Mã công ty và tên công ty không được để trống.");
                return false;
            }

            if (!string.IsNullOrEmpty(sdt))
            {
                if (!sdt.All(char.IsDigit) || (sdt.Length != 10 && sdt.Length != 11))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    return false;
                }
            }

            string queryCheck = "SELECT COUNT(*) FROM CongTy WHERE ma_cong_ty = @maCT";
            var parametersCheck = new Dictionary<string, object>()
            {
                { "@maCT", maCT }
            };
            object countResult = DataProvider.Instance.ExecuteScalar(queryCheck, parametersCheck);
            int count = countResult != null ? Convert.ToInt32(countResult) : 0;
            if (count > 0)
            {
                MessageBox.Show("Mã công ty đã tồn tại trong cơ sở dữ liệu.");
                return false;
            }
            string query = "EXEC USP_InsertCongTy @maCT , @tenCT , @kyHieuCT , @tenDaiDien , @sdt , @diaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi });

            if (result > 0)
            {
                MessageBox.Show("Thêm công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }

        public bool UpdateCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
            {
                MessageBox.Show("Mã công ty và tên công ty không được để trống.");
                return false;
            }

            if (!string.IsNullOrEmpty(sdt))
            {
                if (!sdt.All(char.IsDigit) || (sdt.Length != 10 && sdt.Length != 11))
                {
                    MessageBox.Show("Số điện thoại phải là số và có độ dài 10 hoặc 11 số.");
                    return false;
                }
            }

            string query = "EXEC USP_UpdateCongTy @maCT , @tenCT , @kyHieuCT , @tenDaiDien , @sdt , @diaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi });

            if (result > 0)
            {
                MessageBox.Show("Cập nhật công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }

        public bool DeleteCongTy(string maCT)
        {
            if (string.IsNullOrEmpty(maCT))
            {
                MessageBox.Show("Mã công ty không được để trống.", nameof(maCT));
            }

            string query = "EXEC USP_DeleteCongTy @maCT";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCT });

            if (result > 0)
            {
                MessageBox.Show("Xóa công ty thất bại: Lỗi từ cơ sở dữ liệu.");
            }
            return result < 0;
        }
    }
}