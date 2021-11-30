using StudentManagement.Helper;
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
    public partial class FormPrintFee : Form
    {
        private HocPhiDAL hocPhiDAL;
        ReportTuitionFee report = new ReportTuitionFee();
        public FormPrintFee()
        {
            InitializeComponent();
            InitialSchoolYear();
            hocPhiDAL = new HocPhiDAL();
        }

        public String convertMoneyString(List<INHOCPHI> list)
        {
            int money = 0;
            for(int i = 0; i < list.Count; i++)
            {
                money += list[i].SOTIENDONG;
            }
            String moneyString = ConvertMoney.NumberToString(money);
            return moneyString;
            
        }

        private void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                CbYear.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            bEYear.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void Print(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            if (textMalop.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã lớp");
                return;
            }

            if (bEYear.EditValue is null)
            {
                MessageBox.Show("Bạn chưa chọn niên khóa");
                return;
            }

            if (bESemester.EditValue is null)
            {
                MessageBox.Show("Bạn chưa chọn học kỳ");
                return;
            }

            String MaLop = textMalop.EditValue.ToString().Trim();
            var check = hocPhiDAL.CheckExistedLop(MaLop);
            string nienKhoa = bEYear.EditValue.ToString();
            int hocKy = int.Parse(bESemester.EditValue.ToString());

            Console.WriteLine(MaLop);
            Console.WriteLine(nienKhoa);
            Console.WriteLine(hocKy);
            if (check.Data)
            {
                var res = hocPhiDAL.INDSHPByLop(MaLop, nienKhoa, hocKy);
                var resKhoa = hocPhiDAL.GetTenKhoaByMaLop(MaLop);

                if (res.Response.State == ResponseState.Fail)
                {
                    MessageBox.Show(res.Response.Message, "", MessageBoxButtons.OK);
                    return;
                }
                
                report.InitData(MaLop, res.Data, resKhoa.Data.TENKHOA, convertMoneyString(res.Data));
                //report.xR
                documentViewer1.DocumentSource = report;
                report.CreateDocument();
            }

            else
            {
                MessageBox.Show("Mã lớp không tồn tại", "", MessageBoxButtons.OK);
            }
            
        }

    }
}
