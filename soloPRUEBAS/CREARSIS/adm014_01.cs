﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//REFERENCIAS
using DATOS.ADM;
using CREARSIS.GLOBAL;
using DevComponents.DotNetBar;
using System.Globalization;


namespace CREARSIS
{
    public partial class adm014_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tabla;
        DataTable vg_str_ucc;
        DataTable tab_adm014;

        int tip_frm = 0;
        int ban_aux = 0;

        #endregion

        #region INSTANCIAS

        c_adm014 o_adm014 = new c_adm014();
        mg_glo_bal o_mg_glo_bal = new mg_glo_bal();

        #endregion


        #region METODOS
        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            //** Obtiene el mes y el año actual del servidor
            cb_prm_bus.SelectedIndex = o_mg_glo_bal.fg_fec_act().Month - 1;
            tb_val_año.Minimum = o_mg_glo_bal.fg_fec_act().Year - 5;
            tb_val_año.Maximum = o_mg_glo_bal.fg_fec_act().Year + 5;
            tb_val_año.Value = o_mg_glo_bal.fg_fec_act().Year;

            fu_bus_car(o_mg_glo_bal.fg_fec_act().Month.ToString(), o_mg_glo_bal.fg_fec_act().Year);

            tip_frm = va_tip_frm;

            if (tip_frm == 0)
            {
                gb_ctr_frm.Enabled = false;
            }
            else
            {
                gb_ctr_frm.Enabled = true;
            }

        }
        public static int Weekday(DateTime dt, DayOfWeek startOfWeek)
        {
            return (dt.DayOfWeek - startOfWeek + 7) % 7;
        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_mes ">Mes a buscar</param>
        public void fu_bus_car(string val_mes, int val_año)
        {
            try
            {

                DateTime fec_ini;
                //** Fecha Inicial
                DateTime fec_fin;
                //** Fecha Final
                int nro_dms = 0;
                //** Numero de dias del mes
                int str_dia = 0;
                //** Nombre del dia

                fl_cal_end.Controls.Clear();

                fec_ini = Convert.ToDateTime("01/" + val_mes.ToString() + "/" + val_año.ToString());
                fec_fin = fec_ini;
                fec_fin= fec_ini.AddMonths(1);
                fec_fin= fec_fin.AddDays(-1);
                
                TimeSpan ts = fec_fin - fec_ini;

                nro_dms = ts.Days;
                nro_dms = nro_dms + 1;


                switch (fec_ini.DayOfWeek)
                {
                    case DayOfWeek.Sunday: str_dia = 1;
                        break;
                    case DayOfWeek.Monday: str_dia = 2;
                        break;
                    case DayOfWeek.Tuesday: str_dia = 3;
                        break;
                    case DayOfWeek.Wednesday: str_dia = 4;
                        break;
                    case DayOfWeek.Thursday: str_dia =5;
                        break;
                    case DayOfWeek.Friday: str_dia = 6;
                        break;
                    case DayOfWeek.Saturday: str_dia = 7;
                        break;
                }

                //--** Bucle para dias iniciales deshabilitados 
                for (int j = 0; j <= str_dia - 2; j++)
                {
                    Button bot_val = new Button();
                    System.Windows.Forms.Padding val_pad = new System.Windows.Forms.Padding();
                    val_pad.All = 0;
                    var _with1 = bot_val;
                    // .Location = New Point(64, 40)
                    _with1.Size = new Size(72, 70);
                    _with1.Margin = val_pad;
                    _with1.TabIndex = 0;
                    _with1.Text = "T.C" + (Char)13 + "0.00" + (Char)13 + (Char)13 + "---------";
                    _with1.Name = j.ToString() ;
                    _with1.FlatStyle = FlatStyle.Popup;
                    _with1.Enabled = false;
                    if (j == 0)
                    {
                        _with1.BackColor = Color.Wheat;
                    }
                    fl_cal_end.Controls.Add(bot_val);
                }

                //** Obtiene T.C de todo el mes
                tab_adm014 = o_adm014._01(int.Parse(val_mes), val_año);

                for (int i = 1; i <= nro_dms; i++)
                {
                    Button bot_val = new Button();
                    DateTime fec_aux;
                    System.Windows.Forms.Padding val_pad = new System.Windows.Forms.Padding();
                    val_pad.All = 0;
                    fec_aux =Convert.ToDateTime( i + "/" + val_mes + "/" + val_año).Date;


                    int ban_dat = 0;

                    for (int j = 0; j <= tab_adm014.Rows.Count - 1; j++)
                    {
                        if (Convert.ToDateTime( tab_adm014.Rows[j]["va_fec_buf"].ToString()) == fec_aux)
                        {
                            var _with2 = bot_val;
                            _with2.Size = new Size(72, 70);
                            _with2.Margin = val_pad;
                            _with2.TabIndex = i;
                            _with2.Text = "T.C" + (Char)13 + 
                              tab_adm014.Rows[j]["va_val_buf"].ToString().Trim() + (Char)13 + (Char)13 +
                              tab_adm014.Rows[j]["va_fec_buf"].ToString().Trim();
                            _with2.Name = fec_aux.ToString();
                            _with2.BackColor = Color.Azure;
                            _with2.ForeColor = Color.DarkBlue;
                            _with2.Cursor = Cursors.Hand;

                            //--** Los dias domingos son mintados casi rojos
                            //string dia = "";
                            //dia = Weekday(Weekday(fec_aux, DayOfWeek.Sunday), false, DayOfWeek.Sunday);

                            int nro_dia = 0;
                            nro_dia = Weekday(fec_aux, DayOfWeek.Sunday);



                            if (fec_aux.DayOfWeek==DayOfWeek.Sunday)
                            {
                                _with2.BackColor = Color.Wheat;
                                //.FlatAppearance.BorderColor = Color.Blue
                                //.FlatAppearance.BorderSize = 1
                            }

                            bot_val.Click += mt_bot_tcd;
                            ban_dat = 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (ban_dat == 0)
                    {
                        var _with3 = bot_val;
                        _with3.Size = new Size(72, 70);
                        _with3.Margin = val_pad;
                        _with3.TabIndex = i;
                        _with3.Text = "T.C" + (Char)13 + "0.00" + (Char)13 + (Char)13 + fec_aux.ToShortDateString();
                        _with3.Name = fec_aux.ToString();
                        _with3.Cursor = Cursors.Hand;

                        //--** Los dias domingos son mintados casi rojos
                        if (Weekday(fec_aux, DayOfWeek.Sunday) == 1)
                        {
                            _with3.BackColor = Color.Wheat;
                        }
                        else
                        {
                            _with3.FlatStyle = FlatStyle.System;
                        }
                        bot_val.Click += mt_bot_tcd;
                    }
                    //If tab_adm014.Rows.Count Then
                    //    With bot_val
                    //        .Size = New Size(72, 70)
                    //        .Margin = val_pad
                    //        .TabIndex = i
                    //        .Text = "T.C" & Chr(13) & _
                    //           Trim(tab_adm014.Rows(0).Item("va_val_buf")) & Chr(13) & Chr(13) & _
                    //            Trim(tab_adm014.Rows(0).Item("va_fec_buf"))
                    //        .Name = fec_aux
                    //        .BackColor = Color.Azure
                    //        .ForeColor = Color.DarkBlue
                    //        .Cursor = Cursors.Hand
                    //        '.FlatStyle = FlatStyle.System
                    //        '--** Los dias domingos son mintados casi rojos
                    //        Dim dia As String
                    //        dia = WeekdayName(Weekday(fec_aux, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.Sunday)

                    //        Dim nro_dia As Integer
                    //        nro_dia = Weekday(fec_aux, FirstDayOfWeek.Sunday)

                    //        If Weekday(fec_aux, FirstDayOfWeek.Sunday) = 1 Then
                    //            .BackColor = Color.Wheat
                    //            .FlatAppearance.BorderColor = Color.Blue
                    //            .FlatAppearance.BorderSize = 1
                    //        End If


                    //        AddHandler bot_val.Click, AddressOf mt_bot_tcd
                    //    End With

                    //Else
                    //    With bot_val
                    //        .Size = New Size(72, 70)
                    //        .Margin = val_pad
                    //        .TabIndex = i
                    //        .Text = "T.C" & Chr(13) & _
                    //            "0.00" & Chr(13) & Chr(13) & _
                    //            fec_aux
                    //        .Name = fec_aux
                    //        .Cursor = Cursors.Hand

                    //        Dim dia As String
                    //        dia = WeekdayName(Weekday(fec_aux, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.Sunday)

                    //        Dim nro_dia As Integer
                    //        nro_dia = Weekday(fec_aux, FirstDayOfWeek.Sunday)


                    //        '--** Los dias domingos son mintados casi rojos
                    //        If Weekday(fec_aux, FirstDayOfWeek.Sunday) = 1 Then
                    //            .BackColor = Color.Wheat
                    //        Else
                    //            .FlatStyle = FlatStyle.System
                    //        End If
                    //        AddHandler bot_val.Click, AddressOf mt_bot_tcd
                    //    End With

                    //End If

                    fl_cal_end.Controls.Add(bot_val);

                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Metodo activado con el click en el boton de la fecha T.C.
        /// </summary>
        public void mt_bot_tcd(object sender, EventArgs e)
        {
            vg_str_ucc = new DataTable();

            Button bot_fec = (Button)sender;
            string vv_fec_tcd = bot_fec.Name;

            vg_str_ucc.Columns.Add("va_fec_tcm");
            vg_str_ucc.Columns.Add("va_val_tcm");

            vg_str_ucc.Rows.Add();
            vg_str_ucc.Rows[0]["va_fec_tcm"] = vv_fec_tcd;
            vg_str_ucc.Rows[0]["va_val_tcm"]= 0.0;

            //--** Si es abierta desde el ABM abre la ventana nuevo con el click
            if (tip_frm == 0)
            {
                adm014_02 temp = new adm014_02();
                o_mg_glo_bal.mg_ads000_02(temp, this, vg_str_ucc);
            }


        }


        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            //If Trim(tb_sel_ecc.Text).Length = 0 Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If

            //If IsNumeric(tb_sel_ecc.Text) = False Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If


            //tabla = o_adm014._05(tb_sel_ecc.Text)
            //If tabla.Rows.Count = 0 Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If

            //tb_sel_ecc.Text = tabla.Rows(0).Item("va_cod_rgn")
            //lb_sel_ecc.Text = tabla.Rows(0).Item("va_nom_rgn")

        }
        /// <summary>
        ///-> Metodo para capturar la fila seleccionada
        /// </summary>
        public void fu_fil_act()
        {
            //Dim fila As Integer = dg_res_ult.CurrentCellAddress.Y

            //tb_sel_ecc.Text = dg_res_ult.Rows(fila).Cells("va_cod_rgn").Value
            //lb_sel_ecc.Text = dg_res_ult.Rows(fila).Cells("va_nom_rgn").Value

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            //'Si aun existe
            //tab_adm014 = o_adm014._05(tb_sel_ecc.Text)
            //If tab_adm014.Rows.Count = 0 Then
            //    Return "La Regional no se encuentra registrada"
            //End If

            return null;
        }

        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        public string fu_ver_dat2()
        {
            //'Si aun existe
            //tab_adm014 = o_adm014._05(tb_sel_ecc.Text)
            //If tab_adm014.Rows.Count = 0 Then
            //    Return "La Regional no se encuentra registrada"
            //End If

            return null;
        }
        #endregion


        public adm014_01()
        {
            InitializeComponent();
        }

        private void adm014_01_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
            LabelX1.ForeColor = Color.Red;

            ban_aux = 1;
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            o_mg_glo_bal.mg_ads000_04(this, 1);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            Close();
        }

        private void m_adm014_02a_Click(object sender, EventArgs e)
        {
            //adm014_02a obj = new adm014_02a();
            //o_mg_glo_bal.mg_ads000_02(obj, this);
        }

        private void m_adm014_05_Click(object sender, EventArgs e)
        {

            string vv_err_msg = null;
            vv_err_msg = fu_ver_dat();
            if (vv_err_msg != null)
            {
                MessageBoxEx.Show(vv_err_msg, "Regional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void cb_prm_bus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ban_aux == 1)
            {
                fu_bus_car((cb_prm_bus.SelectedIndex+1).ToString(),Convert.ToInt32( tb_val_año.Value));
            }

        }

        private void tb_val_año_ValueChanged(object sender, EventArgs e)
        {
            if (ban_aux == 1)
            {
                fu_bus_car((cb_prm_bus.SelectedIndex + 1).ToString(), Convert.ToInt32(tb_val_año.Value));
            }
        }
    }
}
