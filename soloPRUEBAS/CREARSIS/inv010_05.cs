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
using DATOS;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv010_05 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm007;

        #endregion

        #region INSTANCIAS

        c_inv010 o_inv010 = new c_inv010();
        c_adm007 o_adm007 = new c_adm007();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_sucu.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nro_gru.Text = vg_str_ucc.Rows[0]["va_nro_gru"].ToString();
            tb_cod_gru.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString().PadLeft(4, '0');
            tb_nom_gru.Text = vg_str_ucc.Rows[0]["va_nom_gru"].ToString();
            tb_des_gru.Text = vg_str_ucc.Rows[0]["va_des_gru"].ToString();

            fu_rec_suc(vg_str_ucc.Rows[0]["va_cod_suc"].ToString());

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }

        void fu_rec_suc(string cod_suc)
        {
            tab_adm007 = o_adm007._05(cod_suc);

            tb_nom_sucu.Text = tab_adm007.Rows[0]["va_nom_suc"].ToString();
        }

        #endregion;

        #region EVENTOS
        public inv010_05()
        {
            InitializeComponent();
        }

        private void inv010_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
