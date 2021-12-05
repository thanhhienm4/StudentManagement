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
        ReportCreditClass report = new ReportCreditClass();
        public FormCreditClass()
        {
            InitializeComponent();
            _lopTinChiDAL = new LopTinChiDAL();
           
           

            
        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void beLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string nienKhoa = beNienKhoa.EditValue.ToString();
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
        //public PrintReport(string nienKhoa, int hocKy, List)
        //{
        //    ReportCreditClass report = new ReportCreditClass();
        //    report.
        //}
    }
}