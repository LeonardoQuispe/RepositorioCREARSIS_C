using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DATOS._4_INV
{
    public class c_inv008
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
        /// Buscar 
        /// </summary>
        /// <param name="cod_pro">cod producto</param>
        /// <returns></returns>
        public DataTable _01(string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from inv008  ");

                vv_str_sql.AppendLine("where va_cod_pro = '"+ cod_pro+" '");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Registra Imagen de Producto
        /// </summary>
        /// <param name="cod_pro"></param>
        /// <param name="img_pro"></param>
        /// <returns></returns>
        public void _02(string cod_pro, byte[] img_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO INV008 VALUES  ");
                vv_str_sql.AppendLine("('"+cod_pro+"',"+ "@va_img_pro)");

                SqlCommand cmd = new SqlCommand(vv_str_sql.ToString(), o_cnx000.fu_cnx_cnx());

                cmd.Parameters.Add("@va_img_pro", System.Data.SqlDbType.VarBinary, img_pro.Length).Value = img_pro;
                cmd.ExecuteNonQuery();

                o_cnx000.mt_cer_cnx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Funcion "Elimina Imagen"
        /// </summary>
        /// <param name="cod_pro">Codigo del producto</param>
        /// <returns></returns>
        public DataTable _06(string cod_pro)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE inv008 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_pro = '" + cod_pro + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
