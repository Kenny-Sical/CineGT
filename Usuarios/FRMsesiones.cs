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
    public partial class FRMsesiones : Form
    {
        private CN_Sesion cnSesion = new CN_Sesion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        public FRMsesiones()
        {
            InitializeComponent();
            cnSesion.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void FRMsesiones_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            //Mostrar los valores de Estado
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.SelectedIndex = 0;
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
            //Mostrar valores por defecto para el tiempo
            cbohoras.SelectedIndex = 0;
            cbominutos.SelectedIndex = 0;
            cbosegundos.SelectedIndex = 0;
            //Mostrar los valores en el datagridview
            Recargar();
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            cboSala.SelectedIndex = 0;
            cboPelicula.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            cbohoras.SelectedIndex = 0;
            cbominutos.SelectedIndex = 0;
            cbosegundos.SelectedIndex= 0;
            FechaInicioSesion.Value = DateTime.Now;
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
            List<Sesion> listasesion = cnSesion.Listar();  // Obtiene la lista actualizada desde la base de datos
            foreach (Sesion item in listasesion)
            {
                dgvdata.Rows.Add(new object[] {
            "", item.IdSesion, item.oPelicula.IdPelicula, item.oPelicula.Nombre, item.oPelicula.Duracion, item.FechaHoraInicio,
            item.FechaHoraFin, item.oSala.IdSala, item.oSala.Nombre, item.Estado, item.oPelicula.oClasificacion.Nombre});
            }
            //Asignar las salas al comboboxrol
            cboSala.Items.Clear();
            List<Sala> listaSala = new CN_Sala().Listar();
            foreach (Sala item in listaSala)
            {
                cboSala.Items.Add(new OpcionCombo() { Valor = item.IdSala, Texto = item.Nombre });
            }
            cboSala.DisplayMember = "Texto";
            cboSala.ValueMember = "Valor";
            cboSala.SelectedIndex = 0;
            //Asignar las Peliculas al comboboxrol
            cboPelicula.Items.Clear();
            List<Pelicula> listaPelicula = new CN_Pelicula().Listar();
            foreach (Pelicula item in listaPelicula)
            {
                cboPelicula.Items.Add(new OpcionCombo() { Valor = item.IdPelicula, Texto = item.Nombre });
            }
            cboPelicula.DisplayMember = "Texto";
            cboPelicula.ValueMember = "Valor";
            cboPelicula.SelectedIndex = 0;
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
                DateTime fechayHora = DateTime.Parse(dgvdata.Rows[indice].Cells["FechaHoraInicio"].Value.ToString());
                int estadoValor = Convert.ToInt32(dgvdata.Rows[indice].Cells["Estado"].Value);
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["IdSesion"].Value.ToString();
                    FechaInicioSesion.Value = fechayHora.Date;
                    cbohoras.SelectedItem = fechayHora.Hour.ToString();
                    cbominutos.SelectedItem = fechayHora.Minute.ToString();
                    cbosegundos.SelectedItem = fechayHora.Second.ToString();
                    foreach (OpcionCombo oc in cboSala.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdSala"].Value))
                        {
                            int indice_combo = cboSala.Items.IndexOf(oc);
                            cboSala.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboPelicula.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdPelicula"].Value))
                        {
                            int indice_combo = cboPelicula.Items.IndexOf(oc);
                            cboPelicula.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == estadoValor)
                        {
                            cboEstado.SelectedItem = oc;
                            break;
                        }
                    }

                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            DateTime fechaSeleccionada = FechaInicioSesion.Value.Date;

            // Obtener los valores seleccionados de los ComboBox
            int hora = int.Parse(cbohoras.SelectedItem.ToString());
            int minuto = int.Parse(cbominutos.SelectedItem.ToString());
            int segundo = int.Parse(cbosegundos.SelectedItem.ToString());
            DateTime fechaCompleta = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, fechaSeleccionada.Day, hora, minuto, segundo);
            Sesion objsesion = new Sesion()
            {
                IdSesion = Convert.ToInt32(txtid.Text),
                FechaHoraInicio = fechaCompleta,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor),
                oSala = new Sala() { IdSala = Convert.ToInt32(((OpcionCombo)cboSala.SelectedItem).Valor), Nombre = ((OpcionCombo)cboSala.SelectedItem).Texto },
                oPelicula = new Pelicula() { IdPelicula = Convert.ToInt32(((OpcionCombo)cboPelicula.SelectedItem).Valor), Nombre = ((OpcionCombo)cboSala.SelectedItem).Texto },
            };

            if (objsesion.IdSesion == 0)
            {

                int IdSesiongenerado = new CN_Sesion().Registrar(objsesion, out mensaje);
                if (IdSesiongenerado != 0)
                {
                    MessageBox.Show("Sesion ingresada correctamente");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool Resultado = new CN_Sesion().Editar(objsesion, out mensaje);

                if (Resultado)
                {
                    MessageBox.Show("Sesion Actualizada correctamente");
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
                if (MessageBox.Show("¿Desea eliminar la sesion", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Sesion objsesion = new Sesion()
                    {
                        IdSesion = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Sesion().Eliminar(objsesion, out mensaje);
                    if (respuesta)
                    {
                        MessageBox.Show("Sesion Eliminada");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
