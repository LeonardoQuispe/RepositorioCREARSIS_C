using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CREARSIS._6_CMR.cmr002_detalle_precio_
{
    public partial class cmr002_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        DataTable tab_cmr001;
        DataTable tab_cmr002;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        DATOS._6_CMR.c_cmr002 o_cmr002 = new DATOS._6_CMR.c_cmr002();

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {

            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count != 0)
            {
                tb_sel_ecc2.Text = vg_str_ucc.Rows[0]["va_cod_lis"].ToString();

            }
            //lenar tbx nombre lista de precio
            tab_cmr001 = o_cmr001._05(tb_sel_ecc2.Text);
            if (tab_cmr001.Rows.Count != 0)
            {
                lb_sel_ecc2.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
            }
            //tb_cod_lis.Text = vg_str_ucc.Rows[0]["va_cod_lis"].ToString();

            //if (vg_str_ucc.Rows[0]["va_mon_lis"].ToString() == "B")
            //{
            //    cb_mon_lis.SelectedIndex = 0;
            //}
            //else
            //{
            //    cb_mon_lis.SelectedIndex = 1;
            //}

            //tb_nom_lis.Text = vg_str_ucc.Rows[0]["va_nom_lis"].ToString();
            //tb_fec_ini.Text = vg_str_ucc.Rows[0]["va_fec_ini"].ToString();
            //tb_fec_fin.Text = vg_str_ucc.Rows[0]["va_fec_fin"].ToString();


            //if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            //{
            //    tb_est_ado.Text = "Habilitado";
            //}
            //else
            //{
            //    tb_est_ado.Text = "Deshabilitado";
            //}

        }
        #endregion

        public cmr002_01()
        {
            InitializeComponent();
        }

        private void cmr002_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }
    }
}
