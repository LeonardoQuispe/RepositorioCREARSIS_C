using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENIAS
using DATOS.ADM;



namespace CREARSIS
{
    public partial class ctb007_05 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ctb007;
        DataTable tabla;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_ctb007 o_ctb007 = new c_ctb007();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public ctb007_05()
        {
            InitializeComponent();
        }

        private void ctb007_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_lla_vee_Click(object sender, EventArgs e)
        {
            ctb007_05a obj = new ctb007_05a();

            o_mg_glo_bal.mg_ads000_03(obj, this, vg_str_ucc);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

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
            tb_nro_dos.Text = vg_str_ucc.Rows[0]["va_nro_aut"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_fac"].ToString());

            tb_cod_sucu.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nom_sucu.Text = vg_str_ucc.Rows[0]["va_nom_suc"].ToString();
            tb_cod_act.Text = vg_str_ucc.Rows[0]["va_cod_act"].ToString();
            tb_nom_act.Text = vg_str_ucc.Rows[0]["va_nom_act"].ToString();
            tb_nro_ini.Text = vg_str_ucc.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = vg_str_ucc.Rows[0]["va_nro_fin"].ToString();
            tb_fec_ini.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ini"].ToString());
            tb_fec_fin.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_fin"].ToString());
            tb_cod_ley.Text = vg_str_ucc.Rows[0]["va_cod_ley"].ToString();
            tb_nom_ley.Text = vg_str_ucc.Rows[0]["va_nom_ley"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }


            if (vg_str_ucc.Rows[0]["va_lla_vee"].ToString() == "")
            {
                bt_lla_vee.Enabled = false;
            }
            else
            {
                bt_lla_vee.Enabled = true;
            }
        }

        #endregion

        
    }
}
