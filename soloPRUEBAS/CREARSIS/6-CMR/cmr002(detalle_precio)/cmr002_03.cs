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

namespace CREARSIS._6_CMR.cmr002_detalle_precio_
{
    public partial class cmr002_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        DataTable tab_cmr001;
        DataTable tab_cmr002;
        DataTable tab_inv002;
        string err_msg = "";
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        DATOS._6_CMR.c_cmr002 o_cmr002 = new DATOS._6_CMR.c_cmr002();
        DATOS._4_INV.c_inv002 o_inv002 = new DATOS._4_INV.c_inv002();

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
            tb_cod_lis.Text = vg_str_ucc.Rows[0]["va_cod_lis"].ToString();
            tab_cmr001 = o_cmr001._05(tb_cod_lis.Text);
            if (tab_cmr001.Rows.Count != 0)
            {
                tb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
            }

            //lenar tbx nombre Producto
            tb_cod_pro.Text = vg_str_ucc.Rows[0]["va_cod_pro"].ToString();
            tab_inv002 = o_inv002._05(tb_cod_pro.Text);
            if (tab_inv002.Rows.Count != 0)
            {
                tb_nom_pro.Text = tab_inv002.Rows[0]["va_nom_pro"].ToString();
            }

            tb_pre_cio.Text = vg_str_ucc.Rows[0]["va_pre_cio"].ToString();
            tb_pmx_des.Text = vg_str_ucc.Rows[0]["va_pmx_des"].ToString();
            tb_pmx_inc.Text = vg_str_ucc.Rows[0]["va_pmx_inc"].ToString();
            tb_por_cal.Text = vg_str_ucc.Rows[0]["va_por_cal"].ToString();
            


        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            return null;
        }


        #endregion

        #region EVENTOS

        public cmr002_03()
        {
            InitializeComponent();
        }

        private void cmr002_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos?", "Actualiza Detalle de Precios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                // grabar datos
                o_cmr002._03(Convert.ToInt32(tb_cod_lis.Text),tb_cod_pro.Text,Convert.ToDecimal(tb_pre_cio.Text), Convert.ToDecimal(tb_pmx_des.Text), Convert.ToDecimal(tb_pmx_inc.Text), Convert.ToDecimal(tb_por_cal.Text));

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vg_frm_pad.fu_sel_fila(tb_cod_lis.Text, tb_nom_lis.Text);

                Close();
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
