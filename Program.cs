using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    static class Program
    {
        public static string serverName { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
        //public static string connectionString { get; set; } 
        public static SqlConnection conn { get; set; } 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FromLogin());
        }
    }
}
