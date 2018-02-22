using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
namespace DATOS._9_CMP
{
    /// <summary>
    /// Clase Principal del documento de Compra
    /// </summary>
   public class c_cmp001
    {
        #region Variables
        /// <summary>
        /// Codigo Identiy del Documento de Compra
        /// </summary>
        public Int32 va_cod_cmp;
        /// <summary>
        /// Codigo del Documento
        /// </summary>
        public string va_cod_doc;
        /// <summary>
        /// COdigo del Talonario
        /// </summary>
        public int va_nro_tal;
        /// <summary>
        /// Numero del Documento
        /// </summary>
        public Int32 va_nro_doc;
        /// <summary>
        /// Codigo del Proveedor
        /// </summary>
        public string va_cod_prv;
        /// <summary>
        /// Fecha de Registro de la Factura
        /// </summary>
        public DateTime va_fec_cmp;
        /// <summary>
        /// Codigo de la Gestion
        /// </summary>
        public int va_cod_ges;
        /// <summary>
        /// Código de Empresa
        /// </summary>
        public int va_emp_cod;
        /// <summary>
        /// Código de la Sucursal
        /// </summary>
        public int va_cod_suc;
        /// <summary>
        /// Tipo de Compra IVA = IVA, EXE = EXENTO, RETBIEN = RETENCION BIEN,RETSER=RETENCION SERVICIOS, IVAXREC = IVA POR RECUPERAR
        /// </summary>
        public string va_tip_cmp;
        /// <summary>
        /// Código del Almacen
        /// </summary>
        public int va_cod_alm ;
        /// <summary>
        /// Fecha de Emision(este campo aplica mas para las factura)
        /// </summary>
        public DateTime va_fec_emi;
        /// <summary>
        /// Forma de Pago 1 = Contado, 2 = Credito
        /// </summary>
        public string va_fom_pag;
        /// <summary>
        /// Codigo del Plan de Pagos
        /// </summary>
        public int va_pla_pag;
        /// <summary>
        /// Moneda(B= Bolivianos; D=Dolares)
        /// </summary>
        public string va_mon_eda;
        /// <summary>
        /// Tipo de Cambio
        /// </summary>
        public decimal va_tip_cam;
        /// <summary>
        /// Valor Bruto de la Compra
        /// </summary>
        public decimal va_tot_bru;
        /// <summary>
        /// Valor del Descuento de la Compra
        /// </summary>
        public decimal va_des_cmp;
        /// <summary>
        /// Valor Neto de la Compra
        /// </summary>
        public decimal va_tot_net;
        /// <summary>
        /// Observacion de la Compra
        /// </summary>
        public string va_obs_cmp;
        /// <summary>
        /// Estado
        /// </summary>
        public string va_est_ado;


        //------ Datos Fiscales
        /// <summary>
        /// Nro.de Factura
        /// </summary>
        public int va_nro_fac;
        /// <summary>
        /// NIT del Proveedor
        /// </summary>
        public Int32 va_nit_fac;
        /// <summary>
        /// Razon Social del Proveedor
        /// </summary>
        public string va_raz_fac;
        /// <summary>
        /// Nro.de Autorizacion
        /// </summary>
        public string va_nro_aut ;
        /// <summary>
        /// Codigo de Control
        /// </summary>
        public string va_cod_ctr ;
        /// <summary>
        /// Total Valor Exento
        /// </summary>
        public decimal va_tot_exe;
        /// <summary>
        /// Total Sujeto a Impuestos
        /// </summary>
        public decimal va_tot_suj;
        /// <summary>
        /// Valor de impuesto IVA 13%
        /// </summary>
        public decimal va_tot_imp;
        /// <summary>
        /// Total de la Retencion de IT 3%
        /// </summary>
        public decimal va_rim_itr;
        /// <summary>
        /// Total de la Retencion de IUE para Bienes 5%
        /// </summary>
        public decimal va_riu_bie ;
        /// <summary>
        ///  Total de la Retencion de IUE para Servicios 12.5 %
        /// </summary>
        public decimal va_riu_ser;
        /// <summary>
        ///  Total de la Retencion de IUE para Alquileres 13 %
        /// </summary>
        public decimal va_rie_alq;
        /// <summary>
        ///  Array con 
        /// </summary>
       public List<c_cmp001a> lisItem = new List<c_cmp001a>();

