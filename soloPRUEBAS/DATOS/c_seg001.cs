using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace DATOS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase USUARIO
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_seg001
    {
        /// <summary>
        /// objeto de la clase conexion
        /// </summary>
        c_cnx000 o_cnx000 = new c_cnx000();

        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();
        /// <summary>
        /// Funcion "BUSCAR USUARIO"
        /// </summary>
        /// <param name="val_bus">Valor de la busqueda</param>
        /// <param name="prm_bus">Parametro de busqueda (0=codigo ; 1=Nombre)</param>
        /// <param name="est_bus">Estado del Usuario (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )</param>
        /// <returns></returns>
        public DataTable _01(string val_bus, int prm_bus, int est_bus)
        {            
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg001");

                switch (prm_bus)
                {
                    //buscar por codigo
                    case 0: vv_str_sql.AppendLine(" WHERE va_cod_usr like '" + val_bus + "%'"); break;

                    //buscar por nombre
                    case 1: vv_str_sql.AppendLine(" WHERE va_nom_usr like '" + val_bus + "%'"); break;
                }

                switch (est_bus)
                {
                    //buscar por estado HABILITADO
                    case 1: vv_str_sql.AppendLine(" AND va_est_ado = 'H'"); break;

                    //buscar por estado DESHABILITADO
                    case 2: vv_str_sql.AppendLine(" AND va_est_ado = 'N'"); break;
                }                

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Registrar USUARIO"
        /// </summary>
        /// <param name="tip_usr">Codigo del tipo de Usuario</param>
        /// <param name="cod_usr">Codigo del Usuario</param>
        /// <param name="nom_usr">Nombre del Usuario</param>
        /// <param name="tel_fon">Telefono del usuario</param>
        /// <param name="car_usr">Cargo del usuario</param>
        /// <param name="cor_usr">Correo del usuario</param>
        /// <param name="win_max">Ventanas maximas abiertas del usuario</param>
        /// <param name="pss_usr">Contraseña del usuario</param>
        /// <returns></returns>
        public DataTable _02(int tip_usr, string cod_usr, string nom_usr, string tel_fon, string car_usr, string cor_usr, int win_max, string pss_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO seg001 VALUES ");    
                vv_str_sql.AppendLine(" (" + tip_usr + ", '" + cod_usr + "','" + nom_usr + "', '" + tel_fon + "' , ");
                vv_str_sql.AppendLine(" '" + car_usr + "','" + cor_usr + "'," + win_max + ",  PWDENCRYPT('" + pss_usr + "'), 'H' )");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Usuario"
        /// </summary>
        /// <param name="tip_usr">Tpo de Usuario</param>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="nom_usr">Nombre del usuario</param>
        /// <param name="tel_fon">Telefono del usuario</param>
        /// <param name="car_usr">Cargo del usuario</param>
        /// <remarks></remarks>
        public object _03(int tip_usr, string cod_usr, string nom_usr, string tel_fon, string car_usr, string cor_usr, int win_max)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg001 SET ");
                vv_str_sql.AppendLine(" va_nom_usr='" + nom_usr + "' , va_tel_fon= '" + tel_fon + "', ");
                vv_str_sql.AppendLine(" va_car_usr='" + car_usr + "', va_cor_usr='" + cor_usr + "', va_win_max =" + win_max + ", ");
                vv_str_sql.AppendLine(" va_tip_usr = " + tip_usr + "");
                vv_str_sql.AppendLine(" WHERE va_cod_usr = '" + cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica INICIALIZA CONTRASEÑA"
        /// </summary>
        /// <param name="tip_usr">Tpo de Usuario</param>
        /// <param name="cod_usr">Codigo de usuario</param>
        /// <param name="pss_usr">Contraeña del usuario</param>
        /// <remarks></remarks>
        public object _03(int tip_usr, string cod_usr, string pss_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg001 SET ");
                vv_str_sql.AppendLine(" va_pss_usr = PWDENCRYPT('" + pss_usr + "')  ");
                vv_str_sql.AppendLine(" WHERE va_tip_usr = " + tip_usr + " and va_cod_usr = '" + cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <param name="est_ado">Estado del usuario</param>
        /// <returns></returns>
        public DataTable _04(string cod_usr, string est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" UPDATE seg001 SET ");
                vv_str_sql.AppendLine(" va_est_ado='" + est_ado + "' ");
                vv_str_sql.AppendLine(" WHERE  va_cod_usr = '" + cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <returns></returns>
        public DataTable _05(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_usr = '" + cod_usr + "' ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Autentifica USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <param name="pss_usr">Contraseña del usuario</param>
        /// <returns></returns>
        public DataTable _05(string cod_usr, string pss_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM seg001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_usr = '" + cod_usr + "' AND ");
                vv_str_sql.AppendLine(" PWDCOMPARE('" + pss_usr + "', va_pss_usr) = 1 ");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  Funcion "Elimina USUARIO"
        /// </summary>
        /// <param name="cod_usr">Codigo del usuario</param>
        /// <returns></returns>
        public DataTable _06(string cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE seg001 ");
                vv_str_sql.AppendLine(" WHERE  va_cod_usr = '" + cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Procedimiento reporte "Lista de Usuarios"
        /// </summary>
        /// <param name="est_ado">Estado (0=Todos ; 1=Habilitado ; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable _01p1(int est_ado)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("Exec seg001_01p1 ");
                vv_str_sql.AppendLine(Convert.ToString(est_ado));

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////////////ESTILO//////////////////////

        /// <summary>
        ///  Consulta estilo de usuario
        /// </summary>
        /// <param name="va_cod_usr"></param>
        /// <returns></returns>
        public DataTable seg004_01(string va_cod_usr)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("SELECT * FROM seg004 where va_cod_usr = '" + va_cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Registrar Estilo de usuario
        /// </summary>
        /// <param name="va_cod_usr">Codigo de usuario</param>
        /// <param name="va_nro_est">Numero de estilo</param>
        /// <returns></returns>
        public DataTable seg004_02(string va_cod_usr, int va_nro_est)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("INSERT INTO seg004 VALUES('" + va_cod_usr + "' , " + va_nro_est + ")");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza estilo de usuario 
        /// </summary>
        /// <param name="va_cod_usr">>Codigo de usuario</param>
        /// <param name="va_nro_est">Numero de estilo</param>
        /// <returns></returns>
        public DataTable seg004_03(string va_cod_usr, int va_nro_est)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine("UPDATE seg004 SET va_nro_est = " + va_nro_est);
                vv_str_sql.AppendLine(" WHERE va_cod_usr = '" + va_cod_usr + "'");

                return o_cnx000.fu_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
