﻿using System;
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
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();

                vv_str_sql.AppendLine(" select * from adm010  ");

                switch (prm_bus)
                {
                    case 1: vv_str_sql.AppendFormat(" where va_cod_per like '{0}%'", val_bus); break;
                    case 2: vv_str_sql.AppendFormat(" where va_raz_soc like '{0}%'", val_bus); break;
                    case 3: vv_str_sql.AppendFormat(" where va_nom_com like '{0}%'", val_bus); break;
                    case 4: vv_str_sql.AppendFormat(" where va_nit_ced like '{0}%'", val_bus); break;
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


                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Registrar "PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo Persona (2 de Grup. Per y 5 de Persona)</param>
        /// <param name="nro_per">Nro. de Persona (5 digitos)</param>
        /// <param name="cod_gru">Cod Grupo Persona</param>
        /// <param name="raz_soc">Razon social de la persona</param>
        /// <param name="nom_com">Nombre comercial de la persona</param>
        /// <param name="nit_ced">Nit/Cedula de la persona</param>
        /// <param name="dir_per">Direccion de la persona</param>
        /// <param name="tel_per">Telefono de la persona</param>
        /// <param name="cel_per">Celular de la persona</param>
        /// <param name="ema_per">Email de la persona</param>
        /// <param name="cod_lpr">Codigo de lista de precio</param>
        /// <param name="cod_ven">Codigo de Vendedor asociado</param>
        /// <param name="lim_cre">Limite de credito para el cliente</param>
        /// <param name="mon_cre">Moneda del limite de credito (B=BOlivianos, U=Dolares americanos)</param>
        /// <param name="con_pac">Condicion de pago del cliente</param>
        /// <param name="con_pap">Condicion de pago del proveedor</param>
        /// <param name="ban_cli">Bandera si identifica persona como cliente</param>
        /// <param name="ban_pro">Bandera si identifica persona como proveedor</param>
        /// <param name="ban_emp">Bandera si identifica persona como empleado</param>
        /// <returns></returns>
        public DataTable _02(string cod_per,string nro_per,string cod_gru,string raz_soc,string nom_com,string nit_ced,string dir_per,
                            string tel_per,string cel_per,string ema_per,string cod_lpr,string cod_ven,string lim_cre,string mon_cre,
                            string con_pac,string con_pap,string ban_cli,string ban_pro,string ban_emp)
        {
            try
            {
                if (lim_cre=="")
                {
                    lim_cre = "0.0";
                }

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm010 VALUES ");
                vv_str_sql.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}',", cod_per, nro_per, cod_gru, raz_soc, nom_com, nit_ced, dir_per);
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}',", tel_per, cel_per,ema_per,cod_lpr,cod_ven,lim_cre,mon_cre);
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','H')", con_pac, con_pap, ban_cli, ban_pro, ban_emp);

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
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public DataTable _05(string cod_per)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_per + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// Obtiene el numero correlativo de la persona a crear segun el tipo de persona
        ///// </summary>
        ///// <param name="cod_tpr">codigo tipo de persona</param>
        ///// <returns></returns>
        //public DataTable _05(int cod_tpr)
        //{
        //    try
        //    {
        //        vv_str_sql = new StringBuilder();
        //        vv_str_sql.AppendLine(" select (( MAX( va_cod_per) %10000) + 1) as va_nro_per from adm010 ");
        //        vv_str_sql.AppendLine(" WHERE  va_cod_tpr = " + cod_tpr + "");

        //        return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
