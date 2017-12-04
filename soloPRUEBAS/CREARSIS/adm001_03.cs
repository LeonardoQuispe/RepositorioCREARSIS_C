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
    public partial class adm001_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        DataTable tabla;
        Byte va_log_emp;

        #endregion

        #region INSTANCIAS

        c_adm001 o_adm001 = new c_adm001();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        DataTable tab_adm001;

        #endregion

        #region FUNCIONES

        public void fu_ini_frm()
        {
            fu_bus_car();
            gb_ctr_frm.Enabled = true;
        }
        private void fu_bus_car()
        {
            tabla = o_adm001._01();
            tb_nit_emp.Text = tabla.Rows[0]["va_nit_emp"].ToString();
            tb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
            tb_rep_leg.Text = tabla.Rows[0]["va_rep_leg"].ToString();
            tb_tel_emp.Text = tabla.Rows[0]["va_tel_emp"].ToString();
            tb_cel_emp.Text = tabla.Rows[0]["va_cel_emp"].ToString();
            tb_dir_emp.Text = tabla.Rows[0]["va_dir_emp"].ToString();
            tb_cor_reo.Text = tabla.Rows[0]["va_cor_reo"].ToString();
            tb_dir_web.Text = tabla.Rows[0]["va_dir_web"].ToString();
            tb_dir_fbk.Text = tabla.Rows[0]["va_dir_fbk"].ToString();
            tb_cla_wif.Text = tabla.Rows[0]["va_cla_wif"].ToString();
            va_log_emp =Convert.ToByte( tabla.Rows[0]["va_log_emp"]);
            pc_log_emp.Image = o_mg_glo_bal.fg_byt_img(va_log_emp);
            tb_nit_emp.Focus();
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int digitos;
            digitos = OpenFileDialog1.SafeFileName.Length - 4;
            pc_log_emp.ImageLocation = OpenFileDialog1.FileName;
        }
        #endregion
        public adm001_03()
        {
            InitializeComponent();
        }

        private void adm001_03_Load(object sender, EventArgs e)
        {

        }
    }
}
