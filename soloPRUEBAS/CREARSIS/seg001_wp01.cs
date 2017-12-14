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


namespace CREARSIS
{
    public partial class seg001_wp01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        DataTable tab_seg001;


        c_seg001 o_seg001 = new c_seg001();

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
            fu_bus_car(cb_est_bus.SelectedIndex);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }



        void fu_ini_frm()
        {
            cb_est_bus.SelectedIndex = 0;
        }


        /// <summary>
        /// Metodo que Consulta a Base de datos y devuelve un DATATABLE
        /// </summary>
        /// <param name="est_bus">Estado  0="TODOS", 1="HABILITADO", 2="DESHABILITADO"</param>
        public void fu_bus_car(int est_bus)
        {    
            //Se llena Datatable con datos recuperados de la BD
            tab_seg001 = o_seg001._01("",0, est_bus);

        }



    }
}
