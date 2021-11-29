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
    public class SinhVienDAL:BaseDAl
    {
        public DataResponse<List<SINHVIEN>> GetListSINHVIEN_LOPTINHCHI(string nienKhoa, int hocKy, string mamh, int nhom)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<SINHVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_SINHVEN_LOPTINCHI @nienKhoa, @hocKy, @mamh, @nhom";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nienKhoa", nienKhoa);
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@mamh", mamh);
                parameters.Add("@nhom", nhom);
                var data = Program.conn.Query<SINHVIEN>(command, parameters).ToList();
                return new DataResponeSuccess<List<SINHVIEN>>(data);
            }
            catch (Exception)
            {
                return new DataResponeFail<List<SINHVIEN>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<List<SINHVIEN>> GetListSinhVien()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<SINHVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_SINHVIEN";
                var data = Program.conn.Query<SINHVIEN>(command).ToList();
                return new DataResponeSuccess<List<SINHVIEN>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<SINHVIEN>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<List<SINHVIEN>> GetListSinhVienByLop(string idClass)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<SINHVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_SINHVIEN_BY_LOP @MALOP";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MALOP", idClass);
                var data = Program.conn.Query<SINHVIEN>(command, parameters).ToList();
                return new DataResponeSuccess<List<SINHVIEN>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<SINHVIEN>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> UpdateSinhVien(List<UPDATESINHVIEN> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_SINHVIEN] @SINHVIEN";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@SINHVIEN", "TYPE_NEWUPDATE_SINHVIEN", list);
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
        public DataResponse<bool> CheckSinhvien(string masv)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[func_KT_SINHVIEN_EXISTS] (@MASV)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MASV", masv);
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
