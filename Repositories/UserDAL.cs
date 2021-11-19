using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataResponse<bool> CreateLogin(string login, string pass, string user, string role)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối! Vui lòng kiểm tra lại mật khẩu");
            try
            {
                string command = "exec dbo.sp_taologin @login, @pass, @user , @role";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@login", login);
                parameters.Add("@pass", pass);
                parameters.Add("@user", user);
                parameters.Add("@role", role);

                parameters.Add("@res", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                Program.conn.Execute(command, parameters);
                var res = parameters.Get<int>("@res");

                switch(res)
                {
                    case 0: return new DataResponeSuccess<bool>(true);
                    case 1: return new DataResponeFail<bool>("Login name bị trùng");
                    case 2: return new DataResponeFail<bool>("User name bị trùng");
                    default:
                        return new DataResponeFail<bool>("Lỗi không xác đinh");

                }

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
