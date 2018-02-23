using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS._5_CTB;
using DevComponents.DotNetBar;

namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    public partial class ctb004_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ctb004;
        DataTable tab_ctb002;
        int va_niv_lin = 0;
        string[] va_mat_cod;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_ctb004 o_ctb004 = new c_ctb004();
        c_ctb002 o_ctb002 = new c_ctb002();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            
            cb_tip_cta.SelectedItem = null;
            cb_uso_cta.SelectedIndex = 0;
            cb_mon_cta.SelectedIndex = 0;

            tb_cod_cta.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_cta.Text="00000000";
            tb_nom_cta.Clear();

            cb_tip_cta.SelectedIndex = 0;
            cb_uso_cta.SelectedIndex = 0;
            cb_mon_cta.SelectedIndex = 0;

            fu_val_cod();

            tb_cod_cta.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        string fu_ver_dat()
        {            
            va_mat_cod= new string[5];
            va_niv_lin = 0;

            fu_val_cod();

            //Valida Código de Cuenta
            if (tb_cod_cta.Text.Trim() == "")
            {
                tb_cod_cta.Focus();
                return "Debes proporcionar el codigo de Plan de Cuentas";
            }
            if (tb_cod_cta.Text.Length!=8)
            {
                tb_cod_cta.Focus();
                return "El codigo de Plan de Cuentas debe tener 8 números";
            }
            if (int.Parse(tb_cod_cta.Text.Trim()) == 0)
            {
                tb_cod_cta.Focus();
                return "El codigo de Plan de Cuentas debe ser mayor a cero";
            }            
            tab_ctb004 = o_ctb004._05(tb_cod_cta.Text);
            if (tab_ctb004.Rows.Count != 0)
            {
                tb_cod_cta.Focus();
                return "El codigo del Plan de Cuentas ya se encuentra registrado";
            }

            tab_ctb002 = o_ctb002._05(int.Parse(tb_cod_cta.Text[0].ToString()));    //Valida que el primer numero del codigo exista en un capitulo agrupador
            if (tab_ctb002.Rows.Count==0)
            {
                tb_cod_cta.Focus();
                return "El primer número del codigo del Plan de Cuentas debe estar  \n\r" +
                    "        registrado en el código de un Capítulo Agrupador ";
            }

            //Recupera los niveles del código
            va_mat_cod[0] = tb_cod_cta.Text.Substring(0, 1);    //1er Nivel
            va_mat_cod[1] = tb_cod_cta.Text.Substring(1, 1);    //2do Nivel
            va_mat_cod[2] = tb_cod_cta.Text.Substring(2, 1);    //3er Nivel
            va_mat_cod[3] = tb_cod_cta.Text.Substring(3, 2);    //4to Nivel
            va_mat_cod[4] = tb_cod_cta.Text.Substring(5, 3);    //5to Nivel

            for (int i = 0; i < va_mat_cod.Length; i++)
            {
                if (int.Parse(va_mat_cod[i])>0)
                {
                    va_niv_lin++;
                }
            }
            
            switch (va_niv_lin)
            {
                case 1:
                    if (int.Parse(tb_cod_cta.Text.Substring(1, 7)) != 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al primer nivel no tiene el formato correcto";
                    }
                    break;
                case 2:
                    if (int.Parse(tb_cod_cta.Text.Substring(2,6))!=0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al segundo nivel no tiene el formato correcto";
                    }
                    tab_ctb004 = o_ctb004._05(va_mat_cod[0].ToString() + ".0.0.00.000");
                    if (tab_ctb004.Rows.Count==0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al primer nivel no encuentra registrado";
                    }
                    if (tab_ctb004.Rows[0]["va_est_ado"].ToString()=="N")
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al primer nivel se encuentra Deshabilitado";
                    }
                    break;
                case 3:
                    if (int.Parse(tb_cod_cta.Text.Substring(3,5)) != 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al tercer nivel no tiene el formato correcto";
                    }
                    tab_ctb004 = o_ctb004._05(va_mat_cod[0].ToString()+"."+va_mat_cod[1].ToString() + ".0.00.000");
                    if (tab_ctb004.Rows.Count == 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al segundo nivel no encuentra registrado";
                    }
                    if (tab_ctb004.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al segundo nivel se encuentra Deshabilitado";
                    }
                    break;
                case 4:
                    if (int.Parse(tb_cod_cta.Text.Substring(5,3)) != 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al cuarto nivel no tiene el formato correcto";
                    }
                    tab_ctb004 = o_ctb004._05(va_mat_cod[0].ToString() + "."+ va_mat_cod[1].ToString() + "." + va_mat_cod[2].ToString() + ".00.000");
                    if (tab_ctb004.Rows.Count == 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al tercer nivel no encuentra registrado";
                    }
                    if (tab_ctb004.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al tercer nivel se encuentra Deshabilitado";
                    }
                    break;
                case 5:
                    tab_ctb004 = o_ctb004._05(va_mat_cod[0].ToString() + "." + va_mat_cod[1].ToString() + "." + va_mat_cod[2].ToString() + "." + va_mat_cod[3].ToString() + ".000");
                    if (tab_ctb004.Rows.Count == 0)
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al cuarto nivel no encuentra registrado";
                    }
                    if (tab_ctb004.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        tb_cod_cta.Focus();
                        return "El Plan de Cuentas al cuarto nivel se encuentra Deshabilitado";
                    }
                    break;
            }


            //Valida nombre de Cuenta
            if (tb_nom_cta.Text.Trim() == "")
            {
                tb_nom_cta.Focus();
                return "Debes proporcionar el nombre de Plan de Cuentas";
            }

            //Valida codigo valido
            if (cb_tip_cta.SelectedItem==null)
            {
                tb_nom_cta.Focus();
                return "El código del plan de cuentas es inválido";
            }

            return null;
        }

        /// <summary>
        /// Elige el tipo de plan de cuenta según al código
        /// </summary>
        void fu_val_cod()
        {
            if (tb_cod_cta.Text.Trim() != "")
            {
                if (tb_cod_cta.Text.Trim().Length == 8)
                {
                    if (int.Parse(tb_cod_cta.Text.Trim()) != 0)
                    {
                        if (int.Parse(tb_cod_cta.Text.Substring(5, 3)) > 0)
                        {
                            cb_tip_cta.SelectedIndex = 1;
                            return;
                        }
                        else
                        {
                            cb_tip_cta.SelectedIndex = 0;
                            return;
                        }
                    }
                }

            }

            cb_tip_cta.SelectedItem = null;
        }

        #endregion

        #region EVENTOS
        public ctb004_02()
        {
            InitializeComponent();
        }

        private void ctb004_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                string va_aux_cod = "";
                string va_aux_pad = "";
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nuevo Plan de Cuentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Arma el codigo del plan de cuentas
                va_aux_cod = tb_cod_cta.Text[0]+ "." + tb_cod_cta.Text[1] + "." + tb_cod_cta.Text[2] + "." + tb_cod_cta.Text[3].ToString()+ tb_cod_cta.Text[4].ToString() + "."
                            + tb_cod_cta.Text[5].ToString() + tb_cod_cta.Text[6].ToString() + tb_cod_cta.Text[7].ToString();

                //Arma el Código padre del pan de cuentas
                switch (va_niv_lin)
                {
                    case 2:va_aux_pad = va_mat_cod[0].ToString()+".0.0.00.000"; break;
                    case 3: va_aux_pad = va_mat_cod[0].ToString() +"."+ va_mat_cod[1].ToString() + ".0.00.000"; break;
                    case 4: va_aux_pad = va_mat_cod[0].ToString() + "." + va_mat_cod[1].ToString() + "." + va_mat_cod[2].ToString() + ".00.000"; break;
                    case 5: va_aux_pad = va_mat_cod[0].ToString() + "." + va_mat_cod[1].ToString() + "." + va_mat_cod[2].ToString() + "." + va_mat_cod[3].ToString() + ".000"; break;

                }


                //Graba datos
                o_ctb004._02(va_aux_cod, tb_nom_cta.Text, cb_tip_cta.SelectedIndex.ToString(),cb_uso_cta.SelectedIndex.ToString(), cb_mon_cta.SelectedIndex.ToString(),va_aux_pad);

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(va_aux_cod);
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nuevo Plan de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        private void tb_cod_cta_Validated(object sender, EventArgs e)
        {
            fu_val_cod();
        }

        
    }
}
