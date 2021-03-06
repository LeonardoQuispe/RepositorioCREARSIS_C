﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;

namespace CREARSIS._9_CMP
{
    public partial class cmp000 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        private MdiClient mdiClient = null;
        private int childFormNumber = 0;
        private const int SB_BOTH = 3;
        private const int WM_NCCALCSIZE = 0x83;
        //[DllImport("User32.dll")]
        [DllImport("user32")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

        #endregion

        #region INSTANCIAS

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        #endregion

        #region MÉTODOS

        private void MDI_CLI_WIN()
        {
            foreach (Control c in this.Controls)
            {
                //Buscar los MdiClient en el MdiWindow
                if (c is MdiClient)
                {
                    mdiClient = c as MdiClient;
                }
            }
        }

        /// <summary>
        ///   -> Verifica menu al Activarseel formulario
        /// </summary>
        /// <param name="ide_usr"></param>
        /// <param name="frm_act"></param>
        public void fu_ver_mnu(string ide_usr, Form frm_act)
        {
            if (mn_pri_nci.Visible == true)
            {
                //verifica Restricciones del menu de la aplicacion para el usuario
                mn_pri_nci = o_mg_glo_bal.fg_ver_mnu(ide_usr, frm_act.Name, mn_pri_nci);
            }
            else
            {
                //verifica Restricciones del menu de la aplicacion para el usuario
                MenuStrip1 = o_mg_glo_bal.fg_ver_mnu(ide_usr, frm_act.Name, MenuStrip1);
            }
        }


        void fu_ini_frm()
        {
            //para ocultar las barras scroll
            MDI_CLI_WIN();

            //Muestra nombre en la parte superior de ventana
            //FORMATO: (NOMBRE EMPRESA)-(Nombre Contenedor)
            Text = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad";
            TitleText = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad";


            //incrementa el contador de ventanas o formularios abiertos
            Program.gl_nro_win++;

            //Obtiene los datos del usuario y de la empresa para mostrarla en el pie del formulario
            ss_cod_usr.Text = Program.gl_usr_usr;
            ss_nom_emp.Text = Program.gl_nom_emp;
            ss_nom_bdo.Text = Program.gl_bdo_usr;

            o_mg_glo_bal.fg_mue_nap(this);
            mn_pri_nci = o_mg_glo_bal.fg_ver_mnu(ss_cod_usr.Text, Name, mn_pri_nci);

            
        }

        #endregion

        #region OPCIONES DEL MENU


        #endregion

        #region EVENTOS


        public cmp000()
        {
            InitializeComponent();
        }

        private void cmp000_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void cmp000_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Activate();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Maximized;
            }

            DialogResult vv_res_msg;
            vv_res_msg = MessageBoxEx.Show(this, "Esta seguro de Salir de la aplicación ?", "Salir",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (vv_res_msg == DialogResult.OK)
            {
                //Disminuye el contador de ventanas o formularios abiertos
                Program.gl_nro_win = Program.gl_nro_win - 1;

                //Establece en nulo el valor para esconder scroll
                mdiClient = null;
            }
            else
            {
                //Retracta la opcion de cerrar el formulario
                e.Cancel = true;
            }
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (mdiClient != null)
                {
                    //Hide the ScrollBars
                    ShowScrollBar(mdiClient.Handle, SB_BOTH, 0);
                }
                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                Program.gl_nro_win = Program.gl_nro_win - 1;
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void StatusStrip1_DoubleClick(object sender, EventArgs e)
        {
            cnx002 o_cnx002 = new cnx002();

            //verifica que exista un menu valido            
            if (mn_pri_nci.Visible == true)
            {
                if (mn_pri_nci.Items.Count != 0)
                {

                    //abre ventana de autentificacion
                    o_cnx002.vg_frm_pad = this;
                    this.Enabled = false;
                    o_cnx002.Show(this);
                }
            }
            else
            {
                if (MenuStrip1.Items.Count != 0)
                {
                    //abre ventana de autentificacion
                    o_cnx002.vg_frm_pad = this.ActiveMdiChild;
                    this.Enabled = false;
                    o_cnx002.Show(this);

                }

            }
        }

        private void cmp000_MdiChildActivate(object sender, EventArgs e)
        {
            //Obtiene Formulario Hijo Activo            
            Form co_ide_ven = ActiveMdiChild;

            if ((co_ide_ven != null))
            {
                //Muestra nombre en la parte superior de ventana
                //FORMATO: (NOMBRE EMPRESA)-(Nombre Contenedor)-(Nombre de ventana hija actual activa)
                Text = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad" + " - " + co_ide_ven.Text;
                TitleText = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad" + " - " + co_ide_ven.Text;


                //Muestra nombre de ventana en la parde inferior del PADRE
                o_mg_glo_bal.fg_mue_nap(co_ide_ven);
            }
            else
            {
                //Muestra nombre en la parte superior de ventana
                //FORMATO: (NOMBRE EMPRESA)-(Nombre Contenedor)-(Nombre de ventana hija actual activa)
                Text = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad";
                TitleText = Program.gl_nom_emp + " - " + "Menú Administración y Seguridad";



                //Muestra nombre de ventana en la parde inferior del PADRE
                co_ide_ven = this;
                o_mg_glo_bal.fg_mue_nap(co_ide_ven);
            }
        }
        #endregion

        private void m_inv016_Click(object sender, EventArgs e)
        {
           
            CREARSIS._9_CMP.cmp001_com_pra_.cmp001_02 obj = new CREARSIS._9_CMP.cmp001_com_pra_.cmp001_02();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }
    }

}
