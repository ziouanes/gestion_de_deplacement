using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;

namespace simpleDatabase7
{
    public partial class spicialReport : DevExpress.XtraReports.UI.XtraReport
    {
        public spicialReport()
        {
            InitializeComponent();
        }
        public void InitData(string name, string cin, string rib, string grade, List<messionspicial1> details)
        {
            Parameters["parameter_name"].Value = name;
            Parameters["parameter_cin"].Value = cin;
            Parameters["parameter_rib"].Value = rib;
            Parameters["parameter_grade"].Value = grade;
            objectDataSource1.DataSource = details;

        }

        private void spicialReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

           
        }

            int page = 0;
        private void ExecuteQueryPersonne()
        {

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct page from [dbo].[messionspicialTEST]";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                page = int.Parse(row["page"].ToString());
                    
                

                }




            

            Program.sql_con.Close();
        }
        int counter = 0;
        
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            ExecuteQueryPersonne();
            //counter =page;
           // xrTableCell30.Text = counter.ToString()+page.ToString();
            if (counter == 1 && page ==1)
            {
                GroupFooter1.Visible = false;
            }
            else if(counter==page)
            {
                GroupFooter1.Visible = false;
            }
        }
    }
}
