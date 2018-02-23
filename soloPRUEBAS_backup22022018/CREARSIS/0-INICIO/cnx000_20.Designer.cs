namespace CREARSIS
{
    partial class cnx000_20
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cnx000_20));
            this.lb_tit_ulo = new DevComponents.DotNetBar.LabelX();
            this.SymbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.tb_tex_msg = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.tm_not_ify = new System.Windows.Forms.Timer(this.components);
            this.tm_org_pos = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lb_tit_ulo
            // 
            // 
            // 
            // 
            this.lb_tit_ulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_tit_ulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lb_tit_ulo.FontBold = true;
            this.lb_tit_ulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_tit_ulo.Location = new System.Drawing.Point(4, 3);
            this.lb_tit_ulo.Name = "lb_tit_ulo";
            this.lb_tit_ulo.Size = new System.Drawing.Size(288, 26);
            this.lb_tit_ulo.TabIndex = 8;
            this.lb_tit_ulo.Text = "Titulo";
            // 
            // SymbolBox1
            // 
            // 
            // 
            // 
            this.SymbolBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SymbolBox1.Location = new System.Drawing.Point(301, 3);
            this.SymbolBox1.Name = "SymbolBox1";
            this.SymbolBox1.Size = new System.Drawing.Size(24, 23);
            this.SymbolBox1.Symbol = "";
            this.SymbolBox1.TabIndex = 6;
            this.SymbolBox1.Text = "SymbolBox1";
            this.SymbolBox1.Click += new System.EventHandler(this.SymbolBox1_Click);
            // 
            // tb_tex_msg
            // 
            this.tb_tex_msg.BackColorRichTextBox = System.Drawing.Color.Teal;
            // 
            // 
            // 
            this.tb_tex_msg.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Transparent;
            this.tb_tex_msg.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
            this.tb_tex_msg.BackgroundStyle.BorderGradientAngle = 0;
            this.tb_tex_msg.BackgroundStyle.Class = "RichTextBoxBorder";
            this.tb_tex_msg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_tex_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tex_msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_tex_msg.Location = new System.Drawing.Point(8, 35);
            this.tb_tex_msg.Name = "tb_tex_msg";
            this.tb_tex_msg.ReadOnly = true;
            this.tb_tex_msg.Rtf = resources.GetString("tb_tex_msg.Rtf");
            this.tb_tex_msg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tb_tex_msg.Size = new System.Drawing.Size(312, 63);
            this.tb_tex_msg.TabIndex = 8;
            this.tb_tex_msg.Text = "Este es el mensaje enviado por alguna ventana, puede ser alguna notificacion prog" +
    "ramada por un usuario";
            this.tb_tex_msg.ZoomFactor = 1.1F;
            // 
            // tm_not_ify
            // 
            this.tm_not_ify.Enabled = true;
            this.tm_not_ify.Interval = 25;
            this.tm_not_ify.Tick += new System.EventHandler(this.tm_not_ify_Tick);
            // 
            // tm_org_pos
            // 
            this.tm_org_pos.Interval = 1;
            this.tm_org_pos.Tick += new System.EventHandler(this.tm_org_pos_Tick);
            // 
            // cnx000_20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(329, 100);
            this.ControlBox = false;
            this.Controls.Add(this.tb_tex_msg);
            this.Controls.Add(this.SymbolBox1);
            this.Controls.Add(this.lb_tit_ulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cnx000_20";
            this.Opacity = 0.03D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "cnx000_20";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cnx000_20_FormClosing);
            this.Load += new System.EventHandler(this.cnx000_20_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.LabelX lb_tit_ulo;
        internal DevComponents.DotNetBar.Controls.SymbolBox SymbolBox1;
        internal DevComponents.DotNetBar.Controls.RichTextBoxEx tb_tex_msg;
        public System.Windows.Forms.Timer tm_not_ify;
        public System.Windows.Forms.Timer tm_org_pos;
    }
}