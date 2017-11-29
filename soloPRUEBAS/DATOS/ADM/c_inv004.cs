using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS.ADM
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase MARCAS
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_inv004
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
        /// Funcion "Buscar MARCA"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv004  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_mar like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_mar like '" + val_bus + "%' "); break;
                }

                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    vv_str_sql.AppendLine(" and va_est_ado ='" + est_bus + "'");
                }

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Registrar MARCA"
        /// </summary>
        /// <param name="cod_mar">Codigo de la Marca</param>
        /// <param name="nom_mar">Nombre de la Marca</param>
        /// <returns></returns>
        public DataTable _02(int cod_mar, string nom_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv004 VALUES");
                vv_str_sql.AppendLine(" (" + cod_mar + ", '" + nom_mar + "', 'H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica MARCA"
        /// </summary>
        /// <param name="cod_mar">Codigo de la Marca</param>
        /// <param name="nom_mar">Nombre de la Marca</param>
        /// <returns></returns>
        public DataTable _03(int cod_mar, string nom_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv004 SET");
                vv_str_sql.AppendLine(" va_nom_mar='" + nom_mar + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_mar =" + cod_mar);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita MARCA"
        /// </summary>
        /// <param name="cod_mar">Codigo de la Marca</param>
        /// <param name="est_ado">Estado de la Marca</param>
        /// <returns></returns>
        public DataTable _04(int cod_mar, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv004 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mar =" + cod_mar);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta MARCA"
        /// </summary>
        /// <param name="cod_mar">Codigo de la Marca</param>
        /// <returns></returns>
        public DataTable _05(int cod_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mar = " + cod_mar);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina MARCA"
        /// </summary>
        /// <param name="cod_mar">Codigo de la Marca</param>
        /// <returns></returns>
        public DataTable _06(int cod_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mar = " + cod_mar);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
