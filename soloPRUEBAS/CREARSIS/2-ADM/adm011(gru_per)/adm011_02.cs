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
    public partial class adm011_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm011;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm011 o_adm011 = new c_adm011();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion      

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_gru.Focus();
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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_gru.Text.Trim() == "")
            {
                tb_cod_gru.Focus();
                return "Debes proporcionar el codigo de Grupo de Persona";
            }

            if (o_mg_glo_bal.fg_val_num(tb_cod_gru.Text)==false)
            {
                tb_cod_gru.Focus();
                return "El código de Grupo debe ser numérico";
            }

            if (int.Parse(tb_cod_gru.Text)<=0)
            {
                tb_cod_gru.Focus();
                return "El código de Grupo debe ser mayor a 0";
            }

            //if (tb_cod_gru.Text.Length < 3)
            //{
            //    tb_cod_gru.Focus();
            //    return "El código del Grupo de Persona debe tener 3 letras";
            //}

            tab_adm011 = o_adm011._05(int.Parse(tb_cod_gru.Text));
            if (tab_adm011.Rows.Count != 0)
            {
                tb_cod_gru.Focus();
                return "El codigo del Grupo de Persona ya se encuentra registrado";
            }

            if (tb_nom_gru.Text.Trim() == "")
            {
                tb_nom_gru.Focus();
                return "Debes proporcionar el nombre de Grupo de Persona";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public adm011_02()
        {
            InitializeComponent();
        }

        private void adm011_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm011._02(int.Parse( tb_cod_gru.Text), tb_nom_gru.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_gru.Text, tb_nom_gru.Text);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
