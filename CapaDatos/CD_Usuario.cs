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
using Microsoft.AspNet.SignalR.Client;

namespace CapaDatos
{
    public class CD_Usuario
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Usuario()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("UsuarioHub");
            hubConnection.Start().Wait();
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
                if (idusuariogenerado != 0)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
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
                if (respuesta)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
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
                if (respuesta)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
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
