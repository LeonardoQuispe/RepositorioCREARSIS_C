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
    public partial class ecp006_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";

                
        c_ecp006 o_ecp006 = new c_ecp006();


        public ecp006_03()
        {
            InitializeComponent();
        }

        private void ecp006_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error Actualiza Libreta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza Libreta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Guarda PERSONA
            o_ecp006._03(int.Parse(tb_cod_lib.Text),tb_des_lib.Text.Trim(), tb_cod_cta.Text.Trim());

            MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Libreta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_lib.Text);

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
            cb_tip_lib.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_lib"].ToString())-1;

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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {            
            //**Verifica Descripcion de Libreta
            if (tb_des_lib.Text.Trim() == "")
            {
                tb_des_lib.Focus();
                return "Debes proporcionar la Descripción de la Libreta";
            }
            

            return null;
        }







    }
}
