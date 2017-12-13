using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase LICENCIA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_seg049
    {
        // create table seg049
        // (
        // va_fec_fin        NVARCHAR(20),    --Fecha encriptada
        // va_ult_fec        DATE            --Ultima fecha en la que se ingreso para validar
        //                                -- que el usuario no cambie la contrase�a para burlar la licencia
        // )
        // go
        // --hace referencia a 01/01/2000
        // insert into tbo_as001 values ('b0-01-i3-01-11-7D0','01/01/2000')

        /// <summary>
        /// objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        /// Funcion "Buscar LICENCIAS"
        /// </summary>
        /// <returns></returns>
        public DataTable _01()
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg049");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Registrar LICENCIA"
        /// </summary>
        /// <param name="fec_fin">Fecha de caducidad del sistema</param>
        /// <returns></returns>
        public DataTable _02(string fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg049 VALUES ") ;
                vv_str_sql.AppendLine(" ('" + fec_fin + "')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable _03(string fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg049 SET ");
                vv_str_sql.AppendLine(" va_fec_fin='" + fec_fin + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
