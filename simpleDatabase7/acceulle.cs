using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleDatabase7
{
    public partial class acceulle : Form
    {
        public acceulle()
        {
            InitializeComponent();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("mailto:contact@hamza-ziouane.tech");


        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ziouanes/gestion_de_deplacement");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deplacement dp = new deplacement();
            dp.ShowDialog();




































































































































































































































        }

        private void button7_Click(object sender, EventArgs e)
        {
            all_deplacement all = new all_deplacement();
            all.ShowDialog();

           

            //try
            //{
            //    using (Showallodm showALllodm = new Showallodm())
            //    { 
            //        showALllodm.ShowDialog();
            //    }
            //}
            //catch (Exception ex)
            //{
            //        MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    //this.Dispose();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void acceulle_Load(object sender, EventArgs e)
        {


        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void acceulle_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 6), this.DisplayRectangle);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_grade gd = new Update_grade();
            gd.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Person ps = new Person();
            ps.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vehicules vs = new vehicules();
            vs.ShowDialog();
        }
    }
}
