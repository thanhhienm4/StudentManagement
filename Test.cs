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
    public partial class Test : DevExpress.XtraEditors.XtraUserControl
    {
        public Test()
        {
            InitializeComponent();
            gridControl1.DataSource = listDataSource; // lay vao
            listDataSource = gridControl1.DataSource 
        }
    }
}
