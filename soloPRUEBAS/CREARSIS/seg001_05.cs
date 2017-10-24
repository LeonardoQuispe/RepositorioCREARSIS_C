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

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO CONSULTA USUARIO
    /// </summary>
    public partial class seg001_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ads005;
        string err_msg = "";
        public DataTable vg_str_ucc;

        #endregion

        #region INSTANCIAS

        c_seg001 o_ads005 = new c_seg001();

        #endregion

        #region EVENTOS

        public seg001_05()
        {
            InitializeComponent();
        }

        private void seg001_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
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

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H":
                    tb_est_ado.Text = "Habilitado";
                    break;
                case "N":
                    tb_est_ado.Text = "Deshabilitado";
                    break;
            }
        }

        //' <summary>
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

        #endregion

    }
}
