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
    /// FORMULARIO HABILITA/DESHABILITA DOCUMENTO
    /// </summary>
    public partial class adm003_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm003;
        DataTable tab_adm004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();
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
            tb_cod_doc.Clear();
            tb_nom_doc.Clear();
            tb_des_doc.Clear();

            tb_cod_doc.Focus();
        }


        public string fu_ver_dat()
        {
            //HACER LAS VALIDACIONES CORRESPONDIENTES

            //Verificar que no tenga talonarios pendientes
            //Verifica que no tenga talonarios ni siquiera deshabilitado
            tab_adm004 = o_adm004._05(tb_cod_doc.Text);
            if (tab_adm004.Rows.Count != 0)
            {
                for (int i = 0; i <= tab_adm004.Rows.Count - 1; i++)
                {
                    if (tab_adm004.Rows[i]["va_est_ado"].ToString() == "H")
                    {
                        return "El Documento tiene talonarios validos";
                    }
                }

            }

            return null;
        }

        #endregion

        #region EVENTOS

        public adm003_04()
        {
            InitializeComponent();
        }

        private void adm003_04_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res_msg = new DialogResult();
                string edo_msg = "";
                //Variable estado para mostrar en el mensaje de confirmacion
                string est_ado = "";
                //Variable estado para guardar en la BD

                if (tb_est_ado.Text == "Habilitado")
                {
                    edo_msg = "Deshabilitar";
                    est_ado = "N";

                    err_msg = fu_ver_dat();
                    if (err_msg != null)
                    {
                        MessageBoxEx.Show(err_msg, "Error Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    edo_msg = "Habilitar";
                    est_ado = "H";
                }

                res_msg = MessageBoxEx.Show("Estas seguro de " + edo_msg + " el documento ?", "Habilita/Deshabilita documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm003._04(tb_cod_doc.Text, est_ado);

                MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_doc.Text, tb_nom_doc.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
