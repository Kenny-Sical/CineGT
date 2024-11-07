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

namespace Usuarios.Modales
{
    public partial class mdAsiento : Form
    {
        private CN_Asiento cnasiento = new CN_Asiento();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        private List<Asiento> asientos = new List<Asiento>();
        private List<Asiento> asientosseleccionados = new List<Asiento>();
        private int _sesion, _sala;
        public mdAsiento(int sesion, int sala)
        {
            InitializeComponent();
            _sesion = sesion;
            _sala = sala;
            cnasiento.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void mdAsiento_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            Recargar();
        }
        private void Recargar()
        {
            if (!formularioAbierto) return;

            // Este método se ejecutará en respuesta a la notificación de SignalR
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { RecargarEnUI(); });
            }
            else
            {
                RecargarEnUI();
            }
        }

        private void RecargarEnUI()
        {
            if (!formularioAbierto || panelAsientos.IsDisposed) return;

            panelAsientos.Controls.Clear(); // Limpiar el panel antes de agregar botones

            // Filtrar asientos por sala actual
            List<Asiento> listaAsientos = cnasiento.Listar(_sala);
            List<Asiento> listaAsientosVendidos = cnasiento.ListarOcupados(_sesion, _sala);

            int left = 20;
            int top = 20;
            int contador = 0;

            foreach (var asiento in listaAsientos)
            {
                var boton = new Button
                {
                    Width = 45,
                    Height = 45,
                    Font = new Font(new FontFamily("Segoe UI"), 10),
                    Visible = true,
                    Left = left,
                    Top = top,
                    Text = $"{asiento.FilaAsiento}{asiento.NumeroAsiento}",
                    Tag = asiento // Guardar el objeto Asiento en el botón
                };

                // Comprobar si el asiento está vendido
                if (listaAsientosVendidos.Any(vendido => vendido.IdAsiento == asiento.IdAsiento))
                {
                    boton.BackColor = Color.Red; // Color rojo para asiento vendido
                    boton.Enabled = false; // Deshabilitar el botón para que no se pueda seleccionar
                }
                else if (asientosseleccionados.Contains(asiento))
                {
                    boton.BackColor = Color.Green; // Color verde para asiento seleccionado
                }

                boton.Click += BottonClick;

                // Ajustar posición para el siguiente botón
                left += 45;
                contador++;

                // Cambiar de fila cada 10 botones
                if (contador % 10 == 0)
                {
                    top += 45;
                    left = 20;
                }

                panelAsientos.Controls.Add(boton); // Agregar el botón al panel
            }
        }

        private void BottonClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            Asiento asiento = (Asiento)btnAsiento.Tag;

            // Lógica de selección/desselección del asiento
            if (asientosseleccionados.Contains(asiento))
            {
                asientosseleccionados.Remove(asiento);
                btnAsiento.BackColor = DefaultBackColor; // Deseleccionar
            }
            else
            {
                asientosseleccionados.Add(asiento);
                btnAsiento.BackColor = Color.Green; // Seleccionar
            }
        }
        // Método para obtener los asientos seleccionados
        public List<Asiento> ObtenerAsientosSeleccionados()
        {
            return asientosseleccionados;
        }
        public List<Asiento> SeleccionarAsientosAutomaticamente(int numeroDeAsientos)
        {
            // Obtener las listas de asientos
            List<Asiento> listaAsientos = cnasiento.Listar(_sala);
            List<Asiento> listaAsientosVendidos = cnasiento.ListarOcupados(_sesion, _sala);

            // Filtrar los asientos disponibles (no vendidos)
            var asientosDisponibles = listaAsientos
                .Where(asiento => !listaAsientosVendidos.Any(vendido => vendido.IdAsiento == asiento.IdAsiento))
                .OrderBy(asiento => asiento.FilaAsiento) // Ordenar si es necesario
                .ThenBy(asiento => asiento.NumeroAsiento)
                .ToList();

            // Verificar que hay suficientes asientos disponibles
            if (asientosDisponibles.Count < numeroDeAsientos)
            {
                MessageBox.Show("No hay suficientes asientos disponibles.");
                return new List<Asiento>();
            }

            // Seleccionar los primeros 'numeroDeAsientos' asientos disponibles
            var asientosSeleccionados = asientosDisponibles.Take(numeroDeAsientos).ToList();

            return asientosSeleccionados;
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
