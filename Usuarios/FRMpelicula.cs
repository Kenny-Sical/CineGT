using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNet.SignalR.Client;
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

namespace Usuarios
{
    public partial class FRMpelicula : Form
    {
        private CN_Pelicula cnUsuario = new CN_Pelicula();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        public FRMpelicula()
        {
            InitializeComponent();
            cnUsuario.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void FRMpelicula_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            //Asignar los roles al comboboxrol
            List<Clasificacion> listarol = new CN_Clasificacion().Listar();
            foreach (Clasificacion item in listarol)
            {
                cboClasificacion.Items.Add(new OpcionCombo() { Valor = item.IdClasificacion, Texto = item.Nombre });
            }
            cboClasificacion.DisplayMember = "Texto";
            cboClasificacion.ValueMember = "Valor";
            cboClasificacion.SelectedIndex = 0;

            //Mostrar las opciones de busqueda en el comboboxbusqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
            //Mostrar los valores en el datagridview
            Recargar();
        }
        private void Recargar()
        {
            if (!formularioAbierto) return;

            // Este método se ejecutará en respuesta a la notificación de SignalR
            if (dgvdata.InvokeRequired)
            {
                dgvdata.Invoke((MethodInvoker)delegate { RecargarEnUI(); });
            }
            else
            {
                RecargarEnUI();
            }
        }

        private void RecargarEnUI()
        {
            if (!formularioAbierto || dgvdata.IsDisposed) return;

            dgvdata.Rows.Clear();
            List<Pelicula> listausuario = cnUsuario.Listar();  // Obtiene la lista actualizada desde la base de datos
            foreach (Pelicula item in listausuario)
            {
                dgvdata.Rows.Add(new object[] {
            "", item.IdPelicula, item.Nombre, item.Descripcion,
            item.Duracion, item.oClasificacion.IdClasificacion, item.oClasificacion.Nombre
        });
            }
        }

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
                string duracionDatagrid = dgvdata.Rows[indice].Cells["Duracion"].Value.ToString();
                TimeSpan duracion = TimeSpan.Parse(duracionDatagrid);
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["idPelicula"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    // Asigna las horas, minutos y segundos a los ComboBox
                    cbohoras.SelectedItem = duracion.Hours.ToString("D2");   // "D2" para que siempre tenga 2 dígitos
                    cbominutos.SelectedItem = duracion.Minutes.ToString("D2");
                    cbosegundos.SelectedItem = duracion.Seconds.ToString("D2");

                    foreach (OpcionCombo oc in cboClasificacion.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdClasificacion"].Value))
                        {
                            int indice_combo = cboClasificacion.Items.IndexOf(oc);
                            cboClasificacion.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
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
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtNombre.Text = "";
            txtdescripcion.Text = "";
            cbohoras.SelectedIndex = 0;
            cbominutos.SelectedIndex = 0;
            cbosegundos.SelectedIndex = 0;
            cboClasificacion.SelectedIndex = 0;
            txtNombre.Select();
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Pelicula objpelicula = new Pelicula()
            {
                IdPelicula = Convert.ToInt32(txtid.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtdescripcion.Text,
                Duracion = new TimeSpan(int.Parse(cbohoras.SelectedItem.ToString()), int.Parse(cbominutos.SelectedItem.ToString()), int.Parse(cbosegundos.SelectedItem.ToString())),
                oClasificacion = new Clasificacion() { IdClasificacion = Convert.ToInt32(((OpcionCombo)cboClasificacion.SelectedItem).Valor), Nombre = ((OpcionCombo)cboClasificacion.SelectedItem).Texto },
            };

            if (objpelicula.IdPelicula == 0)
            {

                int IdPeliculagenerada = new CN_Pelicula().Registrar(objpelicula, out mensaje);
                if (IdPeliculagenerada != 0)
                {
                    MessageBox.Show("Pelicula ingresada correctamente");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool Resultado = new CN_Pelicula().Editar(objpelicula, out mensaje);

                if (Resultado)
                {
                    MessageBox.Show("Pelicula Actualizada correctamente");
                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }
            }
        }
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la pelicula", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Pelicula obJpelicula = new Pelicula()
                    {
                        IdPelicula = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Pelicula().Eliminar(obJpelicula, out mensaje);
                    if (respuesta)
                    {
                        MessageBox.Show("Pelicula Eliminada");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

    }
}
