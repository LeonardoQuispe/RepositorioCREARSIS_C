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
    public partial class inv001_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv001;
        string err_msg = "";
        DataTable tabla;

        #endregion

        #region INSTANCIAS

        c_inv001 o_inv001 = new c_inv001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            cb_tip_fap.SelectedIndex = 0;
            tb_cod_fap.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_fap.Clear();
            tb_nom_fap.Clear();

            tb_cod_fap.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            err_msg = null;
            string codigo;
            string[] va_mat_cod;
            int va_niv_lin = 0;

            if (tb_cod_fap.Text.Trim() == "")
            {
                tb_cod_fap.Focus();
                return "Debes proporcionar el código de la Familia de producto";
            }
            if (tb_cod_fap.Text.Trim().Length !=6)
            {
                tb_cod_fap.Focus();
                return "Debe proporcionar un codigo valido para la familia de producto";
            }

            tab_inv001 = o_inv001._05(tb_cod_fap.Text);
            if (tab_inv001.Rows.Count != 0)
            {
                tb_cod_fap.Focus();
                return "El codigo de la Familia de producto ya se encuentra registrada";
            }

            if (tb_nom_fap.Text.Trim() == "")
            {
                tb_nom_fap.Focus();
                return "Debes proporcionar el nombre de la Familia de producto";
            }

            // aumentar guion 
            codigo = (tb_cod_fap.Text.Substring(0, 2) + ("-" + (tb_cod_fap.Text.Substring(2, 2) + ("-" + tb_cod_fap.Text.Substring(4, 2)))));
            va_mat_cod = codigo.Split('-');
            // 
            if (va_mat_cod[0] == "0")
            {
                err_msg = "Debe proporcionar un codigo valido para la familia de producto";
                return err_msg;
            }

            if ((va_mat_cod[1] == "0") && (int.Parse(va_mat_cod[2]) > 0))
            {
                err_msg = "Debe proporcionar un codigo valido para la familia de producto";
                return err_msg;
            }

            // identificar el nivel de la familia de productos a crear'
            for (int i = 0; (i<= (va_mat_cod.Length - 1)); i++)
            {
                if (int.Parse( va_mat_cod[i] )> 0)
                {
                    va_niv_lin = (va_niv_lin + 1);
                }

            }

            //  Identifica el nivel de la familia
            // Verificar que el tipo de la familia sea coherente con el nivel a crear
            switch (va_niv_lin)
            {
                case 1:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fap.SelectedIndex != 0)
                    {
                        err_msg = "La familia de producto debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia no existe
                    tabla = o_inv001._01(tb_cod_fap.Text,1,"T",2);
                    if (tabla.Rows.Count!=0)
                    {
                        err_msg = "La familia de producto ya se encuentra registrada";
                        return err_msg;
                    }

                    break;
                case 2:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fap.SelectedIndex != 0)
                    {
                        err_msg = "La familia de producto debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia al primer nivel si existe
                    tabla = o_inv001._01(va_mat_cod[0], 1,"T", 1);
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto a primer nivel no se encuentra registrada.";
                        return err_msg;
                    }

                    // verifica que la familia al segundo nivel no existe
                    tabla = o_inv001._01((va_mat_cod[0] + va_mat_cod[1]), 1, "T", 1);
                    if (tabla.Rows.Count!=0)
                    {
                        err_msg = "La familia de producto ya se encuentra registrada.";
                        return err_msg;
                    }

                    break;
                case 3:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fap.SelectedIndex== 0)
                    {
                        err_msg = "La familia de producto no debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia al primer nivel si existe
                    tabla = o_inv001._01(va_mat_cod[0], 1, "T", 1);
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto a primer nivel no se encuentra registrada.";
                        return err_msg;
                    }

                    // verifica que la familia al segundo nivel si existe
                    tabla = o_inv001._01((va_mat_cod[0] + va_mat_cod[1]), 1, "T", 1);
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto al segundo nivel no se encuentra registrada.";
                        return err_msg;
                    }

                    // verifica que la familia al tercer nivel no existe
                    tabla = o_inv001._01((va_mat_cod[0] + (va_mat_cod[1] + va_mat_cod[2])), 1, "T", 1);
                    if (tabla.Rows.Count!=0)
                    {
                        err_msg = "La familia de producto se encuentra registrada.";
                        return err_msg;
                    }

                    break;
            }

            return err_msg;
        }

        #endregion

        #region EVENTOS

        public inv001_02()
        {
            InitializeComponent();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult res_msg = new DialogResult();
                res_msg = MessageBoxEx.Show("Estas seguro de grabar los datos ?", "Nueva Familia de producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //Graba datos
                o_inv001._02(tb_cod_fap.Text.Trim(), tb_nom_fap.Text.Trim(), cb_tip_fap.SelectedIndex.ToString());

                MessageBoxEx.Show("Operación completada exitosamente", "Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vg_frm_pad.fu_sel_fila(tb_cod_fap.Text.Trim(), tb_nom_fap.Text.Trim());
                fu_lim_frm();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error Nueva Familia de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inv001_02_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
