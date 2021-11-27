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
        int rowsFeeNow = 0;
        int rowsFeeDetailNow = 0;

        public UCTuitionFee()
        {
            InitializeComponent();
            InitialSchoolYear();
            
        }

        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                riNienKhoa.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            //r.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
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
                var res = hocPhiDAL.GetInfoSinhvien(MASV);
                textHoTenSV.EditValue = res.Data.HOTEN;
                textMaLop.EditValue = res.Data.MALOP;

                var dsHocPhi = hocPhiDAL.DSHocPhiByMASV(MASV);

                if (dsHocPhi.Response.State == ResponseState.Fail)
                {
                    return;
                }

                gCFee.DataSource = new BindingList<HOCPHITONGHOP>(dsHocPhi.Data);
                rowsFeeNow = gvFee.RowCount;
                
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
                gCFeeDetail.DataSource = new BindingList<CT_DONGHOCPHI>(cthp.Data);
                rowsFeeDetailNow = gvFeeDetail.RowCount;

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

        private void bButtonInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gvFee.ClearSelection();
            //gvFee.FocusInvalidRow();
            //isInsert = true;
            //checkThemHocPhi();
            HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.RowCount - 2);
            String maSv = textMaSV.EditValue.ToString();
            String nienKhoa = hOCPHITONGHOP.NIENKHOA;
            int hocKy = hOCPHITONGHOP.HOCKY;
            int hocPhi = hOCPHITONGHOP.HOCPHI;
            var res = hocPhiDAL.ThemHocPhi(maSv, nienKhoa, hocKy, hocPhi);
            if (res.Data)
            {
                MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK);
            }    

        }

        private void checkThemHocPhi()
        {
            if (textMaSV.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên");
                return;
            }
            HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.RowCount - 2);
            String nienKhoa = hOCPHITONGHOP.NIENKHOA;
            int hocKy = hOCPHITONGHOP.HOCKY;
            Console.WriteLine(nienKhoa, hocKy);
        }

        private void bButtonInsertCTHP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
            String maSv = textMaSV.EditValue.ToString();
            String nienKhoa = hOCPHITONGHOP.NIENKHOA;
            int hocKy = hOCPHITONGHOP.HOCKY;
            int hocPhi = hOCPHITONGHOP.HOCPHI;
            CT_DONGHOCPHI cthp = (CT_DONGHOCPHI)gvFeeDetail.GetRow(gvFeeDetail.RowCount - 2);
            int soTienDong = cthp.SOTIENDONG;
            DateTime ngayDong = cthp.NGAYDONG;
            if(soTienDong <= 0 || soTienDong > hOCPHITONGHOP.HOCPHI - hOCPHITONGHOP.DADONG)
            {
                MessageBox.Show("Số tiền đóng không thể nhỏ hơn bằng 0 hoặc lớn hơn số tiền cần đóng", "", MessageBoxButtons.OK);
                return;
            }
            var res = hocPhiDAL.SVDongHocPhi(maSv, nienKhoa, hocKy, ngayDong, soTienDong);
            if (res.Data)
            {
                MessageBox.Show("Nộp thành công", "", MessageBoxButtons.OK);
                
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK);
                return;
            }
        }
    }


}
