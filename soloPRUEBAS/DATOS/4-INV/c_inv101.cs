using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DATOS._4_INV;
namespace DATOS
{   /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Producto X Almacen
    /// Tambien nos sirver para realizar el Calculo de Costo Promedio
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>

    public class c_inv101
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
        /// Codigo Identiy de Producto X Almacen
        /// </summary>
       	public int va_pro_alm;
        /// <summary>
        /// Código de Empresa
        /// </summary>
	    public int va_emp_cod;
        /// <summary>
        /// Codigo de la Sucursal
        /// </summary>
	    public int va_cod_suc;
        /// <summary>
        /// Código de Almacén
        /// </summary>
	    public int va_cod_alm;
        /// <summary>
        /// Código de Producto
        /// </summary>
	    public string va_cod_pro;
        /// <summary>
        /// Stock total x almacén
        /// </summary>
	    public decimal va_sal_can;
        /// <summary>
        /// Costo Unitario - cálculo = promedio ponderado en Bs
        /// </summary>
	    public decimal va_cos_ubs;
        /// <summary>
        /// Costo Unitario - cálculo = promedio ponderado en USD
        /// </summary>
	    public decimal va_cos_uus;
        /// <summary>
        /// Último Costo de Ingreso en Bs
        /// </summary>
	    public decimal va_ult_cbs;
        /// <summary>
        /// Último Costo de Ingreso en USD
        /// </summary>
        public decimal va_ult_cus;
        /// <summary>
        /// Estado del Producto x Almacen H:Habilidato, D:Desabilidato
        /// </summary>
        public string va_est_ado;
        /// <summary>
        /// Numero Lote
        /// </summary>
        public string va_nro_lote;
        /// <summary>
        /// Fecha de Vencimiento Lote
        /// </summary>
        public DateTime va_fec_ven;
        //#region DatosEnumerados
        //    enum TipoTransaccions
        //    { 
        //        Ingreso = 1,
        //        Egreso = 2,
        //        Traspaso = 3
        //    } 
        //#endregion

