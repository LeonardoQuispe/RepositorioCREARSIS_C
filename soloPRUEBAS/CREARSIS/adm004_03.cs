using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERNCIAS
using DATOS.ADM;
using System.Transactions;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO ACTUALIZA TALONARIO
    /// </summary>
    public partial class adm004_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm003;
        DataTable tab_adm004;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm002 o_adm002 = new c_adm002();
        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();

        #endregion

        #region EVENTOS

        public adm004_03()
        {
            InitializeComponent();
        }

        private void adm004_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Actualiza talonario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza talonario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }


                using (TransactionScope tra_nsa = new TransactionScope())
                {
                    //Graba datos TALONARIO
                    o_adm004._03(tb_cod_doc.Text, tb_nro_tal.Text, tb_nom_tal.Text, cb_tip_num.SelectedIndex, tb_nro_aut.Text, int.Parse(tb_for_mat.Text), cb_nro_cop.SelectedIndex, tb_fir_ma1.Text, tb_fir_ma2.Text, tb_fir_ma3.Text,
                    tb_fir_ma4.Text, cb_for_log.SelectedIndex);

                    tra_nsa.Complete();
                    tra_nsa.Dispose();
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_nom_tal.Text);
                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            cb_nro_cop.SelectedItem = vg_str_ucc.Rows[0]["va_nro_cop"].ToString();


            cb_nro_cop.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_nro_cop"].ToString());


            //switch (vg_str_ucc.Rows[0]["va_nro_cop"].ToString())
            //{
            //    case "0":
            //        cb_nro_cop.SelectedIndex = 0;
            //        break;
            //    case "1":
            //        cb_nro_cop.SelectedIndex = 1;
            //        break;
            //    case "2":
            //        cb_nro_cop.SelectedIndex = 2;
            //        break;
            //    case "3":
            //        cb_nro_cop.SelectedIndex = 3;

            //        break;
            //}

            tb_nro_aut.Text = vg_str_ucc.Rows[0]["va_nro_aut"].ToString();

            cb_for_log.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_for_log"].ToString());

            //switch (vg_str_ucc.Rows(0).Item("va_for_log"))
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

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            int tmp;

            //** Verifica Documento---------------------------------
            if (tb_cod_doc.Text.Trim() == "")
            {
                tb_cod_doc.Focus();
                return "Debes proporcionar el codigo de documento";
            }

            tab_adm003 = o_adm003._05(tb_cod_doc.Text);
            if (tab_adm003.Rows.Count == 0)
            {
                tb_cod_doc.Focus();
                return "El documento NO se encuentra registrado";
            }
            if (tab_adm003.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_doc.Focus();
                return "El documento se encuentra Deshabilitado";
            }
            //**-----------------------------------------------------

            //**Verifica Talonario-----------------------------------
            if (int.TryParse(tb_nro_tal.Text.Trim(), out tmp) == false)
            {
                tb_nro_tal.Focus();
                return "El Nro de talonario NO es valido";
            }

            tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
            if (tab_adm004.Rows.Count == 0)
            {
                tb_nro_tal.Focus();
                return "El Talonario ya NO se encuentra registrado";
            }
            //**-----------------------------------------------------

            //**Verifica formato-------------------------------------
            if (int.TryParse(tb_for_mat.Text.Trim(), out tmp) == false)
            {
                tb_for_mat.Focus();
                return "El formato debe ser numerico";
            }
            //**-----------------------------------------------------

            //**Verifica Nro de Autorizacion-------------------------
            if (int.TryParse(tb_nro_aut.Text.Trim(), out tmp) == false)
            {
                tb_nro_aut.Focus();
                return "El Nro de autorización debe ser numerico";
            }

            if (tb_nro_aut.Text.Trim() != "")
            {
                //Verifica existetncia del Nro de autorizacion

            }
            //**-----------------------------------------------------

            return null;
        }

        #endregion        
    }
}
