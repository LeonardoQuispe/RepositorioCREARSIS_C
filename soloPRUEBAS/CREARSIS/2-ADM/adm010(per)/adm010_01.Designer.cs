﻿namespace CREARSIS._2_ADM.adm010_per_
{
    partial class adm010_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.mn_pri_nci = new System.Windows.Forms.MenuStrip();
            this.m_adm003_02 = new System.Windows.Forms.ToolStripMenuItem();
            this.mr_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_03 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_04 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_06 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_05 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm003_p00 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atr_ass = new System.Windows.Forms.ToolStripMenuItem();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.va_cod_suc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_raz_soc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nit_ced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.mn_pri_nci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_frm.SuspendLayout();
            this.SuspendLayout();
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
            this.GroupBox1.Location = new System.Drawing.Point(1, -9);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(555, 81);
            this.GroupBox1.TabIndex = 71;
            this.GroupBox1.TabStop = false;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DisplayMember = "Text";
            this.cb_prm_bus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.ForeColor = System.Drawing.Color.Black;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.ItemHeight = 20;
            this.cb_prm_bus.Items.AddRange(new object[] {
            this.codigo,
            this.nombre});
            this.cb_prm_bus.Location = new System.Drawing.Point(354, 50);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(86, 26);
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
            this.cb_est_bus.ItemHeight = 20;
            this.cb_est_bus.Items.AddRange(new object[] {
            this.todos,
            this.habilitado,
            this.deshabilitado});
            this.cb_est_bus.Location = new System.Drawing.Point(448, 50);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(93, 26);
            this.cb_est_bus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_est_bus.TabIndex = 40;
            // 
            // todos
            // 
            this.todos.Text = "Todos";
            this.todos.Value = "T";
            // 
            // habilitado
            // 
            this.habilitado.Text = "Habilitado";
            this.habilitado.Value = "H";
            // 
            // deshabilitado
            // 
            this.deshabilitado.Text = "Deshabilitado";
            this.deshabilitado.Value = "N";
            // 
            // lb_sel_ecc
            // 
            this.lb_sel_ecc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lb_sel_ecc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.lb_sel_ecc.Location = new System.Drawing.Point(137, 19);
            this.lb_sel_ecc.Name = "lb_sel_ecc";
            this.lb_sel_ecc.Size = new System.Drawing.Size(390, 23);
            this.lb_sel_ecc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lb_sel_ecc.TabIndex = 1;
            // 
            // tb_val_bus
            // 
            this.tb_val_bus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
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
            this.tb_val_bus.Size = new System.Drawing.Size(332, 26);
            this.tb_val_bus.TabIndex = 20;
            // 
            // tb_sel_ecc
            // 
            this.tb_sel_ecc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_sel_ecc.Border.Class = "TextBoxBorder";
            this.tb_sel_ecc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_sel_ecc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_ecc.Location = new System.Drawing.Point(69, 19);
            this.tb_sel_ecc.MaxLength = 2;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.PreventEnterBeep = true;
            this.tb_sel_ecc.Size = new System.Drawing.Size(62, 26);
            this.tb_sel_ecc.TabIndex = 10;
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
            this.LabelX1.Size = new System.Drawing.Size(51, 21);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Persona";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.mn_pri_nci);
            this.GroupBox2.Controls.Add(this.dg_res_ult);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(1, 72);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(555, 190);
            this.GroupBox2.TabIndex = 72;
            this.GroupBox2.TabStop = false;
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.White;
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_adm003_02,
            this.mr_mod_ifi,
            this.m_adm003_05,
            this.m_adm003_p00,
            this.m_atr_ass});
            this.mn_pri_nci.Location = new System.Drawing.Point(59, 92);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(358, 28);
            this.mn_pri_nci.TabIndex = 5;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // m_adm003_02
            // 
            this.m_adm003_02.Name = "m_adm003_02";
            this.m_adm003_02.Size = new System.Drawing.Size(64, 24);
            this.m_adm003_02.Text = "&Nuevo";
            this.m_adm003_02.Click += new System.EventHandler(this.m_adm003_02_Click);
            // 
            // mr_mod_ifi
            // 
            this.mr_mod_ifi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_adm003_03,
            this.m_adm003_04,
            this.m_adm003_06});
            this.mr_mod_ifi.Name = "mr_mod_ifi";
            this.mr_mod_ifi.Size = new System.Drawing.Size(80, 24);
            this.mr_mod_ifi.Text = "&Modifica";
            // 
            // m_adm003_03
            // 
            this.m_adm003_03.Name = "m_adm003_03";
            this.m_adm003_03.Size = new System.Drawing.Size(218, 26);
            this.m_adm003_03.Text = "&Actualiza";
            // 
            // m_adm003_04
            // 
            this.m_adm003_04.Name = "m_adm003_04";
            this.m_adm003_04.Size = new System.Drawing.Size(218, 26);
            this.m_adm003_04.Text = "&Habilita/Deshabiltia";
            // 
            // m_adm003_06
            // 
            this.m_adm003_06.Name = "m_adm003_06";
            this.m_adm003_06.Size = new System.Drawing.Size(218, 26);
            this.m_adm003_06.Text = "&Elimina";
            // 
            // m_adm003_05
            // 
            this.m_adm003_05.Name = "m_adm003_05";
            this.m_adm003_05.Size = new System.Drawing.Size(78, 24);
            this.m_adm003_05.Text = "&Consulta";
            // 
            // m_adm003_p00
            // 
            this.m_adm003_p00.Name = "m_adm003_p00";
            this.m_adm003_p00.Size = new System.Drawing.Size(73, 24);
            this.m_adm003_p00.Text = "&Informe";
            // 
            // m_atr_ass
            // 
            this.m_atr_ass.Name = "m_atr_ass";
            this.m_atr_ass.Size = new System.Drawing.Size(55, 24);
            this.m_atr_ass.Text = "&Atras";
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToOrderColumns = true;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_suc,
            this.va_raz_soc,
            this.va_nom_com,
            this.va_nit_ced,
            this.va_est_ado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_res_ult.EnableHeadersVisualStyles = false;
            this.dg_res_ult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dg_res_ult.Location = new System.Drawing.Point(11, 14);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(532, 170);
            this.dg_res_ult.TabIndex = 50;
            this.dg_res_ult.TabStop = false;
            // 
            // va_cod_suc
            // 
            this.va_cod_suc.HeaderText = "Codigo";
            this.va_cod_suc.Name = "va_cod_suc";
            this.va_cod_suc.ReadOnly = true;
            this.va_cod_suc.Width = 60;
            // 
            // va_raz_soc
            // 
            this.va_raz_soc.HeaderText = "Razón Social";
            this.va_raz_soc.Name = "va_raz_soc";
            this.va_raz_soc.ReadOnly = true;
            this.va_raz_soc.Width = 150;
            // 
            // va_nom_com
            // 
            this.va_nom_com.HeaderText = "Nombre Comercial";
            this.va_nom_com.Name = "va_nom_com";
            this.va_nom_com.ReadOnly = true;
            this.va_nom_com.Width = 150;
            // 
            // va_nit_ced
            // 
            this.va_nit_ced.HeaderText = "NIT/CI";
            this.va_nit_ced.Name = "va_nit_ced";
            this.va_nit_ced.ReadOnly = true;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            this.va_est_ado.Width = 80;
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(1, 268);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(555, 48);
            this.gb_ctr_frm.TabIndex = 73;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(449, 17);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 70;
            this.bt_can_cel.Text = "Cancelar";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(337, 17);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 60;
            this.bt_ace_pta.Text = "Aceptar";
            // 
            // adm010_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(556, 320);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.gb_ctr_frm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "adm010_01";
            this.Text = "Busca Persona";
            this.TitleText = "Busca Persona";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.mn_pri_nci.ResumeLayout(false);
            this.mn_pri_nci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_frm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.MenuStrip mn_pri_nci;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_02;
        internal System.Windows.Forms.ToolStripMenuItem mr_mod_ifi;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_03;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_04;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_06;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_05;
        internal System.Windows.Forms.ToolStripMenuItem m_adm003_p00;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_ass;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_suc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_raz_soc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_com;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nit_ced;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}