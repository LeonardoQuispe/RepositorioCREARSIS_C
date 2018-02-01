using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS._5_CTB;
using DevComponents.DotNetBar;


namespace CREARSIS._5_CTB.ctb003_centr_cost_
{
    public partial class ctb003_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_ctb003;
        string err_msg = null;

        #endregion

        #region INSTANCIAS

        c_ctb003 o_ctb003 = new c_ctb003();

        #endregion

        #region EVENTOS

        public ctb003_06()
        {
            InitializeComponent();
        }

        private void ctb003_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Elimina Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Eliminar el Centro de Costos?", "Elimina Centro de Costos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //ELIMINA datos
            o_ctb003._06(int.Parse(tb_cod_cct.Text));

            MessageBoxEx.Show("Operación completada exitosamente", "Elimina Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex, vg_frm_pad.cb_est_bus.SelectedIndex);

            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            //Valida Moneda de Centro de Costos
            switch (vg_str_ucc.Rows[0]["va_tip_cct"].ToString())
            {
                case "M": tb_tip_cct.Text = "Matriz"; break;
                case "A": tb_tip_cct.Text = "Analítica"; break;
            }

            //Llena los datos
            tb_cod_cct.Text = vg_str_ucc.Rows[0]["va_cod_cct"].ToString();
            tb_nom_cct.Text = vg_str_ucc.Rows[0]["va_nom_cct"].ToString();

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


        string fu_ver_dat()
        {
            //Valida en caso de que sea Matriz
            if (tb_tip_cct.Text == "Matriz")
            {
                //Valida que la Matriz n tenga Analíticas registradas antes de eliminar
                tab_ctb003 = o_ctb003._01(tb_cod_cct.Text[0].ToString(), 0, "T");

                if (tab_ctb003.Rows.Count >= 2)
                {
                    return "Primero debe Eliminar las Análíticas registradas en esta Matriz";
                }
            }

            return null;
        }

        #endregion
    }
}
