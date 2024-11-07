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
        public Menu(Usuario objUsuario)
        {
                usuarioActual = objUsuario;
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if(usuarioActual.oRol.IdRol == 0)
            {
                menuusuariosAdmin.Visible = false;
                menumantenedor.Visible = false;
                menureportes.Visible = false;
                menuventas.Visible = true;
            }
            else if (usuarioActual.oRol.IdRol == 3)
            {
                menuventas.Visible = false;
                menuusuariosAdmin.Visible = false;
                menumantenedor.Visible = false;
                menureportes.Visible = true;
            }
            else
            {
                menuventas.Visible = true;
                menuusuariosAdmin.Visible = false;
                menumantenedor.Visible = false;
                menureportes.Visible = false;
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

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(submenudetalleventa, new FRMdetalleventa());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new FRMreportes(usuarioActual));
        }
    }
}
