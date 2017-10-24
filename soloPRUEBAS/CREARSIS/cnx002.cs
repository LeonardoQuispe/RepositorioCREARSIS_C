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
using DATOS.ADM;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO AUTENTICACION PERSONALIZACION DEL MENU
    /// </summary>
    public partial class cnx002 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tabla;
        string va_msg_err;
        string va_usr_usr;
        string va_pss_usr;
        string va_ser_ver;
        string va_bdo_usr;
        //Nombre del usuario
        string va_nom_usr;
        //Grupo usuario 1:Administrador ; 2:Supervisor ; 3:Normal
        int va_tip_usr;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_cnx000 o_c_cnx000 = new c_cnx000();
        c_seg001 o_ads005 = new c_seg001();
        c_seg049 o_ads900 = new c_seg049();

        #endregion

        #region EVENTOS

        public cnx002()
        {
            InitializeComponent();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_sel_usr_ButtonCustomClick(object sender, EventArgs e)
        {
            fu_bus_usr();
        }

        
        private void cnx002_Activated(object sender, EventArgs e)
        {
            o_mg_glo_bal.fg_mue_nap(this);
        }

        private void tb_sel_usr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                fu_bus_usr();
            }
        }

        private void tb_sel_usr_Validating(object sender, CancelEventArgs e)
        {
            fu_rec_usr(tb_sel_usr.Text);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (fu_con_bdo() == true)
            {
                o_mg_glo_bal.fg_per_mnu(tb_sel_usr.Text, vg_frm_pad);
                Close();
            }
        }

        private void cnx002_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_frm_pad.IsMdiContainer == true)
            {
                vg_frm_pad.Enabled = true;
                vg_frm_pad.Activate();
            }
            else
            {
                vg_frm_pad.MdiParent.Enabled = true;
                vg_frm_pad.MdiParent.Activate();
            }
        }
        #endregion

        #region METODOS

        void fu_bus_usr()
        {
            seg001_01 w_seg001_01 = new seg001_01();
            o_mg_glo_bal.mg_ads000_03(w_seg001_01, this);
        }

        public void fu_ini_frm(int av_tip_for = 1)
        {

        }

        public string fu_val_ida()
        {
            va_msg_err = null;

            va_usr_usr = tb_usr_usr.Text;
            va_pss_usr = tb_pas_usr.Text;

            if (va_usr_usr.Trim() == "")
            {
                tb_usr_usr.Focus();
                va_msg_err = "Debe proporcionar el nombre de usuario";
                return va_msg_err;
            }

            if (va_pss_usr.Trim() == "")
            {
                tb_pas_usr.Focus();
                va_msg_err = "Debe proporcionar la contraseña de usuario";
                return va_msg_err;

            }

            if (tb_sel_usr.Text.Trim() == "")
            {
                tb_sel_usr.Focus();
                va_msg_err = "Debe proporcionar el usuario a personalizar el menú";
                return va_msg_err;

            }

            //Verifica que el usuario a parametrizar menu es correcto
            if (tb_sel_usr.Text.Trim() == "")
            {
                tb_sel_usr.Focus();
                va_msg_err = "Debe proporcionar el usuario a parametrizar el menú";
                return va_msg_err;
            }

            tabla = o_ads005._05(tb_sel_usr.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_sel_usr.Focus();
                va_msg_err = "El usuario a parametrizar, no existe";
                return va_msg_err;
            }

            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_sel_usr.Focus();
                va_msg_err = "El usuario a parametrizar, esta Deshabilitado";
                return va_msg_err;
            }

            return va_msg_err;

        }

        public bool fu_con_bdo()
        {
            try
            {
                if (fu_val_ida() != null)
                {
                    MessageBoxEx.Show(va_msg_err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //verifica si el usuario y contraseña son corectos
                tabla = o_ads005._05(va_usr_usr, va_pss_usr);
                if (tabla.Rows.Count == 0)
                {
                    o_c_cnx000.mt_cer_cnx();
                    MessageBoxEx.Show("Error de autentificación para el usuario: " + va_usr_usr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                va_nom_usr = tabla.Rows[0]["va_nom_usr"].ToString();
                va_tip_usr = Convert.ToInt32(tabla.Rows[0]["va_tip_usr"]);

                if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    MessageBoxEx.Show("El usuaio: " + va_usr_usr + " se encuentra Deshabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (va_tip_usr != 1)
                {
                    MessageBoxEx.Show("El usuaio debe ser administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                o_c_cnx000.mt_cer_cnx();
                MessageBoxEx.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void fu_rec_usr(string ide_usr)
        {
            if (ide_usr.Trim() == "")
            {
                tb_sel_usr.Text = "";
                return;
            }

            tabla = o_ads005._05(ide_usr);


            if (tabla.Rows.Count == 0)
            {
                tb_sel_usr.Text = ide_usr;
                lb_nom_usr.Text = "** NO Existe";
                return;
            }

            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_sel_usr.Text = ide_usr;
                lb_nom_usr.Text = "** Deshabilitado";
                return;
            }

            tb_sel_usr.Text = ide_usr;
            lb_nom_usr.Text = tabla.Rows[0]["va_nom_usr"].ToString();
        }
        #endregion
    }
}
