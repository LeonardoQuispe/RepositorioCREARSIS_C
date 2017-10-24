namespace CREARSIS
{
    partial class adm002_02
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.dic_cb = new DevComponents.Editors.ComboItem();
            this.nov_cb = new DevComponents.Editors.ComboItem();
            this.oct_cb = new DevComponents.Editors.ComboItem();
            this.sep_cb = new DevComponents.Editors.ComboItem();
            this.ago_cb = new DevComponents.Editors.ComboItem();
            this.jul_cb = new DevComponents.Editors.ComboItem();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.jun_cb = new DevComponents.Editors.ComboItem();
            this.abr_cb = new DevComponents.Editors.ComboItem();
            this.mar_cb = new DevComponents.Editors.ComboItem();
            this.feb_cb = new DevComponents.Editors.ComboItem();
            this.ene_cb = new DevComponents.Editors.ComboItem();
            this.cb_ges_tio = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.may_cb = new DevComponents.Editors.ComboItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.tb_ges_nva = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.Location = new System.Drawing.Point(6, 140);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(329, 41);
            this.GroupBox2.TabIndex = 69;
            this.GroupBox2.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(235, 13);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 50;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(123, 13);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
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
            this.LabelX1.Location = new System.Drawing.Point(67, 95);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(71, 17);
            this.LabelX1.TabIndex = 0;
            this.LabelX1.Text = "Periodo inicial";
            // 
            // dic_cb
            // 
            this.dic_cb.Text = "Diciembre";
            this.dic_cb.Value = "12";
            // 
            // nov_cb
            // 
            this.nov_cb.Text = "Noviembre";
            this.nov_cb.Value = "11";
            // 
            // oct_cb
            // 
            this.oct_cb.Text = "Octubre";
            this.oct_cb.Value = "10";
            // 
            // sep_cb
            // 
            this.sep_cb.Text = "Septiembre";
            this.sep_cb.Value = "9";
            // 
            // ago_cb
            // 
            this.ago_cb.Text = "Agosto";
            this.ago_cb.Value = "8";
            // 
            // jul_cb
            // 
            this.jul_cb.Text = "Julio";
            this.jul_cb.Value = "7";
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
            this.LabelX3.Location = new System.Drawing.Point(98, 58);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(40, 17);
            this.LabelX3.TabIndex = 0;
            this.LabelX3.Text = "Gestión";
            // 
            // jun_cb
            // 
            this.jun_cb.Text = "Junio";
            this.jun_cb.Value = "6";
            // 
            // abr_cb
            // 
            this.abr_cb.Text = "Abril";
            this.abr_cb.Value = "4";
            // 
            // mar_cb
            // 
            this.mar_cb.Text = "Marzo";
            this.mar_cb.Value = "3";
            // 
            // feb_cb
            // 
            this.feb_cb.Text = "Febrero";
            this.feb_cb.Value = "2";
            // 
            // ene_cb
            // 
            this.ene_cb.Text = "Enero";
            this.ene_cb.Value = "1";
            // 
            // cb_ges_tio
            // 
            this.cb_ges_tio.DisplayMember = "Text";
            this.cb_ges_tio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_ges_tio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ges_tio.ForeColor = System.Drawing.Color.Black;
            this.cb_ges_tio.FormattingEnabled = true;
            this.cb_ges_tio.ItemHeight = 16;
            this.cb_ges_tio.Items.AddRange(new object[] {
            this.ene_cb,
            this.feb_cb,
            this.mar_cb,
            this.abr_cb,
            this.may_cb,
            this.jun_cb,
            this.jul_cb,
            this.ago_cb,
            this.sep_cb,
            this.oct_cb,
            this.nov_cb,
            this.dic_cb});
            this.cb_ges_tio.Location = new System.Drawing.Point(144, 90);
            this.cb_ges_tio.Name = "cb_ges_tio";
            this.cb_ges_tio.Size = new System.Drawing.Size(132, 22);
            this.cb_ges_tio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_ges_tio.TabIndex = 31;
            // 
            // may_cb
            // 
            this.may_cb.Text = "Mayo";
            this.may_cb.Value = "5";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cb_ges_tio);
            this.GroupBox1.Controls.Add(this.LabelX2);
            this.GroupBox1.Controls.Add(this.tb_ges_nva);
            this.GroupBox1.Controls.Add(this.LabelX1);
            this.GroupBox1.Controls.Add(this.LabelX3);
            this.GroupBox1.Location = new System.Drawing.Point(6, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(329, 140);
            this.GroupBox1.TabIndex = 68;
            this.GroupBox1.TabStop = false;
            // 
            // LabelX2
            // 
            this.LabelX2.AutoSize = true;
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX2.ForeColor = System.Drawing.Color.Black;
            this.LabelX2.Location = new System.Drawing.Point(22, 21);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(129, 17);
            this.LabelX2.TabIndex = 21;
            this.LabelX2.Text = "Define la primera gestion";
            // 
            // tb_ges_nva
            // 
            this.tb_ges_nva.AutoSelectAll = true;
            this.tb_ges_nva.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_ges_nva.Border.BorderColor = System.Drawing.Color.Black;
            this.tb_ges_nva.Border.Class = "TextBoxBorder";
            this.tb_ges_nva.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_ges_nva.DisabledBackColor = System.Drawing.Color.White;
            this.tb_ges_nva.ForeColor = System.Drawing.Color.Black;
            this.tb_ges_nva.Location = new System.Drawing.Point(144, 58);
            this.tb_ges_nva.MaxLength = 4;
            this.tb_ges_nva.Name = "tb_ges_nva";
            this.tb_ges_nva.PreventEnterBeep = true;
            this.tb_ges_nva.Size = new System.Drawing.Size(54, 22);
            this.tb_ges_nva.TabIndex = 20;
            // 
            // adm002_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(340, 183);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adm002_02";
            this.Text = "Crea nueva gestión";
            this.TitleText = "Crea nueva gestión";
            this.Load += new System.EventHandler(this.adm002_02_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.Editors.ComboItem dic_cb;
        internal DevComponents.Editors.ComboItem nov_cb;
        internal DevComponents.Editors.ComboItem oct_cb;
        internal DevComponents.Editors.ComboItem sep_cb;
        internal DevComponents.Editors.ComboItem ago_cb;
        internal DevComponents.Editors.ComboItem jul_cb;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal DevComponents.Editors.ComboItem jun_cb;
        internal DevComponents.Editors.ComboItem abr_cb;
        internal DevComponents.Editors.ComboItem mar_cb;
        internal DevComponents.Editors.ComboItem feb_cb;
        internal DevComponents.Editors.ComboItem ene_cb;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_ges_tio;
        internal DevComponents.Editors.ComboItem may_cb;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_ges_nva;
    }
}