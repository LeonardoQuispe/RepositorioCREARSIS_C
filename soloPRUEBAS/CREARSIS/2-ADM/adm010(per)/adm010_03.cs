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
using DevComponents.DotNetBar;



namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        DataTable tab_adm010;
        DataTable tab_adm011;


        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();


        public adm010_03()
        {
            InitializeComponent();
        }

        private void adm010_03_Load(object sender, EventArgs e)
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
                fu_lim_cli();
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
                fu_lim_pro();
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
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Actualiza Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }


            string mon_cre = "";
            int ban_cli = 0;
            int ban_pro = 0;
            int ban_emp = 0;

            if (chk_cli.Checked == true)
            {
                ban_cli = 1;

                if (cb_tip_cam.SelectedIndex == 0)
                {
                    mon_cre = "B";
                }
                else if (cb_tip_cam.SelectedIndex == 1)
                {
                    mon_cre = "U";
                }
            }

            if (chk_pro.Checked == true)
            {
                ban_pro = 1;
            }

            if (chk_emp.Checked == true)
            {
                ban_emp = 1;
            }

            //Guarda PERSONA
            o_adm010._03(tb_cod_per.Text.Trim(),tb_raz_per.Text.Trim(),tb_nom_per.Text.Trim(), tb_nit_per.Text.Trim(), tb_dir_gen.Text.Trim(), tb_tel_gen.Text.Trim(), 
                        tb_cel_gen.Text.Trim(),tb_ema_gen.Text.Trim(), tb_cod_pre_cli.Text.Trim(), tb_cod_ven_cli.Text.Trim(), tb_cre_cli.Text.Trim(),
                        mon_cre, tb_cod_pag_cli.Text.Trim(), tb_cod_pag_pro.Text.Trim(), ban_cli.ToString(), ban_pro.ToString(), ban_emp.ToString());

            MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_per.Text, tb_nom_per.Text);

            Close();
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
            tb_cod_gru.Text= vg_str_ucc.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = tab_adm011.Rows[0]["va_nom_gru"].ToString();
            tb_nro_per.Text = vg_str_ucc.Rows[0]["va_nro_per"].ToString();
            tb_cod_per.Text = vg_str_ucc.Rows[0]["va_cod_per"].ToString().PadLeft(7,'0');
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
            if (vg_str_ucc.Rows[0]["va_ban_cli"].ToString()=="1")
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
            if (vg_str_ucc.Rows[0]["va_mon_cre"].ToString()=="B")
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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            ////**Verifica Grupo de PErsona
            //int tmp2;

            //if (tb_cod_gru.Text.Trim() == "")
            //{
            //    tb_cod_gru.Focus();
            //    return "Debes proporcionar el Grupo de Persona";
            //}
            

            

            //if (tab_adm011.Rows[0]["va_est_ado"].ToString() == "N")
            //{
            //    tb_cod_gru.Focus();
            //    return "El Grupo de Persona se encuentra Deshabilitado";
            //}

            ////VERIFICA numero de Grupo

            //if (string.IsNullOrWhiteSpace(tb_nro_per.Text))
            //{
            //    tb_nro_per.Focus();
            //    return "Debes proporcionar el Número del Persona";
            //}

            

            ////**Verifica Codigo de Persona
            //tab_adm010 = o_adm010._05(tb_cod_per.Text);
            //if (tab_adm010.Rows.Count != 0)
            //{
            //    tb_cod_per.Focus();
            //    return "El Código de Persona ya se encuentra registrado";
            //}

            //**Verifica Razon Social
            if (tb_raz_per.Text.Trim() == "")
            {
                tb_raz_per.Focus();
                return "Debes proporcionar la Razón Social de la Persona";
            }

            //**Verifica NIT/CI
            if (tb_nit_per.Text.Trim() == "")
            {
                tb_nit_per.Focus();
                return "Debes proporcionar el NIT/CI de la Persona";
            }
            if (o_mg_glo_bal.fg_val_num(tb_nit_per.Text) == false)
            {
                tb_nit_per.Focus();
                return "El NIT/CI debe ser numérico";
            }
            tab_adm010 = o_adm010._05a(tb_nit_per.Text.Trim());
            
            if (tab_adm010.Rows.Count != 0)
            {
                if (tab_adm010.Rows[0]["va_cod_per"].ToString()!=tb_cod_per.Text)
                {
                    tb_nit_per.Focus();
                    return "El NIT/CI ya se encuentra Registrado";
                }                
            }

            //**Verifica Nombre Comercial
            if (tb_nom_per.Text.Trim() == "")
            {
                tb_nom_per.Focus();
                return "Debes proporcionar el Nombre Comercial de la Persona";
            }


            return null;
        }

        void fu_lim_cli()
        {
            tb_cod_pre_cli.Clear();
            tb_nom_pre_cli.Clear();
            tb_cod_ven_cli.Clear();
            tb_nom_ven_cli.Clear();
            tb_cre_cli.Clear();
            tb_cod_pag_cli.Clear();
            tb_nom_pag_cli.Clear();
        }

        void fu_lim_pro()
        {
            tb_cod_pag_pro.Clear();
            tb_nom_pag_pro.Clear();
        }









    }
}
