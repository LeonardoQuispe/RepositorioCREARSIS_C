namespace CREARSIS
{
    partial class adm005_05
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
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_con_tad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX7 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.tb_fec_fin = new System.Windows.Forms.DateTimePicker();
            this.tb_fec_ini = new System.Windows.Forms.DateTimePicker();
            this.tb_nro_fin = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX4 = new DevComponents.DotNetBar.LabelX();
            this.tb_nro_ini = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.tb_cod_ges = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX12 = new DevComponents.DotNetBar.LabelX();
            this.tb_nom_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_nom_tal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_nro_tal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.tb_cod_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(393, 15);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 90;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.White;
            this.GroupBox3.Controls.Add(this.bt_can_cel);
            this.GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.GroupBox3.Location = new System.Drawing.Point(3, 193);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(516, 56);
            this.GroupBox3.TabIndex = 6;
            this.GroupBox3.TabStop = false;
            // 
            // tb_con_tad
            // 
            this.tb_con_tad.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_con_tad.Border.Class = "TextBoxBorder";
            this.tb_con_tad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_con_tad.DisabledBackColor = System.Drawing.Color.White;
            this.tb_con_tad.Enabled = false;
            this.tb_con_tad.ForeColor = System.Drawing.Color.Black;
            this.tb_con_tad.Location = new System.Drawing.Point(77, 65);
            this.tb_con_tad.MaxLength = 6;
            this.tb_con_tad.Name = "tb_con_tad";
            this.tb_con_tad.PreventEnterBeep = true;
            this.tb_con_tad.ReadOnly = true;
            this.tb_con_tad.Size = new System.Drawing.Size(51, 22);
            this.tb_con_tad.TabIndex = 55;
            this.tb_con_tad.TabStop = false;
            // 
            // LabelX7
            // 
            this.LabelX7.AutoSize = true;
            this.LabelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX7.ForeColor = System.Drawing.Color.Black;
            this.LabelX7.Location = new System.Drawing.Point(23, 68);
            this.LabelX7.Name = "LabelX7";
            this.LabelX7.Size = new System.Drawing.Size(48, 17);
            this.LabelX7.TabIndex = 92;
            this.LabelX7.Text = "Contador";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.tb_con_tad);
            this.GroupBox2.Controls.Add(this.LabelX7);
            this.GroupBox2.Controls.Add(this.LabelX6);
            this.GroupBox2.Controls.Add(this.LabelX5);
            this.GroupBox2.Controls.Add(this.tb_fec_fin);
            this.GroupBox2.Controls.Add(this.tb_fec_ini);
            this.GroupBox2.Controls.Add(this.tb_nro_fin);
            this.GroupBox2.Controls.Add(this.LabelX4);
            this.GroupBox2.Controls.Add(this.tb_nro_ini);
            this.GroupBox2.Controls.Add(this.LabelX3);
            this.GroupBox2.Controls.Add(this.tb_cod_ges);
            this.GroupBox2.Controls.Add(this.LabelX12);
            this.GroupBox2.Location = new System.Drawing.Point(3, 82);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(516, 110);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            // 
            // LabelX6
            // 
            this.LabelX6.AutoSize = true;
            this.LabelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX6.ForeColor = System.Drawing.Color.Black;
            this.LabelX6.Location = new System.Drawing.Point(336, 68);
            this.LabelX6.Name = "LabelX6";
            this.LabelX6.Size = new System.Drawing.Size(54, 17);
            this.LabelX6.TabIndex = 90;
            this.LabelX6.Text = "Fecha final";
            // 
            // LabelX5
            // 
            this.LabelX5.AutoSize = true;
            this.LabelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX5.ForeColor = System.Drawing.Color.Black;
            this.LabelX5.Location = new System.Drawing.Point(157, 68);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(61, 17);
            this.LabelX5.TabIndex = 90;
            this.LabelX5.Text = "Fecha inicial";
            // 
            // tb_fec_fin
            // 
            this.tb_fec_fin.Enabled = false;
            this.tb_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_fin.Location = new System.Drawing.Point(403, 65);
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(97, 22);
            this.tb_fec_fin.TabIndex = 70;
            this.tb_fec_fin.TabStop = false;
            // 
            // tb_fec_ini
            // 
            this.tb_fec_ini.Enabled = false;
            this.tb_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_ini.Location = new System.Drawing.Point(224, 65);
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(97, 22);
            this.tb_fec_ini.TabIndex = 60;
            this.tb_fec_ini.TabStop = false;
            // 
            // tb_nro_fin
            // 
            this.tb_nro_fin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nro_fin.Border.Class = "TextBoxBorder";
            this.tb_nro_fin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nro_fin.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nro_fin.Enabled = false;
            this.tb_nro_fin.ForeColor = System.Drawing.Color.Black;
            this.tb_nro_fin.Location = new System.Drawing.Point(446, 21);
            this.tb_nro_fin.MaxLength = 6;
            this.tb_nro_fin.Name = "tb_nro_fin";
            this.tb_nro_fin.PreventEnterBeep = true;
            this.tb_nro_fin.ReadOnly = true;
            this.tb_nro_fin.Size = new System.Drawing.Size(54, 22);
            this.tb_nro_fin.TabIndex = 50;
            this.tb_nro_fin.TabStop = false;
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
            this.LabelX4.Location = new System.Drawing.Point(374, 23);
            this.LabelX4.Name = "LabelX4";
            this.LabelX4.Size = new System.Drawing.Size(66, 17);
            this.LabelX4.TabIndex = 88;
            this.LabelX4.Text = "Número final";
            // 
            // tb_nro_ini
            // 
            this.tb_nro_ini.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nro_ini.Border.Class = "TextBoxBorder";
            this.tb_nro_ini.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nro_ini.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nro_ini.Enabled = false;
            this.tb_nro_ini.ForeColor = System.Drawing.Color.Black;
            this.tb_nro_ini.Location = new System.Drawing.Point(267, 21);
            this.tb_nro_ini.MaxLength = 6;
            this.tb_nro_ini.Name = "tb_nro_ini";
            this.tb_nro_ini.PreventEnterBeep = true;
            this.tb_nro_ini.ReadOnly = true;
            this.tb_nro_ini.Size = new System.Drawing.Size(54, 22);
            this.tb_nro_ini.TabIndex = 40;
            this.tb_nro_ini.TabStop = false;
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
            this.LabelX3.Location = new System.Drawing.Point(188, 23);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(73, 17);
            this.LabelX3.TabIndex = 86;
            this.LabelX3.Text = "Número inicial";
            // 
            // tb_cod_ges
            // 
            this.tb_cod_ges.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_ges.Border.Class = "TextBoxBorder";
            this.tb_cod_ges.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_ges.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_ges.Enabled = false;
            this.tb_cod_ges.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_ges.Location = new System.Drawing.Point(77, 21);
            this.tb_cod_ges.MaxLength = 4;
            this.tb_cod_ges.Name = "tb_cod_ges";
            this.tb_cod_ges.PreventEnterBeep = true;
            this.tb_cod_ges.ReadOnly = true;
            this.tb_cod_ges.Size = new System.Drawing.Size(51, 22);
            this.tb_cod_ges.TabIndex = 30;
            this.tb_cod_ges.TabStop = false;
            // 
            // LabelX12
            // 
            this.LabelX12.AutoSize = true;
            this.LabelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX12.ForeColor = System.Drawing.Color.Black;
            this.LabelX12.Location = new System.Drawing.Point(31, 23);
            this.LabelX12.Name = "LabelX12";
            this.LabelX12.Size = new System.Drawing.Size(40, 17);
            this.LabelX12.TabIndex = 84;
            this.LabelX12.Text = "Gestión";
            // 
            // tb_nom_doc
            // 
            this.tb_nom_doc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_doc.Border.Class = "TextBoxBorder";
            this.tb_nom_doc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_doc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_doc.Enabled = false;
            this.tb_nom_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_doc.Location = new System.Drawing.Point(147, 22);
            this.tb_nom_doc.MaxLength = 120;
            this.tb_nom_doc.Name = "tb_nom_doc";
            this.tb_nom_doc.PreventEnterBeep = true;
            this.tb_nom_doc.ReadOnly = true;
            this.tb_nom_doc.Size = new System.Drawing.Size(353, 22);
            this.tb_nom_doc.TabIndex = 30;
            this.tb_nom_doc.TabStop = false;
            // 
            // tb_nom_tal
            // 
            this.tb_nom_tal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nom_tal.Border.Class = "TextBoxBorder";
            this.tb_nom_tal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nom_tal.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nom_tal.Enabled = false;
            this.tb_nom_tal.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_tal.Location = new System.Drawing.Point(147, 52);
            this.tb_nom_tal.MaxLength = 120;
            this.tb_nom_tal.Name = "tb_nom_tal";
            this.tb_nom_tal.PreventEnterBeep = true;
            this.tb_nom_tal.ReadOnly = true;
            this.tb_nom_tal.Size = new System.Drawing.Size(353, 22);
            this.tb_nom_tal.TabIndex = 30;
            this.tb_nom_tal.TabStop = false;
            // 
            // tb_nro_tal
            // 
            this.tb_nro_tal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_nro_tal.Border.Class = "TextBoxBorder";
            this.tb_nro_tal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nro_tal.ButtonCustom.Enabled = false;
            this.tb_nro_tal.ButtonCustom.Symbol = "";
            this.tb_nro_tal.ButtonCustom.Visible = true;
            this.tb_nro_tal.DisabledBackColor = System.Drawing.Color.White;
            this.tb_nro_tal.Enabled = false;
            this.tb_nro_tal.ForeColor = System.Drawing.Color.Black;
            this.tb_nro_tal.Location = new System.Drawing.Point(77, 52);
            this.tb_nro_tal.MaxLength = 2;
            this.tb_nro_tal.Name = "tb_nro_tal";
            this.tb_nro_tal.PreventEnterBeep = true;
            this.tb_nro_tal.ReadOnly = true;
            this.tb_nro_tal.Size = new System.Drawing.Size(63, 22);
            this.tb_nro_tal.TabIndex = 20;
            this.tb_nro_tal.TabStop = false;
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
            this.LabelX1.Location = new System.Drawing.Point(13, 22);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(60, 17);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Documento";
            // 
            // tb_cod_doc
            // 
            this.tb_cod_doc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_doc.Border.Class = "TextBoxBorder";
            this.tb_cod_doc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_doc.ButtonCustom.Enabled = false;
            this.tb_cod_doc.ButtonCustom.Symbol = "";
            this.tb_cod_doc.ButtonCustom.Visible = true;
            this.tb_cod_doc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_doc.Enabled = false;
            this.tb_cod_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_doc.Location = new System.Drawing.Point(77, 22);
            this.tb_cod_doc.MaxLength = 3;
            this.tb_cod_doc.Name = "tb_cod_doc";
            this.tb_cod_doc.PreventEnterBeep = true;
            this.tb_cod_doc.ReadOnly = true;
            this.tb_cod_doc.Size = new System.Drawing.Size(63, 22);
            this.tb_cod_doc.TabIndex = 10;
            this.tb_cod_doc.TabStop = false;
            // 
            // LabelX2
            // 
            this.LabelX2.AutoSize = true;
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX2.ForeColor = System.Drawing.Color.Black;
            this.LabelX2.Location = new System.Drawing.Point(25, 52);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(48, 17);
            this.LabelX2.TabIndex = 0;
            this.LabelX2.Text = "Talonario";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.tb_nom_tal);
            this.GroupBox1.Controls.Add(this.tb_nro_tal);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.Controls.Add(this.tb_cod_doc);
            this.GroupBox1.Controls.Add(this.LabelX2);
            this.GroupBox1.Controls.Add(this.tb_nom_doc);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(3, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(516, 87);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            // 
            // adm005_05
            // 
            this.AcceptButton = this.bt_can_cel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(523, 254);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adm005_05";
            this.Text = "Consulta numeración";
            this.TitleText = "Consulta numeración";
            this.Load += new System.EventHandler(this.adm005_05_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_con_tad;
        internal DevComponents.DotNetBar.LabelX LabelX7;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.LabelX LabelX6;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal System.Windows.Forms.DateTimePicker tb_fec_fin;
        internal System.Windows.Forms.DateTimePicker tb_fec_ini;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nro_fin;
        internal DevComponents.DotNetBar.LabelX LabelX4;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nro_ini;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_ges;
        internal DevComponents.DotNetBar.LabelX LabelX12;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_doc;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_tal;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nro_tal;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_doc;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal System.Windows.Forms.GroupBox GroupBox1;
    }
}