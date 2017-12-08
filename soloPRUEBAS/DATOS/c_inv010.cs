using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    public class c_inv010
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
        /// Funcion "Buscar UNIDAD"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="est_bus">Parametro estado de busqueda (0=Todos; 1=Habilitado ; 2=Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv010  ");

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

        /// <summary>
        /// Registrar Grupo de Almacenes
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de Almacen (##-###) -> compuesto por (va_cod_suc , va_nro_gru)</param>
        /// <param name="cod_suc">Codigo de la sucursal al que pertenece el Grupo de almacen</param>
        /// <param name="nro_gru">Nro. de Grupo</param>
        /// <param name="nom_gru">Nombre del grupo</param>
        /// <param name="des_gru">Descripcion del grupo</param>
        /// <returns></returns>
        public DataTable _02(int cod_gru,int cod_suc,int nro_gru, string nom_gru, string des_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv010 VALUES");
                vv_str_sql.AppendLine(" (" + cod_gru + ", " + cod_suc + ", " + nro_gru + ",'" + nom_gru);
                vv_str_sql.AppendLine(" ','" + des_gru + "','H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica Grupo de Almacenes
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de Almacen (##-###) -> compuesto por (va_cod_suc , va_nro_gru)</param>
        /// <param name="cod_suc">Codigo de la sucursal al que pertenece el Grupo de almacen</param>
        /// <param name="nro_gru">Nro. de Grupo</param>
        /// <param name="nom_gru">Nombre del grupo</param>
        /// <param name="des_gru">Descripcion del grupo</param>
        /// <returns></returns>
        public DataTable _03(int cod_gru,string nom_gru, string des_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv010 SET");
                vv_str_sql.AppendLine(" va_cod_gru=" + cod_gru + ", va_nom_gru='" + nom_gru + "', ");
                vv_str_sql.AppendLine(" va_des_gru='" + des_gru + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Grupo de Almacenes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacenes</param>
        /// <param name="est_ado">Estado del Grupo de Almacenes</param>
        /// <returns></returns>
        public DataTable _04(string cod_gru, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv010 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "'");
                vv_str_sql.AppendLine(" WHERE  va_cod_gru = " + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Grupo de Almacenes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacenes</param>
        /// <returns></returns>
        public DataTable _05(string cod_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_gru =" + cod_mar);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Grupo de Almacenes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacenes</param>
        /// <returns></returns>
        public DataTable _06(string cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_gru =" + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
