using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS._4_INV
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase PRODUCTO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_inv002
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
        /// Funcion "Buscar Producto"
        /// </summary>
        /// <param name="val_bus">Valor del busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre ; 3=Descripcion ; 4=Fabricante )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv002  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendLine(" where va_cod_pro like '" + val_bus + "%' "); break;
                    case 2: vv_str_sql.AppendLine(" where va_nom_pro like '" + val_bus + "%' "); break;
                    case 3: vv_str_sql.AppendLine(" where va_des_pro like '" + val_bus + "%' "); break;
                    case 4: vv_str_sql.AppendLine(" where va_fab_ric like '" + val_bus + "%' "); break;                
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
        /// funcion "Registrar Producto"
        /// </summary>
        /// <param name="cod_pro">Codigo del producto </param>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <param name="cod_umd">(inv003-Und. Med)Codigo de la Unidad de Medida</param>
        /// <param name="und_cmp">(inv003-Und. Med)Codigo de la unidad de compra</param>
        /// <param name="und_vta">(inv003-Und. Med)Codigo de la unidad de venta</param>
        /// <param name="cod_mar">Codigo de la Marca del producto</param>
        /// <param name="nom_pro">Nombre del producto</param>
        /// <param name="des_pro">Descripcion del producto</param>
        /// <param name="cod_bar">Codigo de barra del producto</param>
        /// <param name="fab_ric">Fabricante al que pertenece el producto</param>
        /// <param name="eqv_cmp">Cantidad de unidad de medida por unidad de compra</param>
        /// <param name="eqv_vta">Cantidad de unidad de medida por unidad de presentacion</param>
        /// <param name="ban_ser">Bandera identifica si el producto se maneja por ¨serie 0=No  1= si en todas</param>
        /// <param name="ban_vta">Bandera identifica si el producto esta disponible para ventas VENTAS 0=NO ; 1=SI</param>
        /// <param name="ban_cmp">Bandera identifica si el producto esta disponible para ventas COMPRAS 0=NO ; 1=SI</param>
        /// <param name="ban_lot">Bandera identifica si el producto se maneja por LOTE 1=SI ; 2=NO</param>
        /// <returns></returns>
        public void _02(string cod_pro, string cod_fam, string cod_umd,string und_cmp,string und_vta,string cod_mar,string nom_pro,string des_pro,
                             string cod_bar,string fab_ric,string eqv_cmp,string eqv_vta, int ban_ser,int ban_vta,int ban_cmp,int ban_lot)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO inv002 VALUES");

                vv_str_sql.AppendLine(" ('" + cod_pro + "', '" + cod_fam + "', '" + cod_umd + "', '" + und_cmp + "', '" + und_vta + "', '" + cod_mar + "', '" + nom_pro + "', '" + des_pro + "', '" );
                vv_str_sql.AppendLine( cod_bar + "', '" + fab_ric + "', '" + eqv_cmp + "', '" + eqv_vta + "', '" + ban_ser + "', '" + ban_vta + "', '" + ban_cmp + "', '" + ban_lot +  "','H')");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica Producto"
        /// </summary>
        /// <param name="cod_pro">Codigo del producto </param>
        /// <param name="cod_fam">Codigo de la familia de producto</param>
        /// <param name="cod_umd">(inv003-Und. Med)Codigo de la Unidad de Medida</param>
        /// <param name="und_cmp">(inv003-Und. Med)Codigo de la unidad de compra</param>
        /// <param name="und_vta">(inv003-Und. Med)Codigo de la unidad de venta</param>
        /// <param name="cod_mar">Codigo de la Marca del producto</param>
        /// <param name="nom_pro">Nombre del producto</param>
        /// <param name="des_pro">Descripcion del producto</param>
        /// <param name="cod_bar">Codigo de barra del producto</param>
        /// <param name="fab_ric">Fabricante al que pertenece el producto</param>
        /// <param name="eqv_cmp">Cantidad de unidad de medida por unidad de compra</param>
        /// <param name="eqv_vta">Cantidad de unidad de medida por unidad de presentacion</param>
        /// <param name="ban_ser">Bandera identifica si el producto se maneja por ¨serie 0=No  1= si en todas</param>
        /// <param name="ban_vta">Bandera identifica si el producto esta disponible para ventas VENTAS 0=NO ; 1=SI</param>
        /// <param name="ban_cmp">Bandera identifica si el producto esta disponible para ventas COMPRAS 0=NO ; 1=SI</param>
        /// <param name="ban_lot">Bandera identifica si el producto se maneja por LOTE 1=SI ; 2=NO</param>
        /// <returns></returns>
        public void _03(string cod_pro, string cod_fam, string cod_umd, string und_cmp, string und_vta, string cod_mar, string nom_pro, string des_pro,
                             string cod_bar, string fab_ric, string eqv_cmp, string eqv_vta, int ban_ser, int ban_vta, int ban_cmp, int ban_lot)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv002 SET");
                
                vv_str_sql.AppendLine(" va_cod_fam='" + cod_fam + "' , va_cod_umd='" + cod_umd + "' , va_und_cmp='" + und_cmp + "' , va_und_vta='" + und_vta + "' , va_cod_mar='" + cod_mar + "' , va_nom_pro='" + nom_pro + "' , va_des_pro='" + des_pro+"',");
                vv_str_sql.AppendLine(" va_cod_bar='" + cod_bar + "' , va_fab_ric='" + fab_ric + "' , va_eqv_cmp='" + eqv_cmp + "' , va_eqv_vta='" + eqv_vta + "' , va_ban_ser='" + ban_ser + "' , va_ban_vta='" + ban_vta + "' , va_ban_cmp='" + ban_cmp + "' , va_ban_lot='" + ban_lot + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_pro = '" + cod_pro + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita/Deshabilita Producto"
        /// </summary>
        /// <param name="cod_pro">Codigo del Producto</param>
        /// <param name="est_ado">Estado del Producto</param>
        /// <returns></returns>
        public void _04(string cod_pro, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE inv002 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_pro = '" + cod_pro + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Consulta Producto"
        /// </summary>
        /// <param name="cod_pro">Codigo del Producto</param>
        /// <returns></returns>
        public DataTable _05(string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM inv002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_pro = " + "'" + cod_pro + "'");

                return o_cnx000.fu_exe_sql_si(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Elimina Producto"
        /// </summary>
        /// <param name="cod_pro">Codigo del Producto</param>
        /// <returns></returns>
        public void _06(string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv002 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_pro = '" + cod_pro + "'");

                o_cnx000.fu_exe_sql_no(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
