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

namespace CREARSIS._5_CTB.ctb002_cap_agru_
{
    public partial class ctb002_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb002;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._5_CTB.c_ctb002 o_ctb002 = new DATOS._5_CTB.c_ctb002();

        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car("", 1, 0);

            tb_val_bus.Focus();
        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text.Trim() == "")
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tabla = o_ctb002._05(int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {                
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_cap"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_cap"].ToString();

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
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
                tab_ctb002 = o_ctb002._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb002.Rows.Count == 0)
                {
                    return "El Capitulo/Agrupador no se encuentra registrado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitado)
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
                //Si aun existe
                tab_ctb002 = o_ctb002._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb002.Rows.Count == 0)
                {
                    return "El Capitulo/Agrupador no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ctb002.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Capitulo/Agrupador se encuentra Deshabilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Deshabilitado)   
        /// (para ventana Elimina)
        /// </summary>
        public string fu_ver_dat3()
        {

            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Focus();
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_ctb002 = o_ctb002._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb002.Rows.Count == 0)
                {
                    return "El Capitulo/Agrupador no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ctb002.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Capitulo/Agrupador se encuentra Habilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }

        }
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_tra_cap = "";
            bool va_cen_cto = false;
            string va_est_ado = "";
            

            dg_res_ult.Rows.Clear();

            tab_ctb002 = o_ctb002._01(val_bus, prm_bus + 1, est_bus.ToString());

            if (tab_ctb002.Rows.Count != 0)
            {
                foreach (DataRow row in tab_ctb002.Rows)
                {
                    //Valida Tratamiento
                    switch (row["va_tra_cap"].ToString())
                    {
                        case "D":
                            va_tra_cap = "Deudor";
                            break;
                        case "A":
                            va_tra_cap = "Acreedor";
                            break;
                    }

                    //Valida si usa Centro de Costo
                    switch (row["va_cen_cto"].ToString())
                    {
                        case "0": va_cen_cto = false; break;
                        case "1": va_cen_cto = true; break;
                    }


                    switch (row["va_est_ado"].ToString())
                    {
                        case "H":
                            va_est_ado = "Habilitado";
                            break;
                        case "N":
                            va_est_ado = "Deshabilitado";
                            break;
                    }

                    dg_res_ult.Rows.Add(row["va_cod_cap"], row["va_nom_cap"], va_tra_cap,
                                        chk_cen_cto.Checked=va_cen_cto, va_est_ado);

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
                tb_sel_ecc.Text = tab_ctb002.Rows[0]["va_cod_cap"].ToString();
                lb_sel_ecc.Text = tab_ctb002.Rows[0]["va_nom_cap"].ToString();
            }


            tb_val_bus.Focus();

        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_doc, string nom_doc)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_doc;
            lb_sel_ecc.Text = nom_doc;

            if (cod_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_doc.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == nom_doc.ToUpper())
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

        /// <summary>
        /// Método para llenar codigo y nombre de usuario
        /// </summary>
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
        #endregion

        #region EVENTOS

        public ctb002_01()
        {
            InitializeComponent();
        }

        private void ctb002_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);
        }

        private void tb_sel_ecc_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
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
        
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_doc(tb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_doc(tb_sel_ecc.Text);

                vg_frm_pad.Enabled = true;
                Close();
            }
        }
        #endregion

        #region OPCIONES DE MENU
        //[MENU- Nuevo]
        private void m_ctb002_02_Click(object sender, EventArgs e)
        {
            ctb002_02 obj = new ctb002_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //[MENU: Actualiza]
        private void m_ctb002_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb002_03 obj = new ctb002_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb002);
        }
        //[MENU: Habilita/Deshabilita]
        private void m_ctb002_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb002_04 obj = new ctb002_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb002);
        }
        //[MENU: Elimina]
        private void m_ctb002_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb002_06 obj = new ctb002_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb002);
        }
        //[MENU: Consulta]
        private void m_ctb002_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb002_05 obj = new ctb002_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb002);
        }
        //[MENU - Atras]
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        #endregion
    }
}
