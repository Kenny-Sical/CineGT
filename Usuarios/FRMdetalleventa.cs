using CapaEntidad;
using CapaNegocio;
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

namespace Usuarios
{
    public partial class FRMdetalleventa : Form
    {
        private CN_VentayTransaccion cnventa = new CN_VentayTransaccion();
        private List<Asiento> asientosSeleccionados = new List<Asiento>();
        List<Asiento> asientosParaCambiar = new List<Asiento>();
        List<Venta> ventasobtenidas = new List<Venta>();
        public FRMdetalleventa()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtnumerodeventa.Text != "")
            {
                ventasobtenidas = cnventa.ObtenerVentaPorTransaccion(Convert.ToInt32(txtnumerodeventa.Text));
                foreach(var n in ventasobtenidas)
                {
                    txtidsala.Text = n.oSesion.oSala.IdSala.ToString();
                    txtidsesion.Text = n.oSesion.IdSesion.ToString();
                }

            }
        }

        private void btnbusquedaasiento_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCambioAsiento(Convert.ToInt32(txtidsesion.Text), Convert.ToInt32(txtidsala.Text), Convert.ToInt32(txtnumerodeventa.Text)))
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Aquí obtienes la lista de asientos que el usuario desea cambiar
                    asientosParaCambiar = modal.ObtenerAsientosParaCambiar();

                    // Procesar la lista de asientos que se desean cambiar como necesites
                    foreach (var asiento in asientosParaCambiar)
                    {
                        
                    }
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (txtnumerodeventa.Text == "")
            {
                MessageBox.Show("Debe ingresar un numero de venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable detalle_anular = new DataTable();
            detalle_anular.Columns.Add("IdVenta", typeof(int));
            List<Venta> ListaAnular = new List<Venta>();
            ListaAnular = cnventa.ObtenerVentaPorTransaccion(Convert.ToInt32(txtnumerodeventa.Text));
            foreach (Venta row in ListaAnular)
            {
                detalle_anular.Rows.Add(new object[] {
                    row.idVenta
                });
            }
            string mensaje = string.Empty;
            bool respuesta = new CN_VentayTransaccion().Anular(detalle_anular, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Transaccion anulada correctamente", "Mensaje", MessageBoxButtons.OK);
                //dgvdata.Rows.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnbuscarsesion_Click(object sender, EventArgs e)
        {
            using (var modal = new mdSesion())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (modal._Sesion.Estado == 1)
                    {
                        txtidsesionnuevo.Text = modal._Sesion.IdSesion.ToString();
                        txtidsalanuevo.Text = modal._Sesion.oSala.IdSala.ToString();
                        txtpelicula.Text = modal._Sesion.oPelicula.Nombre;
                        txtduracion.Text = modal._Sesion.oPelicula.Duracion.ToString();
                        txtfechainicio.Text = modal._Sesion.FechaHoraInicio.ToString();
                        txtsala.Text = modal._Sesion.oSala.Nombre;
                    }
                    else
                    {
                        MessageBox.Show("La sesion se encuentra inactiva", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    txtpelicula.Select();
                }
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            using (var modal = new mdAsiento(Convert.ToInt32(txtidsesionnuevo.Text), Convert.ToInt32(txtidsalanuevo.Text)))
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Aquí obtienes la lista de asientos seleccionados
                    asientosSeleccionados = modal.ObtenerAsientosSeleccionados();
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidsala.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar una sala", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Inicializar el DataTable para almacenar los detalles de la asignación
            DataTable detalleCambioAsiento = new DataTable();
            detalleCambioAsiento.Columns.Add("IDVenta", typeof(int));
            detalleCambioAsiento.Columns.Add("IdSesion", typeof(int));
            detalleCambioAsiento.Columns.Add("IdAsiento", typeof(int));


            // Verificar que haya suficientes asientos seleccionados para los cambios
            if (asientosSeleccionados.Count < ventasobtenidas.Count)
            {
                MessageBox.Show("No hay suficientes asientos seleccionados para realizar el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Recorrer las ventas y los asientos seleccionados para llenar el DataTable
            for (int i = 0; i < ventasobtenidas.Count; i++)
            {
                var venta = ventasobtenidas[i];
                var asiento = asientosSeleccionados[i];

                detalleCambioAsiento.Rows.Add(new object[] {
                venta.idVenta,
                txtidsesionnuevo.Text,
                asiento.IdAsiento,
                });
            }

            // Procesar el cambio de asientos con el DataTable
            string mensaje = string.Empty;
            bool respuesta = new CN_VentayTransaccion().CambiarAsiento(detalleCambioAsiento, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Asientos cambiados correctamente", "Mensaje", MessageBoxButtons.OK);
                detalleCambioAsiento.Rows.Clear();
                asientosParaCambiar.Clear();
                asientosSeleccionados.Clear();
                ventasobtenidas.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
