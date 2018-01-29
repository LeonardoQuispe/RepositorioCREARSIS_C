using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._5_CTB;
using DevComponents.DotNetBar;


namespace CREARSIS._5_CTB.ctb003_centr_cost_
{
    public partial class ctb003_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        DataTable tab_ctb003;
        string vv_err_msg = "";


        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_ctb003 o_ctb003 = new c_ctb003();


        public ctb003_01()
        {
            InitializeComponent();
        }

        private void ctb003_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);
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
                //vg_frm_pad.fu_rec_cct(tb_sel_ecc.Text);

                vg_frm_pad.Enabled = true;
                Close();
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //vg_frm_pad.fu_rec_cct(tb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }







        void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);

        }

        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_tip_cct = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_ctb003 = o_ctb003._01(val_bus, prm_bus, est_bus.ToString());

            if (tab_ctb003.Rows.Count != 0)
            {
                foreach (DataRow row in tab_ctb003.Rows)
                {
                    //Se valida el tipo de Centro de Costos
                    switch (row["va_tip_cct"].ToString())
                    {
                        case "M": va_tip_cct = "Matriz"; break;
                        case "A": va_tip_cct = "Analítica"; break;
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


                    dg_res_ult.Rows.Add(row["va_cod_cct"],row["va_nom_cct"],va_tip_cct, va_est_ado);

                    dg_res_ult.Rows[va_ind_ice].Tag = row;
                    va_ind_ice = va_ind_ice + 1;
                }
            }

            if (va_ind_ice == 0)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_sel_ecc.Text = tab_ctb003.Rows[0]["va_cod_cct"].ToString();
                lb_sel_ecc.Text = tab_ctb003.Rows[0]["va_nom_cct"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_cct)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_cct;

            if (cod_cct != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_cct.ToUpper())
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


            tab_ctb003 = o_ctb003._05(int.Parse(tb_sel_ecc.Text));
            if (tab_ctb003.Rows.Count == 0)
            {
                tb_sel_ecc.Clear();
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tab_ctb003.Rows[0]["va_cod_cct"].ToString();
            lb_sel_ecc.Text = tab_ctb003.Rows[0]["va_nom_cct"].ToString();

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
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }
        string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_sel_ecc.Text) == false)
                {
                    return "El Código del Centro de Costos debe ser Numérico";
                }

                //Si aun existe
                tab_ctb003 = o_ctb003._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb003.Rows.Count == 0)
                {
                    return "El Centro de Costos no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_ctb003.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Centro de Costos se encuentra Deshabilitado";
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
                    return "El Código del Centro de Costos debe ser Numérico";
                }
                //Si aun existe
                tab_ctb003 = o_ctb003._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb003.Rows.Count == 0)
                {
                    return "El Centro de Costos no se encuentra registrado";
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
                    return "El Código del Centro de Costos debe ser Numérico";
                }
                ///Si aun existe
                tab_ctb003 = o_ctb003._05(int.Parse(tb_sel_ecc.Text));
                if (tab_ctb003.Rows.Count == 0)
                {
                    return "El Centro de Costos no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_ctb003.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Centro de Costos se encuentra Habilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }








    }
}
