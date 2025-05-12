using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using baocao.DTO;
using NAudio.Gui;

namespace baocao.DAO
{
    public class DonHangDAO
    {
        private static DonHangDAO instance;
        public static DonHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonHangDAO();
                return DonHangDAO.instance;
            }
            private set
            {
                DonHangDAO.instance = value;
            }
        }
        public DonHangDAO() { }

        public List<DonHang> LoadData()
        {
            List<DonHang> list = new List<DonHang>();
            string query = "USP_GetDonHangList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    DonHang donHang = new DonHang(row);
                    list.Add(donHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
            return list;
        }

        public List<DonHang> SearchDonHang(string keyword)
        {
            List<DonHang> list = new List<DonHang>();
            string query = "USP_SearchDonHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    DonHang donHang = new DonHang(row);
                    list.Add(donHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return list;
        }

        public bool InsertDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            string query = "EXEC USP_InsertDonHang @MaDH, @MaHD, @NgayLM, @NgayKQ, @Quy, @TrangThai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH, maHD, ngayLM, ngayKQ, quy, trangThai });
            return result < 0; 
        }

        public bool CheckDuplicateDonHang(string maHD, int quy, int nam)
        {
            string query = "SELECT COUNT(*) FROM DonHang WHERE ma_hop_dong = @MaHD AND quy = @Quy AND YEAR(ngay_bat_dau_lay_mau) = @Nam";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaHD", maHD },
                { "@Quy", quy },
                { "@Nam", nam }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters, false);
            return Convert.ToInt32(result) > 0;
        }
        public string GetMaHopDongByDonHang(string maDH)
        {
            string query = "SELECT ma_hop_dong FROM DonHang WHERE ma_don_hang = @MaDH";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaDH", maDH }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters, false);
            return result?.ToString() ?? string.Empty;
        }
        public int GetQuyByDonHang(string maDH)
        {
            string query = "SELECT quy FROM DonHang WHERE ma_don_hang = @MaDH";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaDH", maDH }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters, false);
            return Convert.ToInt32(result);
        }
        public string GenerateMaDonHang()
        {
            try
            {
                return DataProvider.Instance.ExecuteProcedureWithOutput("USP_GenerateMaDonHang", null, "@NewMaDonHang")?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public bool UpdateDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            string query = "EXEC USP_UpdateDonHang @MaDH, @MaHD, @NgayLM, @NgayKQ, @Quy, @TrangThai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH, maHD, ngayLM, ngayKQ, quy, trangThai });
            return result < 0;
        }

        public bool DeleteDonHang(string maDH)
        {
            string query = "EXEC USP_DeleteDonHang @MaDH";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH });
            return result < 0;
        }
        public DataTable GetOrderStatusCounts(int quy, int nam)
        {
            string query = "USP_GetOrderStatusCounts";
            object[] parameters = { quy, nam };
            return DataProvider.Instance.ExecuteQuery(query, parameters, true);
        }
        public DataTable GetOrderStatusCountsByDot(int dot, int nam)
        {
            string query = "USP_GetOrderStatusCountsByDot";
            object[] parameters = { dot, nam };
            return DataProvider.Instance.ExecuteQuery(query, parameters, true);
        }
        public DataTable GetOrderListByStatusAndQuy(string status, int quy, int nam)
        {
            return DataProvider.Instance.ExecuteQuery("USP_GetOrderListByStatusAndQuy", new object[] { status, quy, nam }, true);
        }

        public DataTable GetOrderListByStatusAndDot(string status, int dot, int nam)
        {
            return DataProvider.Instance.ExecuteQuery("USP_GetOrderListByStatusAndDot", new object[] { status, dot, nam }, true);
        }
        public DataTable GetYears()
        {
            string query = "SELECT DISTINCT YEAR(ngay_bat_dau_lay_mau) AS Year FROM DonHang ORDER BY Year DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool SetStatus(string maDonHang, string trangThai)
        {
            string query = "EXEC USP_UpdateTrangThaiDonHang @ma_don_hang, @trang_thai";
            object[] parameters = { maDonHang, trangThai };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result < 0;
        }
    }
}