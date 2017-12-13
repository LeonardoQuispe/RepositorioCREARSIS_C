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
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO BUSCA GESTION
    /// </summary>
    public partial class adm002_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES
        
        public dynamic vg_frm_pad;
        DataTable tabla;
        int temp;

        #endregion

        #region INSTANCIAS

        c_adm002 o_adm002 = new c_adm002();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region EVENTOS

        public adm002_01()
        {
            InitializeComponent();
        }

        private void adm002_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void cb_ges_tio_SelectedIndexChanged(object sender, EventArgs e)
        {
            fu_bus_car();
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                tb_ges_sel.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                tb_prd_sel.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                lb_des_sel.Text = dg_res_ult.SelectedRows[0].Cells[2].Value.ToString();
            }
        }


        private void tb_ges_sel_Validated(object sender, EventArgs e)
        {
            fu_con_sel();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        #endregion

        #region OPCIONES DE MENU

        //[MENU - Atras]
        private void mn_atr_atr_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }
        //[MENU - Nuevo]
        private void m_adm002_02_Click(object sender, EventArgs e)
        {
            //Solo permite crear la funcion para la primera vez
            DataTable tabla = o_adm002._05();
            if (tabla.Rows.Count == 0)
            {
                adm002_02 obj = new adm002_02();
                o_mg_glo_bal.mg_ads000_02(obj, this);
            }
            else
            {
                MessageBoxEx.Show("Ya existe una gestión creada, debe usar la opcion de: Prepara siguiente Gestión", "Nueva Gestión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //[MENU - Nueva gestión]
        private void m_adm002_02a_Click(object sender, EventArgs e)
        {
            DataTable tabla = o_adm002._05();

            if (tabla.Rows.Count != 0)
            {
                adm002_02a obj = new adm002_02a();
                o_mg_glo_bal.mg_ads000_02(obj, this);

                return;
            }
            else
            {
                MessageBoxEx.Show("No existe ninguna una gestión creada, debe usar la opcion de: Nueva Gestión", "Prepara siguente Gestión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //[MENU - Reporte adm002_p01]
        private void m_adm002_p01_Click(object sender, EventArgs e)
        {
            DataTable tabla = o_adm002._05();

            if (tabla.Rows.Count != 0)
            {
                adm002_01wp obj = new adm002_01wp();
                o_mg_glo_bal.mg_ads000_02(obj, this);

                return;
            }
            else
            {
                MessageBoxEx.Show("No existe ninguna una gestión creada, debe usar la opcion de: Nueva Gestión", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        #region METODOS

        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int ar_tip_frm = 0)
        {
            //Obtiene datos de gestion/periodo
            tabla = o_adm002._05();

            //Carga datos en el comboBox
            cb_ges_tio.DisplayMember = "va_cod_ges";
            cb_ges_tio.ValueMember = "va_cod_ges";
            cb_ges_tio.DataSource = tabla;

            //Funcion Buscar
            fu_bus_car();
        }

        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (int.TryParse(tb_ges_sel.Text, out temp) == false || tb_ges_sel.Text == "0")
            {
                lb_des_sel.Text = "** NO existe";
                return;
            }

            if (int.TryParse(tb_prd_sel.Text, out temp) == false || tb_prd_sel.Text == "0")
            {
                lb_des_sel.Text = "** NO existe";
                return;
            }

            tabla = o_adm002._05(Convert.ToInt32( tb_ges_sel.Text),Convert.ToInt32( tb_prd_sel.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_des_sel.Text = "** NO existe";
                return;
            }

            tb_ges_sel.Text = tabla.Rows[0]["va_cod_ges"].ToString();
            tb_prd_sel.Text = tabla.Rows[0]["va_prd_ges"].ToString();
            lb_des_sel.Text = tabla.Rows[0]["va_nom_prd"].ToString();

            if (lb_des_sel.Text != "** NO existe")
            {
                fu_sel_fila(tb_ges_sel.Text, tb_prd_sel.Text,lb_des_sel.Text);
            }
        }

        /// <summary>
        /// Metodo Buscar datos en pantalla
        /// </summary>
        public void fu_bus_car()
        {
            dg_res_ult.Rows.Clear();

            tabla = o_adm002._05(Convert.ToInt32(cb_ges_tio.SelectedValue));

            if (tabla.Rows.Count == 0)
            {
                MessageBoxEx.Show("** NO existen registros para la gestion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int va_ind_ice = 0;

            foreach (DataRow row in tabla.Rows)
            {
                dg_res_ult.Rows.Add(row["va_cod_ges"], row["va_prd_ges"], row["va_nom_prd"], row["va_fec_ini"], row["va_fec_fin"]);
                dg_res_ult.Rows[va_ind_ice].Tag = row;
                va_ind_ice = va_ind_ice + 1;
            }

            if (tabla.Rows.Count > 0)
            {
                tb_ges_sel.Text = tabla.Rows[0]["va_cod_ges"].ToString();
                tb_prd_sel.Text = tabla.Rows[0]["va_prd_ges"].ToString();
                lb_des_sel.Text = tabla.Rows[0]["va_nom_prd"].ToString();
            }
        }

        public void fu_sel_fila(string gest,string per,string nom_per)
        {           

            tb_ges_sel.Text = gest;
            tb_prd_sel.Text = per;
            lb_des_sel.Text = nom_per;

            if (gest != null)
            {         
                try
                {
                       for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                        {
                            if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == gest && dg_res_ult.Rows[i].Cells[1].Value.ToString() == per && dg_res_ult.Rows[i].Cells[2].Value.ToString() == nom_per)
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

        #endregion

        
    }
}
