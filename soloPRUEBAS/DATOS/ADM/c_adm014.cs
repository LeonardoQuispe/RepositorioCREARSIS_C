using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS.ADM
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase T.C. Bs/Ufv 
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm014
    {
        /// <summary>
        /// objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        ///  Busca tipos de cambio de un mes en el año
        /// </summary>
        /// <param name="val_mes">Numero de mes</param>
        /// <param name="val_año">año</param>
        /// <returns></returns>
        public DataTable _01(int val_mes, int val_año)
        {
            try
            {
                DateTime fec_ini;
                DateTime fec_fin;

                fec_ini = Convert.ToDateTime("01/" + val_mes + "/" + val_año);
                fec_fin = fec_ini.AddMonths(1);
                fec_fin = fec_fin.AddDays(-1);

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from adm014  ");
                vv_str_sql.AppendLine(" where va_fec_buf BETWEEN '" + fec_ini + "' AND '" + fec_fin + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca tipoc de cambio de una fecha
        /// </summary>
        /// <param name="val_fec">Fecha</param>
        /// <returns></returns>
        public DataTable _01(DateTime val_fec)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from adm014  ");
                vv_str_sql.AppendLine(" where va_fec_buf= '" + val_fec + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "inserta nueva T.C. Bs/Ufv"
        /// </summary>
        /// <param name="fec_buf"></param>
        /// <param name="val_buf"></param>
        /// <returns></returns>
        public DataTable _02(DateTime fec_buf, string val_buf)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm014 VALUES ");
                vv_str_sql.AppendLine(" ('" + fec_buf + "', '" + val_buf + "')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "inserta nueva T.C. Bs/Ufv por rango de fecha"
        /// </summary>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <param name="val_buf"></param>
        /// <returns></returns>
        public DataTable _02(DateTime fec_ini, DateTime fec_fin, string val_buf)
        {
            try
            {
                int nro_dia = 0;
                DateTime fec_aux;

                nro_dia = ((fec_fin - fec_ini).Days);

                vv_str_sql = new StringBuilder();

                for (int i = 1; i <= nro_dia; i++)
                {
                    vv_str_sql.AppendLine(" INSERT INTO adm014 VALUES");
                    fec_aux = fec_ini.AddDays(i);
                    vv_str_sql.AppendLine(" ('" + fec_aux + "', '" + val_buf + "')");

                }

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica T.C. Bs/Ufv"
        /// </summary>
        /// <param name="fec_buf">Fecha de T.C. Bs/Ufv</param>
        /// <param name="val_buf">Valor de T.C. Bs/Ufv</param>
        /// <returns></returns>
        public DataTable _03(DateTime fec_buf, DateTime val_buf)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" va_val_buf='" + val_buf + "'");
                vv_str_sql.AppendLine(" WHERE va_fec_buf ='" + fec_buf + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta T.C. Bs/Ufv"
        /// </summary>
        /// <param name="fec_buf">Fecha de la T.C. Bs/Ufv</param>
        /// <returns></returns>
        public DataTable _05(string fec_buf)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm014 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_buf ='" + fec_buf + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina T.C. Bs/Ufv"
        /// </summary>
        /// <param name="fec_buf">Codigo de T.C. Bs</param>
        /// <returns></returns>
        public DataTable _06(string fec_buf)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm014 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_buf = '" + fec_buf + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina T.C. Bs/Ufv por rango de fecha"
        /// </summary>
        /// <param name="fec_ini">Fecha inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable _06(DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm014 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_buf BETWEEN '" + fec_ini + "' AND '" + fec_fin + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
