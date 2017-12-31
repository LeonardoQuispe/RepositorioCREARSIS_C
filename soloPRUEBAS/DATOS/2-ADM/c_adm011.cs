using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase TIPO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm011
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
        /// Funcion "BUSCAR TIPO DE PERSONA autorizadas"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <returns></returns>
        public DataTable _01(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT seg022.va_cod_usr , adm011.va_cod_tpr, adm011.va_nom_tpr  ");
                vv_str_sql.AppendLine(" FROM adm011, seg022");
                vv_str_sql.AppendLine(" WHERE adm011.va_cod_tpr = seg022.va_cod_tpr	AND");
                vv_str_sql.AppendLine(" va_cod_usr ='" + cod_usr + "' ");

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
        /// <param name="cod_tpr">Codigo del tipo de persona</param>
        /// <param name="nom_tpr">nombre del tipo de persona</param>
        /// <returns></returns>
        public DataTable _02(int cod_tpr, string nom_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm011 VALUES ");
                vv_str_sql.AppendLine(" ('" + cod_tpr + "','" + cod_tpr + "' )");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion consultar "TIPO DE PERSONA"
        /// </summary>
        /// <param name="cod_tpr">codigo del tipo de persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm011   ");
                vv_str_sql.AppendLine(" WHERE va_cod_tpr ='" + cod_tpr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina TIPO DE PERSONA DEL SISTEMA"
        /// </summary>
        /// <param name="cod_tpr">Codigo del tipo de persona</param>
        /// <returns></returns>
        public DataTable _06(string cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm011 ");
                vv_str_sql.AppendLine(" WHERE va_cod_tpr ='" + cod_tpr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
