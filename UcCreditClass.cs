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

namespace StudentManagement
{
    public partial class UcCreditClass : DevExpress.XtraEditors.XtraUserControl
    {
        bool isInsert = false;
        private LopTinChiDAL lopTinChiDAL;
        private GiangVienDAL giangVienDAL;
        private MonHocDAL monHocDAL;
        public UcCreditClass()
        {
            InitializeComponent();
            lopTinChiDAL = new LopTinChiDAL();
            giangVienDAL = new GiangVienDAL();
            monHocDAL = new MonHocDAL();

            SupportConnectionDAL connectionDAL = new SupportConnectionDAL();
            lkFaculty.DataSource = connectionDAL.GetListPhanManh();

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            bEFaculty.EditValue = Program.serverName;

            lkSubject.Properties.DataSource = monHocDAL.GetListMonHoc().Data;

            lkTeacher.Properties.DataSource = giangVienDAL.GetListGiangVien().Data;


            InitialSchoolYear();
            bESemester.EditValue = 1;
            tbxIdClass.Enabled = false;
            tbxSchoolYear.Enabled = false;
            nmuSemester.Enabled = false;

            btnCancelInsert.Visible = false;
            btnInsert.Visible = false;


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
            gcCreditClass.DataSource = res.Data;
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
            
           
            LOPTINCHI lOPTINCHI = new LOPTINCHI()
            {
                MAKHOA = "CNTT",
                MAMH = lkSubject.EditValue as string,
                MAGV = lkTeacher.EditValue as string,
                TENGV = lkTeacher.Text as string,
                HUYLOP = false,
                NHOM = Convert.ToInt32( nmuGroup.EditValue),
                SOSVTOITHIEU = Convert.ToInt32( nmuMininumStudent.EditValue),
                MALTC = 0,
                TENMH = lkSubject.Text as string,
            };
            nmuGroup.EditValue.ToString();
            nmuMininumStudent.EditValue.ToString();



            var data = (List<LOPTINCHI>)gvCreditClass.DataSource;
            data.Add(lOPTINCHI);
            gcCreditClass.RefreshDataSource();
        }

        private void bESchoolYear_EditValueChanged(object sender, EventArgs e)
        {
            tbxSchoolYear.EditValue = bESchoolYear.EditValue;
            
        }

        private void bESemester_EditValueChanged(object sender, EventArgs e)
        {
            nmuSemester.EditValue = bESemester.EditValue;//
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
            List<UpdateLopTinChi> listUpdate;
            listUpdate = ((List<LOPTINCHI>)gvCreditClass.DataSource).Select(x => new UpdateLopTinChi(x)).ToList();
            string nienKhoa = bESchoolYear.EditValue as string;
            int hocky = Convert.ToInt32( bESemester.EditValue);
            var res = lopTinChiDAL.UpdateLopTinChi(listUpdate,nienKhoa,hocky);
            if (res.Response.State == ResponseState.Fail)
            {
                // Notify error
            } else
            {
                // notify susscess
            }


        }
    }
}
