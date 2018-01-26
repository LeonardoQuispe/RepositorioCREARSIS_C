using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._8_TES;
using DevComponents.DotNetBar;




namespace CREARSIS._8_TES.tes001_caja_banco_
{
    public partial class tes001_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_tes001 o_tes001 = new c_tes001();

        #endregion

        #region EVENTOS

        public tes001_03()
        {
            InitializeComponent();
        }

        private void tes001_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Actualiza Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Caja/Banco", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Guarda PERSONA
            o_tes001._03(int.Parse(tb_cod_cjb.Text), tb_nom_cjb.Text.Trim(), tb_nro_cta.Text.Trim(), tb_cod_cta.Text.Trim());

            MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Caja/Banco", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_cjb.Text);

            Close();
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

            //Valida Tipo de Caja/Banco
            cb_tip_cjb.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_cjb"].ToString()) - 1;

            //Valida Moneda de Caja/Banco
            switch (vg_str_ucc.Rows[0]["va_mon_cjb"].ToString())
            {
                case "B": cb_mon_cjb.SelectedIndex = 0; break;
                case "U": cb_mon_cjb.SelectedIndex = 1; break;
            }

            //Llena los datos
            tb_cod_cjb.Text = vg_str_ucc.Rows[0]["va_cod_cjb"].ToString();
            tb_nom_cjb.Text = vg_str_ucc.Rows[0]["va_nom_cjb"].ToString();
            tb_nro_cta.Text = vg_str_ucc.Rows[0]["va_nro_cta"].ToString();
            tb_sal_cjb.Text = vg_str_ucc.Rows[0]["va_sal_cjb"].ToString();


            //Valida Estado
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
            //**Verifica Descripcion de Caja/Banco
            if (tb_nom_cjb.Text.Trim() == "")
            {
                tb_nom_cjb.Focus();
                return "Debes proporcionar el Nombre de la Caja/Banco";
            }

            //**Verifica Nro de Cuenta de banco de la Caja/Banco
            if (tb_nom_cjb.Text.Trim() == "")
            {
                tb_nom_cjb.Focus();
                return "Debes proporcionar el Nro de Cuenta de Banco de la Caja/Banco";
            }


            return null;
        }

        #endregion
    }
}
