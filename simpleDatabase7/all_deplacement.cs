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
using DevExpress.Utils;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace simpleDatabase7
{
    public partial class all_deplacement : XtraForm
    {
        public all_deplacement()
        {
            InitializeComponent();
        }
        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        //public DataTable GetData()
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("IsSelected", typeof(Boolean));
        //    table.Columns.Add("ID", typeof(String));
        //    for (int i = 0; i < 10; i++)
        //        table.Rows.Add(new object[] { i % 2 == 0 ? true : false, "Item " + i.ToString() });
        //    return table;
        //}

        private void all_deplacement_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            //gridControl1.DataSource = GetData();
           

            this.gridView1.Columns["id"].Visible = false;
            //RepositoryItemCheckEdit repositoryCheckEdit1 = gridControl1.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            //repositoryCheckEdit1.ValueChecked = "True";
            //repositoryCheckEdit1.ValueUnchecked = "False";
            //gridView1.Columns["Payé"].ColumnEdit = repositoryCheckEdit1;


            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            //gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            //using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            //{
            //    if (db.State == ConnectionState.Closed)
            //        db.Open();
            //    string query = $"SELECT  mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade";
            //    messionBindingSource.DataSource = db.Query<People>(query, commandType: CommandType.Text);
            //}
            ExecuteQueryPersonne();
        }

        //setexecutequery
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
            comboBox1.Properties.DataSource = dt;
            comboBox1.Properties.ValueMember = "id_Person";
            comboBox1.Properties.DisplayMember = "Nom";
            comboBox1.ItemIndex = -1;

            comboBox1.Properties.PopulateColumns();
            comboBox1.Properties.Columns[0].Visible = false;
            comboBox1.Properties.Columns[2].Visible = false;
            comboBox1.Properties.Columns[3].Visible = false;


            Program.sql_con.Close();

            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           // comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void selectData() {
            using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

            {
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT  GRADE.type,GRADE.Taux,Personne.Nom,mission.id ,mission.type_mession , mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where mission.Archive = 0 and Personne.id_Person = {comboBox1.EditValue.ToString()} order by mission.date_depart desc";

                DataTable dt1 = new DataTable();
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
                da1.Fill(dt1);
                gridControl1.DataSource = dt1;
            }
        } 
       

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectData();


        }

        private void Afficher_invoice_Click(object sender, EventArgs e)
        {

           // People obj = peopleBindingSource3.Current as People;

            if (comboBox1.ItemIndex != -1)
            {
                using (OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + "/base_Donné-deplacement.accdb"))

                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = $"SELECT mission.date_depart as date_depart,mission.date_retour as date_retour , mission.DESTINATION as DESTINATION , GRADE.Taux as Taux_Fix , mission.nbr_Taux as Taux , mission.date_depart as date_depart_H , mission.date_retour as date_retour_H from(Personne  inner join mission  on  Personne.id_Person = mission.id_person) inner join GRADE on GRADE.id = mission.id_grade where mission.Archive = 0 and Personne.id_Person = { comboBox1.EditValue.ToString()} order by mission.date_depart asc";
                    List<mession> details = db.Query<mession>(query, commandType: CommandType.Text).ToList();
                    using (Etat_des_sommes_dues frm = new Etat_des_sommes_dues())
                    {
                        frm.PrintInvoice(int.Parse(comboBox1.EditValue.ToString()), details);
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();

                    }
                }


            }
            else { MessageBox.Show("no data"); }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //var gridView = sender as GridView;
            //gridView.SelectRow(gridView1.FocusedRowHandle);
            //gridControl1 selectedRow = dataGridView1.Rows[selectedrowindex];

            //string ss = gridView1.


            //MessageBox.Show();

        }

        private void barButton_supprimer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var row = gridView1.FocusedRowHandle;
            //gridView1.SelectRows[gridView1.Rows.Count - 1].Cells[colID].Selected = true;


            string value = gridView1.GetFocusedDataRow()["id"].ToString();

            //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //args.AutoCloseOptions.Delay = 2000;
            //args.Caption = "suppression";
            //args.Text = "supprimer success.";
            //args.Buttons = new DialogResult[] { DialogResult.OK};
            


            using (OleDbCommand deleteCommand = new OleDbCommand("DELETE FROM mission WHERE id = ?", Program.sql_con))
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                deleteCommand.Parameters.AddWithValue("@id", value);

                deleteCommand.ExecuteNonQuery();
                

               
            }
            gridView1.DeleteRow(row);
            //XtraMessageBox.Show(args).ToString();

        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        protected BandedGridView _view;


        private void button1_Click_1(object sender, EventArgs e)
        {
            //gridView1.OptionsSelection.CheckBoxSelectorField = "IsSelected";

            List<int> row = gridView1.GetSelectedRows().Where(c => c >= 0).ToList();

            row.ForEach(d =>
                 {

                     using (OleDbCommand updateCommand = new OleDbCommand("UPDATE mission SET Archive = ?  WHERE id = ?", Program.sql_con))
                     {
                         if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                         updateCommand.Parameters.AddWithValue("@Archive", 1);


                         updateCommand.Parameters.AddWithValue("@id", gridView1.GetRowCellValue(d, "id").ToString());

                         updateCommand.ExecuteNonQuery();


                         //MessageBox.Show(gridView1.GetRowCellValue(d, "id").ToString());

                     }
                 }

            );
            selectData();

            this.Alert("Archive Success", Form_Alert.enmType.Success);


        
                
            
        }

             private void gridView1_MouseUp(object sender, MouseEventArgs e)
             {

                 if (e.Button != MouseButtons.Right) return;
                 var rowM = gridView1.FocusedRowHandle;
                 var focusRowView = (DataRowView)gridView1.GetFocusedRow();
                 if (focusRowView == null || focusRowView.IsNew) return;
                 if (rowM >= 0)
                     popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                 else
                     popupMenu1.HidePopup();


             }       

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.FocusedRowHandle;
            //gridView1.SelectRows[gridView1.Rows.Count - 1].Cells[colID].Selected = true;


            string value = gridView1.GetFocusedDataRow()["id"].ToString();
            update_deplacement update = new update_deplacement(value);
                update.ShowDialog();
            selectData();


        }

        private void Ovrire_Click(object sender, EventArgs e)
        {
            if (comboBox1.ItemIndex != -1)
            {

            selectData();

            }
        }

        private void comboBox1_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.ItemIndex != -1)
            {

                selectData();

            }
        }
    }
}
