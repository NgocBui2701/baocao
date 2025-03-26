using Microsoft.Data.SqlClient;
using System.Data;
using baocao.DTO;

namespace baocao.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return AccountDAO.instance;
            }
            private set
            {
                AccountDAO.instance = value;
            }
        }
        public AccountDAO() { }
        public bool Login(string userName, string passWord)
        {
<<<<<<< HEAD:DAO/AccountDAO.cs
            try
            {
                string query = "USP_Login";
                return DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord }, true).Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
=======
            string query = "USP_Login @userName , @passWord";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord }).Rows.Count > 0;
>>>>>>> parent of 15cbd76 (sql):DAL/AccountDAO.cs
        }
        public Account GetAccountByUsername(string username)
        {
            string query = "USP_GetAccountByUsername @username";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
<<<<<<< HEAD:DAO/AccountDAO.cs
        public bool UpdateOwnAccount(string username, string id, string name, string email, string phone, string password, string newPassword)
        {
            try
            {
                string query = "EXEC USP_UpdateOwnAccount @username, @ID, @name, @email, @sdt, @password, @newPassword";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, id, name, email, phone, password, newPassword });
                return result < 0;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Email hoặc số điện thoại đã tồn tại, vui lòng nhập lại!");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<Account> LoadData()
        {
            List<Account> list = new List<Account>();
            string query = "USP_GetAccountList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { }, true);
            if (data == null || data.Rows.Count == 0)
            {
                return new List<Account>();
            }
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    Account account = new Account(row);
                    list.Add(account);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public List<Account> SearchAccount(string keyword)
        {
            List<Account> list = new List<Account>();
            string query = "USP_SearchAccount";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword }, true);
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    Account account = new Account(row);
                    list.Add(account);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Có lỗi xảy ra");
                }
            }
            return list;
        }
        public string GenerateMaNguoiDung()
        {
            try
            {
                return DataProvider.Instance.ExecuteProcedureWithOutput("USP_GenerateMaNguoiDung", null, "@NewMaNguoiDung")?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra");
                return string.Empty;
            }
        }
        public bool InsertAccount(string ma_nguoi_dung, string ten, string vai_tro, string ten_dang_nhap, string email, string sdt)
        {
            if (IsExists(ten_dang_nhap, email, sdt))
            {
                MessageBox.Show("Tên đăng nhập, Email hoặc số điện thoại đã tồn tại!");
                return false;
            }
            try
            {
                string query = "EXEC USP_InsertAccount @MaNguoiDung, @Ten, @VaiTro, @TenDangNhap, @Email, @Sdt";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, email, sdt });
                LoadData();
                return result < 0;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Tên đăng nhập, email hoặc số điện thoại đã tồn tại, vui lòng nhập lại!");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateAccount(string ma_nguoi_dung, string ten, string vai_tro, string ten_dang_nhap, string email, string sdt)
        {
            if (IsExists(ten_dang_nhap, email, sdt))
            {
                MessageBox.Show("Tên đăng nhập, Email hoặc số điện thoại đã tồn tại!");
                return false;
            }
            try
            {
                string query = "EXEC USP_UpdateAccount @MaNguoiDung, @Ten, @VaiTro, @TenDangNhap, @Email, @Sdt";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, email, sdt });
                LoadData();
                return result < 0;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Tên đăng nhập, email hoặc số điện thoại đã tồn tại, vui lòng nhập lại!");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool DeleteAccount(string ma_nguoi_dung)
        {
            string query = "EXEC USP_DeleteAccount @MaNguoiDung";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma_nguoi_dung });
            LoadData();
            return result < 0;
        }
        public bool IsExists(string ten_dang_nhap, string email, string sdt)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE ten_dang_nhap = @TenDangNhap OR email = @Email OR sdt = @Sdt";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", ten_dang_nhap },
                { "@Email", email },
                { "@Sdt", sdt }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
=======
>>>>>>> parent of 15cbd76 (sql):DAL/AccountDAO.cs
    }
}
