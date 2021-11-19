using DevExpress.XtraBars;
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
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        FormLogin fromLogin;
        public FormMain()
        {
            InitializeComponent();
            ShowFormLogin();
                    
        }
        
        
        void ShowFormLogin()
        {
            if (fromLogin == null)
                fromLogin = new FormLogin();

            var dr = fromLogin.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Initial();
            }else
            {
                this.Load += MyForm_CloseOnStart;
            }
            
        }
        
        void Initial()
        {
            bbtnCode.Caption = Program.username;
            bbtnFullName.Caption = Program.fullName;
            bbtnGroup.Caption = Program.group;
           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ucCreditClass = new UcCreditClass();
            ucCreditClass.Dock = DockStyle.Fill;
            pnContent.Controls.Add(ucCreditClass);

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new TestAddLogin();
            form.Show();
        }
    }
}