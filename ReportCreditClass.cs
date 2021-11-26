using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class ReportCreditClass : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportCreditClass()
        {
            InitializeComponent();
        }
        public void InitData(string nienKhoa, int hocKy, List<LOPTINCHI> data, string tenKhoa)
        {
            this.nienKhoa.Value = nienKhoa;
            this.hocKy.Value = hocKy;
            this.tenKhoa.Value = tenKhoa;
            objectDataSource1.DataSource = data;
           
        }

    }
}
