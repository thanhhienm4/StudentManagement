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
    public class DangKyDAL : BaseDAl
    {
        public DataResponse<bool> UpdateDangKy(List<UpdateDangKy> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_DangKy] @DK";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@DK", "[dbo].[TYPE_UPDATE_DANGKY]", list);
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
        public DataResponse<List<LOPTINCHI>> GetListDangKyBySinhVien(string nienKhoa, int hocKy, string maSinhVien)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<LOPTINCHI>>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_DS_DANGKY_SINHVIEN] @nienKhoa , @hocKy , @maSV";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nienKhoa", nienKhoa);
                parameters.Add("@hocKy", hocKy);
                parameters.Add("maSV", maSinhVien);
                var res = Program.conn.Query<LOPTINCHI>(command, parameters).ToList();
                return new DataResponeSuccess<List<LOPTINCHI>>(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<LOPTINCHI>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
