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
        public DataResponse<bool> UpdateDangKy(List<UpdateDangKy> list, string masv)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_DangKy] @DK, @masv";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@DK", "[dbo].[TYPE_UPDATE_DANGKY]", list);
                parameters.Add("@masv", masv);
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
        public DataResponse<List<DANGKY>> GetListDKByMALTC(int maltc)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<DANGKY>>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_DS_DANGKY_BY_MALTC] @maltc";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@maltc", maltc);
                var res = Program.conn.Query<DANGKY>(command, parameters).ToList();
                return new DataResponeSuccess<List<DANGKY>>(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<DANGKY>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<bool> UpdateDiem(List<UpdateGrade> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_DIEM] @DK";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@DK", "[dbo].[TYPE_UPDATE_DIEM]", list);
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
