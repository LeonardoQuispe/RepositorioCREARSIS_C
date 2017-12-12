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

using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv003_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv003 o_inv003 = new c_inv003();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_uni.Text = vg_str_ucc.Rows[0]["va_cod_umd"].ToString();
            tb_nom_uni.Text = vg_str_ucc.Rows[0]["va_nom_umd"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }
        public string fu_ver_dat()
        {
            if (tb_cod_uni.Text.Trim() == "")
            {
                tb_cod_uni.Focus();
                return "Debes proporcionar el código de las Unidad";
            }


            if (tb_nom_uni.Text.Trim() == "")
            {
                tb_nom_uni.Focus();
                return "Debes proporcionar el nombre de la Unidad";
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public inv003_06()
        {
            InitializeComponent();
        }

        private void inv003_06_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Elimina Unidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar la Unidad ?", "Elimina Unidad", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv003._06(tb_cod_uni.Text.Trim());

                

                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex);

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
