using DevExpress.XtraReports.UI;
using StudentManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace StudentManagement
{
    public partial class UcReportDiemLTC : DevExpress.XtraReports.UI.XtraReport
    {
        public UcReportDiemLTC()
        {
            InitializeComponent();
        }
        public void InitData(string monhoc,int hocky,int nhom,string nienkhoa, List<REPORTDIEMLTC> data, string tenKhoa)
        {
            this.pKHOA.Value = tenKhoa;
            this.pMonhoc.Value = monhoc;
            this.pNhom.Value = nhom;
            this.pHocky.Value = hocky;
            this.pNienKhoa.Value = nienkhoa;
            objectDataSource1.DataSource = data;
        }
    }
}
