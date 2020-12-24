using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace simpleDatabase7
{
    public partial class somme_due_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public somme_due_Report()
        {
            InitializeComponent();
        }

        public void InitData(string name, string cin, string rib, string grade, List<mession> details)
        {
            Parameters["parameter_name"].Value = name;
            Parameters["parameter_cin"].Value = cin;
            Parameters["parameter_rib"].Value = rib;
            Parameters["parameter_grade"].Value = grade;
            bindingSource1.DataSource = details;

        }


    }
}
