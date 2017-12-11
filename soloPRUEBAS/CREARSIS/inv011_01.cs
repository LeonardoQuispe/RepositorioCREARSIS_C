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


namespace CREARSIS
{
    public partial class inv011_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        public inv011_01()
        {
            InitializeComponent();
        }

        private void inv011_01_Load(object sender, EventArgs e)
        {

        }

        private void m_inv011_02_Click(object sender, EventArgs e)
        {
            inv011_02 obj = new inv011_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void m_inv011_03_Click(object sender, EventArgs e)
        {

        }
    }
}
