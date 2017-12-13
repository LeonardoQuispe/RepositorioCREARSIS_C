using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Persona
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_adm010
    {
        /// <summary>
        /// Cadena de comando SQL
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        /// Funcion "Buscar PERSONAS"
        /// </summary>
        /// <param name="val_bus">Valor de la busqued</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Raz Soc;3=nombre;4=Ape Pat;5=Ape Mat;6=CI;7=Nit )</param>
        /// <param name="est_bus">Estado del persona (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )(</param>
        /// <param name="cod_tpr">Codigo del tipo de persona para buscar (0=todos)</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus, int cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT adm010.va_cod_per, adm010.va_cod_tpr, adm011.va_nom_tpr,  adm010.va_raz_soc, adm010.va_nom_per, adm010.va_ape_pat, adm010.va_ape_mat,");
                vv_str_sql.AppendLine("        adm010.va_nit_per, adm010.va_nro_cip, adm010.va_tel_per, adm010.va_cel_per, adm010.va_ema_per, ");
                vv_str_sql.AppendLine("        adm010.va_dir_per, adm010.va_ciu_dad, adm010.va_fec_nac, adm010.va_est_civ, adm010.va_est_ado ");
                vv_str_sql.AppendLine(" FROM adm010, adm011, seg022 ");
                vv_str_sql.AppendLine(" WHERE adm010.va_cod_tpr = adm011.va_cod_tpr	AND  ");
                vv_str_sql.AppendLine("       adm011.va_cod_tpr = seg022.va_cod_tpr	AND  ");

                if (prm_bus == 1)//codigo
                {
                    vv_str_sql.AppendLine("   adm010.va_cod_per LIKE '" + val_bus + "%'		    ");
                }
                if (prm_bus == 2)//razon social
                {
                    vv_str_sql.AppendLine("   adm010.va_raz_soc LIKE '" + val_bus + "%'			");
                }
                if (prm_bus == 3)//nombre
                {
                    vv_str_sql.AppendLine("   adm010.va_nom_per LIKE '" + val_bus + "%'		    ");
                }
                if (prm_bus == 4)//apellido paterno
                {
                    vv_str_sql.AppendLine("   adm010.va_ape_pat LIKE '" + val_bus + "%'			");
                }
                if (prm_bus == 5)//apellido materno
                {
                    vv_str_sql.AppendLine("   adm010.va_ape_mat LIKE '" + val_bus + "%'		    ");
                }
                if (prm_bus == 6)//C.I.
                {
                    vv_str_sql.AppendLine("   adm010.va_nro_cip LIKE '" + val_bus + "%'			");
                }
                if (prm_bus == 7)//nit
                {
                    vv_str_sql.AppendLine("   adm010.va_nit_per LIKE '" + val_bus + "%'			");
                }

                if (est_bus != "T")
                {
                    vv_str_sql.AppendLine("   AND  adm010.va_est_ado='" + est_bus + "' ");
                }

                if (cod_tpr != 0)
                {
                    vv_str_sql.AppendLine("   AND  adm010.va_cod_tpr=" + cod_tpr + " ");
                }
                vv_str_sql.AppendLine(" ORDER BY va_cod_per ASC");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Funcion "Registrar persona"
        /// </summary>
        /// <param name="cod_tpr">Codigo tipo persona (10=Cliente ...)</param>
        /// <param name="cod_per">Codigo de la persona (990000)-> [99=codigo de tipo de persona ; 0000=codigo correlativo para la persona]</param>
        /// <param name="raz_soc">Razon Social de la persona</param>
        /// <param name="nom_per">Nombre de la persona</param>
        /// <param name="ape_pat">Apellido paterno de la persona</param>
        /// <param name="ape_mat">Apellido materno de la persona</param>
        /// <param name="nit_per">Nit de la persona</param>
        /// <param name="nro_cip">Nro de cedula de identidad de la persona</param>
        /// <param name="tel_per">Telefono de la persona</param>
        /// <param name="cel_per">Celular de la persona</param>
        /// <param name="ema_per">Email de la persona</param>
        /// <param name="dir_per">Direccion de la persona</param>
        /// <param name="ciu_dad">Ciudad donde vive la persona</param>
        /// <param name="fec_nac">Fecha de nacimiento de la persona</param>
        /// <param name="est_civ">Estado civil de la persona (0=soltero ; 1=casado ; 2=viudo ; 3=divorsiado)</param>
        /// <param name="obs_per">>Observacion o detalle de la persona</param>
        /// <returns></returns>
        public DataTable _02(int cod_tpr, string cod_per, string raz_soc, string nom_per,
        string ape_pat, string ape_mat, string nit_per, string nro_cip,
        string tel_per, string cel_per, string ema_per, string dir_per,
        string ciu_dad, DateTime fec_nac, int est_civ, string obs_per)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm010 VALUES ");
                vv_str_sql.AppendLine(" (" + cod_tpr + ", '" + cod_per + "','" + raz_soc + "', '" + nom_per + "' ,");
                vv_str_sql.AppendLine(" '" + ape_pat + "','" + ape_mat + "', '" + nit_per + "' , '" + nro_cip + "' , ");
                vv_str_sql.AppendLine(" '" + tel_per + "','" + cel_per + "','" + ema_per + "','" + dir_per + "',");
                vv_str_sql.AppendLine(" '" + ciu_dad + "','" + fec_nac + "', " + est_civ + " , 'H','" + obs_per + "' )");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Funcion "Modifica persona"
        /// </summary>
        /// <param name="cod_tpr">Codigo tipo persona (10=Cliente ...)</param>
        /// <param name="cod_per">Codigo de la persona (990000)-> [99=codigo de tipo de persona ; 0000=codigo correlativo para la persona]</param>
        /// <param name="raz_soc">Razon Social de la persona</param>
        /// <param name="nom_per">Nombre de la persona</param>
        /// <param name="ape_pat">Apellido paterno de la persona</param>
        /// <param name="ape_mat">Apellido materno de la persona</param>
        /// <param name="nit_per">Nit de la persona</param>
        /// <param name="nro_cip">Nro de cedula de identidad de la persona</param>
        /// <param name="tel_per">Telefono de la persona</param>
        /// <param name="cel_per">Celular de la persona</param>
        /// <param name="ema_per">Email de la persona</param>
        /// <param name="dir_per">Direccion de la persona</param>
        /// <param name="ciu_dad">Ciudad donde vive la persona</param>
        /// <param name="fec_nac">Fecha de nacimiento de la persona</param>
        /// <param name="est_civ">Estado civil de la persona (0=soltero ; 1=casado ; 2=viudo ; 3=divorsiado)</param>
        /// <param name="obs_per">>Observacion o detalle de la persona</param>
        /// <returns></returns>
        public DataTable _03(int cod_tpr, string cod_per, string raz_soc, string nom_per,
        string ape_pat, string ape_mat, string nit_per, string nro_cip,
        string tel_per, string cel_per, string ema_per, string dir_per,
        string ciu_dad, DateTime fec_nac, int est_civ, string obs_per)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm010 SET ");
                vv_str_sql.AppendLine(" va_raz_soc='" + raz_soc + "' , va_nom_per= '" + nom_per + "',va_ape_pat= '" + ape_pat + "',");
                vv_str_sql.AppendLine(" va_ape_mat='" + ape_mat + "' , va_nit_per= '" + nit_per + "',va_nro_cip= '" + nro_cip + "',");
                vv_str_sql.AppendLine(" va_tel_per='" + tel_per + "' , va_cel_per = '" + cel_per + "',va_ema_per= '" + ema_per + "',");
                vv_str_sql.AppendLine(" va_dir_per='" + dir_per + "' , va_ciu_dad= '" + ciu_dad + "',va_fec_nac= '" + fec_nac + "', ");
                vv_str_sql.AppendLine(" va_est_civ = " + est_civ + " , va_obs_per = '" + obs_per + "'");
                vv_str_sql.AppendLine(" WHERE va_cod_per = '" + cod_per + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <param name="est_ado">Estado del persona</param>
        /// <returns></returns>
        public DataTable _03(string cod_per, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm010 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_per + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta persona"
        /// </summary>
        /// <param name="cod_doc">Codigo del persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene el numero correlativo de la persona a crear segun el tipo de persona
        /// </summary>
        /// <param name="cod_tpr">codigo tipo de persona</param>
        /// <returns></returns>
        public DataTable _05(int cod_tpr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select (( MAX( va_cod_per) %10000) + 1) as va_nro_per from adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_tpr = " + cod_tpr + "");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina persona"
        /// </summary>
        /// <param name="cod_doc">Codigo del persona</param>
        /// <returns></returns>
        public DataTable _06(string cod_doc)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_doc + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
