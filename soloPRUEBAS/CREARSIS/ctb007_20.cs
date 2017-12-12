using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using CREARSIS.GLOBAL;
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

        mg_cod_ctr o_md_cod_ctr = new mg_cod_ctr();

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

            if (int.TryParse(tb_nro_aut.Text.Trim(), out tmp) == false)
            {
                va_msg_err = "Debe proporcionar un numero de autorizacion valido, solo numerico";
                tb_nro_aut.Focus();
                return va_msg_err;
            }

            if (int.TryParse(tb_nro_fac.Text.Trim(), out tmp) == false)
            {
                va_msg_err = "Debe proporcionar un numero de factura valido, solo numerico";
                tb_nro_fac.Focus();
                return va_msg_err;
            }

            if (int.TryParse(tb_nit_cli.Text.Trim(), out tmp) == false)
            {
                va_msg_err = "Debe proporcionar un nit valido, solo numerico";
                tb_nit_cli.Focus();
                return va_msg_err;
            }

            if (DateTime.TryParse(tb_fec_fac.Text.Trim(), out tmp2) == false)
            {
                va_msg_err = "Debe proporcionar una fecha valida";
                tb_fec_fac.Focus();
                return va_msg_err;
            }

            if (decimal.TryParse(tb_mto_fac.Text.Trim(), out tmp3) == false)
            {
                va_msg_err = "Debe proporcionar un monto valido, solo numerico";
                tb_mto_fac.Focus();
                return va_msg_err;
            }

            if (tb_lla_vee.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar la llave";

                tb_lla_vee.Focus();
                return va_msg_err;
            }
            tmp = 0;
            for (int i = 0; i < tb_mto_fac.Text.Count(); i++)
            {
                if (tb_mto_fac.Text[i] == '.')
                {
                    tmp++;
                }
                if (tmp >= 2)
                {
                    va_msg_err = "No puede poner mas de 1 punto en el Monto";

                    tb_mto_fac.Focus();
                    return va_msg_err;
                }

            }


            return va_msg_err;
        }

        #endregion
        
    }
}
