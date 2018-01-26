using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._8_TES
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase CAJA/BANCO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_tes001
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
        /// Funcion "Buscar Caja/Banco"
        /// </summary>
        /// <param name="val_bus">Valor del busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="tip_cjb">Tipo de Caja/Banco (1=Caja ; 2=Banco)</param>
        /// <param name="est_bus">Estado de la Búsqueda (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, int tip_cjb, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from tes001 ");

                switch (prm_bus)
                {
                    case 0: vv_str_sql.AppendLine(" where va_cod_cjb like '" + val_bus + "%' "); break;
                    case 1: vv_str_sql.AppendLine(" where va_nom_cjb like '" + val_bus + "%' "); break;
                }

                switch (tip_cjb)
                {
                    case 1: vv_str_sql.AppendLine(" and va_tip_cjb=1"); break;
                    case 2: vv_str_sql.AppendLine(" and va_tip_cjb=2"); break;
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
        /// Registrar Caja/Banco
        /// </summary>
        /// <param name="cod_cjb">Código Caja/Banco (5 Números)</param>
        /// <param name="tip_cjb">Tipo (1=Caja ; 2=Banco )</param>
        /// <param name="mon_cjb">Moneda (B=Bolivianos; U=USD)</param>
        /// <param name="nro_cjb">Nro Correlativo de Caja/Banco (3 Numeros)</param>
        /// <param name="nom_cjb">Nombre de Caja/Banco</param>
        /// <param name="nro_cta">Numero de Cuenta Banco</param>
        /// <param name="sal_cjb">Saldo de Caja/Banco</param>
        /// <param name="cod_cta">Código Cuenta Contable</param>
        public void _02(int cod_cjb, int tip_cjb, string mon_cjb,string nom_cjb,
                        string nro_cta,decimal sal_cjb, string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO tes001 VALUES");
                vv_str_sql.AppendFormat(" ({0},{1},'{2}',", cod_cjb, tip_cjb, mon_cjb);
                vv_str_sql.AppendFormat("'{0}','{1}',{2},'{3}','H')", nom_cjb, nro_cta,sal_cjb,cod_cta);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica Caja/Banco
        /// </summary>
        /// <param name="cod_cjb">Código de la Caja/Banco (5 Numeros)
		///					        Formato ---> TMNNN
        ///							T=Tipo
		///							M=Moneda
	    ///							N=Nro Correlativo de Caja/Banco</param>
        /// <param name="tip_cjb">Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')</param>
        /// <param name="mon_cjb">Moneda (B=Bolivianos; U=USD)</param>
        /// <param name="nro_cjb">Nro Correlativo de Caja/Banco (3 Numeros)</param>
        /// <param name="nom_cjb">Descripcion de la Caja/Banco</param>
        /// <param name="cod_cta">Cod. Cuenta Contable</param>
        public void _03(int cod_cjb, string nom_cjb,string nro_cta, string cod_cta)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE tes001 SET");
                vv_str_sql.AppendFormat(" va_nom_cjb='{0}',va_nro_cta='{1}',va_cod_cta='{2}'", nom_cjb,nro_cta, cod_cta);
                vv_str_sql.AppendFormat(" WHERE va_cod_cjb ={0}", cod_cjb);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Caja/Banco"
        /// </summary>
        /// <param name="cod_cjb">Codigo de la Caja/Banco</param>
        /// <param name="est_ado">Estado de la Caja/Banco</param>
        /// <returns></returns>
        public void _04(int cod_cjb, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE tes001 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cjb =" + cod_cjb);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Caja/Banco"
        /// </summary>
        /// <param name="cod_cjb">Codigo de la Caja/Banco</param>
        /// <returns></returns>
        public DataTable _05(int cod_cjb)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM tes001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cjb =" + cod_cjb);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion Sugerir Nro de Caja/Banco
        /// </summary>
        /// <param name="cod_cjb">Números Iniciales de Código</param>
        /// <returns></returns>
        public DataTable _05a(string cod_cjb)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT MAX(va_cod_cjb) fROM tes001 ");
                vv_str_sql.AppendFormat(" WHERE  va_cod_cjb like '{0}%'",cod_cjb);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Caja/Banco"
        /// </summary>
        /// <param name="cod_cjb">Codigo del Caja/Banco</param>
        /// <returns></returns>
        public void _06(int cod_cjb)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE tes001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_cjb =" + cod_cjb);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
