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

using DevComponents.DotNetBar;
using System.Transactions;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO PREPARA SIGUIENTE GESTION
    /// </summary>
    public partial class adm002_02a : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tabla = new DataTable();

        #endregion

        #region INSTANCIAS

        c_adm002 o_adm002 = new c_adm002();
        c_adm005 o_ads008 = new c_adm005();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public adm002_02a()
        {
            InitializeComponent();
        }

        private void adm002_02a_Load(object sender, EventArgs e)
        {
            tabla = o_adm002._05();
           
            tb_ges_act.Text = tabla.Rows[0]["va_cod_ges"].ToString();
            tb_ges_nva.Text =Convert.ToString(Convert.ToInt32(tabla.Rows[0]["va_cod_ges"])+1);

            tb_ges_nva.Focus();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res_msg;

                string err_msg = null;
                err_msg = fu_ver_dat();

                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Gestion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                res_msg = MessageBoxEx.Show("Esta seguro de grabar los datos?", "Nueva Gestión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Dim a = DateAdd("M", 1, "01/" & 1 & "/" & tb_ges_nva.Text)  PARA QUE??? si no se usa

                //◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                //INICIALIZA TRANSACCION
                using (TransactionScope tra_nsa = new TransactionScope())
                {

                    //Prepara la siguiente gestion
                    for (int i = 1; i <= 12; i++)
                    {
                        DateTime fec_ini;
                        DateTime fec_fin;
                        fec_ini = Convert.ToDateTime("01/" + i.ToString() + "/" + tb_ges_nva.Text);
                        fec_fin = fec_ini;

                        fec_fin = fec_ini.AddMonths(1);
                        fec_ini = fec_ini.AddDays(-1);


                        o_adm002._02(int.Parse(tb_ges_nva.Text), i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), fec_ini, fec_fin);
                    }

                    //◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                    //Obtiene los documentos con sus numeraciones de la gestion pasada
                    tabla = o_ads008._01(int.Parse(tb_ges_act.Text), "%", 1);
                    if (tabla.Rows.Count != 0)
                    {
                        for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                        {
                            string cod_doc = null;
                            int nro_tal = 0;
                            DateTime fec_ini;
                            DateTime fec_fin;

                            cod_doc = tabla.Rows[i]["va_cod_doc"].ToString();
                            nro_tal = int.Parse(tabla.Rows[i]["va_nro_tal"].ToString());

                            fec_fin = Convert.ToDateTime(tabla.Rows[0]["va_fec_ini"].ToString()).AddYears(1);
                            fec_ini = Convert.ToDateTime(tabla.Rows[0]["va_fec_fin"].ToString()).AddYears(1);

                            if (o_ads008._05(cod_doc, nro_tal,int.Parse(tb_ges_nva.Text)).Rows.Count == 0)
                            {
                                o_ads008._02(cod_doc, nro_tal, int.Parse(tb_ges_nva.Text), 0, 9999, fec_ini, fec_fin, 0);
                            }

                        }
                    }

                    tra_nsa.Complete();
                    tra_nsa.Dispose();
                }

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Gestión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_ini_frm();
                Dispose();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Gestión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region MÉTODOS

        public string fu_ver_dat()
        {
            string err_msg = null;

            if (o_mg_glo_bal.fg_val_num(tb_ges_nva.Text) == false)
            {
                err_msg = "La gestion a crear no es correcta";
                return err_msg;
            }

            if (tb_ges_nva.Text.Trim() == "0")
            {
                err_msg = "La gestion a crear debe ser mayor a cero";
                return err_msg;
            }

            if (tb_ges_act.Text.Trim() == "0")
            {
                err_msg = "Debe de crear una gestion antes";
                return err_msg;
            }


            if (int.Parse(tb_ges_nva.Text.Trim()) != int.Parse(tb_ges_act.Text.Trim()) + 1)
            {
                err_msg = "La gestion a crear debe ser " + Convert.ToString(int.Parse(tb_ges_act.Text) + 1);
                return err_msg;
            }            

            return err_msg;
        }

        #endregion


    }
}
