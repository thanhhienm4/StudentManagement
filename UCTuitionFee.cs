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
            hocPhiDAL = new HocPhiDAL();
            String MASV = textMaSV.EditValue.ToString();
            var check = hocPhiDAL.CheckExistedSV(MASV);
            if (check.Data)
            {
                var res = hocPhiDAL.TestInfoSinhvien(MASV);
                textHoTenSV.EditValue = res.Data.HOTEN;
                textMaLop.EditValue = res.Data.MALOP;

                var dsHocPhi = hocPhiDAL.DSHocPhiByMASV(MASV);

                if (dsHocPhi.Response.State == ResponseState.Fail)
                {
                    return;
                }

                gCFee.DataSource = dsHocPhi.Data;
            }
            
            else
            {
                MessageBox.Show("Bạn chưa nhập Mã sinh viên hoặc mã sinh viên không tồn tại", "", MessageBoxButtons.OK);
            }

            
        }

        private void barEditItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridFee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvFee.IsValidRowHandle(e.FocusedRowHandle) && gvFee.GetFocusedRow() != null)
            {
                HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
                String nienKhoa = hOCPHITONGHOP.NIENKHOA;
                int hocKy = hOCPHITONGHOP.HOCKY;
                var cthp = hocPhiDAL.DSCTHocPhi(textMaSV.EditValue.ToString(), nienKhoa, hocKy);
                if(cthp.Response.State == ResponseState.Fail)
                {
                    return;
                }
                gCFeeDetail.DataSource = cthp.Data;
            }
        }
    }


}
