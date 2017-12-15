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
            this.seg001_ds01 = new CREARSIS.seg001_ds01();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rep_view = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.seg001BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seg001_ds01)).BeginInit();
            this.gb_ctr_frm.SuspendLayout();
            this.GroupBox2.SuspendLayout();
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
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(591, 16);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 70;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(12, 466);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(744, 48);
            this.gb_ctr_frm.TabIndex = 72;
            this.gb_ctr_frm.TabStop = false;
            this.gb_ctr_frm.Text = " ";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GroupBox2.Controls.Add(this.rep_view);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(12, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(744, 455);
            this.GroupBox2.TabIndex = 71;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " ";
            // 
            // rep_view
            // 
            this.rep_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            reportDataSource1.Name = "seg001_ds01";
            reportDataSource1.Value = this.seg001BindingSource;
            this.rep_view.LocalReport.DataSources.Add(reportDataSource1);
            this.rep_view.LocalReport.ReportEmbeddedResource = "CREARSIS.seg001_rpt01.rdlc";
            this.rep_view.Location = new System.Drawing.Point(23, 18);
            this.rep_view.Name = "rep_view";
            this.rep_view.ServerReport.BearerToken = null;
            this.rep_view.Size = new System.Drawing.Size(708, 418);
            this.rep_view.TabIndex = 0;
            this.rep_view.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // seg001_rpt01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(772, 520);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.gb_ctr_frm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "seg001_rpt01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Usuarios";
            this.TitleText = "Informe Usuarios";
            this.Load += new System.EventHandler(this.seg001_rpt01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seg001BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seg001_ds01)).EndInit();
            this.gb_ctr_frm.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource seg001BindingSource;
        private seg001_ds01 seg001_ds01;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rep_view;
    }
}