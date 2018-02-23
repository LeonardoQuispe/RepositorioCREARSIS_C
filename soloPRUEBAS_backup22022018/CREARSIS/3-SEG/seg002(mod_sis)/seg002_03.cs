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
    public partial class seg002_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._3_SEG.c_seg002 o_seg002 = new DATOS._3_SEG.c_seg002();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_mod.Text = vg_str_ucc.Rows[0]["va_cod_mod"].ToString();
            tb_nom_mod.Text = vg_str_ucc.Rows[0]["va_nom_mod"].ToString();
            tb_des_mod.Text = vg_str_ucc.Rows[0]["va_des_mod"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;

                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            tb_nom_mod.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nom_mod.Text.Trim() == "")
            {
                tb_nom_mod.Focus();
                return "Debes proporcionar el nombre de Modulo del Sistema";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public seg002_03()
        {
            InitializeComponent();
        }

        private void seg002_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Acatualiza Modulo de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Acatualiza Modulo de Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_seg002._03(int.Parse(tb_cod_mod.Text), tb_nom_mod.Text, tb_des_mod.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Modifica Modulo de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_mod.Text, tb_nom_mod.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Modulo de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
