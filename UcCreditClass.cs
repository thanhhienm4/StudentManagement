using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using StudentManagement.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class UcCreditClass : DevExpress.XtraEditors.XtraUserControl
    {
        bool isInsert = false;
        public UcCreditClass()
        {
            InitializeComponent();
            this.DSCreditClass.EnforceConstraints = false;
            this.tASPCreditClass.Connection.ConnectionString = Program.conmStr;
            this.tASPCreditClass.Fill(this.DSCreditClass.SP_DS_LopTinChi, "2021-2022", 1);

            this.tASubject.Connection.ConnectionString = Program.conmStr;
            this.tASubject.Fill(this.DSCreditClass.MONHOC);

            this.tATeacher.Connection.ConnectionString = Program.conmStr;
            this.tATeacher.Fill(this.DSCreditClass.SP_DS_GiangVien);

            SupportConnectionDAL connectionDAL = new SupportConnectionDAL();

            lkFaculty.DataSource = connectionDAL.GetSubscripton();
            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;


            InitialSchoolYear();
            bESemester.EditValue = 1;

            

            tbxIdClass.Enabled = false;
            tbxSchoolYear.Enabled = false;
            nmuSemester.Enabled = false;

            btnCancelInsert.Visible = false;
            btnInsert.Visible = false;


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
            Program.conmStr = String.Format("Data Source={0} ;Database=QLDSV_TC ;Persist Security Info=True;User ID={1}; password={2}",
                                    bEFaculty.EditValue, Program.login, Program.password);
        }

        private void bEAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvCreditClass.ClearSelection();
            this.dSSPCreditClass.SuspendBinding();
            gvCreditClass.FocusInvalidRow();
            isInsert = true;
            btnCancelInsert.Visible = true;
            btnInsert.Visible = true;
            ckCancel.Visible = false;
           
        }

        private void bEdelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GetSelelectRow() == -1)
                return;
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Int;
            parameter.ParameterName = "@MALTC";
            parameter.Value = int.Parse(gvCreditClass.GetRowCellValue(GetSelelectRow(),"MALTC").ToString());

            BaseDAl.Connect();
            SqlCommand command = new SqlCommand("select  [dbo].[FUNC_KT_DK_LopTinChi] (@MALTC)", Program.conn);
            command.Parameters.Clear();
            command.Parameters.Add(parameter);
            if((bool)command.ExecuteScalar() == true)
            {
                MessageBox.Show("Không thể xóa");
                Program.conn.Close();
                return;
            }

            Program.conn.Close();
            gvCreditClass.DeleteSelectedRows();
        }

       
        private void bELoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tASPCreditClass.Fill(this.DSCreditClass.SP_DS_LopTinChi, bESchoolYear.EditValue.ToString(), int.Parse(bESemester.EditValue.ToString()));
            gvCreditClass.FocusInvalidRow();
        }

        private void btnCancelInsert_Click(object sender, EventArgs e)
        {
            isInsert = false;
            ckCancel.Visible = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            gvCreditClass.AddNewRow();
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle, "MAKHOA", "CNTT");
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"MAMH",lkSubject.EditValue);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"TENMH", lkSubject.Text);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"NIENKHOA", bESchoolYear.EditValue);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"HOCKY", bESemester.EditValue);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"MAGV", lkTeacher.EditValue);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"TENGV", lkTeacher.Text);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"HUYLOP", false);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle, "NHOM", nmuGroup.EditValue);
            gvCreditClass.SetRowCellValue(GridControl.NewItemRowHandle,"SOSVTOITHIEU",nmuMininumStudent.EditValue );
        }

        private void bESchoolYear_EditValueChanged(object sender, EventArgs e)
        {
            tbxSchoolYear.EditValue = bESchoolYear.EditValue;
            
        }

        private void bESemester_EditValueChanged(object sender, EventArgs e)
        {
            nmuSemester.EditValue = bESemester.EditValue;
        }

        

        private void gvCreditClass_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (isInsert)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;
            tbxIdClass.EditValue = gvCreditClass.GetRowCellValue(row, "MALTC");
            lkTeacher.EditValue = gvCreditClass.GetRowCellValue(row, "MAGV");
            lkSubject.EditValue = gvCreditClass.GetRowCellValue(row, "MAMH");
            nmuGroup.EditValue = gvCreditClass.GetRowCellValue(row, "NHOM");
            nmuMininumStudent.EditValue = gvCreditClass.GetRowCellValue(row, "SOSVTOITHIEU");
            ckCancel.EditValue = gvCreditClass.GetRowCellValue(row, "HUYLOP");

        }

        private int GetSelelectRow()
        {
            int[] rows = gvCreditClass.GetSelectedRows();
            if (rows.Length == 0)
                return -1;
            return rows[0];
        }

        private void lkSubject_EditValueChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

            gvCreditClass.SetRowCellValue(row, "MAMH", lkSubject.EditValue);
            gvCreditClass.SetRowCellValue(row, "TENMH", lkSubject.Text);

        }

        private void nmuGroup_EditValueChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

            gvCreditClass.SetRowCellValue(row, "NHOM", nmuGroup.EditValue);
        }

        private void lkTeacher_EditValueChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

            gvCreditClass.SetRowCellValue(row, "MAGV", lkTeacher.EditValue);
            gvCreditClass.SetRowCellValue(row, "TENGV", lkTeacher.Text);

        }

        private void nmuMininumStudent_EditValueChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

            gvCreditClass.SetRowCellValue(row, "SOSVTOITHIEU", nmuMininumStudent.EditValue);
        }

        private void ckCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (isInsert == true)
                return;
            int row = GetSelelectRow();
            if (row == -1)
                return;

            gvCreditClass.SetRowCellValue(row, "HUYLOP", ckCancel.EditValue);
        }

        private void bESave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvCreditClass.FocusInvalidRow();
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC",typeof(int));
            dt.Columns.Add("NIENKHOA", typeof(string));
            dt.Columns.Add("HOCKI",typeof(int));
            dt.Columns.Add("MAMH",typeof(string));
            dt.Columns.Add("NHOM", typeof(int));
            dt.Columns.Add("MAGV", typeof(string));

            dt.Columns.Add("MAKHOA", typeof(string));
            dt.Columns.Add("SOSVTOITHIEU", typeof(int));
            dt.Columns.Add("HUYLOP", typeof(bool));
            
            for(int i = 0;i< gvCreditClass.RowCount;i++)
            {
                dt.Rows.Add(
                    gvCreditClass.GetRowCellValue(i, "MALTC"),
                    gvCreditClass.GetRowCellValue(i, "NIENKHOA"),
                    gvCreditClass.GetRowCellValue(i, "HOCKY"),
                    gvCreditClass.GetRowCellValue(i, "MAMH"),
                    gvCreditClass.GetRowCellValue(i, "NHOM"),
                    gvCreditClass.GetRowCellValue(i, "MAGV"),
                    gvCreditClass.GetRowCellValue(i, "MAKHOA"),
                    gvCreditClass.GetRowCellValue(i, "SOSVTOITHIEU"),
                    gvCreditClass.GetRowCellValue(i, "HUYLOP")
                    );
               
            }


            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "DBO.TYPE_UPDATE_LopTinChi";
            parameter.ParameterName = "@LTC";
            parameter.Value = dt;

            BaseDAl.Connect();
            SqlCommand command = new SqlCommand("SP_UPDATE_LOPTINCHI",Program.conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();

            

        }
    }
}
