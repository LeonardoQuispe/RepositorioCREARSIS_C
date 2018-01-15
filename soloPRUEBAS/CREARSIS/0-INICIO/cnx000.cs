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
using System.IO;
using DevComponents.DotNetBar;
using System.Globalization;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO INICIO DE SESION
    /// </summary>
    public partial class cnx000 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        string va_msg_err;
        int va_ban_err;

        #endregion

        #region INSTANCIAS

        c_seg001 o_ads005 = new c_seg001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region  EVENTOS

        public cnx000()
        {
            InitializeComponent();
        }

        private void cnx000_Load(object sender, EventArgs e)
        {
            try
            {

                CultureInfo regional = System.Threading.Thread.CurrentThread.CurrentCulture;
                //= New System.Globalization.CultureInfo("es-MX")

                if (regional.Name != "es-MX")
                {
                    MessageBoxEx.Show("La regional es diferente a 'Español Mexico', verifique por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //Obtiene la version del sistema de: My projet -> Application -> Assembly Information
                lb_ver_sis.Text = "Ver.: " + o_mg_glo_bal.sub_string(Application.ProductVersion, 1, 5); // "CrearSis" + Convert.ToChar(10) +
                //--** Pantalleo
                Label1.ForeColor = Color.Olive;
                lb_ver_sis.ForeColor = Color.Olive;
                tb_usr_usr.Focus();

                fu_lis_bdo();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_ver_key(object sender, EventArgs e)
        {
             
        }


        private void bt_ver_pss_MouseHover(object sender, EventArgs e)
        {
            tb_pss_usr.UseSystemPasswordChar = false;
        }

        private void bt_ver_pss_MouseLeave(object sender, EventArgs e)
        {
            tb_pss_usr.UseSystemPasswordChar = true;
        }

        private void sy_pss_usr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string msg_err = fu_val_ida(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text);

                if (msg_err != null)
                {
                    MessageBoxEx.Show(msg_err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                dynamic vc_usr_log = o_mg_glo_bal.fg_cnx_usr(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text, false);

                //verifica conexion de usuaio con la base de datos
                if (vc_usr_log.vs_msg_err != "")
                {
                    MessageBoxEx.Show(vc_usr_log.vs_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataTable tabla = new DataTable();
                tabla = o_ads005._05(tb_usr_usr.Text);

                seg001_03b obj = new seg001_03b();
                o_mg_glo_bal.mg_ads000_03(obj, this, tabla);

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(" Error: " + ex.Message + System.Environment.NewLine + _01_mg_glo_bal.vc_usr_log.vs_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        private void sy_bdo_usr_DoubleClick(object sender, EventArgs e)
        {
            string msg_err = fu_val_ida(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text);
            if (msg_err != null)
            {
                MessageBoxEx.Show(va_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tb_usr_usr.Text != "crearsis")
            {
                MessageBoxEx.Show("Usuario no valido para proporcionar licencia", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-si todo esta bien
            dynamic vc_usr_log = o_mg_glo_bal.fg_cnx_usr(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text, true);

            //verifica conexion de usuaio con la base de datos
            if (vc_usr_log.vs_msg_err != "")
            {
                MessageBoxEx.Show(vc_usr_log.vs_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }



            this.Visible = false;

            cnx001 obj = new cnx001();

            obj.ShowDialog();
            obj.Activate();
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            //mg_not_ify("Notificacion", "Prueba de la notificacion")

            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");

            // Dim a = fg_gen_lic("01/10/2016", "b0-i3-11")

            //Verifica datos en pantalla
            if (fu_val_ida(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text) != null)
            {
                MessageBoxEx.Show(va_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            //Obtiene y guarda datos de usuario y empresa en variables GLOBALES
            dynamic vc_usr_log = o_mg_glo_bal.fg_cnx_usr(tb_usr_usr.Text, tb_pss_usr.Text, cb_bdo_usr.Text, false);


            //verifica conexion de usuaio con la base de datos
            if (vc_usr_log.vs_msg_err != "")
            {
                MessageBoxEx.Show(vc_usr_log.vs_msg_err, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.Hide();

            cnx003 o_cnx003 = new cnx003();

            if (va_ban_mnu == 1)
            {
                o_cnx003.ShowDialog();
                Close();
            }

            if (va_ban_mnu == 2)
            {
                o_cnx003.ShowDialog();
                Close();
            }
            
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Bandera de inicio del sistema: 1=Menu Normal ; 2=Menu Resumido
        /// </summary>
        int va_ban_mnu;

        /// <summary>
        /// Obtiene Lista de instancias de conexion
        /// </summary>
        public void fu_lis_bdo()
        {
            try
            {
                //inicializa variable
                va_ban_mnu = 2;

                string cad_ena = @"c:\crearsis\crearsisBD.txt";

                bool ban_arc = File.Exists(cad_ena);

                if (ban_arc)
                {
                    string con_ten = File.ReadAllText(cad_ena);

                    string[] BD = con_ten.Split('#');
                    for (int i = 1; i <= BD.Length - 1; i++)
                    {
                        string instancia = BD[i];

                        if (instancia.Length != 0)
                        {
                            if (instancia!= "**1" || instancia == "**2")
                            {
                                cb_bdo_usr.Items.Add(instancia);
                            }

                        }
                    }

                    string[] separador = new string[] { "#**" };
                    BD = con_ten.Split(separador, StringSplitOptions.None);

                    if (BD.Length <= 0)
                    {
                        va_ban_mnu = 2;
                    }
                    else
                    {
                        va_ban_mnu = int.Parse(BD[1]);
                    }

                    cb_bdo_usr.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }


        /// <summary>
        /// Valida Datos de Autenticacion en pantalla
        /// </summary>
        string fu_val_ida(string usr_usr, string pss_usr, string ins_bdo)
        {
            try
            {
                va_msg_err = null;

                if (usr_usr.Trim() == "")
                {
                    va_msg_err = "Debe proporcionar el nombre de usuario";
                    tb_usr_usr.Focus();
                    return va_msg_err;
                }

                if (pss_usr.Trim() == "")
                {
                    va_msg_err = "Debe proporcionar la contraseña de usuario";
                    tb_pss_usr.Focus();
                    return va_msg_err;
                }

                if (ins_bdo.Trim() == "")
                {
                    va_msg_err = "Debe proporcionar al menos una instancia de conexion";
                    cb_bdo_usr.Focus();
                    return va_msg_err;
                }

                return va_msg_err;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        private void lk_fan_pag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre la pagina de facebook para contacto
            System.Diagnostics.Process.Start("https://www.facebook.com/crearsis/");
        }
    }
}
