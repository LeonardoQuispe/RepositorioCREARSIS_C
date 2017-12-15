using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using Microsoft.Reporting.WinForms;


namespace CREARSIS
{
    public partial class seg001_rpt01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        public seg001_rpt01()
        {
            InitializeComponent();
        }

        private void seg001_rpt01_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            fu_ini_frm();
        }



        void fu_ini_frm()
        {
            //Carga la el datatable con los datos al DataSource
            seg001_ds01 o_dat_set = new seg001_ds01();
            o_dat_set.Tables.Add(vg_str_ucc);

            //Pasando Parametros al REPORTE
            ReportParameter par_ame_tro = new ReportParameter("par_am1", "ES UNA PRUEBAZA");
            rep_view.LocalReport.SetParameters(par_ame_tro);

            //Carga el Datasource al REPORTE
            ReportDataSource seg001_ds = new ReportDataSource("tab_seg001", o_dat_set.Tables[1]);            
            rep_view.LocalReport.DataSources.Clear();
            rep_view.LocalReport.DataSources.Add(seg001_ds);
            rep_view.LocalReport.Refresh();            
            rep_view.RefreshReport();


        }

        private void m_atr_atr_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
