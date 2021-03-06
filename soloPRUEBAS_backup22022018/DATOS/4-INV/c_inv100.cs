﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase para el Ingreso de Productos
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>

    public class c_inv100
    {
        #region Variables
        /// <summary>
        /// Codigo de la transacción
        /// </summary>
        public int va_trn_cod;
        /// <summary>
        /// Código de Empresa
        /// </summary>
        public int va_emp_cod;
        /// <summary>
        /// Codigo de la Sucursal
        /// </summary>
        public int va_cod_suc;
        /// <summary>
        /// Código de Gestión
        /// </summary>
        public int va_gst_cod;
        /// <summary>
        /// Fecha de Registro
        /// </summary>
        public DateTime va_fec_pro;
        /// <summary>
        /// Tipo de Transacción. I=Ingreso, E=Egreso, T=Traspaso
        /// </summary>
        public string va_tip_tra;
        /// <summary>
        /// Abreviación del Modulo Origen para saber si desde otro modulo se origino la transacción
        /// </summary>
        public string va_mod_org;
        /// <summary>
        /// Número de transacción del Modulo Origen para saber si desde otro modulo se origino la transacción
        /// </summary>
        public Int32  va_tra_org;
        /// <summary>
        /// Fecha del Documento de Referencia
        /// </summary>
        public DateTime va_fec_tra;
        /// <summary>
        /// Nro de Referencia ó Numero de Documento
        /// </summary>
        public int va_ref_doc;
        /// <summary>
        /// Moneda (B=Bolivianos; D=Dolares), Solo para Ingreso
        /// </summary>
        public string va_mon_tra;
        /// <summary>
        /// Glosa
        /// </summary>
        public string va_tra_glo;
        /// <summary>
        ///  Codigo del Producto
        /// </summary>
        public string va_cod_pro;
        /// <summary>
        ///  Cantida
        /// </summary>
        public decimal va_can_pro;
        /// <summary>
        ///  Costo Unitario
        /// </summary>
        public decimal va_cos_uni;
        /// <summary>
        ///  Importe Total 
        /// </summary>
        public decimal va_imp_tot;
        /// <summary>
        ///  Código de Almacén Origen
        /// </summary>
        public int va_alm_mov;
        /// <summary>
        ///  Código de Lote
        /// </summary>
        public string va_lot_cod;
        /// <summary>
        ///  Fecha de Registro
        /// </summary>
        public DateTime va_fec_ven;
        /// <summary>
        ///  Estado. V=Vigente, R=Revertido
        /// </summary>
        public string va_est_tra;
        /// <summary>
        ///  Marca con Factura 0 = Con Factura, 1 = Exenta
        /// </summary>
        public string va_tra_fac;
        /// <summary>
        /// Marca con Retension 0 = Sin Retencion, 1= Con Retencion
        /// </summary>
        public string va_tra_ret;
        /// <summary>
        /// Tipo de Cambio de la Transaccion
        /// </summary>
        public decimal va_tas_cam;
        /// <summary>
        /// COdigo del Talonario
        /// </summary>
        public int va_nro_tal;
       
        #endregion


        #region DatosEnumerados
        public enum TipoTransaccions
        {
            Ingreso = 1,
            Egreso = 2,
            Traspaso = 3
        }
        #endregion


        #region Metodos
        public bool fu_reg_mov(c_cnx000 _cnx000, TipoTransaccions tipo)
        {
            try
            {
                if (tipo == TipoTransaccions.Ingreso)
                {
                    StringBuilder vv_str_sql = new StringBuilder();
                    vv_str_sql.AppendLine(" Insert into inv100( ");
                    vv_str_sql.AppendLine("va_emp_cod,va_cod_suc,va_gst_cod,va_fec_pro,va_tip_tra,va_cod_doc,va_tra_org,");
                    vv_str_sql.AppendLine("va_fec_tra,va_ref_doc,va_mon_tra,va_tra_glo,va_cod_pro,va_can_pro,va_cos_uni,");
                    vv_str_sql.AppendLine("va_imp_tot,va_alm_mov,va_lot_cod,va_fec_ven,va_tra_fac,va_tra_ret,va_tas_cam,va_nro_tal)");
                    vv_str_sql.AppendFormat(" values({0}, ", va_emp_cod);
                    vv_str_sql.AppendFormat(" {0}, ", va_cod_suc);
                    vv_str_sql.AppendFormat(" {0}, ", va_gst_cod);
                    vv_str_sql.AppendFormat(" '{0}', ", va_fec_pro.ToShortDateString());
                    vv_str_sql.AppendFormat(" '{0}', ", "1");
                    vv_str_sql.AppendFormat(" '{0}', ", va_mod_org);
                    vv_str_sql.AppendFormat(" {0}, ", va_tra_org );
                    vv_str_sql.AppendFormat(" '{0}', ", va_fec_tra.ToShortDateString());
                    vv_str_sql.AppendFormat(" {0}, ", va_ref_doc);
                    vv_str_sql.AppendFormat(" '{0}', ", va_mon_tra);
                    vv_str_sql.AppendFormat(" '{0}', ", va_tra_glo);
                    vv_str_sql.AppendFormat(" '{0}', ", va_cod_pro);
                    vv_str_sql.AppendFormat(" {0}, ", va_can_pro);
                    vv_str_sql.AppendFormat(" {0}, ", va_cos_uni);
                    vv_str_sql.AppendFormat(" {0}, ", va_imp_tot);
                    vv_str_sql.AppendFormat(" {0}, ", va_alm_mov);
                    vv_str_sql.AppendFormat(" '{0}', ", va_lot_cod);
                    vv_str_sql.AppendFormat(" '{0}', ", va_fec_ven.ToShortDateString());
                    vv_str_sql.AppendFormat(" '{0}', ", va_tra_fac);
                    vv_str_sql.AppendFormat(" '{0}', ", va_tra_ret);
                    vv_str_sql.AppendFormat(" {0}, ", va_tas_cam);
                    vv_str_sql.AppendFormat(" {0}) ", va_nro_tal);
                    if (!_cnx000.fu_exe_sql_no(vv_str_sql.ToString()))
                    {
                        Exception ex = new Exception("No se pudo Registrar el Movimiento del Producto: " + va_cod_pro);
                        throw ex;
                    }
                    else
                    {
                        c_inv101 o_inv101 = new c_inv101();
                        o_inv101.va_cod_alm = va_alm_mov;
                        o_inv101.va_cod_pro = va_cod_pro;
                        o_inv101.va_cod_suc = va_cod_suc;
                        o_inv101.va_cos_ubs = va_cos_uni;
                        o_inv101.va_sal_can = va_can_pro;

                        c_adm013 objTipo = new c_adm013();
                        DataTable dtTipo = objTipo._05(va_fec_tra.ToShortDateString());
                        if (dtTipo.Rows.Count == 0)
                        {
                            o_inv101.va_cos_uus = Math.Round(va_cos_uni / va_tas_cam, 2);
                        }
                        else
                        {
                            o_inv101.va_cos_uus = Math.Round(va_cos_uni / Convert.ToDecimal(((DataRow)dtTipo.Rows[0])["va_val_bus"]), 2);
                        }

                        
                        o_inv101.va_emp_cod = va_emp_cod;
                        o_inv101.va_fec_ven = va_fec_ven;
                        o_inv101.va_nro_lote = va_lot_cod;
                        o_inv101.va_ult_cbs = va_cos_uni;
                        o_inv101.va_ult_cus = o_inv101.va_cos_uus;
                        o_inv101.va_est_ado = "H";

                        if (!o_inv101.fu_ing_art(_cnx000))
                        {
                            Exception ex = new Exception("No se pudo Registrar el Movimiento del Producto: " + va_cod_pro);
                            throw ex;
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion


    }
}

