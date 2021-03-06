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
    public partial class inv004_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv004;
        string err_msg="";

        #endregion

        #region INSTANCIAS
        
        c_inv004 o_inv004 = new c_inv004();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_mar.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_mar.Clear();
            tb_nom_mar.Clear();

            tb_cod_mar.Focus();
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
            if (o_mg_glo_bal.fg_val_num(tb_cod_mar.Text) == false)
            {
                tb_cod_mar.Focus();
                return "El codigo de la Marca debe ser Numerico";
            }
            tab_inv004 = o_inv004._05(int.Parse(tb_cod_mar.Text));
            if (tab_inv004.Rows.Count != 0)
            {
                tb_cod_mar.Focus();
                return "El codigo de la Marca ya se encuentra registrada";
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

        public inv004_02()
        {
            InitializeComponent();
        }

        

        private void inv004_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nueva Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Marca", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv004._02(int.Parse(tb_cod_mar.Text.Trim()), tb_nom_mar.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_mar.Text.Trim(), tb_nom_mar.Text.Trim());
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
