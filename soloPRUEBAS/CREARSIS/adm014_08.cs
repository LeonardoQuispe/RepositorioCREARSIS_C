using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS
using DATOS.ADM;
using DevComponents.DotNetBar;
using CREARSIS.GLOBAL;
using Excel = Microsoft.Office.Interop.Excel;


namespace CREARSIS
{
    public partial class adm014_08 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        #endregion

        #region INSTANCIAS
        
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion


        #region METODOS

        void fu_imp_xls()
        {

            try
            {
                string ruta = "";


                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Libro de Excel 97-2003|*.xls|Libro de Excel|*.xlsx";
                openfile1.Title = "Seleccione el Libro de Excel";
                if (openfile1.ShowDialog() == DialogResult.OK)
                {
                    ruta = openfile1.FileName;


                    //creando una instancia para el objeto de excel 
                    Excel.Application obj_xls = new Excel.Application();

                    //pasando el objeto a un libro de excel
                    Excel.Workbook libro_xls = obj_xls.Workbooks.Open(ruta, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    //Elijiendo la hoja del libro de excel elegido
                    Excel.Worksheet hoja_xls = (Excel.Worksheet)libro_xls.Worksheets[1];

                    //asignando el rango de filas y columnas usadas en la hoja de excel
                    Excel.Range xlsRange = hoja_xls.UsedRange;

                    //recuperando el nombre del libro, de la hoja, y el año seleccionado
                    tb_libro_xls.Text = libro_xls.Name;
                    tb_hoja_xls.Text = hoja_xls.Name;
                    string tmp = xlsRange[2, 1].Value.ToString();
                    tb_año_xls.Text = tmp.Substring(4, 4);



                    dg_res_ult.Rows.Clear();

                    //cargando el contenido 
                    int filas = 30;
                    int columnas = 12;

                    for (int i = 0; i <= filas; i++)
                    {
                        dg_res_ult.Rows.Add();

                        for (int j = 0; j <= columnas; j++)
                        {
                            dg_res_ult[j, i].Value = xlsRange[i + 7, j + 1].Value ?? "";
                        }
                    }


                    libro_xls.Close(false, ruta, Type.Missing);
                    obj_xls.Quit();


                }

            }
            catch (Exception ex)
            {

                MessageBoxEx.Show(ex.Message);
            }

        }

        #endregion

        public adm014_08()
        {
            InitializeComponent();
        }

        private void bt_imp_xls_Click(object sender, EventArgs e)
        {
            fu_imp_xls();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
