using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    public partial class Person : Form
    {
        public Person()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void ExecuteQuery(string txtQuery)
        {
            //Program.SetConnection();
            Program.sql_con.Open();
            Program.sql_cmd = Program.sql_con.CreateCommand();
            Program.sql_cmd.CommandText = txtQuery;
            Program.sql_cmd.ExecuteNonQuery();
            Program.sql_con.Close();
        }


        private void Person_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_personne update_Personne = new update_personne();
            update_Personne.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxfrnom.Text != "")
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                Program.sql_cmd = new SqlCommand("SELECT * from Personne where Nom =  '" + textBoxfrnom.Text + "'", Program.sql_con);
                Program.db = Program.sql_cmd.ExecuteReader();
                if (Program.db.HasRows)
                {

                    MessageBox.Show("ce Grade est déjà ajouter");
                }

                else if (MessageBox.Show("Voulez-vous vraiment ajouter un nouveau GRADE   " + textBoxfrnom.Text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string textquery = "INSERT INTO Personne (Nom,CIN,RIB,ar_Nom) VALUES ('" + textBoxfrnom.Text + "','" + textBoxcin.Text + "','" + textBoxrib.Text +"','" + textBoxarnome.Text +"')";
                    ExecuteQuery(textquery);
                    this.Alert("ajouter Personne Succès", Form_Alert.enmType.Success);
                    textBoxfrnom.Text = "";
                    textBoxcin.Text = "";
                    textBoxrib.Text = "";
                    textBoxarnome.Text = "";



                }



            }
            else
            {
                this.Alert("Veuillez ajouter un nouveau Personne", Form_Alert.enmType.Warning);
            }

        }
    }
}
