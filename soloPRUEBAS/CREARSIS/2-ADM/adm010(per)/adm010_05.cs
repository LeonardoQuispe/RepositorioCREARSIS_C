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


namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm011;


        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();


        public adm010_05()
        {
            InitializeComponent();
        }

        private void adm010_05_Load(object sender, EventArgs e)
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

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }





        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //Recupera Nombre de Grupo de Persona
            tab_adm011 = o_adm011._05(int.Parse(vg_str_ucc.Rows[0]["va_cod_gru"].ToString()));

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

            //CLIENTE
            tb_cod_pre_cli.Text = vg_str_ucc.Rows[0]["va_cod_lpr"].ToString();
            tb_cod_ven_cli.Text = vg_str_ucc.Rows[0]["va_cod_ven"].ToString();
            tb_cre_cli.Text = vg_str_ucc.Rows[0]["va_lim_cre"].ToString();
            tb_cod_pag_cli.Text = vg_str_ucc.Rows[0]["va_con_pac"].ToString();

            //PROOVEDOR
            tb_cod_pag_pro.Text = vg_str_ucc.Rows[0]["va_con_pap"].ToString();




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

        
    }
}
