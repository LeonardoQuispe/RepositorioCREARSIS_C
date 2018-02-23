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

namespace CREARSIS._2_ADM.adm011_gru_per_
{
    public partial class adm011_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm003;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm011 o_adm011 = new c_adm011();

        #endregion      

        #region METODOS

        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_gru.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = vg_str_ucc.Rows[0]["va_nom_gru"].ToString();

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

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_gru.Clear();
            tb_nom_gru.Clear();

            tb_cod_gru.Focus();
        }

        #endregion
        public adm011_05()
        {
            InitializeComponent();
        }

        private void adm011_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
