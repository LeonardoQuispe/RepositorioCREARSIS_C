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
        public dynamic vg_frm_pad;
        c_adm012 o_adm012 = new c_adm012();


        public adm012_02()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            int tmp;

            try
            {
                if (tb_cod_act.Text.Trim()=="")
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el codigo", "error Nueva Actividad Economica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(tb_cod_act.Text ,out tmp)== false)
                {
                    tb_cod_act.Focus();
                    MessageBoxEx.Show("Dato no valido, debe ser numerico el codigo", "error Nueva Actividad Economica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tb_nom_act.Text.Trim()=="")
                {
                    tb_nom_act.Focus();
                    MessageBoxEx.Show("Debes proporcionar el nombre de la Actividad Economica", "error Nueva Actividad Economica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Nueva Actividad Economica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
    }
}
