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
    public partial class inv010_04 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm007;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv010 o_inv010 = new c_inv010();
        c_adm007 o_adm007 = new c_adm007();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_cod_sucu.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nro_gru.Text = vg_str_ucc.Rows[0]["va_nro_gru"].ToString();
            tb_cod_gru.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString().PadLeft(4, '0');
            tb_nom_gru.Text = vg_str_ucc.Rows[0]["va_nom_gru"].ToString();
            tb_des_gru.Text = vg_str_ucc.Rows[0]["va_des_gru"].ToString();

            fu_rec_suc(vg_str_ucc.Rows[0]["va_cod_suc"].ToString());

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }
        }
        public string fu_ver_dat()
        {
            if (tb_cod_gru.Text.Trim() == "")
            {
                tb_cod_gru.Focus();
                return "Debes proporcionar el código de la Grupo de Almacén";
            }
            
            return null;
        }

        void fu_rec_suc(string cod_suc)
        {
            tab_adm007 = o_adm007._05(cod_suc);

            tb_nom_sucu.Text = tab_adm007.Rows[0]["va_nom_suc"].ToString();
        }

        #endregion

        #region EVENTOS
        public inv010_04()
        {
            InitializeComponent();
        }

        private void inv010_04_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Habilita/Deshabilita Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult res_msg = new DialogResult();
                if (tb_est_ado.Text == "Habilitado")
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Deshabilitar la  Grupo de Almacén?", "Deshabilita  Grupo de Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBoxEx.Show("¿Estas seguro de Habilitar a la Grupo de Almacén?", "Habilita  Grupo de Almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }



                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                if (tb_est_ado.Text == "Habilitado")
                {
                    o_inv010._04(int.Parse(tb_cod_gru.Text), "N");
                }
                else
                {
                    o_inv010._04(int.Parse(tb_cod_gru.Text), "H");
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Habilita/Deshabilita Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_gru.Text.Trim(), tb_nom_gru.Text.Trim());
                Close();
            }
                
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Habilita/Deshabilita Grupo de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
