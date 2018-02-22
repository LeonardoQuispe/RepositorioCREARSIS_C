using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._3_SEG
{
    public class c_seg002
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
        /// Funcion "Buscar Modulos del Sistema"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from seg002  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_mod like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_mod like '" + val_bus + "%' "); break;
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
        /// funcion "Registrar Modulos del Sistema"
        /// <param name="cod_mod">Codigo de la Modulos del Sistema</param>
        /// <param name="nom_mar">Nombre de la Modulos del Sistema</param>
        /// <param name="des_mod">Descripcion</param>
        /// <returns></returns>
        public void _02(int cod_mod, string nom_mod,string des_mod)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg002 VALUES");
                vv_str_sql.AppendLine(" (" + cod_mod + ", '" + nom_mod + "',' "+ des_mod + "', 'H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica Modulos del Sistema"
        /// </summary>
        /// <param name="cod_mod">Codigo de la Modulos del Sistema</param>
        /// <param name="nom_mar">Nombre de la Modulos del Sistema</param>
        /// <param name="des_mod">Descripcion</param>
        public void _03(int cod_mod, string nom_mod, string des_mod)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg002 SET");
                vv_str_sql.AppendLine(" va_nom_mod='" + nom_mod + "',va_des_mod='"+des_mod+"' ");
                vv_str_sql.AppendLine(" WHERE va_cod_mod =" + cod_mod);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Modulos del Sistema"
        /// </summary>
        /// <param name="cod_mod">Codigo de la Modulos del Sistema</param>
        /// <param name="est_ado">Estado de la Modulos del Sistema</param>
        /// <returns></returns>
        public void _04(int cod_mod, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg002 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mod =" + cod_mod);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Modulos del Sistema"
        /// </summary>
        /// <param name="cod_mod">Codigo de la Modulos del Sistema</param>
        /// <returns></returns>
        public DataTable _05(int cod_mod)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM seg002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mod = " + cod_mod);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Modulos del Sistema"
        /// </summary>
        /// <param name="cod_mod">Codigo de la Modulos del Sistema</param>
        /// <returns></returns>
        public void _06(int cod_mod)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE seg002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_mod = " + cod_mod);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
