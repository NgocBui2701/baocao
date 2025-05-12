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
    public class HopDongDAO
    {
        private static HopDongDAO instance;
        public static HopDongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HopDongDAO();
                return HopDongDAO.instance;
            }
            private set
            {
                HopDongDAO.instance = value;
            }
        }
        public HopDongDAO() { }
        public List<HopDong> LoadData()
        {
            List<HopDong> list = new List<HopDong>();
            string query = "USP_GetHopDongList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    HopDong HopDong = new HopDong(row);
                    list.Add(HopDong);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public List<HopDong> SearchHopDong(string keyword)
        {
            List<HopDong> list = new List<HopDong>();
            string query = "USP_SearchHopDong";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    HopDong HopDong = new HopDong(row);
                    list.Add(HopDong);
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
        public bool InsertHopDong(string maHD, string maCT, DateTime ngayHD)
        {
            string query = "EXEC USP_InsertHopDong @MaHD, @MaCT, @NgayHD";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, ngayHD });
            LoadData();
            return result < 0;
        }
        public bool CheckMaCongTyExists(string maCT)
        {
            string query = "SELECT COUNT(*) FROM CongTy WHERE ma_cong_ty = @MaCT";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaCT", maCT }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters, false);
            return Convert.ToInt32(result) > 0;
        }
        public string GenerateMaHopDong()
        {
            try
            {
                return DataProvider.Instance.ExecuteProcedureWithOutput("USP_GenerateMaHopDong", null, "@NewMaHopDong")?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        public bool UpdateHopDong(string maHD, string maCT, DateTime ngayHD)
        {
            string query = "EXEC USP_UpdateHopDong @MaHD, @MaCT, @NgayHD";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, ngayHD });
            LoadData();
            return result < 0;
        }
        public bool DeleteHopDong(string maHD)
        {
            try
            {
                string query = "EXEC USP_DeleteHopDong @MaHD";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD });
                LoadData();
                return result < 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi xóa hợp đồng: hợp đồng đã phát sinh đơn hàng, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

    }
}
