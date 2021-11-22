using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public class MonHocDAL
    {
        public DataResponse<List<MONHOC>> GetListMonHoc()
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<MONHOC>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DS_MonHoc";
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
    }
}
