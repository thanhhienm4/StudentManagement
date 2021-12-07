using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using StudentManagement.Model;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using StudentManagement.Undo;
using DevExpress.XtraGrid.Views.Base;

namespace StudentManagement
{
    public partial class UcCreditClass : DevExpress.XtraEditors.XtraUserControl
    {
        bool isInsert = false;
        private LopTinChiDAL lopTinChiDAL;
        private GiangVienDAL giangVienDAL;
        private MonHocDAL monHocDAL;
        private SUndo undo;
        private bool stateUndo;
        public UcCreditClass()
        {
            InitializeComponent();
            lopTinChiDAL = new LopTinChiDAL();
            giangVienDAL = new GiangVienDAL();
            monHocDAL = new MonHocDAL();
            undo = new SUndo();
            stateUndo = false;


           

            SupportDAL connectionDAL = new SupportDAL();
            lkFaculty.DataSource = Program.servers;

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;

            if (Program.group == Role.KHOA)
                bEFaculty.Enabled = false;


            InitialSchoolYear();
            bESemester.EditValue = 1;


            LoadData(); 
            //lkTeacher.selected
        }
       

        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                cbxSchoolYear.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            bESchoolYear.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void bESemester_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.tASPCreditClass.Connection.ConnectionString = Program.conmStr;
            
        }

        private void bEFaculty_EditValueChanged(object sender, EventArgs e)
        {
            Program.currentServer = bEFaculty.EditValue as string;

        }

