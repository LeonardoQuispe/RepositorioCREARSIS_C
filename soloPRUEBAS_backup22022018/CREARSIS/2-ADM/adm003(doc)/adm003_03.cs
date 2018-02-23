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
    /// <summary>
    /// FORMULARIO MODIFICA Grupo de Persona
    /// </summary>
    public partial class adm003_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm003 o_adm003 = new c_adm003();
        DataTable tab_adm003;

        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm()
        {
            tb_cod_doc.Text = vg_str_ucc.Rows[0]["va_cod_doc"].ToString();
            tb_nom_doc.Text = vg_str_ucc.Rows[0]["va_nom_doc"].ToString();
            tb_des_doc.Text = vg_str_ucc.Rows[0]["va_des_doc"].ToString();

            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H": tb_est_ado.Text = "Habilitado"; break;

                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }

            tb_nom_doc.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_doc.Clear();
            tb_nom_doc.Clear();
            tb_des_doc.Clear();

            tb_cod_doc.Focus();
        }


        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            if (tb_nom_doc.Text.Trim() == "")
            {
                tb_nom_doc.Focus();
                return "Debes proporcionar el nombre de Grupo de Persona";
            }

            tab_adm003 = o_adm003._05(tb_cod_doc.Text);
            if (tab_adm003.Rows.Count == 0)
            {
                return "Los datos han cambiado desde su ultima lectura; El Grupo de Persona ya NO se encuentra registrado";
            }

            if (tab_adm003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public adm003_03()
        {
            InitializeComponent();
        }

        private void adm003_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Acatualiza Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Acatualiza Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm003._03(0, tb_cod_doc.Text, tb_nom_doc.Text, tb_des_doc.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Modifica Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_doc.Text, tb_nom_doc.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        
    }
}
