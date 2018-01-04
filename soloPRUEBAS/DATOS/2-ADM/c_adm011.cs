﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase GRUPO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm011
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
        /// Funcion "BUSCAR GRUPO DE PERSONA autorizadas"
        /// </summary>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from adm011  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_gru like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_gru like '" + val_bus + "%' "); break;

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
        //public DataTable _01(string cod_usr)
        //{
        //    try
        //    {
        //        vv_str_sql = new StringBuilder();
        //        vv_str_sql.AppendLine(" SELECT seg022.va_cod_usr , adm011.va_cod_gru, adm011.va_nom_gru  ");
        //        vv_str_sql.AppendLine(" FROM adm011, seg022");
        //        vv_str_sql.AppendLine(" WHERE adm011.va_cod_gru = seg022.va_cod_gru	AND");
        //        vv_str_sql.AppendLine(" va_cod_usr ='" + cod_usr + "' ");

        //        return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        /// <summary>
        /// Funcion "Registrar GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de persona</param>
        /// <param name="nom_gru">nombre del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _02(int cod_gru, string nom_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm011 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_gru + ", '" + nom_gru + "','H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica Grupo de Persona"
        /// </summary>
        /// <param name="cod_gru">Codigo de actividad</param>
        /// <param name="nom_gru">nombre de actividad</param>
        /// <returns></returns>
        public DataTable _03(int cod_gru, string nom_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm011 SET ");
                vv_str_sql.AppendLine(" va_nom_gru='" + nom_gru + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_gru =" + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Grupo de Persona"
        /// </summary>
        /// <param name="cod_per">Codigo de Actividad</param>
        /// <param name="est_ado">Estado de Actividad</param>
        /// <remarks></remarks>
        public object _04(int cod_gru, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm011 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_gru = '" + cod_gru + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion consultar "GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm011   ");
                vv_str_sql.AppendLine(" WHERE va_cod_gru ='" + cod_gru + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina GRUPO DE PERSONA DEL SISTEMA"
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _06(string cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm011 ");
                vv_str_sql.AppendLine(" WHERE va_cod_gru ='" + cod_gru + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}