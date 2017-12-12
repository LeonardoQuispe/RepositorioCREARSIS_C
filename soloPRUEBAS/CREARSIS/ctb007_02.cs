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
using DevComponents.DotNetBar;



namespace CREARSIS
{
    public partial class ctb007_02 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;

        //** tabla Dosificacion
        DataTable tab_ctb007;
        //** tabla Leyendas
        DataTable tab_ctb006;
        //** tabla Sucursal
        DataTable tab_adm007;
        //** tabla Actividad economica
        DataTable tab_adm012;
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

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public ctb007_02()
        {
            InitializeComponent();
        }

        private void ctb007_02_Load(object sender, EventArgs e)
        {
            this.cb_tip_fac.SelectedIndex = 0;
            tb_fec_ini.Value = System.DateTime.Now;
            tb_fec_fin.Value = tb_fec_ini.Value.AddDays(180);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("¿Estas seguro de grabar los datos?", "Nueva Dosificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_ctb007._02(Int64.Parse(tb_nro_dos.Text.Trim()), cb_tip_fac.SelectedIndex, int.Parse(tb_cod_sucu.Text.Trim()), int.Parse(tb_cod_act.Text.Trim()), int.Parse(tb_nro_ini.Text.Trim()), int.Parse(tb_nro_fin.Text.Trim()), tb_fec_ini.Value, tb_fec_fin.Value, int.Parse(tb_cod_ley.Text.Trim()));

                vg_frm_pad.fu_sel_fila(tb_nro_dos.Text);

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(cb_tip_fac.SelectedIndex == 0)
                {
                    MessageBoxEx.Show("Ha Registrado una Dosificación con Facturas emitidas por computadora, \r\n  no olvide Actualizar Llave, de lo contrario NO podrá registrar Facturas", "Nueva Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                tb_nro_dos.Clear();
                tb_cod_sucu.Clear();
                tb_nom_sucu.Clear();
                tb_cod_act.Clear();
                tb_nom_act.Clear();
                tb_nro_ini.Text = "1";
                tb_nro_fin.Text = "9999";
                tb_cod_ley.Clear();
                tb_nom_ley.Clear();                

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }        

        private void tb_nro_dos_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_nro_ini_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_nro_fin_KeyPress(object sender, KeyPressEventArgs e)
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
        private void tb_cod_sucu_Validated(object sender, EventArgs e)
        {
            fu_rec_suc(tb_cod_sucu.Text);
        }

        private void tb_cod_act_Validated(object sender, EventArgs e)
        {
            fu_rec_act(tb_cod_act.Text);
        }

        private void tb_cod_ley_Validated(object sender, EventArgs e)
        {
            fu_rec_ley(tb_cod_ley.Text);
        }

        private void tb_cod_sucu_TextChanged(object sender, EventArgs e)
        {
            tb_cod_sucu.Text = o_mg_glo_bal.valida_numeros(tb_cod_sucu.Text);
            tb_cod_sucu.Select(tb_cod_sucu.Text.Length, 0);
        }

        private void tb_cod_act_TextChanged(object sender, EventArgs e)
        {
            tb_cod_act.Text = o_mg_glo_bal.valida_numeros(tb_cod_act.Text);
            tb_cod_act.Select(tb_cod_act.Text.Length, 0);
        }

        private void tb_cod_ley_TextChanged(object sender, EventArgs e)
        {
            tb_cod_ley.Text = o_mg_glo_bal.valida_numeros(tb_cod_ley.Text);
            tb_cod_ley.Select(tb_cod_ley.Text.Length, 0);
        }

        private void tb_nro_dos_TextChanged(object sender, EventArgs e)
        {
            tb_nro_dos.Text = o_mg_glo_bal.valida_numeros(tb_nro_dos.Text);
            tb_nro_dos.Select(tb_nro_dos.Text.Length, 0);
        }


        #endregion

        #region METODOS

        public void fu_rec_act(string cod_act)
        {
            try
            {
                tb_cod_act.Text = cod_act;
                if (cod_act.Trim() == "")
                {
                    tb_nom_act.Text = "** NO existe";
                    return;
                }

                tab_adm012 = o_adm012._05(cod_act);
                if (tab_adm012.Rows.Count == 0)
                {
                    tb_nom_act.Text = "** NO existe";
                    return;
                }

                tb_cod_act.Text = cod_act;
                tb_nom_act.Text = tab_adm012.Rows[0]["va_nom_act"].ToString();


            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }

        }
        public void fu_rec_ley(string cod_ley)
        {
            try
            {
                if (cod_ley.Trim() == "")
                {
                    tb_nom_ley.Text = "** NO existe";
                    return;
                }

                tab_ctb006 = o_ctb006._01(cod_ley, 1);
                if (tab_ctb006.Rows.Count == 0)
                {
                    tb_nom_ley.Text = "** NO existe";
                    return;
                }

                tb_cod_ley.Text = cod_ley;
                tb_nom_ley.Text = tab_ctb006.Rows[0]["va_nom_ley"].ToString();


            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }

        }
        public void fu_rec_suc(string cod_suc)
        {
            try
            {
                if (cod_suc.Trim() == "")
                {
                    tb_nom_sucu.Text = "** NO existe";
                    return;
                }

                tab_adm007 = o_adm007._05(cod_suc);
                if (tab_adm007.Rows.Count == 0)
                {
                    tb_nom_sucu.Text = "** NO existe";
                    return;
                }

                tb_cod_sucu.Text = cod_suc;
                tb_nom_sucu.Text = tab_adm007.Rows[0]["va_nom_suc"].ToString();


            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
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
                if (tb_nro_dos.Text == "0")
                {
                    tb_nro_dos.Focus();
                    return "El Nro de Dosificación NO es valido";
                }              


                //** Verifica Sucursal
                if (tb_cod_sucu.Text.Trim() == "")
                {
                    tb_cod_sucu.Focus();
                    return "Debes seleccionar una Sucursal";
                }

                if (tb_nom_sucu.Text== "** NO existe")
                {
                    tb_cod_sucu.Focus();
                    return "La Sucursal no Existe";
                }
                


                //** Verifica Actividad economica
                if (tb_cod_act.Text.Trim() == "")
                {
                    tb_cod_act.Focus();
                    return "Debes proporcionar la Actividad economica";
                }

                if (tb_nom_act.Text.Trim() == "** NO existe")
                {
                    tb_cod_act.Focus();
                    return "La Actividad Económica no Existe";
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
                
                //** Verifica Fechas
                if ((tb_fec_fin.Value-tb_fec_ini.Value).Days <= 0)
                {
                    tb_fec_fin.Focus();
                    return "Dato no valido,el campo fecha final debe ser mayor que fecha inicial";
                }                

                //** Verifica LEYENDA
                if (tb_cod_ley.Text.Trim() == "")
                {
                    tb_cod_ley.Focus();
                    return "Debes proporcionar la Leyenda";
                }

                if (tb_nom_ley.Text.Trim() == "** NO existe")
                {
                    tb_cod_ley.Focus();
                    return "La Leyenda no Existe";
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
            o_mg_glo_bal.mg_ads000_03(obj,this);
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
