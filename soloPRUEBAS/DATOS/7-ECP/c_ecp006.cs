using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._7_ECP
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase LIBRETAS
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ecp006
    {
        /// <summary>
        /// Objeto del clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        /// Funcion "Buscar Libreta"
        /// </summary>
        /// <param name="val_bus">Valor del busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Descripcion )</param>
        /// <param name="tip_lib">Tipo de Libreta (1=CXC ; 2=CXP )</param>
        /// <param name="est_bus">Estado de la Búsqueda (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus,int tip_lib, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ecp006 ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_lib like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_des_lib like '" + val_bus + "%' "); break;
                }

                switch (tip_lib)
                {
                    case 2: vv_str_sql.AppendLine(" and va_tip_lib=1"); break;
                    case 3: vv_str_sql.AppendLine(" and va_tip_lib=2"); break;
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
        /// Registra Libreta
        /// </summary>
        /// <param name="cod_lib">Código de la Libreta (5 Numeros)
		///					        Formato ---> TMNNN
        ///							T=Tipo
		///							M=Moneda
	    ///							N=Nro Correlativo de libreta</param>
        /// <param name="tip_lib">Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')</param>
        /// <param name="mon_lib">Moneda (B=Bolivianos; U=USD)</param>
        /// <param name="nro_lib">Nro Correlativo de Libreta (3 Numeros)</param>
        /// <param name="des_lib">Descripcion de la Libreta</param>
        /// <param name="cod_cta">Cod. Cuenta Contable</param>
        public void _02(int cod_lib, int tip_lib, string mon_lib, string des_lib,string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ecp006 VALUES");
                vv_str_sql.AppendFormat(" ({0},{1},'{2}',",cod_lib,tip_lib,mon_lib);
                vv_str_sql.AppendFormat("'{0}','{1}','H')", des_lib, cod_cta);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica Libreta
        /// </summary>
        /// <param name="cod_lib">Código de la Libreta (5 Numeros)
		///					        Formato ---> TMNNN
        ///							T=Tipo
		///							M=Moneda
	    ///							N=Nro Correlativo de libreta</param>
        /// <param name="tip_lib">Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')</param>
        /// <param name="mon_lib">Moneda (B=Bolivianos; U=USD)</param>
        /// <param name="nro_lib">Nro Correlativo de Libreta (3 Numeros)</param>
        /// <param name="des_lib">Descripcion de la Libreta</param>
        /// <param name="cod_cta">Cod. Cuenta Contable</param>
        public void _03(int cod_lib, string des_lib, string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ecp006 SET");
                vv_str_sql.AppendFormat(" va_des_lib='{0}',va_cod_cta='{1}'",des_lib,cod_cta);
                vv_str_sql.AppendFormat(" WHERE va_cod_lib ={0}",cod_lib);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo de la Libreta</param>
        /// <param name="est_ado">Estado de la Libreta</param>
        /// <returns></returns>
        public void _04(int cod_lib, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE ecp006 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lib =" + cod_lib);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo de la Libreta</param>
        /// <returns></returns>
        public DataTable _05(int cod_lib)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM ecp006 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lib =" + cod_lib);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion Sugerir Nro de Libreta
        /// </summary>
        /// <param name="cod_lib">Números Iniciales de Código</param>
        /// <returns></returns>
        public DataTable _05a(string cod_lib)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT MAX(va_cod_lib) fROM ecp006 ");
                vv_str_sql.AppendFormat(" WHERE  va_cod_lib like '{0}%'", cod_lib);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        public void _06(int cod_lib)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ecp006 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_lib =" + cod_lib);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
