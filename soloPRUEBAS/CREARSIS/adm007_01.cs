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
    public partial class adm007_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm007;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_adm007 o_adm007 = new c_adm007();

        #endregion

        #region METODOS
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_doc, string nom_doc)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex.ToString());

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
            string va_est_ado = "";
            dynamic cod_tpr = 0;

            dg_res_ult.Rows.Clear();

            tab_adm007 = o_adm007._01(val_bus, prm_bus, est_bus);

            foreach (DataRow row in tab_adm007.Rows)
            {
                switch (row["va_est_ado"].ToString())
                {
                    case "H":
                        va_est_ado = "Habilitada";
                        break;
                    case "N":
                        va_est_ado = "Deshabilitada";
                        break;
                }

                dg_res_ult.Rows.Add(row["va_cod_suc"], row["va_nom_suc"], row["va_ubi_suc"], va_est_ado);

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
                tb_sel_ecc.Text = tab_adm007.Rows[0]["va_cod_suc"].ToString();
                lb_sel_ecc.Text = tab_adm007.Rows[0]["va_nom_suc"].ToString();
            }

            tb_val_bus.Focus();

        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text== "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            int tmp;

            if (int.TryParse(tb_sel_ecc.Text,out tmp) == false)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tabla = o_adm007._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_suc"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_suc"].ToString();

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
                //Si aun existe
                tab_adm007 = o_adm007._05(tb_sel_ecc.Text);
                if (tab_adm007.Rows.Count == 0)
                {
                    return "La Sucursal no se encuentra registrada";
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
            if (tb_sel_ecc.Text.Trim() != "" )
            {
                //Si aun existe
                tab_adm007 = o_adm007._05(tb_sel_ecc.Text);
                if (tab_adm007.Rows.Count == 0)
                {
                    return "La Sucursal no se encuentra registrada";
                }

                //Verifica estado del dato
                if (tab_adm007.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "La Sucursal  se encuentra Deshabilitada";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }


        }
        #endregion

        #region EVENTOS

        public adm007_01()
        {
            InitializeComponent();
        }

        private void adm007_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex.ToString());
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_suc(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
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

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }
        private void tb_sel_ecc_TextChanged(object sender, EventArgs e)
        {
            tb_sel_ecc.Text = o_mg_glo_bal.valida_numeros(tb_sel_ecc.Text);
        }

        #endregion

        #region OPCIONES DEL MENU
        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            adm007_02 obj = new adm007_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void m_adm003_03_Click(object sender, EventArgs e)
        {

            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm007_03 obj = new adm007_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm007);
        }

        private void m_adm003_04_Click(object sender, EventArgs e)
        {

            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adm007_04 obj = new adm007_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm007);
        }

        private void m_adm003_06_Click(object sender, EventArgs e)
        {

            string vv_err_msg;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm007_06 obj = new adm007_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm007);
        }

        private void m_adm003_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm007_05 obj = new adm007_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm007);
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }



        #endregion
        
    }
}
