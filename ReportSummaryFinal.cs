using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class ReportSummaryFinal : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSummaryFinal()
        {
            InitializeComponent();
        }
        public void InitData(List<TongKetCuoiKhoa> data)
        {
            objectDataSource1.DataSource = data;
        }

        private void xrCrossTab1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void ReportSummaryFinal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XtraReport report = (XtraReport)sender;
            report.DataSource = null;
        }
    }
}
