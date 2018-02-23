using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase T.C. Bs/Ufv 
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb001
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
                vv_str_sql.AppendLine(" select * from ctb001  ");
                if (prm_bus == 1)
                {
                    vv_str_sql.AppendLine(" where va_cod_rgn =" + val_bus + "");
                }
                else
                {
                    vv_str_sql.AppendLine(" where va_nom_rgn like '" + val_bus + "%'");
                }

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "inserta nueva regional"
        /// </summary>
        /// <param name="cod_rgn"></param>
        /// <param name="nom_rgn"></param>
        /// <returns></returns>
        public void _02(int cod_rgn, string nom_rgn)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ctb001 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_rgn + ", '" + nom_rgn + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica regional"
        /// </summary>
        /// <param name="cod_rgn">Codigo de regional</param>
        /// <param name="nom_rgn">nombre de regional</param>
        /// <returns></returns>
        public void _03(int cod_rgn, string nom_rgn)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb001 SET ");
                vv_str_sql.AppendLine(" va_nom_rgn='" + nom_rgn + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_rgn =" + cod_rgn);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta regional"
        /// </summary>
        /// <param name="cod_rgn">Codigo de la regional</param>
        /// <returns></returns>
        public DataTable _05(string cod_rgn)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ctb001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_rgn =" + cod_rgn);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina regional"
        /// </summary>
        /// <param name="cod_rgn">Codigo de regional</param>
        /// <returns></returns>
        public void _06(string cod_rgn)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ctb001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_rgn = '" + cod_rgn + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

