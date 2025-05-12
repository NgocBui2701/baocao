using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baocao.DTO;
using baocao.DAO;

namespace baocao.BLL
{
    internal class ViTriBLL
    {
        private static ViTriBLL instance;
        public static ViTriBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViTriBLL();
                }
                return instance;
            }
        }

        private ViTriBLL() { }
        public List<ViTriLayMau> GetViTriByMaHD(string maHD)
        {
            return ViTriDAO.Instance.GetViTriByMaHD(maHD);
        }
        public List<ViTriLayMau> GetViTriByMaDH(string maDH)
        {
            return ViTriDAO.Instance.GetViTriByMaDH(maDH);
        }
        public bool AddViTri(string maVT, string maHD, string maDH, string tenVT, string loaiVT)
        {
            if (string.IsNullOrEmpty(maVT) || string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maDH) || string.IsNullOrEmpty(tenVT) || string.IsNullOrEmpty(loaiVT))
            {
                return false;
            }

            return ViTriDAO.Instance.InsertViTri(maVT, maHD, maDH, tenVT, loaiVT);
        }
        public bool UpdateTenViTri(string maHD, string maDH, string maVT, string newName)
        {
            return ViTriDAO.Instance.UpdateTenViTri(maHD, maDH, maVT, newName);
        }
        public bool DeleteViTri(string maVT, string maHD, string maDH)
        {
            return ViTriDAO.Instance.DeleteViTri(maVT, maHD, maDH);
        }
        public bool CheckViTriExists(string maViTri, string maHD, string maDH)
        {
            return ViTriDAO.Instance.CheckViTriExists(maViTri, maHD, maDH);
        }
    }
}
