using DevExpress.XtraEditors;
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
    public partial class Extra_Taux : DevExpress.XtraEditors.XtraForm
    {
        int taux;
        public Extra_Taux()
        {
            InitializeComponent();

            
        }

        private void rangeTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = rangeTrackBarControl1.Value.Maximum.ToString();
        }

        private void Extra_Taux_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           taux  = rangeTrackBarControl1.Value.Maximum;
            Rdlc_all_deplacement.newTaux = taux;
            this.Close();
        }
    }
}