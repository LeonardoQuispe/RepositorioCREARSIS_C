using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using CREARSIS._2_ADM.adm011_gru_per_;
using DATOS;
using DATOS._6_CMR;


namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_05 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm011;
        DataTable tab_cmr003;

        #endregion

        #region INSTANCIAS

        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();
        c_cmr003 o_cmr003 = new c_cmr003();

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public adm010_05()
        {
            InitializeComponent();
        }

        private void adm010_05_Load(object sender, EventArgs e)
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

            //Recupera Nombre de Grupo de Persona
            tab_adm011 = o_adm011._05(int.Parse(vg_str_ucc.Rows[0]["va_cod_gru"].ToString()));

            //Valida si es CLIENTE-PROOVEDOR
            if (vg_str_ucc.Rows[0]["va_ban_ven"].ToString() == "1")
            {
                chk_ven.Checked = true;
                tab_ven.Visible = true;
            }

            if (vg_str_ucc.Rows[0]["va_ban_com"].ToString() == "1")
            {
                chk_com.Checked = true;
            }

            //Llena los datos
            tb_cod_gru.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = tab_adm011.Rows[0]["va_nom_gru"].ToString();
            tb_nro_per.Text = vg_str_ucc.Rows[0]["va_nro_per"].ToString();
            tb_cod_per.Text = vg_str_ucc.Rows[0]["va_cod_per"].ToString().PadLeft(7, '0');
            tb_raz_per.Text = vg_str_ucc.Rows[0]["va_raz_soc"].ToString();
            tb_nit_per.Text = vg_str_ucc.Rows[0]["va_nit_ced"].ToString();
            tb_nom_per.Text = vg_str_ucc.Rows[0]["va_nom_com"].ToString();
            tb_dir_gen.Text = vg_str_ucc.Rows[0]["va_dir_per"].ToString();
            tb_tel_gen.Text = vg_str_ucc.Rows[0]["va_tel_per"].ToString();
            tb_cel_gen.Text = vg_str_ucc.Rows[0]["va_cel_per"].ToString();
            tb_ema_gen.Text = vg_str_ucc.Rows[0]["va_ema_per"].ToString();

            //VENTAS
            if (chk_ven.Checked == true)
            {
                if (vg_str_ucc.Rows[0]["va_cod_lpr"].ToString() != "" && vg_str_ucc.Rows[0]["va_cod_lpr"].ToString() != "0")
                {
                    tb_cod_pre_cli.Text = vg_str_ucc.Rows[0]["va_cod_lpr"].ToString();
                }

                if (vg_str_ucc.Rows[0]["va_cod_ven"].ToString() != "" && vg_str_ucc.Rows[0]["va_cod_ven"].ToString() != "0")
                {
                    tb_cod_ven_cli.Text = vg_str_ucc.Rows[0]["va_cod_ven"].ToString();
                    fu_rec_ven(tb_cod_ven_cli.Text);
                }
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


        public void fu_rec_ven(string cod_ven)
        {
            if (cod_ven.Trim() == "")
            {
                tb_cod_ven_cli.Clear();
                tb_nom_ven_cli.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_num(cod_ven) == false)
            {
                tb_cod_ven_cli.Clear();
                tb_nom_ven_cli.Text = "** NO existe";
                return;
            }

            tab_cmr003 = o_cmr003._05(cod_ven);
            if (tab_cmr003.Rows.Count == 0)
            {
                tb_cod_ven_cli.Clear();
                tb_nom_ven_cli.Text = "** NO existe";
                return;
            }

            tb_cod_ven_cli.Text = tab_cmr003.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven_cli.Text = tab_cmr003.Rows[0]["va_nom_ven"].ToString();
        }

        #endregion
    }
}
