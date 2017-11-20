namespace CREARSIS
{
    partial class adm014_09
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bt_imp_xls = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_libro_xls = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dg_res_ult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.DIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.gb_ctr_frm = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new DevComponents.DotNetBar.ButtonX();
            this.bt_ace_pta = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_frm.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_imp_xls
            // 
            this.bt_imp_xls.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_imp_xls.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_imp_xls.Location = new System.Drawing.Point(143, 24);
            this.bt_imp_xls.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_imp_xls.Name = "bt_imp_xls";
            this.bt_imp_xls.Size = new System.Drawing.Size(91, 33);
            this.bt_imp_xls.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_imp_xls.TabIndex = 37;
            this.bt_imp_xls.Text = "Importar";
            this.bt_imp_xls.Click += new System.EventHandler(this.bt_imp_xls_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_libro_xls);
            this.groupBox1.Controls.Add(this.dg_res_ult);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.bt_imp_xls);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(367, 342);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // tb_libro_xls
            // 
            this.tb_libro_xls.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_libro_xls.Border.Class = "TextBoxBorder";
            this.tb_libro_xls.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_libro_xls.DisabledBackColor = System.Drawing.Color.White;
            this.tb_libro_xls.ForeColor = System.Drawing.Color.Black;
            this.tb_libro_xls.Location = new System.Drawing.Point(52, 306);
            this.tb_libro_xls.Name = "tb_libro_xls";
            this.tb_libro_xls.PreventEnterBeep = true;
            this.tb_libro_xls.ReadOnly = true;
            this.tb_libro_xls.Size = new System.Drawing.Size(262, 22);
            this.tb_libro_xls.TabIndex = 82;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToOrderColumns = true;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DIA,
            this.Enero,
            this.Observaciones});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_res_ult.EnableHeadersVisualStyles = false;
            this.dg_res_ult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dg_res_ult.Location = new System.Drawing.Point(25, 68);
            this.dg_res_ult.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(321, 200);
            this.dg_res_ult.TabIndex = 44;
            this.dg_res_ult.TabStop = false;
            // 
            // DIA
            // 
            this.DIA.HeaderText = "Fecha";
            this.DIA.Name = "DIA";
            this.DIA.ReadOnly = true;
            // 
            // Enero
            // 
            this.Enero.HeaderText = "T.C - Bs/Ufv";
            this.Enero.Name = "Enero";
            this.Enero.ReadOnly = true;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(138, 276);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 27);
            this.labelX4.TabIndex = 80;
            this.labelX4.Text = "Libro de Excel:";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // gb_ctr_frm
            // 
            this.gb_ctr_frm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.gb_ctr_frm.Controls.Add(this.bt_can_cel);
            this.gb_ctr_frm.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_frm.ForeColor = System.Drawing.Color.Black;
            this.gb_ctr_frm.Location = new System.Drawing.Point(2, 348);
            this.gb_ctr_frm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_ctr_frm.Name = "gb_ctr_frm";
            this.gb_ctr_frm.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_ctr_frm.Size = new System.Drawing.Size(367, 45);
            this.gb_ctr_frm.TabIndex = 79;
            this.gb_ctr_frm.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_can_cel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.Location = new System.Drawing.Point(207, 14);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(84, 23);
            this.bt_can_cel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_can_cel.Symbol = "";
            this.bt_can_cel.SymbolColor = System.Drawing.Color.Maroon;
            this.bt_can_cel.SymbolSize = 15F;
            this.bt_can_cel.TabIndex = 104;
            this.bt_can_cel.Text = "Cancelar";
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ace_pta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ace_pta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.Location = new System.Drawing.Point(76, 14);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(83, 23);
            this.bt_ace_pta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ace_pta.Symbol = "";
            this.bt_ace_pta.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_ace_pta.SymbolSize = 15F;
            this.bt_ace_pta.TabIndex = 103;
            this.bt_ace_pta.Text = "Aceptar";
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // adm014_09
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(373, 392);
            this.ControlBox = false;
            this.Controls.Add(this.gb_ctr_frm);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "adm014_09";
            this.Text = "T.C. Bs/Ufv por Fechas";
            this.TitleText = "T.C. Bs/Ufv por Fechas";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_frm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bt_imp_xls;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_frm;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dg_res_ult;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_libro_xls;
        private DevComponents.DotNetBar.LabelX labelX4;
        internal DevComponents.DotNetBar.ButtonX bt_can_cel;
        internal DevComponents.DotNetBar.ButtonX bt_ace_pta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
    }
}