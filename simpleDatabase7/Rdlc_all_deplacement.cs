using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;


namespace simpleDatabase7
{
    public partial class Rdlc_all_deplacement : Form
    {
        string _PersoneNome ;
        string   _gradeNome ;
        string _PersoneValue;
        string _gradeValue;

        string   _type_mession;
        string _destination   ;
        string _transport     ;
       public DateTime _date_depart ;
       public DateTime _date_retour;
        public Rdlc_all_deplacement(string PersoneNome, string PersoneValue, string gradeNome, string gradeValue, string type_mession, string destination, string transport, DateTime date_depart, DateTime date_retour)

        {
            InitializeComponent();

           _PersoneNome = PersoneNome;
           _gradeNome   = gradeNome;
           _PersoneValue =  PersoneValue;
           _gradeValue  =  gradeValue;
        
           _type_mession =  type_mession;
           _destination  =  destination;
           _transport     =  transport;
        _date_depart =  date_depart;
        _date_retour = date_retour;
        }

        public static string GetLocaleTime(DateTime? date)
        {
            string time1 = "";

            if (date.Value.Hour == 1 || date.Value.Hour == 13)
            {
                time1 = " الواحدة";

            }
            else if(date.Value.Hour == 2 || date.Value.Hour ==14)
            {
                time1 = " الثانية ";
            }
            else if (date.Value.Hour == 3 || date.Value.Hour == 15)

            {
                time1 = " الثالثة";
            }
            else if (date.Value.Hour == 4 || date.Value.Hour == 16)
            {
                time1 = " الرابعة";
            }
            else if (date.Value.Hour == 5 || date.Value.Hour == 17)
            {
                time1 = " الخامسة";
            }
            else if (date.Value.Hour == 6 || date.Value.Hour == 18)
            {
                time1 = " السادسة";
            }
            else if (date.Value.Hour == 7 || date.Value.Hour == 19)
            {
                time1 = " السابعة";
            }
            else if (date.Value.Hour == 8 || date.Value.Hour == 20)
            {
                time1 = " التامنة";
            }
            else if (date.Value.Hour == 9 || date.Value.Hour == 21)
            {
                time1 = " التاسعة";
            }
            else if (date.Value.Hour == 10 || date.Value.Hour == 22)
            {
                time1 = " العاشرة";
            }
            else if (date.Value.Hour == 11 || date.Value.Hour == 23)
            {
                time1 = " الحادية عشرة";
            }
            else if (date.Value.Hour == 12 || date.Value.Hour == 00)
            {
                time1 = " الثانية عشرة";
            }
           


            return time1;
        }

        public static string GetLocaleDate(DateTime? date)
        {
            string AMPM = "";
           
                if (date.Value.Hour > 12 && date.Value.Hour <= 16)
                {
                    AMPM = " بعد الزوال ";

                }
                else if (date.Value.Hour > 17 && date.Value.Hour <= 23)

                {
                    AMPM = " مساءً ";
                }
                else
                {
                    AMPM = " صباحا ";
                }
            
           
           return AMPM;
        }


        public static int allday = 0;

