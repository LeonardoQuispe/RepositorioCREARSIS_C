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

namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    public partial class ctb004_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public int va_axu_tip = 0;
        DataTable tab_ctb004;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();

        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            cb_tip_pla.SelectedIndex = 0;

            if (va_axu_tip==1)
            {
                cb_tip_pla.SelectedIndex = 2;
                fu_bus_car("", 1,2, 0); //buscar solo por analiticas
            }
            else
            {
                fu_bus_car("", 1,0, 0);
            }

            

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
                tb_sel_ecc.Text = "";
                return;
            }
            if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
            {
                lb_sel_ecc.Text = "** NO existe";
                tb_sel_ecc.Text = "";
                return;
            }

            tabla = o_ctb004._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                tb_sel_ecc.Text = "";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_cta"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_cta"].ToString();

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_ctb004 = o_ctb004._05(tb_sel_ecc.Text);
                if (tab_ctb004.Rows.Count == 0)
                {
                    return "El Plan de Cuentas no se encuentra registrado";
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
                tab_ctb004 = o_ctb004._05(tb_sel_ecc.Text);
                if (tab_ctb004.Rows.Count == 0)
                {
                    return "El Plan de Cuentas no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ctb004.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Plan de Cuentas se encuentra Deshabilitado";
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
                tab_ctb004 = o_ctb004._05(tb_sel_ecc.Text);
                if (tab_ctb004.Rows.Count == 0)
                {
                    return "El Plan de Cuentas no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ctb004.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Plan de Cuentas se encuentra Habilitado";
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

        public void fu_bus_car(string val_bus, int prm_bus, int tip_pla, int est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";
            string va_tip_cta = "";
            string va_uso_cta = "";
            string va_mon_cta = "";

            dg_res_ult.Rows.Clear();

            tab_ctb004 = o_ctb004._01(val_bus, prm_bus + 1, tip_pla, est_bus.ToString());

            if (tab_ctb004.Rows.Count != 0)
            {

                foreach (DataRow row in tab_ctb004.Rows)
                {
                    //Tipo
                    switch (row["va_tip_cta"].ToString())
                    {
                        case "M":
                            va_tip_cta = "Matriz";
                            break;
                        case "A":
                            va_tip_cta = "Analitica";
                            break;
                    }
                    //Uso
                    switch (row["va_uso_cta"].ToString())
                    {
                        case "M":
                            va_uso_cta = "Modular";
                            break;
                        case "N":
                            va_uso_cta = "Normal";
                            break;
                    }
                    //Moneda
                    switch (row["va_mon_cta"].ToString())
                    {
                        case "B":
                            va_mon_cta = "Bolivianos";
                            break;
                        case "U":
                            va_mon_cta = "Dolares";
                            break;
                    }
                    //Estado
                    switch (row["va_est_ado"].ToString())
                    {
                        case "H":
                            va_est_ado = "Habilitado";
                            break;
                        case "N":
                            va_est_ado = "Deshabilitado";
                            break;
                    }
                    
                    dg_res_ult.Rows.Add(row["va_cod_cta"], row["va_nom_cta"], va_tip_cta,va_uso_cta,va_mon_cta, va_est_ado);

                    //Cambia color de letra de fila si es de Uso Modular
                    if (va_uso_cta=="Modular" && va_tip_cta== "Analitica")
                    {
                        dg_res_ult.Rows[va_ind_ice].DefaultCellStyle.ForeColor = Color.Red;
                    }


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
                tb_sel_ecc.Text = tab_ctb004.Rows[0]["va_cod_cta"].ToString();
                lb_sel_ecc.Text = tab_ctb004.Rows[0]["va_nom_cta"].ToString();
            }


            tb_val_bus.Focus();

        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_doc, string nom_doc)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex,cb_tip_pla.SelectedIndex, cb_est_bus.SelectedIndex);

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

        public ctb004_01()
        {
            InitializeComponent();
        }

        private void ctb004_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex,cb_tip_pla.SelectedIndex, cb_est_bus.SelectedIndex);
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
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

        private void tb_sel_ecc_KeyDown(object sender, KeyEventArgs e)
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
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fu_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
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
            vg_frm_pad.fu_rec_cta(tb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_cta(tb_sel_ecc.Text);

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

        #region OPCIONES DE MENU
        //[MENU- Nuevo]
        private void m_ctb004_02_Click(object sender, EventArgs e)
        {
            ctb004_02 obj = new ctb004_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //[MENU: Actualiza]
        private void m_ctb004_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb004_03 obj = new ctb004_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb004);
        }
        //[MENU: Habilita/Deshabilita]
        private void m_ctb004_04_Click(object sender, EventArgs e)
        {

            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb004_04 obj = new ctb004_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb004);
        }
        //[MENU: Elimina]
        private void m_ctb004_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb004_06 obj = new ctb004_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb004);
        }
        //[MENU: Consulta]
        private void m_ctb004_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctb004_05 obj = new ctb004_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb004);
        }
        //[MENU - Atras]
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        #endregion

        
    }
}
