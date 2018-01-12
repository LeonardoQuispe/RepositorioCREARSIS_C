using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CREARSIS._6_CMR.cmr003_vendedor_
{
    public partial class cmr003_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        

        public cmr003_05()
        {
            InitializeComponent();
        }

        private void cmr003_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }




        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            tb_cod_ven.Text = vg_str_ucc.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven.Text = vg_str_ucc.Rows[0]["va_nom_ven"].ToString();
            tb_por_ven.Text = vg_str_ucc.Rows[0]["va_por_cms"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;
                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            switch (vg_str_ucc.Rows[0]["va_tip_cms"].ToString())
            {
                case "1": cb_tip_com.SelectedIndex = 0; break;
                case "2": cb_tip_com.SelectedIndex = 1; break;
            }
        }



    }
}
