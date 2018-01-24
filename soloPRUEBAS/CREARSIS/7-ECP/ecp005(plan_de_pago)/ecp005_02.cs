﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS;
using DevComponents.DotNetBar;

namespace CREARSIS._7_ECP.ecp005_plan_de_pago_
{
    public partial class ecp005_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ecp005;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_plg.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_plg.Clear();
            tb_des_plg.Clear();
            tb_nro_cuo.Clear();
            tb_int_dia.Clear();
            tb_dia_ini.Clear();

            tb_cod_plg.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_plg.Text.Trim() == "")
            {
                tb_cod_plg.Focus();
                return "Debes proporcionar el código del Plan de Pago";
            }

            tab_ecp005 = o_ecp005._05(tb_cod_plg.Text);
            if (tab_ecp005.Rows.Count != 0)
            {
                tb_cod_plg.Focus();
                return "El codigo del Plan de Pago ya se encuentra registrada";
            }

            if (tb_nom_uni.Text.Trim() == "")
            {
                tb_nom_uni.Focus();
                return "Debes proporcionar el nombre del Plan de Pago";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public ecp005_02()
        {
            InitializeComponent();
        }

        private void ecp005_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Plan de Pago", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ecp005._02(Convert.ToInt32(tb_cod_plg.Text.Trim()), tb_des_plg.Text.Trim(), Convert.ToInt32(tb_nro_cuo.Text.Trim()), Convert.ToInt32(tb_int_dia.Text.Trim()),Convert.ToInt32(tb_dia_ini.Text.Trim()));

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_plg.Text.Trim(), tb_des_plg.Text.Trim());
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
