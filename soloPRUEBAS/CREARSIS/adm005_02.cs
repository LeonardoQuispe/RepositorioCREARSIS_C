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
    /// FORMULARIO NUEVA NUEMERACION
    /// </summary>
    public partial class adm005_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_adm002;
        DataTable tab_adm003;
        DataTable tab_adm004;
        DataTable tab_adm005;
        DataTable vg_str_ucc;
        string err_msg = "";
        string cod_doc_aux = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();     
        c_adm002 o_adm002 = new c_adm002();
        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();

        #endregion

        #region EVENTOS

        public adm005_02()
        {
            InitializeComponent();
        }

        private void adm005_02_Load(object sender, EventArgs e)
        {
            tb_cod_doc.GotFocus += tb_cod_doc_GotFocus;
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva numeración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva numeración", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos NUMERACION
                o_adm005._02(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text), Convert.ToInt32(tb_cod_ges.Text), Convert.ToInt32(tb_nro_ini.Text), Convert.ToInt32(tb_nro_fin.Text), tb_fec_ini.Value, tb_fec_fin.Value, 0);

                vg_frm_pad.fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_cod_ges.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Numeración", MessageBoxButtons.OK, MessageBoxIcon.Information);


                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tb_nro_tal_ButtonCustomClick(object sender, EventArgs e)
        {
            //Verifca que haya un documento seleccionado
                        
                if (tb_cod_doc.Text.Trim() == "")
                {
                    return;
                }

                fu_tab_aux();
                adm004_01a obj = new adm004_01a();
                o_mg_glo_bal.mg_ads000_03(obj, this, vg_str_ucc);
            
        }

        private void tb_nro_tal_KeyDown(object sender, KeyEventArgs e)
        {
            //Verifca que haya un documento seleccionado

            if (e.KeyData == Keys.Up)
            {
                fu_tab_aux();
                adm004_01a obj = new adm004_01a();
                o_mg_glo_bal.mg_ads000_03(obj, this, vg_str_ucc);
            }

        }

        private void tb_cod_doc_GotFocus(Object sender, EventArgs e)
        {

            cod_doc_aux = tb_cod_doc.Text;
        }

        private void tb_cod_doc_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Up)
            {
                adm003_01 obj = new adm003_01();
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        

        private void tb_cod_doc_Validating(object sender, CancelEventArgs e)
        {
            //busca el valor digitado y obtiene nombre
            fu_rec_doc(tb_cod_doc.Text);
        }

        private void tb_nro_tal_Validating(object sender, CancelEventArgs e)
        {
            //busca el valor digitado y obtiene nombre
            fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);
        }
        #endregion
        
        #region METODOS

        public void fu_ini_frm()
        {
            int nro_ini = 0;
            int nro_fin = 9999;
            tb_nro_ini.Text= nro_ini.ToString();
            tb_nro_fin.Text = nro_fin.ToString();

            tb_fec_ini.Value = DateTime.Now;
            tb_fec_fin.Value = DateTime.Now;

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

            tb_cod_doc.Focus();

        }

        public void fu_tab_aux()
        {
            // Creamos el objeto DataTable
            vg_str_ucc = new DataTable("vg_str_ucc");

            // Creamos una nueva columna
            //Dim dc As New DataColumn("va_cod_doc", Type.GetType("System.Decimal"))

            // Añadimos la columna al objeto DataTable
            vg_str_ucc.Columns.Add(new DataColumn("va_cod_doc"));
            vg_str_ucc.Columns.Add(new DataColumn("va_nom_doc"));

            // Creamos una nueva fila
            DataRow gri_fil = vg_str_ucc.NewRow();


            // Le Asignamos un valor a la columna Precio


            gri_fil["va_cod_doc"] = tb_cod_doc.Text;
            gri_fil["va_nom_doc"] = tb_nom_doc.Text;


            // Añadimos la fila al objeto DataTable
            vg_str_ucc.Rows.Add(gri_fil);
        }



        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
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
            int tmp;
            if (int.TryParse(tb_nro_tal.Text.Trim(), out tmp) == false)
            {
                tb_nro_tal.Focus();
                return "El Nro de talonario NO es valido";
            }

            tab_adm004 = o_adm004._05(tb_cod_doc.Text,Convert.ToInt32( tb_nro_tal.Text));
            if (tab_adm004.Rows.Count == 0)
            {
                tb_nro_tal.Focus();
                return "El Talonario NO se encuentra registrado";
            }

            if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_nro_tal.Focus();
                return "El Talonario se encuentra Deshabilitado";
            }
            //**-----------------------------------------------------

            //**Verifica Numeracion----------------------------------
            tab_adm005 = o_adm005._05(tb_cod_doc.Text,Convert.ToInt32( tb_nro_tal.Text),Convert.ToInt32( tb_cod_ges.Text));
            if (tab_adm005.Rows.Count!=0)
            {
                tb_nro_tal.Focus();
                return "La numeración para el Talonario ya se encuentra registrada";
            }
            //**Verifica que la gestion sea valida-------------------
            if (int.TryParse(tb_cod_ges.Text.Trim(), out tmp) == false)
            {
                tb_cod_ges.Focus();
                return "La Gestion no es valida";
            }

            tab_adm002 = o_adm002._05(Convert.ToInt32( tb_cod_ges.Text));
            if (tab_adm002.Rows.Count == 0)
            {
                tb_cod_ges.Focus();
                return "La Gestión NO se encuentra registrada";
            }
            //**-----------------------------------------------------

            //**Verifica Numero inicial y fianl----------------------
            if (int.TryParse(tb_nro_ini.Text.Trim(), out tmp) == false)
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser numerico";
            }

            if (int.TryParse(tb_nro_fin.Text.Trim(), out tmp) == false)
            {
                tb_nro_fin.Focus();
                return "El Número final debe ser numerico";
            }

            if (Convert.ToInt32( tb_nro_ini.Text.Trim()) < 0)
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser Mayor a cero";
            }

            if (Convert.ToInt32( tb_nro_ini.Text.Trim()) > Convert.ToInt32( tb_nro_fin.Text))
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser Menor al Número final";
            }
            //**-----------------------------------------------------

            //**Verifica Fecha inicial y final-----------------------

            TimeSpan ts = tb_fec_fin.Value - tb_fec_ini.Value;

            if (ts.Days < 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }
            tab_adm002 = o_adm002._05(Convert.ToInt32( tb_cod_ges.Text), 1);

            ts = tb_fec_ini.Value- Convert.ToDateTime(tab_adm002.Rows[0]["va_fec_ini"].ToString());

            if (ts.Days < 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial No pertenece a una fecha valida para la gestion";
            }


            tab_adm002 = o_adm002._05(Convert.ToInt32(tb_cod_ges.Text), 12);

            ts = Convert.ToDateTime(tab_adm002.Rows[0]["va_fec_fin"].ToString()) - tb_fec_fin.Value;

            if (ts.Days< 0)
            {
                tb_fec_ini.Focus();
                return "La fecha Final No pertenece a una fecha valida para la gestion";
            }

            //**-----------------------------------------------------

            return null;
        }

        public void fu_rec_doc(string cod_doc)
        {
            
            if (cod_doc_aux == cod_doc)
            {
                return;
            }

            tb_nro_tal.Clear();
            tb_nom_tal.Clear();

            if (cod_doc.Trim()=="")
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
            
            tb_cod_doc.Text = tab_adm003.Rows[0]["va_cod_doc"].ToString(); ;
            tb_nom_doc.Text = tab_adm003.Rows[0]["va_nom_doc"].ToString();
        }

        public void fu_rec_tal(string cod_doc, string nro_tal)
        {
            if (cod_doc.Trim()=="")
            {
                tb_nom_tal.Text = "** NO existe";
                return;
            }
            int tmp;
            if (int.TryParse(nro_tal.Trim(), out tmp) == false)
            {
                tb_nom_tal.Text = "** NO existe";
                return;
            }

            tab_adm004 = o_adm004._05(cod_doc,Convert.ToInt32( nro_tal));
            if (tab_adm004.Rows.Count == 0)
            {
                tb_nom_tal.Text = "** NO existe";
                return;
            }

            tb_nro_tal.Text = tab_adm004.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = tab_adm004.Rows[0]["va_nom_tal"].ToString();
        }

        #endregion

        private void tb_nro_tal_TextChanged(object sender, EventArgs e)
        {
            tb_nro_tal.Text = o_mg_glo_bal.valida_numeros(tb_nro_tal.Text);
        }

        private void tb_cod_ges_TextChanged(object sender, EventArgs e)
        {
            tb_cod_ges.Text = o_mg_glo_bal.valida_numeros(tb_cod_ges.Text);
        }

        private void tb_nro_ini_TextChanged(object sender, EventArgs e)
        {
            tb_nro_ini.Text = o_mg_glo_bal.valida_numeros(tb_nro_ini.Text);
        }

        private void tb_nro_fin_TextChanged(object sender, EventArgs e)
        {
            tb_nro_fin.Text = o_mg_glo_bal.valida_numeros(tb_nro_fin.Text);
        }
    }
}
