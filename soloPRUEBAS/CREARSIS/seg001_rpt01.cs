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

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        public seg001_rpt01()
        {
            InitializeComponent();            
        }

        private void seg001_rpt01_Load(object sender, EventArgs e)
        {
            //Se amplia el reporte en toda la pantalla del forulario Padre
            this.Dock = DockStyle.Fill;

            //Se cambió propiedades de Visualización del REPORTE
            rep_view.SetDisplayMode(DisplayMode.PrintLayout);
            rep_view.ZoomMode = ZoomMode.Percent;

            //Ejecuta funcion Inicial
            fu_ini_frm();
        }

        //Evento Imprimir
        private void m_imp_rim_Click(object sender, EventArgs e)
        {
            rep_view.PrintDialog();
        }

        //Evento Exportar a WORD
        private void m_exp_docx_Click(object sender, EventArgs e)
        {
            RenderingExtension[] list_exp = rep_view.LocalReport.ListRenderingExtensions();
            RenderingExtension ext_exp = list_exp[5];

            rep_view.ExportDialog(ext_exp);
        }

        //Evento Exportar PDF
        private void m_exp_pdf_Click(object sender, EventArgs e)
        {
            RenderingExtension[] list_exp = rep_view.LocalReport.ListRenderingExtensions();
            RenderingExtension ext_exp = list_exp[3];

            rep_view.ExportDialog(ext_exp);
        }

        //Evento Exportar Excel
        private void m_exp_xlsx_Click(object sender, EventArgs e)
        {
            RenderingExtension[] list_exp = rep_view.LocalReport.ListRenderingExtensions();
            RenderingExtension ext_exp = list_exp[1];

            rep_view.ExportDialog(ext_exp);
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
            ReportParameter[] par_ame_tro = new ReportParameter[4];
            par_ame_tro[0] = new ReportParameter("cod_usr", "(" + Program.gl_usr_usr + ")");
            par_ame_tro[1] = new ReportParameter("nom_emp", "(" + Program.gl_nom_emp + ")");

            switch (vg_frm_pad.cb_est_bus.SelectedIndex)
            {
                case 0: par_ame_tro[2] = new ReportParameter("est_prm", "(Todos)"); break;

                case 1: par_ame_tro[2] = new ReportParameter("est_prm", "(Habilitados)"); break;

                case 2: par_ame_tro[2] = new ReportParameter("est_prm", "(Deshabilitados)"); break;
            }
            //Obtiene Fecha y hora del servidor para pasar al reporte
            par_ame_tro[3]= new ReportParameter("fec_act", o_mg_glo_bal.fg_fec_act().ToString());


            //Carga los parametros al reporte
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
