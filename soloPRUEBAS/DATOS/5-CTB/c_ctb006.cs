using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase LEYENDA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb006
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
        /// 
        /// </summary>
        /// <param name="val_bus"></param>
        /// <param name="prm_bus"></param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ctb006 ");

                if (prm_bus == 1)
                {
                    vv_str_sql.AppendLine(" where va_cod_ley like '" + val_bus + "%' ");
                }
                if (prm_bus == 2)
                {
                    vv_str_sql.AppendLine(" where va_nom_ley like '" + val_bus + "%'");
                }
                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Elimina e Insertar Leyenda
        /// </summary>
        /// <returns></returns>
        public DataTable _02()
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE ctb006_02p1");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Eliminar Leyenda
        /// </summary>
        /// <returns></returns>
        public DataTable _06()
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE from ctb006");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Leyenda"
        /// </summary>
        /// <param name="nro_dos">Codigo de la dosificacion</param>
        /// <returns></returns>
        public DataTable _05(string cod_ley)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ctb006 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_ley = " + cod_ley);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
