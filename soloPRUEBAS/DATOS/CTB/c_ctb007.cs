using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase DOSIFICACION
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ctb007
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
        /// 
        /// </summary>
        /// <param name="val_bus"></param>
        /// <param name="prm_bus"></param>
        /// <param name="va_fec_ini"></param>
        /// <param name="va_fec_fin"></param>
        /// <param name="est_bus"></param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, DateTime va_fec_ini, DateTime va_fec_fin, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ctb007  ");

                switch (prm_bus)
                {
                    case 1 : vv_str_sql.AppendLine(" WHERE va_nro_aut like '" + val_bus + "%' "); break;
                }
                
                vv_str_sql.AppendLine(" AND va_fec_ini BETWEEN '" + va_fec_ini.ToShortDateString() + "' AND '" + va_fec_fin.ToShortDateString() + "'");

                switch (est_bus)
                {  
                    case "1": vv_str_sql.AppendLine(" AND va_est_ado ='H'"); break;

                    case "2": vv_str_sql.AppendLine(" AND va_est_ado ='N'"); break;
                }

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Registra dosificacion
        /// </summary>
        /// <param name="nro_dos">Nuemero de dosificacion</param>
        /// <param name="tip_fac">Tipo de factura 0=Computarizada ; 1=Manual</param>
        /// <param name="cod_sucu">Codigo sucursal</param>
        /// <param name="cod_act">Codigo Actividad economica</param>
        /// <param name="nro_ini">Numero inicial factura</param>
        /// <param name="nro_fin">Numero final factura</param>
        /// <param name="fec_ini">Fecha inicial dosificacion</param>
        /// <param name="fec_fin">Fecha final dosificacion</param>
        /// <param name="cod_ley">Codigo de leyenda</param>
        /// <returns></returns>
        public DataTable _02(long nro_dos, int tip_fac, int cod_sucu, int cod_act, int nro_ini, int nro_fin, DateTime fec_ini, DateTime fec_fin, int cod_ley)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE ctb007_02p1 " + "'" + nro_dos + "',"+tip_fac+",");
                vv_str_sql.AppendLine("'" + fec_ini.ToShortDateString() + "','" + fec_fin.ToShortDateString() + "',");
                vv_str_sql.AppendLine(nro_ini + "," + nro_fin + ","+cod_sucu+"," + cod_act + "," + cod_ley + ",");
                vv_str_sql.AppendLine("'','H'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica dosificacion"
        /// </summary>
        /// <param name="nro_dos"></param>
        /// <param name="tip_fac"></param>
        /// <param name="cod_sucu"></param>
        /// <param name="cod_act"></param>
        /// <param name="nro_ini"></param>
        /// <param name="nro_fin"></param>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <param name="cod_ley"></param>
        /// <returns></returns>
        public DataTable _03(long nro_dos, int tip_fac, int cod_sucu, int cod_act, int nro_ini, int nro_fin, DateTime fec_ini, DateTime fec_fin, int cod_ley,string lla_ve)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE ctb007_03p1 " + "'" + nro_dos + "'," + tip_fac + ",");
                vv_str_sql.AppendLine("'" + fec_ini.ToShortDateString() + "','" + fec_fin.ToShortDateString() + "',");
                vv_str_sql.AppendLine(nro_ini + "," + nro_fin + "," + cod_sucu + "," + cod_act + "," + cod_ley + ",");                

                switch (tip_fac)
                {
                    case 0: vv_str_sql.AppendLine("'"+lla_ve + "'"); break;

                    case 1: vv_str_sql.AppendLine("''"); break;
                }
                
                

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza llave de dosificacion
        /// </summary>
        /// <param name="nro_dos">Numero de dosificacion</param>
        /// <param name="lla_vee"></param>
        /// <returns></returns>
        public DataTable _03(long nro_dos, string lla_vee)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE ctb007_03ap1 " + "'" + nro_dos + "','" + lla_vee + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita Dosificacion"
        /// </summary>
        /// <param name="nro_dos">Codigo de dosificaion</param>
        /// <param name="est_ado">Estado de dosificaion</param>
        /// <returns></returns>
        public DataTable _04(long nro_dos, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                //vv_str_sql.AppendLine(" UPDATE ctb007 SET ");
                //vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                //vv_str_sql.AppendLine(" WHERE  va_nro_aut = '" + nro_dos + "'");


                switch (est_ado)
                {
                    case "H": vv_str_sql.AppendLine(" EXECUTE ctb007_04p1 " + "'" + nro_dos + "'"); break;

                    case "N": vv_str_sql.AppendLine(" EXECUTE ctb007_04p2 " + "'" + nro_dos + "'"); break;
                }                

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta dosificacion"
        /// </summary>
        /// <param name="nro_dos">Codigo de la dosificacion</param>
        /// <returns></returns>
        public DataTable _055(string proc, long nro_dos)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE "+ proc +" '"+ nro_dos + "'");
               

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable _05(long nro_dos)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ctb007 ");
                vv_str_sql.AppendLine(" WHERE  va_nro_aut ='" + nro_dos + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Dosificacion"
        /// </summary>
        /// <param name="nro_dos">codigo de Dosificacion</param>
        /// <returns></returns>
        public DataTable _06(long nro_dos)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" EXECUTE ctb007_06p1 " + "'" + nro_dos + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
