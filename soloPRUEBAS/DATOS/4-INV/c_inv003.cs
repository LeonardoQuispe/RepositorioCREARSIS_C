using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase UNIDADES DE MEDIDA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_inv003
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
        /// Funcion "Buscar UNIDAD"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus, int tipo = 1)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv003  ");

                if (tipo == 1)
                {
                    switch (prm_bus)
                    {
                        case 1: vv_str_sql.AppendLine(" where va_cod_umd like '" + val_bus + "%' "); break;
                        case 2: vv_str_sql.AppendLine(" where va_nom_umd like '" + val_bus + "%' "); break;
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
                }
                else if (tipo == 2)
                {
                    vv_str_sql.AppendLine(" where va_cod_umd = '" + val_bus + "' ");
                }

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Registrar UNIDAD"
        /// </summary>
        /// <param name="cod_umd">Codigo de la Unidad</param>
        /// <param name="nom_umd">Nombre de la Unidad</param>
        /// <returns></returns>
        public void _02(string cod_umd, string nom_umd)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv003 VALUES");
                vv_str_sql.AppendLine(" ('" + cod_umd + "', '" + nom_umd + "', 'H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica UNIDAD"
        /// </summary>
        /// <param name="cod_umd">Codigo de la Unidad</param>
        /// <param name="nom_umd">Nombre de la Unidad</param>
        /// <returns></returns>
        public void _03(string cod_umd, string nom_umd)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv003 SET");
                vv_str_sql.AppendLine(" va_nom_umd='" + nom_umd + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_umd = '" + cod_umd + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita UNIDAD"
        /// </summary>
        /// <param name="cod_umd">Codigo de la Unidad</param>
        /// <param name="est_ado">Estado de la Unidad</param>
        /// <returns></returns>
        public void _04(string cod_umd, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv003 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_umd = '" + cod_umd + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta UNIDAD"
        /// </summary>
        /// <param name="cod_umd">Codigo de la Unidad</param>
        /// <returns></returns>
        public DataTable _05(string cod_umd)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_umd = " + "'" + cod_umd + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina UNIDAD"
        /// </summary>
        /// <param name="cod_umd">Codigo de la Unidad</param>
        /// <returns></returns>
        public void _06(string cod_umd)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_umd = '" + cod_umd + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
