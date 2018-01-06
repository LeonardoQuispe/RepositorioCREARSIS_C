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
    public partial class inv002_02 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_adm007;
        DataTable tab_inv010;

        #endregion

        #region INSTANCIAS

        c_inv010 o_inv010 = new c_inv010();
        c_adm007 o_adm007 = new c_adm007();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS
        public void fu_rec_suc(string cod_suc)
        {
            string tmp = "";

            if (cod_suc.Trim() == "")
            {
                tb_cod_sucu.Text = "";
                tb_nom_sucu.Text = "** NO existe";
                tb_cod_gru.Text = "00" + tb_cod_gru.Text[2].ToString() + tb_cod_gru.Text[3].ToString();
                return;
            }

            tab_adm007 = o_adm007._05(cod_suc);
            if (tab_adm007.Rows.Count == 0)
            {
                tb_cod_sucu.Text = "";
                tb_nom_sucu.Text = "** NO existe";
                tb_cod_gru.Text = "00" + tb_cod_gru.Text[2].ToString() + tb_cod_gru.Text[3].ToString();
                return;
            }

            tb_cod_sucu.Text = cod_suc;
            tb_nom_sucu.Text = tab_adm007.Rows[0]["va_nom_suc"].ToString();

            tmp = tb_cod_sucu.Text.PadLeft(2, '0');

            tb_cod_gru.Text = tmp[0].ToString() + tmp[1].ToString() + tb_cod_gru.Text[2].ToString() + tb_cod_gru.Text[3].ToString();


        }
        void fu_ini_frm()
        {
            tb_cod_sucu.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_sucu.Clear();
            tb_nro_gru.Clear();
            tb_cod_gru.Clear();
            tb_nom_gru.Clear();
            tb_des_gru.Clear();


            tb_cod_sucu.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            //**Verifica Codigo de la Sucursal-----------------------------------
            int tmp;

            if (tb_cod_sucu.Text.Trim() == "")
            {
                tb_cod_sucu.Focus();
                return "Debes proporcionar el código de la Sucursal";
            }

            if (int.TryParse(tb_cod_sucu.Text.Trim(), out tmp) == false)
            {
                tb_cod_sucu.Focus();
                return "El Codigo de la Sucursal NO es valido";
            }

            tab_adm007 = o_adm007._05(tb_cod_sucu.Text);
            if (tab_adm007.Rows.Count == 0)
            {
                tb_cod_sucu.Focus();
                return "El Codigo de la Sucursal NO se encuentra registrado";
            }

            if (tab_adm007.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_sucu.Focus();
                return "El Codigo de la Sucursal se encuentra Deshabilitado";
            }

            //VERIFICA numero de Grupo

            if (string.IsNullOrWhiteSpace(tb_nro_gru.Text))
            {
                tb_nro_gru.Focus();
                return "Debes proporcionar el Número del Grupo de Almacén";
            }

            if (int.Parse(tb_nro_gru.Text) <= 0)
            {
                tb_nro_gru.Focus();
                return "El Número del Grupo de Almacén debe ser mayor a cero";
            }

            //**Verifica Codigo de GRUPO
            tab_inv010 = o_inv010._05(int.Parse(tb_cod_gru.Text));
            if (tab_inv010.Rows.Count != 0)
            {
                tb_cod_gru.Focus();
                return "El codigo del Grupo de Almacén ya se encuentra registrado";
            }

            //**Verifica el nombre del grupo de Almacén
            if (tb_nom_gru.Text.Trim() == "")
            {
                tb_nom_gru.Focus();
                return "Debes proporcionar el nombre  del Grupo de Almacén";
            }




            return null;
        }
        #endregion

        #region EVENTOS

        public inv002_02()
        {
            InitializeComponent();
        }

        private void inv002_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Grupo de Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos GRUPO DE Almacén
                o_inv010._02(int.Parse(tb_cod_gru.Text), int.Parse(tb_cod_sucu.Text), int.Parse(tb_nro_gru.Text), tb_nom_gru.Text, tb_des_gru.Text);

                vg_frm_pad.fu_sel_fila(tb_cod_gru.Text, tb_nom_gru.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);


                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Buton Flia Producto
        private void tb_cod_flia_ButtonCustomClick(object sender, EventArgs e)
        {
            adm007_01 obj = new adm007_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        //Keydown flia producto
        private void tb_cod_fap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                adm007_01 obj = new adm007_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }
    }
}
