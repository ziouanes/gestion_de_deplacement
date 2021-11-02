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
using System.Data.SqlClient;


namespace simpleDatabase7
{
    public partial class special : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public special()
        {
            InitializeComponent();
        }
        public void PrintInvoice(int mession, List<messionspicial1> details)
        {
           // MessageBox.Show(mession.ToString());
            spicialReport report = new spicialReport();

            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;


            if (Program.sql_con.State == ConnectionState.Closed)
                Program.sql_con.Open();
            SqlCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT top 1 Personne.Nom,Personne.CIN,Personne.RIB,GRADE.type from (Personne  inner join mission  on  Personne.id_Person =mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where mission.id_person =  " + mession + "";
            DataTable table = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(table);
            foreach (DataRow row in table.Rows)
            {


                report.InitData(row["Nom"].ToString(), row["CIN"].ToString(), row["RIB"].ToString(), row["type"].ToString(), details);
                documentViewer1.DocumentSource = report;
                report.CreateDocument();

            }



        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void special_Load(object sender, EventArgs e)
        {

        }
    }
}