namespace CREARSIS
{
    partial class cnx000
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cnx000));
            this.bt_ver_pss = new DevComponents.DotNetBar.ButtonX();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.lb_ver_sis = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.sy_bdo_usr = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.sy_pss_usr = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.SymbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.cb_bdo_usr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tb_pss_usr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tb_usr_usr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Label1 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lk_fan_pag = new System.Windows.Forms.LinkLabel();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_ver_pss
            // 
            this.bt_ver_pss.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ver_pss.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ver_pss.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ver_pss.Location = new System.Drawing.Point(460, 80);
            this.bt_ver_pss.Margin = new System.Windows.Forms.Padding(0);
            this.bt_ver_pss.Name = "bt_ver_pss";
            this.bt_ver_pss.ShowSubItems = false;
            this.bt_ver_pss.Size = new System.Drawing.Size(25, 18);
            this.bt_ver_pss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ver_pss.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.bt_ver_pss.SubItemsExpandWidth = 0;
            this.bt_ver_pss.Symbol = "";
            this.bt_ver_pss.SymbolSize = 14F;
            this.bt_ver_pss.TabIndex = 87;
            this.bt_ver_pss.MouseLeave += new System.EventHandler(this.bt_ver_pss_MouseLeave);
            this.bt_ver_pss.MouseHover += new System.EventHandler(this.bt_ver_pss_MouseHover);
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.Name = "itemContainer1";
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Location = new System.Drawing.Point(390, 167);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(97, 37);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.TabIndex = 86;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Location = new System.Drawing.Point(283, 167);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(97, 37);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.TabIndex = 85;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // lb_ver_sis
            // 
            this.lb_ver_sis.AutoSize = true;
            this.lb_ver_sis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.lb_ver_sis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ver_sis.ForeColor = System.Drawing.Color.Black;
            this.lb_ver_sis.Location = new System.Drawing.Point(49, 146);
            this.lb_ver_sis.Name = "lb_ver_sis";
            this.lb_ver_sis.Size = new System.Drawing.Size(65, 13);
            this.lb_ver_sis.TabIndex = 83;
            this.lb_ver_sis.Text = "Ver.: 0.0.0.0";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.PictureBox1.ForeColor = System.Drawing.Color.Black;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(19, 32);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(127, 112);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 84;
            this.PictureBox1.TabStop = false;
            // 
            // sy_bdo_usr
            // 
            this.sy_bdo_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.sy_bdo_usr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sy_bdo_usr.ForeColor = System.Drawing.Color.Black;
            this.sy_bdo_usr.Location = new System.Drawing.Point(156, 116);
            this.sy_bdo_usr.Name = "sy_bdo_usr";
            this.sy_bdo_usr.Size = new System.Drawing.Size(26, 23);
            this.sy_bdo_usr.Symbol = "";
            this.sy_bdo_usr.TabIndex = 82;
            this.sy_bdo_usr.Text = "sy_bdo_usr";
            this.sy_bdo_usr.DoubleClick += new System.EventHandler(this.sy_bdo_usr_DoubleClick);
            // 
            // sy_pss_usr
            // 
            this.sy_pss_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.sy_pss_usr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sy_pss_usr.ForeColor = System.Drawing.Color.Black;
            this.sy_pss_usr.Location = new System.Drawing.Point(156, 77);
            this.sy_pss_usr.Name = "sy_pss_usr";
            this.sy_pss_usr.Size = new System.Drawing.Size(26, 23);
            this.sy_pss_usr.Symbol = "";
            this.sy_pss_usr.TabIndex = 81;
            this.sy_pss_usr.Text = "sy_pss_usr";
            this.sy_pss_usr.DoubleClick += new System.EventHandler(this.sy_pss_usr_DoubleClick);
            // 
            // SymbolBox1
            // 
            this.SymbolBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.SymbolBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SymbolBox1.ForeColor = System.Drawing.Color.Black;
            this.SymbolBox1.Location = new System.Drawing.Point(156, 38);
            this.SymbolBox1.Name = "SymbolBox1";
            this.SymbolBox1.Size = new System.Drawing.Size(26, 23);
            this.SymbolBox1.Symbol = "";
            this.SymbolBox1.TabIndex = 80;
            this.SymbolBox1.Text = "SymbolBox1";
            // 
            // cb_bdo_usr
            // 
            this.cb_bdo_usr.DisplayMember = "Text";
            this.cb_bdo_usr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_bdo_usr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_bdo_usr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_bdo_usr.ForeColor = System.Drawing.Color.Black;
            this.cb_bdo_usr.FormattingEnabled = true;
            this.cb_bdo_usr.ItemHeight = 16;
            this.cb_bdo_usr.Location = new System.Drawing.Point(187, 117);
            this.cb_bdo_usr.Name = "cb_bdo_usr";
            this.cb_bdo_usr.Size = new System.Drawing.Size(300, 22);
            this.cb_bdo_usr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_bdo_usr.TabIndex = 79;
            // 
            // tb_pss_usr
            // 
            this.tb_pss_usr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_pss_usr.Border.Class = "TextBoxBorder";
            this.tb_pss_usr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_pss_usr.ButtonCustom.Symbol = "";
            this.tb_pss_usr.ButtonCustom2.Symbol = "";
            this.tb_pss_usr.ButtonCustom2.Visible = true;
            this.tb_pss_usr.DisabledBackColor = System.Drawing.Color.White;
            this.tb_pss_usr.ForeColor = System.Drawing.Color.Black;
            this.tb_pss_usr.Location = new System.Drawing.Point(185, 78);
            this.tb_pss_usr.MaxLength = 30;
            this.tb_pss_usr.Name = "tb_pss_usr";
            this.tb_pss_usr.PreventEnterBeep = true;
            this.tb_pss_usr.Size = new System.Drawing.Size(302, 22);
            this.tb_pss_usr.TabIndex = 78;
            this.tb_pss_usr.Text = "Crearsis123.";
            this.tb_pss_usr.UseSystemPasswordChar = true;
            this.tb_pss_usr.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pss_usr.WatermarkText = "**********";
            // 
            // tb_usr_usr
            // 
            this.tb_usr_usr.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_usr_usr.Border.Class = "TextBoxBorder";
            this.tb_usr_usr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_usr_usr.ButtonCustom.Symbol = "";
            this.tb_usr_usr.DisabledBackColor = System.Drawing.Color.White;
            this.tb_usr_usr.ForeColor = System.Drawing.Color.Black;
            this.tb_usr_usr.Location = new System.Drawing.Point(185, 40);
            this.tb_usr_usr.MaxLength = 15;
            this.tb_usr_usr.Name = "tb_usr_usr";
            this.tb_usr_usr.PreventEnterBeep = true;
            this.tb_usr_usr.Size = new System.Drawing.Size(302, 22);
            this.tb_usr_usr.TabIndex = 77;
            this.tb_usr_usr.Text = "crearsis";
            this.tb_usr_usr.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_usr_usr.WatermarkText = "Usuario...";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(410, -3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 26);
            this.Label1.TabIndex = 76;
            this.Label1.Text = "Soporte\r\nTelf: 999 99999";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // lk_fan_pag
            // 
            this.lk_fan_pag.ActiveLinkColor = System.Drawing.Color.RosyBrown;
            this.lk_fan_pag.AutoSize = true;
            this.lk_fan_pag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.lk_fan_pag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lk_fan_pag.ForeColor = System.Drawing.Color.Black;
            this.lk_fan_pag.LinkColor = System.Drawing.Color.Blue;
            this.lk_fan_pag.Location = new System.Drawing.Point(16, 191);
            this.lk_fan_pag.Name = "lk_fan_pag";
            this.lk_fan_pag.Size = new System.Drawing.Size(134, 13);
            this.lk_fan_pag.TabIndex = 88;
            this.lk_fan_pag.TabStop = true;
            this.lk_fan_pag.Text = "@Visitanos en Facebook";
            this.lk_fan_pag.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_fan_pag_LinkClicked);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.line1.ForeColor = System.Drawing.Color.Black;
            this.line1.Location = new System.Drawing.Point(148, 33);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(11, 110);
            this.line1.TabIndex = 89;
            this.line1.Text = "line1";
            this.line1.VerticalLine = true;
            // 
            // cnx000
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(510, 211);
            this.ControlBox = false;
            this.Controls.Add(this.lk_fan_pag);
            this.Controls.Add(this.bt_ver_pss);
            this.Controls.Add(this.bt_can_cel);
            this.Controls.Add(this.bt_ace_pta);
            this.Controls.Add(this.lb_ver_sis);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.sy_bdo_usr);
            this.Controls.Add(this.sy_pss_usr);
            this.Controls.Add(this.SymbolBox1);
            this.Controls.Add(this.cb_bdo_usr);
            this.Controls.Add(this.tb_pss_usr);
            this.Controls.Add(this.tb_usr_usr);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.line1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cnx000";
            this.ShowIcon = false;
            this.Text = "CREARSIS - Autenticación de Usuario";
            this.TitleText = "CREARSIS - Autenticación de Usuario";
            this.Load += new System.EventHandler(this.cnx000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bt_ver_pss;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        internal System.Windows.Forms.Label lb_ver_sis;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal DevComponents.DotNetBar.Controls.SymbolBox sy_bdo_usr;
        internal DevComponents.DotNetBar.Controls.SymbolBox sy_pss_usr;
        internal DevComponents.DotNetBar.Controls.SymbolBox SymbolBox1;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cb_bdo_usr;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_pss_usr;
        internal DevComponents.DotNetBar.Controls.TextBoxX tb_usr_usr;
        internal System.Windows.Forms.Label Label1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.LinkLabel lk_fan_pag;
        private DevComponents.DotNetBar.Controls.Line line1;
    }
}