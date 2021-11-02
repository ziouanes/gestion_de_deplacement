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
using System.Data.SqlClient;

namespace simpleDatabase7
{
    public partial class Rdlc_all_deplacement : Form
    {
        string _id;
        string _PersoneNome ;
        string   _gradeNome ;
        string _PersoneValue;
        string _gradeValue;

        string   _type_mession;
        string _destination   ;
        string _destination_ar;
        string _transport     ;
       public DateTime _date_depart ;
       public DateTime _date_retour;
        public Rdlc_all_deplacement(string id,string PersoneNome, string PersoneValue, string gradeNome, string gradeValue, string type_mession, string destination,string destination_ar, string transport, DateTime date_depart, DateTime date_retour)

        {
            InitializeComponent();
            _id = id;
           _PersoneNome = PersoneNome;
           _gradeNome   = gradeNome;
           _PersoneValue =  PersoneValue;
           _gradeValue  =  gradeValue;
        
           _type_mession =  type_mession;
           _destination  =  destination;

            _destination_ar = destination_ar;
            _transport =  transport;
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
                if ((d1.Value.Hour <= 08 && d2.Value.Hour >= 08) || (d1.Value.Hour <= 09 && d2.Value.Hour >= 09) || (d1.Value.Hour <= 10 && d2.Value.Hour >= 10) || (d1.Value.Hour <= 11 && d2.Value.Hour >= 11))
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

      public static  int newTaux = 0;
        
        private void Rdlc_all_deplacement_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(_id);

            if (int.Parse(_id) == 0)
            {
                button1.Visible = false;
            }
                TimeSpan difference = _date_retour - _date_depart;
            var days = difference.TotalDays;
            int day1 = System.Convert.ToInt32(System.Math.Floor(days));
         // MessageBox.Show("day ...." + day1.ToString());
           // MessageBox.Show("taux ...." + GetLocaleTaux(_date_depart, _date_retour).ToString());

           // var dates = new List<DateTime>();

           // for (var dt = _date_depart; dt <= _date_retour; dt = dt.AddDays(1))
           // {
           //     dates.Add(dt);
           // }
           //MessageBox.Show("days::::" + dates.Select(o=>o.ToString())) ;
            if (day1 < 0 || GetLocaleTaux(_date_depart, _date_retour)==0)
            {
                MessageBox.Show("Error date deferent", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
          
            else
            {
                if (GetLocaleTaux(_date_depart, _date_retour) < 0)
                {
                    Extra_Taux extra_Taux = new Extra_Taux();
                    extra_Taux.ShowDialog();
                    //MessageBox.Show(newTaux.ToString());

                }

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
               
                cmd.CommandText = "SELECT TYPE_ar from GRADE where id =" + _gradeValue + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                _gradeNome = row["TYPE_ar"].ToString();

                }
            Program.sql_con.Close();

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


                SqlCommand cmd1 = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT ar_NOM from Personne where id_Person =" + _PersoneValue + "";
            DataTable table1 = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
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
            reportParameters.Add(new ReportParameter("ReportParameter_DESTINATION", _destination_ar));
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
                if (int.Parse(_id) != 0)
                {

                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


                    using (SqlCommand updateCommand = new SqlCommand("UPDATE mission SET id_person = @id_person ,id_grade =@id_grade ,type_mession = @type_mession,DESTINATION  = @DESTINATION ,DESTINATION_ar = @DESTINATION_ar,date_depart = @date_depart , date_retour = @date_retour , Transport = @Transport  , nbr_Taux = @nbr_Taux  WHERE id = @id", Program.sql_con))
                    {
                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        updateCommand.Parameters.AddWithValue("@id_person", _PersoneValue);
                        updateCommand.Parameters.AddWithValue("@id_grade", _gradeValue);
                        updateCommand.Parameters.AddWithValue("@type_mession", _type_mession);
                        updateCommand.Parameters.AddWithValue("@DESTINATION", _destination);
                        updateCommand.Parameters.AddWithValue("@DESTINATION_ar", _destination_ar);
                        updateCommand.Parameters.AddWithValue("@date_depart", _date_depart);
                        updateCommand.Parameters.AddWithValue("@date_retour", _date_retour);
                        updateCommand.Parameters.AddWithValue("@Transport", _transport);
                        //updateCommand.Parameters.AddWithValue("@nbr_Taux", GetLocaleTaux(_date_depart, _date_retour));
                        if (GetLocaleTaux(_date_depart, _date_retour) < 0)
                        {
                            updateCommand.Parameters.AddWithValue("@nbr_Taux", newTaux);

                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@nbr_Taux", GetLocaleTaux(_date_depart, _date_retour));

                        }
                        updateCommand.Parameters.AddWithValue("@id", _id);



                        updateCommand.ExecuteNonQuery();
                        this.Alert("modifier Success", Form_Alert.enmType.Info);

                    }

                }
                else
                {

                
            

            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    using (SqlCommand insertCommand = new SqlCommand("INSERT INTO mission ([id_person],[id_grade],[type_mession],[DESTINATION],[DESTINATION_ar],[date_depart],[date_retour],[Transport],[nbr_Taux]) VALUES (@id_person,@id_grade,@type_mession,@DESTINATION,@DESTINATION_ar,@date_depart,@date_retour,@Transport,@nbr_Taux)", Program.sql_con))
                    {



                        insertCommand.Parameters.AddWithValue("@id_person", _PersoneValue);
                        insertCommand.Parameters.AddWithValue("@id_grade", _gradeValue);
                        insertCommand.Parameters.AddWithValue("@type_mession", _type_mession);
                        insertCommand.Parameters.AddWithValue("@DESTINATION", _destination);
                        insertCommand.Parameters.AddWithValue("@DESTINATION_ar", _destination_ar);

                        insertCommand.Parameters.AddWithValue("@date_depart", _date_depart);
                        insertCommand.Parameters.AddWithValue("@date_retour", _date_retour);

                        insertCommand.Parameters.AddWithValue("@Transport", _transport);
                        //string ss = GetLocaleTaux(_date_depart, _date_retour).ToString();
                        if (GetLocaleTaux(_date_depart, _date_retour) < 0)
                        {
                            insertCommand.Parameters.AddWithValue("@nbr_Taux", newTaux);

                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@nbr_Taux", GetLocaleTaux(_date_depart, _date_retour));

                        }







                        insertCommand.ExecuteNonQuery();
                        this.Alert("Enregistre Success", Form_Alert.enmType.Info);
                    }
                }

            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("sauvegarder à nouveau ?  ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                using (SqlCommand insertCommand = new SqlCommand("INSERT INTO mission ([id_person],[id_grade],[type_mession],[DESTINATION],[DESTINATION_ar],[date_depart],[date_retour],[Transport],[nbr_Taux]) VALUES (@id_person,@id_grade,@type_mession,@DESTINATION,@DESTINATION_ar,@date_depart,@date_retour,@Transport,nbr_Taux)", Program.sql_con))
                {



                    insertCommand.Parameters.AddWithValue("@id_person", _PersoneValue);
                    insertCommand.Parameters.AddWithValue("@id_grade", _gradeValue);
                    insertCommand.Parameters.AddWithValue("@type_mession", _type_mession);
                    insertCommand.Parameters.AddWithValue("@DESTINATION", _destination);
                    insertCommand.Parameters.AddWithValue("@DESTINATION_ar", _destination_ar);

                    insertCommand.Parameters.AddWithValue("@date_depart", _date_depart);
                    insertCommand.Parameters.AddWithValue("@date_retour", _date_retour);

                    insertCommand.Parameters.AddWithValue("@Transport", _transport);
                    //string ss = GetLocaleTaux(_date_depart, _date_retour).ToString();

                         if (GetLocaleTaux(_date_depart, _date_retour) < 0)
                         {
                        insertCommand.Parameters.AddWithValue("@nbr_Taux",newTaux);

                         }
                         else
                         {
                        insertCommand.Parameters.AddWithValue("@nbr_Taux", GetLocaleTaux(_date_depart, _date_retour));

                         }







                    insertCommand.ExecuteNonQuery();
                    this.Alert("Enregistre Success", Form_Alert.enmType.Info);
                    save = true;


                }
            }


           
            
                
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("sauvegarder à modification ?  ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Savedata();

            save = true;

            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
