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

namespace CREARSIS._7_ECP.ecp007_linea_de_credito__
{
    public partial class ecp007_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        DataTable tab_adm010;
        DataTable tab_ecp005;
        DataTable tab_ecp006;
        DataTable tab_ecp007;
        string err_msg = "";
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        c_adm010 o_adm010 = new c_adm010();
        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();
        DATOS._7_ECP.c_ecp006 o_ecp006 = new DATOS._7_ECP.c_ecp006();
        DATOS._7_ECP.c_ecp007 o_ecp007 = new DATOS._7_ECP.c_ecp007();

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

            tab_ecp007 = o_ecp007._01(val_bus);

            if (tab_ecp007.Rows.Count != 0)
            {
                foreach (DataRow row in tab_ecp007.Rows)
                {

                    dg_res_ult.Rows.Add(row["va_cod_lib"], row["va_des_lib"], row["va_cod_per"], row["va_nom_com"], row["va_cod_plg"], row["va_des_plg"], row["va_mto_lim"], row["va_fec_exp"]);

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
                tb_sel_ecc2.Text = tab_ecp007.Rows[0]["va_cod_per"].ToString();
                tab_adm010 = o_adm010._05(tb_sel_ecc2.Text);
                lb_sel_ecc2.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();

                tb_sel_ecc.Text = tab_ecp007.Rows[0]["va_cod_lib"].ToString();
                lb_sel_ecc.Text = tab_ecp007.Rows[0]["va_des_lib"].ToString();
            }

            tb_val_bus.Focus();

        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(int cod_per, string val_bus, int prm_bus)
        {
            int va_ind_ice = 0;
            string va_mon_lis = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_ecp007 = o_ecp007._01(cod_per, val_bus, prm_bus);

            if (tab_ecp007.Rows.Count != 0)
            {
                foreach (DataRow row in tab_ecp007.Rows)
                {


                    dg_res_ult.Rows.Add(row["va_cod_lib"], row["va_des_lib"], row["va_cod_per"], row["va_nom_com"], row["va_cod_plg"], row["va_des_plg"], row["va_mto_lim"], row["va_fec_exp"]);

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
                tb_sel_ecc.Text = tab_ecp007.Rows[0]["va_cod_lib"].ToString();
                lb_sel_ecc.Text = tab_ecp007.Rows[0]["va_des_lib"].ToString();
            }

            tb_val_bus.Focus();

        }


        public void fu_ini_frm()
        {
            if (vg_str_ucc != null)
            {
                if (vg_str_ucc.Rows.Count != 0)
                {
                    tb_sel_ecc2.Text = vg_str_ucc.Rows[0]["va_cod_per"].ToString();

                }
                //lenar tbx nombre Linea de Credito
                tab_adm010 = o_adm010._05(tb_sel_ecc2.Text);
                if (tab_adm010.Rows.Count != 0)
                {
                    lb_sel_ecc2.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();
                }
            }
            cb_prm_bus.SelectedIndex = 0;

            fu_bus_car(tb_sel_ecc2.Text);

        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_lib, string des_lib)
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                fu_bus_car(tb_sel_ecc2.Text);
            }
            tb_sel_ecc.Text = cod_lib;
            lb_sel_ecc.Text = des_lib;


            if (cod_lib != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_lib.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == des_lib.ToUpper())
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


                tabla = o_ecp007._01(Convert.ToInt32(tb_sel_ecc2.Text), tb_sel_ecc.Text, 1);
                if (tabla.Rows.Count == 0)
                {
                    lb_sel_ecc.Text = "** NO existe";
                    return;
                }

                tb_sel_ecc.Text = tabla.Rows[0]["va_cod_lib"].ToString();
                lb_sel_ecc.Text = tabla.Rows[0]["va_des_lib"].ToString();
            }
            else
            {
                tb_sel_ecc.Text = "";
                lb_sel_ecc.Text = "** Ninguna Libreta Seleccionada";
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
                string cod_plg= dg_res_ult.SelectedRows[0].Cells[4].Value.ToString();
                //Si aun existe
                tab_ecp007 = o_ecp007._05(tb_sel_ecc2.Text,tb_sel_ecc.Text,int.Parse(cod_plg));
                if (tab_ecp007.Rows.Count == 0)
                {
                    return "Datos Incorrectos";
                }
                //Si aun existe
                tab_ecp006 = o_ecp006._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp006.Rows.Count == 0)
                {
                    return "La Libreta no se encuentra registrada";
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
                
                //Si aun existe
                tab_ecp007 = o_ecp007._01(tb_sel_ecc2.Text, tb_sel_ecc.Text);
                if (tab_ecp007.Rows.Count == 0)
                {
                    return "Datos Incorrectos";
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
            return null;

            //if (tb_sel_ecc2.Text.Trim() != "")
            //{
            //    //Si aun existe
            //    tab_ecp006 = o_ecp005._05(tb_sel_ecc.Text);
            //    if (tab_ecp006.Rows.Count == 0)
            //    {
            //        return "La Libreta no se encuentra registrado";
            //    }

            //    //Verifica estado del dato
            //    if (tab_ecp006.Rows[0]["va_est_ado"].ToString() == "H")
            //    {
            //        return "La Libreta se encuentra Habilitado";
            //    }


            //    return null;
            //}
            //else
            //{
            //    return "Ningún dato Seleccionado";
            //}
        }
        //---------------- Lista----------
        public void fu_rec_per(string cod_per)
        {
            
            if (cod_per.Trim() == "")
            {
                lb_sel_ecc2.Text = "** NO existe";
                fu_bus_car(tb_sel_ecc2.Text);
                return;
            }

            tab_adm010 = o_adm010._05(cod_per);
            if (tab_adm010.Rows.Count == 0)
            {
                tb_sel_ecc2.Text = "";
                lb_sel_ecc2.Text = "** NO existe";

                fu_bus_car(tb_sel_ecc2.Text);
                return;
            }

            tb_sel_ecc2.Text = tab_adm010.Rows[0]["va_cod_per"].ToString();
            lb_sel_ecc2.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();

            fu_bus_car(tb_sel_ecc2.Text);

        }
        #endregion

        #region EVENTOS

        public ecp007_01()
        {
            InitializeComponent();
        }

        private void ecp007_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
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

        private void tb_sel_ecc2_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._2_ADM.adm010_per_.adm010_01 obj = new _2_ADM.adm010_per_.adm010_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_sel_ecc2_KeyDown(object sender, KeyEventArgs e)
        {
            CREARSIS._2_ADM.adm010_per_.adm010_01 obj = new _2_ADM.adm010_per_.adm010_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_sel_ecc2_Validated(object sender, EventArgs e)
        {
            fu_rec_per(tb_sel_ecc2.Text);
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            if (lb_sel_ecc2.Text != "** NO existe")
            {
                fu_bus_car(Convert.ToInt32(tb_sel_ecc2.Text), tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1);
            }
            else
            {
                MessageBoxEx.Show("Debe Seleccionar una Linea de Creditos");
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
        #endregion

        #region OPCIONES DEL MENU

        //NUEVO
        private void m_eco007_02_Click(object sender, EventArgs e)
        {
            CREARSIS._7_ECP.ecp007_linea_de_credito__.ecp007_02 obj = new CREARSIS._7_ECP.ecp007_linea_de_credito__.ecp007_02();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm010);
        }
        //ACTUALIZA
        private void m_eco007_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ecp007_03 obj = new ecp007_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp007);
        }
        //ELIMINA
        private void m_eco007_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Linea de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ecp007_06 obj = new ecp007_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp007);
        }
        //CONSULTA
        private void m_eco007_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Linea de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ecp007_05 obj = new ecp007_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp007);
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 2);
        }

        #endregion
    }
}
