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

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO BUSCA TALONARIO A
    /// </summary>
    public partial class adm004_01a : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        DataTable tab_adm004;
        DataTable tabla;
        string cod_doc;
        string nom_doc;

        #endregion

        #region INSTANCIAS

        c_adm004 o_adm004 = new c_adm004();

        #endregion

        #region EVENTOS

        public adm004_01a()
        {
            InitializeComponent();
        }

        private void adm004_01a_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_nro_tal_Validating(object sender, CancelEventArgs e)
        {
            fu_con_sel();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vg_frm_pad.fu_rec_tal(tb_cod_doc.Text, tb_nro_tal.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>
        public void fu_ini_frm(int va_tip_frm = 0)
        {
            cod_doc = vg_str_ucc.Rows[0]["va_cod_doc"].ToString();
            nom_doc = vg_str_ucc.Rows[0]["va_nom_doc"].ToString();

            this.TitleText = this.TitleText + " - (" + cod_doc + ") " + nom_doc;

            fu_bus_car(cod_doc, 1, "0");
        }
        
        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_cod_doc.Text=="")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }
            if (tb_nro_tal.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tabla = o_adm004._05(tb_cod_doc.Text,int.Parse(tb_nro_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_cod_doc.Text = tabla.Rows[0]["va_cod_doc"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_tal"].ToString();
            
        }

        ///// <summary>
        ///// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        ///// </summary>
        //public string fu_ver_dat()
        //{
        //    //Si aun existe
        //    tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
        //    if (tab_adm004.Rows.Count == 0)
        //    {
        //        return "El Talonario no se encuentra registrado";
        //    }

        //    return null;
        //}

        ///// <summary>
        /////-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitado)
        ///// </summary>
        //public string fu_ver_dat2()
        //{
        //    //Si aun existe
        //    tab_adm004 = o_adm004._05(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
        //    if (tab_adm004.Rows.Count == 0)
        //    {
        //        return "El Talonario no se encuentra registrado";
        //    }

        //    //Verifica estado del dato
        //    if (tab_adm004.Rows[0]["va_est_ado"].ToString() == "N")
        //    {
        //        return "El Talonario se encuentra Deshabilitado";
        //    }

        //    return null;
        //}
        
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_bus">Valor a ser buscado</param>
        /// <param name="prm_bus">parametro por el cual se buscará (1=codigo documento ;2=nombre documento ; 3=nombre talonario)</param>
        /// <param name="est_bus">Estado por el cual se buscará</param>

        public void fu_bus_car(string val_bus, int prm_bus, string est_bus)
        {
            int va_ind_ice = 0;
            string va_tip_num = "";

            dg_res_ult.Rows.Clear();

            tab_adm004 = o_adm004._01(0, val_bus, prm_bus, est_bus);

            foreach (DataRow row in tab_adm004.Rows)
            {
                switch (row["va_tip_num"].ToString())
                {
                    case "0":
                        va_tip_num = "Manual";
                        break;
                    case "1":
                        va_tip_num = "Automatico";
                        break;
                }


                dg_res_ult.Rows.Add(row["va_cod_doc"], row["va_nro_tal"], row["va_nom_tal"], va_tip_num, row["va_nro_aut"]);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

            if (va_ind_ice == 0)
            {
                tb_cod_doc.Text = "";
                tb_nro_tal.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_cod_doc.Text = tab_adm004.Rows[0]["va_cod_doc"].ToString();
                tb_nro_tal.Text = tab_adm004.Rows[0]["va_nro_tal"].ToString();
                lb_sel_ecc.Text = tab_adm004.Rows[0]["va_nom_tal"].ToString();
            }

        }

        /// <summary>
        ///-> Metodo para capturar la fila seleccionada por el Talonario
        /// </summary>
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count!=0)
            {
                tb_cod_doc.Text = dg_res_ult.SelectedRows[0].Cells["va_cod_doc"].Value.ToString();
                tb_nro_tal.Text = dg_res_ult.SelectedRows[0].Cells["va_nro_tal"].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_tal"].Value.ToString();
            }  
        }


        #endregion

        
    }
}
