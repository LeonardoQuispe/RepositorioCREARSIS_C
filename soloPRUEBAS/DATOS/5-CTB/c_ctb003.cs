using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._5_CTB
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase CENTRO DE COSTOS
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb003
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
        /// Funcion "Buscar Centro de Costos"
        /// </summary>
        /// <param name="val_bus">Valor del busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (0=codigo ; 1=Nombre )</param>
        /// <param name="est_bus">Estado de la Búsqueda (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ctb003 ");

                switch (prm_bus)
                {
                    case 0: vv_str_sql.AppendLine(" where va_cod_cct like '" + val_bus + "%' "); break;
                    case 1: vv_str_sql.AppendLine(" where va_nom_cct like '" + val_bus + "%' "); break;
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

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar Centro de Costos
        /// </summary>
        /// <param name="cod_cct">Codigo del centro de Costos (3 numeros)</param>
        /// <param name="nom_cct">Nombre del centro de Costos</param>
        /// <param name="tip_cct">Tipo del centro de Costos (M=Matriz; A=Analitica)</param>
        public void _02(int cod_cct, string nom_cct,string tip_cct)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ctb003 VALUES");
                vv_str_sql.AppendFormat(" ({0},'{1}','{2}','H')", cod_cct, nom_cct, tip_cct);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MODIFICA Centro de Costos
        /// </summary>
        /// <param name="cod_cct">Codigo del centro de Costos (3 numeros)</param>
        /// <param name="nom_cct">Nombre del centro de Costos</param>
        public void _03(int cod_cct, string nom_cct)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb003 SET");
                vv_str_sql.AppendFormat(" va_nom_cct='{0}'", nom_cct);
                vv_str_sql.AppendFormat(" WHERE va_cod_cct={0}", cod_cct);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Centro de Costos"
        /// </summary>
        /// <param name="cod_cct">Codigo de la Centro de Costos</param>
        /// <param name="est_ado">Estado de la Centro de Costos</param>
        /// <returns></returns>
        public void _04(int cod_cct, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb003 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cct =" + cod_cct);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Centro de Costos"
        /// </summary>
        /// <param name="cod_cct">Codigo de la Centro de Costos</param>
        /// <returns></returns>
        public DataTable _05(int cod_cct)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ctb003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cct =" + cod_cct);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Centro de Costos"
        /// </summary>
        /// <param name="cod_cct">Codigo del Centro de Costos</param>
        /// <returns></returns>
        public void _06(int cod_cct)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ctb003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cct =" + cod_cct);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
