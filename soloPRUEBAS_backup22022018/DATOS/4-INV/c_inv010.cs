using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    public class c_inv010
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
        /// Funcion "Buscar GRUPO DE AlmacénES"
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
                vv_str_sql.AppendLine(" select * from inv010  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendFormat(" where va_cod_gru like '{0}%'",val_bus); break;
                    case 2: vv_str_sql.AppendFormat(" where va_nom_gru like '{0}%'", val_bus); break;
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

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar Grupo de Almacénes
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de Almacén (##-###) -> compuesto por (va_cod_suc , va_nro_gru)</param>
        /// <param name="cod_suc">Codigo de la sucursal al que pertenece el Grupo de Almacén</param>
        /// <param name="nro_gru">Nro. de Grupo</param>
        /// <param name="nom_gru">Nombre del grupo</param>
        /// <param name="des_gru">Descripcion del grupo</param>
        /// <returns></returns>
        public void _02(int cod_gru,int cod_suc,int nro_gru, string nom_gru, string des_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendFormat(" INSERT INTO inv010 VALUES");
                vv_str_sql.AppendFormat(" ({0},{1},{2},", cod_suc, nro_gru, cod_gru);
                vv_str_sql.AppendFormat(" '{0}','{1}','H')", nom_gru, des_gru);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifica Grupo de Almacénes
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de Almacén (##-###) -> compuesto por (va_cod_suc , va_nro_gru)</param>
        /// <param name="cod_suc">Codigo de la sucursal al que pertenece el Grupo de Almacén</param>
        /// <param name="nro_gru">Nro. de Grupo</param>
        /// <param name="nom_gru">Nombre del grupo</param>
        /// <param name="des_gru">Descripcion del grupo</param>
        /// <returns></returns>
        public void _03(int cod_gru,string nom_gru, string des_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv010 SET");
                vv_str_sql.AppendFormat(" va_nom_gru='{0}',va_des_gru='{1}'",nom_gru,des_gru);
                vv_str_sql.AppendFormat(" WHERE  va_cod_gru ={0}", cod_gru);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Grupo de Almacénes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacénes</param>
        /// <param name="est_ado">Estado del Grupo de Almacénes</param>
        /// <returns></returns>
        public void _04(int cod_gru, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv010 SET ");
                vv_str_sql.AppendFormat(" va_est_ado='{0}'",est_ado);
                vv_str_sql.AppendFormat(" WHERE  va_cod_gru ={0}",cod_gru);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Grupo de Almacénes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacénes</param>
        /// <returns></returns>
        public DataTable _05(int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv010 ");
                vv_str_sql.AppendFormat(" WHERE  va_cod_gru ={0}",cod_gru);

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Grupo de Almacénes"
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de Almacénes</param>
        /// <returns></returns>
        public void _06(int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv010 ");
                vv_str_sql.AppendFormat(" WHERE  va_cod_gru ={0}", cod_gru);

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
