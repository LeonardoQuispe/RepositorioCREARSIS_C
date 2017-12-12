namespace CREARSIS
{
    partial class inv011_02
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
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_mtd_cto = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cb_mon_inv = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.BO = new DevComponents.Editors.ComboItem();
            this.USD = new DevComponents.Editors.ComboItem();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tb_cta_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX8 = new DevComponents.DotNetBar.LabelX();
            this.dt_fec_ctr = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.tb_dir_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tb_cod_alm = new System.Windows.Forms.MaskedTextBox();
            this.tb_nro_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.tb_nom_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_des_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX9 = new DevComponents.DotNetBar.LabelX();
            this.LabelX4 = new DevComponents.DotNetBar.LabelX();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.tb_gru_alm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_dir_ecg = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.tb_tlf_ecg = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.tb_nom_ecg = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.gb_ctr_frm.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fec_ctr)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(12, 411);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(493, 48);
            this.gb_ctr_frm.TabIndex = 2;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(391, 16);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(286, 16);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 0;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.cb_mtd_cto);
            this.GroupBox1.Controls.Add(this.labelX10);
            this.GroupBox1.Controls.Add(this.cb_mon_inv);
            this.GroupBox1.Controls.Add(this.labelX7);
            this.GroupBox1.Controls.Add(this.tb_cta_alm);
            this.GroupBox1.Controls.Add(this.labelX6);
            this.GroupBox1.Controls.Add(this.LabelX8);
            this.GroupBox1.Controls.Add(this.dt_fec_ctr);
            this.GroupBox1.Controls.Add(this.tb_dir_alm);
            this.GroupBox1.Controls.Add(this.labelX5);
            this.GroupBox1.Controls.Add(this.labelX2);
            this.GroupBox1.Controls.Add(this.tb_cod_alm);
            this.GroupBox1.Controls.Add(this.tb_nro_alm);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.Controls.Add(this.tb_nom_alm);
            this.GroupBox1.Controls.Add(this.tb_des_alm);
            this.GroupBox1.Controls.Add(this.LabelX9);
            this.GroupBox1.Controls.Add(this.LabelX4);
            this.GroupBox1.Controls.Add(this.LabelX3);
            this.GroupBox1.Controls.Add(this.tb_gru_alm);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(12, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(493, 279);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // cb_mtd_cto
            // 
            this.cb_mtd_cto.DisplayMember = "Text";
            this.cb_mtd_cto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_mtd_cto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mtd_cto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_mtd_cto.FocusHighlightColor = System.Drawing.Color.Blue;
            this.cb_mtd_cto.ForeColor = System.Drawing.Color.Black;
            this.cb_mtd_cto.FormattingEnabled = true;
            this.cb_mtd_cto.ItemHeight = 20;
            this.cb_mtd_cto.Items.AddRange(new object[] {
            this.comboItem3});
            this.cb_mtd_cto.Location = new System.Drawing.Point(310, 242);
            this.cb_mtd_cto.Name = "cb_mtd_cto";
            this.cb_mtd_cto.Size = new System.Drawing.Size(131, 26);
            this.cb_mtd_cto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_mtd_cto.TabIndex = 17;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Promedio Ponderado";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(226, 242);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(97, 21);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "Método Costeo";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cb_mon_inv
            // 
            this.cb_mon_inv.DisplayMember = "Text";
            this.cb_mon_inv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_mon_inv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mon_inv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_mon_inv.FocusHighlightColor = System.Drawing.Color.Blue;
            this.cb_mon_inv.ForeColor = System.Drawing.Color.Black;
            this.cb_mon_inv.FormattingEnabled = true;
            this.cb_mon_inv.ItemHeight = 20;
            this.cb_mon_inv.Items.AddRange(new object[] {
            this.BO,
            this.USD});
            this.cb_mon_inv.Location = new System.Drawing.Point(126, 242);
            this.cb_mon_inv.Name = "cb_mon_inv";
            this.cb_mon_inv.Size = new System.Drawing.Size(82, 26);
            this.cb_mon_inv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_mon_inv.TabIndex = 15;
            // 
            // BO
            // 
            this.BO.Text = "Bolivianos";
            // 
            // USD
            // 
            this.USD.Text = "Dóladres";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(16, 242);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(118, 21);
            this.labelX7.TabIndex = 14;
            this.labelX7.Text = "Moneda Inventario";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_cta_alm
            // 
            this.tb_cta_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cta_alm.Border.Class = "TextBoxBorder";
            this.tb_cta_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cta_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cta_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_cta_alm.Location = new System.Drawing.Point(126, 161);
            this.tb_cta_alm.MaxLength = 6;
            this.tb_cta_alm.Multiline = true;
            this.tb_cta_alm.Name = "tb_cta_alm";
            this.tb_cta_alm.PreventEnterBeep = true;
            this.tb_cta_alm.Size = new System.Drawing.Size(354, 22);
            this.tb_cta_alm.TabIndex = 11;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(16, 161);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(104, 21);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Cuenta Contable";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // LabelX8
            // 
            this.LabelX8.AutoSize = true;
            this.LabelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX8.ForeColor = System.Drawing.Color.Black;
            this.LabelX8.Location = new System.Drawing.Point(16, 201);
            this.LabelX8.Name = "LabelX8";
            this.LabelX8.Size = new System.Drawing.Size(130, 21);
            this.LabelX8.TabIndex = 12;
            this.LabelX8.Text = "Última Fecha Control";
            // 
            // dt_fec_ctr
            // 
            this.dt_fec_ctr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dt_fec_ctr.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt_fec_ctr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fec_ctr.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt_fec_ctr.ButtonDropDown.Visible = true;
            this.dt_fec_ctr.ForeColor = System.Drawing.Color.Black;
            this.dt_fec_ctr.IsPopupCalendarOpen = false;
            this.dt_fec_ctr.Location = new System.Drawing.Point(126, 201);
            // 
            // 
            // 
            this.dt_fec_ctr.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dt_fec_ctr.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fec_ctr.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt_fec_ctr.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt_fec_ctr.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fec_ctr.MonthCalendar.DisplayMonth = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            this.dt_fec_ctr.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dt_fec_ctr.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dt_fec_ctr.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt_fec_ctr.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fec_ctr.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt_fec_ctr.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fec_ctr.MonthCalendar.TodayButtonVisible = true;
            this.dt_fec_ctr.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dt_fec_ctr.Name = "dt_fec_ctr";
            this.dt_fec_ctr.Size = new System.Drawing.Size(82, 26);
            this.dt_fec_ctr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt_fec_ctr.TabIndex = 13;
            this.dt_fec_ctr.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
            this.dt_fec_ctr.Value = new System.DateTime(2017, 5, 27, 0, 0, 0, 0);
            // 
            // tb_dir_alm
            // 
            this.tb_dir_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_dir_alm.Border.Class = "TextBoxBorder";
            this.tb_dir_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_dir_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_dir_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_dir_alm.Location = new System.Drawing.Point(126, 124);
            this.tb_dir_alm.MaxLength = 200;
            this.tb_dir_alm.Multiline = true;
            this.tb_dir_alm.Name = "tb_dir_alm";
            this.tb_dir_alm.PreventEnterBeep = true;
            this.tb_dir_alm.Size = new System.Drawing.Size(354, 22);
            this.tb_dir_alm.TabIndex = 9;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(16, 124);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(59, 21);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Dirección";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(341, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(86, 21);
            this.labelX2.TabIndex = 18;
            this.labelX2.Text = "Cod. Almacén";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_cod_alm
            // 
            this.tb_cod_alm.BackColor = System.Drawing.Color.White;
            this.tb_cod_alm.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_alm.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_alm.Location = new System.Drawing.Point(417, 19);
            this.tb_cod_alm.Mask = "00-00-000";
            this.tb_cod_alm.Name = "tb_cod_alm";
            this.tb_cod_alm.PromptChar = ' ';
            this.tb_cod_alm.ReadOnly = true;
            this.tb_cod_alm.Size = new System.Drawing.Size(63, 26);
            this.tb_cod_alm.TabIndex = 19;
            this.tb_cod_alm.TabStop = false;
            this.tb_cod_alm.Text = "0000000";
            this.tb_cod_alm.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // tb_nro_alm
            // 
            this.tb_nro_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nro_alm.Border.Class = "TextBoxBorder";
            this.tb_nro_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nro_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nro_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_nro_alm.Location = new System.Drawing.Point(294, 20);
            this.tb_nro_alm.MaxLength = 3;
            this.tb_nro_alm.Name = "tb_nro_alm";
            this.tb_nro_alm.PreventEnterBeep = true;
            this.tb_nro_alm.Size = new System.Drawing.Size(34, 26);
            this.tb_nro_alm.TabIndex = 3;
            this.tb_nro_alm.Text = "0";
            this.tb_nro_alm.TextChanged += new System.EventHandler(this.tb_nro_alm_TextChanged);
            this.tb_nro_alm.Validated += new System.EventHandler(this.tb_nro_alm_Validated);
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
            this.LabelX1.Location = new System.Drawing.Point(220, 20);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(85, 21);
            this.LabelX1.TabIndex = 2;
            this.LabelX1.Text = "Nro. Almacén";
            this.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_nom_alm
            // 
            this.tb_nom_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_alm.Border.Class = "TextBoxBorder";
            this.tb_nom_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_alm.Location = new System.Drawing.Point(127, 52);
            this.tb_nom_alm.MaxLength = 40;
            this.tb_nom_alm.Name = "tb_nom_alm";
            this.tb_nom_alm.PreventEnterBeep = true;
            this.tb_nom_alm.Size = new System.Drawing.Size(353, 26);
            this.tb_nom_alm.TabIndex = 5;
            // 
            // tb_des_alm
            // 
            this.tb_des_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_des_alm.Border.Class = "TextBoxBorder";
            this.tb_des_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_des_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_des_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_des_alm.Location = new System.Drawing.Point(126, 86);
            this.tb_des_alm.MaxLength = 160;
            this.tb_des_alm.Multiline = true;
            this.tb_des_alm.Name = "tb_des_alm";
            this.tb_des_alm.PreventEnterBeep = true;
            this.tb_des_alm.Size = new System.Drawing.Size(354, 22);
            this.tb_des_alm.TabIndex = 7;
            // 
            // LabelX9
            // 
            this.LabelX9.AutoSize = true;
            this.LabelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX9.ForeColor = System.Drawing.Color.Black;
            this.LabelX9.Location = new System.Drawing.Point(16, 86);
            this.LabelX9.Name = "LabelX9";
            this.LabelX9.Size = new System.Drawing.Size(73, 21);
            this.LabelX9.TabIndex = 6;
            this.LabelX9.Text = "Descripcion";
            this.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // LabelX4
            // 
            this.LabelX4.AutoSize = true;
            this.LabelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX4.ForeColor = System.Drawing.Color.Black;
            this.LabelX4.Location = new System.Drawing.Point(16, 52);
            this.LabelX4.Name = "LabelX4";
            this.LabelX4.Size = new System.Drawing.Size(53, 21);
            this.LabelX4.TabIndex = 4;
            this.LabelX4.Text = "Nombre";
            this.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // LabelX3
            // 
            this.LabelX3.AutoSize = true;
            this.LabelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX3.ForeColor = System.Drawing.Color.Black;
            this.LabelX3.Location = new System.Drawing.Point(16, 20);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(97, 21);
            this.LabelX3.TabIndex = 0;
            this.LabelX3.Text = "Grupo Almacén";
            this.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_gru_alm
            // 
            this.tb_gru_alm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_gru_alm.Border.Class = "TextBoxBorder";
            this.tb_gru_alm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_gru_alm.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.CtrlB;
            this.tb_gru_alm.ButtonCustom.Symbol = "";
            this.tb_gru_alm.ButtonCustom.Visible = true;
            this.tb_gru_alm.DisabledBackColor = System.Drawing.Color.White;
            this.tb_gru_alm.ForeColor = System.Drawing.Color.Black;
            this.tb_gru_alm.Location = new System.Drawing.Point(127, 20);
            this.tb_gru_alm.MaxLength = 4;
            this.tb_gru_alm.Name = "tb_gru_alm";
            this.tb_gru_alm.PreventEnterBeep = true;
            this.tb_gru_alm.Size = new System.Drawing.Size(81, 26);
            this.tb_gru_alm.TabIndex = 1;
            this.tb_gru_alm.ButtonCustomClick += new System.EventHandler(this.tb_gru_alm_ButtonCustomClick);
            this.tb_gru_alm.TextChanged += new System.EventHandler(this.tb_gru_alm_TextChanged);
            this.tb_gru_alm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_gru_alm_KeyDown);
            this.tb_gru_alm.Validated += new System.EventHandler(this.tb_gru_alm_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.tb_dir_ecg);
            this.groupBox2.Controls.Add(this.labelX11);
            this.groupBox2.Controls.Add(this.tb_tlf_ecg);
            this.groupBox2.Controls.Add(this.labelX12);
            this.groupBox2.Controls.Add(this.tb_nom_ecg);
            this.groupBox2.Controls.Add(this.labelX13);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tb_dir_ecg
            // 
            this.tb_dir_ecg.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_dir_ecg.Border.Class = "TextBoxBorder";
            this.tb_dir_ecg.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_dir_ecg.DisabledBackColor = System.Drawing.Color.White;
            this.tb_dir_ecg.ForeColor = System.Drawing.Color.Black;
            this.tb_dir_ecg.Location = new System.Drawing.Point(125, 102);
            this.tb_dir_ecg.MaxLength = 200;
            this.tb_dir_ecg.Multiline = true;
            this.tb_dir_ecg.Name = "tb_dir_ecg";
            this.tb_dir_ecg.PreventEnterBeep = true;
            this.tb_dir_ecg.Size = new System.Drawing.Size(355, 22);
            this.tb_dir_ecg.TabIndex = 5;
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.ForeColor = System.Drawing.Color.Black;
            this.labelX11.Location = new System.Drawing.Point(16, 102);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(127, 21);
            this.labelX11.TabIndex = 4;
            this.labelX11.Text = "Dirección Encargado";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_tlf_ecg
            // 
            this.tb_tlf_ecg.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_tlf_ecg.Border.Class = "TextBoxBorder";
            this.tb_tlf_ecg.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_tlf_ecg.DisabledBackColor = System.Drawing.Color.White;
            this.tb_tlf_ecg.ForeColor = System.Drawing.Color.Black;
            this.tb_tlf_ecg.Location = new System.Drawing.Point(125, 65);
            this.tb_tlf_ecg.MaxLength = 10;
            this.tb_tlf_ecg.Multiline = true;
            this.tb_tlf_ecg.Name = "tb_tlf_ecg";
            this.tb_tlf_ecg.PreventEnterBeep = true;
            this.tb_tlf_ecg.Size = new System.Drawing.Size(355, 22);
            this.tb_tlf_ecg.TabIndex = 3;
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.ForeColor = System.Drawing.Color.Black;
            this.labelX12.Location = new System.Drawing.Point(16, 65);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(123, 21);
            this.labelX12.TabIndex = 2;
            this.labelX12.Text = "Teléfono Encargado";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_nom_ecg
            // 
            this.tb_nom_ecg.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_ecg.Border.Class = "TextBoxBorder";
            this.tb_nom_ecg.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_ecg.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_ecg.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_ecg.Location = new System.Drawing.Point(125, 27);
            this.tb_nom_ecg.MaxLength = 120;
            this.tb_nom_ecg.Multiline = true;
            this.tb_nom_ecg.Name = "tb_nom_ecg";
            this.tb_nom_ecg.PreventEnterBeep = true;
            this.tb_nom_ecg.Size = new System.Drawing.Size(355, 22);
            this.tb_nom_ecg.TabIndex = 1;
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.ForeColor = System.Drawing.Color.Black;
            this.labelX13.Location = new System.Drawing.Point(16, 27);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(121, 21);
            this.labelX13.TabIndex = 0;
            this.labelX13.Text = "Nombre Encargado";
            this.labelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // inv011_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 463);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_frm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "inv011_02";
            this.Text = "Nuevo Almacén";
            this.TitleText = "Nuevo Almacén";
            this.Load += new System.EventHandler(this.inv011_02_Load);
            this.gb_ctr_frm.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fec_ctr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal System.Windows.Forms.MaskedTextBox tb_cod_alm;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nro_alm;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_alm;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_des_alm;
        internal DevComponents.DotNetBar.LabelX LabelX9;
        internal DevComponents.DotNetBar.LabelX LabelX4;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_gru_alm;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_dir_alm;
        internal DevComponents.DotNetBar.LabelX labelX5;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cta_alm;
        internal DevComponents.DotNetBar.LabelX labelX6;
        internal DevComponents.DotNetBar.LabelX LabelX8;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput dt_fec_ctr;
        internal DevComponents.DotNetBar.LabelX labelX7;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_mtd_cto;
        private DevComponents.Editors.ComboItem comboItem3;
        internal DevComponents.DotNetBar.LabelX labelX10;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_mon_inv;
        private DevComponents.Editors.ComboItem BO;
        private DevComponents.Editors.ComboItem USD;
        public System.Windows.Forms.GroupBox groupBox2;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_dir_ecg;
        internal DevComponents.DotNetBar.LabelX labelX11;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_tlf_ecg;
        internal DevComponents.DotNetBar.LabelX labelX12;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_ecg;
        internal DevComponents.DotNetBar.LabelX labelX13;
    }
}