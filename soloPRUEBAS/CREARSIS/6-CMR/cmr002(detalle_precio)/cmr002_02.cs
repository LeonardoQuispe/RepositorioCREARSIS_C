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
    public partial class cmr002_02 : DevComponents.DotNetBar.Metro.MetroForm
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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            tab_cmr002 = o_cmr002._01(tb_cod_lis.Text);

            if (tb_cod_lis.Text == "")
            {
                tb_cod_lis.Focus();
                return "Debes proporcionar el codigo de la Detalle de Precio";
            }
            if (o_mg_glo_bal.fg_val_num(tb_cod_lis.Text) == false)
            {
                tb_cod_lis.Focus();
                return "El Codigo de la Detalle de Precios debe ser Numerico";
            }
            if (tb_cod_pro.Text == "")
            {
                tb_cod_lis.Focus();
                return "Debes proporcionar el codigo de la Detalle de Precio";
            }

            if (tb_pre_cio.Text == "")
            {
                tb_pre_cio.Focus();
                return "Debes proporcionar el Precio";
            }
            //valida PRECIO
            err_msg = o_mg_glo_bal.fg_val_dec(tb_pre_cio.Text, 10, 5);

            if (err_msg == null)
            {
                tb_pre_cio.Focus();
                return "La equivalencia de  Unidad de Medida en Ventas debe ser Numerico";
            }
            if (err_msg == "ent")
            {
                tb_pre_cio.Focus();
                return "La equivalencia de  Unidad de Medida en Ventas debe tener hasta 10 numeros Enteros";
            }
            if (err_msg == "dec")
            {
                tb_pre_cio.Focus();
                return "La equivalencia de  Unidad de Medida en Ventas debe tener hasta 5 números Decimales";
            }

            return null;
        }

        //---------------- Producto----------
        public void fu_rec_pro(string cod_pro)
        {
            if (cod_pro.Trim() == "")
            {
                tb_nom_pro.Text = "** NO existe";
                return;
            }

            tab_inv002 = o_inv002._05(cod_pro);
            if (tab_inv002.Rows.Count == 0)
            {
                tb_cod_pro.Text = "";
                tb_nom_pro.Text = "** NO existe";
                return;
            }

            tb_cod_pro.Text = tab_inv002.Rows[0]["va_cod_pro"].ToString();
            tb_nom_pro.Text = tab_inv002.Rows[0]["va_nom_pro"].ToString();
        }
        //---------------- Producto----------
        public void fu_rec_lis(string cod_lis)
        {
            if (cod_lis.Trim() == "")
            {
                tb_nom_lis.Text = "** NO existe";
                return;
            }

            tab_cmr001 = o_cmr001._05(cod_lis);
            if (tab_cmr001.Rows.Count == 0)
            {
                tb_cod_lis.Text = "";
                tb_nom_lis.Text = "** NO existe";
                return;
            }

            tb_cod_lis.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
            tb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
        }
        #endregion

        public cmr002_02()
        {
            InitializeComponent();
        }

        private void cmr002_02_Load(object sender, EventArgs e)
        {

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Detalle de Precios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                int aux = 0;
                // grabar datos
                o_cmr002._02(Convert.ToInt32(tb_cod_lis.Text), tb_cod_pro.Text.Trim().ToString(),Convert.ToInt32(tb_pre_cio.Text), Convert.ToInt32(tb_pmx_des.Text), Convert.ToInt32(tb_pmx_inc.Text),aux);

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_bus_car(tb_cod_lis.Text);
                vg_frm_pad.fu_sel_fila(tb_cod_pro.Text, tb_nom_pro.Text);
                

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Detalle de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_cod_lis.Clear();
                tb_nom_lis.Clear();


                tb_cod_lis.Focus();
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

        private void tb_cod_lis_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01 obj = new CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }
        private void tb_cod_lis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01 obj = new CREARSIS._6_CMR.cmr001_lista_precios_.cmr001_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }
        private void tb_cod_lis_Validated(object sender, EventArgs e)
        {
            fu_rec_lis(tb_cod_lis.Text);
        }

        private void tb_cod_pro_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._4_INV.inv002_pro_.inv002_01 obj = new CREARSIS._4_INV.inv002_pro_.inv002_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                CREARSIS._4_INV.inv002_pro_.inv002_01 obj = new CREARSIS._4_INV.inv002_pro_.inv002_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_pro_Validated(object sender, EventArgs e)
        {
            fu_rec_pro(tb_cod_pro.Text);
        }

       
    }
}
