using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS.ADM;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv001_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv001 o_inv001 = new c_inv001();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_fap.Text = vg_str_ucc.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fap.Text = vg_str_ucc.Rows[0]["va_nom_fam"].ToString();

            string pedo = vg_str_ucc.Rows[0]["va_est_ado"].ToString();

            switch (vg_str_ucc.Rows[0]["va_tip_fam"].ToString())
            {
                case "M":

                    cb_tip_fap.SelectedIndex = 0;
                    break;
                case "D":
                    cb_tip_fap.SelectedIndex = 1;
                    break;
                case "S":
                    cb_tip_fap.SelectedIndex = 2;
                    break;
                case "C":
                    cb_tip_fap.SelectedIndex = 3;
                    break;
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
            if (tb_cod_fap.Text.Trim() == "")
            {
                tb_cod_fap.Focus();
                return "Debes proporcionar el código de la Familia de producto";
            }


            if (tb_nom_fap.Text.Trim() == "")
            {
                tb_nom_fap.Focus();
                return "Debes proporcionar el nombre de la Familia de producto";
            }

            return null;
        }

        #endregion
        public inv001_03()
        {
            InitializeComponent();
        }

        private void inv001_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Actualiza Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Familia de producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv001._03(tb_cod_fap.Text.Trim(), tb_nom_fap.Text.Trim(),cb_tip_fap.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_fap.Text.Trim(), tb_nom_fap.Text.Trim());
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
