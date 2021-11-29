using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class ReportSudentInCreditClass : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSudentInCreditClass()
        {
            InitializeComponent();
        }
        public void InitData(string nienKhoa, int hocKy , int nhom, string tenKhoa, List<SINHVIEN> data, string tenMonHoc)
        {
            this.nienKhoa.Value = nienKhoa;
            this.hocKy.Value = hocKy;
            this.nhom.Value = nhom;
            this.tenKhoa.Value = tenKhoa;
            this.objectDataSource1.DataSource = data;
        }
    }
}
