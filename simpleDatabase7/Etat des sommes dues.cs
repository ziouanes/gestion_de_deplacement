using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using Dapper;
using System.Data.SqlClient;

namespace simpleDatabase7
{
    public partial class Etat_des_sommes_dues : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Etat_des_sommes_dues()
        {
            InitializeComponent();
        }

       // static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void PrintInvoice(int mession, List<mession> details)
        {
           // MessageBox.Show(mession.ToString());
            somme_due_Report report = new somme_due_Report();

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

            private void Etat_des_sommes_dues_Load(object sender, EventArgs e)
            {
            

            //_base_Donné_deplacementDataSet.GRADEDataTable g = new _base_Donné_deplacementDataSet.GRADEDataTable();
            //_base_Donné_deplacementDataSet.PersonneDataTable p = new _base_Donné_deplacementDataSet.PersonneDataTable();
            //_base_Donné_deplacementDataSet.missionDataTable m = new _base_Donné_deplacementDataSet.missionDataTable();

            //if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            //{
            //    SqlCommand cmd = Program.sql_con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    //cmd.CommandText = "SELECT GRADE.type,GRADE.Taux,Personne.Nom,Personne.CIN,Personne.RIB,mission.type_mession,mission.DESTINATION,mission.date_depart,mission.date_retour,mission.Transport FROM (Personne  inner join mission  on  Personne.id_Person = mission.id_person)inner join GRADE on GRADE.id = mission.id_grade where  mission.id = 3";
            //    cmd.CommandText = "select * from grade";
            //    cmd.ExecuteNonQuery();
            //     SqlDataAdapter ad   = new SqlDataAdapter(cmd);
            //   // da.Fill(_base_Donné_deplacementDataSet.GRADE);
             


            //    //}

            //}

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
