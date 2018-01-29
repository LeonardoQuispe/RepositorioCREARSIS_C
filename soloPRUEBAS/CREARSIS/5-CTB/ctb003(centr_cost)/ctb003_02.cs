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
    public partial class ctb003_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        DataTable tab_ctb003;
        string err_msg = "";
        


        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_ctb003 o_ctb003 = new c_ctb003();

        public ctb003_02()
        {
            InitializeComponent();
        }

        private void ctb003_02_Load(object sender, EventArgs e)
        {

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Centro de Costos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                string va_tip_cct = "";

                if (int.Parse(tb_cod_cct.Text.Trim()) % 100 == 0)
                {
                    va_tip_cct = "M";
                }
                else
                {
                    va_tip_cct = "A";
                }

                //Graba datos
                o_ctb003._02(int.Parse(tb_cod_cct.Text.Trim()),tb_nom_cct.Text.Trim(),va_tip_cct);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_cct.Text.Trim());

                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }



        


        void fu_lim_frm()
        {
            tb_cod_cct.Clear();
            tb_nom_cct.Clear();

            tb_cod_cct.Focus();
        }

        string fu_ver_dat()
        {
            //Valida Código de Centro de Costos
            if (tb_cod_cct.Text.Trim() == "")
            {
                tb_cod_cct.Focus();
                return "Debes proporcionar el Código del Centro de Costos";
            }
            if (o_mg_glo_bal.fg_val_num(tb_cod_cct.Text) == false)
            {
                tb_cod_cct.Focus();
                return "El Código del Centro de Costos debe ser numérico";
            }
            if (int.Parse(tb_cod_cct.Text.Trim()) <= 0)
            {
                tb_cod_cct.Focus();
                return "El Código del Centro de Costos debe ser mayor a 0";
            }
            

            //Valida Nombre de Centro de Costos
            if (tb_nom_cct.Text.Trim() == "")
            {
                tb_nom_cct.Focus();
                return "Debes proporcionar el Nombre del Centro de Costos";
            }
            

            return null;
        }





    }
}
