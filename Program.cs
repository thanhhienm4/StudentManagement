using StudentManagement.Model;
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
        public static string username { get; set; }
        public static string fullName { get; set; }
        public static string group { get; set; }

        public static string loginRemote = "HTKN";
        public static string passwordRemote = "123456";
        public static string loginStudent = "SV";
        public static string passwordStudent = "123456";
        public static string currentServer { get; set; }

        public static SqlDataReader dataReader { get; set; }
        public static SqlConnection conn { get; set; } 
        public static List<ServerInfo> servers { get; set; }
        public static string conmStr { get; set; }
        public static FormMain formMain;
       

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
