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
    public partial class adm010_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_adm010;
        DataTable tab_adm011;
        string tmp = "";


        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();



        public adm010_02()
        {
            InitializeComponent();
        }

        private void adm010_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }


            string mon_cre="";
            int ban_cli =0;
            int ban_pro = 0;
            int ban_emp=0;

            if (chk_cli.Checked==true)
            {
                ban_cli = 1;

                if (cb_tip_cam.SelectedIndex==0)
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
            o_adm010._02(tb_cod_per.Text.Trim(), tb_nro_per.Text.Trim(), tb_cod_gru.Text.Trim(), tb_raz_per.Text.Trim(),
                        tb_nom_per.Text.Trim(), tb_nit_per.Text.Trim(), tb_dir_gen.Text.Trim(), tb_tel_gen.Text.Trim(), tb_cel_gen.Text.Trim(), 
                        tb_ema_gen.Text.Trim(),tb_cod_pre_cli.Text.Trim(), tb_cod_ven_cli.Text.Trim(), tb_cre_cli.Text.Trim(),
                        mon_cre, tb_cod_pag_cli.Text.Trim(),tb_cod_pag_pro.Text.Trim(), ban_cli.ToString(), ban_pro.ToString(), ban_emp.ToString());

            MessageBoxEx.Show("Operación completada exitosamente", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_per.Text, tb_nom_per.Text);   

            fu_lim_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }




        private void tb_cod_gru_ButtonCustomClick(object sender, EventArgs e)
        {
            adm011_01 obj = new adm011_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                adm011_01 obj = new adm011_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_gru_Validated(object sender, EventArgs e)
        {
            fu_rec_gru(tb_cod_gru.Text.Trim());
        }

        private void tb_nro_per_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_nro_per.Text) != true)
            {
                if (o_mg_glo_bal.fu_val_num(tb_nro_per.Text) != false)
                {
                    tmp = tb_nro_per.Text.PadLeft(5, '0');

                    tb_cod_per.Text = tb_cod_per.Text[0].ToString() + tb_cod_per.Text[1].ToString() + tmp[0].ToString() + tmp[1].ToString() + tmp[2].ToString() + tmp[3].ToString() + tmp[4].ToString();
                }
                else
                {
                    MessageBoxEx.Show("Sólo se admiten números", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

















        void fu_ini_frm()
        {
            cb_tip_cam.SelectedIndex = 0;
            

        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            //**Verifica Grupo de PErsona
            
            if (tb_cod_gru.Text.Trim() == "")
            {
                tb_cod_gru.Focus();
                return "Debes proporcionar el Grupo de Persona";
            }

            if (o_mg_glo_bal.fu_val_num(tb_cod_gru.Text) == false)
            {
                tb_cod_gru.Focus();
                return "El Codigo del Grupo de Persona NO es valido";
            }

            tab_adm011 = o_adm011._05(int.Parse(tb_cod_gru.Text));
            if (tab_adm011.Rows.Count == 0)
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona NO se encuentra registrado";
            }

            if (tab_adm011.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            //VERIFICA numero de Grupo

            if (tb_nro_per.Text.Trim()=="")
            {
                tb_nro_per.Focus();
                return "Debes proporcionar el Número del Persona";
            }

            if (int.Parse(tb_nro_per.Text) <= 0)
            {
                tb_nro_per.Focus();
                return "El Número de Persona debe ser mayor a cero";
            }

            //**Verifica Codigo de Persona
            tab_adm010 = o_adm010._05(tb_cod_per.Text);
            if (tab_adm010.Rows.Count != 0)
            {
                tb_cod_per.Focus();
                return "El Código de Persona ya se encuentra registrado";
            }

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
            if (o_mg_glo_bal.fu_val_num(tb_nit_per.Text) == false)
            {
                tb_nit_per.Focus();
                return "El NIT/CI debe ser numérico";
            }

            tab_adm010 = o_adm010._01(tb_nit_per.Text.Trim(), 4, 0.ToString());
            if (tab_adm010.Rows.Count!=0)
            {
                tb_nit_per.Focus();
                return "El NIT/CI ya se encuentra Registrado";
            }

            //**Verifica Nombre Comercial
            if (tb_nom_per.Text.Trim() == "")
            {
                tb_nom_per.Focus();
                return "Debes proporcionar el Nombre Comercial de la Persona";
            }


            return null;
        }

        public void fu_rec_gru(string cod_gru)
        {

            if (o_mg_glo_bal.fu_val_num(tb_cod_gru.Text) == false)
            {
                tb_cod_gru.Text = "";
                tb_nom_gru.Text = "** NO existe";
                return;
            }

            if (cod_gru.Trim() == "")
            {
                tb_cod_gru.Text = "";
                tb_nom_gru.Text = "** NO existe";
                tb_cod_per.Text = "00" + tb_cod_per.Text[2].ToString() + tb_cod_per.Text[3].ToString() + tb_cod_per.Text[4].ToString() + tb_cod_per.Text[5].ToString() + tb_cod_per.Text[6].ToString();
                return;
            }

            tab_adm011 = o_adm011._05(int.Parse(cod_gru));
            if (tab_adm011.Rows.Count == 0)
            {
                tb_cod_gru.Text = "";
                tb_nom_gru.Text = "** NO existe";
                tb_cod_per.Text = "00" + tb_cod_per.Text[2].ToString() + tb_cod_per.Text[3].ToString() + tb_cod_per.Text[4].ToString() + tb_cod_per.Text[5].ToString() + tb_cod_per.Text[6].ToString();
                return;
            }

            tb_cod_gru.Text = cod_gru;
            tb_nom_gru.Text = tab_adm011.Rows[0]["va_nom_gru"].ToString();

            tmp = tb_cod_gru.Text.PadLeft(2, '0');

            tb_cod_per.Text = tmp[0].ToString() + tmp[1].ToString() + tb_cod_per.Text[2].ToString() + tb_cod_per.Text[3].ToString() + tb_cod_per.Text[4].ToString() + tb_cod_per.Text[5].ToString() + tb_cod_per.Text[6].ToString();


        }
        

        void fu_lim_frm()
        {
            tb_cod_gru.Clear();
            tb_nom_gru.Clear();
            tb_nro_per.Text = "0";
            tb_cod_per.Text = "0000000";
            chk_cli.Checked = false;
            chk_pro.Checked = false;
            chk_emp.Checked = false;
            tb_raz_per.Clear();
            tb_nit_per.Clear();
            tb_nom_per.Clear();
            tb_dir_gen.Clear();
            tb_tel_gen.Clear();
            tb_cel_gen.Clear();
            tb_ema_gen.Clear();

            tb_cod_pre_cli.Clear();
            tb_nom_pre_cli.Clear();
            tb_cod_ven_cli.Clear();
            tb_nom_ven_cli.Clear();
            tb_cre_cli.Clear();
            cb_tip_cam.SelectedIndex = 0;
            tb_cod_pag_cli.Clear();
            tb_nom_pag_cli.Clear();

            tb_cod_pag_pro.Clear();
            tb_nom_pag_pro.Clear();

            tb_cod_gru.Focus();
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
