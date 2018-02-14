using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase  para el Maestro de Lotes
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_inv103
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
        /// Codigo Identity de la Tabla
        /// </summary>
        public int va_cod_lote;
        /// <summary>
        /// Codigo de la Empresa
        /// </summary>
        public int va_emp_cod;
        /// <summary>
        /// Codigo de la Sucursal
        /// </summary>
        public int va_cod_suc;
        /// <summary>
        /// Numero del Lote
        /// </summary>
        public string va_nro_lot;
        /// <summary>
        /// Descripcion del Lote
        /// </summary>
        public string va_des_lot;
        /// <summary>
        /// Fecha de Fabricacion
        /// </summary>
        public DateTime va_fec_fab;
        /// <summary>
        /// Fecha de Vencimiento
        /// </summary>
        public DateTime va_fec_ven;
        /// <summary>
        /// Estado del Lote H:Habilidato, D:Desabilidato
        /// </summary>
        public string va_est_ado;

        #region Metodos
        /// <summary>
        /// Funcion "Buscar Lotes"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=Numero ; 2=Nombre ; 3=Numero Exacto)</param>
        /// <param name="est_bus">Parametro estado de busqueda (0=Todos; 1=Habilitado ; 2=Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv103  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendFormat(" where va_nro_lote like '{0}%'", val_bus); break;
                    case 2: vv_str_sql.AppendFormat(" where va_des_lote like '{0}%'", val_bus); break;
                    case 3: vv_str_sql.AppendFormat(" where UPPER(RTRIM(LTRIM(va_nro_lote)))) = '{0}'", val_bus.Trim().ToUpper()); break;
                }

                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    vv_str_sql.AppendFormat(" and va_est_ado ='{0}'", est_bus);
                }

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Registrar Lotes
        /// </summary>
        /// <returns></returns>
        public void _02()
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv103(va_emp_cod,va_cod_suc,va_nro_lot,va_des_lot,va_fec_fab,va_fec_ven) VALUES");

                vv_str_sql.AppendFormat(" ({0},{1},'{2}','{3}','{4}','{5}'", va_emp_cod, va_cod_suc, va_nro_lot, va_des_lot, va_fec_fab.ToShortDateString(), va_fec_ven.ToShortDateString());

                va_cod_lote = o_cnx000.fu_exe_sql_id(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
