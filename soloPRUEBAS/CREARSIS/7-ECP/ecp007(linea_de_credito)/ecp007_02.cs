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
    public partial class ecp007_02 : DevComponents.DotNetBar.Metro.MetroForm
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

            //lenar tbx nombre Detalle de Precio
            tb_cod_per.Text = vg_str_ucc.Rows[0]["va_cod_per"].ToString();

            tab_adm010 = o_adm010._05(tb_cod_per.Text);
            if (tab_adm010.Rows.Count != 0)
            {
                tb_nom_per.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();
            }

            tb_cod_lib.Focus();
        }
        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_lib.Clear();
            tb_des_lib.Clear();
            tb_mto_lim.Clear();
            tb_cod_plg.Clear();
            tb_des_plg.Clear();
            tb_nro_cuo.Clear();
            tb_int_dia.Clear();
            tb_max_cuo.Clear();

            tb_cod_lib.Focus();
        }
        /// <summary>
        /// /// Funcion que verifica los datos antes de grabar
        /// /// </summary>
        public string fu_ver_dat()
        {
            //Valida Libreta
            if (tb_cod_lib.Text == "")
            {
                tb_cod_per.Focus();
                return "Debes proporcionar el codigo de la Libreta";
            }
            
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
            //valida plan de pago
            if (tb_cod_plg.Text == "")
            {
                tb_cod_plg.Focus();
                return "Debes proporcionar el codigo del plan de pago";
            }
            if(tb_max_cuo.Text!="")
            {
                if (o_mg_glo_bal.fg_val_num(tb_max_cuo.Text) == false)
                {
                    tb_max_cuo.Focus();
                    return "El Maximo de Cuotas debe ser Numerico"; ;
                }
            }
            

            //Si aun existe
            tab_ecp007 = o_ecp007._05(tb_cod_per.Text, tb_cod_lib.Text,int.Parse(tb_cod_plg.Text));
            if (tab_ecp007.Rows.Count != 0)
            {
                return "Los datos seleccionados ya esta registrado en Esta Linea de Credito";
            }

            return null;
        }

        //---------------- LIbreta----------
        public void fu_rec_lib(string cod_lib)
        {
            if (cod_lib.Trim() == "")
            {
                tb_cod_lib.Clear();
                tb_des_lib.Text = "** NO existe";
                return;
            }
            if (o_mg_glo_bal.fg_val_num(cod_lib) == false)
            {
                tb_cod_lib.Clear();
                tb_des_lib.Text = "** NO existe";
                return;
            }

            tab_ecp006 = o_ecp006._05(int.Parse(cod_lib));
            if (tab_ecp006.Rows.Count == 0)
            {
                tb_cod_lib.Clear();
                tb_des_lib.Text = "** NO existe";
                return;
            }

            if (tab_ecp006.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_lib.Clear();
                tb_des_lib.Text = "** NO existe";

                MessageBoxEx.Show("La Libreta se encuentra Deshabilitada", "Nuevo Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            tb_cod_lib.Text = tab_ecp006.Rows[0]["va_cod_lib"].ToString();
            tb_des_lib.Text = tab_ecp006.Rows[0]["va_des_lib"].ToString();
        }
        //---------------- Plan de Pago----------
        public void fu_rec_plg(string cod_plg)
        {
            if (cod_plg.Trim() == "")
            {
                tb_cod_plg.Clear();
                tb_des_plg.Text = "** NO existe";
                return;
            }
            if (o_mg_glo_bal.fg_val_num(cod_plg) == false)
            {
                tb_cod_plg.Clear();
                tb_des_plg.Text = "** NO existe";
                return;
            }

            tab_ecp005 = o_ecp005._05(int.Parse(cod_plg));
            if (tab_ecp005.Rows.Count == 0)
            {
                tb_cod_plg.Clear();
                tb_des_plg.Text = "** NO existe";
                return;
            }

            if (tab_ecp005.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_plg.Clear();
                tb_des_plg.Text = "** NO existe";

                MessageBoxEx.Show("El plan de Pago se encuentra Deshabilitado", "Nuevo Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            tb_cod_plg.Text = tab_ecp005.Rows[0]["va_cod_plg"].ToString();
            tb_des_plg.Text = tab_ecp005.Rows[0]["va_des_plg"].ToString();
        }
        #endregion

        #region EVENTOS

        public ecp007_02()
        {
            InitializeComponent();
        }

        private void ecp007_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_cod_lib_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._7_ECP.ecp006_libreta_.ecp006_01 obj = new ecp006_libreta_.ecp006_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_lib_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                CREARSIS._7_ECP.ecp006_libreta_.ecp006_01 obj = new ecp006_libreta_.ecp006_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_lib_Validated(object sender, EventArgs e)
        {
            fu_rec_lib(tb_cod_lib.Text);
        }

        private void tb_cod_plg_ButtonCustomClick(object sender, EventArgs e)
        {
            ecp005_plan_de_pago_.ecp005_01 obj = new ecp005_plan_de_pago_.ecp005_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_plg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                ecp005_plan_de_pago_.ecp005_01 obj = new ecp005_plan_de_pago_.ecp005_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_plg_Validated(object sender, EventArgs e)
        {
            fu_rec_plg(tb_cod_plg.Text);

            if (tb_cod_plg.Text!="")
            {
                tab_ecp005 = o_ecp005._05(int.Parse(tb_cod_plg.Text));

                tb_nro_cuo.Text=tab_ecp005.Rows[0]["va_nro_cuo"].ToString();
                tb_int_dia.Text = tab_ecp005.Rows[0]["va_int_dia"].ToString();
            }
            else
            {
                tb_nro_cuo.Text = "";
                tb_int_dia.Text = "";
            }
            
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tmp;
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Linea de Credito", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                // grabar datos
                o_ecp007._02(int.Parse(tb_cod_lib.Text), tb_cod_per.Text, int.Parse(tb_cod_plg.Text), (decimal.TryParse(tb_mto_lim.Text, out tmp) ? tmp : 0m),0m,tb_max_cuo.Text,tb_fec_exp.Value);
                fu_lim_frm();

                //Actualiza la grilla de busqueda en la ventana padre


                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Linea de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        
    }
}
