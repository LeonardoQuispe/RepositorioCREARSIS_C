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

namespace CREARSIS._3_SEG.seg002_mod_sis_
{
    public partial class seg002_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_seg002;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._3_SEG.c_seg002 o_seg002 = new DATOS._3_SEG.c_seg002();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_mod.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_mod.Clear();
            tb_nom_mod.Clear();
            tb_des_mod.Clear();

            tb_cod_mod.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_mod.Text.Trim() == "")
            {
                tb_cod_mod.Focus();
                return "Debes proporcionar el codigo de Modulo del Sistema";
            }

            if (o_mg_glo_bal.fg_val_num(tb_cod_mod.Text) == false)
            {
                tb_cod_mod.Focus();
                return "El Codigo debe ser numérico";
            }

            tab_seg002 = o_seg002._05(int.Parse(tb_cod_mod.Text));
            if (tab_seg002.Rows.Count != 0)
            {
                tb_cod_mod.Focus();
                return "El codigo del Modulo del Sistema ya se encuentra registrado";
            }

            if (tb_nom_mod.Text.Trim() == "")
            {
                tb_nom_mod.Focus();
                return "Debes proporcionar el nombre de Modulo del Sistema";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public seg002_02()
        {
            InitializeComponent();
        }

        private void seg002_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Modulo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Modulo del Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_seg002._02(int.Parse(tb_cod_mod.Text), tb_nom_mod.Text, tb_des_mod.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Modulo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_mod.Text, tb_nom_mod.Text);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Modulo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
