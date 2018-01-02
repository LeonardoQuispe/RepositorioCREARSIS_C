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



namespace CREARSIS
{
    public partial class ctb007_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        DataTable tab_ctb007;        

        #endregion

        #region INSTANCIAS

        c_ctb007 o_ctb007 = new c_ctb007();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public ctb007_01()
        {
            InitializeComponent();
        }

        private void ctb007_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, tb_fec_ini.Value, tb_fec_fin.Value, cb_est_bus.SelectedIndex.ToString());
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

        private void tb_sel_ecc_Validating(object sender, CancelEventArgs e)
        {            
            fu_con_sel();
        }

        private void tb_sel_ecc_TextChanged(object sender, EventArgs e)
        {
            tb_sel_ecc.Text = o_mg_glo_bal.valida_numeros(tb_sel_ecc.Text);
            tb_sel_ecc.Select(tb_sel_ecc.Text.Length, 0);
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_dos(tb_sel_ecc.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            tb_fec_fin.Value = DateTime.Today;
            tb_fec_ini.Value = tb_fec_fin.Value.AddDays(-180);

            fu_bus_car("", 1, tb_fec_ini.Value, tb_fec_fin.Value, "");

        }
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>
        public void fu_bus_car(string val_bus, int prm_bus, DateTime fec_ini, DateTime fec_fin, string est_bus)
        {

            try
            {
                int va_ind_ice = 0;
                string va_tip_usr = "";
                string va_est_ado = "";
                dynamic cod_tpr = 0;

                dg_res_ult.Rows.Clear();

                tab_ctb007 = o_ctb007._01(val_bus, prm_bus, fec_ini, fec_fin, est_bus);
                foreach (DataRow row in tab_ctb007.Rows)
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

                    if (row["va_lla_vee"].ToString()!="")
                    {
                        dg_res_ult.Rows.Add(row["va_nro_aut"], row["va_cod_suc"], row["va_fec_ini"], row["va_fec_fin"], va_est_ado,va_lla_vee.Checked=true);
                    }
                    else
                    {
                        dg_res_ult.Rows.Add(row["va_nro_aut"], row["va_cod_suc"], row["va_fec_ini"], row["va_fec_fin"], va_est_ado);
                    }                    

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
                    tb_sel_ecc.Text = tab_ctb007.Rows[0]["va_nro_aut"].ToString();
                    lb_sel_ecc.Text = "";
                }

                tb_val_bus.Focus();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        public string fu_ver_dat(string acc_ion)
        {
            try
            {
                if (tb_sel_ecc.Text.Trim() == "")
                {
                    tb_sel_ecc.Focus();
                    return "Ningún dato Seleccionado";
                    
                }
                else if (tb_sel_ecc.Text.Trim() == "0")
                {
                    tb_sel_ecc.Focus();
                    return "Debe ser diferente de cero";
                }


                switch (acc_ion)
                {
                    case "03": acc_ion = "ctb007_01p3"; break;
                    case "03a": acc_ion = "ctb007_01p3a"; break;
                    case "04": acc_ion = "ctb007_01p4"; break;
                    case "05": acc_ion = "ctb007_01p5"; break;
                    case "06": acc_ion = "ctb007_01p6"; break;
                }

                tb_sel_ecc.Focus();
                tab_ctb007 = o_ctb007._055(acc_ion, Int64.Parse(tb_sel_ecc.Text));                               

                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        string fu_ver_dat2()
        {
            ///Si aun existe
            tab_ctb007 = o_ctb007._05(long.Parse(tb_sel_ecc.Text));
            if (tab_ctb007.Rows.Count == 0)
            {
                return "La Dosificación no se encuentra registrada";
            }

            //Verifica estado del dato
            if (tab_ctb007.Rows[0]["va_tip_fac"].ToString() != "0")
            {
                return "Sólo las facturas Emitidas por Computadora pueden Actualizar Llave";
            }

            return null;
        }
        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        //public string fu_ver_dat3()
        //{
        //    if (tb_sel_ecc.Text.Trim() != "")
        //    {
        //        //Si aun existe
        //        tab_ctb007 = o_ctb007._05(tb_sel_ecc.Text);
        //        if (tab_ctb007.Rows.Count == 0)
        //        {
        //            return "La Dosificación  no se encuentra registrada";
        //        }

        //        //Verifica estado del dato
        //        if (tab_ctb007.Rows[0]["va_est_ado"].ToString() == "N")
        //        {
        //            return "La Dosificación se encuentra Deshabilitada";
        //        }

        //        return null;
        //    }
        //    else
        //    {
        //        return "Ningún dato Seleccionado";
        //    }

        //}
        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Int64 tmp;

            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text.Trim() == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            else if (tb_sel_ecc.Text.Trim()== "0")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            //if (Int64.TryParse(tb_sel_ecc.Text, out tmp) == false)
            //{
            //    lb_sel_ecc.Text = "** NO existe";
            //    return;
            //}


            tab_ctb007 = o_ctb007._05(Int64.Parse(tb_sel_ecc.Text));
            if (tab_ctb007.Rows.Count==0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tab_ctb007.Rows[0]["va_nro_aut"].ToString();
            lb_sel_ecc.Text = "";

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text);
            }

        }
        /// <summary>
        ///-> Metodo para capturar la fila seleccionada
        /// </summary>
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells["va_nro_aut"].Value.ToString();
                lb_sel_ecc.Text = "";
            }

        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_dos)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, tb_fec_ini.Value, tb_fec_fin.Value, cb_est_bus.SelectedIndex.ToString());

            tb_sel_ecc.Text = cod_dos;
            lb_sel_ecc.Text = "";

            if (cod_dos != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().Trim().ToUpper() == cod_dos.Trim().ToUpper())
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

        #region OPCIONES DE MENU

        //NUEVO
        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            ctb007_02 obj = new ctb007_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ACTUALIZA
        private void m_adm003_03_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat("03");

                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            ctb007_03 obj = new ctb007_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb007);
        }

        //ACTUALIZA LLAVE
        private void mn_act_lla_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat2();
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctb007_03a obj = new ctb007_03a();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb007);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        //HABILITA/DESHABILITA
        private void m_adm003_04_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat("04");
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctb007_04 obj = new ctb007_04();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb007);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        //ELIMINA
        private void m_adm003_06_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat("06");
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctb007_06 obj = new ctb007_06();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb007);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //CONSULTA
        private void m_adm003_05_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_err_msg = null;
                vv_err_msg = fu_ver_dat("05");
                if (vv_err_msg != null)
                {
                    MessageBoxEx.Show(vv_err_msg, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctb007_05 obj = new ctb007_05();
                o_mg_glo_bal.mg_ads000_02(obj, this, tab_ctb007);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }
        
        //VERIFICA CODIGO CONTROL
        private void mn_ver_ccf_Click(object sender, EventArgs e)
        {   
            ctb007_20 obj = new ctb007_20();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        #endregion

        
    }
}
