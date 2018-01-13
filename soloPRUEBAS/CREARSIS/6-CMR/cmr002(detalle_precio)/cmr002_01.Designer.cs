namespace CREARSIS._6_CMR.cmr002_detalle_precio_
{
    partial class cmr002_01
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
            this.m_cmr002_02 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_prm_bus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.codigo = new DevComponents.Editors.ComboItem();
            this.nombre = new DevComponents.Editors.ComboItem();
            this.cb_est_bus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.todos = new DevComponents.Editors.ComboItem();
            this.habilitado = new DevComponents.Editors.ComboItem();
            this.deshabilitado = new DevComponents.Editors.ComboItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_sel_ecc = new DevComponents.DotNetBar.LabelX();
            this.tb_val_bus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_sel_ecc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.m_cmr002_03 = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.mn_pri_nci = new System.Windows.Forms.MenuStrip();
            this.mr_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_cmr002_04 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_cmr002_06 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_cmr002_05 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_cmr002_p00 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atr_ass = new System.Windows.Forms.ToolStripMenuItem();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.va_cod_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_pre_cio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_sel_ecc2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lb_sel_ecc2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.mn_pri_nci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_frm.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmr002_02
            // 
            this.m_cmr002_02.Name = "m_cmr002_02";
            this.m_cmr002_02.Size = new System.Drawing.Size(54, 20);
            this.m_cmr002_02.Text = "&Nuevo";
            this.m_cmr002_02.Click += new System.EventHandler(this.m_cmr002_02_Click);
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
            this.cb_prm_bus.Location = new System.Drawing.Point(290, 45);
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
            this.cb_est_bus.Location = new System.Drawing.Point(384, 45);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(93, 22);
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
            this.GroupBox1.Location = new System.Drawing.Point(2, 43);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(487, 77);
            this.GroupBox1.TabIndex = 82;
            this.GroupBox1.TabStop = false;
            // 
            // lb_sel_ecc
            // 
            this.lb_sel_ecc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lb_sel_ecc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.lb_sel_ecc.Location = new System.Drawing.Point(166, 14);
            this.lb_sel_ecc.Name = "lb_sel_ecc";
            this.lb_sel_ecc.Size = new System.Drawing.Size(311, 23);
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
            this.tb_val_bus.Location = new System.Drawing.Point(16, 45);
            this.tb_val_bus.MaxLength = 50;
            this.tb_val_bus.Name = "tb_val_bus";
            this.tb_val_bus.PreventEnterBeep = true;
            this.tb_val_bus.Size = new System.Drawing.Size(268, 22);
            this.tb_val_bus.TabIndex = 20;
            this.tb_val_bus.ButtonCustomClick += new System.EventHandler(this.tb_val_bus_ButtonCustomClick);
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
            this.tb_sel_ecc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_ecc.Location = new System.Drawing.Point(98, 14);
            this.tb_sel_ecc.MaxLength = 2;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.PreventEnterBeep = true;
            this.tb_sel_ecc.Size = new System.Drawing.Size(62, 22);
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
            this.LabelX1.Location = new System.Drawing.Point(15, 16);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(47, 17);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Producto";
            // 
            // m_cmr002_03
            // 
            this.m_cmr002_03.Name = "m_cmr002_03";
            this.m_cmr002_03.Size = new System.Drawing.Size(178, 22);
            this.m_cmr002_03.Text = "&Actualiza";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.mn_pri_nci);
            this.GroupBox2.Controls.Add(this.dg_res_ult);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(2, 118);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(487, 190);
            this.GroupBox2.TabIndex = 83;
            this.GroupBox2.TabStop = false;
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.White;
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmr002_02,
            this.mr_mod_ifi,
            this.m_cmr002_05,
            this.m_cmr002_p00,
            this.m_atr_ass});
            this.mn_pri_nci.Location = new System.Drawing.Point(57, 92);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(301, 24);
            this.mn_pri_nci.TabIndex = 5;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // mr_mod_ifi
            // 
            this.mr_mod_ifi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmr002_03,
            this.m_cmr002_04,
            this.m_cmr002_06});
            this.mr_mod_ifi.Name = "mr_mod_ifi";
            this.mr_mod_ifi.Size = new System.Drawing.Size(66, 20);
            this.mr_mod_ifi.Text = "&Modifica";
            // 
            // m_cmr002_04
            // 
            this.m_cmr002_04.Name = "m_cmr002_04";
            this.m_cmr002_04.Size = new System.Drawing.Size(178, 22);
            this.m_cmr002_04.Text = "&Habilita/Deshabiltia";
            // 
            // m_cmr002_06
            // 
            this.m_cmr002_06.Name = "m_cmr002_06";
            this.m_cmr002_06.Size = new System.Drawing.Size(178, 22);
            this.m_cmr002_06.Text = "&Elimina";
            // 
            // m_cmr002_05
            // 
            this.m_cmr002_05.Name = "m_cmr002_05";
            this.m_cmr002_05.Size = new System.Drawing.Size(66, 20);
            this.m_cmr002_05.Text = "&Consulta";
            // 
            // m_cmr002_p00
            // 
            this.m_cmr002_p00.Name = "m_cmr002_p00";
            this.m_cmr002_p00.Size = new System.Drawing.Size(61, 20);
            this.m_cmr002_p00.Text = "&Informe";
            // 
            // m_atr_ass
            // 
            this.m_atr_ass.Name = "m_atr_ass";
            this.m_atr_ass.Size = new System.Drawing.Size(46, 20);
            this.m_atr_ass.Text = "&Atras";
            this.m_atr_ass.Click += new System.EventHandler(this.m_atr_ass_Click);
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
            this.va_cod_pro,
            this.va_nom_pro,
            this.va_pre_cio,
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
            this.dg_res_ult.Location = new System.Drawing.Point(10, 14);
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
            this.dg_res_ult.Size = new System.Drawing.Size(466, 170);
            this.dg_res_ult.TabIndex = 50;
            this.dg_res_ult.TabStop = false;
            // 
            // va_cod_pro
            // 
            this.va_cod_pro.HeaderText = "Codigo";
            this.va_cod_pro.Name = "va_cod_pro";
            this.va_cod_pro.ReadOnly = true;
            this.va_cod_pro.Width = 95;
            // 
            // va_nom_pro
            // 
            this.va_nom_pro.HeaderText = "Producto";
            this.va_nom_pro.Name = "va_nom_pro";
            this.va_nom_pro.ReadOnly = true;
            this.va_nom_pro.Width = 145;
            // 
            // va_pre_cio
            // 
            this.va_pre_cio.HeaderText = "Precio";
            this.va_pre_cio.Name = "va_pre_cio";
            this.va_pre_cio.ReadOnly = true;
            this.va_pre_cio.Width = 115;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(2, 307);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(487, 48);
            this.gb_ctr_frm.TabIndex = 84;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(376, 13);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(264, 13);
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.tb_sel_ecc2);
            this.groupBox3.Controls.Add(this.lb_sel_ecc2);
            this.groupBox3.Controls.Add(this.labelX3);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(2, -4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 48);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            // 
            // tb_sel_ecc2
            // 
            this.tb_sel_ecc2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_sel_ecc2.Border.Class = "TextBoxBorder";
            this.tb_sel_ecc2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_sel_ecc2.ButtonCustom.Symbol = "";
            this.tb_sel_ecc2.ButtonCustom.Visible = true;
            this.tb_sel_ecc2.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_ecc2.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_ecc2.Location = new System.Drawing.Point(97, 16);
            this.tb_sel_ecc2.MaxLength = 3;
            this.tb_sel_ecc2.Name = "tb_sel_ecc2";
            this.tb_sel_ecc2.PreventEnterBeep = true;
            this.tb_sel_ecc2.Size = new System.Drawing.Size(63, 22);
            this.tb_sel_ecc2.TabIndex = 46;
            this.tb_sel_ecc2.ButtonCustomClick += new System.EventHandler(this.tb_sel_ecc2_ButtonCustomClick);
            this.tb_sel_ecc2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sel_ecc2_KeyDown);
            this.tb_sel_ecc2.Validated += new System.EventHandler(this.tb_sel_ecc2_Validated);
            // 
            // lb_sel_ecc2
            // 
            this.lb_sel_ecc2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lb_sel_ecc2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_sel_ecc2.ForeColor = System.Drawing.Color.Black;
            this.lb_sel_ecc2.Location = new System.Drawing.Point(166, 16);
            this.lb_sel_ecc2.Name = "lb_sel_ecc2";
            this.lb_sel_ecc2.Size = new System.Drawing.Size(311, 23);
            this.lb_sel_ecc2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lb_sel_ecc2.TabIndex = 44;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(15, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(77, 17);
            this.labelX3.TabIndex = 45;
            this.labelX3.Text = "Lista de Precios";
            // 
            // cmr002_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(492, 358);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.gb_ctr_frm);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "cmr002_01";
            this.Text = "Busca Detalle Precio";
            this.Load += new System.EventHandler(this.cmr002_01_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.mn_pri_nci.ResumeLayout(false);
            this.mn_pri_nci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_frm.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_02;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_prm_bus;
        internal DevComponents.Editors.ComboItem codigo;
        internal DevComponents.Editors.ComboItem nombre;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_est_bus;
        internal DevComponents.Editors.ComboItem todos;
        internal DevComponents.Editors.ComboItem habilitado;
        internal DevComponents.Editors.ComboItem deshabilitado;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.LabelX lb_sel_ecc;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_val_bus;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_sel_ecc;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_03;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.MenuStrip mn_pri_nci;
        internal System.Windows.Forms.ToolStripMenuItem mr_mod_ifi;
        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_04;
        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_06;
        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_05;
        internal System.Windows.Forms.ToolStripMenuItem m_cmr002_p00;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_ass;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        public System.Windows.Forms.GroupBox groupBox3;
        internal DevComponents.DotNetBar.LabelX lb_sel_ecc2;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_sel_ecc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_pre_cio;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}