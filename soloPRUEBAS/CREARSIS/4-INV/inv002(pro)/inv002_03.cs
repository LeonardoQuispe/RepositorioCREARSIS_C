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
    public partial class inv002_03 : DevComponents.DotNetBar.Metro.MetroForm
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
            if(tab_inv001.Rows.Count!=0)
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

            if(vg_str_ucc.Rows[0]["va_ban_lot"].ToString()=="1")
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

            if (tab_inv008.Rows.Count==0)
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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            int tmp;

            //**Verifica Marca-----------------------------------
            

            if (int.TryParse(tb_cod_mar.Text.Trim(), out tmp) == false)
            {
                tb_cod_mar.Focus();
                return "El Nro de la Marca debe ser numérico";
            }

            if (tb_cod_mar.Text == "0")
            {
                tb_cod_mar.Focus();
                return "El Nro de la Marca debe ser diferente de 0";
            }
            if (tb_cod_mar.Text.Trim() == "")
            {
                tb_cod_mar.Focus();
                return "Debes proporcionar el codigo de la Marca";
            }

            tab_inv004 = o_inv004._05(int.Parse(tb_cod_mar.Text));
            if (tab_inv004.Rows.Count == 0)
            {
                tb_cod_mar.Focus();
                return "La Marca NO se encuentra registrada";
            }
            if (tab_inv004.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_mar.Focus();
                return "La Marca se encuentra Deshabilitada";
            }
            //**-----------------------------------------------------

            //** Verifica Unidad de Medida---------------------------------
            if (tb_uni_inv.Text.Trim() == "")
            {
                tb_uni_inv.Focus();
                return "Debes proporcionar la Unidad de Medida";
            }

            tab_inv003 = o_inv003._05(tb_uni_inv.Text);
            if (tab_inv003.Rows.Count == 0)
            {
                tb_uni_inv.Focus();
                return "La Unidad de Medida NO se encuentra registrada";
            }
            if (tab_inv003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_uni_inv.Focus();
                return "La Unidad de Medida se encuentra Deshabilitada";
            }
            //**-----------------------------------------------------

            //** Verifica Unidad de Medida de Ventas---------------------------------
            if (tb_uni_com.Text.Trim() == "")
            {
                tb_uni_com.Focus();
                return "Debes proporcionar el codigo de la Unidad de Medida en Ventas";
            }

            tab_inv003 = o_inv003._05(tb_uni_com.Text);
            if (tab_inv003.Rows.Count == 0)
            {
                tb_uni_com.Focus();
                return "La Unidad de Medida de Ventas NO se encuentra registrada";
            }
            if (tab_inv003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_uni_com.Focus();
                return "La Unidad de Medida de Ventas se encuentra Deshabilitada";
            }
            //**-----------------------------------------------------

            //** Verifica Unidad de Medida de Compras---------------------------------
            if (tb_uni_com.Text.Trim() == "")
            {
                tb_uni_com.Focus();
                return "Debes proporcionar el codigo de la Unidad de Medida en Compras";
            }

            tab_inv003 = o_inv003._05(tb_uni_com.Text);
            if (tab_inv003.Rows.Count == 0)
            {
                tb_uni_com.Focus();
                return "La Unidad de Medida de Compras NO se encuentra registrada";
            }
            if (tab_inv003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_uni_com.Focus();
                return "La Unidad de Medida de Compras se encuentra Deshabilitada";
            }
            //**-----------------------------------------------------


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
        //-----------------Marca-----------
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

        public inv002_03()
        {
            InitializeComponent();
        }

        private void inv002_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                //----------- chekbox--
                int var_lot = 0;
                int var_ser = 0;
                int var_ven = 0;
                int var_com = 0;

                if (chk_lot.Checked == true)
                {
                    var_lot = 1;
                }
                if (chk_ser.Checked == true)
                {
                    var_ser = 1;
                }
                if (chk_ven.Checked == true)
                {
                    var_ven = 1;
                }
                if (chk_com.Checked == true)
                {
                    var_com = 1;
                }


                //Graba datos Producto
                o_inv002._03(tb_cod_pro.Text.Trim(), tb_cod_fap.Text.Trim(), tb_uni_inv.Text.Trim(), tb_uni_com.Text.Trim(), tb_uni_ven.Text.Trim(), tb_cod_mar.Text.Trim(),
                            tb_nom_pro.Text.Trim(), tb_des_pro.Text.Trim(), tb_cod_bar.Text.Trim(), tb_fab_ric.Text.Trim(), tb_eqv_com.Text.Trim(), tb_eqv_ven.Text.Trim(), var_ser, var_ven, var_com, var_lot);


                //Valida si ingresó una imagen
                if (pc_img_pro.Image != pc_img_pro.ErrorImage)
                {
                    o_inv008._06(tb_cod_pro.Text.Trim());
                    //Convierte la imagen a BYTE
                    va_img_pro = o_mg_glo_bal.fg_img_byt(pc_img_pro.Image);

                    //Graba Imagen de Producto
                    o_inv008._02(tb_cod_pro.Text.Trim(), va_img_pro);
                }
                else
                {
                    //elimina Imagen de Producto
                    o_inv008._06(tb_cod_pro.Text.Trim());
                }

               

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_sel_fila(tb_cod_pro.Text.Trim(), tb_nom_pro.Text.Trim());
                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void bt_bus_img_Click(object sender, EventArgs e)
        {
            //Carga Imagen
            OpenFileDialog abrir_archivo = new OpenFileDialog();
            abrir_archivo.Filter = "Imágenes | *.jpeg; *.jpg; *.png";
            abrir_archivo.Title = "Seleccione la Imagen";
            if (abrir_archivo.ShowDialog() == DialogResult.OK)
            {
                pc_img_pro.Image = Image.FromFile(abrir_archivo.FileName);
            }
        }

        private void bt_eli_img_Click(object sender, EventArgs e)
        {
            pc_img_pro.Image = pc_img_pro.ErrorImage;
        }

        private void tb_cod_mar_ButtonCustomClick(object sender, EventArgs e)
        {
            inv004_01 obj = new inv004_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_mar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                inv004_01 obj = new inv004_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_mar_Validated(object sender, EventArgs e)
        {
            fu_rec_mar(tb_cod_mar.Text);
        }

        private void tb_uni_inv_Validated(object sender, EventArgs e)
        {

        }
    }
}
