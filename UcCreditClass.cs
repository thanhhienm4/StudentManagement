using DevExpress.XtraEditors;
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
    public partial class UcCreditClass : DevExpress.XtraEditors.XtraUserControl
    {
        public UcCreditClass()
        {
            InitializeComponent();
            this.DSCreditClass.EnforceConstraints = false;
            this.tACreditClass.Connection.ConnectionString = Program.conmStr;
            this.tACreditClass.Fill(this.DSCreditClass.LOPTINCHI);

            this.tASubject.Connection.ConnectionString = Program.conmStr;
            this.tASubject.Fill(this.DSCreditClass.MONHOC);

            this.tATeacher.Connection.ConnectionString = Program.conmStr;
            this.tATeacher.Fill(this.DSCreditClass.GIANGVIEN);

            SupportConnectionDAL connectionDAL = new SupportConnectionDAL();
           
            lkBranch.DataSource = connectionDAL.GetSubscripton();
            lkBranch.DisplayMember = "TENCN";
            lkBranch.ValueMember = "TENSERVER";
            lkBranch.PopulateColumns();
            lkBranch.Columns["TENSERVER"].Visible = false;
            bmBranch.EditValue = Program.serverName;
            //lkBranch.value

            lkTeacher.GetNotInListValue += LookUpEdit1_GetNotInListValue;

            tbxIdClass.Enabled = false;
            lkTeacher.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSCreditClass, "MAGV", true));
            lkSubject.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSCreditClass, "MAMH", true));

            //lkTeacher.selected
        }
        private void LookUpEdit1_GetNotInListValue(object sender, DevExpress.XtraEditors.Controls.GetNotInListValueEventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            string info1 = editor.Properties.GetDataSourceValue("HO", e.RecordIndex).ToString();
            string info2 = editor.Properties.GetDataSourceValue("TEN", e.RecordIndex).ToString();
            e.Value = info1 + " " + info2;
        }


        private void dANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mALTCLabel_Click(object sender, EventArgs e)
        {

        }

        private void nIENKHOALabel_Click(object sender, EventArgs e)
        {

        }

        private void hOCKYLabel_Click(object sender, EventArgs e)
        {

        }

        private void mAMHLabel_Click(object sender, EventArgs e)
        {

        }

        private void nHOMLabel_Click(object sender, EventArgs e)
        {

        }

        private void mAGVLabel_Click(object sender, EventArgs e)
        {

        }

        private void mAKHOALabel_Click(object sender, EventArgs e)
        {

        }

        private void sOSVTOITHIEULabel_Click(object sender, EventArgs e)
        {

        }

        //private void lkTeacher_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        //{
        //    if (e.Value == null)
        //        return;
        //    var edit = (LookUpEdit) sender;
        //    var props = edit.Properties;

        //    object row = props.GetDataSourceRowByKeyValue(e.Value);
        //    if (row != null)
        //    {
        //        e.DisplayText = String.Format("{0} {1}", ((DataRowView) row)["HO"], ((DataRowView)row)["TEN"]);
                
        //    }

        //}
    }
}
