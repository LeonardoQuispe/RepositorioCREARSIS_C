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
        ///// </summary>
        //public string fu_ver_dat()
        //{
        //    if (tb_cod_lib.Text == "")
        //    {
        //        tb_cod_lib.Focus();
        //        return "Debes proporcionar el codigo de la Lista de Precio";
        //    }
        //    if (o_mg_glo_bal.fg_val_num(tb_cod_lib.Text) == false)
        //    {
        //        tb_cod_lib.Focus();
        //        return "El Codigo de la Lista de Precios debe ser Numerico";
        //    }
        //    if (tb_cod_plg.Text == "")
        //    {
        //        tb_cod_lib.Focus();
        //        return "Debes proporcionar el codigo del Producto";
        //    }

        //    //valida PRECIO
        //    if (tb_pre_cio.Text == "")
        //    {
        //        tb_pre_cio.Focus();
        //        return "Debes proporcionar el Precio";
        //    }
        //    err_msg = o_mg_glo_bal.fg_val_dec(tb_pre_cio.Text, 5, 5);

        //    if (err_msg == null)
        //    {
        //        tb_pre_cio.Focus();
        //        return "El Precio debe ser Numerico";
        //    }
        //    if (err_msg == "ent")
        //    {
        //        tb_pre_cio.Focus();
        //        return "El Precio debe tener hasta 5 numeros Enteros";
        //    }
        //    if (err_msg == "dec")
        //    {
        //        tb_pre_cio.Focus();
        //        return "El Precio debe tener hasta 5 números Decimales";
        //    }
        //    //valida Porcentaje Maximo de descuento
        //    if (tb_pmx_des.Text == "")
        //    {
        //        tb_pmx_des.Focus();
        //        return "Debes proporcionar el Porcentaje Maximo de Descuento";
        //    }
        //    err_msg = o_mg_glo_bal.fg_val_dec(tb_pmx_des.Text, 2, 2);

        //    if (err_msg == null)
        //    {
        //        tb_pmx_des.Focus();
        //        return "El Porcentaje Maximo de Descuento debe ser Numerico";
        //    }
        //    if (err_msg == "ent")
        //    {
        //        tb_pmx_des.Focus();
        //        return "El Porcentaje Maximo de Descuento debe tener hasta 2 numeros Enteros";
        //    }
        //    if (err_msg == "dec")
        //    {
        //        tb_pmx_des.Focus();
        //        return "El Porcentaje Maximo de Descuento debe tener hasta 2 números Decimales";
        //    }
        //    //valida Porcentaje Maximo de Incremento
        //    if (tb_pmx_inc.Text == "")
        //    {
        //        tb_pmx_inc.Focus();
        //        return "Debes proporcionar el Porcentaje Maximo de Incremento";
        //    }
        //    err_msg = o_mg_glo_bal.fg_val_dec(tb_pmx_inc.Text, 2, 2);

        //    if (err_msg == null)
        //    {
        //        tb_pmx_inc.Focus();
        //        return "El Porcentaje Maximo de Incremento debe ser Numerico";
        //    }
        //    if (err_msg == "ent")
        //    {
        //        tb_pmx_inc.Focus();
        //        return "El Porcentaje Maximo de Incremento debe tener hasta 2 numeros Enteros";
        //    }
        //    if (err_msg == "dec")
        //    {
        //        tb_pmx_inc.Focus();
        //        return "El Porcentaje Maximo de Incremento debe tener hasta 2 números Decimales";
        //    }

        //    return null;
        //}


        #endregion

        #region EVENTOS

        public ecp007_03()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

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
