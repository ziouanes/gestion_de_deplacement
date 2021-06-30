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
        public Extra_Taux()
        {
            InitializeComponent();
        }

        private void rangeTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = rangeTrackBarControl1.Value.Maximum.ToString();
        }
    }
}