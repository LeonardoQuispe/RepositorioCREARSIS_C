namespace CREARSIS
{
    partial class cnx002
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
            this.lb_nom_usr = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.tb_sel_usr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_pas_usr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_usr_usr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GroupBox1.Controls.Add(this.lb_nom_usr);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.tb_sel_usr);
            this.GroupBox1.Controls.Add(this.tb_pas_usr);
            this.GroupBox1.Controls.Add(this.tb_usr_usr);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(8, -1);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Size = new System.Drawing.Size(271, 160);
            this.GroupBox1.TabIndex = 59;
            this.GroupBox1.TabStop = false;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.lb_nom_usr.ForeColor = System.Drawing.Color.Black;
            this.lb_nom_usr.Location = new System.Drawing.Point(98, 124);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(0, 13);
            this.lb_nom_usr.TabIndex = 31;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(7, 30);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Adminsitrador";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(40, 100);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 13);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Usuario";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(21, 64);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Contraseña";
            // 
            // tb_sel_usr
            // 
            this.tb_sel_usr.AutoSelectAll = true;
            this.tb_sel_usr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_sel_usr.Border.Class = "TextBoxBorder";
            this.tb_sel_usr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_sel_usr.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.CtrlUp;
            this.tb_sel_usr.ButtonCustom.Symbol = "";
            this.tb_sel_usr.ButtonCustom.Visible = true;
            this.tb_sel_usr.DisabledBackColor = System.Drawing.Color.White;
            this.tb_sel_usr.ForeColor = System.Drawing.Color.Black;
            this.tb_sel_usr.Location = new System.Drawing.Point(101, 93);
            this.tb_sel_usr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_sel_usr.Name = "tb_sel_usr";
            this.tb_sel_usr.PreventEnterBeep = true;
            this.tb_sel_usr.Size = new System.Drawing.Size(164, 22);
            this.tb_sel_usr.TabIndex = 30;
            this.tb_sel_usr.ButtonCustomClick += new System.EventHandler(this.tb_sel_usr_ButtonCustomClick);
            this.tb_sel_usr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_sel_usr_KeyUp);
            this.tb_sel_usr.Validating += new System.ComponentModel.CancelEventHandler(this.tb_sel_usr_Validating);
            // 
            // tb_pas_usr
            // 
            this.tb_pas_usr.AutoSelectAll = true;
            this.tb_pas_usr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_pas_usr.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_pas_usr.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_pas_usr.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_pas_usr.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.tb_pas_usr.Border.Class = "TextBoxBorder";
            this.tb_pas_usr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_pas_usr.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.CtrlM;
            this.tb_pas_usr.ButtonCustom.Symbol = "";
            this.tb_pas_usr.DisabledBackColor = System.Drawing.Color.White;
            this.tb_pas_usr.ForeColor = System.Drawing.Color.Black;
            this.tb_pas_usr.Location = new System.Drawing.Point(101, 62);
            this.tb_pas_usr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_pas_usr.MaxLength = 20;
            this.tb_pas_usr.Name = "tb_pas_usr";
            this.tb_pas_usr.PasswordChar = '*';
            this.tb_pas_usr.PreventEnterBeep = true;
            this.tb_pas_usr.Size = new System.Drawing.Size(164, 22);
            this.tb_pas_usr.TabIndex = 20;
            this.tb_pas_usr.UseSystemPasswordChar = true;
            this.tb_pas_usr.WatermarkText = "**************";
            // 
            // tb_usr_usr
            // 
            this.tb_usr_usr.AutoSelectAll = true;
            this.tb_usr_usr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_usr_usr.Border.Class = "TextBoxBorder";
            this.tb_usr_usr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_usr_usr.DisabledBackColor = System.Drawing.Color.White;
            this.tb_usr_usr.ForeColor = System.Drawing.Color.Black;
            this.tb_usr_usr.Location = new System.Drawing.Point(101, 27);
            this.tb_usr_usr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_usr_usr.MaxLength = 15;
            this.tb_usr_usr.Name = "tb_usr_usr";
            this.tb_usr_usr.PreventEnterBeep = true;
            this.tb_usr_usr.Size = new System.Drawing.Size(164, 22);
            this.tb_usr_usr.TabIndex = 10;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GroupBox2.Controls.Add(this.bt_can_cel);
            this.GroupBox2.Controls.Add(this.bt_ace_pta);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(8, 155);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Size = new System.Drawing.Size(271, 56);
            this.GroupBox2.TabIndex = 60;
            this.GroupBox2.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(169, 21);
            this.bt_can_cel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 27);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 72;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(57, 21);
            this.bt_ace_pta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 27);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 71;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // cnx002
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(290, 216);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "cnx002";
            this.Text = "Autenticación personalización menú";
            this.TitleText = "Autenticación personalización menú";
            this.Activated += new System.EventHandler(this.cnx002_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cnx002_FormClosing);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lb_nom_usr;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_sel_usr;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_pas_usr;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_usr_usr;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
    }
}