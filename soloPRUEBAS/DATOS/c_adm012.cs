using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace DATOS.ADM
{
    public class c_adm012
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
        /// <param name="est_bus"></param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from adm012  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_act like '" + val_bus + "%' "); break;

                    case 2: vv_str_sql.AppendLine(" where va_nom_act like '" + val_bus + "%'"); break;
                }

                switch (est_bus)
                {
                    case "1": vv_str_sql.AppendLine(" and va_est_ado ='H'"); break;

                    case "2": vv_str_sql.AppendLine(" and va_est_ado ='N'"); break;
                }                

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cod_act"></param>
        /// <param name="nom_act"></param>
        /// <returns></returns>
        public DataTable _02(int cod_act, string nom_act)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm012 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_act + ", '" + nom_act + "','H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica actividad economica"
        /// </summary>
        /// <param name="cod_act">Codigo de actividad</param>
        /// <param name="nom_act">nombre de actividad</param>
        /// <returns></returns>
        public DataTable _03(int cod_act, string nom_act)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm012 SET ");
                vv_str_sql.AppendLine(" va_nom_act='" + nom_act + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_act =" + cod_act);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita Actividad Economica"
        /// </summary>
        /// <param name="cod_per">Codigo de Actividad</param>
        /// <param name="est_ado">Estado de Actividad</param>
        /// <remarks></remarks>
        public object _04(string cod_act, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm012 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_act = '" + cod_act + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// funcion "Consulta persona"
        /// </summary>
        /// <param name="cod_act">codigo del Actividad</param>
        /// <returns></returns>
        public DataTable _05(string cod_act)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm012 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_act =" + cod_act);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Actividad"
        /// </summary>
        /// <param name="cod_act">Codigo de Actividad</param>
        /// <returns></returns>
        public DataTable _06(string cod_act)
        {
            try
            {
                vv_str_sql = new StringBuilder();

                vv_str_sql.AppendLine(" DELETE adm012 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_act = '" + cod_act + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
