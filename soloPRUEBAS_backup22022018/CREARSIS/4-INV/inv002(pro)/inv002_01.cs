﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._4_INV;
using DevComponents.DotNetBar;

namespace CREARSIS._4_INV.inv002_pro_
{
    public partial class inv002_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv001;
        DataTable tab_inv002;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS.c_inv001 o_inv001 = new DATOS.c_inv001();
        c_inv002 o_inv002 = new c_inv002();

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
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tabla = o_inv002._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_pro"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_pro"].ToString();

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_inv002 = o_inv002._05(tb_sel_ecc.Text);
                if (tab_inv002.Rows.Count == 0)
                {
                    return "El Producto no se encuentra registrado";
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
                //Si aun existe
                tab_inv002 = o_inv002._05(tb_sel_ecc.Text);
                if (tab_inv002.Rows.Count == 0)
                {
                    return "El Producto no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_inv002.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Producto se encuentra Deshabilitado";
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
                //Si aun existe
                tab_inv002 = o_inv002._05(tb_sel_ecc.Text);
                if (tab_inv002.Rows.Count == 0)
                {
                    return "El Producto no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_inv002.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Producto se encuentra Habilitado";
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
            string va_cod_fam;
            string va_nom_fam;
            bool va_ban_ven = false;
            bool va_ban_com = false;
            string va_est_ado = "";


            dg_res_ult.Rows.Clear();

            tab_inv002 = o_inv002._01(val_bus, prm_bus + 1, est_bus.ToString());

            if (tab_inv002.Rows.Count != 0)
            {
                foreach (DataRow row in tab_inv002.Rows)
                {
                    //Recupera Codigo y nombre de Familia de Producto
                    tab_inv001 = o_inv001._05(row["va_cod_fam"].ToString());

                    va_cod_fam = tab_inv001.Rows[0]["va_cod_fam"].ToString();
                    va_nom_fam = tab_inv001.Rows[0]["va_nom_fam"].ToString();


                    //Inicializa las bandera en falso
                    va_ban_ven = false;
                    va_ban_com = false;

                    //Valida la visibilidad del producto(compras-Ventas) y lo muestra en un Checkbox
                    if (row["va_ban_vta"].ToString() == "1")
                    {
                        va_ban_ven = true;
                    }
                    if (row["va_ban_cmp"].ToString() == "1")
                    {
                        va_ban_com = true;
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

                    dg_res_ult.Rows.Add(row["va_cod_pro"], row["va_nom_pro"], row["va_des_pro"], row["va_fab_ric"],
                                        va_cod_fam, va_nom_fam, ban_ven.Checked = va_ban_ven, 
                                        ban_com.Checked = va_ban_com,va_est_ado);

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
                tb_sel_ecc.Text = tab_inv002.Rows[0]["va_cod_pro"].ToString();
                lb_sel_ecc.Text = tab_inv002.Rows[0]["va_nom_pro"].ToString();
            }

            tb_val_bus.Focus();

        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_pro, string nom_pro)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_pro;
            lb_sel_ecc.Text = nom_pro;

            if (cod_pro != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_pro.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == nom_pro.ToUpper())
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

        public inv002_01()
        {
            InitializeComponent();
        }

        private void inv002_01_Load(object sender, EventArgs e)
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
            vg_frm_pad.fu_rec_pro(tb_sel_ecc.Text, lb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_pro(tb_sel_ecc.Text,lb_sel_ecc.Text );

                vg_frm_pad.Enabled = true;
                Close();
            }
        }
        
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        #endregion


        //[MENU- Nuevo]
        private void m_inv002_02_Click(object sender, EventArgs e)
        {
            CREARSIS._4_INV.inv002_pro_.inv002_02 obj = new CREARSIS._4_INV.inv002_pro_.inv002_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //[MENU: Actualiza]
        private void m_inv002_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._4_INV.inv002_pro_.inv002_03 obj = new CREARSIS._4_INV.inv002_pro_.inv002_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv002);
        }
        //[MENU: Habilita/Deshabilita]
        private void m_inv002_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._4_INV.inv002_pro_.inv002_04 obj = new CREARSIS._4_INV.inv002_pro_.inv002_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv002);
        }
        //[MENU: Elimina]
        private void m_inv002_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._4_INV.inv002_pro_.inv002_06 obj = new CREARSIS._4_INV.inv002_pro_.inv002_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv002);
        }
        //[MENU: Consulta]
        private void m_inv002_05_Click(object sender, EventArgs e)
        {

            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._4_INV.inv002_pro_.inv002_05 obj = new CREARSIS._4_INV.inv002_pro_.inv002_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv002);
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        
    }
}
