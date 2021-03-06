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
    public partial class ecp005_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ecp005;
        DataTable tabla;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS


        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();

        #endregion

        #region METODOS

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            if (va_tip_frm == 1)
            {
                bt_ace_pta.Enabled = false;
                bt_can_cel.Enabled = false;
            }
            if (va_tip_frm == 2)
            {
                bt_ace_pta.Enabled = true;
                bt_can_cel.Enabled = true;
            }
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);

        }
        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_ecp005 = o_ecp005._01(val_bus, prm_bus, est_bus.ToString());

            if (tab_ecp005.Rows.Count != 0)
            {

                foreach (DataRow row in tab_ecp005.Rows)
                {
                    switch (row["va_est_ado"].ToString())
                    {
                        case "H":
                            va_est_ado = "Habilitado";
                            break;
                        case "N":
                            va_est_ado = "Deshabilitado";
                            break;
                    }

                    dg_res_ult.Rows.Add(row["va_cod_plg"], row["va_des_plg"], va_est_ado);

                    dg_res_ult.Rows[va_ind_ice].Tag = row;
                    va_ind_ice = va_ind_ice + 1;
                }

            }

            if (va_ind_ice == 0)
            {
                tb_sel_ecc.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_sel_ecc.Text = tab_ecp005.Rows[0]["va_cod_plg"].ToString();
                lb_sel_ecc.Text = tab_ecp005.Rows[0]["va_des_plg"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_plg, string des_plg)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_plg;
            lb_sel_ecc.Text = des_plg;

            if (cod_plg != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_plg.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == des_plg.ToUpper())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                            return;
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBoxEx.Show(ex.Message, "Error");
                }
            }
        }
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                tb_sel_ecc.Text = "";
                return;
            }
            if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
            {
                tb_sel_ecc.Text = "";
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tabla = o_ecp005._05(int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                tb_sel_ecc.Text = "";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_plg"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_des_plg"].ToString();

        }

        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {

                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Focus();
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_ecp005 = o_ecp005._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp005.Rows.Count == 0)
                {
                    return "El Plan de Pago no se encuentra registrado";
                }

                //Verifica estado del datos
                if (tab_ecp005.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Plan de Pago  se encuentra Deshabilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat2()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Focus();
                    return "Datos Incorrectos";
                }
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Focus();
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_ecp005 = o_ecp005._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp005.Rows.Count == 0)
                {
                    return "El Plan de Pago no se encuentra registrado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }

        }
        public string fu_ver_dat3()
        {

            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Focus();
                    return "Datos Incorrectos";
                }
                ///Si aun existe
                tab_ecp005 = o_ecp005._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp005.Rows.Count == 0)
                {
                    return "El Plan de Pago no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ecp005.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Plan de Pago se encuentra Habilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        #endregion

        #region EVENTOS
        public ecp005_01()
        {
            InitializeComponent();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void ecp005_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);
        }

        private void tb_val_bus_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    //al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fu_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fu_fil_act();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vg_frm_pad.fu_rec_plg(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_plg(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region OPCIONES DE MENU
        //NUEVO
        private void m_ecp005_02_Click(object sender, EventArgs e)
        {
            CREARSIS._7_ECP.ecp005_plan_de_pago_.ecp005_02 obj = new CREARSIS._7_ECP.ecp005_plan_de_pago_.ecp005_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //ACTUALIZA
        private void m_ecp005_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp005_03 obj = new ecp005_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp005);
        }
        //HABILTA/DESHABILITA
        private void m_ecp005_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp005_04 obj = new ecp005_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp005);
        }
        //ELIMINA
        private void m_ecp005_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp005_06 obj = new ecp005_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp005);
        }
        //CONSULTA
        private void m_ecp005_05_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp005_05 obj = new ecp005_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp005);
        }
        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        #endregion

        
    }
}
