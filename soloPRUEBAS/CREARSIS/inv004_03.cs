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

namespace CREARSIS
{
    public partial class inv004_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv004 o_inv004 = new c_inv004();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_mar.Text = vg_str_ucc.Rows[0]["va_cod_mar"].ToString();
            tb_nom_mar.Text = vg_str_ucc.Rows[0]["va_nom_mar"].ToString();

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
            if (tb_cod_mar.Text.Trim() == "")
            {
                tb_cod_mar.Focus();
                return "Debes proporcionar el código de la Marca";
            }
            

            if (tb_nom_mar.Text.Trim() == "")
            {
                tb_nom_mar.Focus();
                return "Debes proporcionar el nombre de la Marca";
            }

            return null;
        }

        #endregion

        #region EVENTOS
        public inv004_03()
        {
            InitializeComponent();
        }

        private void inv004_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Marca", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv004._03(int.Parse(tb_cod_mar.Text.Trim()), tb_nom_mar.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_mar.Text.Trim(), tb_nom_mar.Text.Trim());
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
