using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._6_CMR;
using DevComponents.DotNetBar;


namespace CREARSIS._6_CMR.cmr003_vendedor_
{
    public partial class cmr003_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        c_cmr003 o_cmr003 = new c_cmr003();


        public cmr003_06()
        {
            InitializeComponent();
        }

        private void cmr003_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar el Vendedor?", "Elimina Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //ELIMINA datos
            o_cmr003._06(tb_cod_ven.Text.Trim());

            MessageBoxEx.Show("Operación completada exitosamente", "Elimina Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex);

            Close();
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
