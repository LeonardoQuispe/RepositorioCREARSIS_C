using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CREARSIS
{
    static class Program
    {
        public static string gl_usr_usr = "";
        public static string gl_cnx_str = "";
        public static string gl_bdo_usr = "";
        public static string gl_nom_usr = "";
        public static string gl_ide_gru = "";
        public static string gl_nom_emp = "";
        //VARIABLE GLOBAL PARA CONTROLAR EL NUMERO DE VENTANAS ABIERTAS
        public static int gl_nro_win = 0;
        //VARIABLE GLOBAL PARA CONTROLAR LAS NOTIFICACIONES Y SUS POSICIONES
        public static int gl_nro_not = 0;
        public static int gl_win_cer = 0;
        public static string ClientSettingsProviderServiceUri = "";        


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new cnx000());
        }
    }
}
