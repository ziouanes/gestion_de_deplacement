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
            textBox4.Text = "";
            textBox6.Text = "";
            Program.sql_con.Close();

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = "1";
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            if (comboBox1.SelectedIndex > -1)
            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                s = comboBox1.SelectedValue.ToString();
                cmd.CommandText = "SELECT CIN ,  RIB from Personne where id_Person =" + s + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    textBox6.Text = row["CIN"].ToString();
                    textBox4.Text = row["RIB"].ToString();


                }




            }

            Program.sql_con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbCommand updateCommand = new OleDbCommand("UPDATE Personne SET CIN = ?, RIB = ? WHERE id_Person = ?", Program.sql_con))
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                updateCommand.Parameters.AddWithValue("@CIN", textBox6.Text);
                updateCommand.Parameters.AddWithValue("@RIB", textBox4.Text);
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
            using (OleDbCommand deleteCommand = new OleDbCommand("DELETE FROM Personne WHERE id_Person = ?", Program.sql_con))
            {
               
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                deleteCommand.Parameters.AddWithValue("@id_Person", comboBox1.SelectedValue);

                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("done");
                ExecuteQuery();
            }

        }
    }
}
