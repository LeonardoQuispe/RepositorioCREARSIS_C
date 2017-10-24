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
    public partial class adm007_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm007;

        #endregion

        #region INSTANCIAS

        c_adm007 o_adm007 = new c_adm007();

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            int cod_tpr = 0;
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_suc.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nom_suc.Text = vg_str_ucc.Rows[0]["va_nom_suc"].ToString();

            tb_res_suc.Text = vg_str_ucc.Rows[0]["va_enc_suc"].ToString();
            tb_ubi_suc.Text = vg_str_ucc.Rows[0]["va_ubi_suc"].ToString();
            tb_tel_suc.Text = vg_str_ucc.Rows[0]["va_tel_suc"].ToString();
            tb_ema_suc.Text = vg_str_ucc.Rows[0]["va_ema_suc"].ToString();
            tb_ciu_suc.Text = vg_str_ucc.Rows[0]["va_ciu_suc"].ToString();
            tb_ley_suc.Text = vg_str_ucc.Rows[0]["va_ley_suc"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Dehabilitado";
            }

        }

        #endregion

        #region EVENTOS

        public adm007_05()
        {
            InitializeComponent();
        }

        private void adm007_05_Load(object sender, EventArgs e)
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
