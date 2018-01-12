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
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Raz Soc;3=nombre Comercial; 4=NIT/CI )</param>
        /// <param name="est_bus">Estado del persona (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )(</param>
        /// <param name="con_bus">Condición de Búsqueda 0=LIKE(%); 1=IGUAL(=)</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();

                vv_str_sql.AppendLine(" select * from adm010  ");

                if (true)
                {

                }
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
                            string tel_per,string cel_per,string ema_per,string cod_lpr,string cod_ven,decimal lim_cre,string mon_cre,
                            string con_pac,string con_pap,string ban_cli,string ban_pro,string ban_emp)
        {
            try
            {         

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO adm010 VALUES ");
                vv_str_sql.AppendFormat("('{0}','{1}','{2}','{3}','{4}',", cod_per, nro_per, cod_gru, raz_soc, nom_com);
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','{3}','{4}',", nit_ced, dir_per, tel_per, cel_per, ema_per);

                //Valida Bandera cliente y Manda NULO si es 0
                if (ban_cli=="1")
                {
                    vv_str_sql.AppendFormat("'{0}','{1}','{2}','{3}','{4}',", cod_lpr, cod_ven, lim_cre, mon_cre, con_pac);
                }
                else
                {
                    vv_str_sql.AppendFormat("NULL,NULL,NULL,NULL,NULL,");
                }

                //Valida Bandera Proovedor y Manda NULO si es 0
                if (ban_pro == "1")
                {
                    vv_str_sql.AppendFormat("'{0}',",con_pap);
                }
                else
                {
                    vv_str_sql.AppendFormat("NULL,");
                }
                
              
                vv_str_sql.AppendFormat("'{0}','{1}','{2}','H')", ban_cli, ban_pro, ban_emp);

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// actualiza "PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo Persona (2 de Grup. Per y 5 de Persona)</param>        
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
        public DataTable _03(string cod_per, string raz_soc, string nom_com, string nit_ced, string dir_per,
                            string tel_per, string cel_per, string ema_per, string cod_lpr, string cod_ven, decimal lim_cre, string mon_cre,
                            string con_pac, string con_pap, string ban_cli, string ban_pro, string ban_emp)
        {
            try
            {
                
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE adm010 SET ");
                vv_str_sql.AppendFormat("va_raz_soc='{0}',va_nom_com='{1}',va_nit_ced='{2}',", raz_soc, nom_com, nit_ced);
                vv_str_sql.AppendFormat("va_dir_per='{0}',va_tel_per='{1}',va_cel_per='{2}',va_ema_per='{3}',", dir_per, tel_per, cel_per, ema_per);

                //Valida Bandera cliente y Manda NULO si es 0
                if (ban_cli == "1")
                {
                    vv_str_sql.AppendFormat("va_cod_lpr='{0}',va_cod_ven='{1}',va_lim_cre='{2}',va_mon_cre='{3}',va_con_pac='{4}',", cod_lpr, cod_ven, lim_cre, mon_cre, con_pac);
                }
                else
                {
                    vv_str_sql.AppendFormat("va_cod_lpr=NULL,va_cod_ven=NULL,va_lim_cre=NULL,va_mon_cre=NULL,va_con_pac=NULL,");
                }

                //Valida Bandera Proovedor y Manda NULO si es 0
                if (ban_pro == "1")
                {
                    vv_str_sql.AppendFormat("va_con_pap='{0}',", con_pap);
                }
                else
                {
                    vv_str_sql.AppendFormat("va_con_pap=NULL,");
                }


                vv_str_sql.AppendFormat("va_ban_cli='{0}',va_ban_pro='{1}',va_ban_emp='{2}' ", ban_cli, ban_pro, ban_emp);
                vv_str_sql.AppendFormat("  WHERE va_cod_per='{0}'", cod_per);

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
        public DataTable _04(string cod_per, string est_ado)
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

        /// <summary>
        /// Funcion "Consulta persona por NID/CI"
        /// </summary>
        /// <param name="nit_ci">NIT/CI de persona</param>
        /// <returns></returns>
        public DataTable _05a(string nit_ci)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_nit_ced = '" + nit_ci + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion sugerir nro de Persona según el Codigo de grupo de Persona
        /// </summary>
        /// <param name="cod_gru">codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _05b(int cod_gru)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT MAX(va_nro_per) FROM adm010   ");
                vv_str_sql.AppendLine(" WHERE va_cod_gru ='" + cod_gru + "' ");

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
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public DataTable _06(string cod_per)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE adm010 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_per = '" + cod_per + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
