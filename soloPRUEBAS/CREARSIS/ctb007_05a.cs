using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CREARSIS
{
    public partial class ctb007_05a : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;

        public ctb007_05a()
        {
            InitializeComponent();
        }

        private void ctb007_05a_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }




        void fu_ini_frm()
        {
            tb_nro_dos.Text = vg_str_ucc.Rows[0]["va_nro_dos"].ToString();
            tb_lla_ve.Text = vg_str_ucc.Rows[0]["va_lla_vee"].ToString();

            tb_lla_ve.Focus();
            tb_lla_ve.SelectAll();
        }

    }
}
