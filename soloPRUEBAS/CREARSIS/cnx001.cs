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
using DATOS.ADM;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO PROPORCIONA LICENCIA
    /// </summary>
    public partial class cnx001 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        DataTable tabla;
        string cadena = "";
        string clave = "";

        #endregion

        #region INSTANCIAS

        c_seg001 ob_usr_usr = new c_seg001();
        c_seg049 o_ads900 = new c_seg049();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region EVENTOS

        public cnx001()
        {
            InitializeComponent();
        }

        private void cnx001_Load(object sender, EventArgs e)
        {
            try
            {
                tb_bdo_bdo.Text = Program.gl_bdo_usr;
                tabla = o_ads900._01();

                string vv_lic_enc = "";
                DateTime vv_fec_cad;

                vv_lic_enc = tabla.Rows[0]["va_fec_fin"].ToString();

                //dEsencripta la fecha
                vv_fec_cad = o_mg_glo_bal.fg_dcr_lic(vv_lic_enc);

                Tb_fec_lic.Value = vv_fec_cad;
            }
            catch (Exception ex)
            {                
                MessageBoxEx.Show("A ocurrido un error al grabar los datos, comuníquese con su Ing. Sistemas " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void tb_pss_lic_ButtonCustomClick(object sender, EventArgs e)
        {
            // fu_obt_cla()
            clave = o_mg_glo_bal.fg_obt_cla();
            // clave = clave.ToUpper

            if (tb_pss_lic.Text == clave)
            {
                //cambia el icono a candado abierto
                tb_pss_lic.ButtonCustom.Symbol = sy_can_cer.Symbol;


                gb_lic_bdo.Enabled = true;
                bt_ace_pta.Enabled = true;
                Tb_fec_lic.Focus();

                tb_pss_lic.Enabled = false;
            }
            else
            {
                MessageBoxEx.Show("La Clave es incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                string vv_lic_enc = "";
                //LIcencia encriptada

                vv_lic_enc = o_mg_glo_bal.fg_gen_lic(Tb_fec_lic.Value, clave);

                //graba licencia encriptada
                o_ads900._03(vv_lic_enc);

                MessageBoxEx.Show("Se ah actualizado la licencia con exito", "Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Ah ocurrido un error al grabar los datos, comuniquese con su Ing. Sistemas " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion
    }

}
