using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._7_ECP;
using DevComponents.DotNetBar;


namespace CREARSIS._7_ECP.ecp006_libreta_
{
    public partial class ecp006_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ecp006;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_ecp006 o_ecp006 = new c_ecp006();

        #endregion

        #region EVENTOS

        public ecp006_01()
        {
            InitializeComponent();
        }

        private void ecp006_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_tip_lib.SelectedIndex + 1, cb_est_bus.SelectedIndex);
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
                //vg_frm_pad.fu_rec_lib(tb_sel_ecc.Text);

                vg_frm_pad.Enabled = true;
                Close();
            }
        }


        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //vg_frm_pad.fu_rec_lib(tb_cod_gru.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region OPCIONES DE MENU

        //NUEVO
        private void m_ecp006_02_Click(object sender, EventArgs e)
        {
            ecp006_02 obj = new ecp006_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
        //ACTUALIZA
        private void m_ecp006_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Libreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp006_03 obj = new ecp006_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp006);
        }
        //HABILITA/DESHABILITA
        private void m_ecp006_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Libreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp006_04 obj = new ecp006_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp006);
        }
        //ELIMINA
        private void m_ecp006_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Libreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp006_06 obj = new ecp006_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp006);
        }
        //CONSULTA
        private void m_ecp006_05_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Libreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ecp006_05 obj = new ecp006_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ecp006);
        }
        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_tip_lib.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_tip_lib.SelectedIndex + 1, cb_est_bus.SelectedIndex);

        }

        public void fu_bus_car(string val_bus, int prm_bus, int tip_lib, int est_bus)
        {
            int va_ind_ice = 0;
            string va_tip_lib = "";
            string va_mon_lib = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_ecp006 = o_ecp006._01(val_bus, prm_bus, tip_lib, est_bus.ToString());

            if (tab_ecp006.Rows.Count != 0)
            {
                foreach (DataRow row in tab_ecp006.Rows)
                {
                    //Se valida el tipo de Libreta
                    switch (row["va_tip_lib"].ToString())
                    {
                        case "1": va_tip_lib = "Cta. Por Cobrar"; break;
                        case "2": va_tip_lib = "Cta. Por Pagar"; break;
                    }

                    switch (row["va_mon_lib"].ToString())
                    {
                        case "B": va_mon_lib = "Bolivianos"; break;
                        case "U": va_mon_lib = "Dólares"; break;
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


                    dg_res_ult.Rows.Add(row["va_cod_lib"], va_tip_lib, va_mon_lib, row["va_des_lib"], va_est_ado);

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
                tb_sel_ecc.Text = tab_ecp006.Rows[0]["va_cod_lib"].ToString();
                lb_sel_ecc.Text = tab_ecp006.Rows[0]["va_des_lib"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_lis)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_tip_lib.SelectedIndex + 1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_lis;

            if (cod_lis != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_lis.ToUpper())
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
        void fu_con_sel()
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


            tab_ecp006 = o_ecp006._05(int.Parse(tb_sel_ecc.Text));
            if (tab_ecp006.Rows.Count == 0)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tab_ecp006.Rows[0]["va_cod_lib"].ToString();
            lb_sel_ecc.Text = tab_ecp006.Rows[0]["va_des_lib"].ToString();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text);
            }

        }

        void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[3].Value.ToString();
            }

        }
        string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "El Código de la Libreta debe ser Numérico";
                }

                //Si aun existe
                tab_ecp006 = o_ecp006._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp006.Rows.Count == 0)
                {
                    return "La Libreta no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_ecp006.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Libreta se encuentra Deshabilitada";
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
        string fu_ver_dat2()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {

                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "El Código de la Libreta debe ser Numérico";
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
        string fu_ver_dat3()
        {

            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "El Código de la Libreta debe ser Numérico";
                }
                ///Si aun existe
                tab_ecp006 = o_ecp006._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ecp006.Rows.Count == 0)
                {
                    return "La Libreta no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_ecp006.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "La Libreta se encuentra Habilitada";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        #endregion
    }
}
