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
using System.Data.SqlClient;

namespace simpleDatabase7
{
    public partial class update_personne : Form
    {
        public update_personne()
        {
            InitializeComponent();
        }

        private void update_personne_Load(object sender, EventArgs e)
        {

            ExecuteQuery();


        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        //setexecutequery
        private void ExecuteQuery()
        {

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            SqlCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from Personne ORDER BY Nom";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id_Person";
            comboBox1.DisplayMember = "Nom";
            comboBox1.SelectedIndex = -1;
            textBoxrib.Text = "";
            textBoxcin.Text = "";
            textBoxarnom.Text = "";
            Program.sql_con.Close();

            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = "1";
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            if (comboBox1.SelectedIndex > -1)
            {
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                s = comboBox1.SelectedValue.ToString();
                cmd.CommandText = "SELECT CIN ,  RIB , ar_Nom from Personne where id_Person =" + s + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    textBoxcin.Text = row["CIN"].ToString();
                    textBoxrib.Text = row["RIB"].ToString();
                    textBoxarnom.Text = row["ar_Nom"].ToString();


                }




            }

            Program.sql_con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCommand updateCommand = new SqlCommand("UPDATE Personne SET CIN = @CIN, ar_Nom = @ar_Nom , RIB = @RIB WHERE id_Person = @id_Person", Program.sql_con))
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                updateCommand.Parameters.AddWithValue("@CIN", textBoxcin.Text);
                updateCommand.Parameters.AddWithValue("@RIB", textBoxrib.Text);
                updateCommand.Parameters.AddWithValue("@ar_Nom", textBoxarnom.Text);

                updateCommand.Parameters.AddWithValue("@id_Person", comboBox1.SelectedValue.ToString());

                updateCommand.ExecuteNonQuery();

                ExecuteQuery();

                this.Alert("Ajouter Taux Success", Form_Alert.enmType.Success);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Personne WHERE id_Person = @id_Person", Program.sql_con))
            {
               
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                deleteCommand.Parameters.AddWithValue("@id_Person", comboBox1.SelectedValue);

                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("done");
                ExecuteQuery();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
