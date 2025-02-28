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
            string query = "USP_Login @userName , @passWord";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord }).Rows.Count > 0;
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
    }
}
