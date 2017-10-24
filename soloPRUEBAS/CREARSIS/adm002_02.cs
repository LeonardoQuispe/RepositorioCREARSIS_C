using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using System.Transactions;
using DevComponents.DotNetBar;
using DATOS.ADM;
using CREARSIS.GLOBAL;


namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO CREA NUEVA GESTION
    /// </summary>
    public partial class adm002_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tabla;
        int temp;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        c_adm002 o_adm002 = new c_adm002();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();

        #endregion

        #region EVENTOS

        public adm002_02()
        {
            InitializeComponent();
        }

        private void adm002_02_Load(object sender, EventArgs e)
        {
            try
            {                
                tb_ges_nva.Text = o_mg_glo_bal.fg_fec_act().Year.ToString();
                cb_ges_tio.SelectedIndex = 0;
                tb_ges_nva.Focus();               
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Nueva Gestión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res_msg = new DialogResult();

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

                //Dim a = DateAdd("M", 1, "01/" & 1 & "/" & tb_ges_nva.Text)   PARA QUE SI NO SE USA???

                //◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                //INICIALIZA TRANSACCION
                using (TransactionScope tra_nsa = new TransactionScope())
                {

                    //La gestion iniciara en el periodo seleccionado por el usuario
                    int prd_ini = 0;
                    prd_ini = Convert.ToInt32(cb_ges_tio.SelectedIndex + 1);

                    int ges_aux = 0;
                    ges_aux = Convert.ToInt32(tb_ges_nva.Text);

                    //Prepara la siguiente gestion
                    for (int i = 1; i <= 12; i++)
                    {
                        DateTime fec_ini;
                        DateTime fec_fin;

                        fec_ini = Convert.ToDateTime("01/" + prd_ini + "/" + ges_aux);

                        fec_fin = fec_ini;
                        fec_fin = fec_fin.AddMonths(1);
                        fec_fin = fec_fin.AddDays(-1);


                        o_adm002._02(int.Parse(tb_ges_nva.Text), i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(prd_ini), fec_ini, fec_fin);

                        if (prd_ini < 12)
                        {
                            prd_ini = prd_ini + 1;
                        }
                        else
                        {
                            prd_ini = 1;
                            ges_aux = ges_aux + 1;

                        }

                    }

                    //◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                    //PREPARA NUMERADORES PARA LA SIGUIENTE GESTION

                    //Al crear la primera gestion, crea los numeradores de todos los talonarios
                    //obtiene lista de talonarios
                    tabla = o_adm004._01(0, "%", 1, "H");

                    prd_ini = Convert.ToInt32(cb_ges_tio.SelectedIndex + 1);
                    ges_aux = int.Parse(tb_ges_nva.Text);

                    for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                    {
                        string cod_doc = null;
                        int nro_tal = 0;
                        DateTime fec_ini;
                        DateTime fec_fin;

                        cod_doc = tabla.Rows[i]["va_cod_doc"].ToString();
                        nro_tal = int.Parse(tabla.Rows[i]["va_nro_tal"].ToString());

                        fec_ini = Convert.ToDateTime("01/" + prd_ini + "/" + ges_aux);
                        fec_fin = fec_ini;

                        fec_fin.AddYears(1);
                        fec_fin.AddDays(-1);

                        //crea las numeraciones de los talonario existentes
                        o_adm005._02(cod_doc, nro_tal, int.Parse(tb_ges_nva.Text), 0, 9999, fec_ini, fec_fin, 0);
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

        #region  MÉTODOS

        public string fu_ver_dat()
        {
            string err_msg = null;
            

            if (int.TryParse(tb_ges_nva.Text.Trim(), out temp) == false)
            {
                err_msg = "La gestion a crear no es correcta";
                return err_msg;
            }

            if (tb_ges_nva.Text.Trim() == "0")
            {
                err_msg = "La gestion a crear debe ser mayor a cero";
                return err_msg;
            }
                        
            DateTime fec_act = o_mg_glo_bal.fg_fec_act();

            if (int.Parse(tb_ges_nva.Text.Trim()) <fec_act.Year-1 || int.Parse(tb_ges_nva.Text.Trim()) >fec_act.Year+1)
            {
                err_msg = "La gestion a crear debe estar en un rango entre " +Convert.ToString(fec_act.Year-1) + " y " +Convert.ToString( fec_act.Year+ 1);
                return err_msg;
            }

            tb_ges_nva.Focus();

            return err_msg;
        }

        #endregion
    }
}
