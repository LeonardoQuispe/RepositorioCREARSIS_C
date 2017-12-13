using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Permiso sobre TIPO DE PERSONA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_seg022
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
        ///  Funcion "BUSCAR TIPO DE PERSONA autorizadas"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <returns></returns>
        public DataTable _01(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg022   ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='" + cod_usr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Registrar TIPO DE PERSONADEL"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="cod_tpr">Codigo del tipo de persona</param>
        /// <returns></returns>
        public DataTable _02(int cod_usr, string cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg022 VALUES ");
                vv_str_sql.AppendLine(" ('" + cod_usr + "','" + cod_tpr + "' )");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  Funcion consultar "TIPO DE PERSONA" autorizada
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="cod_tpr">codigo del tipo de persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_usr, string cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg022   ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='" + cod_usr + "' AND va_cod_tpr ='" + cod_tpr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  Funcion "Elimina TIPO DE PERSONADEL SISTEMA"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="cod_tpr">Codigo del tipo de persona</param>
        /// <returns></returns>
        public DataTable _06(int cod_usr, string cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE seg022 ");
                vv_str_sql.AppendLine(" WHERE va_cod_usr ='" + cod_usr + "' AND va_cod_tpr ='" + cod_tpr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
