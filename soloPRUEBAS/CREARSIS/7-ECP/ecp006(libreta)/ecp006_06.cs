using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._7_ECP;
using DevComponents.DotNetBar;


namespace CREARSIS._7_ECP.ecp006_libreta_
{
    public partial class ecp006_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        c_ecp006 o_ecp006 = new c_ecp006();


        public ecp006_06()
        {
            InitializeComponent();
        }

        private void ecp006_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar la Libreta?", "Elimina Libreta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //ELIMINA datos
            o_ecp006._06(int.Parse(tb_cod_lib.Text));

            MessageBoxEx.Show("Operación completada exitosamente", "Elimina Libreta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex + 1, vg_frm_pad.cb_tip_lib.SelectedIndex + 1, vg_frm_pad.cb_est_bus.SelectedIndex);

            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }









        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //Valida Tipo de Libreta
            cb_tip_lib.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_lib"].ToString()) - 1;

            //Valida Moneda de Libreta
            switch (vg_str_ucc.Rows[0]["va_mon_lib"].ToString())
            {
                case "B": cb_mon_lib.SelectedIndex = 0; break;
                case "U": cb_mon_lib.SelectedIndex = 1; break;
            }

            //Llena los datos
            tb_cod_lib.Text = vg_str_ucc.Rows[0]["va_cod_lib"].ToString();
            tb_des_lib.Text = vg_str_ucc.Rows[0]["va_des_lib"].ToString();
            tb_cod_cta.Text = vg_str_ucc.Rows[0]["va_cod_cta"].ToString();


            //Valida Estado
            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }




    }
}
