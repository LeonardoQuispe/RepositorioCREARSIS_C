using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS

using DevComponents.DotNetBar;



namespace CREARSIS
{
    public partial class ctb007_20 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        string va_msg_err = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        _01_mg_cod_ctr o_md_cod_ctr = new _01_mg_cod_ctr();

        #endregion

        #region EVENTOS

        public ctb007_20()
        {
            InitializeComponent();
        }

        private void tb_mto_fac_TextChanged(object sender, EventArgs e)
        {           

            if (tb_mto_fac.Text.Contains(","))
            {
                tb_mto_fac.Text = tb_mto_fac.Text.Replace(",", ".");

                //System.Media.SystemSounds.Beep.Play();

                //posiciona el cursor al final del texto
                tb_mto_fac.Select(tb_mto_fac.Text.Length, 0);
            }
        }

        private void bt_obt_cod_Click(object sender, EventArgs e)
        {
            if (fu_ver_dat() != null)
            {
                MessageBoxEx.Show(va_msg_err, "Error Obtener Codigo de Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tb_cod_con.Text = o_md_cod_ctr.FU_obt_ccf(tb_nro_aut.Text.Trim(), tb_nro_fac.Text.Trim(), tb_nit_cli.Text.Trim(), tb_fec_fac.Value.ToShortDateString(), Convert.ToDecimal(tb_mto_fac.Text.Trim()), tb_lla_vee.Text.Trim());

            tb_cod_con.Focus();
            tb_cod_con.SelectAll();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        public string fu_ver_dat()
        {
            va_msg_err = null;
            int tmp;
            DateTime tmp2;
            decimal tmp3;


            //Valida Nro de Autorizacion
            if (tb_nro_aut.Text.Trim()=="")
            {
                va_msg_err = "Debe proporcionar un número de Autorización";
                tb_nro_aut.Focus();
                return va_msg_err;
            }
            if (o_mg_glo_bal.fg_val_num(tb_nro_aut.Text) == false)
            {
                va_msg_err = "Debe proporcionar un número de Autorización válido, solo numérico";
                tb_nro_aut.Focus();
                return va_msg_err;
            }

            //ValidaNro de Factura
            if (tb_nro_fac.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar un número de Factura";
                tb_nro_fac.Focus();
                return va_msg_err;
            }
            if (o_mg_glo_bal.fg_val_num(tb_nro_fac.Text) == false)
            {
                va_msg_err = "Debe proporcionar un número de Factura válido, solo numérico";
                tb_nro_fac.Focus();
                return va_msg_err;
            }

            //Valida NIT
            if (tb_nit_cli.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar un NIT del Cliente";
                tb_nit_cli.Focus();
                return va_msg_err;
            }
            if (o_mg_glo_bal.fg_val_num(tb_nit_cli.Text) == false)
            {
                va_msg_err = "Debe proporcionar un NIT del Cliente válido, solo numérico";
                tb_nit_cli.Focus();
                return va_msg_err;
            }

            //Valida Fecha
            if (tb_fec_fac.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar una Fecha";
                tb_fec_fac.Focus();
                return va_msg_err;
            }
            if (DateTime.TryParse(tb_fec_fac.Text.Trim(), out tmp2) == false)
            {
                va_msg_err = "Debe proporcionar una Fecha valida";
                tb_fec_fac.Focus();
                return va_msg_err;
            }

            //Valida Monto
            if (tb_mto_fac.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar un Monto";
                tb_mto_fac.Focus();
                return va_msg_err;
            }

            va_msg_err=o_mg_glo_bal.fg_val_dec(tb_mto_fac.Text.Trim(), 10, 4);

            if (va_msg_err == null)
            {
                va_msg_err = "El Monto debe ser Numerico";
                tb_mto_fac.Focus();
                return va_msg_err;
            }

            tb_mto_fac.Text = Convert.ToDecimal(tb_mto_fac.Text.Trim()).ToString();



            //Valida Llave
            if (tb_lla_vee.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar la llave";

                tb_lla_vee.Focus();
                return va_msg_err;
            }

            va_msg_err = null;

            return va_msg_err;
        }

        #endregion
        
    }
}
