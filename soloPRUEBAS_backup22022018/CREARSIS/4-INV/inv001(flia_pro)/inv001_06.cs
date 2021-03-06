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
    public partial class inv001_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_inv001;
        string err_msg = "";
        string[] va_aux_cod; 

        #endregion

        #region INSTANCIAS

        c_inv001 o_inv001 = new c_inv001();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_fap.Text = vg_str_ucc.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fap.Text = vg_str_ucc.Rows[0]["va_nom_fam"].ToString();

            switch (vg_str_ucc.Rows[0]["va_tip_fam"].ToString())
            {
                case "M":

                    cb_tip_fap.SelectedIndex = 0;
                    break;
                case "D":
                    cb_tip_fap.SelectedIndex = 1;
                    break;
                case "S":
                    cb_tip_fap.SelectedIndex = 2;
                    break;
                case "C":
                    cb_tip_fap.SelectedIndex = 3;
                    break;
            }

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }
        public string fu_ver_dat()
        {
            va_aux_cod = new string[3];
            int va_aux_niv = 0;


            va_aux_cod[0] = tb_cod_fap.Text.Substring(0, 2);
            va_aux_cod[1] = tb_cod_fap.Text.Substring(2, 2);
            va_aux_cod[2] = tb_cod_fap.Text.Substring(4, 2);


            //Identifica el nuvel de la familia de producto
            for (int i = 0; i < va_aux_cod.Length; i++)
            {
                if (int.Parse(va_aux_cod[i]) > 0)
                {
                    va_aux_niv++;
                }
            }


            switch (va_aux_niv)
            {
                //Verifica si quiere elminar una FAM PROD de primer nivel
                case 1:
                    tab_inv001 = o_inv001._01(va_aux_cod[0], 1, "T");

                    if (tab_inv001.Rows.Count > 1)
                    {
                        return "Primero debe eliminar las Sub-familias que tiene registrada \n\r" +
                                "           esta Familia de Productos de primer nivel";
                    }
                    break;

                //Verifica si quiere elminar una FAM PROD de segundo nivel
                case 2:
                    tab_inv001 = o_inv001._01(va_aux_cod[0].ToString() + va_aux_cod[1].ToString(), 1, "T");

                    if (tab_inv001.Rows.Count > 1)
                    {
                        return "Primero debe eliminar las Sub-familias que tiene registrada \n\r" +
                                "           esta Familia de Productos de segundo nivel";
                    }
                    break;
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public inv001_06()
        {
            InitializeComponent();
        }

        private void inv001_06_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Elimina Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar la Familia de producto ?", "Elimina Familia de producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv001._06(tb_cod_fap.Text.Trim());                

                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex);

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
