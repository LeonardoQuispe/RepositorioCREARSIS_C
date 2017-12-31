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
        /// Funcion "Buscar AlmacénES"
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
                    case 1: vv_str_sql.AppendFormat(" where va_cod_alm like '{0}%'",val_bus); break;
                    case 2: vv_str_sql.AppendFormat(" where va_nom_alm like '{0}%'", val_bus); break;
                }

                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    vv_str_sql.AppendFormat(" and va_est_ado ='{0}'",est_bus);
                }

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar AlmacénES
        /// </summary>
        /// <param name="cod_alm">Codigo deL Almacén (##-##- ###) -> compuesto por (va_cod_gru , va_nro_alm)</param>
        /// <param name="cod_gru">Grupo de Almacén </param>
        /// <param name="nro_alm">Nro. de Almacén</param>
        /// <param name="nom_alm">Nombre del Almacén</param>
        /// <param name="des_alm">Descripcion del Almacén</param>
        /// <param name="dir_alm">Direccion del Almacén</param>
        /// <param name="fec_ctr">ULTIMA FECHA CONTROL  DEL Almacén</param>
        /// <param name="mon_inv">Moneda del inventario B=Bolivianos ; U=Dolares</param>
        /// <param name="mtd_cto">Metodo de costeo 
        ///                         Promedio Ponderado(Solo usaremos este inicialmente)
        ///                         C=UEPS(Ultimos en Entrar, Primeros en Salir)
        ///                         A=PEPS(Primeros en Entrar Primeros en Salir)</param>
        /// <param name="nom_ecg">Nombre del encargado del Almacén</param>
        /// <param name="tlf_ecg">Telefono del encargado</param>
        /// <param name="dir_ecg">Direccion del encargado</param>
        /// <param name="cta_alm">Cuenta contable del Almacén</param>
        /// <returns></returns>
        public DataTable _02(int cod_alm, int cod_gru, int nro_alm, string nom_alm, string des_alm
                            ,string dir_alm, DateTime fec_ctr, string mon_inv
                            ,string mtd_cto,string nom_ecg,string tlf_ecg,string dir_ecg,string cta_alm)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv011 VALUES");

                switch (mon_inv)
                {
                    case "0": mon_inv = "B"; break;
                    case "1": mon_inv = "U"; break;
                }

                switch (mtd_cto)
                {
                    case "0": mtd_cto = "P"; break;
                }

                vv_str_sql.AppendFormat(" ({0},{1},{2},'{3}','{4}',", cod_gru, nro_alm,cod_alm,nom_alm,des_alm);
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','H','{3}',",dir_alm, cta_alm, fec_ctr.ToShortDateString(),mon_inv);
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','{3}')",mtd_cto,nom_ecg,tlf_ecg,dir_ecg);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica AlmacénES
        /// </summary>
        /// <param name="cod_alm">Codigo deL Almacén (##-##-###) -> compuesto por (va_cod_gru , va_nro_alm)</param>
        /// <param name="nom_alm">Nombre del Almacén</param>
        /// <param name="des_alm">Descripcion del Almacén</param>
        /// <param name="dir_alm">Direccion del Almacén</param>
        /// <param name="fec_ctr">ULTIMA FECHA CONTROL  DEL Almacén</param>
        /// <param name="mon_inv">Moneda del inventario B=Bolivianos ; U=Dolares</param>
        /// <param name="mtd_cto">Metodo de costeo 
        ///                         Promedio Ponderado(Solo usaremos este inicialmente)
        ///                         C=UEPS(Ultimos en Entrar, Primeros en Salir)
        ///                         A=PEPS(Primeros en Entrar Primeros en Salir)</param>
        /// <param name="nom_ecg">Nombre del encargado del Almacén</param>
        /// <param name="tlf_ecg">Telefono del encargado</param>
        /// <param name="dir_ecg">Direccion del encargado</param>
        /// <param name="cta_alm">Cuenta contable del Almacén</param>
        /// <returns></returns>
        public DataTable _03(int cod_alm, string nom_alm, string des_alm,string dir_alm
                            , string mon_inv, string mtd_cto
                            , string nom_ecg, string tlf_ecg, string dir_ecg, string cta_alm)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv011 SET");

                switch (mon_inv)
                {
                    case "0": mon_inv = "B"; break;
                    case "1": mon_inv = "U"; break;
                }

                switch (mtd_cto)
                {
                    case "0": mtd_cto = "P"; break;
                }

                vv_str_sql.AppendFormat(" va_nom_alm='{0}',va_des_alm='{1}',va_dir_alm='{2}',",nom_alm, des_alm,dir_alm);
                vv_str_sql.AppendFormat("va_mon_inv='{0}',va_mtd_cto='{1}',",mon_inv,mtd_cto);
                vv_str_sql.AppendFormat("va_nom_ecg='{0}',va_tlf_ecg='{1}',va_dir_ecg='{2}',va_cta_alm='{3}'",nom_ecg,tlf_ecg,dir_ecg,cta_alm);
                vv_str_sql.AppendFormat(" WHERE va_cod_alm={0}", cod_alm);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita AlmacénES"
        /// </summary>
        /// <param name="cod_alm">Codigo del AlmacénES</param>
        /// <param name="est_ado">Estado del AlmacénES</param>
        /// <returns></returns>
        public DataTable _04(int cod_alm, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv011 SET ");
                vv_str_sql.AppendFormat(" va_est_ado='{0}'",est_ado);
                vv_str_sql.AppendFormat(" WHERE  va_cod_alm ={0}",cod_alm);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta AlmacénES"
        /// </summary>
        /// <param name="cod_gru">Codigo del AlmacénES</param>
        /// <returns></returns>
        public DataTable _05(int cod_alm)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv011 ");
                vv_str_sql.AppendFormat(" WHERE va_cod_alm={0}",cod_alm);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina AlmacénES"
        /// </summary>
        /// <param name="cod_gru">Codigo del AlmacénES</param>
        /// <returns></returns>
        public DataTable _06(int cod_alm)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv011 ");
                vv_str_sql.AppendFormat(" WHERE va_cod_alm={0}",cod_alm);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
