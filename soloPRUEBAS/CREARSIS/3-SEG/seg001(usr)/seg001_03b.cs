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
    /// <summary>
    /// FORMULARIO ACTUALIZA USUARIO
    /// </summary>
    public partial class seg001_03b : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tabla;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_seg001 o_ads005 = new c_seg001();

        #endregion

        #region EVENTOS

        public seg001_03b()
        {
            InitializeComponent();
        }

        private void seg001_03b_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ver_pss_MouseHover(object sender, EventArgs e)
        {
            tb_pss_usr.UseSystemPasswordChar = false;
        }

        private void bt_ver_pss_MouseLeave(object sender, EventArgs e)
        {
            tb_pss_usr.UseSystemPasswordChar = true;
        }

        private void bt_ver_con_MouseHover(object sender, EventArgs e)
        {
            tb_pss_con.UseSystemPasswordChar = false;
        }

        private void bt_ver_con_MouseLeave(object sender, EventArgs e)
        {
            tb_pss_con.UseSystemPasswordChar = true;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Actualiza contraseña", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                o_ads005._03(cb_tip_usr.SelectedIndex + 1, tb_cod_usr.Text, tb_pss_usr.Text);

                MessageBoxEx.Show("La contraseña se Actualizó satisfactoriamente", "Modifica contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Modifica contraseña", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            tb_cod_usr.Text = vg_str_ucc.Rows[0]["va_cod_usr"].ToString();
            tb_nom_usr.Text = vg_str_ucc.Rows[0]["va_nom_usr"].ToString();

            switch (vg_str_ucc.Rows[0]["va_tip_usr"].ToString())
            {
                case "1":
                    cb_tip_usr.SelectedIndex = 0;
                    break;
                case "2":
                    cb_tip_usr.SelectedIndex = 1;
                    break;
                case "3":
                    cb_tip_usr.SelectedIndex = 2;
                    break;
            }
        }

        string fu_ver_dat()
        {

            if (tb_cod_usr.Text.Trim() == "")
            {
                return "Debe proporcionar el Código para el Usuario";
            }


            tabla = o_ads005._05(tb_cod_usr.Text);

            if (tabla.Rows.Count == 0)
            {
                return "Los datos han cambiado desde su última lectura; El usuario ya NO se encuentra registrado";
            }

            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                return "El usuario se encuentra Deshabilitado";
            }

            //Valida Contraseña
            if (tb_pss_usr.Text.Trim()=="")
            {
                tb_pss_usr.Focus();
                return "Debe ingresar una Contraseña";

            }
            if (tb_pss_con.Text.Trim() == "")
            {
                tb_pss_usr.Focus();
                return "Debe Confirmar la Contraseña";

            }
            if (tb_pss_usr.Text != tb_pss_con.Text)
            {
                return "La contraseña no coincide con la confirmación de la misma";
            }

            return null;
        }

        #endregion

    }
}
