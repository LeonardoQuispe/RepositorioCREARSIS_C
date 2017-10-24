using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CREARSIS
{
    /// <summary>
    /// (FORMULARIO PARAMETROS) REPORTE USUARIO
    /// </summary>
    public partial class seg001_01wp : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region EVENTOS

        public seg001_01wp()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //Obtiene datos
            //tab_ads005 = o_ads005._01p1(cb_est_ado.SelectedItem.ToString());
        }

        private void seg001_01wp_Load(object sender, EventArgs e)
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
        /// -> Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            cb_est_ado.SelectedIndex = 0;
        }

        #endregion

    }
}
