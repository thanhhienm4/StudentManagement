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
        UcCreateSubject ucCreateSubject;
        UcCreditClass ucCreditClass;
        UcCreateClass ucCreateClass;
        UcCreateStudent ucCreateStudent;
        UCRegisterCreditClass uCRegisterCreditClass;
        UCTuitionFee uCTuitionFee;
        ucUpdateGrade ucUpdateGrade;
        public FormMain()
        {
            InitializeComponent();
            ShowFormLogin();
                    
        }
        
        
        void ShowFormLogin()
        {
            this.Visible = false;
            if (fromLogin == null)
                fromLogin = new FormLogin();

            var dr = fromLogin.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Visible = true;
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
            
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        void reset()
        {
            rbgKhoa.Visible = true;
            rbgBaoCao.Visible = true;
            rbgAddLogin.Visible = true;
            rbgKt.Visible = true;
            rbgSinhVien.Visible = true;
            rbgDSHocPhi.Visible = true;

            rbGLopTinChi.Visible = true;
            rgBBangDiem.Visible = true;
            rgBSVDangKi.Visible = true;
            rbGPhieuDiem.Visible = true;
            rbGTongKet.Visible = true;
        }

        private void svPermission()
        {
            rbgKhoa.Visible = false;
            rbgBaoCao.Visible = false;
            rbgAddLogin.Visible = false;
            rbgKt.Visible = false;
        }

        private void pgvPermission()
        {
            rbgSinhVien.Visible = false;
            rbgKt.Visible = false;
            rbgDSHocPhi.Visible = false;
        }
        
        private void pktPermission()
        {
            rbgSinhVien.Visible = false;
            rbgKhoa.Visible = false;
            rbGLopTinChi.Visible = false;
            rgBBangDiem.Visible = false;
            rgBSVDangKi.Visible = false;
            rbGPhieuDiem.Visible = false;
            rbGTongKet.Visible = false;
        }
        private void khoaPermission()
        {
            rbgSinhVien.Visible = false;
            rbgKt.Visible = false;
            rbgDSHocPhi.Visible = false;
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

        private void beUpdateGrade_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ucUpdateGrade == null)
                ucUpdateGrade = new ucUpdateGrade();

            ucUpdateGrade.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(ucUpdateGrade);

        }

        private void bbReport_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCreditClass form = new FormCreditClass();
            form.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintFee form = new FormPrintFee();
            form.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ucCreateClass == null)
                ucCreateClass = new UcCreateClass();

            ucCreateClass.Dock = DockStyle.Fill;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(ucCreateClass);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ucCreateStudent == null)
                ucCreateStudent = new UcCreateStudent();

            ucCreateStudent.Dock = DockStyle.Fill;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(ucCreateStudent);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportStudentCreditClass form = new FormReportStudentCreditClass();
            form.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintStudentTranscripts form = new FormPrintStudentTranscripts();
            form.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportSumaryFinal form = new FormReportSumaryFinal();
            form.ShowDialog();
        }

        private void btn_inDiemLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintDiemLTC ltc = new FormPrintDiemLTC();
            ltc.ShowDialog();
        }

        public async void Notify(string messasge)
        {
            
            btnNotice.ItemAppearance.Normal.BackColor = Color.LightGreen;
            btnNotice.LargeWidth = 500;
            btnNotice.Caption = messasge + new string(' ',200 - messasge.Length);
            await Task.Delay(2000);
            btnNotice.Caption = "";
            btnNotice.ItemAppearance.Normal.BackColor = Color.LightGray;

        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCreditClass form = new FormCreditClass();
            form.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintDiemLTC form = new FormPrintDiemLTC();
            form.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportSumaryFinal form = new FormReportSumaryFinal();
            form.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uCRegisterCreditClass == null)
                uCRegisterCreditClass = new UCRegisterCreditClass();

            uCRegisterCreditClass.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(uCRegisterCreditClass);
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (uCTuitionFee == null)
                uCTuitionFee = new UCTuitionFee();

            uCTuitionFee.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(uCTuitionFee);
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new FormAddLogin();
            form.ShowDialog();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintFee form = new FormPrintFee();
            form.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportStudentCreditClass form = new FormReportStudentCreditClass();
            form.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPrintStudentTranscripts form = new FormPrintStudentTranscripts();
            form.ShowDialog();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ucCreateSubject == null)
                ucCreateSubject = new UcCreateSubject();

            ucCreateSubject.Dock = DockStyle.Fill;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(ucCreateSubject);

        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            reset();
            ShowFormLogin();
        }
    }
}