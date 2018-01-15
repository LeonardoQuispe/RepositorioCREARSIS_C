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

namespace CREARSIS._6_CMR.cmr002_detalle_precio_
{
    public partial class cmr002_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        DataTable tab_cmr001;
        DataTable tab_cmr002;
        DataTable tab_inv002;
        string err_msg = "";
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        DATOS._6_CMR.c_cmr002 o_cmr002 = new DATOS._6_CMR.c_cmr002();
        DATOS._4_INV.c_inv002 o_inv002 = new DATOS._4_INV.c_inv002();

        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(string val_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_cmr002 = o_cmr002._01(val_bus);

            if (tab_cmr002.Rows.Count != 0)
            {
                foreach (DataRow row in tab_cmr002.Rows)
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

                    dg_res_ult.Rows.Add(row["va_cod_pro"], row["va_nom_pro"], row["va_pre_cio"], va_est_ado);

                    dg_res_ult.Rows[va_ind_ice].Tag = row;
                    va_ind_ice = va_ind_ice + 1;
                }
            }


            //if (va_ind_ice == 0)
            //{
            //    tb_sel_ecc2.Text = "";
            //    lb_sel_ecc2.Text = "** NO existe";
            //}

            if (va_ind_ice > 0)
            {
                tb_sel_ecc2.Text = tab_cmr002.Rows[0]["va_cod_lis"].ToString();
                tab_cmr001 = o_cmr001._05(tb_sel_ecc2.Text);
                lb_sel_ecc2.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();

                tb_sel_ecc.Text = tab_cmr002.Rows[0]["va_cod_pro"].ToString();
                lb_sel_ecc.Text = tab_cmr002.Rows[0]["va_nom_pro"].ToString();
            }

            tb_val_bus.Focus();

        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(int cod_lis, string val_bus, int prm_bus, string est_bus)
        {
            int va_ind_ice = 0;
            string va_mon_lis = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_cmr002 = o_cmr002._01(cod_lis,val_bus, prm_bus, est_bus);

            if (tab_cmr002.Rows.Count != 0)
            {
                foreach (DataRow row in tab_cmr002.Rows)
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

                    dg_res_ult.Rows.Add(row["va_cod_pro"], row["va_nom_pro"], row["va_pre_cio"], va_est_ado);

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
                tb_sel_ecc.Text = tab_cmr002.Rows[0]["va_cod_pro"].ToString();
                lb_sel_ecc.Text = tab_cmr002.Rows[0]["va_nom_pro"].ToString();
            }

            tb_val_bus.Focus();

        }


        public void fu_ini_frm()
        {
            if(vg_str_ucc!=null)
            {
                if (vg_str_ucc.Rows.Count != 0)
                {
                    tb_sel_ecc2.Text = vg_str_ucc.Rows[0]["va_cod_lis"].ToString();

                }
                //lenar tbx nombre lista de precio
                tab_cmr001 = o_cmr001._05(tb_sel_ecc2.Text);
                if (tab_cmr001.Rows.Count != 0)
                {
                    lb_sel_ecc2.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
                }
            }
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_sel_ecc2.Text);

        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_pro, string nom_pro)
        {
            if(tb_sel_ecc.Text.Trim() != "")
            {
                fu_bus_car(tb_sel_ecc2.Text);
            }
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
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            if (tb_sel_ecc2.Text.Trim() != "")
            {
                //Verifica que los datos en pantallas sean correctos
                if (tb_sel_ecc.Text == "")
                {
                    lb_sel_ecc.Text = "** NO existe";
                    return;
                }


                tabla = o_cmr002._01(Convert.ToInt32(tb_sel_ecc2.Text), tb_sel_ecc.Text, 1, "T");
                if (tabla.Rows.Count == 0)
                {
                    lb_sel_ecc.Text = "** NO existe";
                    return;
                }

                tb_sel_ecc.Text = tabla.Rows[0]["va_cod_pro"].ToString();
                lb_sel_ecc.Text = tabla.Rows[0]["va_nom_pro"].ToString();
            }
            else
            {
                lb_sel_ecc.Text = "** Ninguna Lista de Precios Seleccionada";
                return;
            }
            

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
            if (tb_sel_ecc2.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc2.Text) == false)
                {
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_cmr002 = o_cmr002._01(tb_sel_ecc2.Text);
                if (tab_cmr002.Rows.Count == 0)
                {
                    return "Datos Incorrectos";
                }
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
            if (tb_sel_ecc2.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc2.Text) == false)
                {
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_cmr002 = o_cmr002._01(tb_sel_ecc2.Text);
                if (tab_cmr002.Rows.Count == 0)
                {
                    return "Datos Incorrectos";
                }
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
        //---------------- Lista----------
        public void fu_rec_lis(string cod_lis)
        {
            if (o_mg_glo_bal.fg_val_num(cod_lis) == false)
            {
                lb_sel_ecc2.Text = "** NO existe";
                tb_sel_ecc2.Text = "";
                return;
            }
            if (cod_lis.Trim() == "")
            {
                lb_sel_ecc2.Text = "** NO existe";
                return;
            }

            tab_cmr001 = o_cmr001._05(cod_lis);
            if (tab_cmr001.Rows.Count == 0)
            {
                tb_sel_ecc2.Text = "";
                lb_sel_ecc2.Text = "** NO existe";
                return;
            }

            tb_sel_ecc2.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
            lb_sel_ecc2.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();

            fu_bus_car(tb_sel_ecc2.Text);
        }
        #endregion

        public cmr002_01()
        {
            InitializeComponent();
        }

        private void cmr002_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void m_cmr002_02_Click(object sender, EventArgs e)
        {
            CREARSIS._6_CMR.cmr002_detalle_precio_.cmr002_02 obj = new CREARSIS._6_CMR.cmr002_detalle_precio_.cmr002_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 2);
        }

        private void tb_sel_ecc2_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01 obj = new CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }
        private void tb_sel_ecc2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01 obj = new CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01();
                o_mg_glo_bal.mg_ads000_03(obj, this); ;
            }
        }

        private void tb_sel_ecc2_Validated(object sender, EventArgs e)
        {
            fu_rec_lis(tb_sel_ecc2.Text);
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

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            if (lb_sel_ecc2.Text != "** NO existe")
            {
                fu_bus_car(Convert.ToInt32(tb_sel_ecc2.Text), tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex.ToString());
            }
            else
            {
                MessageBoxEx.Show("Debe Seleccionar una Lista de precios");
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
        //ACTUALIZA
        private void m_cmr002_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmr002_03 obj = new cmr002_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr002);
        }
        //ELIMINA
        private void m_cmr002_06_Click(object sender, EventArgs e)
        {

        }
    }
}
