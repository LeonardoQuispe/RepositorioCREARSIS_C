using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._5_CTB
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Capitulo/Agrupador
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb002
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
        /// Funcion "Buscar Capitulo/Agrupador"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ctb002  ");
                
                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_cap like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_cap like '" + val_bus + "%' "); break;
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
        /// funcion "Registrar Capitulo/Agrupador"
        /// </summary>
        /// <param name="cod_cap">Codigo del Capitulo/Agrupador </param>
        /// <param name="nom_cap">Nombre del Capitulo/Agrupador</param>
        /// <param name="tra_cap">Tratamiento (D=Deudor ; A=Acreedor) </param>
        /// <param name="cen_cto">Usa Centro de Costo(0=No ; 1=Si Usa)</param>
        /// <returns></returns>
        public void _02(int cod_cap, string nom_cap, string tra_cap, int cen_cto)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ctb002 VALUES");

                switch (tra_cap)
                {
                    case "0": tra_cap = "D"; break;
                    case "1": tra_cap = "A"; break;
                }

                vv_str_sql.AppendLine(" (" + cod_cap + ", '" + nom_cap + "', '" + tra_cap + "', '" + cen_cto + "', 'H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica Capitulo/Agrupador"
        /// </summary>
        /// <param name="cod_cap">Codigo del Capitulo/Agrupador </param>
        /// <param name="nom_cap">Nombre del Capitulo/Agrupador</param>
        /// <param name="tra_cap">Tratamiento (D=Deudor ; A=Acreedor) </param>
        /// <param name="cen_cto">Usa Centro de Costo(0=No ; 1=Si Usa)</param>
        /// <returns></returns>
        public void _03(int cod_cap, string nom_cap, string tra_cap, int cen_cto)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb002 SET");

                switch (tra_cap)
                {
                    case "0": tra_cap = "D"; break;
                    case "1": tra_cap = "A"; break;
                }

                vv_str_sql.AppendLine(" va_nom_cap='" + nom_cap + "' , va_tra_cap= '" + tra_cap + "' ,");
                vv_str_sql.AppendLine(" va_cen_cto='" + cen_cto + "' ");

                vv_str_sql.AppendLine(" WHERE va_cod_cap = " + cod_cap );

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita Capitulo/Agrupador"
        /// </summary>
        /// <param name="cod_cap">Codigo del Capitulo/Agrupador</param>
        /// <param name="est_ado">Estado del Capitulo/Agrupador</param>
        /// <returns></returns>
        public void _04(int cod_cap, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ctb002 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cap = '" + cod_cap + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Capitulo/Agrupador"
        /// </summary>
        /// <param name="cod_cap">Codigo del Capitulo/Agrupador</param>
        /// <returns></returns>
        public DataTable _05(int cod_cap)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM ctb002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cap = '" + cod_cap + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Capitulo/Agrupador"
        /// </summary>
        /// <param name="cod_cap">Codigo del Capitulo/Agrupador</param>
        /// <returns></returns>
        public void _06(int cod_cap)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ctb002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cap = '" + cod_cap + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
