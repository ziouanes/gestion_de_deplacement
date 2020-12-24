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

namespace simpleDatabase7
{
    public partial class Etat_des_sommes_dues : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Etat_des_sommes_dues()
        {
            InitializeComponent();
        }

        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public void PrintInvoice(int mession, List<mession> details)
        {
            somme_due_Report report = new somme_due_Report();

            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                OleDbCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Personne.Nom,Personne.CIN,Personne.RIB,GRADE.type from (Personne  inner join mission  on  Personne.id_Person =mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where mission.id_person =  " + mession + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {


                    report.InitData(row["Nom"].ToString(), row["CIN"].ToString(), row["RIB"].ToString(), row["type"].ToString(), details);
                    documentViewer1.DocumentSource = report;
                    report.CreateDocument();

                }


            }
        }

            private void Etat_des_sommes_dues_Load(object sender, EventArgs e)
            {
            

            //_base_Donné_deplacementDataSet.GRADEDataTable g = new _base_Donné_deplacementDataSet.GRADEDataTable();
            //_base_Donné_deplacementDataSet.PersonneDataTable p = new _base_Donné_deplacementDataSet.PersonneDataTable();
            //_base_Donné_deplacementDataSet.missionDataTable m = new _base_Donné_deplacementDataSet.missionDataTable();

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "SELECT GRADE.type,GRADE.Taux,Personne.Nom,Personne.CIN,Personne.RIB,mission.type_mession,mission.DESTINATION,mission.date_depart,mission.date_retour,mission.Transport FROM (Personne  inner join mission  on  Personne.id_Person = mission.id_person)inner join GRADE on GRADE.id = mission.id_grade where  mission.id = 3";
                cmd.CommandText = "select * from grade";
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
               // da.Fill(_base_Donné_deplacementDataSet.GRADE);
             


                //}

            }

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
