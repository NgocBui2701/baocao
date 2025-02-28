using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace baocao.DAO
{
    internal class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private string connStr = "Data Source=.\\mssqlserver01;Initial Catalog=QUAN_LY_DON_HANG_MOI_TRUONG;Integrated Security=True; TrustServerCertificate=True;";

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameters = null, bool isStoredProc = false)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (isStoredProc)
                {
                    command.CommandType = CommandType.StoredProcedure; // Chạy như một PROC
                }

                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] paremeter)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paremeter != null)
                {
                    string[] listParemeter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParemeter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paremeter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] paremeter)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paremeter != null)
                {
                    string[] listParemeter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParemeter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paremeter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
