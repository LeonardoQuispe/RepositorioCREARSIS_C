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

namespace CREARSIS._4_INV.inv016_com_pra_
{
    public partial class inv016_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        DataTable tab_ecp005;
        DataTable tab_inv011;
        DataTable tab_adm010;
        DataTable tab_in002;

        #endregion

        #region INSTANCIAS

        DATOS._7_ECP.c_ecp005 o_ecp005 = new DATOS._7_ECP.c_ecp005();
        c_inv011 o_inv011 = new c_inv011();
        c_adm010 o_adm010 = new c_adm010();
        DATOS._4_INV.c_inv002 o_inv002 = new DATOS._4_INV.c_inv002();

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion
        public inv016_02()
        {
            InitializeComponent();
        }

        private void cb_tip_cmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_tip_cmp.SelectedIndex==0)
            {
                this.Width = 1000;
            }
            else
            {
                this.Width = 704;
            }
        }

        private void inv016_02_Load(object sender, EventArgs e)
        {
            this.Width = 704;
        }

        private void tb_nom_alm_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_add_itm_Click(object sender, EventArgs e)
        {
            string prueba = "";
        }
    }
}