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
using DevExpress.XtraGrid.Columns;

namespace StudentManagement
{
    public partial class UCTuitionFee : DevExpress.XtraEditors.XtraUserControl
    {
        private HocPhiDAL hocPhiDAL;
        bool insertFeeSignal = true;
        bool insertFeeDetailSignal = true;
        //bool editFeeSignal = false;
        //bool editFeeDetailSignal = false;

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


        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hocPhiDAL = new HocPhiDAL();
            insertFeeSignal = false;
            
            if (textMaSV.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên");
                return;
            }

            String MASV = textMaSV.EditValue.ToString().Trim();
            var check = hocPhiDAL.CheckExistedSV(MASV);

            if (check.Data)
            {
                loadDataFee(MASV);
            }
            
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại", "", MessageBoxButtons.OK);
            }
            insertFeeSignal = true;
            
        }
        private void loadDataFee(String MASV)
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
        }

        private void gridFee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            insertFeeDetailSignal = false;
            if (gvFee.IsValidRowHandle(e.FocusedRowHandle) && gvFee.GetFocusedRow() != null)
            {
                HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
                String nienKhoa = hOCPHITONGHOP.NIENKHOA;
                int hocKy = hOCPHITONGHOP.HOCKY;
                loadDataFeeDetail(textMaSV.EditValue.ToString(), nienKhoa, hocKy);

            }
            insertFeeDetailSignal = true;
        }

        private void loadDataFeeDetail(string maSV, string nienKhoa, int hocKy)
        {
            var cthp = hocPhiDAL.DSCTHocPhi(maSV, nienKhoa, hocKy);
            if (cthp.Response.State == ResponseState.Fail)
            {
                return;
            }
            gCFeeDetail.DataSource = new BindingList<CT_DONGHOCPHI>(cthp.Data);
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

        }


        private void bButtonInsertCTHP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gvFee_RowCountChanged(object sender, EventArgs e)
        {
            if (insertFeeSignal)
            {
                int newRowInsert = gvFee.RowCount - 2;
                HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(newRowInsert);
                String maSv = textMaSV.EditValue.ToString();
                String nienKhoa = hOCPHITONGHOP.NIENKHOA;
                int hocKy = hOCPHITONGHOP.HOCKY;
                int hocPhi = hOCPHITONGHOP.HOCPHI;

                String message = "Bạn có muốn thêm " + maSv + " khóa " + nienKhoa + " học kỳ " + hocKy + " với học phí là " + hocPhi;
                DialogResult dialog = MessageBox.Show(message, "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    insertFee(maSv, nienKhoa, hocKy, hocPhi);
                }
                else
                {
                    // Cancel
                    insertFeeSignal = false;
                    gvFee.DeleteRow(newRowInsert);
                    insertFeeSignal = true;
                    return;
                }
            }
        }

        private void gvFeeDetail_RowCountChanged(object sender, EventArgs e)
        {
            if (insertFeeDetailSignal)
            {
                int newRowInsert = gvFeeDetail.RowCount - 2;

                HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
                String maSv = textMaSV.EditValue.ToString();
                String nienKhoa = hOCPHITONGHOP.NIENKHOA;
                int hocKy = hOCPHITONGHOP.HOCKY;
                CT_DONGHOCPHI cthp = (CT_DONGHOCPHI)gvFeeDetail.GetRow(newRowInsert);
                int soTienDong = cthp.SOTIENDONG;
                DateTime ngayDong = cthp.NGAYDONG;

                String message = "Bạn có muốn thêm " + maSv + " khóa " + nienKhoa + " học kỳ " + hocKy + " đóng số tiền là " + soTienDong;
                DialogResult dialog = MessageBox.Show(message, "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    insertFeeDetail(maSv, nienKhoa, hocKy, ngayDong, soTienDong);
                }
                else
                {
                    // Cancel
                    insertFeeDetailSignal = false;
                    gvFeeDetail.DeleteRow(newRowInsert);
                    insertFeeDetailSignal = true;
                }
            }
        }

        private void insertFee(String maSv, String nienKhoa, int hocKy, int hocPhi)
        {
            var res = hocPhiDAL.ThemHocPhi(maSv, nienKhoa, hocKy, hocPhi);
            if (res.Data)
            {
                MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show(res.Response.Message, "", MessageBoxButtons.OK);
                // Xóa dòng lỗi
                insertFeeSignal = false;
                gvFee.DeleteRow(gvFee.RowCount - 2);
                insertFeeSignal = true;
            }
        }

        private void insertFeeDetail(string maSv, string nienKhoa, int hocKy, DateTime ngayDong, int soTienDong)
        {
            var res = hocPhiDAL.SVDongHocPhi(maSv, nienKhoa, hocKy, ngayDong, soTienDong);
            if (res.Data)
            {
                MessageBox.Show("Nộp thành công", "", MessageBoxButtons.OK);
                insertFeeSignal = false;
                loadDataFee(maSv);
                insertFeeSignal = false;
            }
            else
            {
                MessageBox.Show(res.Response.Message, "", MessageBoxButtons.OK);
                // Xóa dòng lỗi
                insertFeeDetailSignal = false;
                gvFeeDetail.DeleteRow(gvFeeDetail.RowCount - 2);
                insertFeeDetailSignal = true;
            }
        }

        private void gvFeeDetail_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
        //    if (editFeeDetailSignal)
        //    {
        //        int newRowInsert = gvFeeDetail.RowCount - 2;

        //        HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
        //        String maSv = textMaSV.EditValue.ToString();
        //        String nienKhoa = hOCPHITONGHOP.NIENKHOA;
        //        int hocKy = hOCPHITONGHOP.HOCKY;
        //        CT_DONGHOCPHI cthp = (CT_DONGHOCPHI)gvFeeDetail.GetRow(newRowInsert);
        //        int soTienDong = cthp.SOTIENDONG;
        //        DateTime ngayDong = cthp.NGAYDONG;
        //        if (soTienDong <= 0 || soTienDong > hOCPHITONGHOP.HOCPHI - hOCPHITONGHOP.DADONG)
        //        {
        //            MessageBox.Show("Số tiền đóng không thể nhỏ hơn bằng 0 hoặc lớn hơn số tiền cần đóng", "", MessageBoxButtons.OK);
        //            gvFeeDetail.FocusedRowHandle = newRowInsert;
        //            editFeeDetailSignal = true;
        //            return;
        //        }
        //        insertFeeDetail(maSv, nienKhoa, hocKy, ngayDong, soTienDong);
        //        editFeeDetailSignal = false;
        //    }

        }

        private void gvFee_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //if (editFeeSignal)
            //{
            //    int newRowInsert = gvFee.RowCount - 2;
            //    HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(newRowInsert);
            //    String maSv = textMaSV.EditValue.ToString();
            //    String nienKhoa = hOCPHITONGHOP.NIENKHOA;
            //    int hocKy = hOCPHITONGHOP.HOCKY;
            //    int hocPhi = hOCPHITONGHOP.HOCPHI;

            //    if (nienKhoa is null)
            //    {
            //        MessageBox.Show("Bạn chưa nhập niên khóa", "", MessageBoxButtons.OK);
            //        gvFee.FocusedRowHandle = newRowInsert;
            //        editFeeSignal = true;
            //        return;
            //    }
            //    insertFee(maSv, nienKhoa, hocKy, hocPhi);
            //    editFeeSignal = false;

            //}
        }

        private void gvFee_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (gridView.GetRowCellValue(e.RowHandle, nienKhoa) == null)
            {
                gridView.SetColumnError(nienKhoa, "Niên khóa không được để trống");
                e.Valid = false;
            }

            if (int.Parse(gridView.GetRowCellValue(e.RowHandle, hocPhi).ToString()) <= 0)
            {
                gridView.SetColumnError(hocPhi, "Học phí không hợp lệ");
                e.Valid = false;
            }

            if (int.Parse(gridView.GetRowCellValue(e.RowHandle, hocKy).ToString()) <= 0
                || int.Parse(gridView.GetRowCellValue(e.RowHandle, hocKy).ToString()) > 4)
            {
                gridView.SetColumnError(hocKy, "Học kỳ phải nằm trong khoảng từ 1-3");
                e.Valid = false;
            }

        }

        private void gvFeeDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            HOCPHITONGHOP hOCPHITONGHOP = (HOCPHITONGHOP)gvFee.GetRow(gvFee.FocusedRowHandle);
            int canDong = hOCPHITONGHOP.HOCPHI -hOCPHITONGHOP.DADONG;

            if (gridView.GetRowCellValue(e.RowHandle, ngayDong) == null)
            {
                gridView.SetColumnError(ngayDong, "Niên khóa không được để trống");
                e.Valid = false;
            }

            if (int.Parse(gridView.GetRowCellValue(e.RowHandle, soTienDong).ToString()) > canDong)
            {
                gridView.SetColumnError(hocPhi, "Phải đóng nhỏ hơn hoặc bằng số tiền cần đóng");
                e.Valid = false;
            }
        }
    }


}
