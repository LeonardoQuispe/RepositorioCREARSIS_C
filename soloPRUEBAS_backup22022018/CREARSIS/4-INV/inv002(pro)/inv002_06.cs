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

namespace CREARSIS._4_INV.inv002_pro_
{
    public partial class inv002_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_inv003;
        DataTable tab_inv002;
        DataTable tab_inv004;
        DataTable tab_inv001;
        DataTable tab_inv008;

        byte[] va_img_pro;
        int va_uni_dad;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._4_INV.c_inv002 o_inv002 = new DATOS._4_INV.c_inv002();
        DATOS._4_INV.c_inv008 o_inv008 = new DATOS._4_INV.c_inv008();
        c_inv003 o_inv003 = new c_inv003();
        c_inv004 o_inv004 = new c_inv004();
        c_inv001 o_inv001 = new c_inv001();

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tab_inv008 = o_inv008._01(vg_str_ucc.Rows[0]["va_cod_pro"].ToString());
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_fap.Text = vg_str_ucc.Rows[0]["va_cod_fam"].ToString();
            fu_rec_fam(tb_cod_fap.Text);

            tb_cod_pro.Text = vg_str_ucc.Rows[0]["va_cod_pro"].ToString();
            tb_nom_pro.Text = vg_str_ucc.Rows[0]["va_nom_pro"].ToString();
            tb_des_pro.Text = vg_str_ucc.Rows[0]["va_des_pro"].ToString();
            tb_cod_bar.Text = vg_str_ucc.Rows[0]["va_cod_bar"].ToString();
            tb_fab_ric.Text = vg_str_ucc.Rows[0]["va_fab_ric"].ToString();

            tb_cod_mar.Text = vg_str_ucc.Rows[0]["va_cod_mar"].ToString();
            fu_rec_mar(tb_cod_mar.Text);

            //lenar tbx nombre unidad medida
            tb_uni_inv.Text = vg_str_ucc.Rows[0]["va_cod_umd"].ToString();
            tab_inv003 = o_inv003._05(tb_uni_inv.Text);
            if (tab_inv001.Rows.Count != 0)
            {
                tb_nom_inv.Text = tab_inv003.Rows[0]["va_nom_umd"].ToString();
            }

            //lenar tbx nombre unidad medida venta
            tb_uni_ven.Text = vg_str_ucc.Rows[0]["va_und_vta"].ToString();
            tab_inv003 = o_inv003._05(tb_uni_ven.Text);
            if (tab_inv001.Rows.Count != 0)
            {
                tb_nom_ven.Text = tab_inv003.Rows[0]["va_nom_umd"].ToString();
            }

            //lenar tbx nombre unidad medida compra
            tb_uni_com.Text = vg_str_ucc.Rows[0]["va_und_cmp"].ToString();
            tab_inv003 = o_inv003._05(tb_uni_com.Text);
            if (tab_inv001.Rows.Count != 0)
            {
                tb_nom_com.Text = tab_inv003.Rows[0]["va_nom_umd"].ToString();
            }

            tb_eqv_ven.Text = vg_str_ucc.Rows[0]["va_eqv_vta"].ToString();
            tb_eqv_com.Text = vg_str_ucc.Rows[0]["va_eqv_cmp"].ToString();

            if (vg_str_ucc.Rows[0]["va_ban_lot"].ToString() == "1")
            {
                chk_lot.Checked = true;
            }
            if (vg_str_ucc.Rows[0]["va_ban_ser"].ToString() == "1")
            {
                chk_ser.Checked = true;
            }
            if (vg_str_ucc.Rows[0]["va_ban_vta"].ToString() == "1")
            {
                chk_ven.Checked = true;
            }
            if (vg_str_ucc.Rows[0]["va_ban_cmp"].ToString() == "1")
            {
                chk_com.Checked = true;
            }

            if (tab_inv008.Rows.Count == 0)
            {
                pc_img_pro.Image = pc_img_pro.ErrorImage;
            }
            else
            {
                va_img_pro = (Byte[])tab_inv008.Rows[0]["va_img_pro"];
                pc_img_pro.Image = o_mg_glo_bal.fg_byt_img(va_img_pro);
            }


            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }

        public string fu_ver_dat()
        {

            return null;
        }
        //----------------Familia Producto----------
        public void fu_rec_fam(string cod_fam)
        {
            if (cod_fam.Trim() == "")
            {
                tb_nom_fap.Text = "** NO existe";
                return;
            }

            tab_inv001 = o_inv001._05(cod_fam);
            if (tab_inv001.Rows.Count == 0)
            {
                tb_nom_fap.Text = "** NO existe";
                return;
            }

            tb_cod_fap.Text = tab_inv001.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fap.Text = tab_inv001.Rows[0]["va_nom_fam"].ToString();
        }
        //-----------------Producto-----------
        public void fu_rec_mar(string cod_mar)
        {
            if (cod_mar.Trim() == "")
            {
                tb_nom_mar.Text = "** NO existe";
                return;
            }

            tab_inv004 = o_inv004._05(int.Parse(cod_mar));
            if (tab_inv004.Rows.Count == 0)
            {
                tb_nom_mar.Text = "** NO existe";
                return;
            }

            tb_cod_mar.Text = tab_inv004.Rows[0]["va_cod_mar"].ToString();
            tb_nom_mar.Text = tab_inv004.Rows[0]["va_nom_mar"].ToString();
        }

        #endregion

        #region EVENTOS

        public inv002_06()
        {
            InitializeComponent();
        }

        private void inv002_06_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Elimina Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar EL Producto ?", "Elimina Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                //elimina Imagen de Producto
                o_inv008._06(tb_cod_pro.Text.Trim());

                //Graba datos
                o_inv002._06(tb_cod_pro.Text.Trim());
                



                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex);

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
