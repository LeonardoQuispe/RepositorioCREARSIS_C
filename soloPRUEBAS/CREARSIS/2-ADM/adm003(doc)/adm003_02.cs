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
    /// FORMULARIO NUEVO DOCUMENTO
    /// </summary>
    public partial class adm003_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm003;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm003 o_adm003 = new c_adm003();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_doc.Focus();
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
            if (tb_cod_doc.Text.Trim() == "")
            {
                tb_cod_doc.Focus();
                return "Debes proporcionar el codigo de documento";
            }

            if (o_mg_glo_bal.fg_val_let(tb_cod_doc.Text) == false)
            {
                tb_cod_doc.Focus();
                return "Sólo se admiten letras en el código del documento";
            }

            if (tb_cod_doc.Text.Length < 3)
            {
                tb_cod_doc.Focus();
                return "El código del documento debe tener 3 letras";
            }

            tab_adm003 = o_adm003._05(tb_cod_doc.Text);
            if (tab_adm003.Rows.Count != 0)
            {
                tb_cod_doc.Focus();
                return "El codigo del documento ya se encuentra registrado";
            }

            if (tb_nom_doc.Text.Trim() == "")
            {
                tb_nom_doc.Focus();
                return "Debes proporcionar el nombre de documento";
            }

            return null;
        }
        #endregion

        #region EVENTOS

        public adm003_02()
        {
            InitializeComponent();
        }

        private void adm003_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm003._02(0, tb_cod_doc.Text, tb_nom_doc.Text, tb_des_doc.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_doc.Text, tb_nom_doc.Text);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        
    }
}
