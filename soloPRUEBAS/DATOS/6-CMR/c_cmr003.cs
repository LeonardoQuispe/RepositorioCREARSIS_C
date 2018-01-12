using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._6_CMR
{
    public class c_cmr003
    {
        /// <summary>
        /// Cadena de comando SQL
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        /// Funcion "Buscar VENDEDOR"
        /// </summary>
        /// <param name="val_bus">Valor de la busqued</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Nombre)</param>
        /// <param name="est_bus">Estado de Vendedor (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )(</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();

                vv_str_sql.AppendLine(" select * from cmr003  ");

                if (true)
                {

                }
                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendFormat(" where va_cod_ven like '{0}%'", val_bus); break;
                    case 2: vv_str_sql.AppendFormat(" where va_nom_ven like '{0}%'", val_bus); break;
                }

                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    vv_str_sql.AppendFormat(" and va_est_ado ='{0}'", est_bus);
                }


                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Actualizar Vendedor
        /// </summary>
        /// <param name="cod_ven">Código del Vendedor</param>
        /// <param name="nom_per">Nombre del Vendedor</param>
        /// <param name="por_cms">Porcentaje Comisión</param>
        /// <param name="tip_cms">Tipo comisión (1=Ventas, 2=Cobranzas)</param>
        /// <returns></returns>
        public DataTable _02(string cod_ven, string nom_per, decimal por_cms, int tip_cms)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO cmr003 VALUES ");
                vv_str_sql.AppendFormat("('{0}','{1}','{2}','{3}','H')", cod_ven, nom_per, por_cms, tip_cms);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualizar Vendedor
        /// </summary>
        /// <param name="cod_ven">Código del Vendedor</param>
        /// <param name="nom_per">Nombre del Vendedor</param>
        /// <param name="por_cms">Porcentaje Comisión</param>
        /// <param name="tip_cms">Tipo comisión (1=Ventas, 2=Cobranzas)</param>
        /// <returns></returns>
        public DataTable _03(string cod_ven, string nom_per, decimal por_cms, int tip_cms)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE cmr003 SET  ");
                vv_str_sql.AppendFormat("va_nom_ven='{0}',va_por_cms='{1}',va_tip_cms='{2}' ", nom_per, por_cms, tip_cms);
                vv_str_sql.AppendFormat(" WHERE va_cod_ven='{0}' ", cod_ven);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Habilita/Deshabilita Vendedor"
        /// </summary>
        /// <param name="cod_ven">Codigo del Vendedor</param>
        /// <param name="est_ado">Estado del Vendedor</param>
        /// <returns></returns>
        public DataTable _04(string cod_ven, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE cmr003 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_ven = '" + cod_ven + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta persona"
        /// </summary>
        /// <param name="cod_ven">Codigo del persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_ven)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM cmr003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_ven = '" + cod_ven + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Vendedor"
        /// </summary>
        /// <param name="cod_ven">Codigo del Vendedor</param>
        /// <returns></returns>
        public DataTable _06(string cod_ven)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE cmr003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_ven = '" + cod_ven + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
