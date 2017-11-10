namespace CREARSIS
{
    partial class adm013_02a
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_fec_fin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.tb_fec_ini = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.tb_val_tcm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.gb_ctr_frm.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_fec_fin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_fec_ini)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(20, 17);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 90;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(1, 101);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(226, 48);
            this.gb_ctr_frm.TabIndex = 75;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(132, 17);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 100;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // LabelX1
            // 
            this.LabelX1.AutoSize = true;
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(32, 47);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(38, 21);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Fecha";
            this.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.tb_fec_fin);
            this.GroupBox1.Controls.Add(this.tb_fec_ini);
            this.GroupBox1.Controls.Add(this.tb_val_tcm);
            this.GroupBox1.Controls.Add(this.LabelX2);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(1, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(226, 105);
            this.GroupBox1.TabIndex = 74;
            this.GroupBox1.TabStop = false;
            // 
            // tb_fec_fin
            // 
            // 
            // 
            // 
            this.tb_fec_fin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.tb_fec_fin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_fin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.tb_fec_fin.ButtonDropDown.Visible = true;
            this.tb_fec_fin.CustomFormat = "dd/mm/aaaa";
            this.tb_fec_fin.IsPopupCalendarOpen = false;
            this.tb_fec_fin.Location = new System.Drawing.Point(69, 75);
            this.tb_fec_fin.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.tb_fec_fin.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.tb_fec_fin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.tb_fec_fin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_fin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.tb_fec_fin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.tb_fec_fin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_fin.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            this.tb_fec_fin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.tb_fec_fin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.tb_fec_fin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.tb_fec_fin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.tb_fec_fin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.tb_fec_fin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_fin.MonthCalendar.TodayButtonVisible = true;
            this.tb_fec_fin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(83, 26);
            this.tb_fec_fin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tb_fec_fin.TabIndex = 75;
            // 
            // tb_fec_ini
            // 
            // 
            // 
            // 
            this.tb_fec_ini.BackgroundStyle.Class = "DateTimeInputBackground";
            this.tb_fec_ini.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_ini.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.tb_fec_ini.ButtonDropDown.Visible = true;
            this.tb_fec_ini.CustomFormat = "dd/mm/aaaa";
            this.tb_fec_ini.IsPopupCalendarOpen = false;
            this.tb_fec_ini.Location = new System.Drawing.Point(69, 47);
            this.tb_fec_ini.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.tb_fec_ini.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.tb_fec_ini.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.tb_fec_ini.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_ini.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.tb_fec_ini.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.tb_fec_ini.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_ini.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            this.tb_fec_ini.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.tb_fec_ini.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.tb_fec_ini.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.tb_fec_ini.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.tb_fec_ini.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.tb_fec_ini.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_fec_ini.MonthCalendar.TodayButtonVisible = true;
            this.tb_fec_ini.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(83, 26);
            this.tb_fec_ini.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tb_fec_ini.TabIndex = 74;
            // 
            // tb_val_tcm
            // 
            this.tb_val_tcm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_val_tcm.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_val_tcm.Border.Class = "TextBoxBorder";
            this.tb_val_tcm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_val_tcm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_val_tcm.ForeColor = System.Drawing.Color.Black;
            this.tb_val_tcm.Location = new System.Drawing.Point(69, 17);
            this.tb_val_tcm.MaxLength = 4;
            this.tb_val_tcm.Name = "tb_val_tcm";
            this.tb_val_tcm.PreventEnterBeep = true;
            this.tb_val_tcm.Size = new System.Drawing.Size(66, 26);
            this.tb_val_tcm.TabIndex = 10;
            this.tb_val_tcm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_val_tcm.TextChanged += new System.EventHandler(this.tb_val_tcm_TextChanged);
            // 
            // LabelX2
            // 
            this.LabelX2.AutoSize = true;
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX2.ForeColor = System.Drawing.Color.Black;
            this.LabelX2.Location = new System.Drawing.Point(43, 17);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(24, 21);
            this.LabelX2.TabIndex = 1;
            this.LabelX2.Text = "T.C.";
            this.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // adm013_02a
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(229, 150);
            this.ControlBox = false;
            this.Controls.Add(this.gb_ctr_frm);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "adm013_02a";
            this.Text = "Nuevo T.C - Bs/Us p/rango";
            this.TitleText = "Nuevo T.C - Bs/Us p/rango";
            this.Load += new System.EventHandler(this.adm013_02a_Load);
            this.gb_ctr_frm.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_fec_fin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_fec_ini)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput tb_fec_fin;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput tb_fec_ini;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_val_tcm;
        internal DevComponents.DotNetBar.LabelX LabelX2;
    }
}