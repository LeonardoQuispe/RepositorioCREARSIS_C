using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    public class c_inv011
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
        /// Funcion "Buscar ALMACENES"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="est_bus">Parametro estado de busqueda (0=Todos; 1=Habilitado ; 2=Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv011  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_alm like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_alm like '" + val_bus + "%' "); break;
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
        /// Registrar ALMACENES
        /// </summary>
        /// <param name="cod_alm">Codigo deL ALMACEN (##-##- ###) -> compuesto por (va_cod_gru , va_nro_alm)</param>
        /// <param name="cod_gru">Grupo de Almacen </param>
        /// <param name="nro_alm">Nro. de almacen</param>
        /// <param name="nom_alm">Nombre del almacen</param>
        /// <param name="des_alm">Descripcion del almacen</param>
        /// <param name="dir_alm">Direccion del almacen</param>
        /// <param name="fec_ctr">ULTIMA FECHA CONTROL  DEL ALMACEN</param>
        /// <param name="est_ado">ULTIMA FECHA CONTROL  DEL ALMACEN</param>
        /// <param name="mon_inv">Moneda del inventario B=Bolivianos ; U=Dolares</param>
        /// <param name="mtd_cto">Metodo de costeo 
        ///                         Promedio Ponderado(Solo usaremos este inicialmente)
        ///                         C=UEPS(Ultimos en Entrar, Primeros en Salir)
        ///                         A=PEPS(Primeros en Entrar Primeros en Salir)</param>
        /// <param name="nom_ecg">Nombre del encargado del almacen</param>
        /// <param name="tlf_ecg">Telefono del encargado</param>
        /// <param name="dir_ecg">Direccion del encargado</param>
        /// <param name="cta_alm">Cuenta contable del almacen</param>
        /// <returns></returns>
        public DataTable _02(int cod_alm, int cod_gru, int nro_alm, string nom_alm, string des_alm
                            ,string dir_alm, DateTime fec_ctr, string est_ado, string mon_inv
                            ,string mtd_cto,string nom_ecg,string tlf_ecg,string dir_ecg,string cta_alm)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv011 VALUES");
                vv_str_sql.AppendLine(" (" + cod_gru + ", " + nro_alm + ", " + cod_alm + ",'" + nom_alm);
                vv_str_sql.AppendLine("','" + des_alm + "','" + dir_alm + "','" + fec_ctr.ToShortDateString());
                vv_str_sql.AppendLine("','H','"+mon_inv + "','" + mtd_cto + "','" + nom_ecg);
                vv_str_sql.AppendLine("','" + tlf_ecg + "','" + dir_ecg + "','" + cta_alm+"'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica ALMACENES
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de Almacen (##-###) -> compuesto por (va_cod_suc , va_nro_gru)</param>
        /// <param name="cod_suc">Codigo de la sucursal al que pertenece el Grupo de almacen</param>
        /// <param name="nro_gru">Nro. de Grupo</param>
        /// <param name="nom_gru">Nombre del grupo</param>
        /// <param name="des_gru">Descripcion del grupo</param>
        /// <returns></returns>
        public DataTable _03(int cod_gru, string nom_gru, string des_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv011 SET");
                vv_str_sql.AppendLine(" va_cod_alm=" + cod_gru + ", va_nom_alm='" + nom_gru + "', ");
                vv_str_sql.AppendLine(" va_des_gru='" + des_gru + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita ALMACENES"
        /// </summary>
        /// <param name="cod_gru">Codigo del ALMACENES</param>
        /// <param name="est_ado">Estado del ALMACENES</param>
        /// <returns></returns>
        public DataTable _04(int cod_gru, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv011 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "'");
                vv_str_sql.AppendLine(" WHERE  va_cod_alm = " + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta ALMACENES"
        /// </summary>
        /// <param name="cod_gru">Codigo del ALMACENES</param>
        /// <returns></returns>
        public DataTable _05(int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv011 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_alm =" + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina ALMACENES"
        /// </summary>
        /// <param name="cod_gru">Codigo del ALMACENES</param>
        /// <returns></returns>
        public DataTable _06(int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv011 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_alm =" + cod_gru);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
