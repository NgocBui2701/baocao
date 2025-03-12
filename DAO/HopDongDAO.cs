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
        private HopDongDAO() { }
        public List<HopDong> loadData()
        {
            List<HopDong> list = new List<HopDong>();
            string query = "USP_GetHopDongList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { 100 }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    HopDong HopDong = new HopDong(row);
                    list.Add(HopDong);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public List<HopDong> searchHopDong(string keyword)
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
        public bool insertHopDong(string maHD, string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            string query = "EXEC USP_InsertHopDong @MaHD, @MaCT, @TenCT, @KyHieuCT, @NgayHD, @TenDaiDien, @Sdt, @DiaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, tenCT, kyHieuCT, ngayHD, tenDaiDien, sdt, diaChi });
            loadData();
            return result < 0;
        }
        public bool updateHopDong(string maHD, string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            string query = "EXEC USP_UpdateHopDong @MaHD, @MaCT, @TenCT, @KyHieuCT, @NgayHD, @TenDaiDien, @Sdt, @DiaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, tenCT, kyHieuCT, ngayHD, tenDaiDien, sdt, diaChi });
            loadData();
            return result < 0;
        }
        public bool deleteHopDong(string maHD)
        {
            string query = "EXEC USP_DeleteHopDong @MaHD";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD });
            loadData();
            return result < 0;
        }
        

    }
}
