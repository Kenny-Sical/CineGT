using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Usuarios
{
    public partial class FRMdatos : Form
    {
        public string connectionString = "Data Source=26.21.190.108;Initial Catalog=CINES2;Persist Security Info=True;User ID=Admin;Password=5260;Encrypt=False;TrustServerCertificate=True;";

        public FRMdatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CargarDatosCINES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@carpeta", "C:\\MEIA\\CineCSV2"); // Ruta donde están los archivos CSV

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos insertados correctamente en la base de datos.");
                        // Llamar después de insertar datos en la base de datos
                        CargarSesiones();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("BorrarDatosCINES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos limpiados de la base de datos.");
                        // Llamar después de insertar datos en la base de datos
                        CargarSesiones();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Crear un nuevo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configurar las propiedades del diálogo
            //openFileDialog.Filter = "Archivos CSV (.csv)|.csv|Todos los archivos (.)|.";
            openFileDialog.Title = "Seleccione un archivo";

            // Mostrar el cuadro de diálogo y verificar si el usuario selecciona un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Asignar la ruta del archivo seleccionado al texto de label1
                label2.Text = openFileDialog.FileName;
            }
            // Verificar que solo una de las opciones esté seleccionada
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Seleccione solo una opción: Revertir Todo o Aceptar Únicamente Sesiones Válidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que al menos una opción esté seleccionada
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Seleccione una opción: Revertir Todo o Aceptar Únicamente Sesiones Válidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CargarSesionesAdicionales", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@archivo", label2.Text); // Ruta del archivo CSV de sesiones

                        // Establecer el valor de @revertirTodo basado en la selección de los CheckBox
                        int revertirTodo = checkBox1.Checked ? 1 : 0;
                        cmd.Parameters.AddWithValue("@revertirTodo", revertirTodo);

                        // Ejecutar el procedimiento y capturar el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Verificar el resultado basado en las filas afectadas y la opción seleccionada
                        if (filasAfectadas > 0)
                        {
                            if (revertirTodo == 1)
                            {
                                MessageBox.Show("Sesiones encontradas pero revertidas por seleccionar 'Revertir Todo'.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarSesiones();

                            }
                            else
                            {

                                MessageBox.Show("Solo las sesiones válidas fueron insertadas.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarSesiones();

                            }
                        }
                        else
                        {
                            if (revertirTodo == 1)
                            {
                                MessageBox.Show("No se insertó ninguna sesión y la operación fue revertida.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarSesiones();

                            }
                            else
                            {
                                MessageBox.Show("No se encontraron sesiones válidas para insertar.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarSesiones();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void CargarSesiones()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sesion", conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSesiones.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las sesiones: {ex.Message}");
            }
        }
    }
}
