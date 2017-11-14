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
    public partial class adm013_02a : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vv_str_ucc;
        string err_msg = "";
        DataTable tab_adm013;
        DataTable tabla;
        int vv_ban_tcm = 0;

        #endregion

        #region INSTANCIAS

        c_adm013 o_adm013 = new c_adm013();

        #endregion


        #region "Metodos"
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {

            decimal temp;
            if (decimal.TryParse(tb_val_tcm.Text, out temp) == false)
            {
                tb_val_tcm.Focus();
                return "Dato no valido, el T.C. debe ser numerico";
            }
            if (Convert.ToDecimal(tb_val_tcm.Text.Replace('.', ',')) < 0)
            {
                return "Dato no valido, el T.C. debe ser mayor a cero";
            }
            if (Convert.ToDecimal(tb_val_tcm.Text.Replace('.', ',')) > 10)
            {
                return "Dato no valido, el T.C. debe ser menor que 10";
            }

            DateTime Dtemp;
            if (DateTime.TryParse(tb_fec_ini.Text, out Dtemp) == false)
            {
                tb_fec_ini.Focus();
                return "La fecha es invalida";
            }
            if (DateTime.TryParse(tb_fec_fin.Text, out Dtemp) == false)
            {
                tb_fec_fin.Focus();
                return "La fecha es invalida";
            }

            if ((tb_fec_fin.Value - tb_fec_ini.Value).Days <= 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }

            return null;
        }

        #endregion
        public adm013_02a()
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo T.C. Bs./Us. p/rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;

                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Nuevo T.C. Bs./Us. p/rango", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_adm013._06(tb_fec_ini.Value, tb_fec_fin.Value);
                o_adm013._02(tb_fec_ini.Value, tb_fec_fin.Value, tb_val_tcm.Text);

                DateTime aux;
                aux = Convert.ToDateTime(tb_fec_ini.Text);
                vg_frm_pad.fu_bus_car(aux.Month.ToString(), aux.Year);

                //Selecciona el mes y el año de la fecha aux que va ser la fecha inicial
                vg_frm_pad.tb_val_año.Text = aux.Year.ToString();
                vg_frm_pad.cb_prm_bus.SelectedIndex = aux.Month - 1;

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo T.C. Bs./Us. p/rango", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void tb_val_tcm_TextChanged(object sender, EventArgs e)
        {
            if (tb_val_tcm.Text.Contains(","))
            {
                tb_val_tcm.Text = tb_val_tcm.Text.Replace(",", ".");

                //System.Media.SystemSounds.Beep.Play();

                //posiciona el cursor al final del texto
                tb_val_tcm.Select(tb_val_tcm.Text.Length, 0);
            }
        }

        private void adm013_02a_Load(object sender, EventArgs e)
        {
            tb_fec_fin.Value = DateTime.Today;
            tb_fec_ini.Value = DateTime.Today;
        }
    }
}
