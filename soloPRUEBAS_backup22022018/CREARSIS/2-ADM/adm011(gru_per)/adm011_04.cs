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

namespace CREARSIS._2_ADM.adm011_gru_per_
{
    public partial class adm011_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm011;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm011 o_adm011 = new c_adm011();
        c_adm004 o_adm004 = new c_adm004();
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_gru.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = vg_str_ucc.Rows[0]["va_nom_gru"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H":
                    tb_est_ado.Text = "Habilitado";
                    break;
                case "N":
                    tb_est_ado.Text = "Deshabilitado";
                    break;
            }
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_gru.Clear();
            tb_nom_gru.Clear();

            tb_cod_gru.Focus();
        }

        public string fu_ver_dat()
        {
            if (tb_cod_gru.Text.Trim() == "")
            {
                tb_cod_gru.Focus();
                return "Debes proporcionar el código de la Marca";
            }


            if (tb_nom_gru.Text.Trim() == "")
            {
                tb_nom_gru.Focus();
                return "Debes proporcionar el nombre de la Marca";
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public adm011_04()
        {
            InitializeComponent();
        }

        private void adm011_04_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Habilita/Deshabilita Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult res_msg = new DialogResult();
                if (tb_est_ado.Text == "Habilitado")
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar el Grupo de Persona?", "Deshabilita  Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar a el Grupo de Persona?", "Habilita  Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }



                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                if (tb_est_ado.Text == "Habilitado")
                {
                    o_adm011._04(int.Parse(tb_cod_gru.Text), "N");
                }
                else
                {
                    o_adm011._04(int.Parse(tb_cod_gru.Text), "H");
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_gru.Text.Trim(), tb_nom_gru.Text.Trim());
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Habilita/Deshabilita Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
