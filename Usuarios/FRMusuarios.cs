using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios.Utilidades;
using CapaEntidad;
using CapaNegocio;
using System.Security.Cryptography;
using Microsoft.AspNet.SignalR.Client;
using System.Windows.Documents;

namespace Usuarios
{
    public partial class FRMusuarios : Form
    {
        private CN_Usuario cnUsuario = new CN_Usuario();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        private string contraseña = string.Empty;
        public FRMusuarios()
        {
            InitializeComponent();
            cnUsuario.OnUsuariosChanged += RecargarUsuarios;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("UsuarioHub");
            usuarioHubProxy.On("ActualizarUsuarios", () => RecargarUsuarios());
            hubConnection.Start().Wait();
        }


        private void FRMusuarios_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            //Asignar los roles al comboboxrol
            List<Rol> listarol = new CN_Rol().Listar();
            foreach (Rol item in listarol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Nombre});
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            //Mostrar las opciones de busqueda en el comboboxbusqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if(columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
            //Mostrar los valores en el datagridview
            RecargarUsuarios();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string contraseñaencriptada = "";
            if (txtclave.Text != "" && txtconfirmarclave.Text != "")
            {
                contraseñaencriptada = Encriptar.EncriptarSHA256(txtclave.Text);
                if (contraseñaencriptada != Encriptar.EncriptarSHA256(txtconfirmarclave.Text))
                {
                    MessageBox.Show("Las contraseña no fueron ingresadas correctamente la operacion no se ejecuto");
                    return;
                }
            }
            else
            {
                contraseñaencriptada = contraseña;
            }
            Usuario objusuario = new Usuario()
            {
                IDUsuario = Convert.ToInt32(txtid.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                NombreUsuario = txtnombreusuario.Text,
                Clave = contraseñaencriptada,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor), Nombre= ((OpcionCombo)cboRol.SelectedItem).Texto},
            };

            if (objusuario.IDUsuario == 0)
            {

                int IdUsuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);
                if (IdUsuariogenerado != 0)
                {
                    MessageBox.Show("Usuario ingresado correctamente");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool Resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                if (Resultado)
                {
                    MessageBox.Show("Usuario Actualizado correctamente");
                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtid.Text) != 0)
            {
                if(MessageBox.Show("¿Desea eliminar el usuario","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario,out mensaje);
                    if (respuesta)
                    {
                        MessageBox.Show("Usuario Eliminado");
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtnombreusuario.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cboRol.SelectedIndex = 0;
            txtNombre.Select();
        }
        //Metodo para colocar imagen check
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.Check.Width;
                var h = Properties.Resources.Check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.Check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if(indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtnombreusuario.Text = dgvdata.Rows[indice].Cells["Usuario"].Value.ToString();
                    contraseña = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }
        private void RecargarUsuarios()
        {
            if (!formularioAbierto) return;

            // Este método se ejecutará en respuesta a la notificación de SignalR
            if (dgvdata.InvokeRequired)
            {
                dgvdata.Invoke((MethodInvoker)delegate { RecargarUsuariosEnUI(); });
            }
            else
            {
                RecargarUsuariosEnUI();
            }
        }

        private void RecargarUsuariosEnUI()
        {
            if (!formularioAbierto || dgvdata.IsDisposed) return;

            dgvdata.Rows.Clear();
            List<Usuario> listausuario = cnUsuario.Listar();  // Obtiene la lista actualizada desde la base de datos
            foreach (Usuario item in listausuario)
            {
                dgvdata.Rows.Add(new object[] {
            "", item.IDUsuario, item.NombreUsuario, item.Nombre, item.Apellido,
            item.Clave, item.oRol.IdRol, item.oRol.Nombre
        });
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if(dgvdata.Rows.Count > 0 )
            {
                foreach(DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnafiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
