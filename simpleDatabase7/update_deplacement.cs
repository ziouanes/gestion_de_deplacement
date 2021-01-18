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
    public partial class update_deplacement : Form
    {
           static string id_deplacemet = "";
        public update_deplacement(string value)
        {

            InitializeComponent();
            id_deplacemet = value;
           
        }

        //alert enum
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void loadData()
        {
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT id_person ,  id_grade , type_mession,DESTINATION,DESTINATION_ar,date_depart,date_retour,Transport from mission where id =" + id_deplacemet + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    comboBox1.SelectedValue = row["id_person"].ToString();
                    comboBox2.SelectedValue = row["id_grade"].ToString();
                    textBox1.Text = row["type_mession"].ToString();
                    textBox4.Text = row["DESTINATION_ar"].ToString();
                    textBox2.Text = row["DESTINATION"].ToString();
                    textBox3.Text = row["Transport"].ToString();
                    datePicker1.Value = (DateTime)row["date_depart"];
                    datePicker2.Value = (DateTime)row["date_retour"];
                    

                }

            }
               // MessageBox.Show(id_deplacemet);
        }
            private void update_deplacement_Load(object sender, EventArgs e)
        {
            datePicker1.CustomFormat = "yyyy-MM-dd | HH:mm";
            datePicker2.CustomFormat = "yyyy-MM-dd | HH:mm";
            ExecuteQueryPersonne();
            ExecuteQuerygrade();
            loadData();
        }
        private void ExecuteQuerygrade()
        {
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


            OleDbCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from GRADE ORDER BY type";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "type";
            comboBox2.SelectedIndex = -1;
            Program.sql_con.Close();


            //comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ExecuteQueryPersonne()
        {

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            OleDbCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from Personne ORDER BY Nom";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id_Person";
            comboBox1.DisplayMember = "Nom";
            comboBox1.SelectedIndex = -1;

            Program.sql_con.Close();

            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
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
                string destination_ar = textBox4.Text;
                string transport = textBox3.Text;


                DateTime date_depart = Convert.ToDateTime(datePicker1.Value.ToString());

                DateTime date_retour = Convert.ToDateTime(datePicker2.Value.ToString());



                Rdlc_all_deplacement deplacement = new Rdlc_all_deplacement(id_deplacemet,PersoneNome, PersoneValue, gradeNome, gradeValue, type_mession, destination,destination_ar, transport, date_depart, date_retour);
                deplacement.ShowDialog();
                this.Close();



            }

        }
    }
}
