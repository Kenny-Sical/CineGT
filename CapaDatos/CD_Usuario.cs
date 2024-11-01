using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Collections;
using System.Security.Claims;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public event Action OnUsuariosChanged;
        private SqlTableDependency<Usuario> tableDependency;
        public CD_Usuario()
        {
            IniciarTableDependency();
        }
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "Select u.Nombre, u.Apellido, u.Usuario, u.IDUsuario, u.Clave, r.IDTipoRol, r.Nombre as NombreRol from Usuario u inner join TipoRol r on r.IDTipoRol = u.IDTipoRol";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario {
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NombreUsuario = dr["Usuario"].ToString(),
                                IDUsuario = Convert.ToInt32(dr["IDUsuario"]),
                                Clave = dr["Clave"].ToString(),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IDTipoRol"]), Nombre = dr["NombreRol"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }
        private void Usuarios_OnChanged(object sender, RecordChangedEventArgs<Usuario> e)
        {
            if (e.ChangeType == ChangeType.Insert || e.ChangeType == ChangeType.Update || e.ChangeType == ChangeType.Delete)
            {
                OnUsuariosChanged?.Invoke();  // Notifica a las capas superiores que los datos han cambiado
            }
        }
        private void IniciarTableDependency()
        {
            var connectionString = Conexion.cadena;

            // Inicializa `SqlTableDependency` para la tabla Usuarios
            tableDependency = new SqlTableDependency<Usuario>(connectionString, "Usuario");
            tableDependency.OnChanged += Usuarios_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }
        public void DetenerTableDependency()
        {
            if (tableDependency != null)
            {
                tableDependency.Stop();
                tableDependency.Dispose();
            }
        }
        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"Error en SqlTableDependency: {e.Error.Message}");
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("NombreUsuario", obj.NombreUsuario);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int ).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch(Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }


            return idusuariogenerado;
        }


        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("NombreUsuario", obj.NombreUsuario);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IDUsuario);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }


            return respuesta;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IDUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

    }
}
