using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._6_CMR
{
    public class c_cmr001
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
        /// Cadena de comando sql
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="est_bus">Estado de la Actividad (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from cmr001  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_lis like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_lis like '" + val_bus + "%' "); break;

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
        /// Funcion Nueva Lista de Precios
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <param name="mon_lis"></param>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <returns></returns>
        public DataTable _02(int cod_lis,string nom_lis,string mon_lis, DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO cmr001 VALUES ");

                switch (mon_lis)
                {
                    case "0": mon_lis = "B"; break;
                    case "1": mon_lis = "U"; break;
                }

                vv_str_sql.AppendLine("(" + cod_lis + ", '"+ nom_lis + "', '" + mon_lis+ "',");
                vv_str_sql.AppendLine("'"+fec_ini.ToShortDateString() + "','" + fec_fin.ToShortDateString() + "','H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion Actualiza Lista de Precios
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <param name="mon_lis"></param>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <returns></returns>
        public DataTable _03(int cod_lis, string nom_lis, string mon_lis, DateTime fec_ini, DateTime fec_fin)
        {
            {
                try
                {
                    vv_str_sql = new StringBuilder();
                    vv_str_sql.AppendLine(" UPDATE cmr001 SET ");
                    switch (mon_lis)
                    {
                        case "0": mon_lis = "B"; break;
                        case "1": mon_lis = "U"; break;
                    }
                    vv_str_sql.AppendLine(" va_nom_lis='" + nom_lis + "', va_mon_lis='" + mon_lis + "',");
                    vv_str_sql.AppendLine(" va_fec_ini='" + fec_ini.ToShortDateString() + "', va_fec_fin='" + fec_fin.ToShortDateString()+"'");
                    vv_str_sql.AppendLine(" WHERE va_cod_lis = " + cod_lis );

                    return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita  Lista de Precios"
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <param name="est_ado"></param>
        /// <returns></returns>
        public DataTable _04(string cod_lis, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE cmr001 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lis = '" + cod_lis + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Lista de Precios"
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <returns></returns>
        public DataTable _05(string cod_lis)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM cmr001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lis ='" + cod_lis+"' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Lista de Precios"
        /// </summary>
        /// <param name="cod_lis"></param>
        /// <returns></returns>
        public DataTable _06(string cod_lis)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE cmr001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lis = '" + cod_lis + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
