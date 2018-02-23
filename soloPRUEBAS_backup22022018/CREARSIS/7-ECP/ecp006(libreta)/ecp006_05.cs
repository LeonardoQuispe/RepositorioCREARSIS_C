using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._7_ECP;
using DevComponents.DotNetBar;


namespace CREARSIS._7_ECP.ecp006_libreta_
{
    public partial class ecp006_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ctb004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_ecp006 o_ecp006 = new c_ecp006();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();

        #endregion

        #region EVENTOS

        public ecp006_05()
        {
            InitializeComponent();
        }

        private void ecp006_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //Valida Tipo de Libreta
            cb_tip_lib.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_lib"].ToString()) - 1;

            //Valida Moneda de Libreta
            switch (vg_str_ucc.Rows[0]["va_mon_lib"].ToString())
            {
                case "B": cb_mon_lib.SelectedIndex = 0; break;
                case "U": cb_mon_lib.SelectedIndex = 1; break;
            }

            //Llena los datos
            tb_cod_lib.Text = vg_str_ucc.Rows[0]["va_cod_lib"].ToString();
            tb_des_lib.Text = vg_str_ucc.Rows[0]["va_des_lib"].ToString();

            //lenar tbx de Plan de Cuentas
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();
            tab_ctb004 = o_ctb004._05(tb_cod_cta.Text);
            if (tab_ctb004.Rows.Count != 0)
            {
                tb_nom_cta.Text = tab_ctb004.Rows[0]["va_nom_cta"].ToString();
            }


            //Valida Estado
            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }

        #endregion
    }
}
