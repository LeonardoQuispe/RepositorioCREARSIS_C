using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS.ADM;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv003_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv003;
        DataTable tabla;
        string vv_err_msg = "";

        #endregion

        #region INSTANCIAS


        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_inv003 o_inv003 = new c_inv003();

        #endregion

        #region METODOS

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            if (va_tip_frm == 1)
            {
                bt_ace_pta.Enabled = false;
                bt_can_cel.Enabled = false;
            }
            if (va_tip_frm == 2)
            {
                bt_ace_pta.Enabled = true;
                bt_can_cel.Enabled = true;
            }
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex);

        }
        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_inv003 = o_inv003._01(val_bus, prm_bus, est_bus.ToString());

            foreach (DataRow row in tab_inv003.Rows)
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

                dg_res_ult.Rows.Add(row["va_cod_umd"], row["va_nom_umd"], va_est_ado);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

            if (va_ind_ice == 0)
            {
                tb_sel_ecc.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_sel_ecc.Text = tab_inv003.Rows[0]["va_cod_umd"].ToString();
                lb_sel_ecc.Text = tab_inv003.Rows[0]["va_nom_umd"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_doc, string nom_doc)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_doc;
            lb_sel_ecc.Text = nom_doc;

            if (cod_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_doc && dg_res_ult.Rows[i].Cells[1].Value.ToString() == nom_doc)
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


            tabla = o_inv003._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_umd"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_umd"].ToString();

        }

        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_inv003 = o_inv003._05(tb_sel_ecc.Text);
                if (tab_inv003.Rows.Count == 0)
                {
                    return "La Unidad no se encuentra registrada";
                }

                //Verifica estado del datos
                if (tab_inv003.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Unidad  se encuentra Deshabilitada";
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
                tab_inv003 = o_inv003._05(tb_sel_ecc.Text);
                if (tab_inv003.Rows.Count == 0)
                {
                    return "La Unidad no se encuentra registrada";
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
                tab_inv003 = o_inv003._05(tb_sel_ecc.Text);
                if (tab_inv003.Rows.Count == 0)
                {
                    return "La Unidad no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_inv003.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "la Unidad se encuentra Habilitada";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        #endregion
        public inv003_01()
        {
            InitializeComponent();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

       

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void inv003_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex);
        }

        private void tb_val_bus_KeyDown(object sender, KeyEventArgs e)
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

        private void tb_val_bus_Validating(object sender, CancelEventArgs e)
        {
            
        }
        

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }
        
        private void m_inv003_02_Click(object sender, EventArgs e)
        {
            inv003_02 obj = new inv003_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void m_inv003_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv003_03 obj = new inv003_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv003);
        }

        private void m_inv003_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv003_04 obj = new inv003_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv003);
        }

        private void m_inv003_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv003_06 obj = new inv003_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv003);
        }

        //[MENU- Consulta]
        private void m_inv003_05_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv003_05 obj = new inv003_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv003);
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
    }
}
