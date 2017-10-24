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
        static string gl_cnx_str;       //Variable estática string cadena de conexion

        /// <summary>
        /// Nombre del servidor
        /// </summary>
        public string va_nom_srv = "";
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public string va_nom_bdo = "";
        /// <summary>
        /// codigo de usuario
        /// </summary>
        public string va_cod_usr = "chlsql";
        /// <summary>
        /// contraseña de usuario
        /// </summary>
        //public string va_pws_usr = "leo";
        public string va_pws_usr = "Crearsis123.";


        public SqlConnection va_cnx_cnx = new SqlConnection();
        public string va_cad_str = "";


        /// <summary>
        /// Funcion Conexion inicial (Al loguearse)
        /// </summary>
        public SqlConnection fu_cnx_ini()
        {

            if (va_cnx_cnx.State == ConnectionState.Closed)
            {
                //var appSettings = ConfigurationManager.AppSettings;
                va_cad_str = "Data Source=" + va_nom_srv + "; Initial Catalog="
                    + va_nom_bdo + " ; user=" + va_cod_usr + "; password=" + va_pws_usr;
                va_cnx_cnx.ConnectionString = va_cad_str;
                gl_cnx_str = va_cad_str;
                va_cnx_cnx.Open();
            }
            return va_cnx_cnx;
        }

        /// <summary>
        /// Funcion Conexion durante todo el sistema
        /// </summary>
        public SqlConnection fu_cnx_cnx()
        {
            if (va_cnx_cnx.State == ConnectionState.Closed)
            {
                va_cad_str = gl_cnx_str ?? "";
                va_cnx_cnx.ConnectionString = va_cad_str;
                va_cnx_cnx.Open();
            }
            return va_cnx_cnx;
        }


        /// <summary>
        /// Cerrar Conexion
        /// </summary>
        public void mt_cer_cnx()
        {
            va_cnx_cnx.Close();
            va_cad_str = null;
        }


        /// <summary>
        /// Funcion que Ejecuta comando SQL
        /// </summary>
        /// <param name="va_cad_sql">Cadena SQL a ser ejecutada</param>
        public DataTable fu_exe_sql(string va_cad_sql)
        {
            DataTable tabla = new DataTable();

            if (va_cnx_cnx.State == ConnectionState.Closed)
            {
                fu_cnx_cnx();
            }

            SqlDataAdapter va_ada_ptr = new SqlDataAdapter(va_cad_sql, va_cnx_cnx);
            va_ada_ptr.Fill(tabla);

            return tabla;
        }
    }
}
