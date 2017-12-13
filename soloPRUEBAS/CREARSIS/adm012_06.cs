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
    public partial class adm012_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm012;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm012 o_adm012 = new c_adm012();

        #endregion

        #region EVENTOS

        public adm012_06()
        {
            InitializeComponent();
        }

        private void adm012_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                string va_est_ado = "";

                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Elimina actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar a la actividad Económica ?", "Elimina actividad Económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm012._06(tb_cod_act.Text);

                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            tab_adm012 = o_adm012._05(tb_cod_act.Text);
            if (tab_adm012.Rows.Count == 0)
            {
                return "El codigo de la actividad Económica ya NO se encuentra registrado";
            }

            if (tb_est_ado.Text == "Habilitado")
            {
                return "la actividad Económica se encuentra habilitada NO puede eliminarla";
            }

            return null;
        }
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
                tb_est_ado.Text = "Deshabilitado";
            }

        }

        #endregion
    }
}
