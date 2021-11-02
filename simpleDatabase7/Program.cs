using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new acceulle());
           Application.Run(new acceulle());

        }

        //static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //public static OleDbConnection sql_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + " \base_Donné-deplacement.accdb");
        // public static OleDbConnection sql_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb");
        // public static SqlConnection sql_con = new SqlConnection("Data Source=hamza;Initial Catalog=base_Donné_deplacement;Integrated Security=True;MultipleActiveResultSets = True;");

        public static SqlConnection sql_con = new SqlConnection(@"server =192.168.100.92;database = base_Donné-deplacement ; user id = log1; password=P@ssword1965** ;MultipleActiveResultSets =True;");


        // public static SQLiteConnection sql_con = new SQLiteConnection(@"Data Source=" + filePath + "/base_Donné-deplacement.db3");

        //  public static OleDbCommand sql_cmd;
        // public static OleDbDataReader db;


        //sqlserver
        public static SqlCommand sql_cmd;
        public static SqlDataReader db;
        public static SqlDataAdapter ad;

    }
}
