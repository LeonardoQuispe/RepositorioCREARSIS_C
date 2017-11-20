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
    public partial class adm014_08 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        string err_msg = "";

        //Variables de Importacion EXCEL
        Excel.Application app_xls;                              //Objeto de la aplicacion de Excel        
        Excel.Workbook libro_xls;                               //Libro de Excel        
        Excel.Worksheet hoja_xls;                               //Hoja de un libro de Excel
        Excel.Range rango_xls;                                  //Rango de celdas de Excel(se maneja como una tabla, filas y columnas)

        #endregion

        #region INSTANCIAS

        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();
        c_adm014 o_adm014 = new c_adm014();

        #endregion

        #region METODOS


        string fu_ver_dat()
        {           

            if (tb_libro_xls.Text.Trim()=="" || tb_año_xls.Text.Trim() == "")
            {
                return "Ningún libro de Excel importado";
            }

            if (dg_res_ult.Rows.Count==0)
            {
                return "Ningún libro de Excel importado";
            }

            return null;
        }

        /// <summary>
        /// Metodo que Importa Libro de Excel
        /// </summary>
        void fu_imp_xls()
        {

            try
            {
                string ruta = "";


                OpenFileDialog abrir_archivo = new OpenFileDialog();
                abrir_archivo.Filter = "Libro de Excel 97-2003|*.xls|Libro de Excel|*.xlsx";
                abrir_archivo.Title = "Seleccione el Libro de Excel";

                if (abrir_archivo.ShowDialog() == DialogResult.OK)
                {
                    //Obtiene la Ruta del Libro de Excel Seleccionado
                    ruta = abrir_archivo.FileName;

                    //Instanciando la Aplicacion de Excel
                    app_xls = new Excel.Application();

                    //Abre el libro de excel con la ruta del Excel seleccionado
                    libro_xls = app_xls.Workbooks.Open(ruta);

                    //Seleccionando la primera hoja del libro de Excel elejido
                    hoja_xls = libro_xls.ActiveSheet;

                    //asignando el rango de filas y columnas usadas en la hoja de excel
                    rango_xls = hoja_xls.UsedRange;



                    //Valida que sea un excel Válido
                    if (rango_xls[3, 1].Value != "UNIDAD DE FOMENTO DE VIVIENDA (UFV)")
                    {
                        MessageBoxEx.Show("El formato del Libro de Excel es Inválido ","Error T.C. Bs/Ufv por Año", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();          
                        return;
                    }

                    Limpiar();

                    //recuperando el nombre del libro/ruta y el año seleccionado
                    tb_libro_xls.Text = ruta;                        
                    string tmp = rango_xls[2, "A"].Value.ToString();
                    tb_año_xls.Text = tmp.Substring(4, 4);

                    //declarando numeros de filas y columnas a cargar
                    int filas = 30;
                    int columnas = 11;

                    //Declarando Variables temporales y de validacion
                    decimal tmp2 =0;
                    string tmp3="";
                    int contador=0;         
                        
                       
                    //Cargando el contenido de Excel
                    for (int i = 0; i <= filas; i++)
                    {
                        dg_res_ult.Rows.Add();
                        dg_res_ult[0, i].Value = i + 1;

                        for (int j = 0; j <= columnas; j++)
                        {
                            //Recupera dato de celda y reemplaza coma por punto
                            tmp3 = Convert.ToString(rango_xls[i+7, j+2].Value ?? "").Replace(',','.');
                                
                            //Valida que sea decimal y el tamaño menor a 7 caracteres
                            if ((decimal.TryParse(tmp3,out tmp2)==false || tmp3.Length>7) && tmp3.Trim()!="")
                            {
                                dg_res_ult[j + 1, i].Style.BackColor = Color.Red;
                                contador++;
                            }
                                
                            //carga datos recuperados a datagrid
                            dg_res_ult[j + 1, i].Value = tmp3;
                        }
                    }


                    //Envia mensaje del numero de datos no validos
                    if (contador!=0)
                    {
                        MessageBoxEx.Show("Se encontraron " + contador + " datos con Formato Incorrecto", "Error T.C. Bs/Ufvx por Año", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            tb_año_xls.Clear();
            tb_libro_xls.Clear();
        }




        //Obtiene el identificador de proceso de subproceso de ventana
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwID_proceso);
        /// <summary>
        /// METODO para Cerrar la conexion con la Aplicacion de Excel y Matar Proceso
        /// </summary>
        void fu_cer_rar_xls()
        {
            libro_xls.Close(false);
            app_xls.Quit();            

            uint ID_proceso = 0;

            //Obtiene el ID del proceso de Excel a cerrar Despues 
            GetWindowThreadProcessId((IntPtr)app_xls.Hwnd, out ID_proceso);

            try
            {
                //Mata el proceso de Excel que se obtuvo por ID
                System.Diagnostics.Process proceso_xls = System.Diagnostics.Process.GetProcessById((int)ID_proceso);
                proceso_xls.Kill();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }

            //Limpiando las variables de Excel
            app_xls = null;
            libro_xls = null;
            hoja_xls = null;
            rango_xls = null;
        }


        #endregion

        #region EVENTOS

        public adm014_08()
        {
            InitializeComponent();
        }

        private void bt_imp_xls_Click(object sender, EventArgs e)
        {            
            fu_imp_xls();

            if (app_xls!=null)
            {
                fu_cer_rar_xls();
            }            
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

            err_msg = fu_ver_dat();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error T.C. Bs/Ufv por Año", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res_msg = new DialogResult();
            res_msg = MessageBoxEx.Show("¿Estas seguro de Registrar T.C. Bs/Ufv por Año?  \r\n (Se Actualizarán TODOS los datos de la gestión " + tb_año_xls.Text+")", "Nuevo T.C. Bs/Ufv por Año", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res_msg == DialogResult.Cancel)
            {
                return;
            }
            

            try
            {
                DateTime fec_ini_aux;
                DateTime fec_fin_aux;
                DateTime fec_aux;
                string val_aux = "";

                using (TransactionScope tra_nsa = new TransactionScope())
                {
                    fec_ini_aux = Convert.ToDateTime("01/01/" + tb_año_xls.Text);
                    fec_fin_aux = Convert.ToDateTime("31/12/" + tb_año_xls.Text);
                    
                    //Borra datos del año
                    o_adm014._06(fec_ini_aux, fec_fin_aux);

                    //Registra ufv uno por uno
                    for (int i = 1; i < 13; i++)
                    {
                        for (int j = 1; j < 32; j++)
                        {
                            if (dg_res_ult[i, j - 1].Value.ToString().Trim() != "" && dg_res_ult[i, j - 1].Style.BackColor!=Color.Red)
                            {
                                fec_aux = Convert.ToDateTime(j.ToString() + "/" + i.ToString() + "/" + tb_año_xls.Text);
                                val_aux = dg_res_ult[i, j - 1].Value.ToString();
                                o_adm014._02(fec_aux, val_aux);
                            }
                        }
                    }

                    tra_nsa.Complete();
                    tra_nsa.Dispose();
                    
                }

                vg_frm_pad.fu_bus_car(fec_ini_aux.Month.ToString(), fec_ini_aux.Year);

                //Selecciona el mes y el año de la fecha aux que va ser la fecha inicial
                vg_frm_pad.tb_val_año.Text = fec_ini_aux.Year.ToString();
                vg_frm_pad.cb_prm_bus.SelectedIndex = fec_ini_aux.Month - 1;

                MessageBoxEx.Show("Operación completada exitosamente", "Nuevo T.C. Bs/Ufv por Año", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

                    

            }
            catch(Exception Ex)
            {
                MessageBoxEx.Show(Ex.Message);
            }
        }
        #endregion
    }
}
