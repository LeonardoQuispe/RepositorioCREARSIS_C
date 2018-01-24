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
        public dynamic vg_frm_pad;
        DataTable tab_ecp006;
        string err_msg = "";
        string tmp_cod_lib = "";


        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_ecp006 o_ecp006 = new c_ecp006();


        public ecp006_02()
        {
            InitializeComponent();
        }

        private void ecp006_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void cb_tip_lib_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_cod_lib = tb_cod_lib.Text;

            if (cb_tip_lib.SelectedIndex == 0)
            {
                tb_cod_lib.Text = "1" + tmp_cod_lib[1].ToString() + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
            else if (cb_tip_lib.SelectedIndex == 1)
            {
                tb_cod_lib.Text = "2" + tmp_cod_lib[1].ToString() + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
            else
            {
                tb_cod_lib.Text = "0" + tmp_cod_lib[1].ToString() + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
        }

        private void cb_mon_lib_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_cod_lib = tb_cod_lib.Text;

            if (cb_mon_lib.SelectedIndex == 0)
            {
                tb_cod_lib.Text = tmp_cod_lib[0].ToString() + "1" + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
            else if (cb_mon_lib.SelectedIndex == 1)
            {
                tb_cod_lib.Text = tmp_cod_lib[0].ToString() + "2" + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
            else
            {
                tb_cod_lib.Text = tmp_cod_lib[0].ToString() + "0" + tmp_cod_lib[2].ToString() + tmp_cod_lib[3].ToString() + tmp_cod_lib[4].ToString();
            }
        }

        private void tb_nro_lib_Validated(object sender, EventArgs e)
        {
            tmp_cod_lib = tb_cod_lib.Text;

            if (tb_nro_lib.Text.Trim() == "" || o_mg_glo_bal.fg_val_num(tb_nro_lib.Text.Trim()) == false)
            {
                tb_nro_lib.Clear();

                tb_cod_lib.Text = tmp_cod_lib[0].ToString() + tmp_cod_lib[1].ToString() + "000";
            }
            else
            {
                tb_cod_lib.Text = tmp_cod_lib[0].ToString() + tmp_cod_lib[1].ToString() + tb_nro_lib.Text.PadLeft(3, '0');
            }
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

                if (cb_mon_lib.SelectedIndex==0)
                {
                    va_mon_lis = "B";
                }
                else if (cb_mon_lib.SelectedIndex == 1)
                {
                    va_mon_lis = "U";
                }

                //Graba datos
                o_ecp006._02(int.Parse(tb_cod_lib.Text.Trim()), cb_tip_lib.SelectedIndex + 1, va_mon_lis,
                            int.Parse(tb_nro_lib.Text.Trim()), tb_des_lib.Text.Trim(), tb_cod_cta.Text.Trim());

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







        void fu_ini_frm()
        {
            cb_tip_lib.SelectedIndex = 0;
            cb_mon_lib.SelectedIndex = 0;

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
        }

        string fu_ver_dat()
        {
            //Valida Nro de Libreta
            if (tb_nro_lib.Text.Trim() == "")
            {
                tb_nro_lib.Focus();
                return "Debes proporcionar el Nro de la Libreta";
            }

            //Valida Codigo de Libreta
            if (tb_cod_lib.Text.Trim()=="")
            {
                tb_cod_lib.Focus();
                return "Debes proporcionar el Código de la Libreta";
            }

            tab_ecp006 = o_ecp006._05(int.Parse(tb_cod_lib.Text));
            if (tab_ecp006.Rows.Count != 0)
            {
                tb_cod_lib.Focus();
                return "El Código de la Libreta ya se encuentra registrado";
            }

            //Valida Descripcion de Libreta
            if (tb_des_lib.Text.Trim()=="")
            {
                tb_des_lib.Focus();
                return "Debes proporcionar la Descripción de la Libreta";
            }

            //Valida Cuenta Contabe
            if (tb_cod_cta.Text.Trim()=="")
            {
                tb_cod_cta.Focus();
                return "Debes proporcionar la Cuenta Contable de la Libreta";
            }

            return null;
        }

        


    }
}
