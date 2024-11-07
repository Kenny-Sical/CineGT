namespace Usuarios
{
    partial class Menu
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
            this.Menu_ = new System.Windows.Forms.MenuStrip();
            this.menuusuariosAdmin = new FontAwesome.Sharp.IconMenuItem();
            this.menuusuariosUser = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.submenuclasificacion = new FontAwesome.Sharp.IconMenuItem();
            this.submenupelicula = new FontAwesome.Sharp.IconMenuItem();
            this.submenusesion = new FontAwesome.Sharp.IconMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.Menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Menu_.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_
            // 
            this.Menu_.BackColor = System.Drawing.Color.White;
            this.Menu_.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuariosAdmin,
            this.menuusuariosUser,
            this.menumantenedor,
            this.menuventas,
            this.menureportes,
            this.menuacercade});
            this.Menu_.Location = new System.Drawing.Point(0, 56);
            this.Menu_.Name = "Menu_";
            this.Menu_.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Menu_.Size = new System.Drawing.Size(1049, 78);
            this.Menu_.TabIndex = 0;
            this.Menu_.Text = "menuStrip1";
            // 
            // menuusuariosAdmin
            // 
            this.menuusuariosAdmin.AutoSize = false;
            this.menuusuariosAdmin.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuusuariosAdmin.IconColor = System.Drawing.Color.Black;
            this.menuusuariosAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuariosAdmin.IconSize = 50;
            this.menuusuariosAdmin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuariosAdmin.Name = "menuusuariosAdmin";
            this.menuusuariosAdmin.Size = new System.Drawing.Size(80, 74);
            this.menuusuariosAdmin.Text = "Usuarios";
            this.menuusuariosAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuariosAdmin.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // menuusuariosUser
            // 
            this.menuusuariosUser.AutoSize = false;
            this.menuusuariosUser.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuusuariosUser.IconColor = System.Drawing.Color.Black;
            this.menuusuariosUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuariosUser.IconSize = 50;
            this.menuusuariosUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuariosUser.Name = "menuusuariosUser";
            this.menuusuariosUser.Size = new System.Drawing.Size(80, 74);
            this.menuusuariosUser.Text = "Usuarios";
            this.menuusuariosUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menumantenedor
            // 
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuclasificacion,
            this.submenupelicula,
            this.submenusesion});
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 50;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Size = new System.Drawing.Size(84, 74);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuclasificacion
            // 
            this.submenuclasificacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuclasificacion.IconColor = System.Drawing.Color.Black;
            this.submenuclasificacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuclasificacion.Name = "submenuclasificacion";
            this.submenuclasificacion.Size = new System.Drawing.Size(141, 22);
            this.submenuclasificacion.Text = "Clasificación";
            this.submenuclasificacion.Click += new System.EventHandler(this.submenuclasificacion_Click);
            // 
            // submenupelicula
            // 
            this.submenupelicula.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenupelicula.IconColor = System.Drawing.Color.Black;
            this.submenupelicula.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenupelicula.Name = "submenupelicula";
            this.submenupelicula.Size = new System.Drawing.Size(141, 22);
            this.submenupelicula.Text = "Pelicula";
            this.submenupelicula.Click += new System.EventHandler(this.submenupelicula_Click);
            // 
            // submenusesion
            // 
            this.submenusesion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenusesion.IconColor = System.Drawing.Color.Black;
            this.submenusesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenusesion.Name = "submenusesion";
            this.submenusesion.Size = new System.Drawing.Size(141, 22);
            this.submenusesion.Text = "Sesiones";
            this.submenusesion.Click += new System.EventHandler(this.submenusesion_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenudetalleventa});
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 50;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(80, 74);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuventas.Click += new System.EventHandler(this.menuventas_Click);
            // 
            // submenudetalleventa
            // 
            this.submenudetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetalleventa.IconColor = System.Drawing.Color.Black;
            this.submenudetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetalleventa.Name = "submenudetalleventa";
            this.submenudetalleventa.Size = new System.Drawing.Size(184, 26);
            this.submenudetalleventa.Text = "Detalle Venta";
            this.submenudetalleventa.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(80, 74);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(80, 74);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menutitulo
            // 
            this.Menutitulo.AutoSize = false;
            this.Menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.Menutitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menutitulo.Location = new System.Drawing.Point(0, 0);
            this.Menutitulo.Name = "Menutitulo";
            this.Menutitulo.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menutitulo.Size = new System.Drawing.Size(1049, 56);
            this.Menutitulo.TabIndex = 1;
            this.Menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de ventas";
            // 
            // contenedor
            // 
            this.contenedor.AutoSize = true;
            this.contenedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 134);
            this.contenedor.Margin = new System.Windows.Forms.Padding(2);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1049, 428);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(762, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(808, 28);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(63, 15);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 562);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu_);
            this.Controls.Add(this.Menutitulo);
            this.MainMenuStrip = this.Menu_;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Menu_.ResumeLayout(false);
            this.Menu_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_;
        private System.Windows.Forms.MenuStrip Menutitulo;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menuusuariosAdmin;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem submenuclasificacion;
        private FontAwesome.Sharp.IconMenuItem submenupelicula;
        private FontAwesome.Sharp.IconMenuItem menuusuariosUser;
        private FontAwesome.Sharp.IconMenuItem submenusesion;
        private FontAwesome.Sharp.IconMenuItem submenudetalleventa;
    }
}