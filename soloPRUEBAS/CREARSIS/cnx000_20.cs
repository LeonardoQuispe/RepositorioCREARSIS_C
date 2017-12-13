using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//REFERENCIAS

using DATOS;
using DATOS;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO MENSAJE DE NOTIFICAION
    /// </summary>
    public partial class cnx000_20 : Form
    {
        #region VARIABLES

        //variable nr de Notificaciones
        public int nro_not;
        bool act_iva = true;
        // pos_cer As Integer = 0
        int con_tad = 0;

        #endregion

        #region EVENTOS

        public cnx000_20()
        {
            InitializeComponent();
        }

        private void cnx000_20_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            fu_cer_rar();
        }

        private void cnx000_20_Load(object sender, EventArgs e)
        {
            fu_ubi_not();
        }
        //Timer encargado del efecto mostrar y ocultar/cerrar de la notificacion
        private void tm_not_ify_Tick(object sender, EventArgs e)
        {
            if (act_iva == true)
            {
                if (this.Opacity < 100)
                {
                    this.Opacity += 0.1;
                }
                else
                {
                    tm_not_ify.Enabled = false;
                }
            }
            else
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.1;
                }
                else
                {
                    tm_not_ify.Enabled = false;
                    this.Dispose();
                    this.Close();
                }

            }
        }
        private void SymbolBox1_Click(object sender, EventArgs e)
        {
            fu_cer_rar();
            _01_mg_glo_bal.mg_cer_not();
        }

        private void tm_org_pos_Tick(object sender, EventArgs e)
        {
            //Disminuir la posicion de la notificacion 110 posiciones
            this.Top = this.Top - 1;

            con_tad++;

            if (con_tad == 110)
            {
                tm_org_pos.Enabled = false;
                con_tad = 0;
            }
        }


        #endregion

        #region METODOS

        /// <summary>
        /// Metodo que Ubica la posicion en la que se mostrara la notificacion al aparecer
        /// </summary>
        void fu_ubi_not()
        {
            System.Drawing.Point pos_xey = new System.Drawing.Point();
            pos_xey.X = 0;
            pos_xey.Y = 110;
            int Y = 0;

            for (int i = 2; i <= nro_not; i++)
            {
                Y += pos_xey.Y;
            }
            this.Top = Y;
        }

        //Metodo encargado de cerrar la notificacion
        void fu_cer_rar()
        {
            act_iva = false;
            //Activa el timer de efecto que oculta y cierra la notificacion
            tm_not_ify.Enabled = true;
            //Establece el numero de la notificacon que fue cerro
            Program.gl_win_cer = nro_not;
        }

        #endregion
    }
}
