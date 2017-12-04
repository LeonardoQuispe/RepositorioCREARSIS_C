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
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;


namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO PRINCIPAL (ADMINISTRACION Y SEGURIDAD)
    /// </summary>
    public partial class adm000 : DevComponents.DotNetBar.Metro.MetroForm
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

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion

        #region EVENTOS

        public adm000()
        {
            InitializeComponent();
        }

        private void cnx004_Load(object sender, EventArgs e)
        {
            //para ocultar las barras scroll
            MDI_CLI_WIN();

            //incrementa el contador de ventanas o formularios abiertos
            Program.gl_nro_win++;

            //Obtiene los datos del usuario y de la empresa para mostrarla en el pie del formulario
            ss_cod_usr.Text = Program.gl_usr_usr;
            ss_nom_emp.Text = Program.gl_nom_emp;
            ss_nom_bdo.Text = Program.gl_bdo_usr;

            o_mg_glo_bal.fg_mue_nap(this);
            mn_pri_nci = o_mg_glo_bal.fg_ver_mnu(ss_cod_usr.Text, Name, mn_pri_nci);
        }
        private void cnx004_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Activate();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
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


        private void StatusStrip1_DoubleClick_1(object sender, EventArgs e)
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

        

        //Evento lanzado cada que una ventana hija se activa
        private void cnx004_MdiChildActivate(object sender, EventArgs e)
        {
            //Obtiene Formulario Hijo Activo            
            Form co_ide_ven = (Form)this.ActiveMdiChild;

            if ((co_ide_ven != null))
            {
                o_mg_glo_bal.fg_mue_nap(co_ide_ven);
            }
            else
            {
                co_ide_ven = this;
                o_mg_glo_bal.fg_mue_nap(co_ide_ven);
            }
        }
        #endregion

        #region OPCIONES DEL MENU



        //[Menu USUARIO]
        private void m_ads004_Click(object sender, EventArgs e)
        {
            seg001_01 obj = new seg001_01();

            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu GESTION]
        private void m_ads001_Click(object sender, EventArgs e)
        {
            adm002_01 obj = new adm002_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu DOCUMENTO]
        private void m_ads005_Click(object sender, EventArgs e)
        {
            adm003_01 obj = new adm003_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);

        }

        //[Menu TALONARIO]
        private void m_ads006_Click(object sender, EventArgs e)
        {
            adm004_01 obj = new adm004_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }
        //[Menu NUMERACIONES]
        private void m_ads007_Click(object sender, EventArgs e)
        {
            adm005_01 obj = new adm005_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu SUCURSALES]
        private void mn_suc_urs_Click(object sender, EventArgs e)
        {
            adm007_01 obj = new adm007_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu ACTIVIDADES ECONOMICAS]
        private void mn_act_ivi_Click(object sender, EventArgs e)
        {
            adm012_01 obj = new adm012_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu ACTIVIDADES DOSIFICACIONES]
        private void mn_dos_ifi_Click(object sender, EventArgs e)
        {
            ctb007_01 obj = new ctb007_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        //[Menu ACTIVIDADES LEYENDAS]
        private void mn_ley_end_Click(object sender, EventArgs e)
        {
            ctb006_01 obj = new ctb006_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

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







        #endregion

        private void mn_bs_ufv_Click(object sender, EventArgs e)
        {
            adm014_01 obj = new adm014_01();

            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        private void mn_bs_us_Click(object sender, EventArgs e)
        {
            adm013_01 obj = new adm013_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        private void mn_mar_pro_Click(object sender, EventArgs e)
        {
            inv004_01 obj = new inv004_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        private void mn_uni_med_Click(object sender, EventArgs e)
        {
            inv003_01 obj = new inv003_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        private void mn_fam_pro_Click(object sender, EventArgs e)
        {
            inv001_01 obj = new inv001_01();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }

        private void m_ads002_Click(object sender, EventArgs e)
        {
            adm001_03 obj = new adm001_03();
            o_mg_glo_bal.mg_ads000_01(obj, this, 1);
        }
    }
}
