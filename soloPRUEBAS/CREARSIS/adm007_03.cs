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
using System.Text.RegularExpressions;

namespace CREARSIS
{
    public partial class adm007_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm007;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm007 o_adm007 = new c_adm007();

        #endregion

        #region "Metodos"

        public void fu_ini_frm()
        {
            int cod_tpr = 0;
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_suc.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nom_suc.Text = vg_str_ucc.Rows[0]["va_nom_suc"].ToString();

            tb_res_suc.Text = vg_str_ucc.Rows[0]["va_enc_suc"].ToString();
            tb_ubi_suc.Text = vg_str_ucc.Rows[0]["va_ubi_suc"].ToString();
            tb_tel_suc.Text = vg_str_ucc.Rows[0]["va_tel_suc"].ToString();
            tb_ema_suc.Text = vg_str_ucc.Rows[0]["va_ema_suc"].ToString();
            tb_ciu_suc.Text = vg_str_ucc.Rows[0]["va_ciu_suc"].ToString();
            tb_ley_suc.Text = vg_str_ucc.Rows[0]["va_ley_suc"].ToString();

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
            if (tb_cod_suc.Text == "")
            {
                tb_cod_suc.Focus();
                return "Debes proporcionar el codigo";
            }

            int tmp;
            if (int.TryParse(tb_cod_suc.Text, out tmp) == false)
            {
                tb_cod_suc.Focus();
                return "Dato no valido, debe ser numerico el codigo";
            }
            if (tb_nom_suc.Text == "")
            {
                tb_nom_suc.Focus();
                return "Debes proporcionar el nombre de la Sucursal ";
            }
            if (tb_res_suc.Text == "")
            {
                tb_res_suc.Focus();
                return "Debes proporcionar el nombre del Responsable de sucursal ";
            }
            if ((tb_ema_suc.Text).Trim().Length > 0)
            {
                if (validar_Mail((tb_ema_suc.Text).Trim().ToString()) == false)
                {
                    tb_ema_suc.Focus();
                    return "Debes proporcionar un correo electronico valido";
                }
            }
            
            tab_adm007 = o_adm007._05(tb_cod_suc.Text);
            if (tab_adm007.Rows.Count == 0)
            {
                return "La Sucursal no se encuentra registrada";
            }

            return null;
        }

        public bool validar_Mail(string sMail)
        {
            // retorna true o false 
            return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,4})$");
        }

        #endregion
        public adm007_03()
        {
            InitializeComponent();
        }

        private void adm007_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos?", "Actualiza Sucursal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_adm007._03(int.Parse( tb_cod_suc.Text), tb_nom_suc.Text.Trim().ToString(), tb_res_suc.Text.Trim().ToString(), tb_ubi_suc.Text.Trim().ToString(), tb_tel_suc.Text.Trim().ToString(),tb_ema_suc.Text.Trim().ToString(),tb_ciu_suc.Text.Trim().ToString(),tb_ley_suc.Text.Trim().ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vg_frm_pad.fu_sel_fila(tb_cod_suc.Text, tb_nom_suc.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
