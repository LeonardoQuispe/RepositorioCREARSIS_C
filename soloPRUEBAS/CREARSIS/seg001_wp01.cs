using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class seg001_wp01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        DataTable tab_seg001;


        c_seg001 o_seg001 = new c_seg001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();


        public seg001_wp01()
        {
            InitializeComponent();
        }

        private void seg001_wp01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string est_ado="";

            switch (cb_est_bus.SelectedIndex)
            {
                case 0: est_ado = "T"; break;
                case 1: est_ado = "H"; break;
                case 2: est_ado = "N"; break;
            }

            //Se recupera los datos de la BD
            tab_seg001 = o_seg001._01p1(est_ado);

            if (tab_seg001.Rows.Count == 0)
            {
                MessageBoxEx.Show("Ningún dato encontrado", "Informe Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Se llama al formulario de reporte pasandole el Datatable como parametro
            seg001_rpt01 obj = new seg001_rpt01();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_seg001);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }





        void fu_ini_frm()
        {
            cb_est_bus.SelectedIndex = 0;
        }
        

    }
}
