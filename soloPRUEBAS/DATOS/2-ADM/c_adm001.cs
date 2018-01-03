using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Datos de la EMPRESA
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm001
    {
        /// <summary>
        /// Objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();


        /// <summary>
        /// Funcion "Buscar DATOS DE LA EMPRESA"
        /// </summary>
        /// <returns></returns>
        public DataTable _01()
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE adm001_01p1");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Modifica DATOS DE LA EMPRESA"
        /// </summary>
        /// <param name="nit_emp">Nit de la Empresa</param>
        /// <param name="raz_soc">Razon Social de la Empresa</param>
        /// <param name="rep_leg">Representante legal de la Empresa</param>
        /// <param name="dir_emp">Dirección de la Empresa</param>
        /// <param name="tel_emp">Teléfono de la Empresa</param>
        /// <param name="cel_emp">Celular de la Empresa</param>
        /// <param name="cor_reo">Correo de la Empresa</param>
        /// <param name="dir_web">Dirección Web de la Empresa ejm: "www.tubaboo.com"</param>
        /// <param name="dir_fbk">Dirección de Facebook de la Empresa "www.facebook.com/baboomedia"</param>
        /// <param name="cla_wif"></param>
        public void _03(string nit_emp, string raz_soc, string rep_leg, string dir_emp, string tel_emp,
                        string cel_emp, string cor_reo, string dir_web, string dir_fbk, string cla_wif)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm001 SET ");
                vv_str_sql.AppendLine(" va_nit_emp='" + nit_emp + "' , va_raz_soc= '" + raz_soc + "', va_rep_leg='" + rep_leg + "', va_dir_emp='" + dir_emp + "', ");
                vv_str_sql.AppendLine(" va_tel_emp='" + tel_emp + "' , va_cel_emp='" + cel_emp + "' , va_cor_reo='" + cor_reo + "', va_dir_web ='" + dir_web + "', ");
                vv_str_sql.AppendLine(" va_dir_fbk= '" + dir_fbk + "', va_cla_wif='" + cla_wif + "' ");

                o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        /// -> Modifica Logo de la empresa
        /// </summary>
        /// <param name="log_emp">logo de la empresa en exagesimal</param>
        public void _03(byte[] log_emp)
        {
            vv_str_sql = new StringBuilder();
            vv_str_sql.AppendLine(" UPDATE adm001 SET ");
            vv_str_sql.AppendLine(" va_log_emp = @va_log_emp");

            SqlCommand cmd = new SqlCommand(vv_str_sql.ToString(), o_cnx000.fu_cnx_cnx());

            cmd.Parameters.Add("@va_log_emp", System.Data.SqlDbType.VarBinary, log_emp.Length).Value = log_emp;
            cmd.ExecuteNonQuery();

            o_cnx000.mt_cer_cnx();
        }

    }
}
