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
    public partial class FRMclasificacion : Form
    {
        private CN_Clasificacion cnclasificacion = new CN_Clasificacion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        public FRMclasificacion()
        {
            InitializeComponent();
            cnclasificacion.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void FRMclasificacion_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
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
            List<Clasificacion> listausuario = cnclasificacion.Listar();  // Obtiene la lista actualizada desde la base de datos
            foreach (Clasificacion item in listausuario)
            {
                dgvdata.Rows.Add(new object[] {
            "", item.IdClasificacion, item.Nombre
        });
            }
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtNombre.Text = "";
            txtNombre.Select();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Clasificacion objclasificacion = new Clasificacion()
            {
                IdClasificacion = Convert.ToInt32(txtid.Text),
                Nombre = txtNombre.Text
            };

            if (objclasificacion.IdClasificacion == 0)
            {

                int idClasificaciongenerado = new CN_Clasificacion().Registrar(objclasificacion, out mensaje);
                if (idClasificaciongenerado != 0)
                {
                    MessageBox.Show("Clasificación ingresada correctamente");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool Resultado = new CN_Clasificacion().Editar(objclasificacion, out mensaje);

                if (Resultado)
                {
                    MessageBox.Show("Clasificación Actualizada correctamente");
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
                if (MessageBox.Show("¿Desea eliminar la clasificación", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Clasificacion obj = new Clasificacion()
                    {
                        IdClasificacion = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Clasificacion().Eliminar(obj, out mensaje);
                    if (respuesta)
                    {
                        MessageBox.Show("Clasificación Eliminada");
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
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

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["IdClasificacion"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                }
            }
        }

    }
}
