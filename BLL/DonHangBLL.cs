using System.Data;
using baocao.DAO;
using baocao.DTO;
using baocao.GUI;
using baocao.GUI.Managers;

namespace baocao.BLL
{
    public class DonHangBLL
    {
        private static DonHangBLL instance;
        private DonHangDAO donHangDAO;
        public static DonHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonHangBLL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public DonHangBLL()
        {
            donHangDAO = new DonHangDAO();
        }
        public List<DonHang> LoadData()
        {
            List<DonHang> list = DonHangDAO.Instance.LoadData();
            foreach (var dh in list)
            {
                if (dh.Trangthai != "Hoàn thành")
                {
                    if (dh.NgayKQ < DateTime.Now)
                    {
                        dh.Trangthai = "Quá hạn";
                    }
                    else
                    {
                        dh.Trangthai = "Đang xử lý";
                    }
                    DonHangDAO.Instance.SetStatus(dh.MaDH, dh.Trangthai);
                }
            }
            return DonHangDAO.Instance.LoadData();
        }
        public List<DonHang> SearchDonHang(string keyword)
        {
            return DonHangDAO.Instance.SearchDonHang(keyword);
        }
        public bool InsertDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            if (ngayLM > ngayKQ)
            {
                throw new ArgumentException("Ngày bắt đầu lấy mẫu không thể sau ngày trả kết quả.");
            }
            if (DonHangDAO.Instance.CheckDuplicateDonHang(maHD, quy, ngayLM.Year))
            {
                throw new ArgumentException("Hợp đồng này đã có đơn hàng trong quý này.");
            }
            return DonHangDAO.Instance.InsertDonHang(maHD, maDH, ngayLM, ngayKQ, quy, trangThai);
        }
        public bool UpdateDonHang(string maHD, string maDH, DateTime ngayLM, DateTime ngayKQ, int quy, string trangThai)
        {
            if (ngayLM > ngayKQ)
            {
                throw new ArgumentException("Ngày bắt đầu lấy mẫu không thể sau ngày trả kết quả.");
            }
            string maHDCu = DonHangDAO.Instance.GetMaHopDongByDonHang(maDH);
            int quyCu = DonHangDAO.Instance.GetQuyByDonHang(maDH);
            if (DonHangDAO.Instance.CheckDuplicateDonHang(maHD, quy, ngayLM.Year) && ((maHDCu != null && !maHDCu.Equals(maHD)) || (quyCu != null && quyCu != quy)) )
            {
                throw new ArgumentException("Hợp đồng này đã có đơn hàng trong quý này.");
            }
            return DonHangDAO.Instance.UpdateDonHang(maHD, maDH, ngayLM, ngayKQ, quy, trangThai);
        }
        public bool DeleteDonHang(string maDH)
        {
            return DonHangDAO.Instance.DeleteDonHang(maDH);
        }
        public string GenerateMaDonHang()
        {
            return DonHangDAO.Instance.GenerateMaDonHang();
        }
        public DataTable GetOrderStatusCounts(int quy, int nam)
        {
            return donHangDAO.GetOrderStatusCounts(quy, nam);
        }
        public DataTable GetOrderStatucCountsByDot(int dot, int nam)
        {
            return donHangDAO.GetOrderStatusCountsByDot(dot, nam);
        }
        public DataTable GetOrderListByStatusAndQuy(string status, int quy, int nam)
        {
            return donHangDAO.GetOrderListByStatusAndQuy(status, quy, nam);
        }
        public DataTable GetOrderListByStatusAndDot(string status, int dot, int nam)
        {
            return donHangDAO.GetOrderListByStatusAndDot(status, dot, nam);
        }
        public DataTable GetYears()
        {
            return donHangDAO.GetYears();
        }
        public bool SetStatus(string maDonHang, string trangThai)
        {
            return DonHangDAO.Instance.SetStatus(maDonHang, trangThai);
        }
    }
}