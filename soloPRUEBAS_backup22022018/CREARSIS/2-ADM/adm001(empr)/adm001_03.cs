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
using DevComponents.DotNetBar;

namespace CREARSIS
{
    public partial class adm001_03 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        public DataTable vg_str_ucc;
        string err_msg = "";
        DataTable tabla;
        Byte[] va_log_emp;

        #endregion

        #region INSTANCIAS

        c_adm001 o_adm001 = new c_adm001();
        _01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();
        DataTable tab_adm001;

        #endregion

        #region FUNCIONES

        public void fu_ini_frm()
        {
            fu_bus_car();
            gb_ctr_frm.Enabled = true;
        }
        private void fu_bus_car()
        {
            tabla = o_adm001._01();
            tb_nit_emp.Text = tabla.Rows[0]["va_nit_emp"].ToString();
            tb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
            tb_rep_leg.Text = tabla.Rows[0]["va_rep_leg"].ToString();
            tb_tel_emp.Text = tabla.Rows[0]["va_tel_emp"].ToString();
            tb_cel_emp.Text = tabla.Rows[0]["va_cel_emp"].ToString();
            tb_dir_emp.Text = tabla.Rows[0]["va_dir_emp"].ToString();
            tb_cor_reo.Text = tabla.Rows[0]["va_cor_reo"].ToString();
            tb_dir_web.Text = tabla.Rows[0]["va_dir_web"].ToString();
            tb_dir_fbk.Text = tabla.Rows[0]["va_dir_fbk"].ToString();
            tb_cla_wif.Text = tabla.Rows[0]["va_cla_wif"].ToString();

            if (tabla.Rows[0]["va_log_emp"] == DBNull.Value)
            {
                pc_log_emp.Image = pc_log_emp.InitialImage;
            }
            else
            {
                va_log_emp = (Byte[])tabla.Rows[0]["va_log_emp"];
                pc_log_emp.Image = o_mg_glo_bal.fg_byt_img(va_log_emp);
            }

            tb_nit_emp.Focus();

            
        }
        

        private string fu_ver_dat()
        {
            string err_msg = null;

            if (o_mg_glo_bal.fg_val_num(tb_nit_emp.Text) == false)
            {
                tb_nit_emp.Focus();
                err_msg = "El Nit es incorrecto, debe ser numerico";
                return err_msg;
            }

            if (tb_raz_soc.Text.Trim() == "")
            {
                err_msg = "Debe proporcionar la Razon Social de la empresa";
                return err_msg;
            }

            if (tb_rep_leg.Text.Trim() == "")
            {
                err_msg = "Debe proporcionar el represtante legal de la empresa";
                return err_msg;
            }

            return err_msg;
        }

        //private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    int digitos;
        //    digitos = OpenFileDialog1.SafeFileName.Length - 4;
        //    pc_log_emp.ImageLocation = OpenFileDialog1.FileName;
        //}
        #endregion


        public adm001_03()
        {
            InitializeComponent();
        }

        private void adm001_03_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_sub_log_Click(object sender, EventArgs e)
        {
            //Carga Imagen
            OpenFileDialog abrir_archivo = new OpenFileDialog();
            abrir_archivo.Filter = "Imágenes | *.jpeg; *.jpg; *.png";
            abrir_archivo.Title = "Seleccione la Imagen";
            if (abrir_archivo.ShowDialog() == DialogResult.OK)
            {
                pc_log_emp.Image = Image.FromFile(abrir_archivo.FileName);
            }
        }

        private void adm001_03_FormClosing(object sender, FormClosingEventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                var err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBoxEx.Show(err_msg, "Datos de la empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var res_msg = MessageBoxEx.Show("Esta seguro de grabar los datos ?", "Datos de la empresa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }                

                //MODIFICA DATOS
                o_adm001._03(tb_nit_emp.Text, tb_raz_soc.Text, tb_rep_leg.Text, tb_dir_emp.Text, tb_tel_emp.Text, tb_cel_emp.Text, tb_cor_reo.Text, tb_dir_web.Text, tb_dir_fbk.Text, tb_cla_wif.Text);


                //Valida si ingreso una imagen
                if (pc_log_emp.Image!=pc_log_emp.InitialImage)
                {
                    //Convierte la imagen a BYTE
                    va_log_emp = o_mg_glo_bal.fg_img_byt(pc_log_emp.Image);

                    //GUARDA imagen/LOGO
                    o_adm001._03(va_log_emp);
                }                

                MessageBoxEx.Show("Operación completada exitosamente \r\n\r\nNOTA: Para que los cambios se apliquen \r\ndebe reiniciar el sistema Crearsis", "Datos de la Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                o_mg_glo_bal.mg_ads000_04(this, 1);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Datos de la empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
