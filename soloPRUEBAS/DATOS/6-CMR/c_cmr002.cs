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
        /// Funcion Buscar Detalle de Precio
        /// </summary>
        /// <param name="cod_lis">Codigo del Detalle</param>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="est_bus">Estado de la Actividad (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
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
        /// <param name="cod_lis">Codigo del Detalle</param>
        /// <returns></returns>
        public DataTable _01(string cod_lis,string cod_pro="")
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT cmr001.va_cod_lis,va_nom_lis,inv002.va_cod_pro,va_nom_pro,va_pre_cio,va_pmx_des,va_pmx_inc,va_por_cal,inv002.va_est_ado FROM cmr001,cmr002,inv002 ");
                vv_str_sql.AppendLine(" WHERE cmr002.va_cod_pro=inv002.va_cod_pro ");
                vv_str_sql.AppendLine(" and cmr002.va_cod_lis=cmr001.va_cod_lis ");
                vv_str_sql.AppendLine(" and cmr002.va_cod_lis ='" + cod_lis + "'");
                vv_str_sql.AppendLine(" and inv002.va_cod_pro like '" + cod_pro + "%' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion Inserta Detalle de Precios
        /// </summary>
        /// <param name="cod_lis">Codigo del la lista(cmr001)</param>
        /// <param name="cod_pro">Codigo de Producto(inv002)</param>
        /// <param name="pre_cio">Precio del Producto</param>
        /// <param name="pmx_des">Porcentaje maximo de descuento permitido</param>
        /// <param name="pmx_inc">Porcentaje maximo de incremento permitido</param>
        /// <param name="por_cal">Porcentaje de utilidad(Ganancia) calculado</param>
        /// <returns></returns>
        public DataTable _02(int cod_lis, string cod_pro, decimal pre_cio, decimal pmx_des, decimal pmx_inc, decimal por_cal)
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

        /// <summary>
        /// Funcion Actualiza Detalle de Precios
        /// </summary>
        /// <param name="cod_lis">Codigo del la lista(cmr001)</param>
        /// <param name="cod_pro">Codigo de Producto(inv002)</param>
        /// <param name="pre_cio">Precio del Producto</param>
        /// <param name="pmx_des">Porcentaje maximo de descuento permitido</param>
        /// <param name="pmx_inc">Porcentaje maximo de incremento permitido</param>
        /// <param name="por_cal">Porcentaje de utilidad(Ganancia) calculado</param>
        /// <returns></returns>
        public DataTable _03(int cod_lis, string cod_pro, decimal pre_cio, decimal pmx_des, decimal pmx_inc, decimal por_cal)
        {
            {
                try
                {
                    vv_str_sql = new StringBuilder();
                    vv_str_sql.AppendLine(" UPDATE cmr002 SET ");
                   
                    vv_str_sql.AppendLine(" va_pre_cio='" + pre_cio + "', va_pmx_des='" + pmx_des + "',");
                    vv_str_sql.AppendLine(" va_por_cal='" + por_cal + "'");
                    vv_str_sql.AppendLine(" WHERE va_cod_lis = " + cod_lis);
                    vv_str_sql.AppendLine(" and va_cod_pro= '" + cod_pro + "'");

                    return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        /// <summary>
        /// Funcion Elimina Producto de Detalle
        /// </summary>
        /// <param name="cod_lis">Codigo del la lista(cmr001)</param>
        /// <param name="cod_pro">Codigo de Producto(inv002)</param>
        /// <returns></returns>
        public DataTable _06(string cod_lis,string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE cmr002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lis = '" + cod_lis + "'");
                vv_str_sql.AppendLine(" AND va_cod_pro='" + cod_pro + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
