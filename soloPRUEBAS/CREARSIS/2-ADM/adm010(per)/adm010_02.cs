using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;

        public adm010_02()
        {
            InitializeComponent();
        }

        private void adm010_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }




        private void tb_cod_gru_ButtonCustomClick(object sender, EventArgs e)
        {

        }

        private void tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tb_cod_gru_Validated(object sender, EventArgs e)
        {

        }

        private void tb_nro_per_Validated(object sender, EventArgs e)
        {

        }

        private void chk_cli_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            if (chk_cli.Checked == true)
            {
                tab_cli.Visible = true;
            }
            else if (chk_cli.Checked == false)
            {
                tab_cli.Visible = false;
            }
        }

        private void chk_pro_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            if (chk_pro.Checked == true)
            {
                tab_prv.Visible = true;
            }
            else if (chk_pro.Checked == false)
            {
                tab_prv.Visible = false;
            }
        }

        private void chk_emp_CheckedChanged(object sender, EventArgs e)
        {
            //Oculta / muestra el panel correspondiente si está chekeado
            //if (chk_emp.Checked == true)
            //{
            //    tab_emp.Visible = true;
            //}
            //else if (chk_emp.Checked == false)
            //{
            //    tab_emp.Visible = false;
            //}
        }

















        void fu_ini_frm()
        {
            cb_tip_cam.SelectedIndex = 0;
            

        }

        
    }
}
