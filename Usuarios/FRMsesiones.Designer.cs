namespace Usuarios
{
    partial class FRMsesiones
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdSesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaInicioSesion = new System.Windows.Forms.DateTimePicker();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.cboPelicula = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbosegundos = new System.Windows.Forms.ComboBox();
            this.cbominutos = new System.Windows.Forms.ComboBox();
            this.cbohoras = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(23, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Pelicula:";
            // 
            // txtindice
            // 
            this.txtindice.Location = new System.Drawing.Point(221, 38);
            this.txtindice.Margin = new System.Windows.Forms.Padding(2);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(18, 20);
            this.txtindice.TabIndex = 51;
            this.txtindice.Text = "-1";
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(790, 44);
            this.txtbusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(101, 20);
            this.txtbusqueda.TabIndex = 48;
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(675, 42);
            this.cbobusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(111, 21);
            this.cbobusqueda.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(601, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Buscar por:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(243, 38);
            this.txtid.Margin = new System.Windows.Forms.Padding(2);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(18, 20);
            this.txtid.TabIndex = 45;
            this.txtid.Text = "0";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(676, 48);
            this.label8.TabIndex = 44;
            this.label8.Text = "Lista de sesiones:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnseleccionar,
            this.IdSesion,
            this.IdPelicula,
            this.NPelicula,
            this.Duracion,
            this.FechaHoraInicio,
            this.FechaHoraFin,
            this.IdSala,
            this.NSala,
            this.Estado,
            this.Clasificacion});
            this.dgvdata.Location = new System.Drawing.Point(327, 90);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(676, 299);
            this.dgvdata.TabIndex = 43;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
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
            this.NPelicula.Width = 125;
            // 
            // Duracion
            // 
            this.Duracion.HeaderText = "Duracion";
            this.Duracion.Name = "Duracion";
            this.Duracion.ReadOnly = true;
            // 
            // FechaHoraInicio
            // 
            this.FechaHoraInicio.HeaderText = "Fecha de inicio";
            this.FechaHoraInicio.MinimumWidth = 6;
            this.FechaHoraInicio.Name = "FechaHoraInicio";
            this.FechaHoraInicio.ReadOnly = true;
            this.FechaHoraInicio.Width = 125;
            // 
            // FechaHoraFin
            // 
            this.FechaHoraFin.HeaderText = "Fecha de fin";
            this.FechaHoraFin.MinimumWidth = 6;
            this.FechaHoraFin.Name = "FechaHoraFin";
            this.FechaHoraFin.ReadOnly = true;
            this.FechaHoraFin.Width = 125;
            // 
            // IdSala
            // 
            this.IdSala.HeaderText = "IdSala";
            this.IdSala.MinimumWidth = 6;
            this.IdSala.Name = "IdSala";
            this.IdSala.ReadOnly = true;
            this.IdSala.Visible = false;
            this.IdSala.Width = 125;
            // 
            // NSala
            // 
            this.NSala.HeaderText = "Sala";
            this.NSala.MinimumWidth = 6;
            this.NSala.Name = "NSala";
            this.NSala.ReadOnly = true;
            this.NSala.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Clasificacion
            // 
            this.Clasificacion.HeaderText = "Clasificación";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Detalle Sesion";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(25, 152);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(109, 21);
            this.cboEstado.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(23, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Sala:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 420);
            this.label1.TabIndex = 28;
            // 
            // FechaInicioSesion
            // 
            this.FechaInicioSesion.Location = new System.Drawing.Point(26, 201);
            this.FechaInicioSesion.Name = "FechaInicioSesion";
            this.FechaInicioSesion.Size = new System.Drawing.Size(200, 20);
            this.FechaInicioSesion.TabIndex = 54;
            // 
            // cboSala
            // 
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(25, 57);
            this.cboSala.Margin = new System.Windows.Forms.Padding(2);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(109, 21);
            this.cboSala.TabIndex = 55;
            // 
            // cboPelicula
            // 
            this.cboPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPelicula.FormattingEnabled = true;
            this.cboPelicula.Location = new System.Drawing.Point(25, 103);
            this.cboPelicula.Margin = new System.Windows.Forms.Padding(2);
            this.cboPelicula.Name = "cboPelicula";
            this.cboPelicula.Size = new System.Drawing.Size(203, 21);
            this.cboPelicula.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(153, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Segundos:";
            // 
            // cbosegundos
            // 
            this.cbosegundos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosegundos.FormattingEnabled = true;
            this.cbosegundos.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbosegundos.Location = new System.Drawing.Point(156, 255);
            this.cbosegundos.Margin = new System.Windows.Forms.Padding(2);
            this.cbosegundos.Name = "cbosegundos";
            this.cbosegundos.Size = new System.Drawing.Size(44, 21);
            this.cbosegundos.TabIndex = 62;
            // 
            // cbominutos
            // 
            this.cbominutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbominutos.FormattingEnabled = true;
            this.cbominutos.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbominutos.Location = new System.Drawing.Point(90, 255);
            this.cbominutos.Margin = new System.Windows.Forms.Padding(2);
            this.cbominutos.Name = "cbominutos";
            this.cbominutos.Size = new System.Drawing.Size(44, 21);
            this.cbominutos.TabIndex = 61;
            // 
            // cbohoras
            // 
            this.cbohoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohoras.FormattingEnabled = true;
            this.cbohoras.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbohoras.Location = new System.Drawing.Point(27, 255);
            this.cbohoras.Margin = new System.Windows.Forms.Padding(2);
            this.cbohoras.Name = "cbohoras";
            this.cbohoras.Size = new System.Drawing.Size(44, 21);
            this.cbohoras.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(87, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Minutos:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(25, 240);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Horas:";
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 16;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(942, 45);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(2);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(41, 17);
            this.btnlimpiarbuscador.TabIndex = 50;
            this.btnlimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(897, 46);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(41, 17);
            this.btnbuscar.TabIndex = 49;
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btneliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btneliminar.IconColor = System.Drawing.Color.White;
            this.btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btneliminar.IconSize = 20;
            this.btneliminar.Location = new System.Drawing.Point(54, 368);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(172, 32);
            this.btneliminar.TabIndex = 41;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.White;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 20;
            this.btnlimpiar.Location = new System.Drawing.Point(54, 333);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(172, 31);
            this.btnlimpiar.TabIndex = 40;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnguardar.IconColor = System.Drawing.Color.White;
            this.btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnguardar.IconSize = 20;
            this.btnguardar.Location = new System.Drawing.Point(54, 295);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(172, 34);
            this.btnguardar.TabIndex = 39;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // FRMsesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 420);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbosegundos);
            this.Controls.Add(this.cbominutos);
            this.Controls.Add(this.cbohoras);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPelicula);
            this.Controls.Add(this.cboSala);
            this.Controls.Add(this.FechaInicioSesion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FRMsesiones";
            this.Text = "FRMsesiones";
            this.Load += new System.EventHandler(this.FRMsesiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtindice;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaInicioSesion;
        private System.Windows.Forms.ComboBox cboSala;
        private System.Windows.Forms.ComboBox cboPelicula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbosegundos;
        private System.Windows.Forms.ComboBox cbominutos;
        private System.Windows.Forms.ComboBox cbohoras;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
    }
}