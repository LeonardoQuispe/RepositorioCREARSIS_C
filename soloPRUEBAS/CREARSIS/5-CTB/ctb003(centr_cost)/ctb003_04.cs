using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._5_CTB;
using DevComponents.DotNetBar;

namespace CREARSIS._5_CTB.ctb003_centr_cost_
{
    public partial class ctb003_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;


        c_ctb003 o_ctb003 = new c_ctb003();


        public ctb003_04()
        {
            InitializeComponent();
        }

        private void ctb003_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            if (tb_est_ado.Text == "Habilitado")
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar el Centro de Costos?", "Deshabilita Centro de Costos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar el Centro de Costos?", "Habilita Centro de Costos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }



            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Graba datos
            if (tb_est_ado.Text == "Habilitado")
            {
                o_ctb003._04(int.Parse(tb_cod_cct.Text.Trim()), "N");
            }
            else
            {
                o_ctb003._04(int.Parse(tb_cod_cct.Text.Trim()), "H");
            }

            MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_cct.Text.Trim());

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

            //Valida Moneda de Centro de Costos
            switch (vg_str_ucc.Rows[0]["va_tip_cct"].ToString())
            {
                case "M": tb_tip_cct.Text = "Matriz"; break;
                case "A": tb_tip_cct.Text = "Analítica"; break;
            }

            //Llena los datos
            tb_cod_cct.Text = vg_str_ucc.Rows[0]["va_cod_cct"].ToString();
            tb_nom_cct.Text = vg_str_ucc.Rows[0]["va_nom_cct"].ToString();

            //Valida Estado
            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }





    }
}
