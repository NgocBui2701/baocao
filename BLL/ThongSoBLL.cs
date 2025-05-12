using System.Collections.Generic;
using System.Data;
using baocao.DAO;
using baocao.DTO;

namespace baocao.BLL
{
    public class ThongSoBLL
    {
        private static ThongSoBLL instance;
        public static ThongSoBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongSoBLL();
                return instance;
            }
        }
        private ThongSoBLL() { }
        public List<ThongSo> GetKetQuaList(string maDonHang, string maViTri)
        {
            return ThongSoDAO.Instance.GetKetQuaList(maDonHang, maViTri);
        }
        public List<ThongSo> GetThongSoByLoaiViTri(string loaiViTri)
        {
            return ThongSoDAO.Instance.GetThongSoByLoaiViTri(loaiViTri);
        }
        public DataTable GetNguoiDungByVaiTro(string vaiTro)
        {
            return ThongSoDAO.Instance.GetNguoiDungByVaiTro(vaiTro);
        }
        public bool InsertKetQua(KetQua ketQua)
        {
            return ThongSoDAO.Instance.InsertKetQuaDefault(ketQua);
        }
        public bool InsertOrUpdateKetQua(KetQua ketQua, string loaiViTri, string tenThongSo, string donVi, string giaTriQuyChuanTCVN, string maThongSoCu)
        {
            return ThongSoDAO.Instance.InsertOrUpdateKetQua(ketQua, loaiViTri, tenThongSo, donVi, giaTriQuyChuanTCVN, maThongSoCu);
        }
        public bool DeleteKetQua(string maHopDong, string maDonHang, string maViTri, string maThongSo)
        {
            return ThongSoDAO.Instance.DeleteKetQua(maHopDong, maDonHang, maViTri, maThongSo);
        }
        public List<ThongSo> GetCombinedThongSoByDieuKien(string maViTri, string maHopDong, string maDonHang, string loaiViTri, int currentQuy)
        {
            return ThongSoDAO.Instance.GetCombinedThongSo(maViTri, maHopDong, maDonHang, loaiViTri, currentQuy);
        }
    }
}
