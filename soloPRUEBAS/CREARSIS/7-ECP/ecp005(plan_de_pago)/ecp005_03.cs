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

namespace CREARSIS._7_ECP.ecp005_plan_de_pago_
{
    public partial class ecp005_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_plg.Text = vg_str_ucc.Rows[0]["va_cod_plg"].ToString();
            tb_des_plg.Text = vg_str_ucc.Rows[0]["va_des_plg"].ToString();
            tb_nro_cuo.Text = vg_str_ucc.Rows[0]["va_nro_cuo"].ToString();
            tb_int_dia.Text = vg_str_ucc.Rows[0]["va_int_dia"].ToString();
            tb_dia_ini.Text = vg_str_ucc.Rows[0]["va_dia_ini"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            //valida descripcion
            if (tb_des_plg.Text.Trim() == "")
            {
                tb_des_plg.Focus();
                return "Debes proporcionar una Descripcion";
            }
            //valida Nro. Cuotas
            if (tb_nro_cuo.Text.Trim() == "")
            {
                tb_nro_cuo.Focus();
                return "Debes proporcionar el Nro. de Cuotas";
            }

            if (o_mg_glo_bal.fg_val_num(tb_nro_cuo.Text) == false)
            {
                tb_nro_cuo.Focus();
                return "El Nro. de Cuotas debe ser Numerico";
            }
            //valida Intervalo de dias
            if (tb_int_dia.Text.Trim() == "")
            {
                tb_int_dia.Focus();
                return "Debes proporcionar el Intervalo de Dias";
            }

            if (o_mg_glo_bal.fg_val_num(tb_int_dia.Text) == false)
            {
                tb_int_dia.Focus();
                return "El Intervalo de Dias debe ser Numerico";
            }
            //valida Intervalo de dias
            if (tb_dia_ini.Text.Trim() == "")
            {
                tb_dia_ini.Focus();
                return "Debes proporcionar el Dia Inicial";
            }

            if (o_mg_glo_bal.fg_val_num(tb_dia_ini.Text) == false)
            {
                tb_dia_ini.Focus();
                return "El Dia Inicial debe ser Numerico";
            }
            if (int.Parse(tb_dia_ini.Text) > 30)
            {
                tb_dia_ini.Focus();
                return "El Dia Inicial debe ser Menor a 30";
            }


            return null;
        }

        #endregion

        #region EVENTOS

        public ecp005_03()
        {
            InitializeComponent();
        }

        private void ecp005_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Plan de Pago", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_ecp005._03(Convert.ToInt32(tb_cod_plg.Text.Trim()), tb_des_plg.Text.Trim(), Convert.ToInt32(tb_nro_cuo.Text.Trim()), Convert.ToInt32(tb_int_dia.Text.Trim()), Convert.ToInt32(tb_dia_ini.Text.Trim()));

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_plg.Text.Trim(), tb_des_plg.Text.Trim());
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
