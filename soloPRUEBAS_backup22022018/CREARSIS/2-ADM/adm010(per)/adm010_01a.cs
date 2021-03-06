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



namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_01a : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm010;
        DataTable tab_adm011;
        string vv_err_msg = "";
        Boolean lventa ;
        Boolean lcompra ;
        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_adm010 o_adm010 = new c_adm010();
        c_adm011 o_adm011 = new c_adm011();
        DATOS._7_ECP.c_ecp007 o_ecp007 = new DATOS._7_ECP.c_ecp007();

        #endregion

        #region EVENTOS
        /// <summary>
        /// Instancia de la Clase
        /// </summary>
        /// <param name="lventa">Bandera que inidica si muestra o no las personas visibles para Ventas</param>
        /// <param name="lcompra">Bandera que inidica si muestra o no las personas visibles para Compras</param>
        /// <returns></returns>
        public adm010_01a(Boolean _lventa = false, Boolean _lcompra= false )
        {
            lventa = _lventa;
            lcompra = _lcompra;
            InitializeComponent();
        }

        private void adm010_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
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

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1);
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                //vg_frm_pad.fu_rec_per(tb_sel_ecc.Text, lb_sel_ecc.Text);
                vg_frm_pad.fu_rec_per(tb_sel_ecc.Text);
                vg_frm_pad.Enabled = true;
                Close();
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //vg_frm_pad.fu_rec_tal(tb_cod_gru.Text, tb_nro_tal.Text);
            vg_frm_pad.fu_rec_per(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1);

        }

        public void fu_bus_car(string val_bus, int prm_bus)
        {
            int va_ind_ice = 0;
            string va_cod_per = "";
            string va_nom_gru = "";

            dg_res_ult.Rows.Clear();

            tab_adm010 = o_adm010._01a(val_bus, prm_bus,lventa,lcompra );

            if (tab_adm010.Rows.Count != 0)
            {
                foreach (DataRow row in tab_adm010.Rows)
                {
                    
                    //agregar ceros al inicio de los codigos con 7 DIGITOS
                    va_cod_per = row["va_cod_per"].ToString().PadLeft(7, '0');


                    //Recupera y reemplaza nombre de Grupo de Almacén
                    tab_adm011 = o_adm011._05(int.Parse(row["va_cod_gru"].ToString()));
                    va_nom_gru = tab_adm011.Rows[0]["va_nom_gru"].ToString();

                    dg_res_ult.Rows.Add(va_cod_per, row["va_raz_soc"], row["va_nom_com"], row["va_nit_ced"], va_nom_gru);

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
                tb_sel_ecc.Text = tab_adm010.Rows[0]["va_cod_per"].ToString().PadLeft(7, '0');
                lb_sel_ecc.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_per, string nom_per)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1);

            tb_sel_ecc.Text = cod_per;
            lb_sel_ecc.Text = nom_per;

            if (nom_per != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_per.ToUpper() && dg_res_ult.Rows[i].Cells[2].Value.ToString().ToUpper() == nom_per.ToUpper())
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
            if (tb_sel_ecc.Text.Trim() == "")
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tab_adm010 = o_adm010._05(tb_sel_ecc.Text);
            if (tab_adm010.Rows.Count == 0)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tab_adm010.Rows[0]["va_cod_per"].ToString().PadLeft(7, '0');
            lb_sel_ecc.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }

        }

        void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[2].Value.ToString();
            }

        }
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_adm010 = o_adm010._05(tb_sel_ecc.Text);
                if (tab_adm010.Rows.Count == 0)
                {
                    return "La Persona no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_adm010.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Persona se encuentra Deshabilitada";
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
                tab_adm010 = o_adm010._05(tb_sel_ecc.Text);
                if (tab_adm010.Rows.Count == 0)
                {
                    return "La Persona no se encuentra registrada";
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
                tab_adm010 = o_adm010._05(tb_sel_ecc.Text);
                if (tab_adm010.Rows.Count == 0)
                {
                    return "La Persona no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_adm010.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "La Persona se encuentra Habilitada";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }
        public string fu_ver_dat4()
        {

            if (tb_sel_ecc.Text.Trim() != "")
            {
                ///Si aun existe
                tab_adm010 = o_adm010._05(tb_sel_ecc.Text);
                if (tab_adm010.Rows.Count == 0)
                {
                    return "La Persona no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_adm010.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Persona se encuentra Deshabilitada";
                }

                tab_adm010 = o_adm010._05(tb_sel_ecc.Text);


                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        #endregion

        #region OPCIONES DEL MENU

        //NUEVO
        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            adm010_02 obj = new adm010_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ACTUALIZA
        private void m_adm003_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adm010_03 obj = new adm010_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm010);
        }

        //HABILITA/DESHABILITA
        private void m_adm003_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adm010_04 obj = new adm010_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm010);
        }

        //ELIMINA
        private void m_adm003_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adm010_06 obj = new adm010_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm010);
        }

        //CONSULTA
        private void m_adm003_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adm010_05 obj = new adm010_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm010);
        }

        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }


        #endregion

        private void m_ecp007_01_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat4();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._7_ECP.ecp007_linea_de_credito__.ecp007_01 obj = new _7_ECP.ecp007_linea_de_credito__.ecp007_01();

            o_mg_glo_bal.mg_ads000_01(obj, this, 2, tab_adm010);
        }

      
    }
}
