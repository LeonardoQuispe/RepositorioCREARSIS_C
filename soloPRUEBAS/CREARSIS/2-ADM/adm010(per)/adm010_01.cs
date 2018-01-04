using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;





namespace CREARSIS._2_ADM.adm010_per_
{
    public partial class adm010_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public dynamic vg_frm_pad;

        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();


        public adm010_01()
        {
            InitializeComponent();
        }

        private void m_adm003_02_Click(object sender, EventArgs e)
        {
            adm010_02 obj = new adm010_02();
            o_mg_glo_bal.mg_ads000_02(obj, this);
        }
    }
}
