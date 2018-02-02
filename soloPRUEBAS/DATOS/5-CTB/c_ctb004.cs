using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._5_CTB
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Plan de Cuentas
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb004
    {
        /// <summary>
        /// Objeto de la clase Conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        /// Funcion "Buscar Plan de Cuentas"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ctb004  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_cta like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_cta like '" + val_bus + "%' "); break;
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
        /// funcion "Registrar Plan de Cuentas"
        /// </summary>
        /// <param name="cod_cta">Codigo Plan de Cuentas</param>
        /// <param name="nom_cta">Nombre Plan de Cuentas</param>
        /// <param name="tip_cta">Tipo (M=Matriz ; A=Analitica)</param>
        /// <param name="uso_cta">Uso (M=Modular ; A=Analitica)</param>
        /// <param name="mon_cta">Moneda (B=Bolivianos ; U=Dolares)</param>
        public void _02(string cod_cta, string nom_cta, string tip_cta, string uso_cta, string mon_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ctb004 VALUES");

                switch (tip_cta)
                {
                    case "0": tip_cta = "M"; break;
                    case "1": tip_cta = "A"; break;
                }
                switch (uso_cta)
                {
                    case "0": uso_cta = "M"; break;
                    case "1": uso_cta = "N"; break;
                }
                switch (mon_cta)
                {
                    case "0": mon_cta = "B"; break;
                    case "1": mon_cta = "U"; break;
                }

                vv_str_sql.AppendLine(" (" + cod_cta + ", '" + nom_cta + "', '" + tip_cta + "', '" + uso_cta + "', '" + mon_cta + "', 'H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// funcion "Modifica Plan de Cuentas"
        /// </summary>
        /// <param name="cod_cta">Codigo Plan de Cuentas</param>
        /// <param name="nom_cta">Nombre Plan de Cuentas</param>
        /// <param name="tip_cta">Tipo (M=Matriz ; A=Analitica)</param>
        /// <param name="uso_cta">Uso (M=Modular ; A=Analitica)</param>
        /// <param name="mon_cta">Moneda (B=Bolivianos ; U=Dolares)</param>
        public void _03(string cod_cta, string nom_cta, string tip_cta, string uso_cta, string mon_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb004 SET");

                switch (tip_cta)
                {
                    case "0": tip_cta = "D"; break;
                    case "1": tip_cta = "A"; break;
                }

                vv_str_sql.AppendLine(" va_nom_cta='" + nom_cta + "' , va_tip_cta= '" + tip_cta + "' ,");
                vv_str_sql.AppendLine(" va_uso_cta='" + uso_cta + "' " + " , va_mon_cta= '" + mon_cta + "' ");

                vv_str_sql.AppendLine(" WHERE va_cod_cta = " + cod_cta);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita Plan de Cuentas"
        /// </summary>
        /// <param name="cod_cta">Codigo del Plan de Cuentas</param>
        /// <param name="est_ado">Estado del Plan de Cuentas</param>
        /// <returns></returns>
        public void _04(string cod_cta, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb004 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cta = '" + cod_cta + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Plan de Cuentas"
        /// </summary>
        /// <param name="cod_cta">Codigo del Plan de Cuentas</param>
        /// <returns></returns>
        public DataTable _05(string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM ctb004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cta = '" + cod_cta + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Plan de Cuentas"
        /// </summary>
        /// <param name="cod_cta">Codigo del Plan de Cuentas</param>
        /// <returns></returns>
        public void _06(string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ctb004 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cta = '" + cod_cta + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
