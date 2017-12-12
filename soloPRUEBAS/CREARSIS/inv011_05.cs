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
    public partial class inv011_05 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;


        c_inv011 o_inv011 = new c_inv011();

        public inv011_05()
        {
            InitializeComponent();
        }

        private void inv011_05_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }






        void fu_ini_frm()
        {
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }

            tb_gru_alm.Text = vg_str_ucc.Rows[0]["va_cod_gru"].ToString().PadLeft(4, '0');
            tb_nro_alm.Text = vg_str_ucc.Rows[0]["va_nro_alm"].ToString();
            tb_cod_alm.Text = vg_str_ucc.Rows[0]["va_cod_alm"].ToString().PadLeft(7, '0');
            tb_nom_alm.Text = vg_str_ucc.Rows[0]["va_nom_alm"].ToString();
            tb_des_alm.Text = vg_str_ucc.Rows[0]["va_des_alm"].ToString();
            tb_dir_alm.Text = vg_str_ucc.Rows[0]["va_dir_alm"].ToString();
            tb_cta_alm.Text = vg_str_ucc.Rows[0]["va_cta_alm"].ToString();
            dt_fec_ctr.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ctr"].ToString());
            tb_nom_ecg.Text = vg_str_ucc.Rows[0]["va_nom_ecg"].ToString();
            tb_tlf_ecg.Text = vg_str_ucc.Rows[0]["va_tlf_ecg"].ToString();
            tb_dir_ecg.Text = vg_str_ucc.Rows[0]["va_dir_ecg"].ToString();

            switch (vg_str_ucc.Rows[0]["va_mon_inv"].ToString())
            {
                case "B": cb_mon_inv.SelectedIndex = 0; break;
                case "U": cb_mon_inv.SelectedIndex = 1; break;
            }

            switch (vg_str_ucc.Rows[0]["va_mtd_cto"].ToString())
            {
                case "P": cb_mtd_cto.SelectedIndex = 0; break;
            }


            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Deshabilitado";
            }

            tb_nom_alm.Focus();
        }





    }
}
