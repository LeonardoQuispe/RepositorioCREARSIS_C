﻿namespace CREARSIS._5_CTB.ctb004_plan_cuen_
{
    partial class ctb004_02
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
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_cod_cta = new System.Windows.Forms.MaskedTextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cb_uso_cta = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Modular = new DevComponents.Editors.ComboItem();
            this.Normal = new DevComponents.Editors.ComboItem();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cb_mon_cta = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Bolivianos = new DevComponents.Editors.ComboItem();
            this.Dolares = new DevComponents.Editors.ComboItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cb_tip_cta = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Matriz = new DevComponents.Editors.ComboItem();
            this.Analitica = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tb_nom_cta = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(281, 15);
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
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(167, 15);
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
            // LabelX1
            // 
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(13, 22);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(39, 23);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Codigo";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.tb_cod_cta);
            this.GroupBox1.Controls.Add(this.labelX2);
            this.GroupBox1.Controls.Add(this.cb_uso_cta);
            this.GroupBox1.Controls.Add(this.labelX5);
            this.GroupBox1.Controls.Add(this.cb_mon_cta);
            this.GroupBox1.Controls.Add(this.labelX4);
            this.GroupBox1.Controls.Add(this.cb_tip_cta);
            this.GroupBox1.Controls.Add(this.labelX3);
            this.GroupBox1.Controls.Add(this.tb_nom_cta);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(0, -6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(389, 180);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // tb_cod_cta
            // 
            this.tb_cod_cta.BackColor = System.Drawing.Color.White;
            this.tb_cod_cta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_cta.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_cta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_cta.Location = new System.Drawing.Point(56, 24);
            this.tb_cod_cta.Mask = "0.0.0.00.000";
            this.tb_cod_cta.Name = "tb_cod_cta";
            this.tb_cod_cta.PromptChar = ' ';
            this.tb_cod_cta.Size = new System.Drawing.Size(85, 22);
            this.tb_cod_cta.TabIndex = 1;
            this.tb_cod_cta.Text = "00000000";
            this.tb_cod_cta.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_cta.ValidatingType = typeof(int);
            this.tb_cod_cta.Validated += new System.EventHandler(this.tb_cod_cta_Validated);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(258, 95);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(27, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Uso";
            // 
            // cb_uso_cta
            // 
            this.cb_uso_cta.DisplayMember = "Text";
            this.cb_uso_cta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_uso_cta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_uso_cta.ForeColor = System.Drawing.Color.Black;
            this.cb_uso_cta.FormattingEnabled = true;
            this.cb_uso_cta.ItemHeight = 16;
            this.cb_uso_cta.Items.AddRange(new object[] {
            this.Modular,
            this.Normal});
            this.cb_uso_cta.Location = new System.Drawing.Point(291, 96);
            this.cb_uso_cta.Name = "cb_uso_cta";
            this.cb_uso_cta.Size = new System.Drawing.Size(85, 22);
            this.cb_uso_cta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_uso_cta.TabIndex = 7;
            // 
            // Modular
            // 
            this.Modular.Text = "Modular";
            this.Modular.Value = "1";
            // 
            // Normal
            // 
            this.Normal.Text = "Normal";
            this.Normal.Value = "2";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(7, 134);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(43, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Moneda";
            // 
            // cb_mon_cta
            // 
            this.cb_mon_cta.DisplayMember = "Text";
            this.cb_mon_cta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_mon_cta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mon_cta.ForeColor = System.Drawing.Color.Black;
            this.cb_mon_cta.FormattingEnabled = true;
            this.cb_mon_cta.ItemHeight = 16;
            this.cb_mon_cta.Items.AddRange(new object[] {
            this.Bolivianos,
            this.Dolares});
            this.cb_mon_cta.Location = new System.Drawing.Point(56, 135);
            this.cb_mon_cta.Name = "cb_mon_cta";
            this.cb_mon_cta.Size = new System.Drawing.Size(85, 22);
            this.cb_mon_cta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_mon_cta.TabIndex = 9;
            // 
            // Bolivianos
            // 
            this.Bolivianos.Text = "Bolivianos";
            this.Bolivianos.Value = "1";
            // 
            // Dolares
            // 
            this.Dolares.Text = "Dolares";
            this.Dolares.Value = "2";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(25, 96);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(25, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Tipo";
            // 
            // cb_tip_cta
            // 
            this.cb_tip_cta.DisplayMember = "Text";
            this.cb_tip_cta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tip_cta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_cta.Enabled = false;
            this.cb_tip_cta.ForeColor = System.Drawing.Color.Black;
            this.cb_tip_cta.FormattingEnabled = true;
            this.cb_tip_cta.ItemHeight = 16;
            this.cb_tip_cta.Items.AddRange(new object[] {
            this.Matriz,
            this.Analitica});
            this.cb_tip_cta.Location = new System.Drawing.Point(56, 96);
            this.cb_tip_cta.Name = "cb_tip_cta";
            this.cb_tip_cta.Size = new System.Drawing.Size(86, 22);
            this.cb_tip_cta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tip_cta.TabIndex = 5;
            // 
            // Matriz
            // 
            this.Matriz.Text = "Matriz";
            this.Matriz.Value = "1";
            // 
            // Analitica
            // 
            this.Analitica.Text = "Analitica";
            this.Analitica.Value = "2";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(9, 59);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(43, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Nombre";
            // 
            // tb_nom_cta
            // 
            this.tb_nom_cta.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_cta.Border.Class = "TextBoxBorder";
            this.tb_nom_cta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_cta.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_cta.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_cta.Location = new System.Drawing.Point(56, 59);
            this.tb_nom_cta.MaxLength = 40;
            this.tb_nom_cta.Name = "tb_nom_cta";
            this.tb_nom_cta.PreventEnterBeep = true;
            this.tb_nom_cta.Size = new System.Drawing.Size(320, 22);
            this.tb_nom_cta.TabIndex = 3;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(0, 175);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(389, 44);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            // 
            // ctb004_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(388, 221);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ctb004_02";
            this.Text = "Nuevo Plan de Cuentas";
            this.TitleText = "Nuevo Plan de Cuentas";
            this.Load += new System.EventHandler(this.ctb004_02_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_cta;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_uso_cta;
        internal DevComponents.Editors.ComboItem Modular;
        internal DevComponents.Editors.ComboItem Normal;
        internal DevComponents.DotNetBar.LabelX labelX5;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_mon_cta;
        internal DevComponents.Editors.ComboItem Bolivianos;
        internal DevComponents.Editors.ComboItem Dolares;
        internal DevComponents.DotNetBar.LabelX labelX4;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_tip_cta;
        internal DevComponents.Editors.ComboItem Matriz;
        internal DevComponents.Editors.ComboItem Analitica;
        internal System.Windows.Forms.MaskedTextBox tb_cod_cta;
    }
}