        #endregion

        #region Metodos
            /// <summary>
            /// Registra los datos de la Cabecera del Documento de Compra
            /// </summary>
            private bool fu_reg_cab(c_cnx000 _cnx000)
                {
                    try
                    {
                    
                            StringBuilder vv_str_sql = new StringBuilder();
                            vv_str_sql.AppendLine(" Insert into cmp001( ");
                            vv_str_sql.AppendLine("va_cod_doc,va_nro_tal,va_nro_doc,va_cod_prv,va_fec_cmp,va_cod_ges,va_emp_cod, ");
                            vv_str_sql.AppendLine("va_cod_suc,va_tip_cmp,va_cod_alm,va_fec_emi,va_fom_pag,va_pla_pag,va_mon_eda, ");
                            vv_str_sql.AppendLine("va_tip_cam,va_tot_bru,va_des_cmp,va_tot_net,va_obs_cmp,va_est_ado,va_nro_fac, ");
                            vv_str_sql.AppendLine("va_nit_fac,va_raz_fac,va_nro_aut,va_cod_ctr,va_tot_exe,va_tot_suj,va_tot_imp, ");
                            vv_str_sql.AppendLine("va_rim_itr,va_riu_bie,va_riu_ser,va_rie_alq) ");
                            vv_str_sql.AppendFormat(" values('{0}', ", va_cod_doc );
                            vv_str_sql.AppendFormat("  {0}, ", va_nro_tal);
                            vv_str_sql.AppendFormat("  {0}, ", va_nro_doc );
                            vv_str_sql.AppendFormat("  '{0}', ", va_cod_prv);
                            vv_str_sql.AppendFormat("  '{0}', ", va_fec_cmp.ToShortDateString());
                            vv_str_sql.AppendFormat("  {0}, ", va_cod_ges );
                            vv_str_sql.AppendFormat("  {0}, ", va_emp_cod);
                            vv_str_sql.AppendFormat("  {0}, ", va_cod_suc);
                            vv_str_sql.AppendFormat("  '{0}', ", va_tip_cmp);
                            vv_str_sql.AppendFormat("  {0}, ", va_cod_alm);
                            vv_str_sql.AppendFormat("  '{0}', ", va_fec_emi.ToShortDateString() );
                            vv_str_sql.AppendFormat("  '{0}', ", va_fom_pag);
                            vv_str_sql.AppendFormat("  {0}, ", va_pla_pag);
                            vv_str_sql.AppendFormat("  '{0}', ", va_mon_eda);
                            vv_str_sql.AppendFormat("  {0}, ", va_tip_cam);
                            vv_str_sql.AppendFormat("  {0}, ", va_tot_bru);
                            vv_str_sql.AppendFormat("  {0}, ", va_des_cmp);
                            vv_str_sql.AppendFormat("  {0}, ", va_tot_net);
                            vv_str_sql.AppendFormat("  '{0}', ", va_obs_cmp);
                            vv_str_sql.AppendFormat("  '{0}', ", va_est_ado);
                            vv_str_sql.AppendFormat("  {0}, ", va_nro_fac);
                            vv_str_sql.AppendFormat("  {0}, ", va_nit_fac);
                            vv_str_sql.AppendFormat("  '{0}', ", va_raz_fac);
                            vv_str_sql.AppendFormat("  '{0}', ", va_nro_aut);
                            vv_str_sql.AppendFormat("  '{0}', ", va_cod_ctr);
                            vv_str_sql.AppendFormat("  {0}, ", va_tot_exe);
                            vv_str_sql.AppendFormat("  {0}, ", va_tot_suj);
                            vv_str_sql.AppendFormat("  {0}, ", va_tot_imp);
                            vv_str_sql.AppendFormat("  {0}, ", va_rim_itr);
                            vv_str_sql.AppendFormat("  {0}, ", va_riu_bie);
                            vv_str_sql.AppendFormat("  {0}, ", va_riu_ser);
                            vv_str_sql.AppendFormat("  {0}) ", va_rie_alq);

                            va_cod_cmp = _cnx000.fu_exe_sql_id(vv_str_sql.ToString());

                            if (va_cod_cmp <=0 )
                            {
                                Exception ex = new Exception("Error:cmp001- No se pudo Registrar el Movimiento del Producto: " );
                                throw ex;
                            }
                    
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

            /// <summary>
            /// Registra Documento de Compra
            /// </summary>
            public Boolean fu_reg_cmp()
            {
                c_cnx000 o_cnx000 = new c_cnx000();

                using (TransactionScope oTran = new TransactionScope())
                {
                    try
                    {
                        //Grabamos Cabecera
                        fu_reg_cab(o_cnx000);
                        foreach (c_cmp001a item in lisItem)
                        {
                            item.va_cod_cmp = va_cod_cmp;
                            if (!item.fu_reg_cmp(o_cnx000))
                            {
                                oTran.Dispose();
                                throw new Exception("Error:cmp001- No se pudo Registrar el item: " + item.va_cod_pro);
                            }
                            c_inv100 o_inv100 = new DATOS.c_inv100();
                            o_inv100.va_cod_pro = item.va_cod_pro;
                            o_inv100.va_alm_mov = item.va_cod_alm;
                            o_inv100.va_can_pro = item.va_can_pro;
                            o_inv100.va_cod_suc = va_cod_suc;
                            o_inv100.va_emp_cod = va_emp_cod;
                            o_inv100.va_est_tra = va_est_ado;
                            o_inv100.va_fec_pro = va_fec_cmp;
                            o_inv100.va_fec_tra = va_fec_emi;
                            o_inv100.va_fec_ven = item.va_fec_ven;
                            o_inv100.va_gst_cod = va_cod_ges;
                            o_inv100.va_imp_tot = va_tot_net;
                            o_inv100.va_lot_cod = item.va_lot_cod;
                            o_inv100.va_mod_org = "CMP";
                            o_inv100.va_mon_tra = va_mon_eda;
                            o_inv100.va_nro_tal = va_nro_tal;
                            o_inv100.va_ref_doc = va_nro_fac ;
                            o_inv100.va_tas_cam = va_tip_cam;
                            o_inv100.va_tip_tra = va_tip_cmp;
                            o_inv100.va_tra_glo = "Compra de Productos";
                            o_inv100.va_tra_org = va_nro_doc;
                        
                            switch (va_tip_cmp)
                            {
                                    case "IVA": //IVA
                                    o_inv100.va_tra_fac = "0";
                                        o_inv100.va_cos_uni = item.va_pre_uni  - Math.Round( item.va_pre_uni * 13 / 100,4);
                                
                                        break;
                                    case "EXE": //EXENTA
                                        o_inv100.va_cos_uni = item.va_pre_uni;
                                        break;
                                case "RETBIEN":  //RETENCION BIEN
                                    o_inv100.va_tra_ret = "1";
                                    o_inv100.va_cos_uni = item.va_pre_uni +  Math.Round( item.va_pre_uni / (92/100),4);
                                    break;
                                case "RETSER":   //RETENCION SERVICIOS
                                    o_inv100.va_tra_ret = "1";
                                    o_inv100.va_cos_uni = item.va_pre_uni + Math.Round(item.va_pre_uni / (84.5m / 100), 4);
                                    break;
                                case "IVAXREC":  //IVA POR RECUPERAR
                                    o_inv100.va_cos_uni = Math.Round(item.va_pre_uni * 13 / 100, 4);
                                    break;
                                default:
                                        o_inv100.va_tra_fac = "1";
                                        o_inv100.va_tra_ret = "0";
                                        break;
                            }

                            //Registramos el movimiento en Inventario y Actualizamos Saldos 
                            if (!o_inv100.fu_reg_mov(o_cnx000, c_inv100.TipoTransaccions.Ingreso))
                            {
                                oTran.Dispose();
                                throw new Exception("Error:cmp001- No se pudo Registrar el Movimiento de Inventario del Item: " + item.va_cod_pro);
                            }
                    }
                        oTran.Complete();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        oTran.Dispose();
                        throw ex;
                    }
                }

        }
        #endregion

    }
}
