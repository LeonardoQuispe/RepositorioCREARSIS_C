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
    public partial class ctb006_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb006;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_ctb006 o_ctb006 = new c_ctb006();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_ley, string prm_bus)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1);

            tb_sel_ecc.Text = cod_ley;
            lb_sel_ecc.Text = prm_bus;

            if (cod_ley != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_ley.ToUpper())
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

            tabla = o_ctb006._05(tb_sel_ecc.Text);

            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_ley"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_ley"].ToString();

        }

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cb_prm_bus.SelectedIndex = 0;

            fu_bus_car("", 1);

        }
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>


        public void fu_bus_car(string val_bus, int prm_bus)
        {
            int va_ind_ice = 0;
            dynamic cod_tpr = 0;

            dg_res_ult.Rows.Clear();

            tab_ctb006 = o_ctb006._01(val_bus, prm_bus);

            if (tab_ctb006.Rows.Count != 0)
            {

                foreach (DataRow row in tab_ctb006.Rows)
                {
                    dg_res_ult.Rows.Add(row["va_cod_ley"], row["va_nom_ley"]);

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
                tb_sel_ecc.Text = tab_ctb006.Rows[0]["va_cod_ley"].ToString();
                lb_sel_ecc.Text = tab_ctb006.Rows[0]["va_nom_ley"].ToString();
            }

            tb_val_bus.Focus();

        }
        /// <summary>
        ///-> Metodo para capturar la fila seleccionada
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
        public ctb006_01()
        {
            InitializeComponent();
        }

        private void ctb006_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_ley(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;

            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_ley(tb_sel_ecc.Text);
                vg_frm_pad.Enabled = true;

                Close();
            }
        }

        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            DialogResult vv_res_dlg = new DialogResult();

            vv_res_dlg = MessageBoxEx.Show("Esta operacion inicializara todas las leyendas por ley de acuerdo a la ley N° 453; Esta seguro de continuar ?", "Inicializa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (vv_res_dlg == DialogResult.OK)
            {
                //Elimina e Insertar Leyenda
                o_ctb006._02();

                fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1);

            }
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1);
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

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void tb_sel_ecc_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }
        
        #endregion


    }
}
