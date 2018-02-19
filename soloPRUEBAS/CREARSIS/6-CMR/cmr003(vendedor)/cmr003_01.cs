using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._6_CMR;
using DevComponents.DotNetBar;

namespace CREARSIS._6_CMR.cmr003_vendedor_
{
    public partial class cmr003_01 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES
        
        public dynamic vg_frm_pad;
        DataTable tab_cmr003;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_cmr003 o_cmr003 = new c_cmr003();

        #endregion

        #region EVENTOS

        public cmr003_01()
        {
            InitializeComponent();
        }

        private void cmr003_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);
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

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_frm.Enabled == true)
            {
                vg_frm_pad.fu_rec_ven(tb_sel_ecc.Text);

                vg_frm_pad.Enabled = true;
                Close();
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_ven(tb_sel_ecc.Text);

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
        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            cmr003_02 obj = new cmr003_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ACTUALIZA
        private void m_adm003_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmr003_03 obj = new cmr003_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr003);
        }

        //HABILITA/DESHABILITA
        private void m_adm003_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmr003_04 obj = new cmr003_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr003);
        }

        //ELIMINA
        private void m_adm003_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmr003_06 obj = new cmr003_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr003);
        }

        //CONSULTA
        private void m_adm003_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Busca Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmr003_05 obj = new cmr003_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_cmr003);
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
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);

        }

        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_cmr003 = o_cmr003._01(val_bus, prm_bus, est_bus.ToString());

            if (tab_cmr003.Rows.Count != 0)
            {
                foreach (DataRow row in tab_cmr003.Rows)
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


                    dg_res_ult.Rows.Add(row["va_cod_ven"], row["va_nom_ven"], va_est_ado);

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
                tb_sel_ecc.Text = tab_cmr003.Rows[0]["va_cod_ven"].ToString();
                lb_sel_ecc.Text = tab_cmr003.Rows[0]["va_nom_ven"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_ven, string nom_ven)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_ven;
            lb_sel_ecc.Text = nom_ven;

            if (nom_ven != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_ven.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == nom_ven.ToUpper())
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


            tab_cmr003 = o_cmr003._05(tb_sel_ecc.Text.Trim());
            if (tab_cmr003.Rows.Count == 0)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tab_cmr003.Rows[0]["va_cod_ven"].ToString();
            lb_sel_ecc.Text = tab_cmr003.Rows[0]["va_nom_ven"].ToString();

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
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }

        string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    tb_sel_ecc.Clear();
                    lb_sel_ecc.Text = "** NO existe";
                    return "El Código de Vendedor debe ser Numérico";
                }

                //Si aun existe
                tab_cmr003 = o_cmr003._05(tb_sel_ecc.Text);
                if (tab_cmr003.Rows.Count == 0)
                {
                    return "El Vendedor no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_cmr003.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Vendedor se encuentra Deshabilitado";
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
                    tb_sel_ecc.Clear();
                    lb_sel_ecc.Text = "** NO existe";
                    return "El Código de Vendedor debe ser Numérico";
                }

                //Si aun existe
                tab_cmr003 = o_cmr003._05(tb_sel_ecc.Text);
                if (tab_cmr003.Rows.Count == 0)
                {
                    return "El Vendedor no se encuentra registrado";
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
                    tb_sel_ecc.Clear();
                    lb_sel_ecc.Text = "** NO existe";
                    return "El Código de Vendedor debe ser Numérico";
                }

                ///Si aun existe
                tab_cmr003 = o_cmr003._05(tb_sel_ecc.Text);
                if (tab_cmr003.Rows.Count == 0)
                {
                    return "El Vendedor no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_cmr003.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Vendedor se encuentra Habilitado";
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
