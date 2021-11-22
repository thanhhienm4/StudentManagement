using DevExpress.XtraEditors;
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
    public partial class UCTuitionFee : DevExpress.XtraEditors.XtraUserControl
    {
        public UCTuitionFee()
        {
            InitializeComponent();
        }

        public void InitialSchoolYear()
        {
            DateTime now = DateTime.Now;
            int start = now.AddYears(-15).Year;
            int end = now.AddYears(15).Year;
            for (int year = start; year <= end; year++)
            {
                string schoolYear = String.Format("{0}-{1}", year, year + 1);
                ItemComboBox.Items.Add(schoolYear);
            }

            if (now.Month < 9)
                now.AddYears(-1);
            barEditItem1.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }
    }


}
