using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS.ADM
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase FAMILIA DE PRODUCTO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_inv001
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
        /// Funcion "Buscar familia de producto"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus,int tipo =1)
         {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv001  ");

                if (tipo==1)
                {
                    switch (prm_bus)
                    {
                        case 1: vv_str_sql.AppendLine(" where va_cod_fam like '" + val_bus + "%' "); break;
                        case 2: vv_str_sql.AppendLine(" where va_nom_fam like '" + val_bus + "%' "); break;
                    }
                }
                else if (tipo==2)
                {
                    vv_str_sql.AppendLine(" where va_cod_fam = '" + val_bus + "' ");                       
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
        /// funcion "Registrar familia de producto"
        /// </summary>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <param name="nom_fam">Nombre de la familia de producto</param>
        /// <param name="tip_fam">Tipo de la familia de producto</param>
        /// <returns></returns>
        public DataTable _02(string cod_fam, string nom_fam,string tip_fam)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv001 VALUES");

                switch (tip_fam)
                {
                    case "0":tip_fam = "M"; break;
                    case "1": tip_fam = "D"; break;
                    case "2": tip_fam = "S"; break;
                    case "3": tip_fam = "C"; break;
                }

                vv_str_sql.AppendLine(" ('" + cod_fam + "', '" + nom_fam + "', '"+tip_fam+"','H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica familia de producto"
        /// </summary>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <param name="nom_fam">Nombre de la familia de producto</param>
        /// <param name="tip_fam">Tipo de la familia de producto</param>
        /// <returns></returns>
        public DataTable _03(string cod_fam, string nom_fam,string tip_fam)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv001 SET");

                switch (tip_fam)
                {
                    case "0": tip_fam = "M"; break;
                    case "1": tip_fam = "D"; break;
                    case "2": tip_fam = "S"; break;
                    case "3": tip_fam = "C"; break;
                }

                vv_str_sql.AppendLine(" va_nom_fam='" + nom_fam + "' , va_tip_fam='"+tip_fam+"'");
                vv_str_sql.AppendLine(" WHERE va_cod_fam = '" + cod_fam + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita familia de producto"
        /// </summary>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <param name="est_ado">Estado de la familia de producto</param>
        /// <returns></returns>
        public DataTable _04(string cod_fam, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv001 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_fam = '" + cod_fam + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta familia de producto"
        /// </summary>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <returns></returns>
        public DataTable _05(string cod_mar)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_fam = " + "'" + cod_mar + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina familia de producto"
        /// </summary>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <returns></returns>
        public DataTable _06(string cod_fam)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_fam = '" + cod_fam + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
