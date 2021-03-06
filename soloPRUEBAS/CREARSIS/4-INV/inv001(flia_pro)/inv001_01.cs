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
    public partial class inv001_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv001;
        DataTable tabla;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS


        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_inv001 o_inv001 = new c_inv001();

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

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex);

        }
        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";
            string va_tip_fap = "";
            string va_nom_fam = "";

            dg_res_ult.Rows.Clear();

            tab_inv001 = o_inv001._01(val_bus, prm_bus, est_bus.ToString());

            if (tab_inv001.Rows.Count != 0)
            {

                foreach (DataRow row in tab_inv001.Rows)
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

                    switch (row["va_tip_fam"].ToString())
                    {
                        case "M":

                            va_tip_fap = "Matriz";
                            break;
                        case "D":
                            va_tip_fap = "Detalle";
                            break;
                        case "S":
                            va_tip_fap = "Servicio";
                            break;
                        case "C":
                            va_tip_fap = "Combo";
                            break;
                    }

                    //Ordena nombre de famiia de acuerdo al nivel (3 Niveles)
                    va_nom_fam = row["va_cod_fam"].ToString();

                    int a = int.Parse(va_nom_fam.Substring(0, 2));

                    if (int.Parse(va_nom_fam.Substring(4, 2)) > 0)
                    {
                        va_nom_fam = "--.--." + row["va_nom_fam"].ToString();
                    }
                    else if (int.Parse(va_nom_fam.Substring(2, 2)) > 0)
                    {
                        va_nom_fam = "--." + row["va_nom_fam"].ToString();
                    }
                    else if (int.Parse(va_nom_fam.Substring(0, 2)) > 0)
                    {
                        va_nom_fam = row["va_nom_fam"].ToString();
                    }
                    else
                    {
                        va_nom_fam = row["va_nom_fam"].ToString();
                    }


                    dg_res_ult.Rows.Add(row["va_cod_fam"], va_nom_fam, va_tip_fap, va_est_ado);

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
                tb_sel_ecc.Text = tab_inv001.Rows[0]["va_cod_fam"].ToString();
                lb_sel_ecc.Text = tab_inv001.Rows[0]["va_nom_fam"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_fap)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_fap;

            if (cod_fap != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_fap.ToUpper())
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
                return;
            }


            tabla = o_inv001._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_fam"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_fam"].ToString();

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
                //Si aun existe
                tab_inv001 = o_inv001._05(tb_sel_ecc.Text);
                if (tab_inv001.Rows.Count == 0)
                {
                    return "La Familia de producto no se encuentra registrada";
                }

                //Verifica estado del datos
                if (tab_inv001.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Familia de producto  se encuentra Deshabilitada";
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
                //Si aun existe
                tab_inv001 = o_inv001._05(tb_sel_ecc.Text);
                if (tab_inv001.Rows.Count == 0)
                {
                    return "La Familia de producto no se encuentra registrada";
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
                ///Si aun existe
                tab_inv001 = o_inv001._05(tb_sel_ecc.Text);
                if (tab_inv001.Rows.Count == 0)
                {
                    return "La Familia de producto no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_inv001.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "la Familia de producto se encuentra Habilitada";
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
        public inv001_01()
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

        private void inv001_01_Load(object sender, EventArgs e)
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
                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            dg_res_ult.Show();

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
        private void tb_sel_ecc_Validating_1(object sender, CancelEventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text);
            }
        }

        private void dg_res_ult_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged_1(object sender, EventArgs e)
        {
            fu_fil_act();
        }
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_fam(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_fam(tb_sel_ecc.Text);
                vg_frm_pad.Enabled = true;
                Close();
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region OPCIONES DE MENU

        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        //NUEVO
        private void m_inv001_02_Click(object sender, EventArgs e)
        {
            inv001_02 obj = new inv001_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //ACTUALIZA
        private void m_inv001_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv001_03 obj = new inv001_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv001);
        }
        //HABILITA/DESHABILITA
        private void m_inv001_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv001_04 obj = new inv001_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv001);
        }
        //CONSULTA
        private void m_inv001_05_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv001_05 obj = new inv001_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv001);
        }
        //ELIMINA
        private void m_inv001_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv001_06 obj = new inv001_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv001);
        }

        #endregion

        

        
    }
}
