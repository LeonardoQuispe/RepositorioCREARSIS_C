using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._3_SEG;
using DATOS._6_CMR;
using DevComponents.DotNetBar;

namespace CREARSIS._3_SEG.seg024_per_ven_
{
    public partial class seg024_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_seg024;
        DataTable tab_cmr003;
        string err_msg = "";



        c_seg024 o_seg024 = new c_seg024();
        c_cmr003 o_cmr003 = new c_cmr003();

        public seg024_01()
        {
            InitializeComponent();
        }

        private void seg024_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Permiso Usuario sobre Vendedor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Elimina Permisos del Usuario
            o_seg024._06(tb_cod_usr.Text.Trim());

            //Guarda PERMISOS
            for (int i = 0; i < dg_res_ult.Rows.Count; i++)
            {
                if (va_chk_per.Checked==true)
                {
                    o_seg024._02(tb_cod_usr.Text.Trim(), Convert.ToInt32(dg_res_ult.Rows[i].Cells["va_cod_ven"].Value));
                }
            }
            

            MessageBoxEx.Show("Operación completada exitosamente", "Permiso Usuario sobre Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_usr.Text);

            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }









        void fu_ini_frm()
        {
            bool va_ban_aux;
            int va_ind_ice = 0;

            dg_res_ult.Rows.Clear();

            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            tb_cod_usr.Text = vg_str_ucc.Rows[0]["va_cod_usr"].ToString();
            tb_nom_usr.Text = vg_str_ucc.Rows[0]["va_nom_usr"].ToString();


            //CARGA DATAGRID con todos los vendedores
            tab_cmr003 = o_cmr003._01("", 1,"0");
            if (tab_cmr003.Rows.Count == 0)
            {
                return;
            }

            //Recupera todos los vendedores sobre los que tiene permiso el USUARIO
            tab_seg024 = o_seg024._05(tb_cod_usr.Text.Trim());
            
            //recorre todos los vendedores
            foreach (DataRow row in tab_cmr003.Rows)
            {
                va_ban_aux = false;

                //valida los vendedores a los que tiene permiso el usuario
                foreach (DataRow row2 in tab_seg024.Rows)
                {
                    if (row["va_cod_ven"].ToString()==row2["va_cod_ven"].ToString())
                    {
                        va_ban_aux = true;
                    }
                }
                

                dg_res_ult.Rows.Add(row["va_cod_ven"], row["va_nom_ven"], va_chk_per.Checked=va_ban_aux);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

        }

        
    }
}
