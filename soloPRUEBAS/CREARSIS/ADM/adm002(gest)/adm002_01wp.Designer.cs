namespace CREARSIS
{
    partial class adm002_01wp
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
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.cb_ges_tio = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.LabelX3.Location = new System.Drawing.Point(93, 44);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(49, 21);
            this.LabelX3.TabIndex = 0;
            this.LabelX3.Text = "Gestión";
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
            // cb_ges_tio
            // 
            this.cb_ges_tio.DisplayMember = "Text";
            this.cb_ges_tio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_ges_tio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ges_tio.ForeColor = System.Drawing.Color.Black;
            this.cb_ges_tio.FormattingEnabled = true;
            this.cb_ges_tio.ItemHeight = 20;
            this.cb_ges_tio.Location = new System.Drawing.Point(139, 43);
            this.cb_ges_tio.Name = "cb_ges_tio";
            this.cb_ges_tio.Size = new System.Drawing.Size(86, 26);
            this.cb_ges_tio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_ges_tio.TabIndex = 68;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cb_ges_tio);
            this.GroupBox1.Controls.Add(this.LabelX3);
            this.GroupBox1.Location = new System.Drawing.Point(6, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(329, 103);
            this.GroupBox1.TabIndex = 68;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.Location = new System.Drawing.Point(6, 102);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(329, 41);
            this.GroupBox2.TabIndex = 69;
            this.GroupBox2.TabStop = false;
            // 
            // adm002_01wp
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(340, 145);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adm002_01wp";
            this.Text = "Periodos de una gestión";
            this.TitleText = "Periodos de una gestión";
            this.Load += new System.EventHandler(this.adm002_01wp_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_ges_tio;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
    }
}