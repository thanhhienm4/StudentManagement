using DevExpress.XtraEditors;
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
    public partial class UCAddLogin : DevExpress.XtraEditors.XtraUserControl
    {
        private UserDAL _userDAL;
        private GiangVienDAL _giangVienDAL;
        public UCAddLogin()
        {
            InitializeComponent();
            _userDAL = new UserDAL();
            _giangVienDAL = new GiangVienDAL();

            lkGiangVien.Properties.DataSource = _giangVienDAL.GetListGiangVien().Data;

            switch(Program.group)
            {
                case Role.KHOA: cbxRole.Properties.Items.Add(Role.KHOA);
                    break;
                case Role.PGV: cbxRole.Properties.Items.Add(Role.KHOA);
                    cbxRole.Properties.Items.Add(Role.PGV);
                    break;
                case Role.PKT: cbxRole.Properties.Items.Add(Role.PKT);
                    break;
            }    
        }

        

        private void Tạo_Click(object sender, EventArgs e)
        {
            string login = teLogin.Text.Trim();
            string password = tePW.Text.Trim();
            string user = lkGiangVien.EditValue as string;
            string role = cbxRole.EditValue.ToString();

            var res = _userDAL.CreateLogin(login, password, user, role);
            if (res.Response.State == Model.ResponseState.Fail)
            {
                MessageBox.Show(res.Response.Message);
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thành công");
            }
        }
    }
}
