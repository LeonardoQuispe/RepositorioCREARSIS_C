using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace DATOS._7_ECP
{
    public class c_ecp007
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
        /// <param name="cod_per">Codigo del Detalle</param>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo Persona ; 2=Nombre Persona 3=Codigo Libreta 4=Nombre Libreta)</param>
        /// <param name="est_bus">Estado de la Actividad (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
        /// <returns></returns>
        public DataTable _01(int cod_per, string val_bus, int prm_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("SELECT ecp006.va_cod_lib,va_des_lib,adm010.va_cod_per,va_nom_com,va_mto_lim,va_fec_exp FROM ecp006,ecp007,ecp005,adm010");
                vv_str_sql.AppendLine(" WHERE ecp007.va_cod_plg=ecp005.va_cod_plg ");
                vv_str_sql.AppendLine(" and va_cod_per =' " + cod_per + " '");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" and ecp007.va_cod_lib like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" and va_nom_lib like '" + val_bus + "%' "); break;
                    case 3: vv_str_sql.AppendLine(" and va_cod_per like '" + val_bus + "%' "); break;
                    case 4: vv_str_sql.AppendLine(" and va_nom_com like '" + val_bus + "%' "); break;

                }


                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Detalle"
        /// </summary>
        /// <param name="cod_per">Codigo del Detalle</param>
        /// <returns></returns>
        public DataTable _01(string cod_per, string cod_lib = "")
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("SELECT ecp006.va_cod_lib,va_des_lib,adm010.va_cod_per,va_nom_com,va_mto_lim,va_fec_exp FROM ecp006,ecp007,ecp005,adm010 ");
                vv_str_sql.AppendLine(" WHERE ecp007.va_cod_plg=ecp005.va_cod_plg ");
                vv_str_sql.AppendLine(" and adm010.va_cod_per='" + cod_per + "'");
                vv_str_sql.AppendLine(" and ecp006.va_cod_lib like '" + cod_lib + "%' ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void _02(int cod_lib, string cod_per, int cod_plg, Decimal mto_lim, Decimal sal_act, int max_cuo,DateTime fec_exp)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ecp007 VALUES ");

                vv_str_sql.AppendLine("(" + cod_lib + ", '" + cod_per + "', '" + cod_plg + "', '" + mto_lim + "',");
                vv_str_sql.AppendLine("'" + sal_act + "','" + max_cuo +  "','" + fec_exp.ToShortDateString() + "')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion Actualiza Detalle de Precios
        /// </summary>
        /// <param name="cod_per">Codigo del la lista(cmr001)</param>
        /// <param name="cod_lib">Codigo de Producto(ecp007)</param>
        /// <param name="pre_cio">Precio del Producto</param>
        /// <param name="pmx_des">Porcentaje maximo de descuento permitido</param>
        /// <param name="pmx_inc">Porcentaje maximo de incremento permitido</param>
        /// <param name="por_cal">Porcentaje de utilidad(Ganancia) calculado</param>
        /// <returns></returns>
        public void _03(int cod_per, string cod_lib, decimal pre_cio, decimal pmx_des, decimal pmx_inc, decimal por_cal)
        {
            {
                try
                {
                    vv_str_sql = new StringBuilder();
                    vv_str_sql.AppendLine(" UPDATE cmr002 SET ");

                    vv_str_sql.AppendLine(" va_pre_cio='" + pre_cio + "', va_pmx_des='" + pmx_des + "',");
                    vv_str_sql.AppendLine(" va_por_cal='" + por_cal + "'");
                    vv_str_sql.AppendLine(" WHERE va_cod_per = " + cod_per);
                    vv_str_sql.AppendLine(" and va_cod_lib= '" + cod_lib + "'");

                    o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        /// <summary>
        /// funcion "Consulta Detalle"
        /// </summary>
        /// <param name="cod_per">Codigo del Detalle</param>
        /// <returns></returns>
        public DataTable _05(string cod_per, string cod_lib,int cod_plg)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("SELECT ecp006.va_cod_lib,va_des_lib,adm010.va_cod_per,va_nom_com,va_mto_lim,va_fec_exp FROM ecp006,ecp007,ecp005,adm010 ");
                vv_str_sql.AppendLine(" WHERE ecp007.va_cod_plg='" + cod_plg+"'");
                vv_str_sql.AppendLine(" and adm010.va_cod_per='" + cod_per + "'");
                vv_str_sql.AppendLine(" and ecp006.va_cod_lib like '" + cod_lib + "%' ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion Elimina Producto de Detalle
        /// </summary>
        /// <param name="cod_per">Codigo del la lista(cmr001)</param>
        /// <param name="cod_lib">Codigo de Producto(ecp007)</param>
        /// <returns></returns>
        public void _06(string cod_per, string cod_lib)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE cmr002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_per + "'");
                vv_str_sql.AppendLine(" AND va_cod_lib='" + cod_lib + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
