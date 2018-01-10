using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DATOS
{
    public class c_cnx001
    {
        #region VARIABLES

        //Nos creamos un objeto conection para conectarnos a la BD
        /// <summary>
        /// Objeto de Conexion de SQL
        /// </summary>
        static SqlConnection obj_sql_cnx;
        /// <summary>
        /// Objeto de Parámetro de SQL
        /// </summary>
        private SqlParameter obj_sql_par;
        /// <summary>
        /// Objeto de Comando de SQL
        /// </summary>
        private SqlCommand obj_sql_cmd;
        /// <summary>
        /// Objeto de Transacción de SQL
        /// </summary>
        private SqlTransaction obj_sql_tra;

        //Datos de Acceso a la Base de Datos
        public string va_nom_srv = "";              //Nombre del Servidor
        public string va_nom_bdo = "";                //Nombre de la Base de Datos
        private string va_cod_usr = "chlsql";           //Nombre de usuario para loguearse en la BD
        private string va_pws_usr = "Crearsis123.";    //Contraseña del Usuario para loguearse en la BD

        //Variable estática string cadena de conexion
        static string gl_cnx_str;

        #endregion

        #region METODOS

        //public c_cnx001()
        //{
        //    if (gl_cnx_str != null)
        //    {
        //        //Instanciamos el objeto conecction
        //        obj_sql_cnx = new SqlConnection(gl_cnx_str);
        //    }
        //}

        /// <summary>
        /// Funcion Conexion inicial (Al loguearse)
        /// </summary>
        public void fu_cnx_ini()
        {
            gl_cnx_str = "Data Source=" + va_nom_srv + "; Initial Catalog=" + va_nom_bdo + " ; " +
                        "user=" + va_cod_usr + "; password=" + va_pws_usr + ";packet size=4096;Connect Timeout=300";

            obj_sql_cnx = new SqlConnection(gl_cnx_str);
        }


        #region EJECUTAR CONSULTA SQL

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
                    obj_sql_cnx.Open();
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
                    obj_sql_cnx.Open();
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

        #endregion

        #region TRANSACCIONES

        //Inicia la Transaccion para que luego llamar a EjecutarTransaccion la cual ejecuta Queries(Insert, Update,Delete) 
        //y si existe algun error revierte todo, con esto aseguramos la Integridad de los datos.
        //Por ultimo llamamos al metodo CerrarTransaccion, el cual confirma todos los Queries que se ejecutaron.
        /// <summary>
        /// Metodo Para Iniciar una Transacción
        /// </summary>
        public void fu_ini_tra()
        {
            try
            {
                obj_sql_cmd = new SqlCommand();     //Instancia el Objeto de Comando de SQL

                //Abre la Conexion en Caso de que esté cerrado
                if (obj_sql_cnx.State == ConnectionState.Closed)
                {
                    obj_sql_cnx.Open();
                }

                obj_sql_cmd.Connection = obj_sql_cnx;   //Asigna el Objeto conexion al Comando de SQL Actual
                obj_sql_tra = obj_sql_cnx.BeginTransaction();   //Inicia la Transacción
                obj_sql_cmd.Transaction = obj_sql_tra;  //Asigna la Transaccion al Objeto Comando de SQL Actual
            }
            catch (Exception ex)
            {
                //Cierra La conexion depues de ejecutar comando
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
                throw ex;
            }
        }



        //Ejecuta Cualquier Query, para usar este metodo, primero tenemos que llamar al metodo IniciarTransaccion
        //Una vez ejecutadas todas las Queries, se llama al metodo CerrarTransaccion, para confirmar todos los cambios.
        /// <summary>
        /// Metodo que Ejecuta Transacción
        /// </summary>
        /// <param name="va_cad_sql">Consulta(query) a ejecutar</param>
        /// <returns></returns>
        public bool fu_exe_tra(string va_cad_sql)
        {
            try
            {
                int va_num_fila = 0;    //Variable para recuperar el numero de filas afectadas al ejecutar la consulta a la BD

                obj_sql_cmd.CommandText = va_cad_sql;   //Llena la Consulta al Objeto Comando de SQL
                va_num_fila = obj_sql_cmd.ExecuteNonQuery();   //Ejecuta el Comando con la consulta a la BD

                //Valida si se afectaron filas en la BD
                if (va_num_fila > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //Revierte todas las consultas realizadas en caso de un Error en la Transacción
                obj_sql_tra.Rollback();

                //Cierra la Conexion
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
                throw ex;
            }
        }


        //Este Metodo Confirma todos los Queries que estan dentro de la Transaccion,
        //Si existe algun error revierte todas las transacciones
        /// <summary>
        /// Metodo para Finalizar la Transaccion
        /// </summary>
        public void fu_fin_tra()
        {
            try
            {
                //Confirma/Cierra la transacción realizada
                obj_sql_tra.Commit();
            }
            catch (Exception ex)
            {
                //Revierte todas las consultas realizadas en caso de un Error en la Transacción
                obj_sql_tra.Rollback();
                throw ex;
            }
            finally
            {
                //Cierra la conexion
                if (obj_sql_cnx.State == ConnectionState.Open)
                {
                    obj_sql_cnx.Close();
                }
            }
        }









        #endregion
        



        #endregion










    }
}
