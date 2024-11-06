namespace Usuarios.Modales
{
    partial class mdAsiento
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
            this.panelAsientos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // panelAsientos
            // 
            this.panelAsientos.AutoScroll = true;
            this.panelAsientos.Location = new System.Drawing.Point(44, 55);
            this.panelAsientos.Name = "panelAsientos";
            this.panelAsientos.Size = new System.Drawing.Size(564, 471);
            this.panelAsientos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asientos:";
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconButton1.IconColor = System.Drawing.Color.DarkCyan;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(480, 12);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(128, 38);
            this.iconButton1.TabIndex = 59;
            this.iconButton1.Text = "Guardar asientos";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // mdAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 552);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelAsientos);
            this.Name = "mdAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdAsiento";
            this.Load += new System.EventHandler(this.mdAsiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAsientos;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}