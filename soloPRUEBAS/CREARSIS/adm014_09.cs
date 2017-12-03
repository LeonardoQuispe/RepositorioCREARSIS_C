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

        string fu_ver_dat_imp()
        {
            char tmp1, tmp2;

            if (tb_col_ini.Text.Trim()!="")
            {
                if (char.IsLetter(tb_col_ini.Text, 0) == false)
                {
                    tb_col_ini.Focus();
                    return "Columna inicial inválida";
                }
            }

            if (tb_col_fin.Text.Trim() != "")
            {
                if (char.IsLetter(tb_col_fin.Text, 0) == false)
                {
                    tb_col_fin.Focus();
                    return "Columna final inválida";
                }
            }

            
            tmp1 = Convert.ToChar(string.IsNullOrWhiteSpace(tb_col_ini.Text) ? tb_col_ini.WatermarkText:tb_col_ini.Text);
            tmp2 = Convert.ToChar(string.IsNullOrWhiteSpace(tb_col_fin.Text) ? tb_col_fin.WatermarkText : tb_col_fin.Text);
            if (Convert.ToInt32(tmp1) >= Convert.ToInt32(tmp2))
            {
                tb_col_fin.Focus();
                return "La columna final debe ser mayor a la inicial";
            }

            if (int.Parse(string.IsNullOrWhiteSpace(tb_fila_ini.Text) ? tb_fila_ini.WatermarkText:tb_fila_ini.Text) >= int.Parse(string.IsNullOrWhiteSpace(tb_fila_fin.Text) ? tb_fila_fin.WatermarkText:tb_fila_fin.Text))
            {
                tb_fila_fin.Focus();
                return "La fila final debe ser mayor a la inicial";
            }

            return null;
        }

        void fu_imp_xls()
        {

            try
            {
                //Ruta del libro de Excel
                string ruta = "";

                //Variables de obtencion de fila y columna
                char tmp_char;
                int fila_ini, fila_fin, col_ini, col_fin,nro_fila,nro_col;
                
                //Declarando varibles temporales y de validacion
                DateTime tmp1;
                decimal tmp2;
                string fecha,tc,mensaje;


                OpenFileDialog abrir_archivo = new OpenFileDialog();
                abrir_archivo.Filter = "Libro de Excel|*.xls; *.xlsx";
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

                    ////asignando el rango de filas y columnas usadas en la hoja de excel
                    rango_xls = hoja_xls.UsedRange;


                    

                    //Obteniendo fila inicial
                    fila_ini = int.Parse(string.IsNullOrWhiteSpace(tb_fila_ini.Text) ? tb_fila_ini.WatermarkText : tb_fila_ini.Text);

                    //Obteniendo el numero ASCII equivalente a la letra ingresada para luego
                    //restarle 64 y usarla como indice al recuperar datos de Excel
                    tmp_char =Convert.ToChar(string.IsNullOrWhiteSpace(tb_col_ini.Text) ? tb_col_ini.WatermarkText: tb_col_ini.Text);
                    col_ini = Convert.ToInt32(tmp_char)-64;

                    //Obteniendo fila final y comparando el numero de filas usadas
                    if (rango_xls.Rows.Count<500 && string.IsNullOrWhiteSpace(tb_fila_fin.Text))
                    {
                        fila_fin = rango_xls.Rows.Count;
                    }
                    else
                    {
                        fila_fin = int.Parse(string.IsNullOrWhiteSpace(tb_fila_fin.Text) ? tb_fila_fin.WatermarkText : tb_fila_fin.Text);
                    }                    

                    //Obteniendo el numero ASCII equivalente a la letra ingresada para luego
                    //restarle 64 y usarla como indice al recuperar datos de Excel
                    tmp_char = Convert.ToChar(string.IsNullOrWhiteSpace(tb_col_fin.Text) ? tb_col_fin.WatermarkText : tb_col_fin.Text);
                    col_fin = Convert.ToInt32(tmp_char)-64;

                    //obteniendo el numero total de filas y columnas
                    nro_fila = fila_fin - fila_ini + 1;
                    nro_col = col_fin - col_ini + 1;

                    if (nro_col!=2)
                    {
                        MessageBoxEx.Show("El número de columnas seleccionadas es incorrecto, sólo se mostrarán las columnas válidas.", "Nuevo T.C. Bs/Ufv por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Limpiar();


                    //recuperando el nombre del libro/ruta de Excel Seleccionado
                    tb_libro_xls.Text = ruta;


                    //cargando el contenido 
                    for (int i = 0; i < nro_fila; i++)
                    {
                        dg_res_ult.Rows.Add();
                        mensaje = "";


                        //recupera fecha
                        fecha =Convert.ToString(rango_xls[fila_ini+i, col_ini].Value ?? "");
                        //Recupera TC
                        tc = Convert.ToString(rango_xls[fila_ini + i, col_ini+1].Value ?? "").Replace(',','.');
                        
                        //valida fecha
                        if (DateTime.TryParse(fecha,out tmp1)==false || fecha.Trim()=="")
                        {
                            dg_res_ult.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            mensaje = "Fecha Inválida";

                            dg_res_ult[0, i].Value = fecha;
                            dg_res_ult[1, i].Value = tc;
                            dg_res_ult[2, i].Value = mensaje;
                            continue;
                        }    
                        //Valida que sea decimal y el tamaño menor a 7 caracteres 
                        else if (decimal.TryParse(tc, out tmp2) == false || tmp2>=3 || tc.Length > 7 || tc.Trim()=="")
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
        
        private void tb_libro_xls_ButtonCustomClick(object sender, EventArgs e)
        {
            err_msg = fu_ver_dat_imp();
            if (err_msg != null)
            {
                MessageBoxEx.Show(err_msg, "Error T.C. Bs/Ufv por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fu_imp_xls();

            if (app_xls != null)
            {
                fu_cer_rar_xls();
            }
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
            res_msg = MessageBoxEx.Show("¿Estas seguro de Registrar T.C. Bs/Ufv por Fechas?   \r\n (Se Actualizarán TODOS los datos de las fechas ingresadas)", "Nuevo T.C. Bs/Ufv por Fechas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
                        if (dg_res_ult[2, i].Value.ToString() == "")
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

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_fila_ini_TextChanged(object sender, EventArgs e)
        {
            tb_fila_ini.Text = o_mg_glo_bal.valida_numeros(tb_fila_ini.Text);
            tb_fila_ini.Select(tb_fila_ini.Text.Length, 0);
        }

        private void tb_fila_fin_TextChanged(object sender, EventArgs e)
        {
            tb_fila_fin.Text = o_mg_glo_bal.valida_numeros(tb_fila_fin.Text);
            tb_fila_fin.Select(tb_fila_fin.Text.Length, 0);
        }

        private void tb_libro_xls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                err_msg = fu_ver_dat_imp();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Error T.C. Bs/Ufv por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                fu_imp_xls();

                if (app_xls != null)
                {
                    fu_cer_rar_xls();
                }
            }
        }

        #endregion


    }
}
