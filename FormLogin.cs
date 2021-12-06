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
        private UserDAL userDAL { get; set; }
        public FormLogin()
        {

            InitializeComponent();
            Initial();
            userDAL = new UserDAL();
        }
        void Initial()
        {
            SupportDAL connectionDAL = new SupportDAL();
            cbx.DataSource = connectionDAL.GetListPhanManh();

            Program.servers = connectionDAL.GetListPhanManh().Where(x => x.TENCN.Trim() != "PHONG KT").ToList();
            cbx.DisplayMember = "TENCN";
            cbx.ValueMember = "TENSERVER";


            cbxRole.Properties.Items.Add(Role.SV);
            cbxRole.Properties.Items.Add(Role.GIANGVIEN);
            

        }
        
        
       
        private void lbUsername_Click(object sender, EventArgs e)
        {

        }

        private void cbx_SelectedValueChanged(object sender, EventArgs e)
        {

           Program.serverName = Program.currentServer = (cbx.SelectedItem as ServerInfo).TENSERVER;
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch(cbxRole.EditValue)
            {
                case Role.SV: LoginStudent(); break;
                case null: return;
                default: LoginStaff(); break;
                
            }
        }
        void LoginStudent()
        {
            Program.login = Program.loginStudent;
            Program.password = Program.passwordStudent;
            var res = userDAL.LoginStudent(tbLogin.Text.Trim(), tbPassword.Text.Trim());
            if (res.Response.State == ResponseState.Fail)
            {
                lbMessage.Text = res.Response.Message;
                return;
            }
            if (res.Data == null)
                return;

            Program.username = res.Data.USERNAME;
            Program.fullName = res.Data.HOTEN;
            Program.group = res.Data.TENNHOM;

            this.DialogResult = DialogResult.OK;
        }
        void LoginStaff()
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text;

            Program.login = login;
            Program.password = password;

            var res = userDAL.Login(login);
            if (res.Response.State == ResponseState.Fail)
            {
                lbMessage.Text = res.Response.Message;
                return;
            }

            Program.username = res.Data.USERNAME;
            Program.fullName = res.Data.HOTEN;
            Program.group = res.Data.TENNHOM;

            this.DialogResult = DialogResult.OK;
        }

    }
    
}
