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

namespace CREARSIS._7_ECP.ecp007_linea_de_credito__
{
    public partial class ecp007_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        DataTable tab_adm010;
        DataTable tab_ecp005;
        DataTable tab_ecp006;
        DataTable tab_ecp007;
        string err_msg = "";
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        c_adm010 o_adm010 = new c_adm010();
        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();
        DATOS._7_ECP.c_ecp006 o_ecp006 = new DATOS._7_ECP.c_ecp006();
        DATOS._7_ECP.c_ecp007 o_ecp007 = new DATOS._7_ECP.c_ecp007();

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //lenar tbx nombre Persona

            tb_cod_per.Text = vg_str_ucc.Rows[0]["va_cod_per"].ToString();

            tab_adm010 = o_adm010._05(tb_cod_per.Text);
            if (tab_adm010.Rows.Count != 0)
            {
                tb_nom_per.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();
            }

            //lenar tbx nombre Detalle de Precio
            tb_cod_lib.Text = vg_str_ucc.Rows[0]["va_cod_lib"].ToString();
            tab_ecp006 = o_ecp006._05(int.Parse(tb_cod_lib.Text));
            if (tab_ecp006.Rows.Count != 0)
            {
                tb_des_lib.Text = tab_ecp006.Rows[0]["va_des_lib"].ToString();
            }

            //lenar tbx nombre Plan de Pago
            tb_cod_plg.Text = vg_str_ucc.Rows[0]["va_cod_plg"].ToString();
            tab_ecp005 = o_ecp005._05(int.Parse(tb_cod_plg.Text));
            if (tab_ecp005.Rows.Count != 0)
            {
                tb_des_plg.Text = tab_ecp005.Rows[0]["va_des_plg"].ToString();

                tb_nro_cuo.Text = tab_ecp005.Rows[0]["va_nro_cuo"].ToString();
                tb_int_dia.Text = tab_ecp005.Rows[0]["va_int_dia"].ToString();
            }

            tb_mto_lim.Text = vg_str_ucc.Rows[0]["va_mto_lim"].ToString();
            tb_fec_exp.Text = vg_str_ucc.Rows[0]["va_fec_exp"].ToString();
            tb_max_cuo.Text = vg_str_ucc.Rows[0]["va_max_cuo"].ToString();



        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            //valida Monto limite
            if (tb_mto_lim.Text == "")
            {
                tb_mto_lim.Focus();
                return "Debes proporcionar el Monto Limite de Credito";
            }

            err_msg = o_mg_glo_bal.fg_val_dec(tb_mto_lim.Text, 12, 2);

            if (err_msg == null)
            {
                tb_mto_lim.Focus();
                return "El Monto Limite de Credito debe ser Numerico";
            }
            if (err_msg == "ent")
            {
                tb_mto_lim.Focus();
                return "El Monto Limite de Credito debe tener hasta 12 numeros Enteros";
            }
            if (err_msg == "dec")
            {
                tb_mto_lim.Focus();
                return "El Monto Limite debe tener hasta 2 números Decimales";
            }

            if (tb_max_cuo.Text != "")
            {
                if (o_mg_glo_bal.fg_val_num(tb_max_cuo.Text) == false)
                {
                    tb_max_cuo.Focus();
                    return "El Maximo de Cuotas debe ser Numerico"; ;
                }
            }
            return null;
        }


        #endregion

        #region EVENTOS

        public ecp007_03()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tmp;
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Actualiza Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos?", "Actualiza Linea de Credito", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                // grabar datos
                o_ecp007._03(int.Parse(tb_cod_lib.Text), tb_cod_per.Text, int.Parse(tb_cod_plg.Text), (decimal.TryParse(tb_mto_lim.Text, out tmp) ? tmp : 0m), 0m, tb_max_cuo.Text, tb_fec_exp.Value);

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_bus_car(tb_cod_lib.Text);
                vg_frm_pad.fu_sel_fila(tb_cod_lib.Text, tb_des_lib.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }

        private void ecp007_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
