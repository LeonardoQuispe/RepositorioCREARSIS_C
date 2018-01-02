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
    /// <summary>
    /// FORMULARIO BUSCA USUARIO
    /// </summary>
    public partial class seg001_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_seg001;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_seg001 o_seg001 = new c_seg001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public seg001_01()
        {
            InitializeComponent();
        }

        private void seg001_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }
        //Boton Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_usr(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vg_frm_pad.fu_rec_usr(tb_sel_ecc.Text);
            vg_frm_pad.Enabled = true;
            Close();
        }

        //Boton Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);
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

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        #endregion

        #region OPCIONES DEL MENU

        //[MENU- Nuevo]
        private void m_seg001_02_Click(object sender, EventArgs e)
        {
            seg001_02 seg001_02 = new seg001_02();

            o_mg_glo_bal.mg_ads000_02(seg001_02, this);
        }

        //[MENU: Actualiza]
        private void m_seg001_03_Click(object sender, EventArgs e)
        {
            string vv_err_msg;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            seg001_03 seg001_03 = new seg001_03();
            o_mg_glo_bal.mg_ads000_02(seg001_03, this, tab_seg001);
        }

        //[MENU: Inicializa contraseña]
        private void m_seg001_03a_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            seg001_03a seg001_03a = new seg001_03a();
            o_mg_glo_bal.mg_ads000_02(seg001_03a, this, tab_seg001);

        }

        //[MENU: Habilita/Deshabilita]
        private void m_seg001_04_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            seg001_04 seg001_04 = new seg001_04();
            o_mg_glo_bal.mg_ads000_02(seg001_04, this, tab_seg001);
        }

        //[MENU: Elimina]
        private void m_seg001_06_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            seg001_06 seg001_06 = new seg001_06();
            o_mg_glo_bal.mg_ads000_02(seg001_06, this, tab_seg001);
        }

        private void m_seg001_05_Click(object sender, EventArgs e)
        {
            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            seg001_05 seg001_05 = new seg001_05();
            o_mg_glo_bal.mg_ads000_02(seg001_05, this, tab_seg001);
        }

        //[MENU - Informe "Listado de Usuario"]
        private void m_seg001_p01_Click(object sender, EventArgs e)
        {
            //seg001_01wp seg001_01wp = new seg001_01wp();
            seg001_wp01 obj = new seg001_wp01();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
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

            fu_bus_car("", 0, 0);

            tb_val_bus.Focus();

        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text.Trim() == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tabla = o_seg001._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            
            lb_sel_ecc.Text = Convert.ToString(tabla.Rows[0]["va_nom_usr"]);

        }

        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            //Si aun existe
            tab_seg001 = o_seg001._05(tb_sel_ecc.Text);
            if (tab_seg001.Rows.Count == 0)
            {
                return "El Usuario no se encuentra registrado";
            }

            return null;
        }

        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitado)
        /// </summary>
        public string fu_ver_dat2()
        {
            //Si aun existe
            tab_seg001 = o_seg001._05(tb_sel_ecc.Text);
            if (tab_seg001.Rows.Count == 0)
            {
                return "El Usuario no se encuentra registrado";
            }

            //Verifica estado del dato
            if (((string)(tab_seg001.Rows[0]["va_est_ado"])) == "N")
            {
                return "El Usuario se encuentra Deshabilitado";
            }

            return null;
        }

        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Deshabilitado)   
        /// (para ventana Elimina)
        /// </summary>
        public string fu_ver_dat3()
        {
            //Si aun existe
            tab_seg001 = o_seg001._05(tb_sel_ecc.Text);
            if (tab_seg001.Rows.Count == 0)
            {
                return "El Usuario no se encuentra registrado";
            }

            //Verifica estado del dato
            if (tab_seg001.Rows[0]["va_est_ado"].ToString() == "H")
            {
                return "El Usuario se encuentra Habilitado";
            }

            return null;
        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>
        /// <param name="pos_dg">Posicion de fila a Seleccionar</param>
        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_tip_usr = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_seg001 = o_seg001._01(val_bus, prm_bus, est_bus);
            foreach (DataRow row in tab_seg001.Rows)
            {
                switch (row["va_tip_usr"].ToString())
                {
                    case "1":
                        va_tip_usr = "Administrador";
                        break;
                    case "2":
                        va_tip_usr = "Supervisor";
                        break;
                    case "3":
                        va_tip_usr = "Normal";
                        break;
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

                dg_res_ult.Rows.Add(row["va_cod_usr"], row["va_nom_usr"], va_tip_usr, va_est_ado);

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
                
                    tb_sel_ecc.Text = tab_seg001.Rows[0]["va_cod_usr"].ToString();
                    lb_sel_ecc.Text = tab_seg001.Rows[0]["va_nom_usr"].ToString();
                              
            }
            
            tb_val_bus.Focus();

        }

        
        

        /// <summary>
        /// Método para llenar codigo y nombre de usuario
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
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_usr,string nom_usr)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_usr;
            lb_sel_ecc.Text = nom_usr;

            if (cod_usr != null)
            {          
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper() && dg_res_ult.Rows[i].Cells[1].Value.ToString().ToUpper() == nom_usr.ToUpper())
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
