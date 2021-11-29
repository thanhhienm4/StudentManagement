using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class ReportTuitionFee : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportTuitionFee()
        {
            InitializeComponent();
        }

        public void InitData(string maLop, List<INHOCPHI> data, string tenKhoa)
        {
            this.pTenKhoa.Value = tenKhoa;
            this.pMaLop.Value = maLop;
            objectDataSource2.DataSource = data;
            Console.WriteLine("aa");
            Console.WriteLine(this.xrTableCell12.Value);
        }

        //public void convert

    }
}
