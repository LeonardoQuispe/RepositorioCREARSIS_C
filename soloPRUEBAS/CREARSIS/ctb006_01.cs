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
using DevComponents.DotNetBar;
using CREARSIS.GLOBAL;

namespace CREARSIS
{
    public partial class ctb006_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb006;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_ctb006 o_ctb006 = new c_ctb006();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion


        #region METODOS
        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cb_prm_bus.SelectedIndex = 0;
            //cb_est_bus.SelectedIndex = 0

            fu_bus_car("", 1);

        }
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo;2=nombre)</param>


        public void fu_bus_car(string val_bus, int prm_bus)
        {
            int va_ind_ice = 0;
            string va_tip_usr = "";
            string va_est_ado = "";
            dynamic cod_tpr = 0;

            dg_res_ult.Rows.Clear();

            tab_ctb006 = o_ctb006._01(val_bus, prm_bus);
            foreach (DataRow row in tab_ctb006.Rows)
            {
                //Select Case row("va_est_ado")
                //    Case "H"
                //        va_est_ado = "Habilitada"
                //    Case "N"
                //        va_est_ado = "Deshabilitada"
                //End Select

                dg_res_ult.Rows.Add(row["va_cod_ley"], row["va_nom_ley"]);

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
                tb_sel_ecc.Text = tab_ctb006.Rows[0]["va_cod_ley"].ToString();
                lb_sel_ecc.Text = tab_ctb006.Rows[0]["va_nom_ley"].ToString();
            }

            tb_val_bus.Focus();

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
        #endregion

        public ctb006_01()
        {
            InitializeComponent();
        }

        private void ctb006_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_ley(tb_sel_ecc.Text);
            vg_frm_pad.Enable = true;

            Close();
        }
    }
}
