using StudentManagement.Model;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormLogin : Form
    {
        private static string serverName { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            Initial();
        }
        void Initial()
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
                return;
            }

            string loginCommand = String.Format("exec[dbo].[SP_DANGNHAP] '{0}'", login);
            var dataResponse = BaseDAl.GetDataReader(loginCommand);

            if(dataResponse.Response.State == ResponseState.Success && dataResponse.Data.Read())
            {
                lbMessage.Text = "Đăng nhập thành công";

                Program.username = dataResponse.Data.GetString(0);
                Program.fullName = dataResponse.Data.GetString(1);
                Program.group = dataResponse.Data.GetString(2);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lbMessage.Text = "Lỗi hệ thống";
            }    
            
        }
    }
}
