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
using System.Transactions;
using DevComponents.DotNetBar;
using CREARSIS.GLOBAL;


namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO NUEVO TALONARIO
    /// </summary>
    public partial class adm004_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm002;
        DataTable tab_adm003;
        DataTable tab_adm004;
        DataTable tab_ctb007;

        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_adm002 o_adm002 = new c_adm002();
        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();
        c_ctb007 o_ctb007 = new c_ctb007();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region EVENTOS

        public adm004_02()
        {
            InitializeComponent();
        }

        private void adm004_02_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Nuevo talonario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo talonario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                using (TransactionScope tra_nsa = new TransactionScope())
                {
                    //Graba datos TALONARIO
                    o_adm004._02(tb_cod_doc.Text, tb_nro_tal.Text, tb_nom_tal.Text, cb_tip_num.SelectedIndex, tb_nro_aut.Text,int.Parse(tb_for_mat.Text), cb_nro_cop.SelectedIndex, tb_fir_ma1.Text, tb_fir_ma2.Text, tb_fir_ma3.Text,
                    tb_fir_ma4.Text, cb_for_log.SelectedIndex);


                    //Graba datos NUMERACIONES
                    DateTime fec_ini;
                    DateTime fec_fin;
                    int prd_ini = 0;

                    //obtener periodo inicial de la gestion
                    tab_adm002 = o_adm002._05(int.Parse(tb_cod_ges.Text), 1);
                    prd_ini = Convert.ToDateTime(tab_adm002.Rows[0]["va_fec_ini"].ToString()).Month;

                    fec_ini = Convert.ToDateTime( "01/" + prd_ini + "/" + tb_cod_ges.Text);
                    fec_fin = fec_ini.AddYears(1);
                    fec_fin = fec_fin.AddDays(-1);

                    o_adm005._02(tb_cod_doc.Text,int.Parse( tb_nro_tal.Text),int.Parse( tb_cod_ges.Text), 0, 99999, fec_ini, fec_fin, 0);                    

                    tra_nsa.Complete();
                    tra_nsa.Dispose();
                }

                //Actualiza la grilla de busqueda en la ventana padre
                vg_frm_pad.fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_nom_tal.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_cod_doc_ButtonCustomClick(object sender, EventArgs e)
        {
            adm003_01 obj = new adm003_01();

            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_doc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Up)
            {
                adm003_01 obj = new adm003_01();

                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_doc_Validated(object sender, EventArgs e)
        {
            fu_rec_doc(tb_cod_doc.Text);
        }

        private void tb_nro_dos_ButtonCustomClick(object sender, EventArgs e)
        {
            ctb007_01 obj = new ctb007_01();

            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_nro_dos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                ctb007_01 obj = new ctb007_01();

                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_nro_dos_Validated(object sender, EventArgs e)
        {
            fu_rec_dos(tb_nro_aut.Text);
        }



        #endregion

        #region MÉTODOS

        public void fu_ini_frm()
        {
            cb_tip_num.SelectedIndex = 0;
            tb_for_mat.Text = "0";
            cb_nro_cop.SelectedIndex = 0;
            //tb_nro_dos.Text = "0";
            cb_for_log.SelectedIndex = 0;

            tb_cod_doc.Focus();

        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_doc.Clear();
            tb_nom_doc.Clear();
            tb_nro_tal.Clear();
            tb_nom_tal.Clear();
            tb_cod_ges.Clear();
            tb_for_mat.Text = "0";
            tb_nro_aut.Clear();
            tb_fir_ma1.Clear();
            tb_fir_ma2.Clear();
            tb_fir_ma3.Clear();
            tb_fir_ma4.Clear();

            tb_nro_tal.Focus();

        }
        
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            int tmp;
            Int64 tmp2;

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
                return "El Nro de Talonario debe ser numérico";
            }

            if (tb_nro_tal.Text=="0")
            {
                tb_nro_tal.Focus();
                return "El Nro de Talonario debe ser diferente de 0";
            }

            tab_adm004 = o_adm004._05(tb_cod_doc.Text,int.Parse( tb_nro_tal.Text));
            if (tab_adm004.Rows.Count!=0)
            {
                tb_nro_tal.Focus();
                return "El Talonario ya se encuentra registrado";
            }
            //**-----------------------------------------------------

            //**Verifica que la gestion sea valida-------------------
            if (int.TryParse(tb_cod_ges.Text.Trim(), out tmp) == false)
            {
                tb_cod_ges.Focus();
                return "La Gestion no es valida";
            }

                tab_adm002 = o_adm002._05(int.Parse( tb_cod_ges.Text));
            if (tab_adm002.Rows.Count == 0)
            {
                tb_cod_ges.Focus();
                return "La Gestión NO se encuentra registrada";
            }
            //**-----------------------------------------------------

            //**Verifica formato-------------------------------------
            if (int.TryParse(tb_for_mat.Text.Trim(), out tmp) == false)
            {
                tb_for_mat.Focus();
                return "El formato debe ser numerico";
            }
            //**-----------------------------------------------------

            //**Verifica Nro de Dosificacion-------------------------
            if (tb_cod_doc.Text.Trim() == "")
            {
                tb_cod_doc.Focus();
                return "Debes proporcionar el codigo de Dosificación";
            }
            
            tab_ctb007 = o_ctb007._05(Int64.Parse(tb_nro_aut.Text));
            if (tab_ctb007.Rows.Count == 0)
            {
                tb_nro_aut.Focus();
                return "La Dosificación NO se encuentra registrada";
            }
            if (tab_ctb007.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_nro_aut.Focus();
                return "La Dosificación se encuentra Deshabilitada";
            }
            if (Int64.TryParse(tb_nro_aut.Text.Trim(), out tmp2) == false)
            {
                tb_nro_aut.Focus();
                return "El Nro de Dosificación debe ser numérico";
            }

            if (tb_nro_aut.Text.Trim() == "0")
            {
                tb_nro_aut.Focus();
                return "El Nro de Dosificación debe ser diferente de 0";
            }           

            return null;
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

        public void fu_rec_dos(string cod_dos)
        {
            if (cod_dos.Trim() == "")
            {
                tb_nro_aut.Text = "** NO existe";
                return;
            }

            tab_ctb007 = o_ctb007._05(Int64.Parse(cod_dos));
            if (tab_ctb007.Rows.Count == 0)
            {
                tb_nro_aut.Text = "** NO existe";
                return;
            }

            tb_nro_aut.Text = cod_dos;

        }


        #endregion

        private void tb_cod_ges_TextChanged(object sender, EventArgs e)
        {
            tb_cod_ges.Text = o_mg_glo_bal.Valida_numeros(tb_cod_ges.Text);
        }

        private void tb_nro_tal_TextChanged(object sender, EventArgs e)
        {
            tb_nro_tal.Text = o_mg_glo_bal.Valida_numeros(tb_nro_tal.Text);
        }

        private void tb_nro_aut_TextChanged(object sender, EventArgs e)
        {
            tb_nro_aut.Text = o_mg_glo_bal.Valida_numeros(tb_nro_aut.Text);
        }
    }
}
