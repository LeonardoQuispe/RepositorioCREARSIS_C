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

namespace CREARSIS._6_CMR.cmr001_lista_precios_
{
    public partial class cmr001_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_cmr001;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            tb_cod_lis.Text = vg_str_ucc.Rows[0]["va_cod_lis"].ToString();

            if (vg_str_ucc.Rows[0]["va_mon_lis"].ToString() == "B")
            {
                cb_mon_lis.SelectedIndex = 0;
            }
            else
            {
                cb_mon_lis.SelectedIndex = 1;
            }

            tb_nom_lis.Text = vg_str_ucc.Rows[0]["va_nom_lis"].ToString();
            tb_fec_ini.Text = vg_str_ucc.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = vg_str_ucc.Rows[0]["va_fec_fin"].ToString();


            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nom_lis.Text == "")
            {
                tb_nom_lis.Focus();
                return "Debes proporcionar el nombre de la Lista de Precios ";
            }

            //**Verifica Fecha inicial y final-----------------------

            if ((tb_fec_fin.Value - tb_fec_ini.Value).Days <= 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }

            return null;
        }


        #endregion

        #region EVENTOS

        public cmr001_05()
        {
            InitializeComponent();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmr001_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }
        #endregion
    }
}
