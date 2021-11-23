using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using StudentManagement.Repositories;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Model;

namespace StudentManagement
{
    public partial class UCTuitionFee : DevExpress.XtraEditors.XtraUserControl
    {
        private HocPhiDAL hocPhiDAL;

        public UCTuitionFee()
        {
            InitializeComponent();
        }

        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                ItemComboBox.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            barEditItem1.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Console.WriteLine("OK");
            String maSV = barEditItem6.EditValue.ToString();
            hocPhiDAL = new HocPhiDAL();
            var res = hocPhiDAL.TestInfoSinhvien(maSV);
            Console.WriteLine(res);

            if (res.Response.State == ResponseState.Fail)
            {
                Console.WriteLine("xxx");
            }

            foreach (var value in res.Data)
            {
                barEditItem7.EditValue = value.HOTEN;
                barEditItem8.EditValue = value.MALOP;
            }    
            
            Console.WriteLine(maSV);
        }

        private void barEditItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }


}
