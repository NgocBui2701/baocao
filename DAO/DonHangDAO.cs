using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baocao.DTO;
using Microsoft.VisualBasic.Devices;

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
        private DonHangDAO() { }
        public List<DonHang> loadData()
        {
            List<DonHang> list = new List<DonHang>();
            string query = "USP_GetDonHangList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    DonHang DonHang = new DonHang(row);
                    list.Add(DonHang);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public List<DonHang> searchDonHang(string keyword)
        {
            List<DonHang> list = new List<DonHang>();
            string query = "USP_SearchDonHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    DonHang DonHang = new DonHang(row);
                    list.Add(DonHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return list;
        }
        public List<string> GetAllMaHopDong()
        {
            List<string> list = new List<string>();
            string query = "SELECT ma_hop_dong FROM HopDong";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(row["ma_hop_dong"].ToString());
            }

            return list;
        }
        public bool insertDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            string query = "EXEC USP_InsertDonHang @MaDH, @MaHD, @NgayLM, @NgayKQ, @Quy, @TrangThai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH, maHD, ngayLM, ngayKQ, quy, trangThai });
            loadData();
            return result < 0;
        }
        public bool CheckMaHopDongExists(string maHD)
        {
            string query = "SELECT COUNT(*) FROM HopDong WHERE ma_hop_dong = @MaHD";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@MaHD", maHD }
    };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters, false);

            return Convert.ToInt32(result) > 0;
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

        public bool updateDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            string query = "EXEC USP_UpdateDonHang @MaDH, @MaHD, @NgayLM, @NgayKQ, @Quy, @TrangThai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH, maHD, ngayLM, ngayKQ, quy, trangThai });
            loadData();
            return result < 0;
        }
        public bool deleteDonHang(string maDH)
        {
            string query = "EXEC USP_DeleteDonHang @MaDH";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDH });
            loadData();
            return result < 0;
        }
    }
}
