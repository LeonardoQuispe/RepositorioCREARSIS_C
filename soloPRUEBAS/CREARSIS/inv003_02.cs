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
    public partial class inv003_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv003;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv003 o_inv003 = new c_inv003();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_uni.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_uni.Clear();
            tb_nom_uni.Clear();

            tb_cod_uni.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_uni.Text.Trim() == "")
            {
                tb_cod_uni.Focus();
                return "Debes proporcionar el código de la Unidad";
            }

            tab_inv003 = o_inv003._05(tb_cod_uni.Text);
            if (tab_inv003.Rows.Count != 0)
            {
                tb_cod_uni.Focus();
                return "El codigo de la Unidad ya se encuentra registrada";
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

        public inv003_02()
        {
            InitializeComponent();
        }

        private void inv003_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nueva Unidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Unidad", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv003._02(tb_cod_uni.Text.Trim(), tb_nom_uni.Text.Trim());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_uni.Text.Trim(), tb_nom_uni.Text.Trim());
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
