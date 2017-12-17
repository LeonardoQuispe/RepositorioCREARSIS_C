using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            ////Se cambió propiedades de Visualización del REPORTE
            rep_view.SetDisplayMode(DisplayMode.PrintLayout);
            rep_view.ZoomMode = ZoomMode.Percent;
        }

        private void seg001_rpt01_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            fu_ini_frm();
        }

        private void m_atr_atr_Click(object sender, EventArgs e)
        {
            Close();
        }




        void fu_ini_frm()
        {
            //Carga la el datatable con los datos al DataSource
            seg001_ds01 o_dat_set = new seg001_ds01();
            vg_str_ucc.TableName = "seg001";
            o_dat_set.Tables.Add(vg_str_ucc);


            //Pasando Parametros al REPORTE
            ReportParameter[] par_ame_tro = new ReportParameter[3];
            par_ame_tro[0] = new ReportParameter("cod_usr", "(" + Program.gl_usr_usr + ")");
            par_ame_tro[1] = new ReportParameter("nom_emp", "(" + Program.gl_nom_emp + ")");

            switch (vg_frm_pad.cb_est_bus.SelectedIndex)
            {
                case 0: par_ame_tro[2] = new ReportParameter("est_prm", "(Todos)"); break;

                case 1: par_ame_tro[2] = new ReportParameter("est_prm", "(Habilitados)"); break;

                case 2: par_ame_tro[2] = new ReportParameter("est_prm", "(Deshabilitados)"); break;
            }

            rep_view.LocalReport.SetParameters(par_ame_tro);




            //Carga el Datasource al REPORTE
            ReportDataSource seg001_ds = new ReportDataSource("tab_seg001", o_dat_set.Tables[1]);
            rep_view.LocalReport.DataSources.Clear();
            rep_view.LocalReport.DataSources.Add(seg001_ds);
            rep_view.LocalReport.Refresh();
            rep_view.RefreshReport();

        }

        
    }
}
