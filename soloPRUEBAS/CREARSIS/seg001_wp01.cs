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

        private void seg001_rpt01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();            
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string vv_err_msg = fu_ver_dat();

            if (vv_err_msg!=null)
            {
                MessageBoxEx.Show(vv_err_msg, "Informe Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Se llama al formulario de reporte pasandole el Datatable como parametro
            seg001_rpt01 obj = new seg001_rpt01();
            o_mg_glo_bal.mg_ads000_03(obj, this, tab_seg001);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }



        void fu_ini_frm()
        {
            cb_est_bus.SelectedIndex = 0;
        }

        string fu_ver_dat()
        {
            //Se recupera los datos de la BD
            tab_seg001 = o_seg001._01("", 0, cb_est_bus.SelectedIndex);

            if (tab_seg001.Rows.Count==0)
            {
                return "Ningún dato encontrado";
            }

            return null;
        }


    }
}
