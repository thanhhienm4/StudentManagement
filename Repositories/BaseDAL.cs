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
    public class BaseDAl
    {


        public static bool Connect()
        {
            try
            {
                if(Program.currentServer == Program.serverName)
                {
                    Program.conmStr =
                    String.Format("Data Source={0} ;Database=QLDSV_TC ;Persist Security Info=True;User ID={1}; password={2}",
                                    Program.serverName, Program.login, Program.password);
                }else
                {
                    // user remote serversql
                    Program.conmStr =
                    String.Format("Data Source={0} ;Database=QLDSV_TC ;Persist Security Info=True;User ID={1}; password={2}",
                                    Program.currentServer, Program.loginRemote, Program.passwordRemote);
                }
                
                
                //if(Program.conn == null)
                Program.conn = new SqlConnection(Program.conmStr);

                if (Program.conn.State != ConnectionState.Closed)
                    Program.conn.Close();

                if (Program.conn.State != ConnectionState.Open)
                    Program.conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static void DisConnect()
        {
            if (Program.conn == null)
                return;
            if (Program.conn.State != ConnectionState.Closed)
                Program.conn.Close();
        }




        public static DataResponse <DataTable> GetDataTable(string command )
        {          
            try
            {
               
                SqlCommand sqlCommand = new SqlCommand(command, Program.conn);
                sqlCommand.CommandTimeout = 60;
                sqlCommand.CommandType = CommandType.Text;
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

            }finally
            {
                //if (Program.conn.State != ConnectionState.Closed)
                //    Program.conn.Close();
            }
        }
        public static DataResponse<SqlDataReader> GetDataReader(string command)
        {

            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                SqlCommand sqlCommand = new SqlCommand(command, Program.conn);
                sqlCommand.CommandTimeout = 60;
                sqlCommand.CommandType = CommandType.Text;

                var reader  = sqlCommand.ExecuteReader();


                return new DataResponse<SqlDataReader>()
                {
                    Response = new Response()
                    {

                        State = ResponseState.Success,
                        Message = ""
                    },
                    Data = reader
                };
            }
            catch (Exception e)
            {
                return new DataResponse<SqlDataReader>()
                {
                    Response = new Response()
                    {
                        State = ResponseState.Fail,
                        Message = e.Message
                    }
                };

            }
            finally
            {
                //if (Program.conn.State != ConnectionState.Closed)
                //    Program.conn.Close();
            }
        }

    }
}
