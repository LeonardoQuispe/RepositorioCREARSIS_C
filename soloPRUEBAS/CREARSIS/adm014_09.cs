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

            if (tb_libro_xls.Text.Trim() == "")
            {
                return "Ningún libro de Excel importado";
            }

            if (dg_res_ult.Rows.Count == 0)
            {
                return "Ningún libro de Excel importado";
            }

            return null;
        }

        void fu_imp_xls()
        {

            try
            {
                string ruta = "";


                OpenFileDialog abrir_archivo = new OpenFileDialog();
                abrir_archivo.Filter = "Libro de Excel|*.xlsx|Libro de Excel 97-2003|*.xls";
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


                    Limpiar();


                    //recuperando el nombre del libro/ruta de Excel Seleccionado
                    tb_libro_xls.Text = ruta;
                    
                    //Recuperando el numero de fulas usadas en el libro de Excel
                    int filas = rango_xls.Rows.Count;

                    //Declarando varibles temporales y de validacion
                    DateTime tmp1;
                    decimal tmp2;
                    string fecha;
                    string tc;
                    string mensaje;

                    //cargando el contenido 
                    for (int i = 0; i < filas; i++)
                    {
                        dg_res_ult.Rows.Add();
                        mensaje = "";

                        //recupera fecha
                        fecha =Convert.ToString(rango_xls[i + 1, "A"].Value ?? "");
                        //Recupera TC
                        tc = Convert.ToString(rango_xls[i + 1, "B"].Value ?? "").Replace(',','.') ;


                        //valida fecha
                        if (DateTime.TryParse(fecha,out tmp1)==false)
                        {
                            dg_res_ult.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            mensaje = "Fecha Inválida";

                            dg_res_ult[0, i].Value = fecha;
                            dg_res_ult[1, i].Value = tc;
                            dg_res_ult[2, i].Value = mensaje;
                            continue;
                        }    
                        //Valida que sea decimal y el tamaño menor a 7 caracteres 
                        else if (decimal.TryParse(tc, out tmp2) == false || tc.Length > 7)
                        {
                            dg_res_ult.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            mensaje = "T.C. Inválido";
                        }
                        
                        dg_res_ult[0, i].Value = tmp1.ToShortDateString();
                        dg_res_ult[1, i].Value = tc;
                        dg_res_ult[2, i].Value = mensaje;
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

        public adm014_09()
        {
            InitializeComponent();
        }

        private void bt_imp_xls_Click(object sender, EventArgs e)
        {
            fu_imp_xls();

            if (app_xls != null)
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
                MessageBoxEx.Show(err_msg, "Error T.C. Bs/Ufv por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                        if (dg_res_ult[2,i].Value.ToString()=="")
                        {
                            fec_aux = Convert.ToDateTime(dg_res_ult[0, i].Value.ToString());
                            val_aux = dg_res_ult[1, i].Value.ToString();

                            //Borra datos de la fecha
                            o_adm014._06(fec_aux.ToShortDateString());

                            //Registra ufv uno por uno
                            o_adm014._02(fec_aux, val_aux);
                        }                        
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
