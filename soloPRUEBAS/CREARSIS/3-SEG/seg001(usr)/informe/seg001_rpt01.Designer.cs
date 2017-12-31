namespace CREARSIS
{
    partial class seg001_rpt01
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
            this.seg001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seg001_ds01 = new CREARSIS._3_SEG.seg001_usr_.informe.seg001_ds01();
            this.rep_view = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mn_pri_nci = new System.Windows.Forms.MenuStrip();
            this.m_imp_rim = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exp_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exp_docx = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exp_pdf = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exp_xlsx = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atr_atr = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.seg001BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seg001_ds01)).BeginInit();
            this.mn_pri_nci.SuspendLayout();
            this.SuspendLayout();
            // 
            // seg001BindingSource
            // 
            this.seg001BindingSource.DataMember = "seg001";
            this.seg001BindingSource.DataSource = this.seg001_ds01;
            // 
            // seg001_ds01
            // 
            this.seg001_ds01.DataSetName = "seg001_ds01";
            this.seg001_ds01.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rep_view
            // 
            this.rep_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.rep_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rep_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rep_view.ForeColor = System.Drawing.Color.Black;
            reportDataSource1.Name = "seg001_ds01";
            reportDataSource1.Value = this.seg001BindingSource;
            this.rep_view.LocalReport.DataSources.Add(reportDataSource1);
            this.rep_view.LocalReport.ReportEmbeddedResource = "CREARSIS.seg001_rpt01.rdlc";
            this.rep_view.Location = new System.Drawing.Point(0, 0);
            this.rep_view.Margin = new System.Windows.Forms.Padding(0);
            this.rep_view.Name = "rep_view";
            this.rep_view.ServerReport.BearerToken = null;
            this.rep_view.ShowBackButton = false;
            this.rep_view.ShowExportButton = false;
            this.rep_view.ShowPrintButton = false;
            this.rep_view.Size = new System.Drawing.Size(772, 520);
            this.rep_view.TabIndex = 1;
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_imp_rim,
            this.m_exp_ort,
            this.m_atr_atr});
            this.mn_pri_nci.Location = new System.Drawing.Point(58, 144);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(273, 24);
            this.mn_pri_nci.TabIndex = 11;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // m_imp_rim
            // 
            this.m_imp_rim.Name = "m_imp_rim";
            this.m_imp_rim.Size = new System.Drawing.Size(65, 20);
            this.m_imp_rim.Text = "&Imprimir";
            this.m_imp_rim.Click += new System.EventHandler(this.m_imp_rim_Click);
            // 
            // m_exp_ort
            // 
            this.m_exp_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_exp_docx,
            this.m_exp_pdf,
            this.m_exp_xlsx});
            this.m_exp_ort.Name = "m_exp_ort";
            this.m_exp_ort.Size = new System.Drawing.Size(62, 20);
            this.m_exp_ort.Text = "&Exportar";
            // 
            // m_exp_docx
            // 
            this.m_exp_docx.Name = "m_exp_docx";
            this.m_exp_docx.Size = new System.Drawing.Size(103, 22);
            this.m_exp_docx.Text = "&Word";
            this.m_exp_docx.Click += new System.EventHandler(this.m_exp_docx_Click);
            // 
            // m_exp_pdf
            // 
            this.m_exp_pdf.Name = "m_exp_pdf";
            this.m_exp_pdf.Size = new System.Drawing.Size(103, 22);
            this.m_exp_pdf.Text = "&PDF";
            this.m_exp_pdf.Click += new System.EventHandler(this.m_exp_pdf_Click);
            // 
            // m_exp_xlsx
            // 
            this.m_exp_xlsx.Name = "m_exp_xlsx";
            this.m_exp_xlsx.Size = new System.Drawing.Size(103, 22);
            this.m_exp_xlsx.Text = "&Excel";
            this.m_exp_xlsx.Click += new System.EventHandler(this.m_exp_xlsx_Click);
            // 
            // m_atr_atr
            // 
            this.m_atr_atr.Name = "m_atr_atr";
            this.m_atr_atr.Size = new System.Drawing.Size(46, 20);
            this.m_atr_atr.Text = "&Atras";
            this.m_atr_atr.Click += new System.EventHandler(this.m_atr_atr_Click);
            // 
            // seg001_rpt01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 520);
            this.ControlBox = false;
            this.Controls.Add(this.mn_pri_nci);
            this.Controls.Add(this.rep_view);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "seg001_rpt01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form Informe Usuarios";
            this.TitleText = "Form Informe Usuarios";
            this.Load += new System.EventHandler(this.seg001_rpt01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seg001BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seg001_ds01)).EndInit();
            this.mn_pri_nci.ResumeLayout(false);
            this.mn_pri_nci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource seg001BindingSource;
        private CREARSIS._3_SEG.seg001_usr_.informe.seg001_ds01 seg001_ds01;
        private Microsoft.Reporting.WinForms.ReportViewer rep_view;
        internal System.Windows.Forms.ToolStripMenuItem m_imp_rim;
        internal System.Windows.Forms.ToolStripMenuItem m_exp_ort;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_atr;
        private System.Windows.Forms.ToolStripMenuItem m_exp_docx;
        private System.Windows.Forms.ToolStripMenuItem m_exp_pdf;
        private System.Windows.Forms.ToolStripMenuItem m_exp_xlsx;
        public System.Windows.Forms.MenuStrip mn_pri_nci;
    }
}