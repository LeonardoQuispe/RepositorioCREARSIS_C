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

namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    public partial class ctb004_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        string[] va_mat_cod;
        int va_niv_lin = 0;

        #endregion

        #region INSTANCIAS

        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();
        DataTable tab_ctb004;

        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();
            tb_nom_cta.Text = vg_str_ucc.Rows[0]["va_nom_cta"].ToString();

            switch (vg_str_ucc.Rows[0]["va_tip_cta"].ToString())
            {
                case "M": cb_tip_cta.SelectedIndex = 0; break;
                case "A": cb_tip_cta.SelectedIndex = 1; break;
            }
            switch (vg_str_ucc.Rows[0]["va_uso_cta"].ToString())
            {
                case "M": cb_uso_cta.SelectedIndex = 0; break;
                case "N": cb_uso_cta.SelectedIndex = 1; break;
            }
            switch (vg_str_ucc.Rows[0]["va_mon_cta"].ToString())
            {
                case "B": cb_mon_cta.SelectedIndex = 0; break;
                case "U": cb_mon_cta.SelectedIndex = 1; break;
            }

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;

                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            tb_nom_cta.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_cta.Clear();
            tb_nom_cta.Clear();

            cb_tip_cta.SelectedIndex = 0;
            cb_uso_cta.SelectedIndex = 0;
            cb_mon_cta.SelectedIndex = 0;

            tb_cod_cta.Focus();
        }


        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            va_mat_cod = new string[5];
            va_niv_lin = 0;

            //Recupera los niveles del código
            va_mat_cod[0] = tb_cod_cta.Text.Substring(0, 1);    //1er Nivel
            va_mat_cod[1] = tb_cod_cta.Text.Substring(2, 1);    //2do Nivel
            va_mat_cod[2] = tb_cod_cta.Text.Substring(4, 1);    //3er Nivel
            va_mat_cod[3] = tb_cod_cta.Text.Substring(6, 2);    //4to Nivel
            va_mat_cod[4] = tb_cod_cta.Text.Substring(9, 3);    //5to Nivel

            for (int i = 0; i < va_mat_cod.Length; i++)
            {
                if (int.Parse(va_mat_cod[i]) > 0)
                {
                    va_niv_lin++;
                }
            }


            switch (va_niv_lin)
            {
                //Verifica si quiere Eliminar un PLAN DE CUENTAS de primer nivel
                case 1:
                    tab_ctb004 = o_ctb004._01(va_mat_cod[0].ToString(), 1, 0, "T");
                    break;

                //Verifica si quiere Eliminar un PLAN DE CUENTAS de segundo nivel
                case 2:
                    tab_ctb004 = o_ctb004._01(va_mat_cod[0].ToString() + "." + va_mat_cod[1], 1, 0, "T");
                    break;

                //Verifica si quiere Eliminar un PLAN DE CUENTAS de tercer nivel
                case 3:
                    tab_ctb004 = o_ctb004._01(va_mat_cod[0].ToString() + "." + va_mat_cod[1].ToString() + "." + va_mat_cod[2], 1, 0, "T");
                    break;

                //Verifica si quiere Eliminar un PLAN DE CUENTAS de cuarto nivel
                case 4:
                    tab_ctb004 = o_ctb004._01(va_mat_cod[0].ToString() + "." + va_mat_cod[1].ToString() + "." + va_mat_cod[2].ToString() + "." + va_mat_cod[3], 1, 0, "T");
                    break;
            }

            if (va_niv_lin != 5)
            {
                //Valida que el PLAN DE CUENTAS no tenga Sub-familias Registradas
                if (tab_ctb004.Rows.Count>1)
                {
                    return "Primero debe eliminar las Sub-familias que tiene registrada \n\r" +
                        "               este Plan de Cuentas de nivel " + va_niv_lin.ToString();
                }
                
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public ctb004_06()
        {
            InitializeComponent();
        }

        private void ctb004_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Elimina Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar el Plan de Cuentas ?", "Elimina Plan de Cuentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ctb004._06(tb_cod_cta.Text.Trim());

                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1,vg_frm_pad.cb_tip_pla.SelectedIndex, vg_frm_pad.cb_est_bus.SelectedIndex);

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
