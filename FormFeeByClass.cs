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
    public partial class FormFeeByClass : Form
    {
        private HocPhiDAL hocPhiDAL;
        public FormFeeByClass()
        {
            InitializeComponent();
            InitialSchoolYear();
        }

        public void InitialSchoolYear()
        {
            //DateTime now = DateTime.Now;
            //int start = now.AddYears(-15).Year;
            //int end = now.AddYears(15).Year;
            //for (int year = start; year <= end; year++)
            //{
            //    string schoolYear = String.Format("{0}-{1}", year, year + 1);
            //    comboBox.Items.Add(schoolYear);
            //}

            //if (now.Month < 9)
            //    now.AddYears(-1);
            //cBYear.EditValue = String.Format("{0}-{1}", now.Year, now.Year + 1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            hocPhiDAL = new HocPhiDAL();

            if (textLop.EditValue is null)
            {
                MessageBox.Show("Bạn chưa nhập mã lớp");
                return;
            }

            String MaLop = textLop.EditValue.ToString().Trim();
            var check = hocPhiDAL.CheckExistedLop(MaLop);
            Console.WriteLine(MaLop);
            if (check.Data)
            {
                var res = hocPhiDAL.INDSHPByLop(MaLop, "2021-2022", 1);

                if (res.Response.State == ResponseState.Fail)
                {
                    MessageBox.Show(res.Response.Message, "", MessageBoxButtons.OK);
                    return;
                }

                gcFee.DataSource = new BindingList<INHOCPHI>(res.Data);
                //rowsFeeNow = gvFee.RowCount;
            }

            else
            {
                MessageBox.Show("Mã lớp không tồn tại", "", MessageBoxButtons.OK);
            }
        }

        public void InitData()
        {
            
        }
    }
}
