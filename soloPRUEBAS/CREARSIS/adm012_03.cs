using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS.ADM;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class adm012_03 : DevComponents.DotNetBar.Metro.MetroForm
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

        public adm012_03()
        {
            InitializeComponent();
        }

        private void adm012_03_Load(object sender, EventArgs e)
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
                int tmp;

                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "error Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tb_cod_act.Text.Trim() == "")
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el codigo", "error Actualizar Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(tb_cod_act.Text, out tmp) == false)
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Dato no valido, debe ser numerico el codigo", "error Actualizar Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tb_nom_act.Text.Trim() == "")
                {
                    tb_nom_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el nombre de la Actividad Económica", "error Actualizar Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Actualizar Actividad Económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm012._03(int.Parse(tb_cod_act.Text), tb_nom_act.Text);

                vg_frm_pad.fu_sel_fila(tb_cod_act.Text, tb_nom_act.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualizar Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tb_nom_act.Text = vg_str_ucc.Rows[0]["va_nom_act"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Dehabilitado";
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
