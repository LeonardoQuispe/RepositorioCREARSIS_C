﻿namespace CREARSIS._5_CTB.ctb002_cap_agru_
{
    partial class ctb002_02
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
            this.tb_nom_cap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.tb_cod_cap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_cen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cb_trat_cap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Deudor = new DevComponents.Editors.ComboItem();
            this.Acreedor = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_nom_cap
            // 
            this.tb_nom_cap.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_cap.Border.Class = "TextBoxBorder";
            this.tb_nom_cap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_cap.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_cap.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_cap.Location = new System.Drawing.Point(164, 19);
            this.tb_nom_cap.MaxLength = 20;
            this.tb_nom_cap.Name = "tb_nom_cap";
            this.tb_nom_cap.PreventEnterBeep = true;
            this.tb_nom_cap.Size = new System.Drawing.Size(151, 22);
            this.tb_nom_cap.TabIndex = 30;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(231, 15);
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
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(117, 15);
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
            // LabelX1
            // 
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(6, 18);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(39, 23);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Codigo";
            // 
            // tb_cod_cap
            // 
            this.tb_cod_cap.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_cap.Border.Class = "TextBoxBorder";
            this.tb_cod_cap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_cap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_cap.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_cap.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_cap.Location = new System.Drawing.Point(51, 19);
            this.tb_cod_cap.MaxLength = 1;
            this.tb_cod_cap.Name = "tb_cod_cap";
            this.tb_cod_cap.PreventEnterBeep = true;
            this.tb_cod_cap.Size = new System.Drawing.Size(44, 22);
            this.tb_cod_cap.TabIndex = 10;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.chk_cen);
            this.GroupBox1.Controls.Add(this.labelX4);
            this.GroupBox1.Controls.Add(this.labelX2);
            this.GroupBox1.Controls.Add(this.cb_trat_cap);
            this.GroupBox1.Controls.Add(this.labelX3);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.Controls.Add(this.tb_cod_cap);
            this.GroupBox1.Controls.Add(this.tb_nom_cap);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(0, -7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(326, 93);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            // 
            // chk_cen
            // 
            // 
            // 
            // 
            this.chk_cen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_cen.CheckSignSize = new System.Drawing.Size(14, 14);
            this.chk_cen.Location = new System.Drawing.Point(295, 57);
            this.chk_cen.Name = "chk_cen";
            this.chk_cen.Size = new System.Drawing.Size(20, 20);
            this.chk_cen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_cen.TabIndex = 69;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(203, 58);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(90, 17);
            this.labelX4.TabIndex = 68;
            this.labelX4.Text = "Centro de Costo ?";
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
            this.labelX2.Location = new System.Drawing.Point(6, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(64, 23);
            this.labelX2.TabIndex = 67;
            this.labelX2.Text = "Tratamiento";
            // 
            // cb_trat_cap
            // 
            this.cb_trat_cap.DisplayMember = "Text";
            this.cb_trat_cap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_trat_cap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_trat_cap.ForeColor = System.Drawing.Color.Black;
            this.cb_trat_cap.FormattingEnabled = true;
            this.cb_trat_cap.ItemHeight = 16;
            this.cb_trat_cap.Items.AddRange(new object[] {
            this.Deudor,
            this.Acreedor});
            this.cb_trat_cap.Location = new System.Drawing.Point(72, 56);
            this.cb_trat_cap.Name = "cb_trat_cap";
            this.cb_trat_cap.Size = new System.Drawing.Size(86, 22);
            this.cb_trat_cap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_trat_cap.TabIndex = 66;
            // 
            // Deudor
            // 
            this.Deudor.Text = "Deudor";
            this.Deudor.Value = "1";
            // 
            // Acreedor
            // 
            this.Acreedor.Text = "Acreedor";
            this.Acreedor.Value = "2";
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
            this.labelX3.Location = new System.Drawing.Point(110, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(48, 23);
            this.labelX3.TabIndex = 62;
            this.labelX3.Text = "Nombre";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(0, 84);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(326, 44);
            this.GroupBox2.TabIndex = 67;
            this.GroupBox2.TabStop = false;
            // 
            // ctb002_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(327, 129);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ctb002_02";
            this.Text = "Nuevo Capitulo/Agrupador";
            this.TitleText = "Nuevo Capitulo/Agrupador";
            this.Load += new System.EventHandler(this.ctb002_02_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_cap;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_cap;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_cen;
        internal DevComponents.DotNetBar.LabelX labelX4;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_trat_cap;
        internal DevComponents.Editors.ComboItem Deudor;
        internal DevComponents.Editors.ComboItem Acreedor;
    }
}