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
    class LopDAL
    {
        public DataResponse<List<LOP>> GetListLopByNienKhoa(string nienKhoa)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<LOP>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.DS_LOP @nienKhoa";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nienKhoa", nienKhoa);
                var data = Program.conn.Query<LOP>(command, parameters).ToList();
                return new DataResponeSuccess<List<LOP>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<LOP>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
        public DataResponse<List<KHOAHOC>> GetListKhoaHoc()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<KHOAHOC>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.DS_KHOAHOC_LOP";
                var data = Program.conn.Query<KHOAHOC>(command).ToList();
                return new DataResponeSuccess<List<KHOAHOC>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<KHOAHOC>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<List<LOP>> GetListLop()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<LOP>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_LOPHOC";
                var data = Program.conn.Query<LOP>(command).ToList();
                return new DataResponeSuccess<List<LOP>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<LOP>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> UpdateLop(List<UPDATELOP> list)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "exec [dbo].[SP_UPDATE_Lop] @LOP";
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddTable("@LOP", "TYPE_NEWUPDATE_LOP", list);
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

        public DataResponse<bool> CheckLop(string malop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[KT_KHOANGOAI_LOP] (@MALOP)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MALOP", malop);
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

        public DataResponse<bool> CheckMaLopLop(string malop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[FUNC_KT_MALOP] (@MALOP)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MALOP", malop);
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

        public DataResponse<bool> CheckMaLopLopExistsByServer(string malop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[FUNC_KT_MALOP_EXISTSBYSERVER] (@MALOP)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MALOP", malop);
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
        public DataResponse<List<TongKetCuoiKhoa>> GetListTongKetCuoiKhoa(string malop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<TongKetCuoiKhoa>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_TONGKETCUOIKHOA @malop";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@malop", malop);

                var data = Program.conn.Query<TongKetCuoiKhoa>(command,parameters).ToList();
                return new DataResponeSuccess<List<TongKetCuoiKhoa>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<TongKetCuoiKhoa>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
