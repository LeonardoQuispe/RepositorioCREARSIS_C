using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using DATOS;
using System.Data;
using System.Windows.Forms;


namespace CREARSIS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// MODULO GENERICO DE FUNCIONES GLOBALES REUTILIZABLES
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary> 
    public class _01_mg_glo_bal
    {
        //dynamic tmp_frm_nvo;
        //dynamic tmp_frm_pad;
        //dynamic tmp_frm_act;
        dynamic tmp_frm_aux;
        //dynamic tmp_win_act;
        //dynamic tmp_win_pad;

        #region Metodos/Funciones de Autenticación

        c_cnx000 o_cnx000 = new c_cnx000(); //** instancia clase conexión
        c_seg001 o_seg001 = new c_seg001(); //** instancia clase usuario
        c_seg049 o_seg049 = new c_seg049(); //** instancia clase licencia
        c_adm001 o_adm001 = new c_adm001(); //** instancia clase empresa

        DataTable tabla = new DataTable();  //** tabla contenedora de datos

        /// <summary>
        /// Estructura que contiene datos generales del usuario la bd y la app
        /// </summary>
        public struct st_usr_log
        {
            public string vs_cod_usr;
            public string vs_nom_usr;
            public string vs_bdo_usr;
            public string vs_nom_emp;
            public string vs_ide_gru;
            public string vs_nom_gru;
            public DateTime vs_fec_cad;

            public string vs_msg_err;
        }

        public static st_usr_log vc_usr_log;

        string va_ser_ver;
        string va_bdo_usr;

        /// <summary>
        /// FUNCION GLOBAL: Obtiene la fecha actual del servidor///
        /// </summary>
        /// <returns></returns>
        public DateTime fg_fec_act()
        {
            string StrSql = " select CURRENT_TIMESTAMP";
            DateTime fe_cha = Convert.ToDateTime(o_cnx000.fu_exe_sql(StrSql).Rows[0][0].ToString());
            return fe_cha;
        }

        /// <summary>
        /// Funcion que conecta el usuario con la base de datos
        /// </summary>
        /// <param name="ar_usr_usr">Usuario</param>
        /// <param name="ar_pss_usr">Contraseña</param>
        /// <param name="ar_ins_bdo">Instancia</param>
        /// <param name="ar_val_lic">True=logueo para dar licencia, false=si verifica licencia</param>
        /// <returns></returns>
        public st_usr_log fg_cnx_usr(string ar_usr_usr, string ar_pss_usr, string ar_ins_bdo, bool ar_val_lic)
        {
            try
            {
                string[] temp;

                temp = ar_ins_bdo.Split(':');

                va_ser_ver = temp[0].Trim(); //obtiene el nombre del servidor
                va_bdo_usr = temp[1].Trim(); //obtiene la base de datos a conectar


                //apertura la conexion
                o_cnx000.va_nom_srv = va_ser_ver;
                o_cnx000.va_nom_bdo = va_bdo_usr;
                //abre conexion
                o_cnx000.fu_cnx_ini();

                //Obtiene la cadena de conexion valida y la guarda
                Program.gl_usr_usr = ar_usr_usr.ToString();

                //obtiene el nombre de la base de dato y la guarda para toda la aplicacion
                Program.gl_bdo_usr = va_bdo_usr;

                //OBTIENE DATOS DE LA EMPRESA
                //--obtiene el nombre de la empresa
                tabla = o_adm001._01();
                if (tabla.Rows.Count != 0)
                {
                    Program.gl_nom_emp = (tabla.Rows[0]["va_raz_soc"].ToString());
                    string a = Program.gl_nom_emp;
                    vc_usr_log.vs_nom_emp = Program.gl_nom_emp;
                }

                //verifica si el usuario y contraseña son corectos 
                tabla = o_seg001._05(ar_usr_usr, ar_pss_usr);
                if (tabla.Rows.Count == 0)
                {
                    o_cnx000.mt_cer_cnx();
                    vc_usr_log.vs_msg_err = "Error de inicio de sesion para el usuario: " + ar_usr_usr;

                    return vc_usr_log;
                }

                vc_usr_log.vs_cod_usr = ar_usr_usr;
                vc_usr_log.vs_nom_usr = tabla.Rows[0]["va_nom_usr"].ToString();
                vc_usr_log.vs_bdo_usr = va_bdo_usr;
                vc_usr_log.vs_ide_gru = tabla.Rows[0]["va_tip_usr"].ToString();

                ///-switch no terminado--------
                switch (vc_usr_log.vs_ide_gru)
                {
                    case "1": vc_usr_log.vs_nom_gru = "Administrador"; break;
                    case "2": vc_usr_log.vs_nom_gru = "Supervisor"; break;
                    case "3": vc_usr_log.vs_nom_gru = "Normal"; break;
                }

                vc_usr_log.vs_msg_err = "";

                //obtiene el nombre del usuario y la guarda para toda la aplicacion
                Program.gl_nom_usr = vc_usr_log.vs_nom_usr;

                //obtiene el ide del grupo de usuario y la guarda para toda la aplicacion
                Program.gl_ide_gru = vc_usr_log.vs_ide_gru;

                if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    o_cnx000.mt_cer_cnx();
                    vc_usr_log.vs_msg_err = "El usuaio se encuentra Deshabilitado";
                    return vc_usr_log;
                }

                //consulta licencia
                tabla = o_seg049._01();
                if (tabla.Rows.Count == 0)
                {
                    o_cnx000.mt_cer_cnx();
                    vc_usr_log.vs_msg_err = "Error el objeto ads900 no se encuentra registrado en la base de datos";
                    return vc_usr_log;
                }

                //Si se loguea para dar licencia
                if (ar_val_lic == true)
                {
                    return vc_usr_log;
                }

                DateTime vv_fec_cad;
                vv_fec_cad = fg_dcr_lic(tabla.Rows[0]["va_fec_fin"].ToString());

                //guarda la fecha de caducidad en el vector
                vc_usr_log.vs_fec_cad = vv_fec_cad;

                //Ejecuta Método para obtener fecha Actual del Sistema                
                TimeSpan ts = vv_fec_cad - fg_fec_act();

                if (ts.Days < 0)
                {
                    vc_usr_log.vs_msg_err = ("La licencia del sistema ah expirado, comuniquese con su Ing. Sistemas ¡¡");
                    return vc_usr_log;
                }

                return vc_usr_log;

            }
            catch (Exception ex)
            {
                o_cnx000.mt_cer_cnx();
                vc_usr_log.vs_msg_err = "Error: " + ex.Message;

            }
            return vc_usr_log;

        }

        #endregion

        #region -> funciones de licenciamiento




        /// <summary>
        /// Genera Licencia para grabar segun la fecha y la clave
        /// </summary>
        /// <param name="ar_fec_lic"></param>
        /// <param name="ar_cla_vee"></param>
        /// <returns></returns>
        public string fg_gen_lic(DateTime ar_fec_lic, string ar_cla_vee)
        {

            string dia, mes, año;


            dia = ar_fec_lic.Day.ToString();
            mes = ar_fec_lic.Month.ToString();
            año = ar_fec_lic.Year.ToString();

            if (int.Parse(dia) < 10)
            { dia = "0" + dia; }

            if (int.Parse(mes) < 10)
            { mes = "0" + mes; }

            //convierte el año en hexadecimal
            año = String.Format("{0:X}", int.Parse(año));

            string vv_dat_fec;
            string[] vv_tmp_cla;

            vv_tmp_cla = ar_cla_vee.Split('-');
            //primera parte de la clave + mes + 2parte_clave + dia + 3parte_clave + año en hexadecimal
            vv_dat_fec = vv_tmp_cla[0] + '-' + mes + '-' + vv_tmp_cla[1] + '-' + dia + '-' + vv_tmp_cla[2] + '-' + año;

            return vv_dat_fec;
        }


        /// <summary>
        /// Desencripta licencia generada y la devuelve en Fecha
        /// </summary>
        /// <param name="ar_lic_enc">Licencia encriptada</param>
        /// <returns></returns>
        public DateTime fg_dcr_lic(string ar_lic_enc)
        {
            string vv_fec_cad;
            string[] vv_tmp_lic;

            string dia, mes, año;
            vv_tmp_lic = ar_lic_enc.Split('-');

            //b0-08-i3-31-11-7E0
            dia = vv_tmp_lic[3];
            mes = vv_tmp_lic[1];
            año = vv_tmp_lic[5];

            //el año hexadecimal se convierte en numero
            año = Convert.ToString(Convert.ToInt64(año, 16));///EsTa bIEn??

            vv_fec_cad = dia + "/" + mes + "/" + año;
            return Convert.ToDateTime(vv_fec_cad);
        }
        string clave;
        /// <summary>
        /// funcion que determina (obtiene) la clave para dar licencia
        /// </summary>
        /// <returns></returns>
        public string fg_obt_cla()
        {
            DateTime fec_srv;

            int vv_nro_dia; // numero de dia de la semana
            int vv_nro_mes; //nro del mes

            string vv_let_dia; //letra correspondiente al dia
            string vv_let_mes; //letra correspondiente al mes

            int vv_tmp_dia; //temporal del dia
            int vv_tmp_mes; //temporal del mes

            string[] vv_vec_dia = { "g", "a", "b", "c", "d", "e", "f" }; //dia ( 1=a ; 2=b ; 3=c ... ; 8=a ; 9=b ; 10=c ... 15=a ...; 28=a ...
            string[] vv_vec_mes = { "m", "h", "i", "j", "k", "l" }; //meses (enero=h ; febrero=i ; marzo=j ; abril=k ...)

            //'obtiene fecha del servidor//-------------MODIFY

            fec_srv = fg_fec_act();
            //fec_srv = "14/08/2016"

            //'obtiene nro de dia de la fecha
            vv_nro_dia = fec_srv.Day;

            //obtiene nro de mes de la fecha
            vv_nro_mes = fec_srv.Month;

            //obtiene letra del dia segun fecha
            vv_tmp_dia = vv_nro_dia / 7;
            vv_tmp_dia = 7 * vv_tmp_dia;
            vv_tmp_dia = vv_nro_dia - vv_tmp_dia;

            vv_let_dia = vv_vec_dia[vv_tmp_dia];
            //obtiene letra del mes segun fecha
            vv_tmp_mes = vv_nro_mes / 6;
            vv_tmp_mes = 6 * vv_tmp_mes;
            vv_tmp_mes = vv_nro_mes - vv_tmp_mes;

            vv_let_mes = vv_vec_mes[vv_tmp_mes];

            int a; //primer digito del dia
            int b; //segundo digito del dia

            int c; //primer digito del mes
            int d; //segundo digito del mes

            if (vv_nro_dia < 10)
            {
                a = 0;
                b = vv_nro_dia;
            }
            else
            {
                string pate = Convert.ToString(vv_nro_dia);
                a = Convert.ToInt32(pate.Substring(0, 1));
                b = Convert.ToInt32(pate.Substring(1, 1));
            }

            if (vv_nro_mes < 10)
            {
                c = 0;
                d = vv_nro_mes;
            }
            else
            {
                string pate = Convert.ToString(vv_nro_mes);
                c = Convert.ToInt32(pate.Substring(0, 1));
                d = Convert.ToInt32(pate.Substring(1, 1));
            }

            int suma_dia;
            int suma_mes;
            string suma_total;

            suma_dia = a + b;

            suma_mes = c + d;

            suma_total = Convert.ToString(suma_dia + suma_mes);

            if (Convert.ToInt32(suma_total) < 10)
            {
                suma_total = "0" + suma_total;
            }


            clave = vv_let_dia + "" + b + "-" + vv_let_mes + "" + a + "-" + suma_total;

            return clave;
        }
        #endregion

        #region -> Funciones de abrir formularios


        /// <summary>
        /// Abre formulario (desde menu del formulario buscar)
        /// </summary>
        /// <param name="ar_frm_nvo">Formulario nuevo a abrir</param>
        /// <param name="ar_frm_pad">Formulario padre de donde es llamado el nuevo formulario a crear</param>
        /// <param name="ar_tip_nvl">Nivel en el que se abrira el nuevo formulario (1=abierto desde formulario MDI ; 2=Abierto desde otro formulario 'Buscar'</param>
        public void mg_ads000_01(dynamic ar_frm_nvo, dynamic ar_frm_pad, int ar_tip_nvl)
        {
            try
            {                

                if (ar_tip_nvl == 1)
                {
                    if (ar_frm_pad.IsMdiContainer == true)
                    {
                        ar_frm_nvo.MdiParent = ar_frm_pad;
                        //Deshabilita la caja de botones Aceptar/Cancelar
                        ar_frm_nvo.gb_ctr_frm.Enabled = false;

                    }
                    else
                    {
                        ar_frm_nvo.MdiParent = ar_frm_pad.MdiParent;
                        //Habilita la caja de botones Aceptar/Cancelar
                        ar_frm_nvo.gb_ctr_frm.Enabled = true;
                    }

                    ar_frm_pad.mn_pri_nci.Visible = false;
                    ar_frm_pad.MenuStrip1.Visible = true;

                    // pasa el padre quien llamo a la ventana
                    ar_frm_nvo.vg_frm_pad = ar_frm_pad;

                    // Abre y activa formulario
                    ar_frm_nvo.Show();
                    ar_frm_nvo.Activate();


                    // Obtiene el usuario logueado
                    string cod_usr = Program.gl_usr_usr;
                    ar_frm_pad.MenuStrip1 = fg_ver_mnu(cod_usr, ar_frm_nvo.Name, ar_frm_pad.MenuStrip1);
                }

                if (ar_tip_nvl == 2)
                {
                    //deshabilita formulario padre
                    ar_frm_pad.Enabled = false;
                    //Cierra las ventanas hijas del formulario padre
                    foreach (dynamic va_frm_aux in ar_frm_pad.MdiParent.MdiChildren)
                    {
                        if (va_frm_aux.vg_frm_pad.Name == ar_frm_pad.Name)
                        {
                            va_frm_aux.Enabled = false;
                        }

                    }

                    ar_frm_nvo.MdiParent = ar_frm_pad.MdiParent;
                    ar_frm_nvo.vg_frm_pad = ar_frm_pad;
                    ar_frm_nvo.Show();
                    ar_frm_nvo.Activate();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Abre formulario hijo
        /// </summary>
        /// <param name="ar_frm_nvo">Formulario nuevo a abrir</param>
        /// <param name="ar_frm_pad">Formulario padre</param>
        public void mg_ads000_02(dynamic ar_frm_nvo, dynamic ar_frm_pad)
        {            
            Form v_frm_pad = new Form();
            bool ban_frm = false;

            v_frm_pad = ar_frm_pad.MdiParent;

            foreach (dynamic va_frm_aux in v_frm_pad.MdiChildren)
            {
                if (va_frm_aux.Name == ar_frm_nvo.Name)
                {
                    ban_frm = true;
                }
            }

            //si el formulario aun no esta abierto
            if (ban_frm == false)
            {
                ar_frm_nvo.vg_frm_pad = ar_frm_pad;
                ar_frm_nvo.MdiParent = v_frm_pad;
                ar_frm_nvo.Show();
                ar_frm_nvo.Activate();
            }
            else
            {
                ar_frm_nvo.Activate();
            }
        }
        /// <summary>
        /// -> Abre formulario hijo con parametro
        /// </summary>
        /// <param name="ar_frm_nvo">Formulario nuevo a abrir</param>
        /// <param name="ar_frm_pad">Formulario padre</param>
        public void mg_ads000_02(dynamic ar_frm_nvo, Form ar_frm_pad, DataTable ar_str_ucc)
        {

            dynamic v_frm_pad;
            bool ban_frm = false;

            v_frm_pad = ar_frm_pad.MdiParent;

            foreach (dynamic va_frm_aux in v_frm_pad.MdiChildren)
            {
                if (va_frm_aux.Name == ar_frm_nvo.Name)
                {
                    ban_frm = true;
                }
            }

            //si el formulario aun no esta abierto
            if (ban_frm == false)
            {
                ar_frm_nvo.vg_frm_pad = ar_frm_pad;
                ar_frm_nvo.vg_str_ucc = ar_str_ucc;
                ar_frm_nvo.MdiParent = v_frm_pad;
                ar_frm_nvo.Show();
                ar_frm_nvo.Activate();

                // Obtiene el usuario logueado               

                string cod_usr = Program.gl_usr_usr;
                v_frm_pad.MenuStrip1 = fg_ver_mnu(cod_usr, ar_frm_nvo.Name, v_frm_pad.MenuStrip1);
            }
            else
            {
                ar_frm_nvo.Activate();
            }

        }

        /// <summary>
        /// -> Abre formulario hijo de tipo MODAL
        /// </summary>
        /// <param name="ar_frm_nvo">Formulario nuevo a abrir</param>
        /// <param name="ar_frm_pad">Formulario padre</param>
        public void mg_ads000_03(dynamic ar_frm_nvo, Form ar_frm_pad)
        {
            ar_frm_nvo.vg_frm_pad = ar_frm_pad;


            ar_frm_nvo.ShowDialog();
            ar_frm_nvo.Activate();
        }
        /// <summary>
        /// -> Abre formulario hijo de tipo MODAL con parametro
        /// </summary>
        /// <param name="ar_frm_nvo">Formulario nuevo a abrir</param>
        /// <param name="ar_frm_pad">Formulario padre</param>
        public void mg_ads000_03(dynamic ar_frm_nvo, Form ar_frm_pad, DataTable ar_str_ucc)
        {
            //la ventana ya se encuentra abierta en el formulario padre ?

            Form v_frm_pad = new Form();
            bool ban_frm = false;    /*??? para QUE ??? no se usa*/

            v_frm_pad = ar_frm_pad.MdiParent;

            ar_frm_nvo.vg_frm_pad = ar_frm_pad;
            ar_frm_nvo.vg_str_ucc = ar_str_ucc;
            ar_frm_nvo.ShowDialog();
            ar_frm_nvo.Activate();
        }

        /// <summary>
        /// Metodo Global CERRAR formulario actual
        /// </summary>
        /// <param name="ar_frm_act">Formulario actual a cerrar</param>
        /// <param name="ar_tip_nvl">Nivel del formulario (1=1er Nivel abierto desde MDI, ; 2=2do nivel abierto desde otro frm menu)</param>
        public void mg_ads000_04(dynamic ar_frm_act, int ar_tip_nvl)
        {
            if (ar_tip_nvl == 1)
            {
                //Cierra las ventanas hijas del formulario padre
                foreach (Form va_frm_aux in ar_frm_act.MdiParent.MdiChildren)
                {
                    tmp_frm_aux = va_frm_aux;
                    if (ar_frm_act.vg_frm_pad.Name == ar_frm_act.Name)
                    {
                        va_frm_aux.Dispose();
                    }
                }

                ar_frm_act.vg_frm_pad.mn_pri_nci.Visible = true;
                ar_frm_act.vg_frm_pad.MenuStrip1.Visible = false;

                fg_mue_nap(ar_frm_act.vg_frm_pad);
                ar_frm_act.Dispose();

            }

            if (ar_tip_nvl == 2)
            {
                //Cierra las ventanas hijas del formulario padre
                foreach (Form va_frm_aux in ar_frm_act.MdiParent.MdiChildren)
                {
                    if (tmp_frm_aux.vg_frm_pad.Name == ar_frm_act.vg_frm_pad.Name)
                    {
                        va_frm_aux.Enabled = true;
                    }
                }

                fg_mue_nap(ar_frm_act.vg_frm_pad);
                ar_frm_act.Dispose();

            }
        }

        /// <summary>
        /// -> Muestra nombre de la aplicacion en la barra de tareas
        /// </summary>
        /// <remarks></remarks>

        public void fg_mue_nap(dynamic ar_win_act)
        {
            if (ar_win_act.IsMdiContainer == true)
            {
                ar_win_act.ss_nom_vna.Text = ar_win_act.Name;
                return;
            }

            if (ar_win_act.IsMdiChild == true)
            {
                ar_win_act.MdiParent.ss_nom_vna.Text = ar_win_act.Name;
            }
            else
            {
                if (ar_win_act.vg_frm_pad.IsMdiContainer == true)
                {
                    //asigna valor a la etiqueta de nombre de la aplicacion
                    ar_win_act.vg_frm_pad.ss_nom_vna.Text = ar_win_act.Name;
                }
                else
                {
                    if (ar_win_act.vg_frm_pad.MdiParent != null)
                    {
                        //asigna valor a la etiqueta nombre de la aplicacion
                        ar_win_act.vg_frm_pad.MdiParent.ss_nom_vna.Text = ar_win_act.Name;
                    }
                    else
                    {
                        //asigna valor a la etiqueta de nombre de la aplicacion
                        ar_win_act.vg_frm_pad.vg_frm_pad.ss_nom_vna.Text = ar_win_act.Name;
                    }
                }
            }

        }
        /// <summary>
        /// -> Oculta nombre de la aplicacion en la barra de tareas
        /// </summary>
        /// <remarks></remarks>

        public void fg_ocu_nap(dynamic ar_win_pad)
        {
            if (ar_win_pad.IsMdiChild == true)
            {
                //Oculta las etiquetas
                ar_win_pad.MdiParent.ss_etk_vna.visible = false;
                ar_win_pad.MdiParent.ss_nom_vna.visible = false;
            }
            else
            {
                if (ar_win_pad.padre.IsMdiContainer == true)
                {
                    ar_win_pad.padre.ss_etk_vna.visible = false;
                    ar_win_pad.padre.ss_nom_vna.visible = false;
                }
                else
                {
                    ar_win_pad.padre.MdiParent.ss_etk_vna.visible = false;
                    ar_win_pad.padre.MdiParent.ss_nom_vna.visible = false;
                }
            }

        }

        #endregion

        #region -> VERIFICA OPCIONES RESTRINGIDAS DEL MENU PARA EL USUARIO


        private string glo_ide_usr;

        private string glo_ide_ven;
        DataTable tab_usm = new DataTable();
        c_seg020 ob_usr_mnu = new c_seg020();

        /// <summary>
        ///  <example>
        ///   FUNCION GLOBAL: verifica opciones restringidas del menu en la aplicacion para el usuario
        ///  </example>
        /// </summary>
        /// <param name="ide_usr">Codigo del usuario a personalizar el menú</param>
        /// <param name="ide_ven">Ide de la ventana de la cual se personalizara el menú</param>
        /// <param name="menu">Requiere pasar el objeto menu strip</param>
        /// <returns></returns>
        public MenuStrip fg_ver_mnu(string ide_usr, string ide_ven, MenuStrip menu)
        {
            glo_ide_usr = ide_usr;
            glo_ide_ven = ide_ven;

            //verifica restriccines del menu para el usuario

            foreach (dynamic opcion_menu in menu.Items)
            {

                tab_usm = ob_usr_mnu._05(glo_ide_usr, glo_ide_ven, opcion_menu.Name);

                if (glo_ide_usr == Program.gl_usr_usr)
                {
                    if (tab_usm.Rows.Count != 0)
                    {
                        opcion_menu.Enabled = false;
                    }
                    else
                    {
                        opcion_menu.Enabled = true;
                    }

                    //verifica en las opciones Hijas
                    fu_bus_hi1(opcion_menu);
                }
            }

            return menu;

        }


        //barre el menu al 2do nivel

        private void fu_bus_hi1(ToolStripMenuItem itm_hi1)
        {

            foreach (ToolStripMenuItem hijo1 in itm_hi1.DropDownItems)
            {
                //verifica que la opcion no este restringida
                tab_usm = ob_usr_mnu._05(glo_ide_usr, glo_ide_ven, hijo1.Name);

                if (glo_ide_usr == Program.gl_usr_usr)
                {
                    //si existe = permiso restringido
                    if (tab_usm.Rows.Count != 0)
                    {
                        hijo1.Enabled = false;
                    }
                    else
                    {
                        //si no existe = Tiene permiso
                        hijo1.Enabled = true;
                    }

                    if (hijo1.DropDownItems.Count > 0)
                    {
                        fu_bus_hi2(itm_hi1, hijo1);
                    }
                }
            }
        }


        //barre el menu al 3do nivel
        private void fu_bus_hi2(ToolStripMenuItem padre, ToolStripMenuItem itm_hi2)
        {

            foreach (ToolStripMenuItem hijo2 in itm_hi2.DropDownItems)
            {
                //verifica que la opcion no este restringida
                tab_usm = ob_usr_mnu._05(glo_ide_usr, glo_ide_ven, hijo2.Name);

                if (glo_ide_usr == Program.gl_usr_usr)
                {
                    //si existe = permiso restringido
                    if (tab_usm.Rows.Count != 0)
                    {
                        hijo2.Enabled = false;
                    }
                    else
                    {
                        //si no existe = Tiene permiso
                        hijo2.Enabled = true;
                    }
                }

            }
        }
        /// <summary>
        /// Abre Personalizacion del menu actual para el usuario
        /// </summary>
        /// <param name="ide_usr">Usuario aquien se le personalizara el menú</param>
        /// <remarks></remarks>
        public void fg_per_mnu(string ide_usr, dynamic frm_hja)
        {
            seg020_01 v_mnu_usr = new seg020_01();
            v_mnu_usr.vg_frm_pad = frm_hja;

            //Si el formulario es MDI
            if (frm_hja.IsMdiContainer == true)
            {
                v_mnu_usr.obtiene_menu(ide_usr, frm_hja.Name, frm_hja.mn_pri_nci);
            }
            else
            {
                dynamic padre = frm_hja.MdiParent;
                

                v_mnu_usr.obtiene_menu(ide_usr, frm_hja.Name, frm_hja.MdiParent.MenuStrip1);
            }
            v_mnu_usr.ShowDialog();
        }
        #endregion

        #region -> CONVERTIR DE IMAGEN A BYTE Y VICEVERSA
        /// <summary>
        /// Convierte una imagen en byte
        /// </summary>
        /// <param name="imageIn">Imagen a converti</param>
        /// <returns></returns>
        public byte[] fg_img_byt(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        /// <summary>
        /// Recupera Array de byte de una imagen y la convierte en imagen
        /// </summary>
        /// <param name="byteArrayIn">Array de byte a convertir en image</param>
        /// <returns></returns>
        public Image fg_byt_img(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion

        #region -> Funciones NOTIFICACIONES

        //Vector que aglomera las notificaciones activadas
        static cnx000_20[] vec_not = new cnx000_20[11];

        //Nro de la notificacion activada
        public static int nro_not = 0;

        //posision de la notificacion cerrada
        static int pos_cer = 0;
        /// <summary>
        /// Muestra una notificación en la parte superior izquierda de la pantalla
        /// </summary>
        /// <param name="tit_ulo">Titulo de la notificación</param>
        /// <param name="txt_msg">>Texto del mensaje de la notificación</param>
        public static void mg_not_ify(string tit_ulo, string txt_msg)
        {
            cnx000_20 vv_not_ify = new cnx000_20();
            nro_not = Program.gl_nro_not;

            //EN VB ESTA COMO gl_pos_cer------------------------------------------------------------------
            //'inicializa posicion de notificacion cerrada'NO HAY EN EL APPSTEING ES WINCERRADA
            Program.gl_win_cer = 0;

            //incrementa el contador de Notificaciones abiertas
            Program.gl_nro_not = nro_not + 1;
            nro_not = Program.gl_nro_not;

            vv_not_ify.nro_not = nro_not;
            vec_not[nro_not] = vv_not_ify;

            vv_not_ify.lb_tit_ulo.Text = tit_ulo;
            vv_not_ify.tb_tex_msg.Text = txt_msg;

            vv_not_ify.Show();
        }

        public static void mg_cer_not()
        {
            nro_not = Program.gl_nro_not;
            pos_cer = Program.gl_win_cer;

            //para cerrar formulario
            for (int i = 1; (i <= nro_not); i++)
            {
                if (i > pos_cer)
                {
                    vec_not[i - 1] = vec_not[i];
                    //Actualiza el Nro de orden de la notificacion
                    vec_not[i].nro_not = i - 1;
                    //'Activa timer de reorganizacion de notificaciones
                    vec_not[i].tm_org_pos.Enabled = true;
                }
            }

            vec_not[nro_not] = null;

            // Disminuye el numero de notificaciones abiertas
            nro_not = nro_not - 1;
            Program.gl_nro_not = nro_not;
        }
        #endregion


        #region METODOS NUEVO 3.0

        /// <summary>
        /// Substring de Basic con base 0
        /// </summary>
        /// <param name="va_lor"></param>
        /// <param name="indice"></param>
        /// <param name="cuantos"></param>
        /// <returns></returns>
        public string sub_string(string va_lor, int indice, int cuantos)
        {
            indice--;
            string res_ult = "";

            if (indice > va_lor.Length)
            {
                res_ult = "";
            }
            else if (cuantos > (va_lor.Length - indice))
            {
                cuantos = va_lor.Length - indice;
                res_ult = va_lor.Substring(indice, cuantos);
            }
            else
            {
                res_ult = va_lor.Substring(indice, cuantos);
            }

            return res_ult;
        }

        /// <summary>
        /// Valida que solo se ingrese numeros
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string valida_numeros(string dato)
        {
            string nuevo = null;
            bool bandera = false;

            if (string.IsNullOrWhiteSpace(dato) == false)
            {
                for (int i = 0; i < dato.Trim().Length; i++)
                {
                    if (char.IsNumber(dato[i]) == true)
                    {
                        nuevo += dato[i];
                    }
                    else if (char.IsNumber(dato[i]) == false)
                    {
                        bandera = true;
                    }
                }

                if (bandera == true)
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }

            return nuevo;

        }

        #endregion
    }
}
