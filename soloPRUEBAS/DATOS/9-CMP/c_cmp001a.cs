using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATOS._9_CMP
{
    /// <summary>
    /// Clase para los Items del Documento de compra(Detalle)
    /// </summary>
   public class c_cmp001a
    {
        /// <summary>
        /// Codigo del Documento de Compra,este campo me permite relacionar con la tabla cmp001
        /// </summary>
        public Int32 va_cod_cmp;
        /// <summary>
        /// Numero de item del Documento de Compra
        /// </summary>
        public int va_nro_itm ;
        /// <summary>
        /// Codigo del Producto
        /// </summary>
        public string va_cod_pro ;
        /// <summary>
        /// Descripcion del Producto
        /// </summary>
        public string va_nom_pro ;
        /// <summary>
        /// Codigo de la Unidad de Medida
        /// </summary>
        public string va_cod_uni ;
        /// <summary>
        /// Cantidad
        /// </summary>
        public decimal va_can_pro ;
        /// <summary>
        /// Costo Unitario
        /// </summary>
        public decimal va_pre_uni ;
        /// <summary>
        /// Importe Total(Importe Total + Importe de Gastos)
        /// </summary>
        public decimal va_imp_tot;
        /// <summary>
        /// Codigo del Almacen
        /// </summary>
        public int va_cod_alm ;
        /// <summary>
        /// Tipo de Compra IVA = IVA, EXE = EXENTO, RETBIEN = RETENCION BIEN,RETSER=RETENCION SERVICIOS, IVAXREC = IVA POR RECUPERAR
        /// </summary>
        public string va_tip_cmp;
        /// <summary>
        /// Código de Lote
        /// </summary>
        public string va_lot_cod ;
        /// <summary>
        /// Fecha de Vencimiento
        /// </summary>
        public DateTime va_fec_ven ;

         #region Metodos
            /// <summary>
            /// Registra un Item del Documento de Compra
            /// </summary>
            public bool fu_reg_cmp(c_cnx000 _cnx000)
                {
                    try
                    {

                        StringBuilder vv_str_sql = new StringBuilder();
                        vv_str_sql.AppendLine(" Insert into cmp001a( ");
                        vv_str_sql.AppendLine("va_cod_cmp,va_nro_itm,va_cod_pro,va_nom_pro,va_cod_uni,va_can_pro, ");
                        vv_str_sql.AppendLine("va_pre_uni,va_imp_tot,va_cod_alm,va_tip_cmp,va_lot_cod,va_fec_ven) ");
                        vv_str_sql.AppendFormat(" values({0}, ", va_cod_cmp);
                        vv_str_sql.AppendFormat(" {0}, ", va_nro_itm);
                        vv_str_sql.AppendFormat(" '{0}', ", va_cod_pro);
                        vv_str_sql.AppendFormat(" '{0}', ", va_nom_pro);
                        vv_str_sql.AppendFormat(" '{0}', ", va_cod_uni);
                        vv_str_sql.AppendFormat(" {0}, ", va_can_pro);
                        vv_str_sql.AppendFormat(" {0}, ", va_pre_uni);
                        vv_str_sql.AppendFormat(" {0}, ", va_imp_tot);
                        vv_str_sql.AppendFormat(" {0}, ", va_cod_alm);
                        vv_str_sql.AppendFormat(" '{0}', ", va_tip_cmp);
                        vv_str_sql.AppendFormat(" '{0}', ", va_lot_cod);
                        vv_str_sql.AppendFormat(" '{0}') ", va_fec_ven.ToShortDateString());
                

                        if (!_cnx000.fu_exe_sql_no(vv_str_sql.ToString()))
                        {
                            Exception ex = new Exception("Error:cmp001a- No se pudo Registrar el item: " + va_cod_pro);
                            throw ex;
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
