using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    class HocPhiDAL
    {
        public DataResponse<List<SINHVIEN>> TestInfoSinhvien(string maSV)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<SINHVIEN>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_THONGTINSINHVIEN @masv";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
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
    }
}
