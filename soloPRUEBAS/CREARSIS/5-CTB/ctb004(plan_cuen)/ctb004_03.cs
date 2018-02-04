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

namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    public partial class ctb004_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();
        DataTable tab_ctb004;

        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();
            tb_nom_cta.Text = vg_str_ucc.Rows[0]["va_nom_cta"].ToString();

            switch (vg_str_ucc.Rows[0]["va_tip_cta"].ToString())
            {
                case "M": cb_tip_cta.SelectedIndex = 0; break;
                case "A": cb_tip_cta.SelectedIndex = 1; break;
            }
            switch (vg_str_ucc.Rows[0]["va_uso_cta"].ToString())
            {
                case "M": cb_uso_cta.SelectedIndex = 0; break;
                case "N": cb_uso_cta.SelectedIndex = 1; break;
            }
            switch (vg_str_ucc.Rows[0]["va_mon_cta"].ToString())
            {
                case "B": cb_mon_cta.SelectedIndex = 0; break;
                case "U": cb_mon_cta.SelectedIndex = 1; break;
            }

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;

                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            tb_nom_cta.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_cta.Clear();
            tb_nom_cta.Clear();

            cb_tip_cta.SelectedIndex = 0;
            cb_uso_cta.SelectedIndex = 0;
            cb_mon_cta.SelectedIndex = 0;

            tb_cod_cta.Focus();
        }


        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            if (tb_nom_cta.Text.Trim() == "")
            {
                tb_nom_cta.Focus();
                return "Debes proporcionar el nombre de Plan de Cuentas";
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public ctb004_03()
        {
            InitializeComponent();
        }

        private void ctb004_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Acatualiza Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Acatualiza Plan de Cuentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ctb004._03(tb_cod_cta.Text, tb_nom_cta.Text, cb_tip_cta.SelectedIndex.ToString(), cb_uso_cta.SelectedIndex.ToString(), cb_mon_cta.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cta.Text, tb_nom_cta.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
