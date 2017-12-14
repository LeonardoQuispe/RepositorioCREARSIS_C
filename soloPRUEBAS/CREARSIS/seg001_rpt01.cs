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
    public partial class seg001_rpt01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public seg001_rpt01()
        {
            InitializeComponent();
        }

        private void seg001_rpt01_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
