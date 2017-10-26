﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS.ADM;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class ctb007_03 : DevComponents.DotNetBar.Metro.MetroForm
    {


        #region VARIABLES

        public dynamic vg_frm_pad;

        public DataTable vg_str_ucc;
        //** tabla Dosificacion
        DataTable tab_ctb007;
        //** tabla Leyendas
        DataTable tab_ctb006;
        //** tabla Sucursal
        DataTable tab_adm007;
        //** tabla Actividad economica
        DataTable tab_adm012;


        DataTable tabla;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        
        //** Clase Dosificacion
        c_ctb007 o_ctb007 = new c_ctb007();
        //** Clase Leyenda
        c_ctb006 o_ctb006 = new c_ctb006();
        //** Clase Sucursal
        c_adm007 o_adm007 = new c_adm007();
        //** Clase Actividad economica
        c_adm012 o_adm012 = new c_adm012();

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region EVENTOS

        public ctb007_03()
        {
            InitializeComponent();
        }

        private void ctb007_03_Load(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err_msg, "Error Actualiza Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = default(DialogResult);
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos ?", "Actualiza Dosificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_ctb007._03(int.Parse(tb_nro_dos.Text.Trim()), cb_tip_fac.SelectedIndex, int.Parse(tb_cod_sucu.Text.Trim()), int.Parse(tb_cod_act.Text.Trim()), int.Parse(tb_nro_ini.Text.Trim()), int.Parse(tb_nro_fin.Text.Trim()), tb_fec_ini.Value, tb_fec_fin.Value, int.Parse(tb_cod_ley.Text.Trim()));

                vg_frm_pad.fu_sel_fila(tb_nro_dos.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Close();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);

            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_cod_sucu_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_suc();
        }

        private void tb_cod_act_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_ace();
        }

        private void tb_cod_ley_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_ley();
        }

        private void tb_cod_sucu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                fu_bus_suc();
            }
        }

        private void tb_cod_act_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                fu_bus_ace();
            }
        }

        private void tb_cod_ley_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                fu_bus_ley();
            }
        }

        private void tb_cod_sucu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_cod_act_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_cod_ley_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        #region METODOS

        public void fu_ini_frm()
        {
            int cod_tpr = 0;
            //Obtiene parametros y muestra en pantalla
            if (vg_str_ucc.Rows.Count == 0)
            {
                return;
            }
            tb_nro_dos.Text = vg_str_ucc.Rows[0]["va_nro_dos"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(vg_str_ucc.Rows[0]["va_tip_fac"].ToString());

            tb_cod_sucu.Text = vg_str_ucc.Rows[0]["va_cod_suc"].ToString();
            tb_nom_sucu.Text = vg_str_ucc.Rows[0]["va_nom_suc"].ToString();
            tb_cod_act.Text = vg_str_ucc.Rows[0]["va_cod_act"].ToString();
            tb_nom_act.Text = vg_str_ucc.Rows[0]["va_nom_act"].ToString();
            tb_nro_ini.Text = vg_str_ucc.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = vg_str_ucc.Rows[0]["va_nro_fin"].ToString();
            tb_fec_ini.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_ini"].ToString());
            tb_fec_fin.Value = Convert.ToDateTime(vg_str_ucc.Rows[0]["va_fec_fin"].ToString());
            tb_cod_ley.Text = vg_str_ucc.Rows[0]["va_cod_ley"].ToString();
            tb_nom_ley.Text = vg_str_ucc.Rows[0]["va_nom_ley"].ToString();

            if (vg_str_ucc.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            else
            {
                tb_est_ado.Text = "Dehabilitado";
            }

        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            int tmp;

            try
            {
                //** Verifica nro de dosificacion
                if (tb_nro_dos.Text.Trim() == "")
                {
                    tb_nro_dos.Focus();
                    return "Debes proporcionar el número de Dosificación";
                }
                if (int.TryParse(tb_nro_dos.Text, out tmp) == false)
                {
                    tb_nro_dos.Focus();
                    return "Dato no valido, debe ser numerico el número de Dosificación";
                }

                tab_ctb007 = o_ctb007._05(tb_nro_dos.Text);
                if (tab_ctb007.Rows.Count > 0)
                {
                    return "La dosificación ya se encuentra registrada";
                }

                //** Verifica Sucursal
                if (tb_cod_sucu.Text.Trim() == "")
                {
                    tb_cod_sucu.Focus();
                    return "Debes seleccionar una Sucursal";
                }
                if (int.TryParse(tb_cod_sucu.Text, out tmp) == false)
                {
                    tb_cod_sucu.Focus();
                    return "Dato no valido, el codigo sucursal debe ser numerico ";
                }
                tab_adm007 = o_adm007._05(tb_cod_sucu.Text);
                if (tab_adm007.Rows.Count == 0)
                {
                    tb_cod_sucu.Focus();
                    return "La sucursal no se encuentra registrada";
                }

                if (tab_adm007.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    tb_cod_sucu.Focus();
                    return "La sucursal se encuentra Deshabilitada";
                }


                //** Verifica Actividad economica
                if (tb_cod_act.Text.Trim() == "")
                {
                    tb_cod_act.Focus();
                    return "Debes proporcionar la Actividad economica";
                }

                if (int.TryParse(tb_cod_act.Text, out tmp) == false)
                {
                    tb_cod_act.Focus();
                    return "Dato no valido, el codigo de la actividad debe ser numerico";
                }

                tab_adm012 = o_adm012._05(tb_cod_act.Text);
                if (tab_adm012.Rows.Count == 0)
                {
                    tb_cod_act.Focus();
                    return "La Actividad no se encuentra registrada";
                }

                if (tab_adm012.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    tb_cod_act.Focus();
                    return "La Actividad se encuentra Deshabilitada";
                }


                //** Verifica nro inicial y final 
                if (int.TryParse(tb_nro_ini.Text, out tmp) == false)
                {
                    tb_nro_ini.Focus();
                    return "Dato no valido, el número inicial debe ser numerico ";
                }
                if (int.TryParse(tb_nro_fin.Text, out tmp) == false)
                {
                    tb_nro_fin.Focus();
                    return "Dato no valido, el número final debe ser numerico ";
                }
                if (Convert.ToInt32(tb_nro_ini.Text) >= Convert.ToInt32(tb_nro_fin.Text))
                {
                    tb_nro_fin.Focus();
                    return "Dato no valido,el campo número final debe ser mayor que el número inicial";
                }


                TimeSpan ts = tb_fec_ini.Value - tb_fec_fin.Value;
                //** Verifica Fechas
                if (ts.Days <= 0)
                {
                    tb_fec_fin.Focus();
                    return "Dato no valido,el campo fecha final debe ser mayor que fecha inicial";
                }

                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        void fu_bus_suc()
        {
            adm007_01 obj = new adm007_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        void fu_bus_ace()
        {
            adm012_01 obj = new adm012_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        void fu_bus_ley()
        {
            ctb006_01 obj = new ctb006_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        #endregion
    }
}
