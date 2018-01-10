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
using System.Threading;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO MENU PRINCIPAL DEL SISTEMA
    /// </summary>
    public partial class cnx003 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        DataTable tab_seg001;
        DataTable tab_seg021;
        DataTable tab_adm001;

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        c_seg001 o_seg001 = new c_seg001();
        c_seg021 o_seg021 = new c_seg021();
        c_adm001 o_adm001 = new c_adm001();

        #endregion

        #region EVENTOS

        public cnx003()
        {
            InitializeComponent();
        }

        private void bt_azu_mob_Click(object sender, EventArgs e)
        {
            fu_est_ilo(1);
            o_seg001.seg004_03(Program.gl_usr_usr, 1);
        }

        private void bt_neg_dar_Click(object sender, EventArgs e)
        {
            fu_est_ilo(2);
            o_seg001.seg004_03(Program.gl_usr_usr, 2);
        }

        private void bt_lig_col_Click(object sender, EventArgs e)
        {
            fu_est_ilo(3);
            o_seg001.seg004_03(Program.gl_usr_usr, 3);
        }

        private void bt_gla_col_Click(object sender, EventArgs e)
        {
            fu_est_ilo(4);
            o_seg001.seg004_03(Program.gl_usr_usr, 4);
        }
        private void cnx003_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult vv_res_msg;
            int vv_nro_vtn = 0; //nro de ventanas abiertas del sistema

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Maximized;
            }


            //VALIDAR QUE LAS VENTANAS HIJAS ESTE CERRADAS
            vv_nro_vtn = Convert.ToInt32(Program.gl_nro_win);
            if (vv_nro_vtn > 0)
            {
                // MsgBox("Aun existen ventanas abiertas de la aplicacion", MsgBoxStyle.Exclamation, "Crearsis")
                dynamic a = MessageBoxEx.Show("NO deberia cerrar el menú principal." + Convert.ToChar(10) + "Aun exísten (" + vv_nro_vtn + ") ventanas abiertas de la aplicación" + Convert.ToChar(10) + "Desea cerrar de todos modos ?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);

                if (a == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                return;
            }
            
            vv_res_msg = MessageBoxEx.Show("Esta seguro de Salir de la aplicación ?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (vv_res_msg == DialogResult.OK)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cnx003_Load(object sender, EventArgs e)
        {
            fu_ini_frm();            
        }

        private void bt_ref_mnu_Click(object sender, EventArgs e)
        {
            fu_ref_mnu();
        }

        #endregion

        #region METODOS

        #region "Cambia estilo de la aplicación"
        //Cambia el estilo de las pantallas
        void fu_est_ilo(int va_nro_est)
        {
            switch (va_nro_est)
            {
                case 1:
                    estiloMob2014.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
                    break;
                case 2:
                    estiloMob2014.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark;
                    break;
                case 3:
                    estiloMob2014.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
                    break;
                case 4:
                    estiloMob2014.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
                    //estiloMob2014.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;                   
                    break;
            }
        }

        #endregion

        
        void fu_ini_frm()
        {
            fu_cfg_reg();
            try
            {
                Text = "Menú inicial - " + Program.gl_nom_emp;
                TitleText = "Menú inicial - " + Program.gl_nom_emp;

                //Obtiene Codigo de usuario
                lb_usr_usr.Text = Program.gl_usr_usr;
                //Obtiene Nombre de usuario
                lb_nom_usr.Text = Program.gl_nom_usr;
                //Obtiene Nombre de la empresa
                lb_nom_emp.Text = Program.gl_nom_emp;

                //Obtiene LOGO de EMPRESA
                pc_log_emp.Image = fu_log_emp();

                //Fecha un mes antes de que caduque la licencia
                DateTime vv_fec_aux = _01_mg_glo_bal.vc_usr_log.vs_fec_cad.AddMonths(-1);
                //DateTime que obtine valor de la funcion global                
                DateTime vv_fec_act = o_mg_glo_bal.fg_fec_act();

                //COmpara fehca actual con fecha de licencia
                if ((vv_fec_aux - o_mg_glo_bal.fg_fec_act()).Days <= 0)
                {
                    _01_mg_glo_bal.mg_not_ify("LICENCIA POR CADUCAR", "La Licencia esta proxima a caducar, comuniquese con Crearsis");

                    lb_msg_lic.Text = "La Licencia esta por expirar...!!!";
                    //MessageBoxEx.Show("La Licencia esta por expirar...!!! " & Chr(13) & _
                    //                   "Comuniquese con Crearsis.", "Caducidad de licencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                }
                else
                {
                    lb_msg_lic.Text = "Ok.";
                }

                //Obtiene el nro de estilo del usuario para sus ventanas
                int nro_est = Convert.ToInt32(o_seg001.seg004_01(Program.gl_usr_usr).Rows[0]["va_nro_est"]);
                fu_est_ilo(nro_est);

                //Obtiene aplicaciones autorizadas del usuario
                fu_ref_mnu();

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Ah ocurrido un error:" + Convert.ToChar(13) + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        /// <summary>
        /// Configuracion de la regional
        /// </summary>
        public void fu_cfg_reg()
        {
            // Dim a = System.Threading.Thread.CurrentThread.CurrentCulture '=New System.Globalization.CultureInfo()
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");

        }
        
        public void fu_ref_mnu()
        {
            // Verifica la app permitidas para el usuario
            mt_ads000.Visible = false;
            mt_alq_uil.Visible = false;
            mt_con_tab.Visible = false;
            mt_inv_pro.Visible = false;
            mt_res_tau.Visible = false;
            mt_tes_caj.Visible = false;
            mt_ven_tas.Visible = false;

            tab_seg021 = o_seg021._05(_01_mg_glo_bal.vc_usr_log.vs_cod_usr);

            // Verifica la app permitidas para el usuario
            if (tab_seg021.Rows.Count != 0)
            {
                    for (int i = 0; i < tab_seg021.Rows.Count; i++)
                    {                       

                        switch (tab_seg021.Rows[i][1].ToString())
                        {
                            case "ads000":
                                mt_ads000.Visible = true; break;

                            case "app_alq_uil":
                                mt_alq_uil.Visible = true; break;

                            case "app_invent":
                                mt_inv_pro.Visible = true; break;

                            case "app_ventas":
                                mt_ven_tas.Visible = true; break;

                            case "app_restau":
                                mt_res_tau.Visible = true; break;

                            case "app_cajcaj":
                                mt_tes_caj.Visible = true; break;

                            case "app_contab":
                                mt_con_tab.Visible = true; break;

                            default:

                                break;
                        }
                    }
            }

            MetroTilePanel1.Refresh();
        }

        /// <summary>
        /// Funcion que obtiene el Logo de la Empresa Actual
        /// </summary>
        /// <returns></returns>
        Image fu_log_emp()
        {
            byte[] va_log_emp;

            tab_adm001 = o_adm001._01();

            if (tab_adm001.Rows[0]["va_log_emp"] == DBNull.Value)
            {
                return pc_log_emp.InitialImage;
            }
            else
            {
                va_log_emp = (Byte[])tab_adm001.Rows[0]["va_log_emp"];

                return o_mg_glo_bal.fg_byt_img(va_log_emp);
            }
        }


        #endregion

        #region "OPERACIONES DE LOS MOSAICOS DEL MENU"

        private void mt_ads000_Click(object sender, EventArgs e)
        {
            tab_seg001 = o_seg001._05(Program.gl_usr_usr);
            if (Convert.ToInt32(tab_seg001.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBoxEx.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas abiertas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            fh_ads000();
        }
        //procedimiento para que la aplicación arranque desde aquí
        [STAThread()]

        public static void fh_ads000()
        {
            //Crea el hilo del menu administrador
            Thread h_ads000 = new Thread(fu_run_ads000);
            h_ads000.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_ads000.Start();

        }

        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA 
        public static void fu_run_ads000()
        {
            try
            {
                Application.Run(new adm000());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
