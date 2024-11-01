using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;



namespace Usuarios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.NombreUsuario == txtusuario.Text && u.Clave == txtclave.Text).FirstOrDefault();
            
            if(ousuario != null)
            {
                MessageBox.Show("Usuario encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Menu form = new Menu(ousuario);
                form.Show();
                this.Hide();
                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el Usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtusuario.Text = "";
                txtclave.Text = "";
            }

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtusuario.Text = "";
            txtclave.Text = "";
            this.Show();
        }
    }
}
