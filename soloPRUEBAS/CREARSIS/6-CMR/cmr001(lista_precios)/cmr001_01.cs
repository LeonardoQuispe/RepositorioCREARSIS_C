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

namespace CREARSIS._6_CMR.cmr001_lista_precios_
{
    public partial class cmr001_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_cmr001;
        DataTable tab_cmr002;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        DATOS._6_CMR.c_cmr002 o_cmr002 = new DATOS._6_CMR.c_cmr002();

        #endregion

        #region METODOS


        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_lis, string nom_lis)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex.ToString());

            tb_sel_ecc.Text = cod_lis;
            lb_sel_ecc.Text = nom_lis;

            if (cod_lis != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_lis.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == nom_lis.ToUpper())
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
        /// -> Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car("", 1, "T");

        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(string val_bus, int prm_bus, string est_bus)
        {
            int va_ind_ice = 0;
            string va_mon_lis = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_cmr001 = o_cmr001._01(val_bus, prm_bus, est_bus);

            if (tab_cmr001.Rows.Count != 0)
            {
                foreach (DataRow row in tab_cmr001.Rows)
                {
                    switch (row["va_mon_lis"].ToString())
                    {
                        case "B":
                            va_mon_lis = "Bolivianos";
                            break;
                        case "U":
                            va_mon_lis = "Dólares";
                            break;
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

                    dg_res_ult.Rows.Add(row["va_cod_lis"], row["va_nom_lis"], va_mon_lis, row["va_fec_ini"], row["va_fec_fin"], va_est_ado);

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
                tb_sel_ecc.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
                lb_sel_ecc.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
            }

            tb_val_bus.Focus();

        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tabla = o_cmr001._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_lis"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_lis"].ToString();

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
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_cmr001 = o_cmr001._05(tb_sel_ecc.Text);
                if (tab_cmr001.Rows.Count == 0)
                {
                    return "La Lista de Precio no se encuentra registrada";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }


        }
        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        public string fu_ver_dat2()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_cmr001 = o_cmr001._05(tb_sel_ecc.Text);
                if (tab_cmr001.Rows.Count == 0)
                {
                    return "La Lista de Precio no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_cmr001.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Lista de Precio  se encuentra Deshabilitada";
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
                tab_cmr001 = o_cmr001._05(tb_sel_ecc.Text);
                if (tab_cmr001.Rows.Count == 0)
                {
                    return "La lista de Precios no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_cmr001.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "La Lista de Precio  se encuentra Habilitada";
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
                tab_cmr001 = o_cmr001._05(tb_sel_ecc.Text);
                if (tab_cmr001.Rows.Count == 0)
                {
                    return "La lista de Precios no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_cmr001.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Lista de Precio  se encuentra Deshabilitada";
                }

                tab_cmr001 = o_cmr001._05(tb_sel_ecc.Text);


                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }
        #endregion

        #region EVENTOS

        public cmr001_01()
        {
            InitializeComponent();
        }

        private void cmr001_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex.ToString());

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_lis(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_DoubleClick(object sender, EventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_lis(tb_sel_ecc.Text);
                vg_frm_pad.Enabled = true;
                Close();
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_sel_ecc_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }

        private void tb_sel_ecc_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                if (e.KeyData == Keys.Down)
                {
                    if (dg_res_ult.CurrentRow.Index != dg_res_ult.Rows.Count - 1)
                    {
                        int fila = dg_res_ult.CurrentRow.Index + 1;
                        dg_res_ult.CurrentCell = dg_res_ult[0, fila];
                        fu_fil_act();

                    }
                }

                //al presionar tecla para ARRIBA
                if (e.KeyData == Keys.Up)
                {
                    if (dg_res_ult.CurrentRow.Index != 0)
                    {
                        int fila = dg_res_ult.CurrentRow.Index - 1;
                        dg_res_ult.CurrentCell = dg_res_ult[0, fila];
                        fu_fil_act();

                    }
                }
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

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }
        #endregion

        #region OPCIONES DEL MENU

        //BUSCA PRECIO
        private void m_cmr002_01_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat4();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CREARSIS._6_CMR.cmr002_detalle_precio_.cmr002_01 obj = new CREARSIS._6_CMR.cmr002_detalle_precio_.cmr002_01();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr001);
        }

        //MENU NUEVO
        private void m_cmr001_02_Click(object sender, EventArgs e)
        {
            cmr001_02 obj = new cmr001_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //Menu ACTUALIZA
        private void m_cmr001_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            cmr001_03 obj = new cmr001_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr001);
        }
        //MENU HABILITA/DESHABILITA
        private void m_cmr001_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmr001_04 obj = new cmr001_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr001);
        }
        //MENU ELIMINA
        private void m_cmr001_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmr001_06 obj = new cmr001_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr001);
        }
        //MENU CONSULTA
        private void m_cmr001_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmr001_05 obj = new cmr001_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr001);
        }
        //MENU ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        #endregion

        
    }
}
