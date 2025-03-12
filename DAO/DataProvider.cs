using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (isStoredProc)
                        {
                            command.CommandType = CommandType.StoredProcedure;
                        }
                        if (parameters != null)
                        {
                            SqlCommandBuilder.DeriveParameters(command);
                            int paramIndex = 0;

                            foreach (SqlParameter param in command.Parameters)
                            {
                                if (param.ParameterName != "@RETURN_VALUE")
                                {
                                    param.Value = parameters[paramIndex] ?? DBNull.Value;
                                    paramIndex++;
                                }
                            }
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine($"Lỗi SQL: {ex}");
                    Console.WriteLine($"Lỗi SQL: {ex}");
                }
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        MatchCollection matches = Regex.Matches(query, @"@\w+");
                        if (matches.Count != parameters.Length)
                        {
                            throw new ArgumentException("Số lượng tham số không khớp với câu lệnh SQL.");
                        }

                        for (int i = 0; i < matches.Count; i++)
                        {
                            string paramName = matches[i].Value;
                            command.Parameters.AddWithValue(paramName, parameters[i] ?? DBNull.Value);
                        }
                    }

                    data = command.ExecuteNonQuery();
                }
            }
            return data;
        }
        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    data = command.ExecuteScalar();
                }
            }
            return data;
        }

        public object ExecuteProcedureWithOutput(string procName, Dictionary<string, object> inputParams, string outputParamName)
        {
            object outputValue = null;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào
                    if (inputParams != null)
                    {
                        foreach (var param in inputParams)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    // Thêm tham số OUTPUT
                    SqlParameter outputParam = new SqlParameter(outputParamName, SqlDbType.VarChar, 10);
                    outputParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    // Thực thi Stored Procedure
                    command.ExecuteNonQuery();

                    // Lấy giá trị OUTPUT
                    outputValue = outputParam.Value;
                }
            }
            return outputValue;
        }

    }
}
