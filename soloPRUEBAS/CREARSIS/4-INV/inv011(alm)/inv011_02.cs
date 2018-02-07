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


namespace CREARSIS
{
    public partial class inv011_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_inv010;
        DataTable tab_inv011;
        DataTable tab_ctb004;

        #endregion

        #region INSTANCIAS

        c_inv010 o_inv010 = new c_inv010();
        c_inv011 o_inv011 = new c_inv011();
        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public inv011_02()
        {
            InitializeComponent();
        }

        private void inv011_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_gru_alm_ButtonCustomClick(object sender, EventArgs e)
        {
            inv010_01 obj = new inv010_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);

        }

        private void tb_gru_alm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                inv010_01 obj = new inv010_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        

        private void tb_gru_alm_Validated(object sender, EventArgs e)
        {
            fu_rec_gru(tb_gru_alm.Text);
        }

        private void tb_nro_alm_Validated(object sender, EventArgs e)
        {
            string tmp = "";

            if (string.IsNullOrWhiteSpace(tb_nro_alm.Text) != true)
            {
                if (o_mg_glo_bal.fg_val_num(tb_nro_alm.Text)==true)
                {
                    tmp = tb_nro_alm.Text.PadLeft(3, '0');

                    tb_cod_alm.Text = tb_cod_alm.Text[0].ToString() + tb_cod_alm.Text[1].ToString() + tb_cod_alm.Text[2].ToString() + tb_cod_alm.Text[3].ToString() + tmp[0].ToString() + tmp[1].ToString() + tmp[2].ToString();
                    return;
                }     
            }

            tb_cod_alm.Text = tb_cod_alm.Text[0].ToString() + tb_cod_alm.Text[1].ToString() + tb_cod_alm.Text[2].ToString() + tb_cod_alm.Text[3].ToString() + "000";
            tb_nro_alm.Clear();

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos Almacén
                o_inv011._02(int.Parse(tb_cod_alm.Text),int.Parse(tb_gru_alm.Text),int.Parse(tb_nro_alm.Text),tb_nom_alm.Text.Trim(),tb_des_alm.Text.Trim(),
                            tb_dir_alm.Text.Trim(),DateTime.Parse("01/01/1900"),cb_mon_inv.SelectedIndex.ToString(),cb_mon_inv.SelectedIndex.ToString(),tb_nom_ecg.Text.Trim(),
                            tb_tlf_ecg.Text.Trim(),tb_dir_ecg.Text.Trim(),tb_cod_cta.Text.Trim());

                vg_frm_pad.fu_sel_fila(tb_cod_alm.Text, tb_nom_alm.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);


                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_gru_alm.Focus();

            cb_mon_inv.SelectedIndex = 0;
            cb_mtd_cto.SelectedIndex = 0;
        }

        public void fu_rec_gru(string cod_alm)
        {
            string tmp = "";

            if (cod_alm.Trim() == "")
            {
                tb_gru_alm.Text = "";
                tb_nom_gru.Text = "** NO existe";
                tb_cod_alm.Text = "0000" + tb_cod_alm.Text[4].ToString() + tb_cod_alm.Text[5].ToString() + tb_cod_alm.Text[6].ToString();
                return;
            }

            tab_inv010 = o_inv010._05(int.Parse(cod_alm));
            if (tab_inv010.Rows.Count == 0)
            {
                tb_gru_alm.Text = "";
                tb_nom_gru.Text = "** NO existe";
                tb_cod_alm.Text = "0000" + tb_cod_alm.Text[4].ToString() + tb_cod_alm.Text[5].ToString() + tb_cod_alm.Text[6].ToString();
                return;
            }

            tb_gru_alm.Text = cod_alm;
            tb_nom_gru.Text = tab_inv010.Rows[0]["va_nom_gru"].ToString();

            tmp = tb_gru_alm.Text.PadLeft(4, '0');

            tb_cod_alm.Text = tmp[0].ToString() + tmp[1].ToString()+ tmp[2].ToString() + tmp[3].ToString() + tb_cod_alm.Text[4].ToString() + tb_cod_alm.Text[5].ToString() + tb_cod_alm.Text[6].ToString();


        }

        public void fu_rec_cta(string cod_cta)
        {
            if (cod_cta.Trim() == "")
            {
                tb_cod_cta.Clear();
                tb_nom_cta.Text = "** NO existe";
                return;
            }

            if (o_mg_glo_bal.fg_val_let(cod_cta) == false)
            {
                tb_cod_cta.Clear();
                tb_nom_cta.Text = "** NO existe";
                return;
            }

            tab_ctb004 = o_ctb004._05(cod_cta);
            if (tab_ctb004.Rows.Count == 0)
            {
                tb_cod_cta.Clear();
                tb_nom_cta.Text = "** NO existe";
                return;
            }

            tb_cod_cta.Text = tab_ctb004.Rows[0]["va_cod_cta"].ToString();
            tb_nom_cta.Text = tab_ctb004.Rows[0]["va_nom_cta"].ToString();

        }


        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_gru_alm.Clear();
            tb_nom_gru.Clear();
            tb_nro_alm.Clear();
            tb_cod_alm.Clear();
            tb_nom_alm.Clear();
            tb_des_alm.Clear();
            tb_dir_alm.Clear();
            tb_cod_cta.Clear();
            cb_mon_inv.SelectedIndex = 0;
            cb_mtd_cto.SelectedIndex = 0;

            tb_nom_ecg.Clear();
            tb_tlf_ecg.Clear();
            tb_dir_ecg.Clear();


            tb_gru_alm.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            //**Verifica Grupo de Almacén

            if (tb_gru_alm.Text.Trim() == "")
            {
                tb_gru_alm.Focus();
                return "Debes proporcionar el Grupo de Almacén";
            }

            if (o_mg_glo_bal.fg_val_num(tb_gru_alm.Text) == false)
            {
                tb_gru_alm.Focus();
                return "El Codigo del Grupo de Almacén NO es valido";
            }

            tab_inv010 = o_inv010._05(int.Parse(tb_gru_alm.Text));
            if (tab_inv010.Rows.Count == 0)
            {
                tb_gru_alm.Focus();
                return "El Grupo de Almacén NO se encuentra registrado";
            }

            if (tab_inv010.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_gru_alm.Focus();
                return "El Grupo de Almacén se encuentra Deshabilitado";
            }

            //VERIFICA numero de Grupo

            if (string.IsNullOrWhiteSpace(tb_nro_alm.Text))
            {
                tb_nro_alm.Focus();
                return "Debes proporcionar el Número del Almacén";
            }

            if (int.Parse(tb_nro_alm.Text) <= 0)
            {
                tb_nro_alm.Focus();
                return "El Número del Almacén debe ser mayor a cero";
            }

            //**Verifica Codigo de Almacén
            tab_inv011 = o_inv011._05(int.Parse(tb_cod_alm.Text));
            if (tab_inv011.Rows.Count != 0)
            {
                tb_cod_alm.Focus();
                return "El Código del Almacén ya se encuentra registrado";
            }

            //**Verifica el nombre del Almacén
            if (tb_nom_alm.Text.Trim() == "")
            {
                tb_nom_alm.Focus();
                return "Debes proporcionar el nombre del Almacén";
            }

            return null;
        }
        #endregion

        private void tb_cod_cta_ButtonCustomClick(object sender, EventArgs e)
        {
            CREARSIS._5_CTB.ctb004_plan_cuen_.ctb004_01 obj = new CREARSIS._5_CTB.ctb004_plan_cuen_.ctb004_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);

        }

        private void tb_cod_cta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                CREARSIS._5_CTB.ctb004_plan_cuen_.ctb004_01 obj = new CREARSIS._5_CTB.ctb004_plan_cuen_.ctb004_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }
    }
}