        public static int GetLocaleTaux(DateTime? d1 , DateTime? d2)
        {
            int q = 0;


            allday =  d2.Value.Day - d1.Value.Day;



            if (allday == 0)
            {
                if ((d1.Value.Hour <= 11 && d2.Value.Hour >= 11) || (d1.Value.Hour <= 12 && d2.Value.Hour >= 12) || (d1.Value.Hour <= 13 && d2.Value.Hour >= 13) || (d1.Value.Hour <= 14 && d2.Value.Hour >= 14))
                {
                    q++;
                }
                if ((d1.Value.Hour <= 18 && d2.Value.Hour >= 18) || (d1.Value.Hour <= 19 && d2.Value.Hour >= 19) || (d1.Value.Hour <= 20 && d2.Value.Hour >= 20) || (d1.Value.Hour <= 21 && d2.Value.Hour >= 21))
                {
                    q++;
                }




            }

            //

            else if (allday == 1)


            {

                //day1

                q++;

                if ((d1.Value.Hour <= 11) || (d1.Value.Hour <= 12) || (d1.Value.Hour <= 13) || (d1.Value.Hour <= 14))
                {
                    q++;
                }
                if ((d1.Value.Hour <= 18) || (d1.Value.Hour <= 19) || (d1.Value.Hour <= 20) || (d1.Value.Hour <= 21))
                {
                    q++;
                }

                //day2


                if ((d2.Value.Hour >= 11) || (d2.Value.Hour >= 12) || (d2.Value.Hour >= 13) || (d2.Value.Hour >= 14))
                {
                    q++;
                }
                if ((d2.Value.Hour >= 18) || (d2.Value.Hour >= 19) || (d2.Value.Hour >= 20) || (d2.Value.Hour >= 21))
                {
                    q++;
                }

                //end_day2

            }
            else if (allday > 1)

            {

                //first_day
                q++;

                if ((d1.Value.Hour <= 11) || (d1.Value.Hour <= 12) || (d1.Value.Hour <= 13) || (d1.Value.Hour <= 14))
                {
                    q++;
                }
                if ((d1.Value.Hour <= 18) || (d1.Value.Hour <= 19) || (d1.Value.Hour <= 20) || (d1.Value.Hour <= 21))
                {
                    q++;
                }

                //last_day


                if ((d2.Value.Hour >= 11) || (d2.Value.Hour >= 12) || (d2.Value.Hour >= 13) || (d2.Value.Hour >= 14))
                {
                    q++;
                }
                if ((d2.Value.Hour >= 18) || (d2.Value.Hour >= 19) || (d2.Value.Hour >= 20) || (d2.Value.Hour >= 21))
                {
                    q++;
                }

                //day_begin
                for(int i = 1; i < allday; i++)
                {
                    q+=3;
                }

            }
            else
            {
                return q=-1;
            }


           




            return q;
            
        }

        
        private void Rdlc_all_deplacement_Load(object sender, EventArgs e)
        {
            TimeSpan difference = _date_retour - _date_depart;
            var days = difference.TotalDays;
            int day1 = System.Convert.ToInt32(System.Math.Floor(days));
           //MessageBox.Show("day ...." + day1.ToString());
            MessageBox.Show("taux ...." + GetLocaleTaux(_date_depart, _date_retour).ToString());

            if (day1 < 0 || GetLocaleTaux(_date_depart, _date_retour)==0)
            {
                MessageBox.Show("Error date deferent", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            
            
                OleDbCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
               
                cmd.CommandText = "SELECT TYPE_ar from GRADE where id =" + _gradeValue + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                _gradeNome = row["TYPE_ar"].ToString();

                }
            Program.sql_con.Close();

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


            OleDbCommand cmd1 = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT ar_NOM from Personne where id_Person =" + _PersoneValue + "";
            DataTable table1 = new DataTable();
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
            da.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                _PersoneNome = row["ar_NOM"].ToString();

            }
            Program.sql_con.Close();



            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_name", _PersoneNome));
            reportParameters.Add(new ReportParameter("ReportParameter_Grade", _gradeNome));
            reportParameters.Add(new ReportParameter("ReportParameter_type_mession", _type_mession));
            reportParameters.Add(new ReportParameter("ReportParameter_DESTINATION", _destination));
            reportParameters.Add(new ReportParameter("ReportParameter_TRANSPORT", _transport));
            reportParameters.Add(new ReportParameter("ReportParameter_Date_depart",  _date_depart.ToString("MMMM  ", new System.Globalization.CultureInfo("ar-MA"))+ _date_depart.ToString("yyyy", new System.Globalization.CultureInfo("ar-MA")) +  " على الساعــة " + GetLocaleTime(_date_depart) + GetLocaleDate(_date_depart)));
            reportParameters.Add(new ReportParameter("ReportParameter_date_day", _date_depart.ToString("dd", new System.Globalization.CultureInfo("ar-MA"))));
            reportParameters.Add(new ReportParameter("ReportParameter_date_retour", _date_retour.ToString("MMMM  ", new System.Globalization.CultureInfo("ar-MA")) + _date_depart.ToString("yyyy", new System.Globalization.CultureInfo("ar-MA")) + " على الساعــة " + GetLocaleTime(_date_retour) + GetLocaleDate(_date_retour)));
            reportParameters.Add(new ReportParameter("ReportParameter_day_retour", _date_retour.ToString("dd", new System.Globalization.CultureInfo("ar-MA"))));


            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
                
            this.reportViewer1.RefreshReport();


            }



            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (save == false)
            {
            if (MessageBox.Show("sauvegarder les modifications ?  ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    Savedata();
                    this.Close();
                }
               

                

            }
                this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        bool save = false;

        public void Savedata()
        {
            if (save == false)
            {
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            using (OleDbCommand insertCommand = new OleDbCommand("INSERT INTO mission ([id_person],[id_grade],[type_mession],[DESTINATION],[date_depart],[date_retour],[Transport]) VALUES (?,?,?,?,?,?,?)", Program.sql_con))
            {



                insertCommand.Parameters.AddWithValue("@id_person", _PersoneValue);
                insertCommand.Parameters.AddWithValue("@id_grade", _gradeValue);
                insertCommand.Parameters.AddWithValue("@type_mession", _type_mession);
                insertCommand.Parameters.AddWithValue("@DESTINATION", _destination);
                insertCommand.Parameters.AddWithValue("@date_depart", _date_depart);
                insertCommand.Parameters.AddWithValue("@date_retour", _date_retour);

                insertCommand.Parameters.AddWithValue("@Transport", _transport);
                //    string ss = GetLocaleTaux(_date_depart, _date_retour).ToString();
                //insertCommand.Parameters.AddWithValue("@Taux", ss) ;





                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("good");
            }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Savedata();
                save = true;
                
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
