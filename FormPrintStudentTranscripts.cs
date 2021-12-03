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
    public partial class FormPrintStudentTranscripts : Form
    {
        private LopTinChiDAL lopTinChiDAL;
        ReportStudentTranscripts report = new ReportStudentTranscripts();
        public FormPrintStudentTranscripts()
        {
            InitializeComponent();
            lopTinChiDAL = new LopTinChiDAL();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(textMaSV.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "", MessageBoxButtons.OK);
                return;
            }

            var res = lopTinChiDAL.InBangDiemSV(textMaSV.EditValue.ToString().Trim(), Program.group);

            if (res.Response.State == ResponseState.Fail)
            {
                MessageBox.Show(res.Response.Message, "", MessageBoxButtons.OK);
                return;
            }

            report.InitData(res.Data);
            //report.xR
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
