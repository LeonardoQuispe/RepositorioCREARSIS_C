using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace DATOS._7_ECP
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase PLAN DE PAGO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ecp005
    {
        /// <summary>
        /// Objeto del clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        /// Funcion "Buscar Plan de Pago"
        /// </summary>
        /// <param name="val_bus">Valor del busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Descripcion )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus, int tipo = 1)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ecp005 ");

                if (tipo == 1)
                {
                    switch (prm_bus)
                    {
                        case 1: vv_str_sql.AppendLine(" where va_cod_plg like '" + val_bus + "%' "); break;
                        case 2: vv_str_sql.AppendLine(" where va_des_plg like '" + val_bus + "%' "); break;
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
                    vv_str_sql.AppendLine(" where va_cod_plg = '" + val_bus + "' ");
                }

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void _02(int cod_plg, string des_pgl, int nro_cuo,int int_dia,int dia_ini)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ecp005 VALUES");
                vv_str_sql.AppendLine(" ('" + cod_plg + "', '" + des_pgl + "', '" + nro_cuo + "', '" + int_dia + "', '" + dia_ini + "', 'H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <param name="des_pgl">Descripcion</param>
        /// <returns></returns>
        public void _03(int cod_plg, string des_pgl, int nro_cuo,int int_dia,int dia_ini)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ecp005 SET");
                vv_str_sql.AppendLine(" va_des_plg='" + des_pgl + "', va_nro_cuo='" + nro_cuo + "',");
                vv_str_sql.AppendLine(" va_int_dia='" + int_dia + "', va_dia_ini='" + dia_ini + "' ");
                vv_str_sql.AppendLine(" WHERE va_cod_plg = '" + cod_plg + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <param name="est_ado">Estado del Plan de Pago</param>
        /// <returns></returns>
        public void _04(int cod_plg, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ecp005 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_plg = '" + cod_plg + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <returns></returns>
        public DataTable _05(int cod_plg)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM ecp005 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_plg = " + "'" + cod_plg + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <returns></returns>
        public void _06(int cod_plg)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ecp005 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_plg = '" + cod_plg + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
