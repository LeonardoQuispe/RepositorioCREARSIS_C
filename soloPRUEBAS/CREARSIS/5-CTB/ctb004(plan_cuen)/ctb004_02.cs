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
    public partial class ctb004_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_cta.Focus();
            cb_tip_cta.SelectedIndex = 0;
            cb_uso_cta.SelectedIndex = 0;
            cb_mon_cta.SelectedIndex = 0;
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
            if (tb_cod_cta.Text.Trim() == "")
            {
                tb_cod_cta.Focus();
                return "Debes proporcionar el codigo de Plan de Cuentas";
            }

            if (o_mg_glo_bal.fg_val_let(tb_cod_cta.Text) == false)
            {
                tb_cod_cta.Focus();
                return "Sólo se admiten letras en el código del Plan de Cuentas";
            }
            

            tab_ctb004 = o_ctb004._05(tb_cod_cta.Text);
            if (tab_ctb004.Rows.Count != 0)
            {
                tb_cod_cta.Focus();
                return "El codigo del Plan de Cuentas ya se encuentra registrado";
            }

            if (tb_nom_cta.Text.Trim() == "")
            {
                tb_nom_cta.Focus();
                return "Debes proporcionar el nombre de Plan de Cuentas";
            }

            return null;
        }
        #endregion

        #region EVENTOS
        public ctb004_02()
        {
            InitializeComponent();
        }

        private void ctb004_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Plan de Cuentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ctb004._02(tb_cod_cta.Text, tb_nom_cta.Text, cb_tip_cta.SelectedIndex.ToString(),cb_uso_cta.SelectedIndex.ToString(), cb_mon_cta.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cta.Text, tb_nom_cta.Text);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
