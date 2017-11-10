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
    public partial class adm014_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        DataTable tab_adm014;
        DataTable tabla;
        int vv_ban_tcm = 0;

        #endregion

        #region INSTANCIAS

        c_adm014 o_adm014 = new c_adm014();

        #endregion


        #region "Metodos"
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        DateTime Dtemp;
        public string fu_ver_dat()
        {
            if (DateTime.TryParse(tb_fec_tcm.Text,out Dtemp) == false)
            {
                tb_fec_tcm.Focus();
                return "La fecha es invalida";
            }

            decimal temp;
            if (decimal.TryParse(tb_val_tcm.Text, out temp) == false)
            {
                tb_val_tcm.Focus();
                return "Dato no valido, el T.C. debe ser numerico";
            }

            if (Convert.ToDecimal(tb_val_tcm.Text.Replace('.', ',')) > 10)
            {
                return "Dato no valido, el T.C. debe ser menor que 10";
            }

            tab_adm014 = o_adm014._05(tb_fec_tcm.Text);
            if (tab_adm014.Rows.Count!=0)
            {
                //--** si esa fecha ya tiene valor
                vv_ban_tcm = 1;
            }
            else
            {
                //--** si esa fecha aun no tiene valor
                vv_ban_tcm = 0;
            }

            

            return null;
        }

        #endregion
        public adm014_02()
        {
            InitializeComponent();
        }

        private void adm014_02_Load(object sender, EventArgs e)
        {
            tb_fec_tcm.Text = vg_str_ucc.Rows[0]["va_fec_tcm"].ToString();
            tb_val_tcm.Text = vg_str_ucc.Rows[0]["va_val_tcm"].ToString();

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo T.C. Bs./Us.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;

                if (vv_ban_tcm == 0)
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Nuevo T.C. Bs./Us.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿La fecha ya tiene tipo de cambio asignada, esta seguro de continuar ?", "Nuevo T.C. Bs./Us.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }


                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_adm014._06(tb_fec_tcm.Text);

                if (tb_val_tcm.Text!=null)
                {
                    o_adm014._02(Convert.ToDateTime( tb_fec_tcm.Text), tb_val_tcm.Text);
                }
                DateTime aux;
                aux = Convert.ToDateTime(tb_fec_tcm.Text);
                vg_frm_pad.fu_bus_car(aux.Month.ToString(),Convert.ToInt32( aux.Year));

                tb_fec_tcm.Clear();
                tb_val_tcm.Clear();
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
    }
}
