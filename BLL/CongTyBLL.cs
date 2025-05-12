using baocao.DAO;
using baocao.DTO;

namespace baocao.BLL
{
    public class CongTyBLL
    {
        private static CongTyBLL instance;
        public static CongTyBLL Instance
        {
            get { if (instance == null) instance = new CongTyBLL(); return instance; }
            private set { instance = value; }
        }
        private CongTyBLL() { }
        public List<CongTy> LoadData()
        {
            return CongTyDAO.Instance.LoadData();
        }
        public List<CongTy> SearchCongTy(string keyword)
        {
            return CongTyDAO.Instance.SearchCongTy(keyword);
        }
        public bool InsertCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            return CongTyDAO.Instance.InsertCongTy(maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi);
        }
        public bool UpdateCongTy(string maCT, string tenCT, string kyHieuCT, string tenDaiDien, string sdt, string diaChi)
        {
            return CongTyDAO.Instance.UpdateCongTy(maCT, tenCT, kyHieuCT, tenDaiDien, sdt, diaChi);
        }
        public bool DeleteCongTy(string maCT)
        {
            return CongTyDAO.Instance.DeleteCongTy(maCT);
        }
        public List<string> GetAllTenCongTy()
        {
            return CongTyDAO.Instance.GetAllTenCongTy();
        }
        public CongTy GetCongTyByTenCongTy(string tenCT)
        {
            return CongTyDAO.Instance.GetCongTyByTenCongTy(tenCT);
        }
    }
}