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
    public partial class deplacement : Form
    {
        public deplacement()
        {
            InitializeComponent();
        }

        //alert enum
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }


        private void deplacement_Load(object sender, EventArgs e)
        {
            datePicker1.CustomFormat = "yyyy-MM-dd | HH:mm";
            datePicker2.CustomFormat = "yyyy-MM-dd | HH:mm";



            ExecuteQueryPersonne();
            ExecuteQuerygrade();

        }

        //setexecutequery
        private void ExecuteQuerygrade()
        {
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


            OleDbCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from GRADE";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "type";
            comboBox2.SelectedIndex = -1;
            Program.sql_con.Close();


            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void button3_Click(object sender, EventArgs e)
        {
            all_deplacement all = new all_deplacement();
            all.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (comboBox1.SelectedIndex!=-1 || comboBox2.SelectedIndex!=-1)


            //    {
            //        this.Alert(" sélectionnez la ligne à mettre à jour", Form_Alert.enmType.Warning);
            //    }
            //    else
            //    {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1||  comboBox2.SelectedIndex == -1)
            {
                this.Alert("sélectionnez la ligne à mettre à jour", Form_Alert.enmType.Error);
            }
            else
            {

                        string PersoneNome = comboBox1.Text;
                        string gradeNome = comboBox2.Text;
                        string PersoneValue = comboBox1.SelectedValue.ToString();
                        string gradeValue = comboBox2.SelectedValue.ToString();

                        string type_mession = textBox1.Text;
                        string destination = textBox2.Text;
                        string transport = textBox3.Text;
                       

                DateTime date_depart = Convert.ToDateTime(datePicker1.Value.ToString());

                DateTime date_retour = Convert.ToDateTime(datePicker2.Value.ToString());



                Rdlc_all_deplacement deplacement = new Rdlc_all_deplacement(PersoneNome, PersoneValue, gradeNome, gradeValue, type_mession, destination, transport, date_depart, date_retour);
                deplacement.ShowDialog();
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;

               

            }
                        
                        
                        
                    


                //}
            

        }

        private void dateTimePicker1_onValueChanged(object sender, EventArgs e)
        {

        }
    }
}
