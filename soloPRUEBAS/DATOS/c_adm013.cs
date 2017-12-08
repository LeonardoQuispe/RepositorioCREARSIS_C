using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS.ADM
{

    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase T.C. Bs/Us
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm013
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
                vv_str_sql.AppendLine(" select * from adm013  ");
                vv_str_sql.AppendLine(" where va_fec_bus BETWEEN '" + fec_ini.ToShortDateString() + "' AND '" + fec_fin.ToShortDateString() + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "inserta nueva T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de T.C. Bs</param>
        /// <param name="val_bus">Valor de T.C. Bs</param>
        /// <returns></returns>
        public DataTable _02(DateTime fec_bus, string val_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm013 VALUES ");
                vv_str_sql.AppendLine(" ('" + fec_bus.ToShortDateString() + "', '" + val_bus + "')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "inserta nueva T.C. Bs/Us por rango de fecha"
        /// </summary>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <param name="val_bus"></param>
        /// <returns></returns>
        public DataTable _02(DateTime fec_ini, DateTime fec_fin, string val_bus)
        {
            try
            {
                int nro_dia = 0;
                DateTime fec_aux;

                //intervalo de dias
                nro_dia = (fec_fin - fec_ini).Days;

                vv_str_sql = new StringBuilder();

                for (int i = 0; i <= nro_dia; i++)
                {
                    vv_str_sql.AppendLine(" INSERT INTO adm013 VALUES ");
                    
                    fec_aux = fec_ini.AddDays(i);
                    vv_str_sql.AppendLine(" ('" + fec_aux.ToShortDateString() + "', '" + val_bus + "')");
                }
                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de T.C. Bs</param>
        /// <param name="val_bus">Valor de T.C. Bs</param>
        /// <returns></returns>
        public DataTable _03(DateTime fec_bus, decimal val_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm013 SET ");
                vv_str_sql.AppendLine(" va_val_bus='" + val_bus + "'");
                vv_str_sql.AppendLine(" WHERE va_fec_bus ='" + fec_bus.ToShortDateString() + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de la T.C. Bs/Us</param>
        /// <returns></returns>
        public DataTable _05(string fec_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm013 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus ='" + fec_bus + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">>Codigo de T.C. Bs/Us</param>
        /// <returns></returns>
        public DataTable _06(string fec_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm013 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus = '" + fec_bus + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina T.C. Bs/Us por rango de fecha
        /// </summary>
        /// <param name="fec_ini">Fecha inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable _06(DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm013 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus BETWEEN '" + fec_ini.ToShortDateString() + "' AND '" + fec_fin.ToShortDateString() + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
