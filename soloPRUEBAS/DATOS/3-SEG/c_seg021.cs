using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Permiso sobre APPs DEL SISTEMA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_seg021
    {
        /// <summary>
        /// objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        ///  Funcion "BUSCAR RESTRICCIONES DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <returns></returns>
        public DataTable _01(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg020   ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='" + cod_usr + "' ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Registrar RESTRICCION DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario </param>
        /// <param name="cod_win">Codigo de la aplicacion</param>
        /// <param name="cod_mnu"></param>
        /// <returns></returns>
        public void _02(string cod_usr, string cod_win, string cod_mnu)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg020 VALUES ");
                vv_str_sql.AppendLine(" ('" + cod_usr + "','" + cod_win + "','" + cod_mnu + "' )");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion consultar "APLICACIONES DEL SISTEMA AUTORIZADAS P/USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="cod_app">codigo de la aplicacion</param>
        public DataTable _05(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg021   ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='"+cod_usr+"'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina OPCION DEL MENU P/USUARIO (otorga permiso)"
        /// </summary>
        /// <param name="cod_usr">odigo de usuario</param>
        /// <param name="cod_win">Codigo de la aplicacion</param>
        /// <param name="cod_mnu"></param>
        /// <returns></returns>
        public void _06(string cod_usr, string cod_win, string cod_mnu)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE seg020 ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='" + cod_usr + "' AND va_cod_win ='" + cod_win + "' ");
                vv_str_sql.AppendLine(" AND va_cod_mnu ='" + cod_mnu + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

