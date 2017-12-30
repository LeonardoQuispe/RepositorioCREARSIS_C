using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DevComponents.DotNetBar;
using DATOS;

namespace CREARSIS
{
    public partial class adm012_04 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm012;

        #endregion

        #region INSTANCIAS

        c_adm012 o_adm012 = new c_adm012();

        #endregion

        #region EVENTOS

        public adm012_04()
        {
            InitializeComponent();
        }

        private void adm012_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                string va_est_ado = "";

                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat();
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                if (tb_est_ado.Text == "Habilitado")
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la Actividad Económica ?", "Deshabilita Actividad Económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar a la Actividad Económica ?", "Habilita Actividad Económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                if (tb_est_ado.Text == "Habilitado")
                {
                    o_adm012._04(tb_cod_act.Text, "N");
                }
                else
                {
                    o_adm012._04(tb_cod_act.Text, "H");
                }

                vg_frm_pad.fu_sel_fila(tb_cod_act.Text, tb_nom_act.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Habilita/Deshabilita Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            int cod_tpr = 0;
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_act.Text = vg_str_ucc.Rows[0]["va_cod_act"].ToString();
            //cod_tpr = vg_str_ucc.Rows[0][""].TosString();va_cod_tpr")
            tb_nom_act.Text = vg_str_ucc.Rows[0]["va_nom_act"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            //Si aun existe
            tab_adm012 = o_adm012._05(tb_cod_act.Text);
            if (tab_adm012.Rows.Count == 0)
            {
                return "La Actividad Económica no se encuentra registrada";
            }

            return null;
        }

        #endregion
        
    }
}
