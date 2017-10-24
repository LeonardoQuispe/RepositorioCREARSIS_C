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

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO CONSULTA TALONARIO
    /// </summary>
    public partial class adm004_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        DataTable tab_adm003;

        #endregion

        #region INSTANCIAS

        c_adm003 o_adm003 = new c_adm003();

        #endregion

        #region EVENTOS

        public adm004_05()
        {
            InitializeComponent();
        }

        private void adm004_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
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

        #endregion

    }
}
