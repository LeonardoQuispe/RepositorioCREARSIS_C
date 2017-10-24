using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

//REFENCIAS
using System.Windows.Forms;
using DATOS.ADM;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO ELIMINA DOCUMENTO
    /// </summary>
    public partial class adm003_06 : DevComponents.DotNetBar.Metro.MetroForm
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

        #region EVENTOS

        public adm003_06()
        {
            InitializeComponent();
        }

        private void adm003_06_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Elimina Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("Estas seguro de Eliminar al Documento ?", "Elimina Documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_adm003._06(tb_cod_doc.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex, vg_frm_pad.cb_est_bus.SelectedIndex);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

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
            //Si aun existe el dato
            tab_adm003 = o_adm003._05(tb_cod_doc.Text);
            if (tab_adm003.Rows.Count == 0)
            {
                return "El Documento no se encuentra registrado";
            }

            //Verifica que no tenga talonarios ni siquiera deshabilitado
            tab_adm004 = o_adm004._05(tb_cod_doc.Text);
            if (tab_adm004.Rows.Count!=0)
            {
                return "El Documento tiene talonarios";
            }
            return null;
        }

        #endregion
    }
}
