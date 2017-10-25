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
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class ctb007_03a : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ctb007;
        DataTable tabla;

        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_ctb007 o_ctb007 = new c_ctb007();

        #endregion

        #region EVENTOS

        public ctb007_03a()
        {
            InitializeComponent();
        }

        private void ctb007_03a_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza llave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Actualiza llave", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_ctb007._03(int.Parse(tb_nro_dos.Text.Trim()), tb_lla_ve1.Text.Trim());

                vg_frm_pad.fu_sel_fila(tb_nro_dos.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);

            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            int cod_tpr = 0;
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_nro_dos.Text = vg_str_ucc.Rows[0]["va_nro_dos"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_fac"].ToString());

            tb_fec_ini.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ini"].ToString());
            tb_fec_fin.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_fin"].ToString());
            tb_lla_ve1.Text = vg_str_ucc.Rows[0]["va_lla_vee"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Dehabilitado";
            }

        }
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            int tmp;

            if (tb_nro_dos.Text == "")
            {
                tb_nro_dos.Focus();
                return "Debes proporcionar el número de Dosificación";
            }
            if (int.TryParse(tb_nro_dos.Text, out tmp) == false)
            {
                tb_nro_dos.Focus();
                return "Dato no valido, el número de Dosificación debe ser numerico ";
            }

            //Verifica que las llaves coincidan
            if (tb_lla_ve1.Text != tb_lla_ve2.Text)
            {
                tb_lla_ve1.Focus();
                return "Las llaves no coinciden, verifique por favor";
            }

            return "";
        }

        #endregion
    }
}
