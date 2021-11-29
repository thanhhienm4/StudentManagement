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
    public partial class FormReportStudentCreditClass : DevExpress.XtraEditors.XtraForm
    {
       
        private SinhVienDAL _sinhVienDAL;
        private MonHocDAL _monHocDAL;
        ReportSudentInCreditClass report = new ReportSudentInCreditClass();
        public FormReportStudentCreditClass()
        {
            InitializeComponent();
            _sinhVienDAL = new SinhVienDAL();
            _monHocDAL = new MonHocDAL();
            var res = _monHocDAL.GetListMonHoc();
            if (res.Response.State == ResponseState.Fail)
            {
                return;
            }
            rilkMonHoc.DataSource = res.Data;
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
                ricbxNienKhoa.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            beNienKhoa.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }




        private void beLoad_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (beMonHoc.EditValue == null)
                return;

            string nienKhoa = beNienKhoa.EditValue.ToString();
            int hocKy = Convert.ToInt32(beHocKy.EditValue);
            string mamh = beMonHoc.EditValue.ToString();
            int nhom = Convert.ToInt32(beNhom.EditValue);

            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            var res = _sinhVienDAL.GetListSINHVIEN_LOPTINHCHI(nienKhoa, hocKy, mamh, nhom);
            if(res.Response.State == ResponseState.Fail)
            {
                //
                return;
            }

            string tenKhoa = Program.servers.FirstOrDefault(x => x.TENSERVER == Program.currentServer).TENCN;
            report.InitData(nienKhoa, hocKy, nhom,tenKhoa, res.Data, rilkMonHoc.GetDisplayText(beMonHoc.EditValue));
            docView.DocumentSource = report;
            report.CreateDocument();
        }
    }
}