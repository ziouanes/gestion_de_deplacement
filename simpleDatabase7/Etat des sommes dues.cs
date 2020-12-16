using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    public partial class Etat_des_sommes_dues : Form
    {
        public Etat_des_sommes_dues()
        {
            InitializeComponent();
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
                da.Fill(_base_Donné_deplacementDataSet.GRADE);
             


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
