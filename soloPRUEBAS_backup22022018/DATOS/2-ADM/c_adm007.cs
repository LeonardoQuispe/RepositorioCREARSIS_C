using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase SUCURSAL
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm007
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
                vv_str_sql.AppendLine(" select * from adm007  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_suc like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_suc like '" + val_bus + "%' "); break;
                    
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
        /// Funcion "inserta nueva sucursal"
        /// </summary>
        /// <param name="cod_suc"></param>
        /// <param name="nom_suc"></param>
        /// <param name="enc_suc"></param>
        /// <param name="ubi_suc"></param>
        /// <param name="tel_suc"></param>
        /// <param name="ema_suc"></param>
        /// <param name="ciu_suc"></param>
        /// <param name="ley_suc"></param>
        /// <returns></returns>
        public void _02(int cod_suc, string nom_suc, string enc_suc,
            string ubi_suc, string tel_suc, string ema_suc, string ciu_suc, string ley_suc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm007 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_suc + ", '" + nom_suc + "','" + enc_suc + "','" + ubi_suc + "','" + tel_suc);
                vv_str_sql.AppendLine("','" + ema_suc + "','" + ciu_suc + "','" + ley_suc + "','H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica sucursal"
        /// </summary>
        /// <param name="cod_suc"></param>
        /// <param name="nom_suc"></param>
        /// <param name="enc_suc"></param>
        /// <param name="ubi_suc"></param>
        /// <param name="tel_suc"></param>
        /// <param name="ema_suc"></param>
        /// <param name="ciu_suc"></param>
        /// <param name="ley_suc"></param>
        /// <returns></returns>
        public void _03(int cod_suc, string nom_suc, string enc_suc,
            string ubi_suc, string tel_suc, string ema_suc, string ciu_suc, string ley_suc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm007 SET ");
                vv_str_sql.AppendLine(" va_nom_suc='" + nom_suc + "', va_enc_suc='" + enc_suc + "', va_ubi_suc='" + ubi_suc + "',");
                vv_str_sql.AppendLine(" va_tel_suc='" + tel_suc + "', va_ema_suc='" + ema_suc + "', va_ciu_suc='" + ciu_suc + "',");
                vv_str_sql.AppendLine(" va_ley_suc='" + ley_suc + "' WHERE va_cod_suc =" + cod_suc);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita  Sucursal"
        /// </summary>
        /// <param name="cod_suc"></param>
        /// <param name="est_ado"></param>
        /// <returns></returns>
        public void _04(string cod_suc, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm007 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_suc = '" + cod_suc + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Sucursal"
        /// </summary>
        /// <param name="cod_suc"></param>
        /// <returns></returns>
        public DataTable _05(string cod_suc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm007 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_suc =" + cod_suc);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Sucursal"
        /// </summary>
        /// <param name="cod_suc"></param>
        /// <returns></returns>
        public void _06(string cod_suc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm007 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_suc = '" + cod_suc + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