        #region Metodos
        /// <summary>
        /// funcion "Consulta Producto x Almacen"
        /// </summary>
        /// <param name="o_cnx000">Objeto Conexion</param>
        /// <param name="cod_emp">Codigo de Empresa</param>
        /// <param name="cod_suc">Codigo de Sucursal</param>
        /// <param name="cod_alm">Codigo del Almacén</param>
        /// <param name="cod_pro">Codigo del Producto</param>
        /// <returns></returns>
        private Boolean fu_sel_pro_alm(c_cnx000 _cnx000, int cod_emp, int cod_suc, int cod_alm, string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv101 ");
                vv_str_sql.AppendFormat(" WHERE va_emp_cod={0}", cod_emp);
                vv_str_sql.AppendFormat(" AND va_cod_suc={0}", cod_suc);
                vv_str_sql.AppendFormat(" AND va_cod_alm={0}", cod_alm);
                vv_str_sql.AppendFormat(" AND va_cod_pro='{0}'", cod_pro);

                DataTable dt_pro_alm = o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

                if (dt_pro_alm.Rows.Count > 0)
                {
                    DataRow row = dt_pro_alm.Rows[0];
                    va_pro_alm = Convert.ToInt32(row["va_pro_alm"]);
                    va_emp_cod = Convert.ToInt32(row["va_emp_cod"]);
                    va_cod_suc = Convert.ToInt32(row["va_cod_suc"]);
                    va_cod_alm = Convert.ToInt32(row["va_cod_alm"]);
                    va_cod_pro = row["va_cod_pro"].ToString();
                    va_sal_can = Convert.ToDecimal(row["va_sal_can"]);
                    va_cos_ubs = Convert.ToDecimal(row["va_cos_ubs"]);
                    va_cos_uus = Convert.ToDecimal(row["va_cos_uus"]);
                    va_ult_cbs = Convert.ToDecimal(row["va_ult_cbs"]);
                    va_ult_cus = Convert.ToDecimal(row["va_ult_cus"]);
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
        #endregion

        #region Ingreso
        /// <summary>
        /// Actualiza los valor de inventarios de productos y almacen productos por una operación de ingreso 
        /// </summary>
        public Boolean fu_ing_art(c_cnx000 _cnx000)
        {     // StockTrans = Stock en tránsito
              // StockTrans = 0    Cuando es ingreso normal
              // StockTrans <> 0   Cuando es ingreso por compras (Recepcion)
              // StockTrans < cant Solo cuando se recibe mas de lo pedido en O/C
              // ItemDetalle = Registro de detalle con producto y cantidad
              // Ajuste = Variable de ajuste por diferencia de costos, se retorna el valor de ajuste
            decimal dbl_Stock;  // Stock
            decimal dbl_CostoBs; // Costo total Bs
            decimal dbl_CostoUsd; // Costo total USD
            string sSQL;
            bool lSerie = false;
            bool lLote = false;
            try
            {
                if (_cnx000 == null)
                    o_cnx000.fu_abr_cnx();
                else
                    o_cnx000 = _cnx000;

                c_inv002 o_inv002 = new c_inv002(); //Producto
                c_inv011 o_inv011 = new c_inv011(); //Almacen
                c_inv101 o_inv101 = new c_inv101(); //Producto x Almacen


                // Si no existe el producto en el almacén se crea uno nuevo
                if (!o_inv101.fu_sel_pro_alm(o_cnx000, va_emp_cod, va_cod_suc, va_cod_alm, va_cod_pro))
                {
                    DataTable dt_pro = o_inv002._05(va_cod_pro);
                    if (!(dt_pro.Rows.Count > 0))
                    {
                        Exception ex = new Exception("El Producto " + va_cod_pro + " NO esta registrado");
                        throw ex;
                    }
                    else
                    {
                        DataRow row = dt_pro.Rows[0];
                        if (row["va_ban_lot"].ToString() == "1") //Verificamos si Controla Lote
                            lLote = true;
                        if (row["va_ban_ser"].ToString() == "1") //Verificamos si Controla Serie
                            lSerie = true;
                    }
                    if (!(o_inv011._05(va_cod_alm).Rows.Count > 0))
                    {
                        Exception ex = new Exception("El Almacen " + va_cod_pro + " NO esta registrado");
                        throw ex;
                    }

                    sSQL = String.Format("INSERT INTO inv101(va_emp_cod,va_cod_suc,va_cod_alm,va_cod_pro) VALUES({0},{1},{2},'{3}')", va_emp_cod, va_cod_suc, va_cod_alm, va_cod_pro);
                    o_cnx000.fu_exe_sql_no(sSQL);

                    o_inv101.va_cos_ubs = 0;
                    o_inv101.va_cos_uus = 0;
                    o_inv101.va_sal_can = 0;

                }

                //Verificamos si el producto Controla Lote 
                if (lLote)
                {
                    c_inv102 o_inv102 = new c_inv102();
                    o_inv102.va_nro_lote = va_nro_lote;
                    o_inv102.va_emp_cod = va_emp_cod;
                    o_inv102.va_cod_suc = va_cod_suc;
                    o_inv102.va_cod_pro = va_cod_pro;
                    o_inv102.va_cod_alm = va_cod_alm;
                    if (!o_inv102.fu_ing_lot_art(_cnx000))
                    {

                        Exception ex = new Exception("No se pudo Registrar el Ingreso Por Lote del Producto: " + va_cod_pro);
                        throw ex;
                    }
                }

                if (lSerie)
                {

                }
                dbl_CostoBs = o_inv101.va_cos_ubs;
                dbl_CostoUsd = o_inv101.va_cos_uus;
                dbl_Stock = o_inv101.va_sal_can;


                //Calculo del Costo Promedio
                va_sal_can += dbl_Stock;
                va_cos_ubs = Math.Round((va_cos_ubs + dbl_CostoBs) / va_sal_can, 6);
                va_cos_uus = Math.Round((va_cos_uus + dbl_CostoUsd) / va_sal_can, 6);

                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" update inv101 ");
                vv_str_sql.AppendFormat(" set va_sal_can ={0}, ", va_sal_can);
                vv_str_sql.AppendFormat("  va_cos_ubs ={0}, ", va_cos_ubs);
                vv_str_sql.AppendFormat("  va_cos_uus ={0}, ", va_cos_uus);
                vv_str_sql.AppendFormat("  va_ult_cbs ={0}, ", va_ult_cbs);
                vv_str_sql.AppendFormat("  va_ult_cus ={0} ", va_ult_cus);

                vv_str_sql.AppendFormat(" WHERE va_cod_alm={0}", va_cod_alm);
                vv_str_sql.AppendFormat(" and va_cod_pro='{0}'", va_cod_pro);
                vv_str_sql.AppendFormat(" and va_emp_cod={0}", va_emp_cod);
                vv_str_sql.AppendFormat(" and va_cod_suc={0}", va_cod_suc);

                return o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
