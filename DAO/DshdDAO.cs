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
    public class DshdDAO
    {
        private static DshdDAO instance;
        public static DshdDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DshdDAO();
                return DshdDAO.instance;
            }
            private set
            {
                DshdDAO.instance = value;
            }
        }
        private DshdDAO() { }
        public List<Dshd> loadData()
        {
            List<Dshd> list = new List<Dshd>();
            string query = "USP_GetDshdList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { 100 }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    Dshd dshd = new Dshd(row);
                    list.Add(dshd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public List<Dshd> searchDshd(string keyword)
        {
            List<Dshd> list = new List<Dshd>();
            string query = "USP_SearchDshd";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    Dshd dshd = new Dshd(row);
                    list.Add(dshd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine($"Lỗi SQL: {ex}");
                    Console.WriteLine($"Lỗi SQL: {ex}");
                }
            }
            return list;
        }
        public bool insertDshd(string maHD, string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            string query = "EXEC USP_InsertDshd @MaHD, @MaCT, @TenCT, @KyHieuCT, @NgayHD, @TenDaiDien, @Sdt, @DiaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, tenCT, kyHieuCT, ngayHD, tenDaiDien, sdt, diaChi });
            loadData();
            return result < 0;
        }
        public bool updateDshd(string maHD, string maCT, string tenCT, string kyHieuCT, string ngayHD, string tenDaiDien, string sdt, string diaChi)
        {
            string query = "EXEC USP_UpdateDshd @MaHD, @MaCT, @TenCT, @KyHieuCT, @NgayHD, @TenDaiDien, @Sdt, @DiaChi";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maCT, tenCT, kyHieuCT, ngayHD, tenDaiDien, sdt, diaChi });
            loadData();
            return result < 0;
        }
        public bool deleteDshd(string maHD)
        {
            string query = "EXEC USP_DeleteDshd @MaHD";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD });
            loadData();
            return result < 0;
        }
        

    }
}
