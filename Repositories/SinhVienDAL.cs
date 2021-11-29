using Dapper;
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
    }
}
