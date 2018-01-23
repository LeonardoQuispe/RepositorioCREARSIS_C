using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase NUMERADORES DE TALONARIOS
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm005
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
        /// Funcion "Buscar NUMERADORES TALONARIO"
        /// </summary>
        /// <param name="cod_ges">Codigo del Modulo</param>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo Doc ; 2=Nombre Doc ; 3=Nro Talonaio, 4=Nombre Talonario)</param>
        /// <returns></returns>
        public DataTable _01(int cod_ges, string val_bus, int prm_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE adm005_01p1");
                vv_str_sql.AppendLine("  '" + val_bus + "', " + prm_bus + ", " + cod_ges + " ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Nueva NUMERACION
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <param name="cod_ges">Codigo de la gestion</param>
        /// <param name="nro_ini">Numero inicial para el talonario</param>
        /// <param name="nro_fin">Numero fianl para el talonario</param>
        /// <param name="fec_ini">Fecha inicial para el talonario</param>
        /// <param name="fec_fin">Fecha final para el talonario</param>
        /// <param name="con_tad">Contador del talonario</param>
        /// <returns></returns>
        public void _02(string cod_doc, int nro_tal, int cod_ges, int nro_ini,
            int nro_fin, DateTime fec_ini, DateTime fec_fin, int con_tad)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm005 VALUES ");
                vv_str_sql.AppendLine(" ( " + cod_ges + ", '" + cod_doc + "'," + nro_tal + ",");
                vv_str_sql.AppendLine(" " + nro_ini + ", " + nro_fin + " , '" + fec_ini.ToShortDateString() + "' ,");
                vv_str_sql.AppendLine(" '" + fec_fin.ToShortDateString() + "' ," + con_tad + ") ");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Modifica NUMERACION
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <param name="cod_ges">Codigo de la gestion</param>
        /// <param name="nro_ini">Numero inicial para el talonario</param>
        /// <param name="nro_fin">Numero fianl para el talonario</param>
        /// <param name="fec_ini">Fecha inicial para el talonario</param>
        /// <param name="fec_fin">Fecha final para el talonario</param>
        /// <param name="con_tad">Contador del talonario</param>
        /// <returns></returns>
        public void _03(string cod_doc, int nro_tal, int cod_ges, int nro_ini,
            int nro_fin, DateTime fec_ini, DateTime fec_fin, int con_tad)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm005 ");
                vv_str_sql.AppendLine(" SET va_nro_ini = " + nro_ini + ", va_nro_fin =" + nro_fin + ", ");
                vv_str_sql.AppendLine(" va_fec_ini = '" + fec_ini.ToShortDateString() + "' , va_fec_fin = '" + fec_fin.ToShortDateString() + "', ");
                vv_str_sql.AppendLine(" va_con_tad =" + con_tad);
                vv_str_sql.AppendLine(" WHERE va_cod_doc = '" + cod_doc + "' AND va_nro_tal= " + nro_tal + " AND va_cod_ges= " + cod_ges);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Modifica Contador de la NUMERACION
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <param name="cod_ges">Codigo de la gestion</param>
        /// <param name="con_tad">Contador del talonario</param>
        /// <returns></returns>
        public void _03(string cod_doc, int nro_tal, int cod_ges, int con_tad)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm005 ");
                vv_str_sql.AppendLine(" Set va_con_tad =" + con_tad);
                vv_str_sql.AppendLine(" where va_cod_doc = '" + cod_doc + "' and va_nro_tal= " + nro_tal + " and va_cod_ges= " + cod_ges);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Consulta NUMERACION
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <param name="cod_ges">Codigo de la gestion</param>
        /// <returns></returns>
        public DataTable _05(string cod_doc, int nro_tal, int cod_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE adm005_05p1");
                vv_str_sql.AppendLine("  '" + cod_doc + "', " + nro_tal + ", " + cod_ges + " ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Elimina NUMERACION
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <param name="cod_ges">Codigo de la gestion</param>
        /// <returns></returns>
        public void _06(string cod_doc, int nro_tal, int cod_ges)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE FROM adm005 ");
                vv_str_sql.AppendLine(" where va_cod_doc = '" + cod_doc + "' and va_nro_tal= " + nro_tal + " AND va_cod_ges=" + cod_ges);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// -> Elimina NUMERACIONES del talonario (de todas las gestiones)
        ///    siempre y cuando no tenga operaciones relacionada
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero de talonario del documento</param>
        /// <returns></returns>
        public void _06(string cod_doc, int nro_tal)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE FROM adm005 ");
                vv_str_sql.AppendLine(" where va_cod_doc = '" + cod_doc + "' and va_nro_tal= " + nro_tal);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
