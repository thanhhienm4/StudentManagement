using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class UCRegisterCreditClass : DevExpress.XtraEditors.XtraUserControl
    {
        private LopTinChiDAL _lopTinChiDAL;
        private DangKyDAL _dangKyDAL;
        private List<LOPTINCHI> _lopTinchiDaDangKy;
        
        public UCRegisterCreditClass()
        {
            InitializeComponent();
            InitialSchoolYear();
            _lopTinChiDAL = new LopTinChiDAL();
            _dangKyDAL = new DangKyDAL();
            
            AddRepository();
            //gvRegister.min
           


        }
     
      
        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                cbxSchoolYear1.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            bESchoolYear.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void beLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            // change check state in credit class
            IniData();

      
        }
        void IniData()
        {
            string nienKhoa = bESchoolYear.EditValue as string;
            int hocKy = Convert.ToInt32(bESemester.EditValue);

            var res = _lopTinChiDAL.GetListLopTinChiActive(nienKhoa, hocKy);
            if (res.Response.State == ResponseState.Fail)
            {
                return;
            }
            var resDangKy = _dangKyDAL.GetListDangKyBySinhVien(nienKhoa, hocKy, Program.username);
            if (res.Response.State == ResponseState.Fail)
            {
                return;
            }


            _lopTinchiDaDangKy = new List<LOPTINCHI>( resDangKy.Data);
            gcRegister.DataSource = resDangKy.Data;
            gcCreditClass.DataSource = res.Data;
           
            foreach (var lop in resDangKy.Data)
            {
                ChangeCheckState(lop.MALTC, true);
            }
        }
        
        private void AddRepository()
        {
            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.CheckedChanged += Edit_CheckedChanged;
            gvCreditClass.Columns["CHON"].ColumnEdit = edit;
            gvCreditClass.Columns["CHON"].FieldName = "CHON";

            RepositoryItemButtonEdit button = new RepositoryItemButtonEdit();
            button.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            button.ButtonClick += Button_ButtonClick;
            button.Buttons[0].Caption = "Xóa";
            

            button.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            button.Buttons[0].ImageOptions.Image = global::StudentManagement.Properties.Resources.delete_16x161;
            gvRegister.Columns["XOA"].ColumnEdit = button;
        }

        private void Button_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int maltc = (int)gvCreditClass.GetRowCellValue(gvRegister.FocusedRowHandle,"MALTC");
            ChangeCheckState(maltc, false);
            gvRegister.DeleteRow(gvRegister.FocusedRowHandle);
            
        }

        private void Edit_CheckedChanged(object sender, EventArgs e)
        {
            
            
            if((bool)gvCreditClass.GetRowCellValue(gvCreditClass.FocusedRowHandle, "CHON"))
            {
                gvCreditClass.SetRowCellValue(gvCreditClass.FocusedRowHandle, "CHON", false);
            }else
            {
                gvCreditClass.SetRowCellValue(gvCreditClass.FocusedRowHandle, "CHON", true);
            }

            LOPTINCHI lOPTINCHI = (LOPTINCHI)gvCreditClass.GetRow(gvCreditClass.FocusedRowHandle);
            Console.WriteLine(lOPTINCHI.CHON);


            if (gcRegister.DataSource == null)
                gcRegister.DataSource = new List<LOPTINCHI>();

            List<LOPTINCHI> registers = (List<LOPTINCHI>)gcRegister.DataSource;
            if ((bool)gvCreditClass.GetRowCellValue(gvCreditClass.FocusedRowHandle,"CHON"))
            {
                gvCreditClass.SelectRow(gvCreditClass.FocusedRowHandle);

                if (registers.Exists(x => x.MALTC == lOPTINCHI.MALTC))
                    return;

                if (_lopTinchiDaDangKy.Exists(x => x.MALTC == lOPTINCHI.MALTC))
                    lOPTINCHI.TRANGTHAI = "Đã lưu";
                else
                    lOPTINCHI.TRANGTHAI = "Chưa lưu";

                registers.Add(lOPTINCHI);
                gcRegister.RefreshDataSource();
                return;
            }

            var delete = registers.Where(x => x.MALTC == lOPTINCHI.MALTC).FirstOrDefault();
            registers.Remove(delete);
            gcRegister.RefreshDataSource();
        }

        void ChangeCheckState(int maltc, bool state)
        {
            for(int i = 0; i< gvCreditClass.DataRowCount; i++)
            {
                int maltcCurrent = (int)gvCreditClass.GetRowCellValue(i, "MALTC");
                if(maltcCurrent == maltc)
                {
                    gvCreditClass.SetRowCellValue(i, "CHON",state);
                    return;
                }
            }
        }

        private void beSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<LOPTINCHI> lOPTINCHIs = (List<LOPTINCHI>)gcRegister.DataSource;
            if (lOPTINCHIs == null)
                return;
            var listUpdate = lOPTINCHIs.Select(x => new UpdateDangKy()
            {
                HUYDANGKY = false,
                MASV = Program.username,
                MALTC = x.MALTC

            }).ToList();
            var res = new DangKyDAL().UpdateDangKy(listUpdate, Program.username);
            if (res.Response.State == ResponseState.Success)
                IniData();
            else
            {
                MessageBox.Show(res.Response.Message);
            }
           // if(res.)
        }

      

       
    }
}
