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
    public partial class adm007_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm007;

        #endregion

        #region INSTANCIAS

        c_adm007 o_adm007 = new c_adm007();

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
            tb_cod_suc.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nom_suc.Text = vg_str_ucc.Rows[0]["va_nom_suc"].ToString();

            tb_res_suc.Text = vg_str_ucc.Rows[0]["va_enc_suc"].ToString();
            tb_ubi_suc.Text = vg_str_ucc.Rows[0]["va_ubi_suc"].ToString();
            tb_tel_suc.Text = vg_str_ucc.Rows[0]["va_tel_suc"].ToString();
            tb_ema_suc.Text = vg_str_ucc.Rows[0]["va_ema_suc"].ToString();
            tb_ciu_suc.Text = vg_str_ucc.Rows[0]["va_ciu_suc"].ToString();
            tb_ley_suc.Text = vg_str_ucc.Rows[0]["va_ley_suc"].ToString();

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
            tab_adm007 = o_adm007._05(tb_cod_suc.Text);
            if (tab_adm007.Rows.Count == 0)
            {
                return "La Actividad Economica no se encuentra registrada";
            }
            return null;
        }
        #endregion

        #region EVENTOS

        public adm007_04()
        {
            InitializeComponent();
        }

        private void adm007_04_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(vv_err_msg, "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                if (tb_est_ado.Text == "Habilitado")
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la Sucursal ?", "Deshabilita  Sucursal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar a la Sucursal  ?", "Habilita Sucursal ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                if (tb_est_ado.Text == "Habilitado")
                {
                    o_adm007._04(tb_cod_suc.Text, "N");
                }
                else
                {
                    o_adm007._04(tb_cod_suc.Text, "H");
                }

                MessageBoxEx.Show("Operación completada exitosamente", " Habilita/Deshabilita Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vg_frm_pad.fu_sel_fila(tb_cod_suc.Text, tb_nom_suc.Text);


                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Habilita/Deshabilita Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
