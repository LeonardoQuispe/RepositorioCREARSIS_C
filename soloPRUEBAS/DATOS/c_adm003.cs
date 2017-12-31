using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase DOCUMENTOS
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm003
    {
        /// <summary>
        /// Objeto de la clase Conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();
        /// <summary>
        /// Cadena de comando sql
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        /// Funcion "Buscar DOCUMENTOS"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de Busqueda (1=codigo ; 2=Nombre )</param>
        /// <param name="est_bus">Estado del DOCUMENTO (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, int est_bus)
        {
            try
            {
                
                vv_str_sql = new StringBuilder();

                vv_str_sql.AppendLine(" EXECUTE adm003_01p1");

                
                switch (est_bus)
                {
                    //buscar por estado HABILITADO
                    case 0: vv_str_sql.AppendLine(" 0,'" + val_bus + "', " + prm_bus + " , " + " 'T' "); break;
                    //buscar por estado HABILITADO
                    case 1: vv_str_sql.AppendLine(" 0,'" + val_bus + "', " + prm_bus + " , " + " 'H' ");break;
                    //buscar por estado DESHABILITADO
                    case 2: vv_str_sql.AppendLine(" 0,'" + val_bus + "', " + prm_bus +" , "+ " 'N' "); break;
                }

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Registrar DOCUMENTO"
        /// </summary>
        /// <param name="cod_mod">Codigo del modulo </param>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <param name="nom_doc">Nombre del Documento</param>
        /// <param name="des_doc">Descripcion del Documento</param>
        /// <returns></returns>
        public DataTable _02(int cod_mod, string cod_doc, string nom_doc, string des_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder(); 
                vv_str_sql.AppendLine(" INSERT INTO adm003 VALUES");
                vv_str_sql.AppendLine(" (" + cod_mod + ", '" + cod_doc + "', '" + nom_doc + "', '" + des_doc + "', 'H')");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica DOCUMENTO"
        /// </summary>
        /// <param name="cod_mod">Codigo del modulo</param>
        /// <param name="cod_doc">Codigo del Documento</param>
        /// <param name="nom_doc">Nombre del Documento</param>
        /// <param name="des_doc">Descripcion de Documento</param>
        /// <returns></returns>
        public DataTable _03(int cod_mod, string cod_doc, string nom_doc, string des_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm003 SET");
                vv_str_sql.AppendLine(" va_nom_doc='" + nom_doc + "' , va_des_doc= '" + des_doc + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_mod = " + cod_mod + " AND va_cod_doc = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita DOCUMENTO"
        /// </summary>
        /// <param name="cod_doc">Codigo del Documento</param>
        /// <param name="est_ado">Estado del Documento</param>
        /// <returns></returns>
        public DataTable _04(string cod_doc, string est_ado)
        {
            try
            {

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm003 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Documento"
        /// </summary>
        /// <param name="cod_doc">Codigo del Documento</param>
        /// <returns></returns>
        public DataTable _05(string cod_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * fROM adm003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina DOCUMENTO"
        /// </summary>
        /// <param name="cod_doc">Codigo del documento</param>
        /// <returns></returns>
        public DataTable _06(string cod_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm003 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_doc = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
