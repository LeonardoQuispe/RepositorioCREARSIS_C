using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._8_TES;
using DevComponents.DotNetBar;

namespace CREARSIS._8_TES.tes001_caja_banco_
{
    public partial class tes001_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        #endregion

        #region INSTANCIAS

        c_tes001 o_tes001 = new c_tes001();

        #endregion

        #region EVENTOS

        public tes001_04()
        {
            InitializeComponent();
        }

        private void tes001_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            if (tb_est_ado.Text == "Habilitado")
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la Caja/Banco?", "Deshabilita Caja/Banco", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar la Caja/Banco?", "Habilita Caja/Banco", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }



            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Graba datos
            if (tb_est_ado.Text == "Habilitado")
            {
                o_tes001._04(int.Parse(tb_cod_cjb.Text.Trim()), "N");
            }
            else
            {
                o_tes001._04(int.Parse(tb_cod_cjb.Text.Trim()), "H");
            }

            MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_cjb.Text.Trim());

            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //Valida Tipo de Caja/Banco
            cb_tip_cjb.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_cjb"].ToString()) - 1;

            //Valida Moneda de Caja/Banco
            switch (vg_str_ucc.Rows[0]["va_mon_cjb"].ToString())
            {
                case "B": cb_mon_cjb.SelectedIndex = 0; break;
                case "U": cb_mon_cjb.SelectedIndex = 1; break;
            }

            //Llena los datos
            tb_cod_cjb.Text = vg_str_ucc.Rows[0]["va_cod_cjb"].ToString();
            tb_nom_cjb.Text = vg_str_ucc.Rows[0]["va_nom_cjb"].ToString();
            tb_nro_cta.Text = vg_str_ucc.Rows[0]["va_nro_cta"].ToString();
            tb_sal_cjb.Text = vg_str_ucc.Rows[0]["va_sal_cjb"].ToString();


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

        #endregion
    }
}
