using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._6_CMR
{
    public class c_cmr002
    {
        /// <summary>
        /// Objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        /// funcion "Consulta familia de producto"
        /// </summary>
        /// <param name="cod_lis">Codigo de la familia de producto</param>
        /// <returns></returns>
        public DataTable _05(string cod_lis)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM cmr002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lis = " + "'" + cod_lis + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
