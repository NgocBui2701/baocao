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
            if (AccountDAO.Instance.IsUsernameExists(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!");
                return false;
            }
            if (AccountDAO.Instance.IsEmailExists(email))
            {
                MessageBox.Show("Email đã tồn tại, vui lòng nhập email khác!");
                return false;
            }
            if (AccountDAO.Instance.IsPhoneExists(sdt))
            {
                MessageBox.Show("Số điện thoại đã tồn tại, vui lòng nhập số khác!");
                return false;
            }
            return AccountDAO.Instance.InsertAccount(maND, hoTen, vaiTro, tenDangNhap, email, sdt);
        }

        public bool UpdateAccount(string maND, string hoTen, string vaiTro, string tenDangNhap, string email, string sdt)
        {
            var currentAccount = AccountDAO.Instance.GetAccountByUsername(tenDangNhap);
            if (currentAccount == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!");
                return false;
            }
            if (!currentAccount.TenDangNhap.Equals(tenDangNhap, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsUsernameExists(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!");
                return false;
            }
            if (!currentAccount.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsEmailExists(email))
            {
                MessageBox.Show("Email đã tồn tại, vui lòng nhập email khác!");
                return false;
            }
            if (!currentAccount.Sdt.Equals(sdt, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsPhoneExists(sdt))
            {
                MessageBox.Show("Số điện thoại đã tồn tại, vui lòng nhập số khác!");
                return false;
            }
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
            var currentAccount = AccountDAO.Instance.GetAccountByUsername(username);
            if (currentAccount == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!");
                return false;
            }
            if (!currentAccount.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsUsernameExists(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!");
                return false;
            }
            if (!currentAccount.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsEmailExists(email))
            {
                MessageBox.Show("Email đã tồn tại, vui lòng nhập email khác!");
                return false;
            }
            if (!currentAccount.Sdt.Equals(phone, StringComparison.OrdinalIgnoreCase)
                && AccountDAO.Instance.IsPhoneExists(phone))
            {
                MessageBox.Show("Số điện thoại đã tồn tại, vui lòng nhập số khác!");
                return false;
            }
            return AccountDAO.Instance.UpdateOwnAccount(username, id, name, email, phone, password, newPassword);
        }
        public bool IsEmailExist(string email)
        {
            return AccountDAO.Instance.IsEmailExist(email);
        }
        public bool ResetPassword(string email, string newPass)
        {
            return AccountDAO.Instance.ResetPassword(email, newPass);
        }
    }
}
