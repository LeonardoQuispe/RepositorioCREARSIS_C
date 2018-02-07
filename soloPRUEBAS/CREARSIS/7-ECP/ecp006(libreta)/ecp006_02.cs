using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._7_ECP;
using DevComponents.DotNetBar;


namespace CREARSIS._7_ECP.ecp006_libreta_
{
    public partial class ecp006_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ecp006;
        DataTable tab_ctb004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS
        
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();
        c_ecp006 o_ecp006 = new c_ecp006();

        #endregion

        #region EVENTOS

        public ecp006_02()
        {
            InitializeComponent();
        }

        private void ecp006_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

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
        private void cb_tip_lib_SelectedIndexChanged(object sender, EventArgs e)
        {
            fu_sug_nro();
            fu_cod_lib();
        }

        private void tb_nro_lib_Validated(object sender, EventArgs e)
        {
            fu_cod_lib();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Libreta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Libreta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                string va_mon_lis = "";

                if (cb_mon_lib.SelectedIndex == 0)
                {
                    va_mon_lis = "B";
                }
                else if (cb_mon_lib.SelectedIndex == 1)
                {
                    va_mon_lis = "U";
                }

                //Graba datos
                o_ecp006._02(int.Parse(tb_cod_lib.Text.Trim()), cb_tip_lib.SelectedIndex + 1,
                            va_mon_lis, tb_des_lib.Text.Trim(), tb_cod_cta.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Libreta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_lib.Text.Trim());

                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Libreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cb_tip_lib.SelectedIndex = 0;
            cb_mon_lib.SelectedIndex = 0;

            fu_sug_nro();
            fu_cod_lib();

            tb_nro_lib.Focus();
        }

        void fu_lim_frm()
        {
            cb_tip_lib.SelectedIndex = 0;
            cb_mon_lib.SelectedIndex = 0;
            tb_nro_lib.Text = "0";
            tb_cod_lib.Text = "11000";
            tb_des_lib.Clear();
            tb_cod_cta.Clear();

            tb_nro_lib.Focus();

            tb_nom_cta.Clear();

            fu_sug_nro();
            fu_cod_lib();
        }

        string fu_ver_dat()
        {
            fu_cod_lib();

            //Valida Nro de Libreta
            if (tb_nro_lib.Text.Trim() == "")
            {
                tb_nro_lib.Focus();
                return "Debes proporcionar el Nro de la Libreta";
            }
            if (o_mg_glo_bal.fg_val_num(tb_nro_lib.Text) == false)
            {
                tb_nro_lib.Focus();
                return "El Nro de la Libreta debe ser numérico";
            }
            if (int.Parse(tb_nro_lib.Text.Trim()) <= 0)
            {
                tb_nro_lib.Focus();
                return "El Nro de la Libreta debe ser mayor a 0";
            }

            //Valida Codigo de Libreta
            if (tb_cod_lib.Text.Trim() == "")
            {
                tb_cod_lib.Focus();
                return "Debes proporcionar el Código de la Libreta";
            }

            tab_ecp006 = o_ecp006._05(int.Parse(tb_cod_lib.Text));
            if (tab_ecp006.Rows.Count != 0)
            {
                tb_nro_lib.Focus();
                return "El Código de la Libreta ya se encuentra registrado";
            }

            //Valida Descripcion de Libreta
            if (tb_des_lib.Text.Trim() == "")
            {
                tb_des_lib.Focus();
                return "Debes proporcionar la Descripción de la Libreta";
            }


            return null;
        }


        /// <summary>
        /// Función que arma el código compuesto de Libreta
        /// </summary>
        void fu_cod_lib()
        {
            if (tb_nro_lib.Text.Trim() == "" || o_mg_glo_bal.fg_val_num(tb_nro_lib.Text.Trim()) == false)
            {
                tb_nro_lib.Clear();

                tb_cod_lib.Text = (cb_tip_lib.SelectedIndex + 1).ToString() + (cb_mon_lib.SelectedIndex + 1).ToString() + "000";
            }
            else
            {
                tb_cod_lib.Text = (cb_tip_lib.SelectedIndex + 1).ToString() + (cb_mon_lib.SelectedIndex + 1).ToString() + tb_nro_lib.Text.Trim().PadLeft(3, '0');
            }
        }

        /// <summary>
        /// FUnción que sugiere el último numero usado, según el Tipo y Moneda de la Libreta
        /// </summary>
        void fu_sug_nro()
        {
            int tip_lib;
            int mon_lib;
            string nro;
            int nro_sug;

            tip_lib = cb_tip_lib.SelectedIndex + 1;
            mon_lib = cb_mon_lib.SelectedIndex + 1;

            //Numero Conformado
            nro = tip_lib.ToString() + mon_lib.ToString();

            //Realiza Consulta a BD con el numero conformado
            tab_ecp006 = o_ecp006._05a(nro);

            if (tab_ecp006.Rows[0][0].ToString() == "")
            {
                tb_nro_lib.Text = "1";
                return;
            }

            nro_sug = int.Parse(tab_ecp006.Rows[0][0].ToString().Substring(2, 3)) + 1;

            tb_nro_lib.Text = nro_sug.ToString();
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

        #endregion


    }
}
