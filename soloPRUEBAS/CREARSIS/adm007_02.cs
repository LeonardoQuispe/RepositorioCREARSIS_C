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
using CREARSIS.GLOBAL;

namespace CREARSIS
{
    public partial class adm007_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_adm007;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_adm007 o_adm007 = new c_adm007();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region METODOS

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

            if (tb_nom_suc.Text== "")
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
            if (tab_adm007.Rows.Count!=0)
            {
                tb_cod_suc.Focus();
                return "El codigo de la Sucursal ya se encuentra registrado";
            }

            return null;
        }

        public bool validar_Mail(string sMail)
        {
            // retorna true o false 
            return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,4})$");
        }

        #endregion

        #region EVENTOS

        public adm007_02()
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
                    MessageBoxEx.Show(err_msg, "Error Nueva Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Sucursal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if ((res_msg == DialogResult.Cancel))
                {
                    return;
                }

                // grabar datos
                o_adm007._02(Convert.ToInt32( tb_cod_suc.Text), tb_nom_suc.Text.Trim().ToString(), tb_res_suc.Text.Trim().ToString(), tb_ubi_suc.Text.Trim().ToString(), tb_tel_suc.Text.Trim().ToString(), tb_ema_suc.Text.Trim().ToString(), tb_ciu_suc.Text.Trim().ToString(), tb_ley_suc.Text.Trim().ToString());

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_sel_fila(tb_cod_suc.Text, tb_nom_suc.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_cod_suc.Clear();
                tb_nom_suc.Clear();
                tb_res_suc.Clear();
                tb_ubi_suc.Clear();
                tb_tel_suc.Clear();
                tb_ema_suc.Clear();
                tb_ciu_suc.Clear();
                tb_ley_suc.Clear();
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

        private void tb_cod_suc_TextChanged(object sender, EventArgs e)
        {
            tb_cod_suc.Text = o_mg_glo_bal.valida_numeros(tb_cod_suc.Text);
        }

        private void tb_tel_suc_TextChanged(object sender, EventArgs e)
        {
            tb_tel_suc.Text = o_mg_glo_bal.valida_numeros(tb_tel_suc.Text);
        }
    }
}
