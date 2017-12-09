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
using DATOS;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class inv010_02 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_inv010;
        string err_msg = "";

        #endregion

        #region INSTANCIAS

        c_inv010 o_inv010 = new c_inv010();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region METODOS

        void fu_ini_frm()
        {
            tb_cod_sucu.Focus();
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        public void fu_lim_frm()
        {
            tb_cod_sucu.Clear();
            tb_cod_gru.Clear();
            tb_nom_gru.Focus();
            tb_nro_gru.Clear();
            tb_des_gru.Focus();
        }

        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        public string fu_ver_dat()
        {
            if (tb_cod_sucu.Text.Trim() == "")
            {
                tb_cod_sucu.Focus();
                return "Debes proporcionar el código de la Sucursal";
            }

            tab_inv010 = o_inv010._05(int.Parse( tb_cod_gru.Text));
            if (tab_inv010.Rows.Count != 0)
            {
                tb_cod_gru.Focus();
                return "El codigo del Grupo de Almacen ya se encuentra registrado";
            }

            if (tb_nom_gru.Text.Trim() == "")
            {
                tb_nom_gru.Focus();
                return "Debes proporcionar el nombre  del Grupo de Almacen";
            }

            return null;
        }
        void fu_bus_suc()
        {
            adm007_01 obj = new adm007_01();
            o_mg_glo_bal.mg_ads000_03(obj, this);
        }
        #endregion




        public inv010_02()
        {
            InitializeComponent();
        }
    }
}
