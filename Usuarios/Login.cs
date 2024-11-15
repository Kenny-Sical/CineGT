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
using Usuarios.Utilidades;



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
            Usuario ousuario = null;
            string usuarioIngresado = txtusuario.Text;
            string claveEncriptada = Encriptar.EncriptarSHA256(txtclave.Text);
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.NombreUsuario == usuarioIngresado && usuario.Clave == claveEncriptada)
                {
                    ousuario = usuario;
                    break; // Rompe el ciclo una vez encontrado el usuario
                }
            }

            if (ousuario != null)
            {
                if (ousuario.oRol.IdRol != 2)
                {
                    string contraseñaencriptada = Encriptar.EncriptarSHA256(txtclave.Text);
                    Menu form = new Menu(ousuario);
                    form.Show();
                    this.Hide();
                    form.FormClosing += frm_closing;
                }
                else
                {
                    MessageBox.Show("El usuario actualmente se encuentra inactivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtusuario.Text = "";
                    txtclave.Text = "";
                }
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
