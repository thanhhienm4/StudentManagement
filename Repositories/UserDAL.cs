using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public class UserDAL : BaseDAl
    {
        public DataResponse<UserInfo> Login(string login)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<UserInfo>("Lỗi kết nối! Vui lòng kiểm tra lại mật khẩu");
            try
            {
                string command = "exec dbo.SP_DANGNHAP @login";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@login", login);
                var data = Program.conn.Query<UserInfo>(command, parameters).FirstOrDefault();
                return new DataResponeSuccess<UserInfo>(data);
            }
            catch (Exception)
            {
                return new DataResponeFail<UserInfo>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
