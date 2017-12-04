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
    public partial class inv001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv001;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv001 o_inv001 = new c_inv001();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_tip_fam.SelectedIndex = 0;
            tb_cod_fam.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_fam.Clear();
            tb_nom_fam.Clear();

            tb_cod_fam.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_fam.Text.Trim() == "")
            {
                tb_cod_fam.Focus();
                return "Debes proporcionar el código de la Familia de producto";
            }

            tab_inv001 = o_inv001._05(tb_cod_fam.Text);
            if (tab_inv001.Rows.Count != 0)
            {
                tb_cod_fam.Focus();
                return "El codigo de la Familia de producto ya se encuentra registrada";
            }

            if (tb_nom_fam.Text.Trim() == "")
            {
                tb_nom_fam.Focus();
                return "Debes proporcionar el nombre de la Familia de producto";
            }

            return null;
        }
        #endregion

        public inv001_02()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Familia de producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv001._02(tb_cod_fam.Text.Trim(), tb_nom_fam.Text.Trim(), cb_tip_fam.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_fam.Text.Trim(), tb_nom_fam.Text.Trim());
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inv001_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
