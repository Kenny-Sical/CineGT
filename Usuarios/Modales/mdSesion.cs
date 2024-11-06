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

namespace Usuarios.Modales
{
    public partial class mdSesion : Form
    {
        private CN_Sesion cnSesion = new CN_Sesion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        public Sesion _Sesion { get; set; }
        public mdSesion()
        {
            InitializeComponent();
            cnSesion.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void mdSesion_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            //Mostrar las opciones de busqueda en el comboboxbusqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
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
            List<Sesion> listasesion = cnSesion.Listar();  // Obtiene la lista actualizada desde la base de datos
            foreach (Sesion item in listasesion)
            {
                dgvdata.Rows.Add(new object[] { item.IdSesion, item.oSala.IdSala,item.oPelicula.Nombre, item.oPelicula.Duracion, item.FechaHoraInicio, item.oSala.Nombre});
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int icolum = e.ColumnIndex;

            if(iRow >= 0 && icolum > 0)
            {
                _Sesion = new Sesion() { IdSesion = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdSesion"].Value), 
                oPelicula = new Pelicula() {Nombre = dgvdata.Rows[iRow].Cells["NPelicula"].Value.ToString(), Duracion = TimeSpan.Parse(dgvdata.Rows[iRow].Cells["Duracion"].Value.ToString())},
                FechaHoraInicio = DateTime.Parse(dgvdata.Rows[iRow].Cells["FechaHoraInicio"].Value.ToString()),
                oSala = new Sala() {IdSala = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdSala"].Value), Nombre = dgvdata.Rows[iRow].Cells["Sala"].Value.ToString() }
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
