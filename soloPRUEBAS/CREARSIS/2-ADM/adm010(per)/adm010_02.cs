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
using CREARSIS._6_CMR.cmr003_vendedor_;
using CREARSIS._6_CMR.cmr001_lista_precios_;
using DATOS;
using DATOS._6_CMR;
using DevComponents.DotNetBar;



namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_02 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_adm010;
        DataTable tab_adm011;
        DataTable tab_cmr003;
        DataTable tab_cmr001;
        string tmp = "";

        #endregion

        #region INSTANCIAS

        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();
        c_cmr003 o_cmr003 = new c_cmr003();
        c_cmr001 o_cmr001 = new c_cmr001();

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

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


            int ban_ven = 0;
            int ban_com = 0;
            int ban_emp = 0;
           

            if (chk_ven.Checked == true)
            {
                ban_ven = 1;               
            }

            if (chk_com.Checked == true)
            {
                ban_com = 1;
            }
            
            //Guarda PERSONA
            o_adm010._02(tb_cod_per.Text.Trim(), tb_nro_per.Text.Trim(), tb_cod_gru.Text.Trim(), tb_raz_per.Text.Trim(),
                        tb_nom_per.Text.Trim(), tb_nit_per.Text.Trim(), tb_dir_gen.Text.Trim(), tb_tel_gen.Text.Trim(), tb_cel_gen.Text.Trim(),
                        tb_ema_gen.Text.Trim(), tb_cod_pre_cli.Text.Trim(), tb_cod_ven_cli.Text.Trim(), ban_ven.ToString(), ban_com.ToString());

            MessageBoxEx.Show("Operación completada exitosamente", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_per.Text, tb_nom_per.Text);

            fu_lim_frm();

            tb_cod_gru.Focus();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chk_ven_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            if (chk_ven.Checked == true)
            {
                tab_ven.Visible = true;
            }
            else if (chk_ven.Checked == false)
            {
                fu_lim_ven();
                tab_ven.Visible = false;
            }
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
                if (o_mg_glo_bal.fg_val_num(tb_nro_per.Text) != false)
                {
                    tmp = tb_nro_per.Text.PadLeft(5, '0');

                    tb_cod_per.Text = tb_cod_per.Text[0].ToString() + tb_cod_per.Text[1].ToString() + tmp[0].ToString() + tmp[1].ToString() + tmp[2].ToString() + tmp[3].ToString() + tmp[4].ToString();
                    return;
                }
            }

            tb_nro_per.Clear();
            tb_cod_per.Text = tb_cod_per.Text[0].ToString() + tb_cod_per.Text[1].ToString() + "00000";

        }
        

        private void tb_cod_ven_cli_ButtonCustomClick(object sender, EventArgs e)
        {
            cmr003_01 obj = new cmr003_01();

            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_ven_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                cmr003_01 obj = new cmr003_01();

                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_ven_cli_Validated(object sender, EventArgs e)
        {
            fu_rec_ven(tb_cod_ven_cli.Text.Trim());
        }

        private void tb_cod_pre_cli_ButtonCustomClick(object sender, EventArgs e)
        {
            cmr001_01 obj = new cmr001_01();

            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_pre_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                cmr001_01 obj = new cmr001_01();

                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_pre_cli_Validated(object sender, EventArgs e)
        {
            fu_rec_lis(tb_cod_pre_cli.Text.Trim());
        }


        #endregion

        #region METODOS

        void fu_ini_frm()
        {

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

            if (o_mg_glo_bal.fg_val_num(tb_cod_gru.Text) == false)
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

            //VERIFICA numero de Persona

            if (tb_nro_per.Text.Trim() == "")
            {
                tb_nro_per.Focus();
                return "Debes proporcionar el Número del Persona";
            }

            if (o_mg_glo_bal.fg_val_num(tb_nro_per.Text) == false)
            {
                tb_nro_per.Focus();
                return "El Número del Persona debe ser Numérico";
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

            //Verifica Visible en:

            if (chk_ven.Checked==false && chk_com.Checked==false)
            {
                chk_ven.Focus();
                return "Debe seleccionar al menos una opción de la Visibilidad de la Persona";
            }


            //**Verifica Razon Social
            if (tb_raz_per.Text.Trim() == "")
            {
                tb_raz_per.Focus();
                return "Debes proporcionar la Razón Social de la Persona";
            }

            //**Verifica Nombre Comercial
            if (tb_nom_per.Text.Trim() == "")
            {
                tb_nom_per.Focus();
                return "Debes proporcionar el Nombre Comercial de la Persona";
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
                tb_nit_per.Focus();
                return "El NIT/CI ya se encuentra Registrado";
            }

            //valida Lista de Precio y Vendedor antes de grabar datos
            if (chk_ven.Checked == true)
            {
                //Valida Lista de Precio antes de Grabar datos
                fu_rec_lis(tb_cod_pre_cli.Text);


                //Valida Vendedor antes de Grabar datos
                fu_rec_ven(tb_cod_ven_cli.Text);
            }

            

            return null;
        }

        public void fu_rec_gru(string cod_gru)
        {

            if (o_mg_glo_bal.fg_val_num(cod_gru) == false)
            {
                tb_cod_gru.Text = "";
                tb_nom_gru.Text = "** NO existe";
                tb_cod_per.Text = "00" + tb_cod_per.Text[2].ToString() + tb_cod_per.Text[3].ToString() + tb_cod_per.Text[4].ToString() + tb_cod_per.Text[5].ToString() + tb_cod_per.Text[6].ToString();
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


            //Funcion que sugiere un numero de persona de acuerdo al grupo de persona
            tab_adm010 = o_adm010._05b(int.Parse(cod_gru));

            if (tab_adm010.Rows[0][0].ToString() != "")
            {
                int va_sug_nro_per = (Convert.ToInt32(tab_adm010.Rows[0][0].ToString()) + 1);

                if (va_sug_nro_per <= 99999)
                {
                    tb_nro_per.Text = va_sug_nro_per.ToString();

                    tb_cod_per.Text = tb_cod_per.Text[0].ToString() + tb_cod_per.Text[1].ToString() + va_sug_nro_per.ToString().PadLeft(5, '0');
                }
            }
            else
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = tb_cod_per.Text[0].ToString() + tb_cod_per.Text[1].ToString() + "00000";
            }
        }

        public void fu_rec_lis(string cod_lis)
        {
            if (cod_lis.Trim() == "")
            {
                tb_cod_pre_cli.Clear();
                tb_nom_pre_cli.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_num(cod_lis) == false)
            {
                tb_cod_pre_cli.Clear();
                tb_nom_pre_cli.Text = "** NO existe";
                return;
            }

            tab_cmr001 = o_cmr001._05(cod_lis);
            if (tab_cmr001.Rows.Count == 0)
            {
                tb_cod_pre_cli.Clear();
                tb_nom_pre_cli.Text = "** NO existe";
                return;
            }

            if (tab_cmr001.Rows[0]["va_est_ado"].ToString()=="N")
            {
                tb_cod_pre_cli.Clear();
                tb_nom_pre_cli.Text = "** NO existe";

                MessageBoxEx.Show("La Lista de Precio se encuentra Deshabilitada", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            tb_cod_pre_cli.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
            tb_nom_pre_cli.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
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

            if (tab_cmr003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_ven_cli.Clear();
                tb_nom_ven_cli.Text = "** NO existe";

                MessageBoxEx.Show("El Vendedor se encuentra Deshabilitado", "Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            tb_cod_ven_cli.Text = tab_cmr003.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven_cli.Text = tab_cmr003.Rows[0]["va_nom_ven"].ToString();
        }


        void fu_lim_frm()
        {
            tb_cod_gru.Clear();
            tb_nom_gru.Clear();
            tb_nro_per.Text = "0";
            tb_cod_per.Text = "0000000";
            chk_ven.Checked = false;
            chk_com.Checked = false;
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
            
            tb_cod_gru.Focus();
        }

        void fu_lim_ven()
        {
            tb_cod_pre_cli.Clear();
            tb_nom_pre_cli.Clear();
            tb_cod_ven_cli.Clear();
            tb_nom_ven_cli.Clear();
        }
















        #endregion

        
    }
}
