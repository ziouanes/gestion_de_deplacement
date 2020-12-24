using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Dapper;
using DevExpress.XtraEditors;

namespace simpleDatabase7
{
    public partial class all_deplacement : XtraForm
    {
        public all_deplacement()
        {
            InitializeComponent();
        }
        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        private void all_deplacement_Load(object sender, EventArgs e)
        {
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = $"SELECT  mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade";
                messionBindingSource.DataSource = db.Query<People>(query, commandType: CommandType.Text);
            }
            ExecuteQueryPersonne();
        }

        //setexecutequery
        private void ExecuteQueryPersonne()
        {

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            OleDbCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from Personne";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id_Person";
            comboBox1.DisplayMember = "Nom";
            comboBox1.SelectedIndex = -1;

            Program.sql_con.Close();

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where Personne.id_Person = {comboBox1.SelectedValue.ToString()}";

                DataTable dt1 = new DataTable();
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
                da1.Fill(dt1);
                gridControl1.DataSource = dt1;
            }
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }

        private void Afficher_invoice_Click(object sender, EventArgs e)
        {

           // People obj = peopleBindingSource3.Current as People;

            if (comboBox1.SelectedIndex != -1)
            {
                using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = $"SELECT  mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where Personne.id_Person = { comboBox1.SelectedValue.ToString()}";
                    List<mession> details = db.Query<mession>(query, commandType: CommandType.Text).ToList();
                    using (Etat_des_sommes_dues frm = new Etat_des_sommes_dues())
                    {
                        frm.PrintInvoice(int.Parse(comboBox1.SelectedValue.ToString()), details);
                        frm.ShowDialog();
                        frm.WindowState = FormWindowState.Maximized;

                    }
                }


            }
            else { MessageBox.Show("no data"); }
        }
    }
}
