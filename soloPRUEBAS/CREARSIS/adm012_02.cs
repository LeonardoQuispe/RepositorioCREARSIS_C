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
    public partial class adm012_02 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm012;        

        #endregion

        #region INSTANCIAS

        c_adm012 o_adm012 = new c_adm012();

        #endregion

        #region EVENTOS

        public adm012_02()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            int tmp;

            try
            {
                if (tb_cod_act.Text.Trim() == "")
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el codigo", "error Nueva Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(tb_cod_act.Text, out tmp) == false)
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Dato no valido, debe ser numerico el codigo", "error Nueva Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tb_nom_act.Text.Trim() == "")
                {
                    tb_nom_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el nombre de la Actividad Económica", "error Nueva Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                tab_adm012 = o_adm012._05(tb_cod_act.Text);
                if (tab_adm012.Rows.Count != 0)
                {
                    MessageBoxEx.Show("El codigo de la Actividad Económica ya se encuentra registrado", "error Nueva Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_act.Focus();
                    return ;
                }

                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Nueva Actividad Económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_adm012._02(int.Parse(tb_cod_act.Text), tb_nom_act.Text);

                vg_frm_pad.fu_sel_fila(tb_cod_act.Text, tb_nom_act.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Actividad Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_cod_act.Clear();
                tb_nom_act.Clear();
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

    }
}
