using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    ///◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    //////Clase TALONARIO
    ///◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm004
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
        /// Funcion "Buscar TALONARIO"
        /// </summary>
        /// <param name="cod_mod">Codigo del Modulo</param>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo Doc ; 2=Nombre Doc ; 3=Nro Talonaio, 4=Nombre Talonario)</param>
        /// <param name="est_bus">Estado del Talonario (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(int cod_mod, string val_bus, int prm_bus, string est_bus)
        {         
            try
            {
                switch (prm_bus)
                {
                    case 0:prm_bus = 3;break;
                    case 1: prm_bus = 1; break;
                    case 2: prm_bus = 2; break;
                }

                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE adm004_01p1");
                vv_str_sql.AppendLine(" " + cod_mod + ", '" + val_bus + "', " + prm_bus + ", '" + est_bus + "' ");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Funcion "Registrar TALONARIO"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento<</param>
        /// <param name="nro_tal">Nro de talonario</param>
        /// <param name="nom_tal">Nombre del Talonario</param>
        /// <param name="tip_num">Tipo de numeracion (1=manual ; 2=aurtomatic</param>
        /// <param name="nro_dos">Numero de Dosificacion</param>
        /// <param name="for_mat">Formato de impresion</param>
        /// <param name="nro_cop">Numero de copias que imprimira el documento</param>
        /// <param name="fir_ma1">Firma 1 del documento</param>
        /// <param name="fir_ma2">Firma 2 del documento</param>
        /// <param name="fir_ma3">Firma 3 del documento</param>
        /// <param name="fir_ma4">Firma 4 del documento</param>
        /// <param name="for_log">Forma de imprimir el logo en el documento (0=Nombre de la empresa ; 1=Logotipo 1)</param>
        /// <returns></returns>
        public void _02(string cod_doc, string nro_tal, string nom_tal,
            int tip_num, string nro_dos, int for_mat, int nro_cop, string fir_ma1,
            string fir_ma2, string fir_ma3, string fir_ma4, int for_log)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm004 VALUES ");
                vv_str_sql.AppendLine(" ('" + cod_doc + "', " + nro_tal + ",'" + nom_tal + "', " + tip_num + " , ");
                vv_str_sql.AppendLine(" '" + nro_dos + "', " + for_mat + "," + nro_cop + ",'" + fir_ma1 + "', ");
                vv_str_sql.AppendLine(" '" + fir_ma2 + "', '" + fir_ma3 + "', '" + fir_ma4 + "'," + for_log + ",0,'H' )");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica TALONARIO"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento<</param>
        /// <param name="nro_tal">Nro de talonario</param>
        /// <param name="nom_tal">Nombre del Talonario</param>
        /// <param name="tip_num">ipo de numeracion (1=manual ; 2=aurtomatic</param>
        /// <param name="nro_dos">Numero de dosificacion</param>
        /// <param name="for_mat">Formato de impresion</param>
        /// <param name="nro_cop">Numero de copias que imprimira el documento</param>
        /// <param name="fir_ma1">Firma 1 del documento</param>
        /// <param name="fir_ma2">Firma 2 del documento</param>
        /// <param name="fir_ma3">Firma 3 del documento</param>
        /// <param name="fir_ma4">Firma 4 del documento</param>
        /// <param name="for_log">Forma de imprimir el logo en el documento (0=Nombre de la empresa ; 1=Logotipo 1)</param>
        /// <returns></returns>
        public void _03(string cod_doc, string nro_tal, string nom_tal,
            int tip_num, string nro_dos, int for_mat, int nro_cop, string fir_ma1,
            string fir_ma2, string fir_ma3, string fir_ma4, int for_log)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm004 SET ");
                vv_str_sql.AppendLine(" va_nom_tal='" + nom_tal + "' , va_tip_num= " + tip_num + ", va_nro_aut='" + nro_dos + "', ");
                vv_str_sql.AppendLine(" va_for_mat=" + for_mat + ", va_nro_cop=" + nro_cop + ", va_fir_ma1='" + fir_ma1 + "', ");
                vv_str_sql.AppendLine(" va_fir_ma2='" + fir_ma2 + "', va_fir_ma3='" + fir_ma3 + "', va_fir_ma4='" + fir_ma4 + "', ");
                vv_str_sql.AppendLine(" va_for_log=" + for_log);
                vv_str_sql.AppendLine(" WHERE va_cod_doc = '" + cod_doc + "' AND va_nro_tal=" + nro_tal + "");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza bandera de contenido de datos para el talonari
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero del talonario</param>
        /// <param name="ban_dat">Bandera contenido de datos (0=No ; 1=Si tiene datos)</param>
        /// <returns></returns>
        public void _03(string cod_doc, int nro_tal, int ban_dat)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm004 SET ");
                vv_str_sql.AppendLine(" va_ban_dat=" + ban_dat);
                vv_str_sql.AppendLine(" WHERE va_cod_doc = '" + cod_doc + "' AND va_nro_tal=" + nro_tal + "");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita TALONARIO"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Nro de talonario</param>
        /// <param name="est_ado">Estado del talonario</param>
        /// <returns></returns>
        public void _04(string cod_doc, int nro_tal, string est_ado)
        {
            try
            {
                vv_str_sql.AppendLine(" UPDATE adm004 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "' AND va_nro_tal = " + nro_tal);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Funcion "Consulta TALONARIO"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nro_tal">Numero del talonario</param>
        /// <returns></returns>
        public DataTable _05(string cod_doc, int nro_tal)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "' AND va_nro_tal = " + nro_tal);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta TALONARIOS de un Documento"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <returns></returns>
        public DataTable _05(string cod_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina TALONARIO"
        /// </summary>
        /// <param name="cod_doc">Codigo del Documento</param>
        /// <param name="nro_tal">Numero del Talonario</param>
        /// <returns></returns>
        public void _06(string cod_doc, int nro_tal)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "' AND va_nro_tal = " + nro_tal);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
