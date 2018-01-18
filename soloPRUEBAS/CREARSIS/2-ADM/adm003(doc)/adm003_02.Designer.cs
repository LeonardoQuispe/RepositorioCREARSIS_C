namespace CREARSIS
{
    partial class adm003_02
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
            this.tb_nom_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.tb_cod_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_des_doc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.tb_nom_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_nom_doc.Location = new System.Drawing.Point(127, 22);
            this.tb_nom_doc.MaxLength = 80;
            this.tb_nom_doc.Name = "tb_nom_doc";
            this.tb_nom_doc.PreventEnterBeep = true;
            this.tb_nom_doc.Size = new System.Drawing.Size(273, 22);
            this.tb_nom_doc.TabIndex = 30;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(316, 14);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(202, 14);
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
            this.LabelX1.Location = new System.Drawing.Point(13, 22);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(39, 23);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Codigo";
            // 
            // tb_cod_doc
            // 
            this.tb_cod_doc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_cod_doc.Border.Class = "TextBoxBorder";
            this.tb_cod_doc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_cod_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_doc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_cod_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_cod_doc.Location = new System.Drawing.Point(77, 22);
            this.tb_cod_doc.MaxLength = 3;
            this.tb_cod_doc.Name = "tb_cod_doc";
            this.tb_cod_doc.PreventEnterBeep = true;
            this.tb_cod_doc.Size = new System.Drawing.Size(44, 22);
            this.tb_cod_doc.TabIndex = 10;
            // 
            // LabelX2
            // 
            this.LabelX2.AutoSize = true;
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX2.ForeColor = System.Drawing.Color.Black;
            this.LabelX2.Location = new System.Drawing.Point(13, 51);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(59, 17);
            this.LabelX2.TabIndex = 0;
            this.LabelX2.Text = "Descripción";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.tb_des_doc);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.Controls.Add(this.tb_cod_doc);
            this.GroupBox1.Controls.Add(this.LabelX2);
            this.GroupBox1.Controls.Add(this.tb_nom_doc);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(9, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(430, 110);
            this.GroupBox1.TabIndex = 64;
            this.GroupBox1.TabStop = false;
            // 
            // tb_des_doc
            // 
            this.tb_des_doc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_des_doc.Border.Class = "TextBoxBorder";
            this.tb_des_doc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_des_doc.DisabledBackColor = System.Drawing.Color.White;
            this.tb_des_doc.ForeColor = System.Drawing.Color.Black;
            this.tb_des_doc.Location = new System.Drawing.Point(77, 50);
            this.tb_des_doc.MaxLength = 120;
            this.tb_des_doc.Name = "tb_des_doc";
            this.tb_des_doc.PreventEnterBeep = true;
            this.tb_des_doc.Size = new System.Drawing.Size(323, 22);
            this.tb_des_doc.TabIndex = 61;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(9, 113);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(430, 44);
            this.GroupBox2.TabIndex = 65;
            this.GroupBox2.TabStop = false;
            // 
            // adm003_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(449, 163);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adm003_02";
            this.Text = "Nuevo documento";
            this.TitleText = "Nuevo documento";
            this.Load += new System.EventHandler(this.adm003_02_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.TextBoxX tb_nom_doc;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_cod_doc;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_des_doc;
        internal System.Windows.Forms.GroupBox GroupBox2;
    }
}