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

namespace CREARSIS
{
    /// <summary>
    /// (FORMULARIO PARAMETROS) PERIODOS DE UNA GESTION  
    /// </summary>
    public partial class adm002_01wp : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm002;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_adm002 o_adm002 = new c_adm002();

        #endregion

        #region EVENTOS

        public adm002_01wp()
        {
            InitializeComponent();
        }

        private void adm002_01wp_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //Obtiene datos
            tab_adm002 = o_adm002.R_01p1(Convert.ToInt32(cb_ges_tio.SelectedValue));
            // mg_ads000_02(adm002_01wr, Me, tab_adm002)
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm()
        {
            //Obtiene datos de gestion/periodo
            tabla = o_adm002._05();

            //Carga datos en el comboBox
            cb_ges_tio.DisplayMember = "va_cod_ges";
            cb_ges_tio.ValueMember = "va_cod_ges";
            cb_ges_tio.DataSource = tabla;

        }
        #endregion
    }
}
