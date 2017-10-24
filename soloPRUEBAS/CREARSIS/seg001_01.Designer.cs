namespace CREARSIS
{
    partial class seg001_01
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
            this.m_seg001_02 = new System.Windows.Forms.ToolStripMenuItem();
            this.mr_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_03 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_03a = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_04 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_06 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_05 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_per_mis = new System.Windows.Forms.ToolStripMenuItem();
            this.m_per_caj = new System.Windows.Forms.ToolStripMenuItem();
            this.m_per_ven = new System.Windows.Forms.ToolStripMenuItem();
            this.m_per_rest = new System.Windows.Forms.ToolStripMenuItem();
            this.m_per_app = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_p00 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_seg001_p01 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atr_ass = new System.Windows.Forms.ToolStripMenuItem();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.va_cod_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tip_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.GroupBox1.Location = new System.Drawing.Point(4, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(555, 81);
            this.GroupBox1.TabIndex = 65;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " ";
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
            this.cb_prm_bus.Location = new System.Drawing.Point(354, 50);
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
            this.cb_est_bus.Location = new System.Drawing.Point(448, 50);
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
            this.lb_sel_ecc.Location = new System.Drawing.Point(136, 21);
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
            this.tb_val_bus.Size = new System.Drawing.Size(332, 22);
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
            this.tb_sel_ecc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_ecc.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_ecc.Location = new System.Drawing.Point(59, 22);
            this.tb_sel_ecc.MaxLength = 15;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.PreventEnterBeep = true;
            this.tb_sel_ecc.Size = new System.Drawing.Size(71, 22);
            this.tb_sel_ecc.TabIndex = 10;
            this.tb_sel_ecc.Validating += new System.ComponentModel.CancelEventHandler(this.tb_sel_ecc_Validating);
            // 
            // LabelX1
            // 
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(15, 21);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(46, 23);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Usuario";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.mn_pri_nci);
            this.GroupBox2.Controls.Add(this.dg_res_ult);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(4, 80);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(555, 190);
            this.GroupBox2.TabIndex = 66;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " ";
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.White;
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_seg001_02,
            this.mr_mod_ifi,
            this.m_seg001_05,
            this.m_per_mis,
            this.m_seg001_p00,
            this.m_atr_ass});
            this.mn_pri_nci.Location = new System.Drawing.Point(59, 92);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(460, 24);
            this.mn_pri_nci.TabIndex = 5;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // m_seg001_02
            // 
            this.m_seg001_02.Name = "m_seg001_02";
            this.m_seg001_02.Size = new System.Drawing.Size(54, 20);
            this.m_seg001_02.Text = "&Nuevo";
            this.m_seg001_02.Click += new System.EventHandler(this.m_seg001_02_Click);
            // 
            // mr_mod_ifi
            // 
            this.mr_mod_ifi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_seg001_03,
            this.m_seg001_03a,
            this.m_seg001_04,
            this.m_seg001_06});
            this.mr_mod_ifi.Name = "mr_mod_ifi";
            this.mr_mod_ifi.Size = new System.Drawing.Size(66, 20);
            this.mr_mod_ifi.Text = "&Modifica";
            // 
            // m_seg001_03
            // 
            this.m_seg001_03.Name = "m_seg001_03";
            this.m_seg001_03.Size = new System.Drawing.Size(180, 22);
            this.m_seg001_03.Text = "&Actualiza";
            this.m_seg001_03.Click += new System.EventHandler(this.m_seg001_03_Click);
            // 
            // m_seg001_03a
            // 
            this.m_seg001_03a.Name = "m_seg001_03a";
            this.m_seg001_03a.Size = new System.Drawing.Size(180, 22);
            this.m_seg001_03a.Text = "&Inicializa contraseña";
            this.m_seg001_03a.Click += new System.EventHandler(this.m_seg001_03a_Click);
            // 
            // m_seg001_04
            // 
            this.m_seg001_04.Name = "m_seg001_04";
            this.m_seg001_04.Size = new System.Drawing.Size(180, 22);
            this.m_seg001_04.Text = "&Habilita/Deshabiltia";
            this.m_seg001_04.Click += new System.EventHandler(this.m_seg001_04_Click);
            // 
            // m_seg001_06
            // 
            this.m_seg001_06.Name = "m_seg001_06";
            this.m_seg001_06.Size = new System.Drawing.Size(180, 22);
            this.m_seg001_06.Text = "&Elimina";
            this.m_seg001_06.Click += new System.EventHandler(this.m_seg001_06_Click);
            // 
            // m_seg001_05
            // 
            this.m_seg001_05.Name = "m_seg001_05";
            this.m_seg001_05.Size = new System.Drawing.Size(66, 20);
            this.m_seg001_05.Text = "&Consulta";
            this.m_seg001_05.Click += new System.EventHandler(this.m_seg001_05_Click);
            // 
            // m_per_mis
            // 
            this.m_per_mis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_per_caj,
            this.m_per_ven,
            this.m_per_rest,
            this.m_per_app});
            this.m_per_mis.Name = "m_per_mis";
            this.m_per_mis.Size = new System.Drawing.Size(67, 20);
            this.m_per_mis.Text = "&Permisos";
            // 
            // m_per_caj
            // 
            this.m_per_caj.Name = "m_per_caj";
            this.m_per_caj.Size = new System.Drawing.Size(240, 22);
            this.m_per_caj.Text = "Sobre &caja";
            // 
            // m_per_ven
            // 
            this.m_per_ven.Name = "m_per_ven";
            this.m_per_ven.Size = new System.Drawing.Size(240, 22);
            this.m_per_ven.Text = "Sobre Plantilla de &venta";
            // 
            // m_per_rest
            // 
            this.m_per_rest.Name = "m_per_rest";
            this.m_per_rest.Size = new System.Drawing.Size(240, 22);
            this.m_per_rest.Text = "Sobre Plantilla venta &Restaurant";
            // 
            // m_per_app
            // 
            this.m_per_app.Name = "m_per_app";
            this.m_per_app.Size = new System.Drawing.Size(240, 22);
            this.m_per_app.Text = "Sobre &Apps";
            // 
            // m_seg001_p00
            // 
            this.m_seg001_p00.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_seg001_p01});
            this.m_seg001_p00.Name = "m_seg001_p00";
            this.m_seg001_p00.Size = new System.Drawing.Size(61, 20);
            this.m_seg001_p00.Text = "&Informe";
            // 
            // m_seg001_p01
            // 
            this.m_seg001_p01.Name = "m_seg001_p01";
            this.m_seg001_p01.Size = new System.Drawing.Size(219, 22);
            this.m_seg001_p01.Text = "&Usuarios             (seg001_01)";
            this.m_seg001_p01.Click += new System.EventHandler(this.m_seg001_p01_Click);
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
            this.va_cod_usr,
            this.va_nom_usr,
            this.va_tip_usr,
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
            this.dg_res_ult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dg_res_ult.Location = new System.Drawing.Point(10, 13);
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
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.TabStop = false;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_cod_usr
            // 
            this.va_cod_usr.HeaderText = "Codigo";
            this.va_cod_usr.Name = "va_cod_usr";
            this.va_cod_usr.ReadOnly = true;
            // 
            // va_nom_usr
            // 
            this.va_nom_usr.HeaderText = "Nombre";
            this.va_nom_usr.Name = "va_nom_usr";
            this.va_nom_usr.ReadOnly = true;
            this.va_nom_usr.Width = 229;
            // 
            // va_tip_usr
            // 
            this.va_tip_usr.HeaderText = "Tipo";
            this.va_tip_usr.Name = "va_tip_usr";
            this.va_tip_usr.ReadOnly = true;
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
            this.gb_ctr_frm.Location = new System.Drawing.Point(4, 267);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(555, 48);
            this.gb_ctr_frm.TabIndex = 67;
            this.gb_ctr_frm.TabStop = false;
            this.gb_ctr_frm.Text = " ";
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
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
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
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // seg001_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(562, 317);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.gb_ctr_frm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "seg001_01";
            this.Text = "Busca Usuario";
            this.Load += new System.EventHandler(this.seg001_01_Load);
            this.GroupBox1.ResumeLayout(false);
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
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_02;
        internal System.Windows.Forms.ToolStripMenuItem mr_mod_ifi;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_03;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_03a;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_04;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_06;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_05;
        internal System.Windows.Forms.ToolStripMenuItem m_per_mis;
        internal System.Windows.Forms.ToolStripMenuItem m_per_caj;
        internal System.Windows.Forms.ToolStripMenuItem m_per_ven;
        internal System.Windows.Forms.ToolStripMenuItem m_per_rest;
        internal System.Windows.Forms.ToolStripMenuItem m_per_app;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_p00;
        internal System.Windows.Forms.ToolStripMenuItem m_seg001_p01;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_ass;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_cod_usr;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nom_usr;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_tip_usr;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
    }
}