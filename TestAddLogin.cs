using DevExpress.XtraEditors;
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
    public partial class TestAddLogin : DevExpress.XtraEditors.XtraForm
    {
        public TestAddLogin()
        {
            InitializeComponent();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string login = teLogin.Text;
            string password = tePW.Text;
            string user = teUser.Text;
            string role = teRole.Text;

            var res = new UserDAL().CreateLogin(login, password, user, role);
            if (res.Response.State == Model.ResponseState.Fail)
                MessageBox.Show(res.Response.Message);
        }
    }
}