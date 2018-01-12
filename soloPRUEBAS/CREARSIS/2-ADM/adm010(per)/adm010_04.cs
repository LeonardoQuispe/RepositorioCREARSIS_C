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
using DevComponents.DotNetBar;


namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_04 : DevComponents.DotNetBar.Metro.MetroForm
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

        public adm010_04()
        {
            InitializeComponent();
        }

        private void adm010_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void chk_cli_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            if (chk_cli.Checked == true)
            {
                tab_cli.Visible = true;
            }
            else if (chk_cli.Checked == false)
            {
                tab_cli.Visible = false;
            }
        }

        private void chk_pro_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            if (chk_pro.Checked == true)
            {
                tab_prv.Visible = true;
            }
            else if (chk_pro.Checked == false)
            {
                tab_prv.Visible = false;
            }
        }

        private void chk_emp_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            //if (chk_emp.Checked == true)
            //{
            //    tab_emp.Visible = true;
            //}
            //else if (chk_emp.Checked == false)
            //{
            //    tab_emp.Visible = false;
            //}
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            if (tb_est_ado.Text == "Habilitado")
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la Persona?", "Deshabilita Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar la Persona?", "Habilita Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }



            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Graba datos
            if (tb_est_ado.Text == "Habilitado")
            {
                o_adm010._04(tb_cod_per.Text.Trim(), "N");
            }
            else
            {
                o_adm010._04(tb_cod_per.Text.Trim(), "H");
            }

            MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_per.Text.Trim(), tb_nom_per.Text.Trim());

            Close();
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
            if (vg_str_ucc.Rows[0]["va_ban_cli"].ToString() == "1")
            {
                chk_cli.Checked = true;
            }

            if (vg_str_ucc.Rows[0]["va_ban_pro"].ToString() == "1")
            {
                chk_pro.Checked = true;
            }

            if (vg_str_ucc.Rows[0]["va_ban_emp"].ToString() == "1")
            {
                chk_emp.Checked = true;
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


            if (chk_cli.Checked==true)
            {
                //CLIENTE
                tb_cod_pre_cli.Text = vg_str_ucc.Rows[0]["va_cod_lpr"].ToString();
                tb_cod_ven_cli.Text = vg_str_ucc.Rows[0]["va_cod_ven"].ToString();
                fu_rec_ven(tb_cod_ven_cli.Text);
                tb_cre_cli.Text = vg_str_ucc.Rows[0]["va_lim_cre"].ToString();
                tb_cod_pag_cli.Text = vg_str_ucc.Rows[0]["va_con_pac"].ToString();
            }

            if (chk_pro.Checked == true)
            {
                //PROOVEDOR
                tb_cod_pag_pro.Text = vg_str_ucc.Rows[0]["va_con_pap"].ToString();

            }


            
            //Elige tipo de cambio
            if (vg_str_ucc.Rows[0]["va_mon_cre"].ToString() == "B")
            {
                cb_tip_cam.SelectedIndex = 0;
            }
            else if (vg_str_ucc.Rows[0]["va_mon_cre"].ToString() == "U")
            {
                cb_tip_cam.SelectedIndex = 1;
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
