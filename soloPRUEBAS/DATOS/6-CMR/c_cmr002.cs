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
        /// Funcion Nueva Lista de Precios
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <param name="mon_lis"></param>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <returns></returns>

        /// <summary>
        /// funcion "Consulta Detalle"
        /// </summary>
        /// <param name="cod_lis">Codigo de la Detalle</param>
        /// <returns></returns>
        public DataTable _01(int cod_lis, string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT inv002.va_cod_pro,va_nom_pro,va_pre_cio,va_est_ado,va_cod_lis FROM cmr002,inv002 ");
                vv_str_sql.AppendLine(" WHERE cmr002.va_cod_pro=inv002.va_cod_pro ");
                vv_str_sql.AppendLine(" and va_cod_lis =' " + cod_lis + " '");
                
                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" and inv002.va_cod_pro like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" and va_nom_pro like '" + val_bus + "%' "); break;

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
        /// funcion "Consulta Detalle"
        /// </summary>
        /// <param name="cod_lis">Codigo de la Detalle</param>
        /// <returns></returns>
        public DataTable _01(string cod_lis)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT inv002.va_cod_pro,va_nom_pro,va_pre_cio,va_est_ado,va_cod_lis FROM cmr002,inv002 ");
                vv_str_sql.AppendLine(" WHERE cmr002.va_cod_pro=inv002.va_cod_pro ");
                vv_str_sql.AppendLine(" and va_cod_lis =' " + cod_lis + " '");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable _02(int cod_lis, string cod_pro, int pre_cio, int pmx_des, int pmx_inc, int por_cal)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO cmr002 VALUES ");

                vv_str_sql.AppendLine("(" + cod_lis + ", '" + cod_pro + "', '" + pre_cio+ "', '" + pmx_des + "',");
                vv_str_sql.AppendLine("'" + pmx_inc + "','" + por_cal + "')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
