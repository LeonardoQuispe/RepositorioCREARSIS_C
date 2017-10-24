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
    /// FORMULARIO ACTUALIZA USUARIO
    /// </summary>
    public partial class seg001_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ads005;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_seg001 o_ads005 = new c_seg001();

        #endregion

        #region EVENTOS

        public seg001_03()
        {
            InitializeComponent();
        }

        private void seg001_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Acatualiza Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Acatualiza Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ads005._03(cb_tip_usr.SelectedIndex+1, tb_cod_usr.Text, tb_nom_usr.Text, tb_tel_usr.Text, tb_car_usr.Text, tb_cor_usr.Text, Convert.ToInt32(tb_win_max.Text));

                MessageBoxEx.Show("Operación completada exitosamente", "Modifica Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_usr.Text, tb_nom_usr.Text);                

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_usr.Text = vg_str_ucc.Rows[0]["va_cod_usr"].ToString();
            tb_nom_usr.Text = vg_str_ucc.Rows[0]["va_nom_usr"].ToString();
            tb_tel_usr.Text = vg_str_ucc.Rows[0]["va_tel_fon"].ToString();
            tb_car_usr.Text = vg_str_ucc.Rows[0]["va_car_usr"].ToString();
            tb_cor_usr.Text = vg_str_ucc.Rows[0]["va_cor_usr"].ToString();
            tb_win_max.Text = vg_str_ucc.Rows[0]["va_win_max"].ToString();

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

            tb_nom_usr.Focus();
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

        public string fu_ver_dat()
        {
            int temp;
            if (tb_nom_usr.Text.Trim() == "")
            {
                tb_nom_usr.Focus();
                return "Debes proporcionar el nombre de usuario";
            }

            tab_ads005 = o_ads005._05(tb_cod_usr.Text);
            if (tab_ads005.Rows.Count == 0)
            {
                return "Los datos han cambiado desde su ultima lectura; El usuario ya NO se encuentra registrado";
            }

            if (((string)(tab_ads005.Rows[0]["va_est_ado"])) == "N")
            {
                return "El usuario se encuentra Deshabilitado";
            }

            if (int.TryParse(tb_win_max.Text.Trim(), out temp) == false)
            {
                tb_win_max.Focus();
                return "Dato no valido para el Nro Maximo de ventanas abiertas";
            }


            if (Convert.ToInt32(tb_win_max.Text.Trim()) <= 0)
            {
                tb_win_max.Focus();
                return "El Nro Maximo de ventanas abiertas debe ser mayor a 0";
            }

            return null;
        }
        #endregion

    }
}
