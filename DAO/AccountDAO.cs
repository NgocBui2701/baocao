using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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

        private AccountDAO() { }
        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord }, true).Rows.Count > 0;
        }
        public Account GetAccountByUsername(string username)
        {
            string query = "USP_GetAccountByUsername";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username }, true);
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string username, string id, string name, string email, string phone, string password, string newPassword)
        {
            string query = "EXEC USP_UpdateAccount @username, @ID, @name, @email, @sdt, @password, @newPassword";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {username, id, name, email, phone, password, newPassword });
            return result > 0;
        }
    }
}
