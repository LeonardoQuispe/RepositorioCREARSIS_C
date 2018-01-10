﻿using System;
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


namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO ACTUALIZA NUMERACION
    /// </summary>
    public partial class adm005_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm002;
        DataTable tab_adm003;
        DataTable tab_adm004;
        DataTable tab_adm005;
        DataTable tab_aux;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_adm002 o_adm002 = new c_adm002();
        c_adm003 o_adm003 = new c_adm003();
        c_adm004 o_adm004 = new c_adm004();
        c_adm005 o_adm005 = new c_adm005();

        #endregion

        #region EVENTOS

        public adm005_03()
        {
            InitializeComponent();
        }

        private void adm005_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza numeración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Actualiza numeración", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos NUMERACION
                o_adm005._03(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text), Convert.ToInt32(tb_cod_ges.Text), Convert.ToInt32(tb_nro_ini.Text), Convert.ToInt32(tb_nro_fin.Text), tb_fec_ini.Value, tb_fec_fin.Value, Convert.ToInt32(tb_con_tad.Text));
                vg_frm_pad.fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_cod_ges.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Actualiza Numeración", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_nro_tal.Text, tb_cod_doc.Text, tb_cod_ges.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Actualiza numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region METODOS

        public void fu_ini_frm()
        {

            tb_cod_doc.Text = vg_str_ucc.Rows[0]["va_cod_doc"].ToString();

            fu_rec_doc(tb_cod_doc.Text);

            tb_nro_tal.Text = vg_str_ucc.Rows[0]["va_nro_tal"].ToString();
            fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);
            tb_cod_ges.Text = vg_str_ucc.Rows[0]["va_cod_ges"].ToString();
            tb_nro_ini.Text = vg_str_ucc.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = vg_str_ucc.Rows[0]["va_nro_fin"].ToString();
            tb_fec_ini.Text = vg_str_ucc.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = vg_str_ucc.Rows[0]["va_fec_fin"].ToString();
            tb_con_tad.Text = vg_str_ucc.Rows[0]["va_con_tad"].ToString();

            tb_nro_ini.Focus();

        }

        public void fu_tab_aux()
        {
            // Creamos el objeto DataTable
            tab_aux = new DataTable("vg_str_ucc");

            // Creamos una nueva columna
            //Dim dc As New DataColumn("va_cod_doc", Type.GetType("System.Decimal"))

            // Añadimos la columna al objeto DataTable
            tab_aux.Columns.Add(new DataColumn("va_cod_doc"));
            tab_aux.Columns.Add(new DataColumn("va_nom_doc"));

            // Creamos una nueva fila
            DataRow gri_fil = tab_aux.NewRow();

            // Le Asignamos un valor a la columna Precio
            {
                var o_va_cod_doc = gri_fil["va_cod_doc"];
                o_va_cod_doc = tb_cod_doc.Text;
                var o_va_nom_doc = gri_fil["va_nom_doc"];
                o_va_nom_doc = tb_nom_doc.Text;
            }

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
            if (o_mg_glo_bal.fg_val_num(tb_nro_tal.Text) == false)
            {
                tb_nro_tal.Focus();
                return "El Nro de talonario debe ser Numerico";
            }

            tab_adm004 = o_adm004._05(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text));
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

            
            //**Verifica que la gestion sea valida-------------------
            if (o_mg_glo_bal.fg_val_num(tb_cod_ges.Text) == false)
            {
                tb_cod_ges.Focus();
                return "La Gestion debe tener un valor Numerico";
            }

            tab_adm002 = o_adm002._05(Convert.ToInt32(tb_cod_ges.Text));
            if (tab_adm002.Rows.Count == 0)
            {
                tb_cod_ges.Focus();
                return "La Gestión NO se encuentra registrada";
            }
            //**-----------------------------------------------------

            //**Verifica Numero inicial y fianl----------------------
            if (o_mg_glo_bal.fg_val_num(tb_nro_ini.Text) == false)
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser numerico";
            }

            if (o_mg_glo_bal.fg_val_num(tb_nro_fin.Text) == false)
            {
                tb_nro_fin.Focus();
                return "El Número final debe ser numerico";
            }
            

            if (tb_nro_ini.Text.Trim()=="0")
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser Mayor a cero";
            }

            if (Convert.ToInt32(tb_nro_ini.Text.Trim()) > Convert.ToInt32(tb_nro_fin.Text.Trim()))
            {
                tb_nro_ini.Focus();
                return "El Número inicial debe ser Menor al Número final";
            }
            //**-----------------------------------------------------

            //**Verifica contador------------------------------------


                if (o_mg_glo_bal.fg_val_num(tb_con_tad.Text) == false)
                {
                    tb_con_tad.Focus();
                    return "El Contador debe ser numerico";
                }

                if (Convert.ToInt32(tb_con_tad.Text.Trim()) < Convert.ToInt32(tb_nro_ini.Text.Trim()))
                {
                    tb_con_tad.Focus();
                    return "El Contador debe ser mayor al numero inicial.";
                }

                if (Convert.ToInt32(tb_con_tad.Text.Trim()) > Convert.ToInt32(tb_nro_fin.Text.Trim()))
                {
                    tb_con_tad.Focus();
                    return "El Contador debe ser menor al numero final.";
                }
            

            //**Verifica Fecha inicial y final-----------------------
            
            if ((tb_fec_fin.Value - tb_fec_ini.Value).Days < 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }
            tab_adm002 = o_adm002._05(Convert.ToInt32(tb_cod_ges.Text), 1);
            
            if ((tb_fec_ini.Value - Convert.ToDateTime(tab_adm002.Rows[0]["va_fec_ini"].ToString())).Days < 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial No pertenece a una fecha valida para la gestion";
            }


            tab_adm002 = o_adm002._05(Convert.ToInt32(tb_cod_ges.Text), 12);
            
            if ((Convert.ToDateTime(tab_adm002.Rows[0]["va_fec_fin"].ToString()) - tb_fec_fin.Value).Days < 0)
            {
                tb_fec_ini.Focus();
                return "La fecha Final No pertenece a una fecha valida para la gestion";
            }

            //**-----------------------------------------------------

            //**Verifica Numeracion----------------------------------
            tab_adm005 = o_adm005._05(tb_cod_doc.Text, Convert.ToInt32(tb_nro_tal.Text), Convert.ToInt32(tb_cod_ges.Text));
            if (tab_adm005.Rows.Count == 0)
            {
                tb_nro_tal.Focus();
                return "La numeración NO se encuentra registrada";
            }

            return null;
        }

        public void fu_rec_doc(string cod_doc)
        {
            tb_nro_tal.Clear();
            tb_nom_tal.Clear();

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

        public void fu_rec_tal(string cod_doc, string nro_tal)
        {
            if (cod_doc.Trim() == "")
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

            tab_adm004 = o_adm004._05(cod_doc, Convert.ToInt32(nro_tal));
            if (tab_adm004.Rows.Count == 0)
            {
                tb_nom_tal.Text = "** NO existe";
                return;
            }

            tb_nro_tal.Text = tab_adm004.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = tab_adm004.Rows[0]["va_nom_tal"].ToString();
        }
        #endregion
      
    }
}
