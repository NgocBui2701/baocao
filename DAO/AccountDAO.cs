using Microsoft.Data.SqlClient;
using System.Data;
using baocao.DTO;
using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

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
            try
            {
                string hashPassword = HashPassword(passWord);
                string query = "USP_Login";
                return DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPassword }, true).Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public Account GetAccountByUsername(string username)
        {
            try
            {
                string query = "USP_GetAccountByUsername";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username }, true);
                foreach (DataRow item in data.Rows)
                {
                    return new Account(item);
                }
                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public bool UpdateOwnAccount(string username, string id, string name, string email, string phone, string password, string newPassword)
        {
            try
            {
                if(!email.Contains("@") || !email.Contains("mail."))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return false;
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    if (!phone.All(char.IsDigit) || (phone.Length != 10 && phone.Length != 11))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ");
                        return false;
                    }
                }
                string hashNewPassword;
                if (!newPassword.IsNullOrEmpty())
                {
                    hashNewPassword = HashPassword(newPassword);
                }
                else
                {
                    hashNewPassword = "";
                }
                string hashPassword = HashPassword(password); 
                var currentAccount = GetAccountByUsername(username);
                if (hashPassword != currentAccount.MatKhau)
                {
                    MessageBox.Show("Mật khẩu không đúng, vui lòng nhập lại!");
                    return false;
                }
                string query = "EXEC USP_UpdateOwnAccount @username, @ID, @name, @email, @sdt, @password, @newPassword";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, id, name, email, phone, hashPassword, hashNewPassword });
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
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        public bool InsertAccount(string ma_nguoi_dung, string ten, string vai_tro, string ten_dang_nhap, string email, string sdt)
        {
            try
            {
                if (!email.Contains("@") || !email.Contains("mail."))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return false;
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    if (!sdt.All(char.IsDigit) || (sdt.Length != 10 && sdt.Length != 11))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ");
                        return false;
                    }
                }
                string hashPassword = HashPassword("12345678");
                string query = "EXEC USP_InsertAccount @MaNguoiDung, @Ten, @VaiTro, @TenDangNhap, @Email, @Sdt, @MatKhau";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, email, sdt, hashPassword });
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
            try
            {
                if (!email.Contains("@") || !email.Contains("mail."))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return false;
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    if (!sdt.All(char.IsDigit) || (sdt.Length != 10 && sdt.Length != 11))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ");
                        return false;
                    }
                }
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
        public bool IsEmailExist(string email)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE email = @Email";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Email", email }
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
        public bool ResetPassword(string email, string newPassword)
        {
            try
            {
                string hashedPassword = HashPassword(newPassword);

                string query = "UPDATE NGUOIDUNG SET mat_khau = @password WHERE email = @email";
                object[] parameters = { hashedPassword, email };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE ten_dang_nhap = @TenDangNhap";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", username }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
        public bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE email = @Email";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Email", email }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
        public bool IsPhoneExists(string phone)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE sdt = @Sdt";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Sdt", phone }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}
