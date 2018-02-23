using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._6_CMR;
using DevComponents.DotNetBar;


namespace CREARSIS._6_CMR.cmr003_vendedor_
{
    public partial class cmr003_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        decimal tmp;

        #endregion

        #region INSTANCIAS

        c_cmr003 o_cmr003 = new c_cmr003();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public cmr003_03()
        {
            InitializeComponent();
        }

        private void cmr003_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Actualiza Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }


            //Guarda Vendedor
            o_cmr003._03(tb_cod_ven.Text.Trim(), tb_nom_ven.Text.Trim(), Convert.ToDecimal(tb_por_ven.Text.Trim()), cb_tip_com.SelectedIndex + 1);

            MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_ven.Text, tb_nom_ven.Text);

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

            tb_cod_ven.Text = vg_str_ucc.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven.Text = vg_str_ucc.Rows[0]["va_nom_ven"].ToString();
            tb_por_ven.Text = vg_str_ucc.Rows[0]["va_por_cms"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;
                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            switch (vg_str_ucc.Rows[0]["va_tip_cms"].ToString())
            {
                case "1": cb_tip_com.SelectedIndex = 0; break;
                case "2": cb_tip_com.SelectedIndex = 1; break;
            }
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        string fu_ver_dat()
        {
            //VERIFICA nombre de vendedor

            if (tb_nom_ven.Text.Trim() == "")
            {
                tb_nom_ven.Focus();
                return "Debes proporcionar el Nombre del Vendedor";
            }

            //VERIFICA porcentaje de Comisión

            err_msg = o_mg_glo_bal.fg_val_dec(tb_por_ven.Text, 4, 2);

            if (err_msg == null)
            {
                tb_por_ven.Focus();
                return "El Porcentaje de Comisión debe ser Numérico-Decimal";
            }
            if (err_msg == "ent")
            {
                tb_por_ven.Focus();
                return "El Porcentaje de Comisión debe tener hasta 6 numeros Enteros";
            }
            if (err_msg == "dec")
            {
                tb_por_ven.Focus();
                return "El Porcentaje de Comisión debe tener hasta 2 números Decimales";
            }

            decimal.TryParse(tb_por_ven.Text, out tmp);

            if (tmp > 100)
            {
                return "El Porcentaje de Comisión no debe ser mayor a 100";
            }


            return null;
        }

        #endregion
    }
}
