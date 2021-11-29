using Dapper;
using DapperParameters;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    class MonHocDAL
    {
        public DataResponse<bool> UpdateMonHoc(List<UPDATEMONHOC> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_MONHOC] @MONHOC";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@MONHOC", "TYPE_NEWUPDATE_MONHOC", list);
                Program.conn.Execute(command, parameters);
                return new DataResponeSuccess<bool>(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<bool>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<List<MONHOC>> GetListMonHoc()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<MONHOC>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_GET_MONHOC";
                var data = Program.conn.Query<MONHOC>(command).ToList();
                return new DataResponeSuccess<List<MONHOC>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<MONHOC>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<bool> CheckMonHoc(string mamh)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[func_KT_MONHOC] (@MAMH)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MAMH", mamh);
                var res = Program.conn.ExecuteScalar<bool>(command, parameters);
                return new DataResponeSuccess<bool>(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<bool>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
