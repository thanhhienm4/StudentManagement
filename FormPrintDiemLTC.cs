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
    public partial class FormPrintDiemLTC : DevExpress.XtraEditors.XtraForm
    {
        private MonHocDAL monHocDAL;
        private LopTinChiDAL lopTinChiDAL;
        private ReportDiemLTC ucReportDiemLTC = new ReportDiemLTC();
        public FormPrintDiemLTC()
        {
            InitializeComponent();
            monHocDAL = new MonHocDAL();
            lopTinChiDAL = new LopTinChiDAL();

            SupportDAL connectionDAL = new SupportDAL();
            lkFaculty.DataSource = Program.servers;

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;

            if (Program.group == Role.KHOA)
                bEFaculty.Enabled = false;

            loadDataSubject();
            loadDataCourse();
            bEsemester.EditValue = "0";
            bEgroup.EditValue = "0";
        }

        private void bEload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mamh = bEsubject.EditValue.ToString();
            string tenKhoa = Program.servers.FirstOrDefault(x => x.TENSERVER == Program.currentServer).TENCN;
            string nienkhoa = bEcourse.EditValue.ToString();
            int hocky = Int32.Parse(bEsemester.EditValue.ToString());
            int nhom = Int32.Parse(bEgroup.EditValue.ToString());
            if (catchError(mamh, hocky, nhom))
            {
                string monhoc = ((List<MONHOC>)cobboxSubject.DataSource).FirstOrDefault(x => x.MAMH == mamh).TENMH;
                var res = lopTinChiDAL.ReportDiemLTC(nienkhoa, hocky, mamh, nhom);
                if (res.Response.State == ResponseState.Fail)
                {
                    return;
                }
                foreach (DevExpress.XtraReports.Parameters.Parameter p in ucReportDiemLTC.Parameters)
                    p.Visible = false;

                ucReportDiemLTC.InitData(monhoc, hocky,nhom,nienkhoa, res.Data, tenKhoa);
                documentViewer1.DocumentSource = ucReportDiemLTC;
                ucReportDiemLTC.CreateDocument();
            }
        }

        private Boolean catchError(string mamh,int hocky, int nhom)
        {
            Boolean check = true;
            if (mamh.Equals(""))
            {
                MessageBox.Show("Môn học không được trống", "Môn học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            if (hocky<1)
            {
                MessageBox.Show("Học kỳ không được < 1", "Học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            if (nhom<1)
            {
                MessageBox.Show("Nhóm không được < 1", "Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            return check;
        }

        private void loadDataSubject()
        {
            bEsubject.EditValue = "";
            cobboxSubject.DataSource = monHocDAL.GetListMonHoc().Data;
        }

        private void loadDataCourse()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                comboboxCourse.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            bEcourse.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void bEFaculty_EditValueChanged(object sender, EventArgs e)
        {
            Program.currentServer = bEFaculty.EditValue as string;
        }
    }
}