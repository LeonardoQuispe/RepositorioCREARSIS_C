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
                    case 1: vv_str_sql.AppendLine(" where va_cod_tpr like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_tpr like '" + val_bus + "%' "); break;

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
        
        //}
        /// <summary>
        /// Funcion "Registrar GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_tpr">Codigo del GRUPO de persona</param>
        /// <param name="nom_tpr">nombre del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _02(int cod_tpr, string nom_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm011 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_tpr + ", '" + nom_tpr + "','H')");

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
        /// <param name="cod_tpr">Codigo de actividad</param>
        /// <param name="nom_tpr">nombre de actividad</param>
        /// <returns></returns>
        public DataTable _03(int cod_tpr, string nom_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm011 SET ");
                vv_str_sql.AppendLine(" va_nom_tpr='" + nom_tpr + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_tpr =" + cod_tpr);

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
        public object _04(int cod_tpr, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm011 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_tpr = '" + cod_tpr + "'");

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
        /// <param name="cod_tpr">codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _05(int cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm011   ");
                vv_str_sql.AppendLine(" WHERE va_cod_tpr ='" + cod_tpr + "' ");

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
        /// <param name="cod_tpr">Codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _06(int cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm011 ");
                vv_str_sql.AppendLine(" WHERE va_cod_tpr ='" + cod_tpr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
