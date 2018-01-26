using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._8_TES;
using DevComponents.DotNetBar;

namespace CREARSIS._8_TES.tes001_caja_banco_
{
    public partial class tes001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_tes001;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_tes001 o_tes001 = new c_tes001();

        #endregion

        #region EVENTOS

        public tes001_02()
        {
            InitializeComponent();
        }

        private void tes001_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void cb_tip_cjb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fu_sug_nro();
            fu_cod_cjb();
        }

        private void tb_nro_cjb_Validated(object sender, EventArgs e)
        {
            fu_cod_cjb();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Caja/Banco", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                string va_mon_cjb = "";

                if (cb_mon_cjb.SelectedIndex == 0)
                {
                    va_mon_cjb = "B";
                }
                else if (cb_mon_cjb.SelectedIndex == 1)
                {
                    va_mon_cjb = "U";
                }

                //Graba datos
                o_tes001._02(int.Parse(tb_cod_cjb.Text.Trim()), cb_tip_cjb.SelectedIndex + 1, va_mon_cjb,
                            tb_nom_cjb.Text.Trim(), tb_nro_cta.Text.Trim(), 0m, tb_cod_cta.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cjb.Text.Trim());

                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_tip_cjb.SelectedIndex = 0;
            cb_mon_cjb.SelectedIndex = 0;

            fu_sug_nro();
            fu_cod_cjb();

            tb_nro_cjb.Focus();
        }

        void fu_lim_frm()
        {
            cb_tip_cjb.SelectedIndex = 0;
            cb_mon_cjb.SelectedIndex = 0;
            tb_nro_cjb.Text = "0";
            tb_cod_cjb.Text = "11000";
            tb_nom_cjb.Clear();
            tb_nro_cta.Clear();
            tb_sal_cjb.Text = "0.00";
            tb_cod_cta.Clear();

            tb_nro_cjb.Focus();

            tb_nom_cta.Clear();

            fu_sug_nro();
            fu_cod_cjb();

        }

        string fu_ver_dat()
        {
            fu_cod_cjb();

            //Valida Nro de Caja/Banco
            if (tb_nro_cjb.Text.Trim() == "")
            {
                tb_nro_cjb.Focus();
                return "Debes proporcionar el Nro de la Caja/Banco";
            }
            if (o_mg_glo_bal.fg_val_num(tb_nro_cjb.Text) == false)
            {
                tb_nro_cjb.Focus();
                return "El Nro de la Caja/Banco debe ser numérico";
            }
            if (int.Parse(tb_nro_cjb.Text.Trim()) <= 0)
            {
                tb_nro_cjb.Focus();
                return "El Nro de la Caja/Banco debe ser mayor a 0";
            }

            //Valida Codigo de Caja/Banco
            if (tb_cod_cjb.Text.Trim() == "")
            {
                tb_cod_cjb.Focus();
                return "Debes proporcionar el Código de la Caja/Banco";
            }

            tab_tes001 = o_tes001._05(int.Parse(tb_cod_cjb.Text));
            if (tab_tes001.Rows.Count != 0)
            {
                tb_nro_cjb.Focus();
                return "El Código de la Caja/Banco ya se encuentra registrado";
            }

            //Valida Nombre de Caja/Banco
            if (tb_nom_cjb.Text.Trim() == "")
            {
                tb_nom_cjb.Focus();
                return "Debes proporcionar el Nombre de la Caja/Banco";
            }

            //Valida Nro de Cuenta de Banco de Caja/Banco
            if (tb_nro_cta.Text.Trim() == "")
            {
                tb_nro_cta.Focus();
                return "Debes proporcionar el Nro. de Cuenta de la Caja/Banco";
            }

            return null;
        }

        /// <summary>
        /// Función que arma el código compuesto de Caja/Banco
        /// </summary>
        void fu_cod_cjb()
        {
            if (tb_nro_cjb.Text.Trim() == "" || o_mg_glo_bal.fg_val_num(tb_nro_cjb.Text.Trim()) == false)
            {
                tb_nro_cjb.Clear();

                tb_cod_cjb.Text = (cb_tip_cjb.SelectedIndex + 1).ToString() + (cb_mon_cjb.SelectedIndex + 1).ToString() + "000";
            }
            else
            {
                tb_cod_cjb.Text = (cb_tip_cjb.SelectedIndex + 1).ToString() + (cb_mon_cjb.SelectedIndex + 1).ToString() + tb_nro_cjb.Text.Trim().PadLeft(3, '0');
            }
        }

        /// <summary>
        /// FUnción que sugiere el último numero usado, según el Tipo y Moneda de la Caja/Banco
        /// </summary>
        void fu_sug_nro()
        {
            int tip_cjb;
            int mon_cjb;
            string nro;
            int nro_sug;

            tip_cjb = cb_tip_cjb.SelectedIndex + 1;
            mon_cjb = cb_mon_cjb.SelectedIndex + 1;

            //Numero Conformado
            nro = tip_cjb.ToString() + mon_cjb.ToString();

            //Realiza Consulta a BD con el numero conformado
            tab_tes001 = o_tes001._05a(nro);

            if (tab_tes001.Rows[0][0].ToString() == "")
            {
                tb_nro_cjb.Text = "1";
                return;
            }

            nro_sug = int.Parse(tab_tes001.Rows[0][0].ToString().Substring(2, 3)) + 1;

            tb_nro_cjb.Text = nro_sug.ToString();
        }

        #endregion
    }
}
