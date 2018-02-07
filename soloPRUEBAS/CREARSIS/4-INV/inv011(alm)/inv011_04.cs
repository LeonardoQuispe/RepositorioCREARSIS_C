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
    public partial class inv011_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_inv010;
        DataTable tab_ctb004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv011 o_inv011 = new c_inv011();
        c_inv010 o_inv010 = new c_inv010();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DATOS._5_CTB.c_ctb004 o_ctb004 = new DATOS._5_CTB.c_ctb004();

        #endregion

        #region EVENTOS

        public inv011_04()
        {
            InitializeComponent();
        }

        private void inv011_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                
                DialogResult res_msg = new DialogResult();
                if (tb_est_ado.Text == "Habilitado")
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar Almacén?", "Deshabilita Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar a la Grupo de Almacén?", "Habilita Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }


                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                if (tb_est_ado.Text == "Habilitado")
                {
                    o_inv011._04(int.Parse(tb_cod_alm.Text), "N");
                }
                else
                {
                    o_inv011._04(int.Parse(tb_cod_alm.Text), "H");
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_alm.Text.Trim(), tb_nom_alm.Text.Trim());
                Close();
            }

            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Habilita/Deshabilita Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //lenar tbx de Plan de Cuentas
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();
            tab_ctb004 = o_ctb004._05(tb_cod_cta.Text);
            if (tab_ctb004.Rows.Count != 0)
            {
                tb_nom_cta.Text = tab_ctb004.Rows[0]["va_nom_cta"].ToString();
            }

            tb_nom_ecg.Text = vg_str_ucc.Rows[0]["va_nom_ecg"].ToString();
            tb_tlf_ecg.Text = vg_str_ucc.Rows[0]["va_tlf_ecg"].ToString();
            tb_dir_ecg.Text = vg_str_ucc.Rows[0]["va_dir_ecg"].ToString();

            fu_rec_gru(vg_str_ucc.Rows[0]["va_cod_gru"].ToString());

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

        public void fu_rec_gru(string cod_gru)
        {
            tab_inv010 = o_inv010._05(int.Parse(cod_gru));

            tb_nom_gru.Text = tab_inv010.Rows[0]["va_nom_gru"].ToString();
        }
        #endregion
    }
}
