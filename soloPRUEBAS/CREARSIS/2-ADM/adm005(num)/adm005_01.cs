using System;
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
    /// <summary>
    /// FORMULARIO NUMERACIONES
    /// </summary>
    public partial class adm005_01 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES
        
        public dynamic vg_frm_pad;
        DataTable tab_adm002;
        DataTable tab_adm004;
        DataTable tab_adm005;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_adm002 o_adm002 = new c_adm002();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();

        #endregion

        #region METODOS
        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm(int va_tip_frm = 0)
        {
            try
            {

                cb_prm_bus.SelectedIndex = 0;

                //Obtiene datos de gestion/periodo
                tab_adm002 = o_adm002._05();

                //Carga datos en el comboBox (Gestion)
                cb_ges_tio.DisplayMember = "va_cod_ges";
                cb_ges_tio.ValueMember = "va_cod_ges";
                cb_ges_tio.DataSource = tab_adm002;
                

                if (cb_ges_tio.SelectedValue!= null && o_mg_glo_bal.fg_val_num(cb_ges_tio.SelectedValue.ToString()) == false)
                {
                    fu_bus_car("", 1, 0);
                }
                else
                {
                    fu_bus_car("", 1, Convert.ToInt32(cb_ges_tio.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_nro_tal.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            if (tb_cod_doc.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            if (tb_cod_ges.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_num(tb_nro_tal.Text) == true)
            {
                tabla = o_adm005._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text), int.Parse(tb_cod_ges.Text));

                if (tabla.Rows.Count == 0)
                {
                    lb_sel_ecc.Text = "** NO existe";
                    return;
                }

                tb_nro_tal.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                tb_cod_doc.Text = tabla.Rows[0]["va_cod_doc"].ToString();
                tb_cod_ges.Text = tabla.Rows[0]["va_cod_ges"].ToString();

                lb_sel_ecc.Text = tabla.Rows[0]["va_nom_tal"].ToString();
            }

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_cod_ges.Text);
            }


        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nro_tal.Text.Trim() != "" && tb_cod_doc.Text.Trim() != "" && tb_cod_ges.Text.Trim() != "")
            {
                //Si aun existe Numeración
                tab_adm004 = o_adm004._05(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text));
                if (tab_adm004.Rows.Count == 0)
                {
                    return "El Numeración no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Numeración se encuentra Deshabilitado";
                }
                //Si aun existe  Numeracion
                tab_adm005 = o_adm005._05(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text), Convert.ToInt32(tb_cod_ges.Text));
                if (tab_adm005.Rows.Count == 0)
                {
                    return "El Numerador para el Numeración (" + tb_cod_doc.Text + "/" + tb_nro_tal.Text + ") no se encuentra registrado en la gestión " + tb_cod_ges.Text + "";
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
        /// <param name="cod_ges">Codigo de la gestion</param>

        public void fu_bus_car(string val_bus, int prm_bus, int cod_ges)
        {
            int va_ind_ice = 0;

            dg_res_ult.Rows.Clear();

            tab_adm005 = o_adm005._01(cod_ges, val_bus, prm_bus);

            if (tab_adm005.Rows.Count != 0)
            {
                foreach (DataRow row in tab_adm005.Rows)
                {
                    dg_res_ult.Rows.Add(row["va_cod_ges"], row["va_cod_doc"], row["va_nom_doc"], row["va_nro_tal"], row["va_nom_tal"], row["va_nro_ini"], row["va_nro_fin"], row["va_fec_ini"], row["va_fec_fin"]);

                    dg_res_ult.Rows[va_ind_ice].Tag = row;
                    va_ind_ice = va_ind_ice + 1;
                }
            }


            if (va_ind_ice == 0)
            {
                tb_nro_tal.Text = "";
                tb_cod_doc.Text = "";
                tb_cod_ges.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_nro_tal.Text = tab_adm005.Rows[0]["va_nro_tal"].ToString();
                tb_cod_doc.Text = tab_adm005.Rows[0]["va_cod_doc"].ToString();
                tb_cod_ges.Text = tab_adm005.Rows[0]["va_cod_ges"].ToString();
                lb_sel_ecc.Text = tab_adm005.Rows[0]["va_nom_tal"].ToString();
            }            

            tb_val_bus.Focus();

        }

        /// <summary>
        ///-> Metodo para capturar la fila seleccionada por el Numeración
        /// </summary>
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_cod_doc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                tb_nro_tal.Text = dg_res_ult.SelectedRows[0].Cells[3].Value.ToString();
                tb_cod_ges.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();

                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string nro_tal, string cod_doc, string cod_gest)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, int.Parse(cb_ges_tio.SelectedValue.ToString()));

            tb_nro_tal.Text = nro_tal;
            tb_cod_doc.Text = cod_doc;
            tb_cod_ges.Text = cod_gest;


            if (nro_tal != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == cod_doc.ToUpper() && dg_res_ult.Rows[i].Cells[3].Value.ToString().ToUpper() == nro_tal.ToUpper() && dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_gest.ToUpper())
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


        #endregion

        #region EVENTOS

        public adm005_01()
        {
            InitializeComponent();
        }
        private void adm005_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, Convert.ToInt32(cb_ges_tio.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                        if (dg_res_ult.CurrentRow.Index != dg_res_ult.Rows.Count - 1)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.CurrentRow.Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fu_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        if (dg_res_ult.CurrentRow.Index != 0)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.CurrentRow.Index - 1];

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
            vg_frm_pad.fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);

                vg_frm_pad.Enabled = true;
                Close();
            }
            
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void tb_nro_tal_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();
        }

        #endregion

        #region OPCIONES DE MENU

        //[MENU- Nuevo]
        private void m_adm005_02_Click(object sender, EventArgs e)
        {
            try
            {
                adm005_02 obj = new adm005_02();
                o_mg_glo_bal.mg_ads000_02(obj, this);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //[MENU: Actualiza]
        private void m_adm005_03_Click(object sender, EventArgs e)
        {

            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat();
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                adm005_03 obj = new adm005_03();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm005);

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //[MENU: Elimina]
        private void m_adm005_06_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat();
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                adm005_06 obj = new adm005_06();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm005);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //[MENU: Consulta]
        private void m_adm005_05_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat();
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                adm005_05 obj = new adm005_05();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm005);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //[MENU - Informe "Listado de NUMERACIONES"]
        private void m_adm005_p01_Click(object sender, EventArgs e)
        {

        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }



        #endregion

        
    }
}
