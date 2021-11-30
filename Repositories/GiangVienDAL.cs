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
    class GiangVienDAL
    {
        public DataResponse<List<GIANGVIEN>> GetListGiangVien()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<GIANGVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_GiangVien";
                DynamicParameters parameters = new DynamicParameters();
                var data = Program.conn.Query<GIANGVIEN>(command).ToList();
                return new DataResponeSuccess<List<GIANGVIEN>>(data);
            }
            catch (Exception)
            {
                return new DataResponeFail<List<GIANGVIEN>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<List<GIANGVIEN>> GetListAllGiangVien()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<GIANGVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_All_GiangVien";
                DynamicParameters parameters = new DynamicParameters();
                var data = Program.conn.Query<GIANGVIEN>(command).ToList();
                return new DataResponeSuccess<List<GIANGVIEN>>(data);
            }
            catch (Exception)
            {
                return new DataResponeFail<List<GIANGVIEN>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> UpdateGiangVien(List<UPDATEGIANGVIEN> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_GIANGVIEN] @GIANGVIEN";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@GIANGVIEN", "TYPE_NEWUPDATE_GIANGVIEN", list);
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

        public DataResponse<bool> CheckGiangVien(string magv)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[FUNC_KT_MAGV_KHOANGOAI] (@MAGV)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MAGV", magv);
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

        public DataResponse<List<KHOA>> GetListKhoa()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<KHOA>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_KHOA";
                DynamicParameters parameters = new DynamicParameters();
                var data = Program.conn.Query<KHOA>(command).ToList();
                return new DataResponeSuccess<List<KHOA>>(data);
            }
            catch (Exception)
            {
                return new DataResponeFail<List<KHOA>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
