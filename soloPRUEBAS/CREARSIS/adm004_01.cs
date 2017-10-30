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
    /// <summary>
    /// FORMULARIO NUEVO TALONARIO
    /// </summary>
    public partial class adm004_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm004;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_adm004 o_adm004 = new c_adm004();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region EVENTOS        

        public adm004_01()
        {
            InitializeComponent();
        }

        private void adm004_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex.ToString());
        }

        private void tb_val_bus_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ABAJO
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
                {
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
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void tb_cod_doc_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();
        }



        #endregion

        #region OPCIONES DEL MENU

        //[MENU- Nuevo]
        private void m_adm004_02_Click(object sender, EventArgs e)
        {
            adm004_02 obj = new adm004_02();

            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //[MENU: Actualiza]
        private void m_adm004_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm004_03 obj = new adm004_03();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm004);
        }

        //[MENU: Habilita/Deshabilita]
        private void m_adm004_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm004_04 obj = new adm004_04();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm004);
        }

        //[MENU: Consulta]
        private void m_adm004_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm004_05 obj = new adm004_05();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm004);
        }

        //[MENU: Elimina]
        private void m_adm004_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adm004_06 obj = new adm004_06();

            o_mg_glo_bal.mg_ads000_02(obj, this, tab_adm004);
        }

        //[MENU - Informe "Listado de Talonario"]
        private void m_adm004_p01_Click(object sender, EventArgs e)
        {

        }

        //[MENU - Atras]
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car("", 1, "0");

        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_cod_doc.Text=="")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            if (tb_nro_tal.Text=="")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tabla = o_adm004._05(tb_cod_doc.Text,int.Parse(tb_nro_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            tb_nro_tal.Text= tabla.Rows[0]["va_nro_tal"].ToString();
            tb_cod_doc.Text = tabla.Rows[0]["va_cod_doc"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_tal"].ToString();


            if (lb_sel_ecc.Text!= "** NO existe")
            {
                fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, lb_sel_ecc.Text);
            }


        }

        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nro_tal.Text.Trim() != "" && tb_cod_doc.Text.Trim() != "")
            {
                //Si aun existe
                tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
                if (tab_adm004.Rows.Count == 0)
                {
                    return "El Talonario no se encuentra registrado";
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
            if (tb_nro_tal.Text.Trim() != "" && tb_cod_doc.Text.Trim() != "")
            {
                //Si aun existe
                tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
                if (tab_adm004.Rows.Count == 0)
                {
                    return "El Talonario no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Talonario se encuentra Deshabilitado";
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
            if (tb_nro_tal.Text.Trim() != "" && tb_cod_doc.Text.Trim() != "")
            {
                //Si aun existe
                tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
                if (tab_adm004.Rows.Count == 0)
                {
                    return "El Talonario no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Talonario se encuentra Habilitado";
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

        public void fu_bus_car(string val_bus, int prm_bus, string est_bus)
        {
            int va_ind_ice = 0;
            string va_est_ado = "";
            string va_tip_num = "";

            dg_res_ult.Rows.Clear();

            tab_adm004 = o_adm004._01(0, val_bus, prm_bus, est_bus);

            foreach (DataRow row in tab_adm004.Rows)
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

                switch (row["va_tip_num"].ToString())
                {
                    case "0":
                        va_tip_num = "Manual";
                        break;
                    case "1":
                        va_tip_num = "Automatico";
                        break;
                }


                dg_res_ult.Rows.Add(row["va_cod_doc"].ToString(), row["va_nom_doc"].ToString(), row["va_nro_tal"].ToString(), row["va_nom_tal"].ToString(), va_tip_num, va_est_ado);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

            if (va_ind_ice == 0)
            {
                tb_cod_doc.Text = "";
                tb_nro_tal.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_cod_doc.Text = tab_adm004.Rows[0]["va_cod_doc"].ToString();
                tb_nro_tal.Text = tab_adm004.Rows[0]["va_nro_tal"].ToString();
                lb_sel_ecc.Text = tab_adm004.Rows[0]["va_nom_tal"].ToString();
            }

            tb_val_bus.Focus();

        }

        /// <summary>
        ///-> Metodo para capturar la fila seleccionada por el Talonario
        /// </summary>
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_cod_doc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                tb_nro_tal.Text = dg_res_ult.SelectedRows[0].Cells[2].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string nro_tal, string cod_doc,string nom_tal)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex.ToString());

            tb_nro_tal.Text = nro_tal;
            tb_cod_doc.Text = cod_doc;
            lb_sel_ecc.Text = nom_tal;
            

            if (nro_tal != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_doc && dg_res_ult.Rows[i].Cells[2].Value.ToString() == nro_tal && dg_res_ult.Rows[i].Cells[3].Value.ToString() == nom_tal)
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


        #endregion
        
    }
}
