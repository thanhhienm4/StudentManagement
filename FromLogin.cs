using StudentManagement.Model;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FromLogin : Form
    {
        private static string serverName { get; set; }
        public FromLogin()
        {
            InitializeComponent();
            Load();
        }
        
        void Load()
        {
            SupportConnectionDAL connectionDAL = new SupportConnectionDAL();
            cbx.DataSource = connectionDAL.GetSubscripton();
            cbx.DisplayMember = "TENCN";
            cbx.ValueMember = "TENSERVER";

            
        }
       
        private void lbUsername_Click(object sender, EventArgs e)
        {

        }

        private void cbx_SelectedValueChanged(object sender, EventArgs e)
        {

           Program.serverName = (cbx.SelectedItem as DataRowView).Row["TENSERVER"] as string;
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text;

            Program.login = login;
            Program.password = password;
            
            if(!BaseDAl.Connect())
            {
                lbMessage.Text = "Lỗi đăng nhập";
            }

            string loginCommand = String.Format("exec[dbo].[SP_DANGNHAP] '{0}'", login);
            var dataResponse = BaseDAl.GetData(loginCommand);

            if(dataResponse.Response.State == ResponseState.Success)
            {
                lbMessage.Text = "Đăng nhập thành công";
            }else
            {
                lbMessage.Text = "Lỗi hệ thống";
            }    
            
        }
    }
}
