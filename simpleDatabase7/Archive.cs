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

namespace simpleDatabase7
{
    public partial class Archive : DevExpress.XtraEditors.XtraForm
    {
        public Archive()
        {
            InitializeComponent();
        }

        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

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

        private void selectData()
        {
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT  GRADE.type,GRADE.Taux,Personne.Nom,mission.id ,mission.type_mession , mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where mission.Archive = 1 and Personne.id_Person = {comboBox1.SelectedValue.ToString()}";

                DataTable dt1 = new DataTable();
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
                da1.Fill(dt1);
                gridControl1.DataSource = dt1;
            }
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            ExecuteQueryPersonne();



            this.gridView1.Columns["id"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<int> row = gridView1.GetSelectedRows().Where(c => c >= 0).ToList();

            row.ForEach(d =>
            {

                using (OleDbCommand updateCommand = new OleDbCommand("UPDATE mission SET Archive = ?  WHERE id = ?", Program.sql_con))
                {
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    updateCommand.Parameters.AddWithValue("@Archive", 0);


                    updateCommand.Parameters.AddWithValue("@id", gridView1.GetRowCellValue(d, "id").ToString());

                    updateCommand.ExecuteNonQuery();


                    //MessageBox.Show(gridView1.GetRowCellValue(d, "id").ToString());

                }
            }

            );
            selectData();

            this.Alert("DesArchive Success", Form_Alert.enmType.Info);


        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectData();
        }
    }
}