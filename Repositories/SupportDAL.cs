using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
namespace StudentManagement.Repositories
{

    public class SupportDAL
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["SupportConnection"].ConnectionString;
        private SqlConnection conn = new SqlConnection(connStr);
        public DataTable GetSubscripton()
        {
            try
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

            }catch(Exception)
            {
                return new DataTable();
            }
    
        }
        public List<ServerInfo> GetListPhanManh()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec SP_DS_PhanManh";
                List<ServerInfo> servers = conn.Query<ServerInfo>(command).ToList();
                return servers;
                
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }

}