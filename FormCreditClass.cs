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
    public partial class FormCreditClass : DevExpress.XtraEditors.XtraForm
    {
        private LopTinChiDAL _lopTinChiDAL;
        private ReportCreditClass report = new ReportCreditClass();
        private SupportDAL _supportDAL;
        public FormCreditClass()
        {
            InitializeComponent();
            _lopTinChiDAL = new LopTinChiDAL();
            _supportDAL = new SupportDAL();

            rilkKhoa.DataSource = _supportDAL.GetListPhanManh();
            beKHOA.EditValue = Program.serverName;
            InitialSchoolYear();





        }
        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                rilkNienKhoa.Items.Add(schoolYear);
            }

            if (now.Month <= 8)
            {
                now.AddYears(-1);
                beHocky.EditValue = 2;
            }else
            {
                beHocky.EditValue = 1;
            }    
               
            beNienKhoa.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }
        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void beLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            string nienKhoa = beNienKhoa.EditValue.ToString().Trim();

            if(nienKhoa == "")
            {
                MessageBox.Show("Niên khóa không được bỏ trống");
                return;
            }    

            int hocKy =  Convert.ToInt32( beHocky.EditValue);
            var res = _lopTinChiDAL.GetListLopTinChiActive(nienKhoa,hocKy);
            if(res.Response.State ==  ResponseState.Fail)
            {
                return;
            }
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;


            string tenKhoa = Program.servers.FirstOrDefault(x => x.TENSERVER == Program.currentServer).TENCN;
            report.InitData(nienKhoa,hocKy,res.Data,tenKhoa);
            docVIew.DocumentSource = report;
            report.CreateDocument();


        }

        private void beKHOA_EditValueChanged(object sender, EventArgs e)
        {
            
            Program.currentServer = beKHOA.EditValue.ToString();
        }
        //public PrintReport(string nienKhoa, int hocKy, List)
        //{
        //    ReportCreditClass report = new ReportCreditClass();
        //    report.
        //}
    }
}