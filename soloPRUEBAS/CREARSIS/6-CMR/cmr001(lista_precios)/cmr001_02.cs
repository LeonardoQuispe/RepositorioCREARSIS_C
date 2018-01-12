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

namespace CREARSIS._6_CMR.cmr001_lista_precios_
{
    public partial class cmr001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_cmr001;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        DATOS._6_CMR.c_cmr001 o_cmr001 = new DATOS._6_CMR.c_cmr001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_lis.Text == "")
            {
                tb_cod_lis.Focus();
                return "Debes proporcionar el codigo";
            }
            if (o_mg_glo_bal.fg_val_num(tb_cod_lis.Text) == false)
            {
                tb_cod_lis.Focus();
                return "El Codigo de la Lista de Precios debe ser Numerico";
            }
            tab_cmr001 = o_cmr001._05(tb_cod_lis.Text);
            if (tab_cmr001.Rows.Count != 0)
            {
                tb_cod_lis.Focus();
                return "El codigo de la Lista de Precios ya se encuentra registrado";
            }
            
            if (tb_nom_lis.Text == "")
            {
                tb_nom_lis.Focus();
                return "Debes proporcionar el nombre de la Lista de Precios ";
            }

            //**Verifica Fecha inicial y final-----------------------

            if ((tb_fec_fin.Value - tb_fec_ini.Value).Days <= 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }
            

            return null;
        }
        #endregion
        public cmr001_02()
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
                    MessageBoxEx.Show(err_msg, "Error Nueva Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Lista de Precios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                // grabar datos
                o_cmr001._02(Convert.ToInt32(tb_cod_lis.Text), tb_nom_lis.Text.Trim().ToString(), cb_mon_lis.SelectedIndex.ToString(), tb_fec_ini.Value, tb_fec_fin.Value);

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_sel_fila(tb_cod_lis.Text, tb_nom_lis.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_cod_lis.Clear();
                tb_nom_lis.Clear();
                cb_mon_lis.SelectedIndex = 0;
                tb_fec_ini.Value = o_mg_glo_bal.fg_fec_act();
                tb_fec_fin.Value = o_mg_glo_bal.fg_fec_act().AddMonths(6);


                tb_cod_lis.Focus();
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

        private void cmr001_02_Load(object sender, EventArgs e)
        {
            cb_mon_lis.SelectedIndex = 0;

            tb_fec_fin.Value = o_mg_glo_bal.fg_fec_act().AddMonths(6);
        }
    }
}
