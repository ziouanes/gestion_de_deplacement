﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    public partial class Update_grade : Form
    {
        public Update_grade()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void Update_grade_Load(object sender, EventArgs e)
        {

            ExecuteQuery();


        }

        //setexecutequery
        private void ExecuteQuery()
        {
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


            SqlCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from GRADE ORDER BY type";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "type";
            //comboBox1.SelectedIndex = -1;
            Program.sql_con.Close();


            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == ""|| comboBox1.SelectedIndex == -1)
            {
                this.Alert("champs obligatoires", Form_Alert.enmType.Error);
            }

            else
            {
                using (SqlCommand updateCommand = new SqlCommand("UPDATE GRADE SET Taux = @Taux WHERE id = @id", Program.sql_con))
                {
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    updateCommand.Parameters.AddWithValue("@Taux", textBox6.Text);
                    updateCommand.Parameters.AddWithValue("@id", comboBox1.SelectedValue.ToString());

                    updateCommand.ExecuteNonQuery();
                   
                    ExecuteQuery();
                }


                this.Close();
                this.Alert("Ajouter Taux Success", Form_Alert.enmType.Success);




            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
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
                cmd.CommandText = "SELECT Taux from GRADE where id =" + s + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    textBox6.Text = row["Taux"].ToString();

                }




            }

            Program.sql_con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grade grade = new Grade();
            grade.ShowDialog();
        }
    }
}
