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
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv011_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv011 o_inv011 = new c_inv011();

        #endregion

        #region EVENTOS

        public inv011_03()
        {
            InitializeComponent();
        }

        private void inv011_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //ACTUALIZA datos
                o_inv011._03(int.Parse(tb_cod_alm.Text), tb_nom_alm.Text.Trim(), tb_des_alm.Text.Trim(), tb_dir_alm.Text.Trim(), dt_fec_ctr.Value, cb_mon_inv.SelectedIndex.ToString(),
                    cb_mtd_cto.SelectedIndex.ToString(), tb_nom_ecg.Text.Trim(), tb_tlf_ecg.Text.Trim(), tb_dir_ecg.Text.Trim(), tb_cta_alm.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_alm.Text, tb_nom_alm.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            tb_gru_alm.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString().PadLeft(4, '0');
            tb_nro_alm.Text = vg_str_ucc.Rows[0]["va_nro_alm"].ToString();
            tb_cod_alm.Text = vg_str_ucc.Rows[0]["va_cod_alm"].ToString().PadLeft(7, '0');
            tb_nom_alm.Text = vg_str_ucc.Rows[0]["va_nom_alm"].ToString();
            tb_des_alm.Text = vg_str_ucc.Rows[0]["va_des_alm"].ToString();
            tb_dir_alm.Text = vg_str_ucc.Rows[0]["va_dir_alm"].ToString();
            tb_cta_alm.Text = vg_str_ucc.Rows[0]["va_cta_alm"].ToString();
            dt_fec_ctr.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ctr"].ToString());
            tb_nom_ecg.Text = vg_str_ucc.Rows[0]["va_nom_ecg"].ToString();
            tb_tlf_ecg.Text = vg_str_ucc.Rows[0]["va_tlf_ecg"].ToString();
            tb_dir_ecg.Text = vg_str_ucc.Rows[0]["va_dir_ecg"].ToString();

            switch (vg_str_ucc.Rows[0]["va_mon_inv"].ToString())
            {
                case "B": cb_mon_inv.SelectedIndex = 0; break;
                case "U": cb_mon_inv.SelectedIndex = 1; break;
            }

            switch (vg_str_ucc.Rows[0]["va_mtd_cto"].ToString())
            {
                case "P": cb_mtd_cto.SelectedIndex = 0; break;
            }


            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

            tb_nom_alm.Focus();
        }


        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nom_alm.Text.Trim() == "")
            {
                tb_nom_alm.Focus();
                return "Debes proporcionar el nombre del Almacén";
            }

            return null;
        }

        #endregion
    }
}
