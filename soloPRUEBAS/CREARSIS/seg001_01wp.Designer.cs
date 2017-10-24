namespace CREARSIS
{
    partial class seg001_01wp
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
            this.cb_est_ado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.todos = new DevComponents.Editors.ComboItem();
            this.habilitado = new DevComponents.Editors.ComboItem();
            this.deshabilitado = new DevComponents.Editors.ComboItem();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cb_est_ado);
            this.GroupBox1.Controls.Add(this.LabelX3);
            this.GroupBox1.Location = new System.Drawing.Point(6, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(329, 103);
            this.GroupBox1.TabIndex = 70;
            this.GroupBox1.TabStop = false;
            // 
            // cb_est_ado
            // 
            this.cb_est_ado.DisplayMember = "Text";
            this.cb_est_ado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_est_ado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_ado.ForeColor = System.Drawing.Color.Black;
            this.cb_est_ado.FormattingEnabled = true;
            this.cb_est_ado.ItemHeight = 16;
            this.cb_est_ado.Items.AddRange(new object[] {
            this.todos,
            this.habilitado,
            this.deshabilitado});
            this.cb_est_ado.Location = new System.Drawing.Point(126, 43);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(123, 22);
            this.cb_est_ado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_est_ado.TabIndex = 68;
            // 
            // todos
            // 
            this.todos.Text = "Todos";
            this.todos.Value = "0";
            // 
            // habilitado
            // 
            this.habilitado.Text = "Habilitados";
            this.habilitado.Value = "1";
            // 
            // deshabilitado
            // 
            this.deshabilitado.Text = "Deshabilitado";
            this.deshabilitado.Value = "2";
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
            this.LabelX3.Location = new System.Drawing.Point(80, 44);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(35, 17);
            this.LabelX3.TabIndex = 0;
            this.LabelX3.Text = "Estado";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.Location = new System.Drawing.Point(6, 102);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(329, 41);
            this.GroupBox2.TabIndex = 71;
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
            // seg001_01wp
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(340, 145);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "seg001_01wp";
            this.Text = "Usuarios";
            this.TitleText = "Usuarios";
            this.Load += new System.EventHandler(this.seg001_01wp_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cb_est_ado;
        internal DevComponents.Editors.ComboItem todos;
        internal DevComponents.Editors.ComboItem habilitado;
        internal DevComponents.Editors.ComboItem deshabilitado;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
    }
}