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
using System.Runtime.InteropServices;

namespace CREARSIS
{
    public partial class adm014_09 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_adm014 o_adm014 = new c_adm014();


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
                    using (TransactionScope tra_nsa = new TransactionScope())
                    {
                        ruta = openfile1.FileName;


                        //creando una instancia para el objeto de excel 
                        Excel.Application obj_xls = new Excel.Application();

                        //pasando el objeto a un libro de excel
                        Excel.Workbook libro_xls = obj_xls.Workbooks.Open(ruta, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        //Elijiendo la hoja del libro de excel elegido
                        Excel.Worksheet hoja_xls = libro_xls.ActiveSheet;

                        //asignando el rango de filas y columnas usadas en la hoja de excel
                        Excel.Range xlsRange = hoja_xls.UsedRange;
                        

                        Limpiar();


                        //recuperando el nombre del libro/ruta y el año seleccionado
                        tb_libro_xls.Text = ruta;


                        //cargando el contenido 
                        int filas = xlsRange.Rows.Count;

                        DateTime tmp1;
                        decimal tmp2;
                        string fecha;
                        string tc;


                        for (int i = 0; i <= filas; i++)
                        {
                            dg_res_ult.Rows.Add();

                            //recupera fecha
                            fecha =Convert.ToString(xlsRange[i + 1, "A"].Value ?? "");

                            //valida fecha
                            if (DateTime.TryParse(fecha,out tmp1)==true)
                            {

                            }
                            else
                            {
                                //dg_res_ult[0, i].Value = tmp1;
                            }



                            //Recupera TC
                            tc= Convert.ToString(xlsRange[i + 1, "B"].Value ?? "");

                            //Valida que sea decimal y el tamaño menor a 7 caracteres                            
                            if (decimal.TryParse(tc, out tmp2) == true)
                            {
                                
                            }
                            else if(tc.Length>7)
                            {

                            }
                            else
                            {

                            }

                            

                            
                        }

                        

                        //Cierra libro, aplicacion y proceso de excel creado
                        libro_xls.Close(false);
                        obj_xls.Quit();
                        fu_cer_rar_xls(obj_xls);

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


        void Limpiar()
        {
            dg_res_ult.Rows.Clear();            
            tb_libro_xls.Clear();
        }


        //Obtiene el identificador de proceso de subproceso de ventana
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        void fu_cer_rar_xls(Excel.Application app)
        {
            uint iProcessId = 0;

            //Get the process ID of excel so we can kill it later.
            GetWindowThreadProcessId((IntPtr)app.Hwnd, out iProcessId);

            try
            {
                System.Diagnostics.Process pProcess = System.Diagnostics.Process.GetProcessById((int)iProcessId);
                pProcess.Kill();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }

        #endregion

        #region EVENTOS

        public adm014_09()
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
            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Registrar T.C. Bs/Ufv por Fechas?   \r\n (Se Actualizarán TODOS los datos de las fechas ingresadas)" , "Nuevo T.C. Bs/Ufv por Fechas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
                        o_adm014._06(fec_aux.ToShortDateString());

                        //Registra ufv uno por uno
                        o_adm014._02(fec_aux, val_aux);
                    }

                    tra_nsa.Complete();
                    tra_nsa.Dispose();

                }

                vg_frm_pad.fu_bus_car(fec_aux.Month.ToString(), fec_aux.Year);

                //Selecciona el mes y el año de la fecha aux que va ser la fecha inicial
                vg_frm_pad.tb_val_año.Text = fec_aux.Year.ToString();
                vg_frm_pad.cb_prm_bus.SelectedIndex = fec_aux.Month - 1;

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo T.C. Bs/Ufv por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

                    
            }
            catch (Exception Ex)
            {
                MessageBoxEx.Show(Ex.Message);
            }
        }
        #endregion
    }
}
