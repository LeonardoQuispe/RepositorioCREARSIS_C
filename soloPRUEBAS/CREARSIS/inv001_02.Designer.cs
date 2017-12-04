namespace CREARSIS
{
    partial class inv001_02
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
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cb_tip_fam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.matriz = new DevComponents.Editors.ComboItem();
            this.detalle = new DevComponents.Editors.ComboItem();
            this.sevicio = new DevComponents.Editors.ComboItem();
            this.combos = new DevComponents.Editors.ComboItem();
            this.tb_nom_fam = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.tb_cod_fap = new System.Windows.Forms.MaskedTextBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.tb_cod_fap);
            this.GroupBox1.Controls.Add(this.labelX3);
            this.GroupBox1.Controls.Add(this.cb_tip_fam);
            this.GroupBox1.Controls.Add(this.tb_nom_fam);
            this.GroupBox1.Controls.Add(this.labelX2);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(2, -5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(359, 83);
            this.GroupBox1.TabIndex = 189;
            this.GroupBox1.TabStop = false;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(214, 21);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(30, 23);
            this.labelX3.TabIndex = 46;
            this.labelX3.Text = "Tipo";
            // 
            // cb_tip_fam
            // 
            this.cb_tip_fam.DisplayMember = "Text";
            this.cb_tip_fam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tip_fam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_fam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_tip_fam.FocusHighlightColor = System.Drawing.Color.Blue;
            this.cb_tip_fam.ForeColor = System.Drawing.Color.Black;
            this.cb_tip_fam.FormattingEnabled = true;
            this.cb_tip_fam.ItemHeight = 16;
            this.cb_tip_fam.Items.AddRange(new object[] {
            this.matriz,
            this.detalle,
            this.sevicio,
            this.combos});
            this.cb_tip_fam.Location = new System.Drawing.Point(251, 21);
            this.cb_tip_fam.Name = "cb_tip_fam";
            this.cb_tip_fam.Size = new System.Drawing.Size(93, 22);
            this.cb_tip_fam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tip_fam.TabIndex = 45;
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
            // tb_nom_fam
            // 
            this.tb_nom_fam.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_fam.Border.Class = "TextBoxBorder";
            this.tb_nom_fam.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_fam.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_fam.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_fam.Location = new System.Drawing.Point(69, 51);
            this.tb_nom_fam.MaxLength = 25;
            this.tb_nom_fam.Name = "tb_nom_fam";
            this.tb_nom_fam.PreventEnterBeep = true;
            this.tb_nom_fam.Size = new System.Drawing.Size(275, 22);
            this.tb_nom_fam.TabIndex = 12;
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
            this.labelX2.Location = new System.Drawing.Point(15, 53);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(43, 17);
            this.labelX2.TabIndex = 11;
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
            this.LabelX1.Location = new System.Drawing.Point(15, 21);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(38, 17);
            this.LabelX1.TabIndex = 1;
            this.LabelX1.Text = "Codigo";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Location = new System.Drawing.Point(2, 77);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(359, 50);
            this.GroupBox2.TabIndex = 190;
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
            this.bt_ace_pta.TabIndex = 30;
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
            this.bt_can_cel.TabIndex = 40;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // tb_cod_fap
            // 
            this.tb_cod_fap.BackColor = System.Drawing.Color.White;
            this.tb_cod_fap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_fap.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_fap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_fap.Location = new System.Drawing.Point(69, 20);
            this.tb_cod_fap.Mask = "00-00-00";
            this.tb_cod_fap.Name = "tb_cod_fap";
            this.tb_cod_fap.PromptChar = ' ';
            this.tb_cod_fap.Size = new System.Drawing.Size(62, 22);
            this.tb_cod_fap.TabIndex = 48;
            this.tb_cod_fap.TabStop = false;
            this.tb_cod_fap.Text = "000000";
            this.tb_cod_fap.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // inv001_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(362, 123);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "inv001_02";
            this.Text = "Nueva familia de producto";
            this.TitleText = "Nueva familia de producto";
            this.Load += new System.EventHandler(this.inv001_02_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_fam;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_tip_fam;
        internal DevComponents.Editors.ComboItem matriz;
        internal DevComponents.Editors.ComboItem detalle;
        internal DevComponents.Editors.ComboItem sevicio;
        internal DevComponents.Editors.ComboItem combos;
        internal System.Windows.Forms.MaskedTextBox tb_cod_fap;
    }
}