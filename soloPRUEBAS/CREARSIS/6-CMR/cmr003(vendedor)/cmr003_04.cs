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
    public partial class cmr003_04 : DevComponents.DotNetBar.Metro.MetroForm
    {

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        c_cmr003 o_cmr003 = new c_cmr003();
        

        public cmr003_04()
        {
            InitializeComponent();
        }

        private void cmr003_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            if (tb_est_ado.Text == "Habilitado")
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar el Vendedor?", "Deshabilita Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar el Vendedor?", "Habilita Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }



            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Graba datos
            if (tb_est_ado.Text == "Habilitado")
            {
                o_cmr003._04(tb_cod_ven.Text.Trim(), "N");
            }
            else
            {
                o_cmr003._04(tb_cod_ven.Text.Trim(), "H");
            }

            MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_ven.Text.Trim(), tb_nom_ven.Text.Trim());

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
