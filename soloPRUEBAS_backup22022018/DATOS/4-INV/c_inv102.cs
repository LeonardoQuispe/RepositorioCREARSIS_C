using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DATOS
{/// <summary>
 /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
 /// Clase Saldo Lote y Producto x Almacen
 /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
 /// </summary>
    public class c_inv102
    {
        /// <summary>
        /// Objeto del clase conexion
        /// </summary>
        //c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        /// Codigo identiy de la tabla
        /// </summary>
        public int va_cod_lxp;
        /// <summary>
        /// Codigo de la Empresa
        /// </summary>
        public int va_emp_cod;
        /// <summary>
        /// Codigo de la Sucursal
        /// </summary>
        public int va_cod_suc;
        /// <summary>
        /// Codigo del Almacen
        /// </summary>
        public int va_cod_alm;
        /// <summary>
        /// Codigo del Producto
        /// </summary>
        public string va_cod_pro;
        /// <summary>
        /// Stock por Lote y Producto X Almacen
        /// </summary>
        public decimal va_sal_can;
        /// <summary>
        /// Codigo del Lote, hace referencia al Identiy de la tabla inv103
        /// </summary>
        public int va_lot_cod;
        /// <summary>
        /// Fecha de Vencimiento del Lote
        /// </summary>
        public DateTime va_fec_ven;
        /// <summary>
        /// Estado del Producto x Almacen H:Habilidato, D:Desabilidato
        /// </summary>
        public string va_est_ado;
        /// <summary>
        /// Numero de Lote
        /// </summary>
        public string va_nro_lote;

        #region Metodos


        /// <summary>
        /// funcion "Consulta de Lote y Producto x Almacen"
        /// </summary>
        /// <param name="_cnx000">Objeto Conexion</param>
        /// <param name="_cod_emp">Codigo de Empresa</param>
        /// <param name="_cod_suc">Codigo de Sucursal</param>
        /// <param name="_cod_alm">Codigo del Almacén</param>
        /// <param name="_cod_pro">Codigo del Producto</param>
        /// /// <param name="_cod_lot">Codigo del Lote</param>
        /// <returns></returns>
        private Boolean fu_sel_lot_pro_alm(c_cnx000 _cnx000, int _cod_emp, int _cod_suc, int _cod_alm, string _cod_pro, int _cod_lot)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv102 ");
                vv_str_sql.AppendFormat(" WHERE va_emp_cod={0}", _cod_emp);
                vv_str_sql.AppendFormat(" AND va_cod_suc={0}", _cod_suc);
                vv_str_sql.AppendFormat(" AND va_cod_alm={0}", _cod_alm);
                vv_str_sql.AppendFormat(" AND va_cod_pro='{0}'", _cod_pro);
                vv_str_sql.AppendFormat(" AND va_lot_cod={0}", _cod_lot);

                DataTable dt_pro_alm = _cnx000.fu_exe_sql_si(vv_str_sql.ToString());

                if (dt_pro_alm.Rows.Count > 0)
                {
                    DataRow row = dt_pro_alm.Rows[0];
                    va_cod_alm = Convert.ToInt32(row["va_cod_alm"]);
                    va_emp_cod = Convert.ToInt32(row["va_emp_cod"]);
                    va_cod_suc = Convert.ToInt32(row["va_cod_suc"]);
                    va_cod_alm = Convert.ToInt32(row["va_cod_alm"]);
                    va_cod_pro = row["va_cod_pro"].ToString();
                    va_sal_can = Convert.ToDecimal(row["va_sal_can"]);

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Boolean fu_ing_lot_art(c_cnx000 _cnx000)
        {
            try
            {
                if (va_nro_lote == null)
                {
                    Exception ex = new Exception("Introduzca el Número de Lote");
                    throw ex;
                }

                c_inv103 o_inv103 = new c_inv103();
                DataTable dt_lote = o_inv103._01(va_nro_lote, 3, "1");
                if (dt_lote.Rows.Count == 0)
                {
                    //Al no Existir el Lote, Seteamos los parametros 
                    o_inv103.va_cod_suc = va_cod_suc;
                    o_inv103.va_emp_cod = va_emp_cod;
                    o_inv103.va_des_lot = va_nro_lote;
                    o_inv103.va_nro_lot = va_nro_lote;
                    o_inv103.va_fec_ven = va_fec_ven;
                    o_inv103.va_est_ado = "H";
                    //Realizamos el registro del Lote 
                    o_inv103._02();

                }

                c_inv102 o_inv102 = new c_inv102();

                //Verifciamos si Existe la relacion Lote, Producto x Almacen
                //Sino existe, realizamos un Insert, caso contrario sumamos el Stock
                if (!o_inv102.fu_sel_lot_pro_alm(_cnx000, va_emp_cod, va_cod_suc, va_cod_alm, va_cod_pro, va_lot_cod))
                {
                    string sSQL = String.Format("INSERT INTO inv102(va_emp_cod,va_cod_suc,va_lot_cod,va_cod_pro,va_cod_alm,va_fec_ven,va_sal_can) VALUES({0},{1},{2},'{3}',{4},'{5}',{6})", va_emp_cod, va_cod_suc, va_lot_cod, va_cod_pro, va_cod_alm, va_fec_ven.ToShortDateString(), va_sal_can);
                    _cnx000.fu_exe_sql_no(sSQL);
                }
                else
                {
                    va_sal_can += o_inv102.va_sal_can;
                }
                DataRow row = dt_lote.Rows[0];
                va_lot_cod = Convert.ToInt32(row["va_cod_lote"]);

                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" update inv102 ");
                vv_str_sql.AppendFormat(" set va_sal_can ={0}, ", va_sal_can);
                vv_str_sql.AppendFormat(" WHERE va_cod_alm={0}", va_cod_alm);
                vv_str_sql.AppendFormat(" and va_cod_pro='{0}'", va_cod_pro);
                vv_str_sql.AppendFormat(" and va_emp_cod={0}", va_emp_cod);
                vv_str_sql.AppendFormat(" and va_cod_suc={0}", va_cod_suc);
                vv_str_sql.AppendFormat(" and va_lot_cod={0}", va_lot_cod);

                return _cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
