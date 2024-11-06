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
using Usuarios.Modales;
using Usuarios.Utilidades;

namespace Usuarios
{
    public partial class FRMventas : Form
    {
        private Usuario _usuario;
        private CN_Sesion cnSesion = new CN_Sesion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;

        public FRMventas(Usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
            cnSesion.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }
        private void FRMventas_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            numericUpDown.Visible = false;
            txtfecha.Text = DateTime.Now.ToString();
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chktipoasignacion.Checked)
            {
                label9.Visible = false;
                label11.Visible = false;
                txtfila.Visible = false;
                txtnumero.Visible = false;
                btnbusquedaasiento.Visible = false;
                numericUpDown.Visible = true;
            }
            else
            {
                label9.Visible = true;
                label11.Visible = true;
                txtfila.Visible = true;
                txtnumero.Visible = true;
                btnbusquedaasiento.Visible = true;
                numericUpDown.Visible = false;
            }
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
            //if (!formularioAbierto || dgvdata.IsDisposed) return;

            //dgvdata.Rows.Clear();
            //List<Sesion> listasesion = cnSesion.Listar();  // Obtiene la lista actualizada desde la base de datos
            //foreach (Sesion item in listasesion)
            //{
            //    dgvdata.Rows.Add(new object[] {
            //"", item.IdSesion, item.oPelicula.IdPelicula, item.oPelicula.Nombre, item.oPelicula.Duracion, item.FechaHoraInicio,
            //item.FechaHoraFin, item.oSala.IdSala, item.oSala.Nombre, item.Estado, item.oPelicula.oClasificacion.Nombre});
            //}
            ////Asignar las salas al comboboxrol
            //cboSala.Items.Clear();
            //List<Sala> listaSala = new CN_Sala().Listar();
            //foreach (Sala item in listaSala)
            //{
            //    cboSala.Items.Add(new OpcionCombo() { Valor = item.IdSala, Texto = item.Nombre });
            //}
            //cboSala.DisplayMember = "Texto";
            //cboSala.ValueMember = "Valor";
            //cboSala.SelectedIndex = 0;
            ////Asignar las Peliculas al comboboxrol
            //cboPelicula.Items.Clear();
            //List<Pelicula> listaPelicula = new CN_Pelicula().Listar();
            //foreach (Pelicula item in listaPelicula)
            //{
            //    cboPelicula.Items.Add(new OpcionCombo() { Valor = item.IdPelicula, Texto = item.Nombre });
            //}
            //cboPelicula.DisplayMember = "Texto";
            //cboPelicula.ValueMember = "Valor";
            //cboPelicula.SelectedIndex = 0;
        }

        private void btnbuscarsesion_Click(object sender, EventArgs e)
        {
            using (var modal = new mdSesion())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidsesion.Text = modal._Sesion.IdSesion.ToString();
                    txtidsala.Text = modal._Sesion.oSala.IdSala.ToString();
                    txtpelicula.Text = modal._Sesion.oPelicula.Nombre;
                    txtduracion.Text = modal._Sesion.oPelicula.Duracion.ToString();
                    txtfechainicio.Text = modal._Sesion.FechaHoraInicio.ToString();
                    txtsala.Text = modal._Sesion.oSala.Nombre;
                }
                else
                {
                    txtpelicula.Select();
                }
            }
        }

        private void btnbusquedaasiento_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAsiento(Convert.ToInt32(txtidsesion.Text), Convert.ToInt32(txtidsala.Text)))
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Aquí obtienes la lista de asientos seleccionados
                    List<Asiento> asientosSeleccionados = modal.ObtenerAsientosSeleccionados();

                    // Puedes ahora usar `asientosSeleccionados` como necesites en el formulario principal
                    foreach (var asiento in asientosSeleccionados)
                    {
                        Console.WriteLine($"Asiento seleccionado: {asiento.FilaAsiento}{asiento.NumeroAsiento}");
                    }
                }
            }
        }
    }
}
