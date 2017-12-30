namespace CREARSIS
{
    partial class adm005_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.cb_ges_tio = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tb_cod_ges = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_nro_tal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_sel_ecc = new DevComponents.DotNetBar.LabelX();
            this.cb_prm_bus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cod_doc = new DevComponents.Editors.ComboItem();
            this.nom_doc = new DevComponents.Editors.ComboItem();
            this.tb_val_bus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_cod_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.mn_pri_nci = new System.Windows.Forms.MenuStrip();
            this.m_adm005_02 = new System.Windows.Forms.ToolStripMenuItem();
            this.mr_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm005_03 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm005_06 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm005_05 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm005_p00 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_adm005_p01 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atr_ass = new System.Windows.Forms.ToolStripMenuItem();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.va_cod_ges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cod_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_tal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_frm.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.mn_pri_nci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.White;
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(5, 345);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Size = new System.Drawing.Size(658, 48);
            this.gb_ctr_frm.TabIndex = 33;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(544, 17);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 80;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(432, 17);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 70;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // cb_ges_tio
            // 
            this.cb_ges_tio.DisplayMember = "Text";
            this.cb_ges_tio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_ges_tio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ges_tio.ForeColor = System.Drawing.Color.Black;
            this.cb_ges_tio.FormattingEnabled = true;
            this.cb_ges_tio.ItemHeight = 20;
            this.cb_ges_tio.Location = new System.Drawing.Point(559, 50);
            this.cb_ges_tio.Name = "cb_ges_tio";
            this.cb_ges_tio.Size = new System.Drawing.Size(86, 26);
            this.cb_ges_tio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_ges_tio.TabIndex = 60;
            // 
            // tb_cod_ges
            // 
            this.tb_cod_ges.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_ges.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_cod_ges.Border.Class = "TextBoxBorder";
            this.tb_cod_ges.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_ges.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_ges.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_ges.Location = new System.Drawing.Point(157, 19);
            this.tb_cod_ges.MaxLength = 4;
            this.tb_cod_ges.Name = "tb_cod_ges";
            this.tb_cod_ges.PreventEnterBeep = true;
            this.tb_cod_ges.Size = new System.Drawing.Size(44, 26);
            this.tb_cod_ges.TabIndex = 30;
            this.tb_cod_ges.TextChanged += new System.EventHandler(this.tb_cod_ges_TextChanged);
            this.tb_cod_ges.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nro_tal_Validating);
            // 
            // tb_nro_tal
            // 
            this.tb_nro_tal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nro_tal.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_nro_tal.Border.Class = "TextBoxBorder";
            this.tb_nro_tal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nro_tal.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nro_tal.ForeColor = System.Drawing.Color.Black;
            this.tb_nro_tal.Location = new System.Drawing.Point(80, 19);
            this.tb_nro_tal.MaxLength = 2;
            this.tb_nro_tal.Name = "tb_nro_tal";
            this.tb_nro_tal.PreventEnterBeep = true;
            this.tb_nro_tal.Size = new System.Drawing.Size(28, 26);
            this.tb_nro_tal.TabIndex = 10;
            this.tb_nro_tal.TextChanged += new System.EventHandler(this.tb_nro_tal_TextChanged);
            this.tb_nro_tal.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nro_tal_Validating);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.lb_sel_ecc);
            this.GroupBox1.Controls.Add(this.cb_ges_tio);
            this.GroupBox1.Controls.Add(this.tb_cod_ges);
            this.GroupBox1.Controls.Add(this.tb_nro_tal);
            this.GroupBox1.Controls.Add(this.cb_prm_bus);
            this.GroupBox1.Controls.Add(this.tb_val_bus);
            this.GroupBox1.Controls.Add(this.tb_cod_doc);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(5, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(658, 81);
            this.GroupBox1.TabIndex = 31;
            this.GroupBox1.TabStop = false;
            // 
            // lb_sel_ecc
            // 
            this.lb_sel_ecc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lb_sel_ecc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_sel_ecc.Location = new System.Drawing.Point(208, 19);
            this.lb_sel_ecc.Name = "lb_sel_ecc";
            this.lb_sel_ecc.Size = new System.Drawing.Size(412, 23);
            this.lb_sel_ecc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lb_sel_ecc.TabIndex = 61;
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
            this.cod_doc,
            this.nom_doc});
            this.cb_prm_bus.Location = new System.Drawing.Point(442, 50);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(98, 26);
            this.cb_prm_bus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_prm_bus.TabIndex = 50;
            // 
            // cod_doc
            // 
            this.cod_doc.Text = "Cod. Doc.";
            this.cod_doc.Value = "1";
            // 
            // nom_doc
            // 
            this.nom_doc.Text = "Documento";
            this.nom_doc.Value = "2";
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
            this.tb_val_bus.Size = new System.Drawing.Size(418, 26);
            this.tb_val_bus.TabIndex = 40;
            this.tb_val_bus.ButtonCustomClick += new System.EventHandler(this.tb_val_bus_ButtonCustomClick);
            this.tb_val_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_val_bus_KeyDown);
            // 
            // tb_cod_doc
            // 
            this.tb_cod_doc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_doc.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_cod_doc.Border.Class = "TextBoxBorder";
            this.tb_cod_doc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_doc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_doc.Location = new System.Drawing.Point(113, 19);
            this.tb_cod_doc.MaxLength = 3;
            this.tb_cod_doc.Name = "tb_cod_doc";
            this.tb_cod_doc.PreventEnterBeep = true;
            this.tb_cod_doc.Size = new System.Drawing.Size(36, 26);
            this.tb_cod_doc.TabIndex = 20;
            this.tb_cod_doc.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nro_tal_Validating);
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
            this.LabelX1.Size = new System.Drawing.Size(72, 21);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Numerador";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.mn_pri_nci);
            this.GroupBox2.Controls.Add(this.dg_res_ult);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(5, 81);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(658, 266);
            this.GroupBox2.TabIndex = 32;
            this.GroupBox2.TabStop = false;
            // 
            // mn_pri_nci
            // 
            this.mn_pri_nci.BackColor = System.Drawing.Color.White;
            this.mn_pri_nci.Dock = System.Windows.Forms.DockStyle.None;
            this.mn_pri_nci.ForeColor = System.Drawing.Color.Black;
            this.mn_pri_nci.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_pri_nci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_adm005_02,
            this.mr_mod_ifi,
            this.m_adm005_05,
            this.m_adm005_p00,
            this.m_atr_ass});
            this.mn_pri_nci.Location = new System.Drawing.Point(59, 92);
            this.mn_pri_nci.Name = "mn_pri_nci";
            this.mn_pri_nci.Size = new System.Drawing.Size(358, 28);
            this.mn_pri_nci.TabIndex = 5;
            this.mn_pri_nci.Text = "MenuStrip1";
            this.mn_pri_nci.Visible = false;
            // 
            // m_adm005_02
            // 
            this.m_adm005_02.Name = "m_adm005_02";
            this.m_adm005_02.Size = new System.Drawing.Size(64, 24);
            this.m_adm005_02.Text = "&Nuevo";
            this.m_adm005_02.Click += new System.EventHandler(this.m_adm005_02_Click);
            // 
            // mr_mod_ifi
            // 
            this.mr_mod_ifi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_adm005_03,
            this.m_adm005_06});
            this.mr_mod_ifi.Name = "mr_mod_ifi";
            this.mr_mod_ifi.Size = new System.Drawing.Size(80, 24);
            this.mr_mod_ifi.Text = "&Modifica";
            // 
            // m_adm005_03
            // 
            this.m_adm005_03.Name = "m_adm005_03";
            this.m_adm005_03.Size = new System.Drawing.Size(181, 26);
            this.m_adm005_03.Text = "&Actualiza";
            this.m_adm005_03.Click += new System.EventHandler(this.m_adm005_03_Click);
            // 
            // m_adm005_06
            // 
            this.m_adm005_06.Name = "m_adm005_06";
            this.m_adm005_06.Size = new System.Drawing.Size(181, 26);
            this.m_adm005_06.Text = "&Elimina";
            this.m_adm005_06.Click += new System.EventHandler(this.m_adm005_06_Click);
            // 
            // m_adm005_05
            // 
            this.m_adm005_05.Name = "m_adm005_05";
            this.m_adm005_05.Size = new System.Drawing.Size(78, 24);
            this.m_adm005_05.Text = "&Consulta";
            this.m_adm005_05.Click += new System.EventHandler(this.m_adm005_05_Click);
            // 
            // m_adm005_p00
            // 
            this.m_adm005_p00.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_adm005_p01});
            this.m_adm005_p00.Name = "m_adm005_p00";
            this.m_adm005_p00.Size = new System.Drawing.Size(73, 24);
            this.m_adm005_p00.Text = "&Informe";
            // 
            // m_adm005_p01
            // 
            this.m_adm005_p01.Name = "m_adm005_p01";
            this.m_adm005_p01.Size = new System.Drawing.Size(309, 26);
            this.m_adm005_p01.Text = "&Numeraciones           (adm005_01)";
            this.m_adm005_p01.Click += new System.EventHandler(this.m_adm005_p01_Click);
            // 
            // m_atr_ass
            // 
            this.m_atr_ass.Name = "m_atr_ass";
            this.m_atr_ass.Size = new System.Drawing.Size(55, 24);
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
            this.va_cod_ges,
            this.va_cod_doc,
            this.va_nom_doc,
            this.va_nro_tal,
            this.va_nom_tal,
            this.va_nro_ini,
            this.va_nro_fin,
            this.va_fec_ini,
            this.va_fec_fin});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.EnableHeadersVisualStyles = false;
            this.dg_res_ult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dg_res_ult.Location = new System.Drawing.Point(7, 10);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(645, 247);
            this.dg_res_ult.TabIndex = 6;
            this.dg_res_ult.TabStop = false;
            // 
            // va_cod_ges
            // 
            this.va_cod_ges.HeaderText = "Gestión";
            this.va_cod_ges.Name = "va_cod_ges";
            this.va_cod_ges.ReadOnly = true;
            this.va_cod_ges.Width = 50;
            // 
            // va_cod_doc
            // 
            this.va_cod_doc.HeaderText = "Cod. Doc.";
            this.va_cod_doc.Name = "va_cod_doc";
            this.va_cod_doc.ReadOnly = true;
            this.va_cod_doc.Width = 35;
            // 
            // va_nom_doc
            // 
            this.va_nom_doc.HeaderText = "Documento";
            this.va_nom_doc.Name = "va_nom_doc";
            this.va_nom_doc.ReadOnly = true;
            this.va_nom_doc.Width = 140;
            // 
            // va_nro_tal
            // 
            this.va_nro_tal.HeaderText = "Nro.";
            this.va_nro_tal.Name = "va_nro_tal";
            this.va_nro_tal.ReadOnly = true;
            this.va_nro_tal.Width = 30;
            // 
            // va_nom_tal
            // 
            this.va_nom_tal.HeaderText = "Talonario";
            this.va_nom_tal.Name = "va_nom_tal";
            this.va_nom_tal.ReadOnly = true;
            this.va_nom_tal.Width = 150;
            // 
            // va_nro_ini
            // 
            this.va_nro_ini.HeaderText = "Nro. Inicial";
            this.va_nro_ini.Name = "va_nro_ini";
            this.va_nro_ini.ReadOnly = true;
            this.va_nro_ini.Width = 45;
            // 
            // va_nro_fin
            // 
            this.va_nro_fin.HeaderText = "Nro. Final";
            this.va_nro_fin.Name = "va_nro_fin";
            this.va_nro_fin.ReadOnly = true;
            this.va_nro_fin.Width = 45;
            // 
            // va_fec_ini
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.va_fec_ini.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_fec_ini.HeaderText = "Fecha Inicial";
            this.va_fec_ini.Name = "va_fec_ini";
            this.va_fec_ini.ReadOnly = true;
            this.va_fec_ini.Width = 70;
            // 
            // va_fec_fin
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.va_fec_fin.DefaultCellStyle = dataGridViewCellStyle3;
            this.va_fec_fin.HeaderText = "Fecha Final";
            this.va_fec_fin.Name = "va_fec_fin";
            this.va_fec_fin.ReadOnly = true;
            this.va_fec_fin.Width = 70;
            // 
            // adm005_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 394);
            this.ControlBox = false;
            this.Controls.Add(this.gb_ctr_frm);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adm005_01";
            this.Text = "Busca Numeraciones";
            this.TitleText = "Busca Numeraciones";
            this.Load += new System.EventHandler(this.adm005_01_Load);
            this.gb_ctr_frm.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.mn_pri_nci.ResumeLayout(false);
            this.mn_pri_nci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_ges_tio;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_ges;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nro_tal;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_prm_bus;
        internal DevComponents.Editors.ComboItem cod_doc;
        internal DevComponents.Editors.ComboItem nom_doc;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_val_bus;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_doc;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.MenuStrip mn_pri_nci;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_02;
        internal System.Windows.Forms.ToolStripMenuItem mr_mod_ifi;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_03;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_06;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_05;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_p00;
        internal System.Windows.Forms.ToolStripMenuItem m_adm005_p01;
        internal System.Windows.Forms.ToolStripMenuItem m_atr_ass;
        internal DevComponents.DotNetBar.LabelX lb_sel_ecc;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_cod_ges;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_cod_doc;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nom_doc;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nro_tal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nro_ini;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_nro_fin;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_fec_ini;
        internal System.Windows.Forms.DataGridViewTextBoxColumn va_fec_fin;
    }
}