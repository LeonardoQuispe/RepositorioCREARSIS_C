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

namespace CREARSIS._4_INV.inv011_alm_
{
    public partial class inv011_03a : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_inv010;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv011 o_inv011 = new c_inv011();
        c_inv010 o_inv010 = new c_inv010();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            
            tb_cod_alm.Text = vg_str_ucc.Rows[0]["va_cod_alm"].ToString().PadLeft(7, '0');
            tb_nom_alm.Text = vg_str_ucc.Rows[0]["va_nom_alm"].ToString();

            switch (vg_str_ucc.Rows[0]["va_mon_inv"].ToString())
            {
                case "B": cb_mon_inv.SelectedIndex = 0; break;
                case "U": cb_mon_inv.SelectedIndex = 1; break;
            }


            tb_nom_ecg.Text = vg_str_ucc.Rows[0]["va_nom_ecg"].ToString();

            tb_ult_fec.Text = vg_str_ucc.Rows[0]["va_fec_ctr"].ToString();

        }
        


        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_nom_alm.Text.Trim() == "")
            {
                tb_nom_alm.Focus();
                return "Debes proporcionar el nombre del Almacén";
            }

            return null;
        }

        #endregion

        #region EVENTOS

        public inv011_03a()
        {
            InitializeComponent();
        }

        private void inv011_03a_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Apertura Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Apertura Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Apertura datos
                o_inv011._03(int.Parse(tb_cod_alm.Text), tb_fec_ctr.Value);

                MessageBoxEx.Show("Operación completada exitosamente", "Apertura Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_alm.Text, tb_nom_alm.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Apertura Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
