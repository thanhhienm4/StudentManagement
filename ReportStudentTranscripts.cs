using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class ReportStudentTranscripts : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportStudentTranscripts()
        {
            InitializeComponent();
        }

        public void InitData(List<INBANGDIEM> data)
        {
            objectDataSource1.DataSource = data;
        }

    }
}
