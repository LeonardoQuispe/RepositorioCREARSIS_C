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
    /// <summary>
    /// FORMULARIO NUEVO USUARIO
    /// </summary>
    public partial class seg001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_seg001 o_ads005 = new c_seg001();
        DataTable tab_ads005;

        #endregion

        #region EVENTOS

        public seg001_02()
        {
            InitializeComponent();
        }

        private void seg001_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ads005._02(cb_tip_usr.SelectedIndex+1, tb_cod_usr.Text, tb_nom_usr.Text, tb_tel_usr.Text, tb_car_usr.Text, tb_cor_usr.Text, 5, "Usuario123.");

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_usr.Text, tb_nom_usr.Text);

                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_tip_usr.SelectedIndex = 0;

            tb_cod_usr.Focus();
        }
        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_usr.Clear();
            tb_nom_usr.Clear();
            tb_tel_usr.Clear();
            tb_car_usr.Clear();
            tb_cor_usr.Clear();

            tb_cod_usr.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_usr.Text.Trim() == "")
            {
                tb_cod_usr.Focus();
                return "Debes proporcionar el codigo de usuario";
            }

            tab_ads005 = o_ads005._05(tb_cod_usr.Text);
            if (tab_ads005.Rows.Count != 0)
            {
                tb_cod_usr.Focus();
                return "El codigo del Usuario ya se encuentra registrado";
            }

            if (tb_nom_usr.Text.Trim() == "")
            {
                tb_nom_usr.Focus();
                return "Debes proporcionar el nombre de usuario";
            }

            return null;
        }
        #endregion
    }
}
