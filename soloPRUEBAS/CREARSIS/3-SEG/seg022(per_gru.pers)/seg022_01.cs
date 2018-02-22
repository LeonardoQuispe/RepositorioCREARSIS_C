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
using DevComponents.DotNetBar;
using System.Transactions;

namespace CREARSIS._3_SEG.seg022_per_gru.pers_
{
    public partial class seg022_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_seg022;
        DataTable tab_adm011;

        #endregion

        #region INSTANCIAS

        DATOS.c_seg022 o_seg022 = new DATOS.c_seg022();
        DATOS.c_adm011 o_adm011 = new DATOS.c_adm011();

        #endregion

        #region METODOS

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


            //CARGA DATAGRID con todos los Grupo de Personaes
            tab_adm011 = o_adm011._01("", 1, "0");
            if (tab_adm011.Rows.Count == 0)
            {
                return;
            }

            //Recupera todos los Grupo de Personaes sobre los que tiene permiso el USUARIO
            tab_seg022 = o_seg022._05(tb_cod_usr.Text.Trim());

            //recorre todos los Grupo de Personaes
            foreach (DataRow row in tab_adm011.Rows)
            {
                va_ban_aux = false;

                //valida los Grupo de Personaes a los que tiene permiso el usuario
                foreach (DataRow row2 in tab_seg022.Rows)
                {
                    if (row["va_cod_gru"].ToString() == row2["va_cod_gru"].ToString())
                    {
                        va_ban_aux = true;
                    }
                }


                dg_res_ult.Rows.Add(row["va_cod_gru"], row["va_nom_gru"], va_chk_per.Checked = va_ban_aux);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

        }

        #endregion

        #region EVENTOS

        public seg022_01()
        {
            InitializeComponent();
        }

        private void seg022_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Permiso Usuario sobre Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            //Iniciando Transacción
            using (TransactionScope tra_nsa = new TransactionScope())
            {
                //Elimina Permisos del Usuario
                o_seg022._06(tb_cod_usr.Text.Trim());

                //Guarda PERMISOS
                for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dg_res_ult.Rows[i].Cells["va_chk_per"].Value) == true)
                    {
                        o_seg022._02(tb_cod_usr.Text.Trim(), Convert.ToInt32(dg_res_ult.Rows[i].Cells["va_cod_gru"].Value));
                    }
                }

                tra_nsa.Complete();
                tra_nsa.Dispose();
            }



            MessageBoxEx.Show("Operación completada exitosamente", "Permiso Usuario sobre Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vg_frm_pad.fu_sel_fila(tb_cod_usr.Text);

            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
