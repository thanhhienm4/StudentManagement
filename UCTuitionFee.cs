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
using DevExpress.XtraGrid.Views.Grid;

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

        private void gcFee_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click111");
        }

        private void gcFeeDetail_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click222");
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hocPhiDAL = new HocPhiDAL();
            
            if (textMaSV.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên");
                return;
            }

            String MASV = textMaSV.EditValue.ToString().Trim();
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
                MessageBox.Show("Mã sinh viên không tồn tại", "", MessageBoxButtons.OK);
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

        private void bButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GetSelelectRow(gvFee) == -1 && GetSelelectRow(gvFeeDetail) == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc chắn xóa?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if(GetSelelectRow(gvFee) != -1)
                    {
                        gvFee.DeleteSelectedRows();
                    }
                    else
                    {
                        gvFeeDetail.DeleteSelectedRows();
                    }
                        
                }
            }
        }

        private int GetSelelectRow(GridView grid)
        {
            int[] rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                return -1;
            }
            return rows[0];
        }
    }


}
