using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._7_ECP;
using DevComponents.DotNetBar;


namespace CREARSIS._7_ECP.ecp006_libreta_
{
    public partial class ecp006_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        #endregion

        #region INSTANCIAS

        c_ecp006 o_ecp006 = new c_ecp006();

        #endregion

        #region EVENTOS

        public ecp006_04()
        {
            InitializeComponent();
        }

        private void ecp006_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            if (tb_est_ado.Text == "Habilitado")
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la Libreta?", "Deshabilita Libreta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar la Libreta?", "Habilita Libreta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }



            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Graba datos
            if (tb_est_ado.Text == "Habilitado")
            {
                o_ecp006._04(int.Parse(tb_cod_lib.Text.Trim()), "N");
            }
            else
            {
                o_ecp006._04(int.Parse(tb_cod_lib.Text.Trim()), "H");
            }

            MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Libreta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_lib.Text.Trim());

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

            //Valida Tipo de Libreta
            cb_tip_lib.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_lib"].ToString()) - 1;

            //Valida Moneda de Libreta
            switch (vg_str_ucc.Rows[0]["va_mon_lib"].ToString())
            {
                case "B": cb_mon_lib.SelectedIndex = 0; break;
                case "U": cb_mon_lib.SelectedIndex = 1; break;
            }

            //Llena los datos
            tb_cod_lib.Text = vg_str_ucc.Rows[0]["va_cod_lib"].ToString();
            tb_des_lib.Text = vg_str_ucc.Rows[0]["va_des_lib"].ToString();
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();


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
