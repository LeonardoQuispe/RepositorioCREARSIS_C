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
    public partial class cmr003_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_cmr003;
        decimal tmp;

        c_cmr003 o_cmr003 = new c_cmr003();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();


        public cmr003_02()
        {
            InitializeComponent();
        }

        private void cmr003_02_Load(object sender, EventArgs e)
        {
            cb_tip_com.SelectedIndex = 0;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Nuevo Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }
            
            //Guarda PERSONA
            o_cmr003._02(tb_cod_ven.Text.Trim(), tb_nom_ven.Text.Trim(),Convert.ToDecimal(tb_por_ven.Text.Trim()), cb_tip_com.SelectedIndex+1);

            MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_ven.Text, tb_nom_ven.Text);

            fu_lim_frm();

            tb_cod_ven.Focus();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        



        



        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            //**Verifica codigo de Vendedor

            if (tb_cod_ven.Text.Trim() == "")
            {
                tb_cod_ven.Focus();
                return "Debes proporcionar el Grupo de Persona";
            }            

            tab_cmr003 = o_cmr003._05(tb_cod_ven.Text);
            if (tab_cmr003.Rows.Count != 0)
            {
                tb_cod_ven.Focus();
                return "El Código de Vendedor ya se encuentra Registrado";
            }            

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

            if (tmp>100)
            {
                return "El Porcentaje de Comisión no debe ser mayor a 100";
            }


            return null;
        }


        void fu_lim_frm()
        {
            tb_cod_ven.Clear();
            tb_nom_ven.Clear();
            tb_por_ven.Clear();            
            cb_tip_com.SelectedIndex = 0;            
        }





    }
}
