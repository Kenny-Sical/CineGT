using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private bool formularioAbierto = false;
        private List<Asiento> asientosSeleccionados = new List<Asiento>();

        public FRMventas(Usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }
        private void FRMventas_Load(object sender, EventArgs e)
        {
            formularioAbierto = true;
            numericUpDown.Visible = false;
            txtfecha.Text = DateTime.Now.ToString();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chktipoasignacion.Checked)
            {
                btnbusquedaasiento.Visible = false;
                numericUpDown.Visible = true;
            }
            else
            {
                btnbusquedaasiento.Visible = true;
                numericUpDown.Visible = false;
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
                        txtidsesion.Text = modal._Sesion.IdSesion.ToString();
                        txtidsala.Text = modal._Sesion.oSala.IdSala.ToString();
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

        private void btnbusquedaasiento_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAsiento(Convert.ToInt32(txtidsesion.Text), Convert.ToInt32(txtidsala.Text)))
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Aquí obtienes la lista de asientos seleccionados
                    asientosSeleccionados = modal.ObtenerAsientosSeleccionados();
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            bool asiento_existente = false;
            if (chktipoasignacion.Checked == false)
            {
                if (asientosSeleccionados == null)
                {
                    MessageBox.Show("No se ha seleccionado ningun asiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                foreach (var asiento in asientosSeleccionados)
                {
                    foreach (DataGridViewRow fila in dgvdata.Rows)
                    {
                        // Verificamos si el IdAsiento de la fila coincide con el IdAsiento de la lista
                        if (fila.Cells["IdAsiento"].Value != null && fila.Cells["IdAsiento"].Value.ToString() == asiento.IdAsiento.ToString())
                        {
                            asiento_existente = true;
                            break;
                        }
                    }
                }
                if (!asiento_existente)
                {
                    foreach (var asiento in asientosSeleccionados)
                    {
                        dgvdata.Rows.Add(new object[] { txtidsesion.Text, txtsala.Text, txtpelicula.Text, asiento.IdAsiento.ToString(), asiento.FilaAsiento.ToString() + asiento.NumeroAsiento.ToString(), txtfechainicio.Text });
                    }
                }
            }
            else
            {
                using (var modal = new mdAsiento(Convert.ToInt32(txtidsesion.Text), Convert.ToInt32(txtidsala.Text)))
                {
                    // Aquí obtienes la lista de asientos seleccionados
                    asientosSeleccionados = modal.SeleccionarAsientosAutomaticamente((int)numericUpDown.Value);
                    foreach (var asiento in asientosSeleccionados)
                    {
                        foreach (DataGridViewRow fila in dgvdata.Rows)
                        {
                            // Verificamos si el IdAsiento de la fila coincide con el IdAsiento de la lista
                            if (fila.Cells["IdAsiento"].Value != null && fila.Cells["IdAsiento"].Value.ToString() == asiento.IdAsiento.ToString())
                            {
                                asiento_existente = true;
                                break;
                            }
                        }
                    }
                    if (!asiento_existente)
                    {
                        foreach (var asiento in asientosSeleccionados)
                        {
                            dgvdata.Rows.Add(new object[] { txtidsesion.Text, txtsala.Text, txtpelicula.Text, asiento.IdAsiento.ToString(), asiento.FilaAsiento.ToString() + asiento.NumeroAsiento.ToString(), txtfechainicio.Text });
                        }
                    }
                }
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.trash.Width;
                var h = Properties.Resources.trash.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.trash, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvdata.Rows.RemoveAt(indice);
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidsala.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar campos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("TipoAsignacion", typeof(string));
            detalle_compra.Columns.Add("IdSesion", typeof(int));
            detalle_compra.Columns.Add("IdAsiento", typeof(int));
            detalle_compra.Columns.Add("IdUsuario", typeof(int));
            string asignacion = "";
            if (chktipoasignacion.Checked)
            {
                asignacion = "Automatica";
            }
            else
            {
                asignacion = "Manual";
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_compra.Rows.Add(new object[] {
                    asignacion,
                    Convert.ToInt32(row.Cells["IdSesion"].Value.ToString()),
                    Convert.ToInt32(row.Cells["IdAsiento"].Value.ToString()),
                    _usuario.IDUsuario
                });
            }
            string mensaje = string.Empty;
            int respuesta = new CN_VentayTransaccion().Registrar(detalle_compra, out mensaje);
            if (respuesta != 0)
            {
                MessageBox.Show("Asientos ingresados correctamente, Numero de transaccion: " + respuesta.ToString(), "Mensaje", MessageBoxButtons.OK);
                dgvdata.Rows.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
