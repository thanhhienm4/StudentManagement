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
    public partial class FormReportSumaryFinal : DevExpress.XtraEditors.XtraForm
    {
        ReportSummaryFinal report = new ReportSummaryFinal();
        LopDAL lopDAL = new LopDAL();
        SupportDAL supportDAL = new SupportDAL();
        public FormReportSumaryFinal()
        {
            InitializeComponent();
            var res = lopDAL.GetListLop();
            rilkLop.DataSource = res.Data;
            rilkKhoa2.DataSource = Program.servers;
            beKhoa.EditValue = Program.serverName;

            if (Program.group == Role.KHOA)
                beKhoa.Enabled = false;

        }
        

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string malop =beLop.EditValue as string ;
            if(String.IsNullOrWhiteSpace(malop))
            {
                MessageBox.Show("Mã lớp không được để trống");
                return ;
            }    
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;

            var res = lopDAL.GetListTongKetCuoiKhoa(malop);
            report.InitData(res.Data);
            docView.DocumentSource = report;
            report.CreateDocument();
        }

        private void beKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void beKhoa_EditValueChanged(object sender, EventArgs e)
        {
            Program.currentServer = beKhoa.EditValue as string;
        }
    }
}