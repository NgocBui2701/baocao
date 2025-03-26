using baocao.DAO;
using baocao.DTO;

namespace baocao.BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;
        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set { instance = value; }
        }
        private AccountBLL() { }
        public List<Account> LoadData()
        {
            return AccountDAO.Instance.LoadData();
        }
        public List<Account> SearchAccount(string keyword)
        {
            return AccountDAO.Instance.SearchAccount(keyword);
        }
        public bool InsertAccount(string maND, string hoTen, string vaiTro, string tenDangNhap, string email, string sdt)
        {
            return AccountDAO.Instance.InsertAccount(maND, hoTen, vaiTro, tenDangNhap, email, sdt);
        }
        public bool UpdateAccount(string maND, string hoTen, string vaiTro, string tenDangNhap, string email, string sdt)
        {
            return AccountDAO.Instance.UpdateAccount(maND, hoTen, vaiTro, tenDangNhap, email, sdt);
        }
        public bool DeleteAccount(string maND)
        {
            return AccountDAO.Instance.DeleteAccount(maND);
        }
        public Account GetAccountByUsername(string username)
        {
            return AccountDAO.Instance.GetAccountByUsername(username);
        }
        public bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
        public string GenerateMaNguoiDung()
        {
            return AccountDAO.Instance.GenerateMaNguoiDung();
        }
        public bool UpdateOwnAccount(string username, string id, string name, string email, string phone, string password, string newPassword)
        {
            return AccountDAO.Instance.UpdateOwnAccount(username, id, name, email, phone, password, newPassword);
        }
    }
}
