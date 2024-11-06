namespace Usuarios
{
    partial class FRMventas
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
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtpelicula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtduracion = new System.Windows.Forms.TextBox();
            this.txtfechainicio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsala = new System.Windows.Forms.TextBox();
            this.txtidsesion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtidasiento = new System.Windows.Forms.TextBox();
            this.chktipoasignacion = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.txtfila = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.IdSesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnanular = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txttipotransaccion = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnbusquedaasiento = new FontAwesome.Sharp.IconButton();
            this.btnbuscarsesion = new FontAwesome.Sharp.IconButton();
            this.txtidsala = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(969, 468);
            this.label8.TabIndex = 45;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 46;
            this.label1.Text = "Registrar Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txttipotransaccion);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(72, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 73);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Transaccion:";
            // 
            // txtfecha
            // 
            this.txtfecha.Enabled = false;
            this.txtfecha.Location = new System.Drawing.Point(10, 36);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(120, 20);
            this.txtfecha.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtidsala);
            this.groupBox2.Controls.Add(this.txtidsesion);
            this.groupBox2.Controls.Add(this.btnbuscarsesion);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtsala);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtfechainicio);
            this.groupBox2.Controls.Add(this.txtduracion);
            this.groupBox2.Controls.Add(this.txtpelicula);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(427, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 73);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Sesion";
            // 
            // txtpelicula
            // 
            this.txtpelicula.Enabled = false;
            this.txtpelicula.Location = new System.Drawing.Point(10, 36);
            this.txtpelicula.Name = "txtpelicula";
            this.txtpelicula.Size = new System.Drawing.Size(114, 20);
            this.txtpelicula.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Duracion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pelicula";
            // 
            // txtduracion
            // 
            this.txtduracion.Enabled = false;
            this.txtduracion.Location = new System.Drawing.Point(130, 36);
            this.txtduracion.Name = "txtduracion";
            this.txtduracion.Size = new System.Drawing.Size(86, 20);
            this.txtduracion.TabIndex = 49;
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.Enabled = false;
            this.txtfechainicio.Location = new System.Drawing.Point(222, 36);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(112, 20);
            this.txtfechainicio.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Fecha de inicio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Sala";
            // 
            // txtsala
            // 
            this.txtsala.Enabled = false;
            this.txtsala.Location = new System.Drawing.Point(340, 36);
            this.txtsala.Name = "txtsala";
            this.txtsala.Size = new System.Drawing.Size(82, 20);
            this.txtsala.TabIndex = 52;
            // 
            // txtidsesion
            // 
            this.txtidsesion.Location = new System.Drawing.Point(497, 13);
            this.txtidsesion.Name = "txtidsesion";
            this.txtidsesion.Size = new System.Drawing.Size(32, 20);
            this.txtidsesion.TabIndex = 55;
            this.txtidsesion.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(215, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Fila:";
            // 
            // txtidasiento
            // 
            this.txtidasiento.Location = new System.Drawing.Point(294, 13);
            this.txtidasiento.Name = "txtidasiento";
            this.txtidasiento.Size = new System.Drawing.Size(32, 20);
            this.txtidasiento.TabIndex = 55;
            this.txtidasiento.Text = "0";
            // 
            // chktipoasignacion
            // 
            this.chktipoasignacion.AutoSize = true;
            this.chktipoasignacion.Location = new System.Drawing.Point(10, 22);
            this.chktipoasignacion.Name = "chktipoasignacion";
            this.chktipoasignacion.Size = new System.Drawing.Size(133, 17);
            this.chktipoasignacion.TabIndex = 57;
            this.chktipoasignacion.Text = "Asignación automatica";
            this.chktipoasignacion.UseVisualStyleBackColor = true;
            this.chktipoasignacion.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.numericUpDown);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtfila);
            this.groupBox3.Controls.Add(this.chktipoasignacion);
            this.groupBox3.Controls.Add(this.txtidasiento);
            this.groupBox3.Controls.Add(this.btnbusquedaasiento);
            this.groupBox3.Controls.Add(this.txtnumero);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(72, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 90);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información Asiento";
            // 
            // txtnumero
            // 
            this.txtnumero.Enabled = false;
            this.txtnumero.Location = new System.Drawing.Point(156, 39);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(42, 20);
            this.txtnumero.TabIndex = 2;
            // 
            // txtfila
            // 
            this.txtfila.Enabled = false;
            this.txtfila.Location = new System.Drawing.Point(218, 39);
            this.txtfila.Name = "txtfila";
            this.txtfila.Size = new System.Drawing.Size(42, 20);
            this.txtfila.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Numero:";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(10, 45);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown.TabIndex = 60;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSesion,
            this.Sala,
            this.IdPelicula,
            this.NPelicula,
            this.IdAsiento,
            this.NSala,
            this.FechaInicio,
            this.btnanular});
            this.dgvdata.Location = new System.Drawing.Point(126, 286);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(805, 186);
            this.dgvdata.TabIndex = 57;
            // 
            // IdSesion
            // 
            this.IdSesion.HeaderText = "IdSesion";
            this.IdSesion.MinimumWidth = 6;
            this.IdSesion.Name = "IdSesion";
            this.IdSesion.ReadOnly = true;
            this.IdSesion.Visible = false;
            this.IdSesion.Width = 125;
            // 
            // Sala
            // 
            this.Sala.HeaderText = "Sala";
            this.Sala.Name = "Sala";
            this.Sala.ReadOnly = true;
            this.Sala.Width = 150;
            // 
            // IdPelicula
            // 
            this.IdPelicula.HeaderText = "IdPelicula";
            this.IdPelicula.MinimumWidth = 6;
            this.IdPelicula.Name = "IdPelicula";
            this.IdPelicula.ReadOnly = true;
            this.IdPelicula.Visible = false;
            this.IdPelicula.Width = 125;
            // 
            // NPelicula
            // 
            this.NPelicula.HeaderText = "Pelicula";
            this.NPelicula.MinimumWidth = 6;
            this.NPelicula.Name = "NPelicula";
            this.NPelicula.ReadOnly = true;
            this.NPelicula.Width = 200;
            // 
            // IdAsiento
            // 
            this.IdAsiento.HeaderText = "IdAsiento";
            this.IdAsiento.MinimumWidth = 6;
            this.IdAsiento.Name = "IdAsiento";
            this.IdAsiento.ReadOnly = true;
            this.IdAsiento.Visible = false;
            this.IdAsiento.Width = 125;
            // 
            // NSala
            // 
            this.NSala.HeaderText = "Asiento";
            this.NSala.MinimumWidth = 6;
            this.NSala.Name = "NSala";
            this.NSala.ReadOnly = true;
            this.NSala.Width = 125;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha de inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 200;
            // 
            // btnanular
            // 
            this.btnanular.HeaderText = "";
            this.btnanular.MinimumWidth = 6;
            this.btnanular.Name = "btnanular";
            this.btnanular.ReadOnly = true;
            this.btnanular.Width = 30;
            // 
            // txttipotransaccion
            // 
            this.txttipotransaccion.Enabled = false;
            this.txttipotransaccion.Location = new System.Drawing.Point(145, 37);
            this.txttipotransaccion.Name = "txttipotransaccion";
            this.txttipotransaccion.Size = new System.Drawing.Size(133, 20);
            this.txttipotransaccion.TabIndex = 3;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.iconButton1.IconColor = System.Drawing.Color.DarkCyan;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(844, 202);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 66);
            this.iconButton1.TabIndex = 58;
            this.iconButton1.Text = "Registrar";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnbusquedaasiento
            // 
            this.btnbusquedaasiento.BackColor = System.Drawing.Color.White;
            this.btnbusquedaasiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbusquedaasiento.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbusquedaasiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbusquedaasiento.ForeColor = System.Drawing.Color.White;
            this.btnbusquedaasiento.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbusquedaasiento.IconColor = System.Drawing.Color.Black;
            this.btnbusquedaasiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbusquedaasiento.IconSize = 16;
            this.btnbusquedaasiento.Location = new System.Drawing.Point(285, 38);
            this.btnbusquedaasiento.Margin = new System.Windows.Forms.Padding(2);
            this.btnbusquedaasiento.Name = "btnbusquedaasiento";
            this.btnbusquedaasiento.Size = new System.Drawing.Size(41, 20);
            this.btnbusquedaasiento.TabIndex = 54;
            this.btnbusquedaasiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbusquedaasiento.UseVisualStyleBackColor = false;
            this.btnbusquedaasiento.Click += new System.EventHandler(this.btnbusquedaasiento_Click);
            // 
            // btnbuscarsesion
            // 
            this.btnbuscarsesion.BackColor = System.Drawing.Color.White;
            this.btnbuscarsesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarsesion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarsesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarsesion.ForeColor = System.Drawing.Color.White;
            this.btnbuscarsesion.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarsesion.IconColor = System.Drawing.Color.Black;
            this.btnbuscarsesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarsesion.IconSize = 16;
            this.btnbuscarsesion.Location = new System.Drawing.Point(442, 36);
            this.btnbuscarsesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscarsesion.Name = "btnbuscarsesion";
            this.btnbuscarsesion.Size = new System.Drawing.Size(41, 20);
            this.btnbuscarsesion.TabIndex = 54;
            this.btnbuscarsesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarsesion.UseVisualStyleBackColor = false;
            this.btnbuscarsesion.Click += new System.EventHandler(this.btnbuscarsesion_Click);
            // 
            // txtidsala
            // 
            this.txtidsala.Location = new System.Drawing.Point(497, 36);
            this.txtidsala.Name = "txtidsala";
            this.txtidsala.Size = new System.Drawing.Size(32, 20);
            this.txtidsala.TabIndex = 56;
            this.txtidsala.Text = "0";
            // 
            // FRMventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 518);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Name = "FRMventas";
            this.Text = "FRMventas";
            this.Load += new System.EventHandler(this.FRMventas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtpelicula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtfechainicio;
        private System.Windows.Forms.TextBox txtduracion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsala;
        private FontAwesome.Sharp.IconButton btnbuscarsesion;
        private System.Windows.Forms.TextBox txtidsesion;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton btnbusquedaasiento;
        private System.Windows.Forms.TextBox txtidasiento;
        private System.Windows.Forms.CheckBox chktipoasignacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtfila;
        private System.Windows.Forms.TextBox txtnumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sala;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewButtonColumn btnanular;
        private System.Windows.Forms.TextBox txttipotransaccion;
        private System.Windows.Forms.TextBox txtidsala;
    }
}