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
    public partial class mdCambioAsiento : Form
    {
        private CN_Asiento cnasiento = new CN_Asiento();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        private bool formularioAbierto = false;
        private List<Asiento> asientosSeleccionados = new List<Asiento>();
        private List<Asiento> asientosParaCambiar = new List<Asiento>();
        private int _sesion, _sala, _numeroTransaccion;
        public mdCambioAsiento(int sesion, int sala, int numeroTransaccion)
        {
            InitializeComponent();
            _sesion = sesion;
            _sala = sala;
            _numeroTransaccion = numeroTransaccion;

            cnasiento.OnChanged += Recargar;
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            usuarioHubProxy.On("Actualizar", () => Recargar());
            hubConnection.Start().Wait();
        }

        private void Recargar()
        {
            if (!formularioAbierto) return;

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

            panelAsientos.Controls.Clear();

            List<Asiento> listaAsientos = cnasiento.Listar(_sala);
            List<Asiento> listaAsientosVendidos = cnasiento.ListarOcupados(_sesion, _sala);
            List<Asiento> listaAsientosOcupadosPorTransaccion = cnasiento.ListarOcupadosPorTransaccion(_sesion, _sala, _numeroTransaccion);

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
                    Tag = asiento
                };

                // Asiento ocupado por la transacción específica (puede cambiarse)
                if (listaAsientosOcupadosPorTransaccion.Any(t => t.IdAsiento == asiento.IdAsiento))
                {
                    boton.BackColor = Color.Orange; // Color naranja para los asientos ocupados por la transacción actual
                    boton.Click += BottonClick;
                }
                // Asiento ocupado en general, pero no por la transacción (no puede cambiarse)
                else if (listaAsientosVendidos.Any(vendido => vendido.IdAsiento == asiento.IdAsiento))
                {
                    boton.BackColor = Color.Red; // Color rojo para asiento vendido
                    boton.Enabled = false; // Deshabilitar para que no se pueda seleccionar
                }

                // Ajustar posición para el siguiente botón
                left += 45;
                contador++;

                if (contador % 10 == 0)
                {
                    top += 45;
                    left = 20;
                }

                panelAsientos.Controls.Add(boton);
            }
        }

        private void BottonClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            Asiento asiento = (Asiento)btnAsiento.Tag;

            // Verificar si el asiento ya está en la lista de cambios
            if (asientosParaCambiar.Contains(asiento))
            {
                asientosParaCambiar.Remove(asiento);
                btnAsiento.BackColor = Color.Orange; // Restaurar color original (ocupado por transacción)
            }
            else
            {
                asientosParaCambiar.Add(asiento);
                btnAsiento.BackColor = Color.Green; // Marcar como seleccionado para cambio
            }
        }

        private void mdCambioAsiento_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            Recargar();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
            // Método para obtener la lista de asientos que el usuario desea cambiar
        public List<Asiento> ObtenerAsientosParaCambiar()
        {
            return asientosParaCambiar;
        }
    }
}
