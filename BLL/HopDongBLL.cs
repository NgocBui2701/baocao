using baocao.DAO;
using baocao.DTO;

namespace baocao.BLL
{
    public class HopDongBLL
    {
        private static HopDongBLL instance;
        private HopDongDAO hopDongDAO;
        public static HopDongBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HopDongBLL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public HopDongBLL()
        {
            hopDongDAO = new HopDongDAO();
        }
        public List<HopDong> LoadData()
        {
            return HopDongDAO.Instance.LoadData();
        }
        public List<HopDong> SearchHopDong(string keyword)
        {
            return HopDongDAO.Instance.SearchHopDong(keyword);
        }
        public bool InsertHopDong(string maHD, string maCT, DateTime ngayHD)
        {
            if (!HopDongDAO.Instance.CheckMaCongTyExists(maCT))
            {
                throw new ArgumentException("Mã công ty không tồn tại.");
            }
            return HopDongDAO.Instance.InsertHopDong(maHD, maCT, ngayHD);
        }
        public bool UpdateHopDong(string maHD, string maCT, DateTime ngayHD)
        {
            if (!HopDongDAO.Instance.CheckMaCongTyExists(maCT))
            {
                throw new ArgumentException("Mã công ty không tồn tại.");
            }
            return HopDongDAO.Instance.UpdateHopDong(maHD, maCT, ngayHD);
        }
        public bool DeleteHopDong(string maHD)
        {
            return HopDongDAO.Instance.DeleteHopDong(maHD);
        }
        public string GenerateMaHopDong()
        {
            return HopDongDAO.Instance.GenerateMaHopDong();
        }
        public List<string> GetAllMaHopDong()
        {
            return HopDongDAO.Instance.GetAllMaHopDong();
        }
    }
}
