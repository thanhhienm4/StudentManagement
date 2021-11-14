using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using StudentManagement.Model;
using DapperParameters;

namespace StudentManagement.Repositories
{
    public class LopTinChiDAL
    {
        public DataResponse<List<LOPTINCHI>> GetListLopTinChi(string nienKhoa, int hocKy)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<LOPTINCHI>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_LopTinChi @nienKhoa , @hocKy";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nienKhoa", nienKhoa);
                parameters.Add("@hocKy", hocKy);
                var data = Program.conn.Query<LOPTINCHI>(command, parameters).ToList();
                return new DataResponeSuccess<List<LOPTINCHI>>(data);
            }
            catch(Exception)
            {
                return new DataResponeFail<List<LOPTINCHI>>("Lỗi hệ thống");
            }finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> UpdateLopTinChi(List<UpdateLopTinChi> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_LopTinChi] @LTC";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@LTC","Type_NEWUpdate_LopTinChi",list);
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
    }
}
