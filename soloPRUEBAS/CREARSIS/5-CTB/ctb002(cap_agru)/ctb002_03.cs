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
    public partial class ctb002_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        DATOS._5_CTB.c_ctb002 o_ctb002 = new DATOS._5_CTB.c_ctb002();

        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_cap.Text = vg_str_ucc.Rows[0]["va_cod_cap"].ToString();
            tb_nom_cap.Text = vg_str_ucc.Rows[0]["va_nom_cap"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;

                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            switch (vg_str_ucc.Rows[0]["va_tra_cap"].ToString())
            {
                case "D": cb_trat_cap.SelectedIndex=0; break;

                case "A": cb_trat_cap.SelectedIndex = 1; break;
            }

            if (vg_str_ucc.Rows[0]["va_cen_cto"].ToString() == "1")
            {
                chk_cen.Checked = true;
            }

            tb_nom_cap.Focus();
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
            if (tb_nom_cap.Text.Trim() == "")
            {
                tb_nom_cap.Focus();
                return "Debes proporcionar el nombre de Capitulo/Agrupador";
            }
            

            return null;
        }

        #endregion

        #region EVENTOS

        public ctb002_03()
        {
            InitializeComponent();
        }

        private void ctb002_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Acatualiza Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Acatualiza Capitulo/Agrupador", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
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
                o_ctb002._03(int.Parse(tb_cod_cap.Text), tb_nom_cap.Text, cb_trat_cap.SelectedIndex.ToString(), var_cen);

                MessageBoxEx.Show("Operación completada exitosamente", "Modifica Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cap.Text, tb_nom_cap.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Capitulo/Agrupador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
