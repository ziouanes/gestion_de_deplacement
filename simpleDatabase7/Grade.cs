using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    public partial class Grade : Form
    {
        public Grade()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string txtQuery)
        {
            //Program.SetConnection();
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            Program.sql_cmd = Program.sql_con.CreateCommand();
            Program.sql_cmd.CommandText = txtQuery;
            Program.sql_cmd.ExecuteNonQuery();
            Program.sql_con.Close();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }



        private void Grade_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                Program.sql_cmd = new OleDbCommand("SELECT * from GRADE where type =  '" + textBox8.Text + "'", Program.sql_con);
                Program.db = Program.sql_cmd.ExecuteReader();
                if (Program.db.HasRows)
                {

                    MessageBox.Show("ce Grade est déjà ajouter");
                }

                else if (MessageBox.Show("Voulez-vous vraiment ajouter un nouveau GRADE   " + textBox8.Text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string textquery = "INSERT INTO GRADE(type,Taux,TYPE_ar)VALUES('" + textBox8.Text + "','" + spinEdit1.Text + "','" + textBox1.Text+"')";
                    ExecuteQuery(textquery);
                    this.Alert("ajouter Grade Succès", Form_Alert.enmType.Success);
                    textBox8.Text = "";
                    spinEdit1.Text = "";
                    textBox8.Text = "";




                }



            }
            else
            {
                this.Alert("Veuillez ajouter un nouveau Grade", Form_Alert.enmType.Warning);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
