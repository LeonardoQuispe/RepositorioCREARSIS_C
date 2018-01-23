using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DATOS
{
    public class c_cnx000
    {
        /// <summary>
        /// Variable estática string cadena de conexion
        /// </summary>
        static string gl_cnx_str;


        /// <summary>
        /// Nombre del servidor
        /// </summary>
        public string va_nom_srv = "";
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public string va_nom_bdo = "";
        /// <summary>
        /// codigo de usuario de la base de datos
        /// </summary>
        private string va_cod_usr = "chlsql";
        /// <summary>
        /// contraseña de la base de datos
        /// </summary>
        private string va_pws_usr = "Crearsis123.";



        /// <summary>
        /// Objeto de Conexion a SQL
        /// </summary>
        private SqlConnection obj_sql_cnx = new SqlConnection();

        /// <summary>
        /// Objeto de Comando de SQL
        /// </summary>
        static private SqlCommand obj_sql_cmd;



        /// <summary>
        /// Funcion Conexion inicial (Al loguearse)
        /// </summary>
        public void fu_cnx_ini()
        {

            gl_cnx_str = "Data Source=" + va_nom_srv + "; Initial Catalog=" + va_nom_bdo + " ; " +
                        "user=" + va_cod_usr + "; password=" + va_pws_usr + ";packet size=4096;Connect Timeout=300";
        }

        /// <summary>
        /// Funcion Conexion durante todo el sistema
        /// </summary>
        private void fu_abr_cnx()
        {
            obj_sql_cnx = new SqlConnection();
            obj_sql_cnx.ConnectionString = gl_cnx_str;
            obj_sql_cnx.Open();
        }





        #region METODOS PARA EJECUTAR CONSULTAS A SQL

        /// <summary>
        /// Funcion que Ejecuta comando SQL SIN RETORNO
        /// </summary>
        /// <param name="va_cad_sql">Consulta(query) a ejecutar</param>
        /// <returns></returns>
        public bool fu_exe_sql_no(string va_cad_sql)
        {
            try
            {
                int va_num_fila = 0;

                //Instancia el Objeto de Comando de SQL
                obj_sql_cmd = new SqlCommand();

                //Abre la Conexion por si está cerrada
                if (obj_sql_cnx.State == ConnectionState.Closed)
                {
                    fu_abr_cnx();
                }

                obj_sql_cmd.CommandText = va_cad_sql;   //Llena la Consulta al Objeto Comando de SQL
                obj_sql_cmd.Connection = obj_sql_cnx;   //Asigna el objeto Conexion SQL al Comando
                va_num_fila = obj_sql_cmd.ExecuteNonQuery();   //Ejecuta el Comando con la consulta a la BD

                //Cierra La Conexion
                obj_sql_cnx.Close();

                //Valida si se afectaron filas en la BD
                if (va_num_fila > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
            }
        }


        /// <summary>
        /// Funcion que Ejecuta comando SQL CON RETORNO
        /// </summary>
        /// <param name="va_cad_sql">Consulta(query) a ejecutar</param>
        /// <returns></returns>
        public DataTable fu_exe_sql_si(string va_cad_sql)
        {
            try
            {

                DataTable tab_aux = new DataTable();    //Tabla Auxiliar donde se Cargará los datos retornados           
                obj_sql_cmd = new SqlCommand();     //Instancia el Objeto de Comando de SQL
                SqlDataAdapter obj_sql_adp;     //Objetos Adaptador de sql (para llenar la Tabla con datos de BD)


                //Abre la Conexion por si está cerrada
                if (obj_sql_cnx.State == ConnectionState.Closed)
                {
                    fu_abr_cnx();
                }

                obj_sql_cmd.CommandText = va_cad_sql;   //Llena la Consulta al Objeto Comando de SQL
                obj_sql_cmd.Connection = obj_sql_cnx;   //Asigna el objeto Conexion SQL al Comando
                obj_sql_adp = new SqlDataAdapter(obj_sql_cmd);  //Asigna el Comando al Adaptador SQL
                obj_sql_adp.Fill(tab_aux);      //Llena datos de la BD a Tabla auxiliar
                obj_sql_cnx.Close();    //Cierra la Conexion

                return tab_aux;     //Devuelve la Tabla Con los datos llenados desde la BD
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
            }
        }

        /// <summary>
        /// Funcion que guarda imagen a Base de Datos
        /// </summary>
        /// <param name="va_cad_sql">Cadena de consulta a SQL</param>
        /// <param name="va_nom_img">Nombre de Variable Temporal de Imagen</param>
        /// <param name="va_byt_img">Byte de la Imagen a guardar</param>
        public void fu_exe_sql_img(string va_cad_sql,string va_nom_img,byte[] va_byt_img)
        {
            try
            {
                obj_sql_cmd = new SqlCommand();     //Instancia el Objeto de Comando de SQL


                //Abre la Conexion por si está cerrada
                if (obj_sql_cnx.State == ConnectionState.Closed)
                {
                    fu_abr_cnx();
                }

                obj_sql_cmd.CommandText = va_cad_sql;   //Llena la Consulta al Objeto Comando de SQL
                obj_sql_cmd.Connection = obj_sql_cnx;   //Asigna el objeto Conexion SQL al Comando

                //Agrega Parametro con la imagen
                obj_sql_cmd.Parameters.Add(va_nom_img, SqlDbType.VarBinary, va_byt_img.Length).Value = va_byt_img;
                obj_sql_cmd.ExecuteNonQuery();      //Ejecuta la Consulta

                //Cierra la Conexion
                obj_sql_cnx.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
            }
        }



        #endregion
















    }
}
