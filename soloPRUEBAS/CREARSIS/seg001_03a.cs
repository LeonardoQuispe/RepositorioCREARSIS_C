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
    /// FORMULARIO INICIALIZA CONTRASEÑA DE USUARIO
    /// </summary>
    public partial class seg001_03a : DevComponents.DotNetBar.Metro.MetroForm
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

        public seg001_03a()
        {
            InitializeComponent();
        }

        private void seg001_03a_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Inicializa contraseña", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                o_ads005._03(cb_tip_usr.SelectedIndex+1, tb_cod_usr.Text, "Usuario123.");

                MessageBoxEx.Show("La contraseña se inicializo satisfactoriamente", "Inicializa contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_usr.Text, tb_nom_usr.Text);

                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Inicializa contraseña", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            tb_cod_usr.Text =vg_str_ucc.Rows[0]["va_cod_usr"].ToString();
            tb_nom_usr.Text =vg_str_ucc.Rows[0]["va_nom_usr"].ToString();

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
        public string fu_ver_dat()
        {

            if (tb_cod_usr.Text.Trim() == "")
            {
                return "Debe proporcionar el Codigo para el Usuario";
            }

            if (tb_cod_usr.Text.Trim() == "crearsis")
            {
                return "No se permite inicializar contraseña para el usuario 'crearsis'";
            }


            tabla = o_ads005._05(tb_cod_usr.Text);
            if (tabla.Rows.Count == 0)
            {
                return "Los datos han cambiado desde su ultima lectura; El usuario ya NO se encuentra registrado";
            }

            if (((string)(tabla.Rows[0]["va_est_ado"])) == "N")
            {
                return "El usuario se encuentra Deshabilitado";
            }

            return null;
        }
        #endregion
    }
}
