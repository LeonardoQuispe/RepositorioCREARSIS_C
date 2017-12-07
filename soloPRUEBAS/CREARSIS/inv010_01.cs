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
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv010_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv004;
        DataTable tabla;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS


        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_inv004 o_inv004 = new c_inv004();

        #endregion


        public inv010_01()
        {
            InitializeComponent();
        }
    }
}
