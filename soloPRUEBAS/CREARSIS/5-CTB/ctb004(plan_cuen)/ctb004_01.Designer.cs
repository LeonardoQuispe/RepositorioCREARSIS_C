﻿namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    partial class ctb004_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_prm_bus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.codigo = new DevComponents.Editors.ComboItem();
            this.nombre = new DevComponents.Editors.ComboItem();
            this.cb_est_bus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.todos = new DevComponents.Editors.ComboItem();
            this.habilitado = new DevComponents.Editors.ComboItem();
            this.deshabilitado = new DevComponents.Editors.ComboItem();
            this.lb_sel_ecc = new DevComponents.DotNetBar.LabelX();
            this.tb_val_bus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_sel_ecc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.m_atr_ass = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_p00 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctb004_05 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctb004_06 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctb004_04 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctb004_03 = new System.Windows.Forms.ToolStripMenuItem();
            this.mr_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctb004_02 = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.mn_pri_nci = new System.Windows.Forms.MenuStrip();
            this.va_cod_cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tip_cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_uso_cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_mon_cta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_frm.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.mn_pri_nci.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(387, 15);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 60;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(4, 266);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(613, 48);
            this.gb_ctr_frm.TabIndex = 67;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(499, 15);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 70;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.cb_prm_bus);
            this.GroupBox1.Controls.Add(this.cb_est_bus);
            this.GroupBox1.Controls.Add(this.lb_sel_ecc);
            this.GroupBox1.Controls.Add(this.tb_val_bus);
            this.GroupBox1.Controls.Add(this.tb_sel_ecc);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(4, -2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(613, 81);
            this.GroupBox1.TabIndex = 65;
            this.GroupBox1.TabStop = false;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DisplayMember = "Text";
            this.cb_prm_bus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.ForeColor = System.Drawing.Color.Black;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.ItemHeight = 16;
            this.cb_prm_bus.Items.AddRange(new object[] {
            this.codigo,
            this.nombre});
            this.cb_prm_bus.Location = new System.Drawing.Point(415, 50);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(86, 22);
            this.cb_prm_bus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_prm_bus.TabIndex = 30;
            // 
            // codigo
            // 
            this.codigo.Text = "Codigo";
            this.codigo.Value = "1";
            // 
            // nombre
            // 
            this.nombre.Text = "Nombre";
            this.nombre.Value = "2";
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DisplayMember = "Text";
            this.cb_est_bus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_est_bus.FocusHighlightColor = System.Drawing.Color.Blue;
            this.cb_est_bus.ForeColor = System.Drawing.Color.Black;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.ItemHeight = 16;
            this.cb_est_bus.Items.AddRange(new object[] {
            this.todos,
            this.habilitado,
            this.deshabilitado});
            this.cb_est_bus.Location = new System.Drawing.Point(509, 50);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(93, 22);
            this.cb_est_bus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_est_bus.TabIndex = 40;
            // 
            // todos
            // 
            this.todos.Text = "Todos";
            this.todos.Value = "";
            // 
            // habilitado
            // 
            this.habilitado.Text = "Habilitado";
            this.habilitado.Value = "";
            // 
            // deshabilitado
            // 
            this.deshabilitado.Text = "Deshabilitado";
            this.deshabilitado.Value = "";
            // 
            // lb_sel_ecc
            // 
            this.lb_sel_ecc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lb_sel_ecc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.lb_sel_ecc.Location = new System.Drawing.Point(247, 19);
            this.lb_sel_ecc.Name = "lb_sel_ecc";
            this.lb_sel_ecc.Size = new System.Drawing.Size(355, 23);
            this.lb_sel_ecc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lb_sel_ecc.TabIndex = 1;
            // 
            // tb_val_bus
            // 
            this.tb_val_bus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_val_bus.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_val_bus.Border.Class = "TextBoxBorder";
            this.tb_val_bus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_val_bus.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.CtrlB;
            this.tb_val_bus.ButtonCustom.Symbol = "";
            this.tb_val_bus.ButtonCustom.Visible = true;
            this.tb_val_bus.DisabledBackColor = System.Drawing.Color.White;
            this.tb_val_bus.ForeColor = System.Drawing.Color.Black;
            this.tb_val_bus.Location = new System.Drawing.Point(16, 50);
            this.tb_val_bus.MaxLength = 50;
            this.tb_val_bus.Name = "tb_val_bus";
            this.tb_val_bus.PreventEnterBeep = true;
            this.tb_val_bus.Size = new System.Drawing.Size(384, 22);
            this.tb_val_bus.TabIndex = 20;
            this.tb_val_bus.ButtonCustomClick += new System.EventHandler(this.tb_val_bus_ButtonCustomClick);
            this.tb_val_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_val_bus_KeyDown);
            // 
            // tb_sel_ecc
            // 
            this.tb_sel_ecc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_sel_ecc.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_sel_ecc.Border.Class = "TextBoxBorder";
            this.tb_sel_ecc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_sel_ecc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_sel_ecc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_ecc.Location = new System.Drawing.Point(101, 19);
            this.tb_sel_ecc.MaxLength = 3;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.PreventEnterBeep = true;
            this.tb_sel_ecc.Size = new System.Drawing.Size(140, 22);
            this.tb_sel_ecc.TabIndex = 10;
            this.tb_sel_ecc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sel_ecc_KeyDown);
            this.tb_sel_ecc.Validated += new System.EventHandler(this.tb_sel_ecc_Validated);
            // 
            // LabelX1
            // 
            this.LabelX1.AutoSize = true;
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(15, 21);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(80, 17);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Plan de Cuentas";
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToOrderColumns = true;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_cta,
            this.va_nom_cta,
            this.va_tip_cta,
            this.va_uso_cta,
            this.va_mon_cta,
            this.va_est_ado});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_res_ult.EnableHeadersVisualStyles = false;
            this.dg_res_ult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dg_res_ult.Location = new System.Drawing.Point(11, 14);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(591, 170);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.TabStop = false;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // m_atr_ass
            // 
            this.m_atr_ass.Name = "m_atr_ass";
            this.m_atr_ass.Size = new System.Drawing.Size(46, 20);
            this.m_atr_ass.Text = "&Atras";
            this.m_atr_ass.Click += new System.EventHandler(this.m_atr_ass_Click);
            // 
            // m_adm003_p00
            // 
            this.m_adm003_p00.Name = "m_adm003_p00";
            this.m_adm003_p00.Size = new System.Drawing.Size(61, 20);
            this.m_adm003_p00.Text = "&Informe";
            // 
            // m_ctb004_05
            // 
            this.m_ctb004_05.Name = "m_ctb004_05";
            this.m_ctb004_05.Size = new System.Drawing.Size(66, 20);
            this.m_ctb004_05.Text = "&Consulta";
            this.m_ctb004_05.Click += new System.EventHandler(this.m_ctb004_05_Click);
            // 
            // m_ctb004_06
            // 
            this.m_ctb004_06.Name = "m_ctb004_06";
            this.m_ctb004_06.Size = new System.Drawing.Size(178, 22);
            this.m_ctb004_06.Text = "&Elimina";
            this.m_ctb004_06.Click += new System.EventHandler(this.m_ctb004_06_Click);
            // 
            // m_ctb004_04
            // 
            this.m_ctb004_04.Name = "m_ctb004_04";
            this.m_ctb004_04.Size = new System.Drawing.Size(178, 22);
            this.m_ctb004_04.Text = "&Habilita/Deshabiltia";
            this.m_ctb004_04.Click += new System.EventHandler(this.m_ctb004_04_Click);
            // 
            // m_ctb004_03
            // 
            this.m_ctb004_03.Name = "m_ctb004_03";
            this.m_ctb004_03.Size = new System.Drawing.Size(178, 22);
            this.m_ctb004_03.Text = "&Actualiza";
            this.m_ctb004_03.Click += new System.EventHandler(this.m_ctb004_03_Click);
            // 
            // mr_mod_ifi
            // 
            this.mr_mod_ifi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ctb004_03,
            this.m_ctb004_04,
            this.m_ctb004_06});
            this.mr_mod_ifi.Name = "mr_mod_ifi";
            this.mr_mod_ifi.Size = new System.Drawing.Size(66, 20);
            this.mr_mod_ifi.Text = "&Modifica";
            // 
            // m_ctb004_02
            // 
            this.m_ctb004_02.Name = "m_ctb004_02";
            this.m_ctb004_02.Size = new System.Drawing.Size(54, 20);
            this.m_ctb004_02.Text = "&Nuevo";
            this.m_ctb004_02.Click += new System.EventHandler(this.m_ctb004_02_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.mn_pri_nci);
            this.GroupBox2.Controls.Add(this.dg_res_ult);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(4, 77);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(613, 190);
            this.GroupBox2.TabIndex = 66;
            this.GroupBox2.TabStop = false;
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ctb004_02,
            this.mr_mod_ifi,
            this.m_ctb004_05,
            this.m_adm003_p00,
            this.m_atr_ass});
            this.mn_pri_nci.Location = new System.Drawing.Point(59, 92);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(301, 24);
            this.mn_pri_nci.TabIndex = 5;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // va_cod_cta
            // 
            this.va_cod_cta.HeaderText = "Codigo";
            this.va_cod_cta.Name = "va_cod_cta";
            this.va_cod_cta.ReadOnly = true;
            this.va_cod_cta.Width = 140;
            // 
            // va_nom_cta
            // 
            this.va_nom_cta.HeaderText = "Nombre";
            this.va_nom_cta.Name = "va_nom_cta";
            this.va_nom_cta.ReadOnly = true;
            this.va_nom_cta.Width = 150;
            // 
            // va_tip_cta
            // 
            this.va_tip_cta.HeaderText = "Tipo";
            this.va_tip_cta.Name = "va_tip_cta";
            this.va_tip_cta.ReadOnly = true;
            this.va_tip_cta.Width = 70;
            // 
            // va_uso_cta
            // 
            this.va_uso_cta.HeaderText = "Uso";
            this.va_uso_cta.Name = "va_uso_cta";
            this.va_uso_cta.ReadOnly = true;
            this.va_uso_cta.Width = 70;
            // 
            // va_mon_cta
            // 
            this.va_mon_cta.HeaderText = "Moneda";
            this.va_mon_cta.Name = "va_mon_cta";
            this.va_mon_cta.ReadOnly = true;
            this.va_mon_cta.Width = 70;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            this.va_est_ado.Width = 70;
            // 
            // ctb004_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(623, 316);
            this.ControlBox = false;
            this.Controls.Add(this.gb_ctr_frm);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ctb004_01";
            this.Text = "Busca Plan de Cuentas";
            this.TitleText = "Busca Plan de Cuentas";
            this.Load += new System.EventHandler(this.ctb004_01_Load);
            this.gb_ctr_frm.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.mn_pri_nci.ResumeLayout(false);
            this.mn_pri_nci.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_prm_bus;
        internal DevComponents.Editors.ComboItem codigo;
        internal DevComponents.Editors.ComboItem nombre;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_est_bus;
        internal DevComponents.Editors.ComboItem todos;
        internal DevComponents.Editors.ComboItem habilitado;
        internal DevComponents.Editors.ComboItem deshabilitado;
        internal DevComponents.DotNetBar.LabelX lb_sel_ecc;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_val_bus;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_sel_ecc;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_ass;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_p00;
        internal System.Windows.Forms.ToolStripMenuItem m_ctb004_05;
        internal System.Windows.Forms.ToolStripMenuItem m_ctb004_06;
        internal System.Windows.Forms.ToolStripMenuItem m_ctb004_04;
        internal System.Windows.Forms.ToolStripMenuItem m_ctb004_03;
        internal System.Windows.Forms.ToolStripMenuItem mr_mod_ifi;
        internal System.Windows.Forms.ToolStripMenuItem m_ctb004_02;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.MenuStrip mn_pri_nci;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tip_cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_uso_cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_mon_cta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}