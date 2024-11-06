using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;

namespace Usuarios
{
    public partial class Menu : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Menu(Usuario objUsuario = null)
        {
            if (objUsuario == null) usuarioActual = new Usuario() { Nombre = "ADMIN DEFAULT", IDUsuario = 1, oRol = new Rol() { IdRol = 1} };
            else
                usuarioActual = objUsuario;

            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if(usuarioActual.oRol.IdRol == 0)
            {
                menuusuariosAdmin.Visible = false;
                menumantenedor.Visible = false;
            }
            else
            {
                menuusuariosUser.Visible = false;
            }


            lblUsuario.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            MenuActivo = menu;
            MenuActivo.BackColor = Color.Silver;

            // Cerrar el formulario activo si existe
            if (FormularioActivo != null)
            {
                // Llamar a FormClosed para liberar recursos
                FormularioActivo.Close();
                FormularioActivo.Dispose(); // Asegurarse de liberar los recursos completamente
            }

            // Configurar el nuevo formulario
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuusuariosAdmin, new FRMusuarios());
        }

        private void submenuclasificacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new FRMclasificacion());
        }

        private void submenupelicula_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new FRMpelicula());
        }

        private void submenusesion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new FRMsesiones());
        }

        private void menuventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new FRMventas(usuarioActual));
        }
    }
}
