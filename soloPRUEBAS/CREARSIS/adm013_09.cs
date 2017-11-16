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
using System.Transactions;

namespace CREARSIS
{
    public partial class adm013_09 : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARIABLES

        public dynamic vg_frm_pad;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_adm013 o_adm013 = new c_adm013();


        #endregion


        #region METODOS

        void fu_imp_xls()
        {

            try
            {
                string ruta = "";


                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Libro de Excel|*.xlsx|Libro de Excel 97-2003|*.xls";
                openfile1.Title = "Seleccione el Libro de Excel";
                if (openfile1.ShowDialog() == DialogResult.OK)
                {
                    using (TransactionScope tra_nsa = new TransactionScope())
                    {

                        ruta = openfile1.FileName;


                        //creando una instancia para el objeto de excel 
                        Excel.Application obj_xls = new Excel.Application();

                        //pasando el objeto a un libro de excel
                        Excel.Workbook libro_xls = obj_xls.Workbooks.Open(ruta);

                        //Elijiendo la hoja del libro de excel elegido
                        Excel.Worksheet hoja_xls = (Excel.Worksheet)libro_xls.Worksheets[1];

                        //asignando el rango de filas y columnas usadas en la hoja de excel
                        Excel.Range xlsRange = hoja_xls.UsedRange;

                        ////recuperando el nombre del libro/ruta del excel
                        tb_libro_xls.Text = ruta;
                        dg_res_ult.Rows.Clear();

                        //cargando el contenido 
                        int columnas = xlsRange.Columns.Count;
                        int filas = xlsRange.Rows.Count;

                        for (int i = 0; i < filas; i++)
                        {
                            dg_res_ult.Rows.Add();

                            for (int j = 0; j < columnas; j++)
                            {
                                if (j == 0)
                                {
                                    dg_res_ult[j, i].Value = Convert.ToDateTime(xlsRange[i + 1, j + 1].Value ?? "").ToShortDateString();
                                }
                                else
                                {
                                    dg_res_ult[j, i].Value = xlsRange[i + 1, j + 1].Value ?? "";
                                }

                            }
                        }


                        libro_xls.Close();
                        obj_xls.Quit();

                        tra_nsa.Complete();
                        tra_nsa.Dispose();

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBoxEx.Show(ex.Message);
            }

        }

        #endregion

        #region EVENTOS
        public adm013_09()
        {
            InitializeComponent();
        }

        private void bt_imp_xls_Click(object sender, EventArgs e)
        {
            fu_imp_xls();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Registrar T.C. Bs/Usd por Fechas?   \r\n (Se Actualizarán TODOS los datos de las fechas ingresadas)", "Nuevo T.C. Bs/Usd por Fechas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                DateTime fec_aux = new DateTime();
                string val_aux = "";

                using (TransactionScope tra_nsa = new TransactionScope())
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {

                        fec_aux = Convert.ToDateTime(dg_res_ult[0, i].Value.ToString());
                        val_aux = dg_res_ult[1, i].Value.ToString().Replace(",", "."); ;

                        //Borra datos de la fecha
                        o_adm013._06(fec_aux.ToShortDateString());

                        //Registra ufv uno por uno
                        o_adm013._02(fec_aux, val_aux);
                    }


                    tra_nsa.Complete();
                    tra_nsa.Dispose();

                }

                vg_frm_pad.fu_bus_car(fec_aux.Month.ToString(), fec_aux.Year);

                    //Selecciona el mes y el año de la fecha aux que va ser la fecha inicial
                    vg_frm_pad.tb_val_año.Text = fec_aux.Year.ToString();
                    vg_frm_pad.cb_prm_bus.SelectedIndex = fec_aux.Month - 1;

                    MessageBoxEx.Show("Operación completada exitosamente", "Nuevo T.C. Bs/Usd por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
            }
            catch (Exception Ex)
            {
                MessageBoxEx.Show(Ex.Message);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }

}
