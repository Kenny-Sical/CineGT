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

namespace Usuarios
{
    public partial class FRMreportes : Form
    {
        private object usuarioActual;
        private CN_Reporte reporteNegocio = new CN_Reporte();
        public FRMreportes(object usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            DataTable reporte = null;

            // Determina el reporte seleccionado en el ComboBox
            switch (comboBox1.SelectedIndex)
            {
                case 0: // Reporte 1
                    reporte = reporteNegocio.ObtenerReporte1(FechaInicio.Value, FechaFin.Value, out mensaje);
                    break;

                case 1: // Reporte 2
                    reporte = reporteNegocio.ObtenerReporte2(FechaInicio.Value, FechaFin.Value, out mensaje);
                    break;

                case 2: // Reporte 3
                    string nombreSala = txtSala.Text; // Suponiendo que label5 tiene el nombre de la sala
                    reporte = reporteNegocio.ObtenerReporte3(nombreSala, out mensaje);
                    break;

                case 3: // Reporte 4
                    int porcentajeOcupacion;
                    if (int.TryParse(textBox1.Text, out porcentajeOcupacion))
                    {
                        reporte = reporteNegocio.ObtenerReporte4(porcentajeOcupacion, out mensaje);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingresa un porcentaje de ocupación válido.");
                    }
                    break;

                case 4: // Reporte 5
                    reporte = reporteNegocio.ObtenerReporte5(out mensaje);
                    break;

                case 5: // Reporte 6
                    reporte = reporteNegocio.ObtenerReporte6(FechaInicio.Value, FechaFin.Value, out mensaje);
                    break;

                case 6: // Reporte 7
                    reporte = reporteNegocio.ObtenerReporte7(FechaInicio.Value, FechaFin.Value, out mensaje);
                    break;

                default:
                    MessageBox.Show("Por favor, selecciona un reporte válido.");
                    return;
            }
            // Muestra el reporte en el DataGridView o un mensaje de error
            if (reporte != null)
            {
                dataGridView1.DataSource = reporte;
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox1.SelectedItem.ToString();

            // Opcional: Mostrar u ocultar controles en función del reporte seleccionado.
            // Ejemplo: Si el reporte requiere una fecha, muestra los DateTimePickers
            FechaInicio.Visible = false;
            FechaFin.Visible = false;
            label10.Visible = false; // Ejemplo de texto guía
            label9.Visible = false; // Ejemplo de texto guía
            label2.Visible = false; // Ejemplo de texto guía
            label4.Visible = false;
            textBox1.Visible = false; // Ejemplo de texto guía
            txtSala.Visible = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0: // Reporte 1
                    FechaInicio.Visible = true;
                    FechaFin.Visible = true;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = true; // Ejemplo de texto guía
                    label4.Visible = true;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;
                case 1: // Reporte 2
                    FechaInicio.Visible = true;
                    FechaFin.Visible = true;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = true; // Ejemplo de texto guía
                    label4.Visible = true;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;
                case 2:
                    FechaInicio.Visible = false;
                    FechaFin.Visible = false;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = true; // Ejemplo de texto guía
                    label2.Visible = false; // Ejemplo de texto guía
                    label4.Visible = false;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = true;
                    break;
                case 3:
                    FechaInicio.Visible = false;
                    FechaFin.Visible = false;
                    label10.Visible = true; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = false; // Ejemplo de texto guía
                    label4.Visible = false;
                    textBox1.Visible = true; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;
                case 4: // Reporte 6
                    FechaInicio.Visible = false;
                    FechaFin.Visible = false;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = false; // Ejemplo de texto guía
                    label4.Visible = false;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;
                case 5: // Reporte 7
                    FechaInicio.Visible = true;
                    FechaFin.Visible = true;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = true; // Ejemplo de texto guía
                    label4.Visible = true;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;

                case 6: // Reporte 7
                    FechaInicio.Visible = true;
                    FechaFin.Visible = true;
                    label10.Visible = false; // Ejemplo de texto guía
                    label9.Visible = false; // Ejemplo de texto guía
                    label2.Visible = true; // Ejemplo de texto guía
                    label4.Visible = true;
                    textBox1.Visible = false; // Ejemplo de texto guía
                    txtSala.Visible = false;
                    break;
                }
            }
    }
}
