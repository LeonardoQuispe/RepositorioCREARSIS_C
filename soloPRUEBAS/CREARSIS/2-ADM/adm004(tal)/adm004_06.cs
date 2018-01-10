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
using System.Transactions;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO ELIMINA TALONARIO
    /// </summary>
    public partial class adm004_06 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm003;
        DataTable tab_adm004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();
       
        #endregion

        #region EVENTOS

        public adm004_06()
        {
            InitializeComponent();
        }

        private void adm004_06_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tra_nsa = new TransactionScope())
                {



                    err_msg = fu_ver_dat();
                    if (err_msg != null)
                    {
                        MessageBoxEx.Show(err_msg, "Error Elimina talonario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    DialogResult res_msg = new DialogResult();
                    res_msg = MessageBoxEx.Show("Estas seguro de Eliminar el talonario ?", "Elimina talonario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (res_msg == DialogResult.Cancel)
                    {
                        return;
                    }

                    //Graba datos Elimina TALONARIO
                    o_adm004._06(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));

                    //Graba datos Elimina NUMERACIONES DEL TALONARIO
                    o_adm005._06(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));

                    tra_nsa.Complete();
                    tra_nsa.Dispose();
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Elimina Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_bus_car(vg_frm_pad.tb_val_bus.Text, vg_frm_pad.cb_prm_bus.SelectedIndex, vg_frm_pad.cb_est_bus.SelectedIndex.ToString());
                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Elimina talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region MÉTODOS

        public void fu_ini_frm()
        {
            tb_cod_doc.Text = vg_str_ucc.Rows[0]["va_cod_doc"].ToString();
            fu_rec_doc(tb_cod_doc.Text);

            tb_nro_tal.Text = vg_str_ucc.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = vg_str_ucc.Rows[0]["va_nom_tal"].ToString();

            cb_tip_num.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_num"].ToString());

            //switch (vg_str_ucc.Rows[0]["va_tip_num"].ToString())
            //{
            //    case 0:
            //        cb_tip_num.SelectedIndex = 0;
            //        break;
            //    case 1:
            //        cb_tip_num.SelectedIndex = 1;
            //        break;
            //}

            tb_for_mat.Text = vg_str_ucc.Rows[0]["va_for_mat"].ToString();

            //cb_nro_cop.SelectedItem = vg_str_ucc.Rows[0]["va_nro_cop"].ToString();


            cb_nro_cop.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_nro_cop"].ToString());

            //switch (vg_str_ucc.Rows[0]["va_nro_cop"].ToString())
            //{
            //    case 0:
            //        cb_nro_cop.SelectedIndex = 0;
            //        break;
            //    case 1:
            //        cb_nro_cop.SelectedIndex = 1;
            //        break;
            //    case 2:
            //        cb_nro_cop.SelectedIndex = 2;
            //        break;
            //    case 3:
            //        cb_nro_cop.SelectedIndex = 3;

            //        break;
            //}
            tb_nro_aut.Text = vg_str_ucc.Rows[0]["va_nro_aut"].ToString();

            cb_for_log.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_for_log"].ToString());

            //switch (vg_str_ucc.Rows[0]["va_for_log"].ToString())
            //{
            //    case 0:
            //        cb_for_log.SelectedIndex = 0;
            //        break;
            //    case 1:
            //        cb_for_log.SelectedIndex = 1;
            //        break;
            //}

            tb_fir_ma1.Text = vg_str_ucc.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = vg_str_ucc.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = vg_str_ucc.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = vg_str_ucc.Rows[0]["va_fir_ma4"].ToString();


            switch (vg_str_ucc.Rows[0]["va_est_ado"].ToString())
            {
                case "H":
                    tb_est_ado.Text = "Habilitado";
                    break;
                case "N":
                    tb_est_ado.Text = "Deshabilitado";
                    break;
            }

            tb_nom_tal.Focus();

        }

        public void fu_rec_doc(string cod_doc)
        {
            if (cod_doc.Trim() == "")
            {
                tb_nom_doc.Text = "** NO existe";
                return;
            }

            tab_adm003 = o_adm003._05(cod_doc);
            if (tab_adm003.Rows.Count == 0)
            {
                tb_nom_doc.Text = "** NO existe";
                return;
            }

            tb_cod_doc.Text = cod_doc;
            tb_nom_doc.Text = tab_adm003.Rows[0]["va_nom_doc"].ToString();

        }

        public string fu_ver_dat()
        {
            //** Verifica Documento---------------------------------
            if (tb_cod_doc.Text.Trim() == "")
            {
                return "Debes proporcionar el codigo de documento";
            }

            tab_adm003 = o_adm003._05(tb_cod_doc.Text);
            if (tab_adm003.Rows.Count == 0)
            {
                return "El documento NO se encuentra registrado";
            }
            if (tab_adm003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                return "El documento se encuentra Deshabilitado";
            }
            //**-----------------------------------------------------

            //**Verifica Talonario-----------------------------------
            

            tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
            if (tab_adm004.Rows.Count == 0)
            {
                return "El Talonario ya NO se encuentra registrado";
            }

            if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "H")
            {
                return "El Talonario se encuentra Habilitado";
            }

            //**-----------------------------------------------------

            //**Verifica si el talonario tiene datos relacionados---- 
            //  (operaciones realizadas con el talonario)

            if (tab_adm004.Rows[0]["va_ban_dat"].ToString() == "1")
            {
                return "Existen operaciones registradas relacionadas con el talonario del documento.";
            }

            //**-----------------------------------------------------

            return null;
        }

        #endregion

        
    }
}
