using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public class GiangVienDAL 
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
    }
}
