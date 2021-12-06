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
    public partial class FormAddLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormAddLogin()
        {
            InitializeComponent();
            pn.Controls.Clear();
            pn.Controls.Add(new UCAddLogin());
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }
    }
}