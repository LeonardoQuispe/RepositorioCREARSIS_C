namespace CREARSIS
{
    partial class inv001_03
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_cod_fap = new System.Windows.Forms.MaskedTextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cb_tip_fap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.matriz = new DevComponents.Editors.ComboItem();
            this.detalle = new DevComponents.Editors.ComboItem();
            this.sevicio = new DevComponents.Editors.ComboItem();
            this.combos = new DevComponents.Editors.ComboItem();
            this.tb_nom_fap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.tb_est_ado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.labelX14);
            this.GroupBox1.Controls.Add(this.tb_est_ado);
            this.GroupBox1.Controls.Add(this.tb_cod_fap);
            this.GroupBox1.Controls.Add(this.labelX3);
            this.GroupBox1.Controls.Add(this.cb_tip_fap);
            this.GroupBox1.Controls.Add(this.tb_nom_fap);
            this.GroupBox1.Controls.Add(this.labelX2);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(2, -5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(359, 123);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // tb_cod_fap
            // 
            this.tb_cod_fap.BackColor = System.Drawing.Color.White;
            this.tb_cod_fap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_fap.Enabled = false;
            this.tb_cod_fap.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_fap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_fap.Location = new System.Drawing.Point(69, 17);
            this.tb_cod_fap.Mask = "00-00-00";
            this.tb_cod_fap.Name = "tb_cod_fap";
            this.tb_cod_fap.PromptChar = ' ';
            this.tb_cod_fap.ReadOnly = true;
            this.tb_cod_fap.Size = new System.Drawing.Size(62, 22);
            this.tb_cod_fap.TabIndex = 1;
            this.tb_cod_fap.TabStop = false;
            this.tb_cod_fap.Text = "000000";
            this.tb_cod_fap.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(215, 17);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(30, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Tipo";
            // 
            // cb_tip_fap
            // 
            this.cb_tip_fap.DisplayMember = "Text";
            this.cb_tip_fap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tip_fap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_fap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_tip_fap.FocusHighlightColor = System.Drawing.Color.Blue;
            this.cb_tip_fap.ForeColor = System.Drawing.Color.Black;
            this.cb_tip_fap.FormattingEnabled = true;
            this.cb_tip_fap.ItemHeight = 16;
            this.cb_tip_fap.Items.AddRange(new object[] {
            this.matriz,
            this.detalle,
            this.sevicio,
            this.combos});
            this.cb_tip_fap.Location = new System.Drawing.Point(251, 17);
            this.cb_tip_fap.Name = "cb_tip_fap";
            this.cb_tip_fap.Size = new System.Drawing.Size(93, 22);
            this.cb_tip_fap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tip_fap.TabIndex = 5;
            this.cb_tip_fap.TabStop = false;
            // 
            // matriz
            // 
            this.matriz.Text = "Matriz";
            this.matriz.Value = "M";
            // 
            // detalle
            // 
            this.detalle.Text = "Detalle";
            this.detalle.Value = "D";
            // 
            // sevicio
            // 
            this.sevicio.Text = "Servicio";
            this.sevicio.Value = "S";
            // 
            // combos
            // 
            this.combos.Text = "Combo";
            this.combos.Value = "C";
            // 
            // tb_nom_fap
            // 
            this.tb_nom_fap.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_fap.Border.Class = "TextBoxBorder";
            this.tb_nom_fap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_fap.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_fap.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_fap.Location = new System.Drawing.Point(69, 51);
            this.tb_nom_fap.MaxLength = 25;
            this.tb_nom_fap.Name = "tb_nom_fap";
            this.tb_nom_fap.PreventEnterBeep = true;
            this.tb_nom_fap.Size = new System.Drawing.Size(275, 22);
            this.tb_nom_fap.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(25, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(43, 17);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Nombre";
            // 
            // LabelX1
            // 
            this.LabelX1.AutoSize = true;
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline);
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(30, 18);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(38, 17);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Codigo";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Location = new System.Drawing.Point(2, 119);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(359, 50);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(148, 15);
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
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(260, 15);
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
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX14.ForeColor = System.Drawing.Color.Black;
            this.labelX14.Location = new System.Drawing.Point(19, 88);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(45, 17);
            this.labelX14.TabIndex = 6;
            this.labelX14.Text = "Estado:";
            this.labelX14.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_est_ado.Border.Class = "TextBoxBorder";
            this.tb_est_ado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_est_ado.DisabledBackColor = System.Drawing.Color.White;
            this.tb_est_ado.Enabled = false;
            this.tb_est_ado.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tb_est_ado.ForeColor = System.Drawing.Color.Black;
            this.tb_est_ado.Location = new System.Drawing.Point(69, 86);
            this.tb_est_ado.MaxLength = 80;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.PreventEnterBeep = true;
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(85, 22);
            this.tb_est_ado.TabIndex = 7;
            this.tb_est_ado.TabStop = false;
            // 
            // inv001_03
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(362, 170);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "inv001_03";
            this.Text = "Actualiza familia de producto";
            this.TitleText = "Actualiza familia de producto";
            this.Load += new System.EventHandler(this.inv001_03_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_fap;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_tip_fap;
        internal DevComponents.Editors.ComboItem matriz;
        internal DevComponents.Editors.ComboItem detalle;
        internal DevComponents.Editors.ComboItem sevicio;
        internal DevComponents.Editors.ComboItem combos;
        internal System.Windows.Forms.MaskedTextBox tb_cod_fap;
        internal DevComponents.DotNetBar.LabelX labelX14;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_est_ado;
    }
}