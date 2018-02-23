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
using CREARSIS._2_ADM.adm010_per_;
using DevComponents.DotNetBar;
using DATOS._9_CMP;

namespace CREARSIS._9_CMP.cmp001_com_pra_
{
    public partial class cmp001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";
        Boolean lLote ;
        int Sel_Fila=-1;
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

        #region METODOS
        //Selecciona Proveedor
        public void fu_rec_per(string cod_per)
        {

            if (cod_per.Trim() == "")
            {
                tb_cod_per.Text = "** NO existe";
                return;
            }

            tab_adm010 = o_adm010._05(cod_per);
            if (tab_adm010.Rows.Count == 0)
            {
                tb_cod_per.Text = "";
                tb_nom_per.Text = "** NO existe";
                return;
            }

            tb_cod_per.Text = tab_adm010.Rows[0]["va_cod_per"].ToString();
            tb_nom_per.Text = tab_adm010.Rows[0]["va_nom_com"].ToString();
        }
        //Selecciona Almacen
        public void fu_Sel_Alm(string _tb_cod_alm, string _tb_nom_alm)
            {
                if (_tb_cod_alm.Trim() != "")
                {
                    tb_cod_alm.Text = _tb_cod_alm;
                    tb_nom_alm.Text = _tb_nom_alm;
                }
            }
            //Selecciona Plan de pagos
            public void fu_sel_pla(string _tb_cod_pla, string _tb_nom_pla)
            {
                if (_tb_cod_pla.Trim() != "")
                {
                    tb_cod_pla.Text = _tb_cod_pla;
                    tb_nom_pla.Text = _tb_nom_pla;
                }
            }
            //Selecciona el Productos
            public void fu_rec_pro(string _tb_cod_pro, string _tb_nom_pro)
            {
                lLote = false;
                if (_tb_cod_pro.Trim() != "")
                {
                    tb_cod_pro.Text = _tb_cod_pro;
                    tb_nom_pro.Text = _tb_nom_pro;
                    DATOS._4_INV.c_inv002 objPro = new DATOS._4_INV.c_inv002();
                    DataTable dtpro = objPro._01(_tb_cod_pro, 1,"H");
                    if (dtpro.Rows.Count <= 0)
                    {
                        MessageBoxEx.Show("Producto No encontrado", "Error");
                    }
                    else
                    {
                       tb_cod_uni.Text = ((DataRow) dtpro.Rows[0])["va_und_cmp"].ToString();
                    if(Convert.ToInt16(((DataRow)dtpro.Rows[0])["va_ban_lot"])!=1)
                    { 
                        lLote = false;
                        tb_lot_pro.Visible = false;
                        tb_fec_ven.Visible = false;
                        lbl_lot_pro.Visible = false;
                        lb_fec_ven.Visible = false;
                    }
                    else
                    { 
                        lLote = true;
                        tb_lot_pro.Visible = true;
                        tb_fec_ven.Visible = true;
                        lbl_lot_pro.Visible = true;
                        lb_fec_ven.Visible = true ;
                    }
                }
                }
            }
            //Selecciona el Talonario
            public void fu_car_tal()
            {
                try
                {
                    c_adm004 objTal = new c_adm004();
                    DataTable dt_tal = objTal._01("CMP", "H");
                    cb_num_tal.DataSource = dt_tal;
                    cb_num_tal.DisplayMember = "va_nom_tal";
                    cb_num_tal.ValueMember = "va_nro_tal";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //Selecciona todas las sucursales
            public void fu_car_suc()
            {
                try
                {
                    c_adm007 objSuc = new c_adm007();
                    DataTable dt_suc = objSuc._01("%",1,"1");
                    cb_suc_urs.DataSource = dt_suc;
                    cb_suc_urs.DisplayMember = "va_nom_suc";
                    cb_suc_urs.ValueMember = "va_cod_suc";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        //Selecciona el Nro. del Documento
        public void fu_car_nro()
            {
                try
                {
                    c_adm005 objTal = new c_adm005();
                    DataTable dt_tal = objTal._01(tb_fec_cha.Value.Year ,Convert.ToInt16(cb_num_tal.SelectedValue),"CMP");
                    if (dt_tal.Rows.Count == 0)
                    {
                        MessageBoxEx.Show("Talonario en la Gestio NO encontrada", "Error");
                    }
                    else
                    {
                        tb_nro_doc.Text = (Convert.ToInt32( ((DataRow)dt_tal.Rows[0])["va_con_tad"]) + 1).ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //Limpia los campos, para agregar un nuevo Item
            private void fu_lim_pro()
            {
                tb_ite_pro.Text = "";
                tb_cod_pro.Text = "";
                tb_nom_pro.Text = "";
                tb_can_pro.Text = "0.00";
                tb_pre_pro.Text = "0.00";
                tb_tot_pro.Text = "0.00";
                cb_tip_com.SelectedText = "";
                tb_cod_uni.Text = "";
            }
            //Validación al agregar un nuevo Item
            private Boolean fu_val_pro()
            {
                if (tb_cod_alm.Text == "")
                {
                    MessageBox.Show("Almacén Inválido","Validación");
                    return false;
                }
                if (Convert.ToDecimal(tb_can_pro.Text) <= 0)
                {
                   MessageBox.Show("Cantidad Inválido", "Validación");
                    return false;
                }
                if (Convert.ToDecimal(tb_pre_pro.Text) <= 0)
                {
                    MessageBox.Show("Precio Inválido", "Validación");
                    return false;
                }
                if (lLote && tb_lot_pro.Text=="" )
                {
                    MessageBox.Show("Digite el nro. de Lote", "Validación");
                    return false;
                }
                if (cb_tip_cmp.SelectedItem   == null )
                {
                    MessageBox.Show("Seleccione un Tipo de Compra", "Validación");
                    return false;
                }
            return true;
            }
            private void fu_asi_val(int fila,int nro_item)
            {
                dg_res_ult["va_ite_pro", fila].Value = nro_item.ToString();
                dg_res_ult["va_cod_pro", fila].Value = tb_cod_pro.Text;
                dg_res_ult["va_des_pro", fila].Value = tb_nom_pro.Text;
                dg_res_ult["va_cod_uni", fila].Value = tb_cod_uni.Text;
                dg_res_ult["va_can_pro", fila].Value = String.Format("{0:#,0.00}", Convert.ToDecimal(tb_can_pro.Text));
                dg_res_ult["va_can_pro", fila].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dg_res_ult["va_pre_pro", fila].Value = String.Format("{0:#,0.00}", Convert.ToDecimal(tb_pre_pro.Text));
                dg_res_ult["va_pre_pro", fila].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dg_res_ult["va_tot_pro", fila].Value = String.Format("{0:#,0.00}", Convert.ToDecimal(tb_tot_pro.Text));
                dg_res_ult["va_tot_pro", fila].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dg_res_ult["va_alm_pro", fila].Value = tb_cod_alm.Text;
                if (cb_tip_cmp.SelectedIndex > 0)
                    dg_res_ult["va_tip_com", fila].Value = cb_tip_cmp.SelectedItem.ToString();
                else
                    dg_res_ult["va_tip_com", fila].Value = cb_tip_com.SelectedItem.ToString();

                if (lLote)
                {                   
                    dg_res_ult["va_fec_ven", fila].Value = tb_fec_ven.Text;
                }
                dg_res_ult["va_lot_pro", fila].Value = tb_lot_pro.Text;
        }
            //Carga un Item al GridView
            private void fu_car_gri()
            {
                try
                {
                    int nro_item = 0;
                    if (tb_ite_pro.Text == "")
                    {
                        if (dg_res_ult.RowCount == 0)
                            nro_item++;
                        else
                        {
                            nro_item = (Convert.ToInt32(dg_res_ult[0, dg_res_ult.RowCount - 1].Value) + 1);
                        }
                        dg_res_ult.Rows.Add(1);
                        fu_asi_val(dg_res_ult.RowCount - 1, nro_item);
                        fu_lim_pro();
                    }
                    else
                    {
                        fu_asi_val(Sel_Fila, Convert.ToInt32(tb_ite_pro.Text));
                    }
                    Sel_Fila = -1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private void fu_cal_tot()
            {
                int item = 0;
                for (item = 0; item <= dg_res_ult.RowCount - 1; item++)
                {
                    tb_tot_bru.Text =String.Format("{0:#,0.00}",(Convert.ToDecimal(tb_tot_bru.Text) + Convert.ToDecimal(dg_res_ult["va_tot_pro",item].Value)));
                    if(dg_res_ult["va_tip_com", item].Value.ToString() == "Exento")
                        tb_tot_exe.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(tb_tot_exe.Text) + Convert.ToDecimal(dg_res_ult["va_tot_pro", item].Value)));
                    if (dg_res_ult["va_tip_com", item].Value.ToString() == "IVA")
                        tb_tot_suj.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(tb_tot_suj.Text) + Convert.ToDecimal(dg_res_ult["va_tot_pro", item].Value)));
                }
                if (Convert.ToDecimal(tb_tot_suj.Text) > 0)
                    tb_tot_imp.Text =String.Format("{0:#,0.00}",( Convert.ToDecimal(tb_tot_suj.Text) * Convert.ToDecimal("0.13")));

                tb_tot_net.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(tb_tot_bru.Text) - Convert.ToDecimal(tb_tot_des.Text)));
            }

        private bool fu_gra_bar()
        {
            try
            {
                c_cmp001 oCmp001 = new c_cmp001();
                
                oCmp001.va_cod_alm = Convert.ToInt32(tb_cod_alm.Text);
                oCmp001.va_cod_ctr = tb_cod_con.Text;
                oCmp001.va_cod_doc = tb_cod_doc.Text;

                oCmp001.va_cod_ges = tb_fec_cha.Value.Year;
                oCmp001.va_cod_prv = tb_cod_per.Text;
                oCmp001.va_cod_suc = Convert.ToInt16(cb_suc_urs.SelectedValue);
                oCmp001.va_des_cmp = Convert.ToDecimal(tb_tot_des.Text);
                oCmp001.va_emp_cod = 0;
                oCmp001.va_est_ado = "H";
                oCmp001.va_fec_cmp = DateTime.Now;
                oCmp001.va_fec_emi = tb_fec_cha.Value;
                oCmp001.va_fom_pag = (cb_for_pag.SelectedIndex +1).ToString();
                if(cb_mon_eda.SelectedIndex==0)
                    oCmp001.va_mon_eda = "B" ;
                else
                    oCmp001.va_mon_eda = "D";
                oCmp001.va_nit_fac = Convert.ToInt16(tb_nit_prv.Text);
                oCmp001.va_nro_aut = tb_nro_aut.Text;
                oCmp001.va_nro_doc = Convert.ToInt16(tb_nro_doc.Text);
                oCmp001.va_nro_fac = Convert.ToInt16(tb_nro_fac.Text);
                oCmp001.va_nro_tal = Convert.ToInt16(cb_num_tal.SelectedValue);
                oCmp001.va_obs_cmp = tb_com_ent.Text;
                if(tb_cod_pla.Text =="")
                    oCmp001.va_pla_pag = 0;
                else 
                    oCmp001.va_pla_pag = Convert.ToInt16(tb_cod_pla.Text);
                oCmp001.va_raz_fac = tb_raz_soc.Text;
                if (cb_tip_cmp.SelectedIndex  ==2 || cb_tip_cmp.SelectedIndex == 3)
                {
                    oCmp001.va_rie_alq = 0;
                    oCmp001.va_rim_itr = 0;
                    oCmp001.va_riu_bie = 0;
                    oCmp001.va_riu_ser = 0;
                }
                else
                {
                    oCmp001.va_rie_alq = 0;
                    oCmp001.va_rim_itr = 0;
                    oCmp001.va_riu_bie = 0;
                    oCmp001.va_riu_ser = 0;
                }
                oCmp001.va_tip_cam = Convert.ToDecimal(tb_tip_cam.Text);
                oCmp001.va_tip_cmp = ((DevComponents.Editors.ComboItem) cb_tip_cmp.SelectedItem).Value.ToString();
                oCmp001.va_tot_bru = Convert.ToDecimal(tb_tot_bru.Text);
                oCmp001.va_tot_exe = Convert.ToDecimal(tb_tot_exe.Text);
                oCmp001.va_tot_imp = Convert.ToDecimal(tb_tot_imp.Text);
                oCmp001.va_tot_net = Convert.ToDecimal(tb_tot_net.Text);
                oCmp001.va_tot_suj = Convert.ToDecimal(tb_tot_suj.Text);

                int nroFila;
                for (nroFila = 0; nroFila <= dg_res_ult.RowCount - 1; nroFila++)
                {
                    c_cmp001a item = new c_cmp001a();
                    item.va_can_pro = Convert.ToDecimal( dg_res_ult["va_can_pro", nroFila].Value);
                    item.va_cod_alm = Convert.ToInt32(dg_res_ult["va_alm_pro", nroFila].Value);
                    item.va_cod_pro = dg_res_ult["va_cod_pro", nroFila].Value.ToString();
                    item.va_cod_uni = dg_res_ult["va_cod_uni", nroFila].Value.ToString();
                    item.va_lot_cod = dg_res_ult["va_lot_pro", nroFila].Value.ToString();
                    if (item.va_lot_cod =="")
                        item.va_fec_ven = Convert.ToDateTime("01/01/1900");
                    else
                        item.va_fec_ven = Convert.ToDateTime( dg_res_ult["va_fec_ven", nroFila].Value);
                    item.va_imp_tot = Convert.ToDecimal(dg_res_ult["va_tot_pro", nroFila].Value);
                    item.va_nom_pro = dg_res_ult["va_des_pro", nroFila].Value.ToString();
                    item.va_nro_itm = Convert.ToInt16(dg_res_ult["va_ite_pro", nroFila].Value);
                    item.va_pre_uni = Convert.ToDecimal(dg_res_ult["va_pre_pro", nroFila].Value);
                    item.va_tip_cmp = dg_res_ult["va_tip_com", nroFila].Value.ToString();
                    oCmp001.lisItem.Add(item);
                }

                if (!oCmp001.fu_reg_cmp())
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
        public cmp001_02()
        {
            InitializeComponent();
        }

        private void cb_tip_cmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_tip_cmp.SelectedIndex==0)
            {
                this.Width = 1170;
                cb_tip_com.Visible = true;
                lb_tip_com.Visible= true;
                cb_tip_com.SelectedIndex = 0;
            }
            else
            {
                lb_tip_com.Visible = false ;
                cb_tip_com.Visible = false;
                this.Width = 910;
                tb_nro_fac.Text = "0";
                tb_nit_prv.Text = "0";
            }
        }

        private void inv016_02_Load(object sender, EventArgs e)
        {
            try
            {
                this.Width = 910;
                fu_car_tal();
                fu_car_nro();
                fu_car_suc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void tb_nom_alm_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_add_itm_Click(object sender, EventArgs e)
        {
            if (fu_val_pro())
            {
                fu_car_gri();
                fu_cal_tot();
            }
        }

        private void tb_cod_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                adm010_01a obj = new adm010_01a(false,true);
                o_mg_glo_bal.mg_ads000_03(obj, this);
            }
        }

        private void tb_cod_per_ButtonCustomClick(object sender, EventArgs e)
        {
            adm010_01a obj = new adm010_01a(false,true);
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }

        private void tb_cod_alm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                inv011_01 objAlm = new inv011_01();
                o_mg_glo_bal.mg_ads000_03(objAlm, this);
            }
        }

        private void tb_cod_alm_ButtonCustomClick(object sender, EventArgs e)
        {
            inv011_01 objAlm = new inv011_01();
            o_mg_glo_bal.mg_ads000_03(objAlm, this);
        }

        private void tb_cod_pla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                _7_ECP.ecp005_plan_de_pago_.ecp005_01 objPla = new _7_ECP.ecp005_plan_de_pago_.ecp005_01();
                o_mg_glo_bal.mg_ads000_03(objPla, this);
            }
        }

        private void tb_cod_pla_ButtonCustomClick(object sender, EventArgs e)
        {
            _7_ECP.ecp005_plan_de_pago_.ecp005_01  objPla = new _7_ECP.ecp005_plan_de_pago_.ecp005_01();
            o_mg_glo_bal.mg_ads000_03(objPla, this);
        }

        private void tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                _4_INV.inv002_pro_.inv002_01a objPro = new _4_INV.inv002_pro_.inv002_01a(false,true);
                o_mg_glo_bal.mg_ads000_03(objPro, this);
            }
        }

        private void tb_cod_pro_ButtonCustomClick(object sender, EventArgs e)
        {
            _4_INV.inv002_pro_.inv002_01a objPro = new _4_INV.inv002_pro_.inv002_01a(false,true);
            o_mg_glo_bal.mg_ads000_03(objPro, this);
        }

        private void cb_num_tal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(tb_nro_doc.Text !="")
                    fu_car_nro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_mon_eda.SelectedIndex == 0)
                    tb_tip_cam.Text = "1.00";
                else
                { 
                    c_adm013 objTipo = new c_adm013();
                    DataTable dtTipo= objTipo._05(tb_fec_cha.Value.ToShortDateString());
                    if (dtTipo.Rows.Count == 0)
                    {
                        tb_tip_cam.Text = "0.00";
                        MessageBox.Show("Fecha Seleccionada sin Tipo de Cambio", "Error");
                    }
                    else
                    {
                        tb_tip_cam.Text = ((DataRow)dtTipo.Rows[0])["va_val_bus"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void tb_fec_cha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_mon_eda.SelectedIndex == 0)
                    tb_tip_cam.Text = "1.00";
                else
                {
                    c_adm013 objTipo = new c_adm013();
                    DataTable dtTipo = objTipo._05(tb_fec_cha.Value.ToShortDateString());
                    if (dtTipo.Rows.Count == 0)
                    {
                        tb_tip_cam.Text = "0.00";
                        MessageBox.Show("Fecha Seleccionada sin Tipo de Cambio", "Error");
                    }
                    else
                    {
                        tb_tip_cam.Text = ((DataRow)dtTipo.Rows[0])["va_val_bus"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_for_pag.SelectedIndex == 0)
            {
                lb_pla_pag.Visible = false;
                tb_cod_pla.Visible = false;
                tb_nom_pla.Visible = false;
            }
            else
            {
                lb_pla_pag.Visible = true;
                tb_cod_pla.Visible = true;
                tb_nom_pla.Visible = true;
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(tb_can_pro.Text ) > 0)
                if (Convert.ToDecimal(tb_pre_pro.Text ) > 0)
                    tb_tot_pro.Text = String.Format ("{0:#,0.00}", Math.Round (Convert.ToDecimal(tb_can_pro.Text ) * Convert.ToDecimal(tb_pre_pro.Text ),2));
        }

        private void dg_res_ult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void tb_can_pro_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(tb_can_pro.Text) > 0)
                if (Convert.ToDecimal(tb_pre_pro.Text) > 0)
                    tb_tot_pro.Text = String.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal(tb_can_pro.Text) * Convert.ToDecimal(tb_pre_pro.Text), 2));
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fu_lim_pro();
                Sel_Fila = e.RowIndex;
                tb_ite_pro.Text = dg_res_ult["va_ite_pro", e.RowIndex].Value.ToString();
                tb_cod_pro.Text= dg_res_ult["va_cod_pro", e.RowIndex].Value.ToString();
                 tb_nom_pro.Text= dg_res_ult["va_des_pro", e.RowIndex].Value.ToString();
                tb_cod_uni.Text = dg_res_ult["va_cod_uni", e.RowIndex].Value.ToString();
                tb_can_pro.Text= String.Format("{0:#,0.00}", Convert.ToDecimal(dg_res_ult["va_can_pro", e.RowIndex].Value));
                tb_pre_pro.Text= String.Format("{0:#,0.00}", Convert.ToDecimal(dg_res_ult["va_pre_pro", e.RowIndex].Value));
                tb_tot_pro.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dg_res_ult["va_tot_pro", e.RowIndex].Value ));
                cb_tip_cmp.SelectedItem = dg_res_ult["va_tip_com", e.RowIndex].Value;

                if (dg_res_ult["va_lot_pro", e.RowIndex].Value != null && dg_res_ult["va_lot_pro", e.RowIndex].Value.ToString()!="")
                {
                    tb_lot_pro.Text = dg_res_ult["va_lot_pro", e.RowIndex].Value.ToString();
                    if (dg_res_ult["va_fec_ven", e.RowIndex].Value == null)
                        tb_fec_ven.Value = DateTime.Now;
                    else
                        tb_fec_ven.Value = Convert.ToDateTime(dg_res_ult["va_fec_ven", e.RowIndex].Value.ToString());
                    
                    lLote = true;
                }
                else {
                    lLote = false;
                    tb_lot_pro.Text = "";
                    tb_fec_ven.Text = "";
                }
            }
        }

        private void bt_can_itm_Click(object sender, EventArgs e)
        {
            if (Sel_Fila >= 0)
            {
                fu_lim_pro();
                dg_res_ult.Rows.RemoveAt(Sel_Fila);
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }
                    
                
                if(fu_gra_bar())
                    MessageBoxEx.Show("Operación completada exitosamente", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
       
        }
    }
}
