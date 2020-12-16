namespace simpleDatabase7
{
    partial class Etat_des_sommes_dues
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.button2 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this._base_Donné_deplacementDataSet = new simpleDatabase7._base_Donné_deplacementDataSet();
            this.baseDonnédeplacementDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GRADEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GRADETableAdapter = new simpleDatabase7._base_Donné_deplacementDataSetTableAdapters.GRADETableAdapter();
            this.PersonneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonneTableAdapter = new simpleDatabase7._base_Donné_deplacementDataSetTableAdapters.PersonneTableAdapter();
            this.missionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.missionTableAdapter = new simpleDatabase7._base_Donné_deplacementDataSetTableAdapters.missionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._base_Donné_deplacementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDonnédeplacementDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRADEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(957, 660);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 28);
            this.button2.TabIndex = 213;
            this.button2.Text = "Fermer";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GRADEBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.PersonneBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.missionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "simpleDatabase7.Report_all.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 33);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1061, 621);
            this.reportViewer1.TabIndex = 212;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 667);
            this.panel2.TabIndex = 208;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1085, 27);
            this.panel3.TabIndex = 209;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1085, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 694);
            this.panel4.TabIndex = 210;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 694);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 10);
            this.panel1.TabIndex = 211;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel3;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this;
            this.bunifuDragControl2.Vertical = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(446, 660);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 32);
            this.button1.TabIndex = 214;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // _base_Donné_deplacementDataSet
            // 
            this._base_Donné_deplacementDataSet.DataSetName = "_base_Donné_deplacementDataSet";
            this._base_Donné_deplacementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseDonnédeplacementDataSetBindingSource
            // 
            this.baseDonnédeplacementDataSetBindingSource.DataSource = this._base_Donné_deplacementDataSet;
            this.baseDonnédeplacementDataSetBindingSource.Position = 0;
            // 
            // GRADEBindingSource
            // 
            this.GRADEBindingSource.DataMember = "GRADE";
            this.GRADEBindingSource.DataSource = this._base_Donné_deplacementDataSet;
            // 
            // GRADETableAdapter
            // 
            this.GRADETableAdapter.ClearBeforeFill = true;
            // 
            // PersonneBindingSource
            // 
            this.PersonneBindingSource.DataMember = "Personne";
            this.PersonneBindingSource.DataSource = this._base_Donné_deplacementDataSet;
            // 
            // PersonneTableAdapter
            // 
            this.PersonneTableAdapter.ClearBeforeFill = true;
            // 
            // missionBindingSource
            // 
            this.missionBindingSource.DataMember = "mission";
            this.missionBindingSource.DataSource = this._base_Donné_deplacementDataSet;
            // 
            // missionTableAdapter
            // 
            this.missionTableAdapter.ClearBeforeFill = true;
            // 
            // Etat_des_sommes_dues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 704);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Etat_des_sommes_dues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etat_des_sommes_dues";
            this.Load += new System.EventHandler(this.Etat_des_sommes_dues_Load);
            ((System.ComponentModel.ISupportInitialize)(this._base_Donné_deplacementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDonnédeplacementDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRADEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource baseDonnédeplacementDataSetBindingSource;
        private System.Windows.Forms.BindingSource GRADEBindingSource;
        private System.Windows.Forms.BindingSource PersonneBindingSource;
        private System.Windows.Forms.BindingSource missionBindingSource;
        private _base_Donné_deplacementDataSetTableAdapters.GRADETableAdapter GRADETableAdapter;
        private _base_Donné_deplacementDataSetTableAdapters.PersonneTableAdapter PersonneTableAdapter;
        private _base_Donné_deplacementDataSetTableAdapters.missionTableAdapter missionTableAdapter;
        public _base_Donné_deplacementDataSet _base_Donné_deplacementDataSet;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}