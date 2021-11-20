using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
        public UCRegisterCreditClass()
        {
            InitializeComponent();
            InitialSchoolYear();
            _lopTinChiDAL = new LopTinChiDAL();
            
            AddRepository();
        }

        private void UCRegisterCreditClass_Load(object sender, EventArgs e)
        {

        }

        private void gridSplitContainer1Grid_Click(object sender, EventArgs e)
        {

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
            string nienKhoa = bESchoolYear.EditValue as string;
            int hocKy = Convert.ToInt32(bESemester.EditValue);
            
            var res    = _lopTinChiDAL.GetListLopTinChiActive(nienKhoa,hocKy);
            if(res.Response.State == Model.ResponseState.Fail)
            {
                return;
            }
            gcCreditClass.DataSource = res.Data;
        }

        
        private void AddRepository()
        {
            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.CheckedChanged += Edit_CheckedChanged;
            gvCreditClass.Columns["CHON"].ColumnEdit = edit;

            RepositoryItemButtonEdit button = new RepositoryItemButtonEdit();
            button.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            button.ButtonClick += Button_ButtonClick;
            button.Buttons[0].Caption = "Xóa";
            button.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            gvRegister.Columns["XOA"].ColumnEdit = button;
        }

        private void Button_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gvRegister.DeleteRow(gvRegister.FocusedRowHandle);
        }

        private void Edit_CheckedChanged(object sender, EventArgs e)
        {

            LOPTINCHI lOPTINCHI = (LOPTINCHI)gvCreditClass.GetRow(gvCreditClass.FocusedRowHandle);
            if (gcRegister.DataSource == null)
                gcRegister.DataSource = new List<LOPTINCHI>();

            List<LOPTINCHI> registers = (List<LOPTINCHI>)gcRegister.DataSource;

            if (!(bool)gvCreditClass.GetRowCellValue(gvCreditClass.FocusedRowHandle,"CHON"))
            {
                if (registers.Exists(x => x.MALTC == lOPTINCHI.MALTC))
                    return;

                registers.Add(lOPTINCHI);
                gcRegister.RefreshDataSource();
                return;
            }

            var delete = registers.Where(x => x.MALTC == lOPTINCHI.MALTC).FirstOrDefault();
            registers.Remove(delete);
            gcRegister.RefreshDataSource();
        }

       

        
    }
}
