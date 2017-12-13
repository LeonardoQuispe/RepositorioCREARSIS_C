using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///Clase GESTION/PERIODO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm002
    {
        /// <summary>
        /// Objeto de la clase conexión
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql=new StringBuilder();

        /// <summary>
        /// Funcion "Buscar GESTION/PERIODOS"
        /// </summary>
        /// <param name="cod_ges">Gestion, 0=todas ; 2016=gestion 2016 ; 2017=gestion 2017</param>
        /// <param name="val_bus">Valor de busqueda para Periodo/Gestion</param>
        /// <param name="prm_bus">Parametro de busqueda, 1=Nombr</param>
        /// <returns></returns>
        public DataTable _01(int cod_ges, string val_bus, string prm_bus)
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE adm002_01p1 ");
                vv_str_sql.AppendLine(" " + cod_ges + ",'" + val_bus + "', " + prm_bus + " ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Registrar GESTION/PERIODO"
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <param name="prd_ges">Periodo de la Gestion</param>
        /// <param name="nom_prd">Nombre del Periodo</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable _02(int cod_ges, int prd_ges, string nom_prd, DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm002 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_ges + "," + prd_ges + ", '" + nom_prd + "' , '" + fec_ini.ToShortDateString() + "','" + fec_fin.ToShortDateString() + "', 'V' )");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica GESTION/PERIODO"
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <param name="prd_ges">Periodo de la Gestion</param>
        /// <param name="nom_prd">Nombre del Periodo</param>
        /// <param name="fec_ini">Fecha inicial</param>
        /// <param name="fec_fin">Fecha final</param>
        /// <returns></returns>
        public DataTable _03(int cod_ges, int prd_ges, string nom_prd, DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                vv_str_sql.AppendLine(" UPDATE adm002 SET ");
                vv_str_sql.AppendLine(" va_nom_prd='" + nom_prd + "' , va_fec_ini= '" + fec_ini + "', va_fec_fin= '" + fec_fin + "' ");
                vv_str_sql.AppendLine(" WHERE va_cod_ges = " + cod_ges + " AND va_prd_ges = " + prd_ges);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Apertua/Cierre/Reapertura/Restaura GESTION/PERIODO" (Cierra/Reapertura)
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <param name="prd_ges">Periodo de la gestion (1-12)</param>
        /// <param name="est_ado">Estado, V=Valido(abierto) ; E=en proceso ; C=Cerrado ; </param>
        /// <returns></returns>
        public DataTable _03(int cod_ges, int prd_ges, string est_ado)
        {
            try
            {
                vv_str_sql.AppendLine("UPDATE adm002 SET ");
                vv_str_sql.AppendLine("va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE va_cod_ges = " + cod_ges + " AND va_prd_ges = " + prd_ges);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta GESTION/PERIODO
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <param name="prd_ges">Periodo de la gestion</param>
        /// <returns></returns>
        public DataTable _05(int cod_ges, int prd_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm002 ");
                vv_str_sql.AppendLine(" WHERE va_cod_ges = " + cod_ges + " AND va_prd_ges = " + prd_ges);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Consulta una GESTION
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <returns></returns>
        public DataTable _05(int cod_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm002 ");
                vv_str_sql.AppendLine(" WHERE va_cod_ges = " + cod_ges + "");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Consulta GESTIONES registradas agrupadas
        /// </summary>
        /// <returns></returns>
        public DataTable _05()
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT va_cod_ges FROM  adm002 ");
                vv_str_sql.AppendLine(" GROUP BY va_cod_ges ");
                vv_str_sql.AppendLine(" ORDER BY va_cod_ges DESC");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Elimina GESTION/PERIODO
        /// </summary>
        /// <param name="cod_ges">Gestion</param>
        /// <param name="prd_ges">Periodo de la gestion</param>
        /// <returns></returns>
        public DataTable _06(int cod_ges, int prd_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("DELETE adm002 ");
                vv_str_sql.AppendLine(" WHERE va_cod_ges = " + cod_ges + " AND va_prd_ges = " + prd_ges);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Procedimiento reporte "periodos de una gestión"
        /// </summary>
        /// <param name="cod_ges">Codigo de gestión</param>
        /// <returns></returns>
        public DataTable R_01p1(int cod_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("Exec adm002_01p1_R ");
                vv_str_sql.AppendLine(cod_ges.ToString());

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
