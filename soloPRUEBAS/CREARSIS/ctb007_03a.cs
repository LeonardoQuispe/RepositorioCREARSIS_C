using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REGERENCIAS
using DATOS;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class ctb007_03a : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ctb007;
        string va_msg_err = "";

        #endregion

        #region INSTANCIAS

        c_ctb007 o_ctb007 = new c_ctb007();

        #endregion

        #region EVENTOS

        public ctb007_03a()
        {
            InitializeComponent();
        }

        private void ctb007_10_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //Verifica que los datos esten corectos
            try
            {
                if (fu_ver_dat() != null)
                {
                    MessageBoxEx.Show(va_msg_err, "Error Actualiza Llave de Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult vv_res_dlg = new DialogResult();
                vv_res_dlg = MessageBoxEx.Show("Esta seguro de grabar los datos ?", "Actualiza Llave de Dosificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (vv_res_dlg == DialogResult.Cancel)
                {
                    return;
                }


                o_ctb007._03(Int64.Parse(tb_nro_dos.Text), tb_lla_ve1.Text.Trim());


                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Llave de Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_nro_dos.Text);

                Close();


            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Llave de Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            tb_lla_ve1.Text = "";
            tb_lla_ve2.Text = "";

            tb_nro_dos.Text = vg_str_ucc.Rows[0]["va_nro_aut"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_fac"].ToString());
            tb_fec_ini.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ini"].ToString());
            tb_fec_fin.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_fin"].ToString());
            tb_lla_ve1.Text = vg_str_ucc.Rows[0]["va_lla_vee"].ToString();
            tb_lla_ve2.Text = vg_str_ucc.Rows[0]["va_lla_vee"].ToString();


            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }


            tb_lla_ve1.Focus();
        }

        public string fu_ver_dat()
        {
            va_msg_err = null;

            if (tb_lla_ve1.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar la llave de la Dosificación";
                tb_lla_ve1.Focus();
                return va_msg_err;
            }


            if (tb_lla_ve2.Text.Trim() == "")
            {
                va_msg_err = "Debe proporcionar la llave de la Dosificacion para verificación";
                tb_lla_ve2.Focus();
                return va_msg_err;
            }

            if (tb_lla_ve1.Text.Trim() != tb_lla_ve2.Text.Trim())
            {
                va_msg_err = "Las llaves no son iguales, verifique por favor.";
                tb_lla_ve2.Focus();
                return va_msg_err;
            }

            return va_msg_err;
        }

        #endregion

    }
}
