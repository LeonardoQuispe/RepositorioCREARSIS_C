using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._3_SEG
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Permiso Usuario sobre Grupo de Almacén
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_seg025
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
        /// Funcion "Guarda Permisos"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <param name="cod_gru">Codigo del Grupo de Almacén</param>
        /// <returns></returns>
        public void _02(string cod_usr, int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg025 values  ");
                vv_str_sql.AppendFormat(" ('{0}',{1})", cod_usr, cod_gru);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Permisos de Usuario sobre Grupo de Almacén"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <returns></returns>
        public DataTable _05(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT va_cod_gru FROM seg025 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_usr = '" + cod_usr + "' ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Funcion "Elimina Permisos de Usuario sobre Grupo de Almacén"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <returns></returns>
        public void _06(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendFormat(" DELETE FROM seg025 WHERE va_cod_usr='{0}'", cod_usr);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
