using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using StudentManagement.Model;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ucUpdateGrade : DevExpress.XtraEditors.XtraUserControl
    {
        private LopTinChiDAL _lopTinChiDAL;
        private DangKyDAL _dangKyDAL;
        private SupportDAL _supportDAL;

        public ucUpdateGrade()
        {
            InitializeComponent();
            InitialSchoolYear();
            _lopTinChiDAL = new LopTinChiDAL();
            _dangKyDAL = new DangKyDAL();
            beSemester.EditValue = 1;



            _supportDAL = new SupportDAL();
            lkFaculty.DataSource = Program.servers;

            lkFaculty.DisplayMember = "TENCN";
            lkFaculty.ValueMember = "TENSERVER";
            lkFaculty.PopulateColumns();
            lkFaculty.Columns["TENSERVER"].Visible = false;
            beFaculty.EditValue = Program.serverName;


            if (Program.group == Role.KHOA)
                beFaculty.Enabled = false;
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
            beSchoolYear.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void beLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string nienKhoa = beSchoolYear.EditValue as string;
            int hocKy = Convert.ToInt32(beSemester.EditValue);

            var res = _lopTinChiDAL.GetListLopTinChiActive(nienKhoa, hocKy);
            if (res.Response.State == ResponseState.Fail)
            {
                return;
            }
            
            gcCreditClass.DataSource = res.Data;

        }

        private void gvUpdateGrade_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
            

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

        private void gvCreditClass_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void gvCreditClass_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCreditClass.IsValidRowHandle(e.FocusedRowHandle) && gvCreditClass.GetFocusedRow() != null)
            {
                // DANGKY dANGKY = gvCreditClass.get
                int maltc = (int)gvCreditClass.GetRowCellValue(e.FocusedRowHandle, "MALTC");
                var res = _dangKyDAL.GetListDKByMALTC(maltc);
                if (res.Response.State == ResponseState.Fail)
                {
                    return;
                }

                gcUpdateGrade.DataSource = res.Data;
            }
        }

        private void beSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<DANGKY> listDangky = (List<DANGKY>)gvUpdateGrade.DataSource;
            if (listDangky == null)
                return;
            List<UpdateGrade> listUpdateGrade = listDangky.Select(x => new UpdateGrade(x)).ToList();
            var res = _dangKyDAL.UpdateDiem(listUpdateGrade);
            if(res.Response.State == ResponseState.Success)
            {
                Program.formMain.Notify("Lưu thành công");
            }else
            {
                MessageBox.Show("Lưu thông tin thất bại");
            }    

        }

        private void beFaculty_EditValueChanged(object sender, EventArgs e)
        {
            Program.currentServer = (string)beFaculty.EditValue;
        }
    }
}
