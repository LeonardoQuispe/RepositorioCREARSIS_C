using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using CREARSIS.GLOBAL;
using DATOS;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    public partial class inv011_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        DataTable tab_inv011;
        DataTable tabla;
        string vv_err_msg = "";



        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_inv011 o_inv011 = new c_inv011();
        

        public inv011_01()
        {
            InitializeComponent();
        }

        private void inv011_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }    
        

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_val_bus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //al presionar tecla para ABAJO
                if (e.KeyData == Keys.Down)
                {
                    if (dg_res_ult.CurrentRow.Index != dg_res_ult.Rows.Count - 1)
                    {
                        int fila = dg_res_ult.CurrentRow.Index + 1;
                        dg_res_ult.CurrentCell = dg_res_ult[0, fila];
                        fu_fil_act();

                    }
                }

                //al presionar tecla para ARRIBA
                if (e.KeyData == Keys.Up)
                {
                    if (dg_res_ult.CurrentRow.Index != 0)
                    {
                        int fila = dg_res_ult.CurrentRow.Index - 1;
                        dg_res_ult.CurrentCell = dg_res_ult[0, fila];
                        fu_fil_act();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //vg_frm_pad.fu_rec_tal(tb_cod_gru.Text, tb_nro_tal.Text);

            vg_frm_pad.Enabled = true;
            Close();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }





        
        //NUEVO
        private void m_inv011_02_Click(object sender, EventArgs e)
        {
            inv011_02 obj = new inv011_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        //ACTUALIZA
        private void m_inv011_03_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv011_03 obj = new inv011_03();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv011);
        }        

        //HABILITA/DESHABILITA
        private void m_inv011_04_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv011_04 obj = new inv011_04();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv011);
        }

        //CONSULTA
        private void m_inv011_05_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat2();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv011_05 obj = new inv011_05();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv011);
        }

        //ELIMINA
        private void m_inv011_06_Click(object sender, EventArgs e)
        {
            vv_err_msg = fu_ver_dat3();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inv011_06 obj = new inv011_06();
            o_mg_glo_bal.mg_ads000_02(obj, this, tab_inv011);
        }

        //ATRAS
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }









        public void fu_ini_frm()
        {
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);
            
        }
        public void fu_bus_car(string val_bus, int prm_bus, int est_bus)
        {
            int va_ind_ice = 0;
            string va_cod_alm = "";
            string va_est_ado = "";

            dg_res_ult.Rows.Clear();

            tab_inv011 = o_inv011._01(val_bus, prm_bus, est_bus.ToString());

            foreach (DataRow row in tab_inv011.Rows)
            {
                switch (row["va_est_ado"].ToString())
                {
                    case "H":
                        va_est_ado = "Habilitado";
                        break;
                    case "N":
                        va_est_ado = "Deshabilitado";
                        break;
                }

                //agregar ceros al inicio de los numeros con 3 digitos
                va_cod_alm = row["va_cod_alm"].ToString();

                if (row["va_cod_alm"].ToString().Length<7)
                {
                    va_cod_alm=va_cod_alm.PadLeft(7, '0');
                }

                dg_res_ult.Rows.Add(va_cod_alm,row["va_nom_alm"], row["va_dir_alm"],  row["va_fec_ctr"], row["va_nom_ecg"], va_est_ado);

                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

            if (va_ind_ice == 0)
            {
                tb_sel_ecc.Text = "";
                lb_sel_ecc.Text = "** NO existe";
            }

            if (va_ind_ice > 0)
            {
                tb_sel_ecc.Text = tab_inv011.Rows[0]["va_cod_alm"].ToString().PadLeft(7,'0');
                lb_sel_ecc.Text = tab_inv011.Rows[0]["va_nom_alm"].ToString();
            }

            tb_val_bus.Focus();
        }

        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_alm, string nom_alm)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1, cb_est_bus.SelectedIndex);

            tb_sel_ecc.Text = cod_alm;
            lb_sel_ecc.Text = nom_alm;

            if (cod_alm != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_alm && dg_res_ult.Rows[i].Cells[1].Value.ToString() == nom_alm)
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                            return;
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBoxEx.Show(ex.Message, "Error");
                }
            }
        }
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text == "")
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            int tmp;

            if (int.TryParse(tb_sel_ecc.Text, out tmp) == false)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }


            tabla = o_inv011._05(int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_alm"].ToString().PadLeft(7,'0');
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_alm"].ToString();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }

        }

        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }
        public string fu_ver_dat()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_inv011 = o_inv011._05(int.Parse(tb_sel_ecc.Text));
                if (tab_inv011.Rows.Count == 0)
                {
                    return "El Almacén no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_inv011.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Almacén se encuentra Deshabilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat2()
        {
            if (tb_sel_ecc.Text.Trim() != "")
            {
                //Si aun existe
                tab_inv011 = o_inv011._05(int.Parse(tb_sel_ecc.Text));
                if (tab_inv011.Rows.Count == 0)
                {
                    return "El Almacén no se encuentra registrado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }

        }
        public string fu_ver_dat3()
        {

            if (tb_sel_ecc.Text.Trim() != "")
            {
                ///Si aun existe
                tab_inv011 = o_inv011._05(int.Parse(tb_sel_ecc.Text));
                if (tab_inv011.Rows.Count == 0)
                {
                    return "El Almacén no se encuentra registrado";
                }

                //Verifica estado del dato
                if (tab_inv011.Rows[0]["va_est_ado"].ToString() == "H")
                {
                    return "El Almacén se encuentra Habilitado";
                }

                return null;
            }
            else
            {
                return "Ningún dato Seleccionado";
            }
        }

        
    }
}
