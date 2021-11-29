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
    public partial class UcCreateStudent : DevExpress.XtraEditors.XtraUserControl
    {
        bool isInsert = false;
        private LopTinChiDAL lopTinChiDAL;
        private SinhVienDAL sinhVienDAL;
        private GiangVienDAL giangVienDAL;
        private MonHocDAL monHocDAL;
        private SUndo undo;
        private LopDAL lopDAL;
        private bool stateUndo;
        public UcCreateStudent()
        {
            InitializeComponent();
            lopTinChiDAL = new LopTinChiDAL();
            giangVienDAL = new GiangVienDAL();
            lopDAL = new LopDAL();
            monHocDAL = new MonHocDAL();
            sinhVienDAL = new SinhVienDAL();
            undo = new SUndo();
            stateUndo = false;




            SupportDAL connectionDAL = new SupportDAL();
            lkFaculty.DataSource = connectionDAL.GetListPhanManh();

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;




            InitialSchoolYear();
            bESemester.EditValue = 1;


            LoadData();
            //lkTeacher.selected
        }


        public void InitialSchoolYear()
        {
            cbxSchoolYear.Items.Clear();
            cbxSchoolYear.Items.Add("Tất cả");
            foreach (LOP lop in lopDAL.GetListLop().Data)
            {
                cbxSchoolYear.Items.Add(lop.MALOP.ToString());
            }
            bESchoolYear.EditValue = "Tất cả";
        }

        private void bESemester_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.tASPCreditClass.Connection.ConnectionString = Program.conmStr;

        }

        private void bEFaculty_EditValueChanged(object sender, EventArgs e)
        {
            Program.currentServer = bEFaculty.EditValue as string;
            InitialSchoolYear();
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

            string masv = gvCreditClass.GetRowCellValue(GetSelelectRow(), "MASV").ToString();
            var res = sinhVienDAL.CheckSinhvien(masv);
            if (res.Response.State == ResponseState.Fail)
            {
                // notify error
            }

            if (res.Data)
            {
                gvCreditClass.SetFocusedRowCellValue("DANGHIHOC", 1);
            }
            else
            {
                //  notify error
                if (GetSelelectRow() != -1)
                {
                    SINHVIEN sinhvien = (SINHVIEN)gvCreditClass.GetRow(GetSelelectRow());
                    undo.Push(new ActionUndo(3, GetSelelectRow(), sinhvien), new ActionUndo(2, GetSelelectRow(), null));
                    gvCreditClass.DeleteSelectedRows();
                    return;

                }



            }


        }


        private void bELoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (bESchoolYear.EditValue.ToString() != "Tất cả")
            {
                LoadDataByIdClass();
            }
            else
            {
                LoadData();
            }
        }
        private void LoadData()
        {

            rilkLOP.DataSource = new LopDAL().GetListLop().Data;
            var res = sinhVienDAL.GetListSinhVien();
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            }

            gcCreditClass.DataSource = new BindingList<SINHVIEN>(res.Data);
            //gcCreditClass.DataSource = res.Data;
            gvCreditClass.FocusInvalidRow();


        }

        private void LoadDataByIdClass()
        {
            rilkLOP.DataSource = new LopDAL().GetListLop().Data;
            string idClass = bESchoolYear.EditValue.ToString();
            var res = sinhVienDAL.GetListSinhVienByLop(idClass);
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            }

            gcCreditClass.DataSource = new BindingList<SINHVIEN>(res.Data);
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
            gvCreditClass.FocusInvalidRow();
            List<UPDATESINHVIEN> listUpdate;
            var binding = (BindingList<SINHVIEN>)gvCreditClass.DataSource;
            listUpdate = binding.ToList().Select(x => new UPDATESINHVIEN(x)).ToList();
            var res = sinhVienDAL.UpdateSinhVien(listUpdate);
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            }
            else
            {
                // notify susscess
            }


        }


        private void rilkMAMH_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null)
                return;
            LOP LOPs = ((List<LOP>)rilkLOP.DataSource).FirstOrDefault(x => x.MALOP == e.NewValue.ToString());
            if (LOPs == null)
                return;
            gvCreditClass.SetRowCellValue(gvCreditClass.FocusedRowHandle, "TENLOP", LOPs.TENLOP);
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

                    List<SINHVIEN> SINHVIENs = (gvCreditClass.DataSource as BindingList<SINHVIEN>).ToList();
                    SINHVIENs.Insert(int.Parse(action.obj.ToString()), action.value as SINHVIEN);

                    gcCreditClass.DataSource = new BindingList<SINHVIEN>(SINHVIENs);
                    gvCreditClass.FocusedRowHandle = int.Parse(action.obj.ToString());
                    break;
            }
            stateUndo = false;
        }

        private void gvCreditClass_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {


            if (e.Column.FieldName == "MASV")
                return;

            if (stateUndo)
                return;
            GridView view = sender as GridView;
            GridCell gc = new GridCell(view.GetDataSourceRowIndex(e.RowHandle), e.Column);
            var value = (sender as GridView).GetRowCellValue(gc.RowHandle, gc.Column.FieldName);
            ActionUndo action = new ActionUndo(1, gc, value);
            undo.Push(action, new ActionUndo(1, gc, e.Value));
        }
    }
}
