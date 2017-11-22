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
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv004_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable c_inv004;
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        //c_inv004 o_inv004 = new c_inv004();

        #endregion
        #region METODOS

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            if(va_tip_frm==1)
            {
                bt_ace_pta.Enabled = false;
                bt_can_cel.Enabled = false;
            }
            if (va_tip_frm == 2)
            {
                bt_ace_pta.Enabled = true;
                bt_can_cel.Enabled = true;
            }
            cb_prm_bus.SelectedIndex = 0;

            fu_bus_car(tb_val_bus.Text,cb_prm_bus.SelectedIndex);

        }
        public void fu_bus_car(string va_tex_bus, int va_par_ame)
        {
            try
            {
                //tabla = o_inv004._01(va_tex_bus, va_par_ame);

                if (tabla.Rows.Count == 0)
                {
                    dg_res_ult.Rows.Clear();
                    tb_sel_ecc.Text = null;
                    lb_sel_ecc.Text = "**No Existe**";
                    return;
                }

                if (tabla.Rows.Count!=0)
                {
                    dg_res_ult.Rows.Clear();

                    for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                    {
                        dg_res_ult.Rows.Add();

                        dg_res_ult.Rows[i].Cells["va_cod_mar"].Value = tabla.Rows[i]["va_cod_mar"].ToString();
                        dg_res_ult.Rows[i].Cells["va_nom_mar"].Value = tabla.Rows[i]["va_nom_mar"].ToString();

                    }

                    tb_sel_ecc.Text = dg_res_ult.Rows[0].Cells["va_cod_mar"].Value.ToString();
                    lb_sel_ecc.Text = dg_res_ult.Rows[0].Cells["va_nom_mar"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error");
            }
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        public void fu_sel_fila(string cod_doc, string nom_doc)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex + 1);

            tb_sel_ecc.Text = cod_doc;
            lb_sel_ecc.Text = nom_doc;

            if (cod_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_doc && dg_res_ult.Rows[i].Cells[1].Value.ToString() == nom_doc)
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


           // tabla = o_inv003._05(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_sel_ecc.Text = "** NO existe";
                return;
            }

            tb_sel_ecc.Text = tabla.Rows[0]["va_cod_mar"].ToString();
            lb_sel_ecc.Text = tabla.Rows[0]["va_nom_mar"].ToString();

        }
        public void fu_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                lb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
            }

        }


        #endregion
        public inv004_01()
        {
            InitializeComponent();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fu_fil_act();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fu_fil_act();
        }

        private void inv004_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void tb_val_bus_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_car(tb_val_bus.Text, cb_prm_bus.SelectedIndex);
        }

        private void tb_val_bus_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_sel_ecc_Validated(object sender, EventArgs e)
        {
            fu_con_sel();

            if (lb_sel_ecc.Text != "** NO existe")
            {
                fu_sel_fila(tb_sel_ecc.Text, lb_sel_ecc.Text);
            }
        }
    }
}
