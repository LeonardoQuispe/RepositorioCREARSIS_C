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

namespace CREARSIS._5_CTB.ctb002_cap_agru_
{
    public partial class ctb002_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb002;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._5_CTB.c_ctb002 o_ctb002 = new DATOS._5_CTB.c_ctb002();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_trat_cap.SelectedIndex = 0;
            tb_cod_cap.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_cap.Clear();
            tb_nom_cap.Clear();
            cb_trat_cap.SelectedIndex = 0;
            chk_cen.Checked = false;
            tb_cod_cap.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_cap.Text.Trim() == "")
            {
                tb_cod_cap.Focus();
                return "Debes proporcionar el codigo de Capitulo/Agrupador";
            }

            if (o_mg_glo_bal.fg_val_num(tb_cod_cap.Text) == false)
            {
                tb_cod_cap.Focus();
                return "El codigo de Capitulo/Agrupador debe ser Numerico";
            }

            if (int.Parse(tb_cod_cap.Text.Trim()) <= 0)
            {
                tb_cod_cap.Focus();
                return "El Codigo de Capitulo/Agrupador debe ser mayor a cero";
            }

            tab_ctb002 = o_ctb002._05(int.Parse(tb_cod_cap.Text));
            if (tab_ctb002.Rows.Count != 0)
            {
                tb_cod_cap.Focus();
                return "El codigo del Capitulo/Agrupador ya se encuentra registrado";
            }

            if (tb_nom_cap.Text.Trim() == "")
            {
                tb_nom_cap.Focus();
                return "Debes proporcionar el nombre de Capitulo/Agrupador";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public ctb002_02()
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Capitulo/Agrupador", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                //----------- chekbox--
                int var_cen = 0;

                if (chk_cen.Checked == true)
                {
                    var_cen = 1;
                }
                else
                {
                    var_cen = 0;
                }
                //Graba datos
                o_ctb002._02(int.Parse(tb_cod_cap.Text), tb_nom_cap.Text,cb_trat_cap.SelectedIndex.ToString(), var_cen);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cap.Text, tb_nom_cap.Text);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctb002_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
