using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DevComponents.DotNetBar;
using DATOS.ADM;
using CREARSIS.GLOBAL;


namespace CREARSIS
{
    public partial class adm012_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        c_adm012 o_adm012 = new c_adm012();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        DataTable tab_adm012;
        DataTable tabla;


        public adm012_01()
        {
            InitializeComponent();
        }

        private void adm012_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex+1, cb_est_bus.SelectedIndex.ToString());
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void tb_sel_ecc_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_act(tb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }






        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm(int va_tip_frm = 0)
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
            string va_tip_usr = "";
            string va_est_ado = "";
            dynamic cod_tpr = 0;

            dg_res_ult.Rows.Clear();

            tab_adm012 = o_adm012._01(val_bus, prm_bus, est_bus);
            foreach (DataRow row in tab_adm012.Rows)
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

                dg_res_ult.Rows.Add(row["va_cod_act"], row["va_nom_act"], va_est_ado);

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
                tb_sel_ecc.Text = tab_adm012.Rows[0]["va_cod_act"].ToString();
                lb_sel_ecc.Text = tab_adm012.Rows[0]["va_nom_act"].ToString();
            }

            tb_val_bus.Focus();

        }
        /// <summary>
        ///-> Metodo para capturar la fila seleccionada
        /// </summary>
        public void fu_fil_act()
        {
            int fila = dg_res_ult.CurrentCellAddress.Y;

            tb_sel_ecc.Text = dg_res_ult.Rows[fila].Cells["va_cod_act"].Value.ToString();
            lb_sel_ecc.Text = dg_res_ult.Rows[fila].Cells["va_nom_act"].Value.ToString();

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            //Si aun existe
            tab_adm012 = o_adm012._05(tb_sel_ecc.Text);
            if (tab_adm012.Rows.Count == 0)
            {
                return "La Actividad Economica no se encuentra registrada";
            }

            return null;
        }
        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        public string fu_ver_dat2()
        {
            //Si aun existe
            tab_adm012 = o_adm012._05(tb_sel_ecc.Text);
            if (tab_adm012.Rows.Count == 0)
            {
                return "La Actividad Economica no se encuentra registrada";
            }

            //Verifica estado del dato
            if (tab_adm012.Rows[0]["va_est_ado"].ToString()== "N")
            {
                return "La Actividad Economica se encuentra Deshabilitada";
            }

            return null;
        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            int tmp;

            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text.Trim()=="")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            if (int.TryParse(tb_sel_ecc.Text,out tmp) == false)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tabla = o_adm012._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_act"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_act"].ToString();

        }


        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_act, string nom_act)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex.ToString());

            tb_sel_ecc.Text = cod_act;
            lb_sel_ecc.Text = nom_act;


            if (cod_act != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_act && dg_res_ult.Rows[i].Cells[1].Value.ToString() == nom_act)
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


        //NUEVO
        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            adm012_02 obj = new adm012_02();

            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ACTUALIZA
        private void m_adm003_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm012_03 obj = new adm012_03();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm012);
        }

        //HABILITA/DESHABILITA
        private void m_adm003_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm012_04 obj = new adm012_04();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm012);
        }

        //ELIMINA
        private void m_adm003_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm012_06 obj = new adm012_06();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm012);
        }

        //CONSULTA
        private void m_adm003_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm012_05 obj = new adm012_05();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm012);
        }

        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
    }
}
