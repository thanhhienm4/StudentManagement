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
    public partial class UcCreateSubject : DevExpress.XtraEditors.XtraUserControl
    {
        bool isInsert = false;
        private LopDAL lopDAL;
        private LopTinChiDAL lopTinChiDAL;
        private GiangVienDAL giangVienDAL;
        private MonHocDAL monHocDAL;
        private SUndo undo;
        private bool stateUndo;
        public UcCreateSubject()
        {
            InitializeComponent();
            lopDAL = new LopDAL();
            lopTinChiDAL = new LopTinChiDAL();
            giangVienDAL = new GiangVienDAL();
            monHocDAL = new MonHocDAL();
            undo = new SUndo();
            stateUndo = false;




            SupportDAL connectionDAL = new SupportDAL();
            lkFaculty.DataSource = connectionDAL.GetListPhanManh();

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;




            bESemester.EditValue = 1;


            LoadData();
            //lkTeacher.selected
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

            string mamh = gvCreditClass.GetRowCellValue(GetSelelectRow(), "MAMH").ToString();
            var res = monHocDAL.CheckMonHoc(mamh);

            if (res.Response.State == ResponseState.Fail)
            {
                // notify error
            }

            if (res.Data)
            {
                //  notify error
                if (GetSelelectRow() != -1)
                {
                    MONHOC monhoc = (MONHOC)gvCreditClass.GetRow(GetSelelectRow());
                    undo.Push(new ActionUndo(3, GetSelelectRow(), monhoc), new ActionUndo(2, GetSelelectRow(), null));
                    gvCreditClass.DeleteSelectedRows();
                    MessageBox.Show("Xóa thành công!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Mã môn học này đã được dùng ở nơi nào đó rồi");
            }


        }


        private void bELoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                LoadData();
        }

        private void LoadData()
        {

            var res = monHocDAL.GetListMonHoc();
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            }

            gcCreditClass.DataSource = new BindingList<MONHOC>(res.Data);
            //gcCreditClass.DataSource = res.Data;
            gvCreditClass.FocusInvalidRow();
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
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc là muốn lưu không?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                gvCreditClass.FocusInvalidRow();
                List<UPDATEMONHOC> listUpdate;
                var binding = (BindingList<MONHOC>)gvCreditClass.DataSource;
                listUpdate = binding.ToList().Select(x => new UPDATEMONHOC(x)).ToList();
                var res = monHocDAL.UpdateMonHoc(listUpdate);
                if (res.Response.State == ResponseState.Fail)
                {
                    MessageBox.Show("Lưu thất bại");
                }
                else
                {
                    MessageBox.Show("Lưu thành công");
                    cbxSchoolYear.Items.Clear();
                }
            }

        }



        private void gcCreditClass_Click(object sender, EventArgs e)
        {

        }

        private void gvCreditClass_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

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

                    List<MONHOC> mONHOCs = (gvCreditClass.DataSource as BindingList<MONHOC>).ToList();
                    mONHOCs.Insert(int.Parse(action.obj.ToString()), action.value as MONHOC);

                    gcCreditClass.DataSource = new BindingList<MONHOC>(mONHOCs);
                    gvCreditClass.FocusedRowHandle = int.Parse(action.obj.ToString());
                    break;
            }
            stateUndo = false;
        }

        private void gvCreditClass_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MAMH")
                return;

            if (stateUndo)
                return;
            GridView view = sender as GridView;
            GridCell gc = new GridCell(view.GetDataSourceRowIndex(e.RowHandle), e.Column);
            var value = (sender as GridView).GetRowCellValue(gc.RowHandle, gc.Column.FieldName);
            ActionUndo action = new ActionUndo(1, gc, value);
            undo.Push(action, new ActionUndo(1, gc, e.Value));
        }

        private void gvCreditClass_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView.FocusedColumn.FieldName == "MAMH")
            {
                string MAMH = (e.Value.ToString());
                if (MAMH.Equals(""))
                {
                    e.Valid = false;
                    e.ErrorText = "Không để rỗng!";
                }
            }
            if (gridView.FocusedColumn.FieldName == "SOTIET_LT")
            {
                int SOTIET_LT = 0;
                if (!Int32.TryParse(e.Value as String, out SOTIET_LT))
                {
                    e.Valid = false;
                    e.ErrorText = "Chỉ nhập số";
                }
            }

            if (gridView.FocusedColumn.FieldName == "SOTIET_TH")
            {
                int SOTIET_TH = 0;
                if (!Int32.TryParse(e.Value as String, out SOTIET_TH))
                {
                    e.Valid = false;
                    e.ErrorText = "Chỉ nhập số";
                }
            }
            if (gridView.FocusedColumn.FieldName == "TENMH")
            {
                if (e.Value.Equals(""))
                {
                    e.Valid = false;
                    e.ErrorText = "Không để rỗng!";
                }
            }
        }

        private void gvCreditClass_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;
            if(gridView.GetRowCellValue(e.RowHandle, idSubject) == null)
            {
                gridView.SetColumnError(idSubject, "Mã môn học không được để trống");
                e.Valid = false;
            }

            if (gridView.GetRowCellValue(e.RowHandle, colSubjectName) == null)
            {
                gridView.SetColumnError(colSubjectName, "Tên môn học không được để trống");
                e.Valid = false;
                e.ErrorText = "The value is not correct! ";
            }
            if (gridView.GetRowCellValue(e.RowHandle, colLT) == null)
            {
                gridView.SetColumnError(colLT, "Lớp lý thuyết không được để trống");
                e.Valid = false;
                e.ErrorText = "The value is not correct! ";
            }
            if (gridView.GetRowCellValue(e.RowHandle, colTH) == null)
            {
                gridView.SetColumnError(colLT, "Lớp thực hành không được để trống");
                e.Valid = false;
                e.ErrorText = "The value is not correct! ";
            }

            if(gridView.GetRowCellValue(e.RowHandle, colTH) != null || gridView.GetRowCellValue(e.RowHandle, colLT) != null)
            {
                int LT = Int32.Parse(gridView.GetRowCellValue(e.RowHandle, colLT).ToString());
                int TH = Int32.Parse(gridView.GetRowCellValue(e.RowHandle, colTH).ToString());
                if ((LT + TH) % 15 != 0||(LT+TH)<=0)
                {
                    gridView.SetColumnError(colLT, "Số tiết lý  thuyết + Thực hành chia hết cho 15");
                    gridView.SetColumnError(colTH, "Số tiết lý  thuyết + Thực hành chia hết cho 15");
                    e.Valid = false;
                    e.ErrorText = "The value is not correct! ";
                }

            }
        }
    }
}