        private void bEAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvCreditClass.ClearSelection();
            this.dSSPCreditClass.SuspendBinding();
            gvCreditClass.FocusInvalidRow();
            isInsert = true;
           
        }

        private void bEdelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GetSelelectRow() == -1)
                return;
         
            int maltc = int.Parse(gvCreditClass.GetRowCellValue(GetSelelectRow(),"MALTC").ToString());
            var res = lopTinChiDAL.CheckLopTinChi(maltc);
            
            if(res.Response.State == ResponseState.Fail)
            {
               // notify error
            }

            if(res.Data)
            {
                
            }else
            {
                //  notify error
                if (GetSelelectRow() != -1)
                {
                    LOPTINCHI lOPTINCHI = (LOPTINCHI)gvCreditClass.GetRow(GetSelelectRow());
                    undo.Push(new ActionUndo(3, GetSelelectRow(), lOPTINCHI), new ActionUndo(2, GetSelelectRow(), null));
                    gvCreditClass.DeleteSelectedRows();
                    return;

                }
                   

              
            }

            
        }

       
        private void bELoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            LoadData();
        }
        private void LoadData()
        {
           
            string nienKhoa = bESchoolYear.EditValue.ToString();
            int hocKy = int.Parse(bESemester.EditValue.ToString());

            var res = lopTinChiDAL.GetListLopTinChi(nienKhoa, hocKy);
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            }

            gcCreditClass.DataSource = new BindingList<LOPTINCHI>(res.Data);
            //gcCreditClass.DataSource = res.Data;
            gvCreditClass.FocusInvalidRow();
            rilkMAMH.DataSource = new MonHocDAL().GetListMonHoc().Data;
            rilkMAGV.DataSource = new GiangVienDAL().GetListGiangVien().Data;
        }

        private void bESchoolYear_EditValueChanged(object sender, EventArgs e)
        {
            //tbxSchoolYear.EditValue = bESchoolYear.EditValue;
            
        }

        private void bESemester_EditValueChanged(object sender, EventArgs e)
        {
            //nmuSemester.EditValue = bESemester.EditValue;
        }

        

        private void gvCreditClass_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
  
               

        }

        private int GetSelelectRow()
        {
            int[] rows = gvCreditClass.GetSelectedRows();
            if (rows.Length == 0)
                return -1;
            return rows[0];
        }

      

        private void ckCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

          
        }

        private void bESave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(gvCreditClass.RowCount >0)
            {
                gvCreditClass.SetRowCellValue(0, "MALTC", gvCreditClass.GetRowCellValue(0, "MALTC"));
            }    
            List<UpdateLopTinChi> listUpdate;
            var binding = (BindingList<LOPTINCHI>)gvCreditClass.DataSource;
            listUpdate =  binding.ToList().Select(x => new UpdateLopTinChi(x)).ToList();
            string nienKhoa = bESchoolYear.EditValue as string;
            int hocky = Convert.ToInt32( bESemester.EditValue);
            var res = lopTinChiDAL.UpdateLopTinChi(listUpdate,nienKhoa,hocky);
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            } else
            {
                // notify susscess
                Program.formMain.Notify("Lưu thành công");
            }


        }

       
        private void rilkMAMH_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null)
                return;
            MONHOC mONHOC = ((List<MONHOC>)rilkMAMH.DataSource).FirstOrDefault(x => x.MAMH == e.NewValue.ToString());
            if (mONHOC == null)
                return;
            gvCreditClass.SetRowCellValue(gvCreditClass.FocusedRowHandle, "TENMH", mONHOC.TENMH);
        }

        private void gcCreditClass_Click(object sender, EventArgs e)
        {

        }

        private void gvCreditClass_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Console.WriteLine('A');
        }

        private void rilkMAGV_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null)
                return;
            GIANGVIEN gIANGVIEN = ((List<GIANGVIEN>)rilkMAGV.DataSource).FirstOrDefault(x => x.MAGV == e.NewValue.ToString());
            if (gIANGVIEN == null)
                return;
            gvCreditClass.SetRowCellValue(gvCreditClass.FocusedRowHandle, "TENGV", gIANGVIEN.HOTEN);
        }

        private void gvCreditClass_InitNewRow(object sender, InitNewRowEventArgs e)
        {

            if (stateUndo)
                return;
            undo.Push(new ActionUndo(2, gvCreditClass.RowCount, null), new ActionUndo(3, GetSelelectRow(), new LOPTINCHI()));
        }

        private void bEUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            ChangeUndoAction(undo.Before());
        }

        private void beRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeUndoAction(undo.After());
        }
        void ChangeUndoAction(ActionUndo action)
        {
            if (action == null)
                return;
            stateUndo = true;
            switch (action.type)
            {
                case 1:
                    GridCell cell = action.obj as GridCell;
                    gvCreditClass.SetRowCellValue(gvCreditClass.GetRowHandle(cell.RowHandle), cell.Column, action.value);
                    Console.WriteLine(gvCreditClass.GetRowCellValue(gvCreditClass.GetRowHandle(cell.RowHandle), cell.Column));
                    gvCreditClass.FocusedRowHandle = cell.RowHandle;
                    break;
                case 2:
                    int row = (int)action.obj;
                    gvCreditClass.DeleteRow(row - 1);
                    break;
                case 3:

                    List<LOPTINCHI> LOPTINCHIs = (gvCreditClass.DataSource as BindingList<LOPTINCHI>).ToList();
                    LOPTINCHIs.Insert(int.Parse(action.obj.ToString()), action.value as LOPTINCHI);
                   
                    gcCreditClass.DataSource = new BindingList<LOPTINCHI>(LOPTINCHIs);
                    gvCreditClass.FocusedRowHandle = int.Parse(action.obj.ToString());
                    break;
            }
            stateUndo = false;
        }

        private void gvCreditClass_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "TENGV" || e.Column.FieldName == "TENMH" || e.Column.FieldName == "MALTC")
                return;

            if (stateUndo)
                return;
            GridView view = sender as GridView;
            GridCell gc = new GridCell(view.GetDataSourceRowIndex(e.RowHandle), e.Column);
            var value = (sender as GridView).GetRowCellValue(gc.RowHandle, gc.Column.FieldName);
            ActionUndo action = new ActionUndo(1, gc, value);
            undo.Push(action, new ActionUndo(1, gc, e.Value));
        }

        private void gvCreditClass_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;
            if(gridView.GetRowCellValue(e.RowHandle,"NHOM") == null || (int)gridView.GetRowCellValue(e.RowHandle, "NHOM") == 0)
            {
                e.ErrorText = "Nhóm không được để trống hoặc bằng 0";
                e.Valid = false;
            }
            if (gridView.GetRowCellValue(e.RowHandle, "SOSVTOITHIEU") == null || (int)gridView.GetRowCellValue(e.RowHandle, "SOSVTOITHIEU") == 0)
            {
                e.ErrorText = "Số sinh viên tối thiểu không được để trống hoặc bằng 0";
                e.Valid = false;
            }
            if (gridView.GetRowCellValue(e.RowHandle, "MAMH") == null )
            {
                e.ErrorText = "Mã môn học không được để trống";
                e.Valid = false;
            }
            if (gridView.GetRowCellValue(e.RowHandle, "MAGV") == null)
            {
                e.ErrorText = "Max giảng viên không được để trống";

                e.Valid = false;
            }


            if(gridView.GetRowCellValue(e.RowHandle, "NHOM") != null
                && gridView.GetRowCellValue(e.RowHandle, "MAMH") != null)
            {
                var binding = (BindingList<LOPTINCHI>)gvCreditClass.DataSource;
                var listUpdate = binding.ToList().Select(x => new UpdateLopTinChi(x)).ToList();
                if(listUpdate.Exists(x => x.NHOM == (int)(gridView.GetRowCellValue(e.RowHandle, "NHOM") ) &&
                 x.MAMH == gridView.GetRowCellValue(e.RowHandle, "MAMH").ToString()))
                    {
                    e.ErrorText = "Môn học và nhóm đã được đăng kí";

                    e.Valid = false;
                }
            }    
        }
    }
}
