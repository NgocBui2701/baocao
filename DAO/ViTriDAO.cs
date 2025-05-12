using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baocao.DTO;

namespace baocao.DAO
{
    internal class ViTriDAO
    {
        private static ViTriDAO instance;
        public static ViTriDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViTriDAO();
                }
                return instance;
            }
        }

        private ViTriDAO() { }
        public List<ViTriLayMau> GetViTriByMaHD(string maHD)
        {
            string query = "USP_GetViTriByMaHD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maHD }, true);

            List<ViTriLayMau> danhSachViTri = new List<ViTriLayMau>();
            foreach (DataRow row in data.Rows)
            {
                danhSachViTri.Add(new ViTriLayMau(row));
            }
            return danhSachViTri;
        }
        public List<ViTriLayMau> GetViTriByMaDH(string maDH)
        {
            string query = "USP_GetViTriByMaDH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maDH }, true);

            List<ViTriLayMau> danhSachViTri = new List<ViTriLayMau>();
            foreach (DataRow row in data.Rows)
            {
                danhSachViTri.Add(new ViTriLayMau(row));
            }
            return danhSachViTri;
        }
        public bool InsertViTri(string maVT, string maHD, string maDH, string tenVT, string loaiVT)
        {
            string query = "EXEC USP_InsertViTri @MaVT, @MaHD, @MaDH, @TenVT, @LoaiVT";
            object[] parameters = { maVT, maHD, maDH, tenVT, loaiVT };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) < 0;
        }
        public bool UpdateTenViTri(string maHD, string maDH, string maVT, string newName)
        {
            string query = "EXEC USP_UpdateTenViTri @maHD , @maDH , @maVT , @newName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maDH, maVT, newName });
            return result < 0;
        }
        public bool DeleteViTri(string maVT, string maHD, string maDH)
        {
            string query = "EXEC USP_DeleteViTri @MaVT, @MaHD, @MaDH";
            object[] parameters = { maVT, maHD, maDH };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) < 0;
        }
        public bool CheckViTriExists(string maViTri, string maHD, string maDH)
        {
            string query = "USP_CheckViTriExists";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@maViTri", maViTri },
                { "@maHD", maHD },
                { "@maDH", maDH }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters, true);
            return result != null && Convert.ToInt32(result) > 0;
        }

    }
}
