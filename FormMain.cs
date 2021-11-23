using DevExpress.XtraBars;
using System;
using StudentManagement.Model;
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
        UcCreditClass ucCreditClass;
        UCRegisterCreditClass uCRegisterCreditClass;
        UCTuitionFee uCTuitionFee;
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
            decentralization();
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
            if(ucCreditClass == null )
                ucCreditClass = new UcCreditClass();

            ucCreditClass.Dock = DockStyle.Fill;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(ucCreditClass);

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new TestAddLogin();
            form.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uCRegisterCreditClass == null)
                uCRegisterCreditClass = new UCRegisterCreditClass();

            uCRegisterCreditClass.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(uCRegisterCreditClass);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uCTuitionFee == null)
                uCTuitionFee = new UCTuitionFee();

            uCTuitionFee.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(uCTuitionFee);
        }

        private void svPermission()
        {
            //barButtonItem1.Enabled = false;
            //barButtonItem2.Enabled = false;
            //barButtonItem3.Enabled = false;
            //barButtonItem4.Enabled = false;
        }

        private void pgvPermission()
        {
            //barButtonItem1.Enabled = false;
            //barButtonItem2.Enabled = false;
            //barButtonItem3.Enabled = false;
            //barButtonItem4.Enabled = false;
        }
        
        private void pktPermission()
        {
            barButtonItem1.Enabled = false;
            barButtonItem2.Enabled = false;
            barButtonItem3.Enabled = false;
            //barButtonItem4.Enabled = false;
        }
        private void khoaPermission()
        {
            //barButtonItem1.Enabled = false;
            //barButtonItem2.Enabled = false;
            //barButtonItem3.Enabled = false;
            barButtonItem4.Enabled = false;
        }

        private void decentralization()
        {
            switch (bbtnGroup.ToString())
            {
                case Role.SV : svPermission(); break;
                case Role.PGV: pgvPermission(); break;
                case Role.PKT: pktPermission(); break;
                case Role.KHOA: khoaPermission(); break;
                default: return;
            }
        }
    }
}