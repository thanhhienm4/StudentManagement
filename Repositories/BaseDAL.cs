using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public static class BaseDAl
    {


        public static bool Connect()
        {
            try
            {
                string connectionString =
                String.Format("Data Source={0} ;Database=QLDSV_TC ;Persist Security Info=True;User ID={1}; password={2}",
                                    Program.serverName, Program.login, Program.password);
                
                    Program.conn = new SqlConnection(connectionString);

                if(Program.conn.State != ConnectionState.Open)
                    Program.conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        public static DataResponse <DataTable> GetData(string command )
        {
           
            try
            {
                SqlCommand sqlCommand = new SqlCommand(command, Program.conn);
                sqlCommand.CommandTimeout = 60;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                

                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                return new DataResponse<DataTable>()
                {
                    Data = dt,
                    Response = new Response()
                    {
                        State = ResponseState.Success,
                        Message = ""
                    }
                };
            }catch(Exception e)
            {
                return new DataResponse<DataTable>()
                {
                    Response = new Response()
                    {
                        State = ResponseState.Fail,
                        Message = e.Message
                    }
                };
            }
           
        }
    }
}
