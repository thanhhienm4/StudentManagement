using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagement.Repositories
{

    public class SupportConnectionDAL
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["SupportConnection"].ConnectionString;
        private SqlConnection conn = new SqlConnection(connStr);
        public DataTable GetSubscripton()
        {
            SqlCommand command = new SqlCommand("select * from V_DS_PHANMANH", conn);
            command.CommandTimeout = 60;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = command;
            conn.Open();
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            conn.Close();
            return dt;
            
        }
    }

}