using CapaEntidad;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Pelicula
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Pelicula()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            hubConnection.Start().Wait();
        }
        public List<Pelicula> Listar()
        {
            List<Pelicula> lista = new List<Pelicula>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select p.IDPelicula, p.Nombre, p.Descripcion, p.Duracion, p.IDClasificacion, c.Nombre as NombreClasificacion  from Pelicula p inner join Clasificacion c on c.IDClasificacion = p.IDClasificacion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pelicula
                            {
                                IdPelicula = Convert.ToInt32(dr["IDPelicula"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Duracion = dr.GetTimeSpan(dr.GetOrdinal("Duracion")),
                                oClasificacion = new Clasificacion() { IdClasificacion = Convert.ToInt32(dr["IDClasificacion"]), Nombre = dr["NombreClasificacion"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Pelicula>();
                }
            }
            return lista;
        }

        public int Registrar(Pelicula obj, out string Mensaje)
        {
            int idpeliculagenerada = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPELICULA", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Duracion", obj.Duracion);
                    cmd.Parameters.AddWithValue("IdClasificacion", obj.oClasificacion.IdClasificacion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idpeliculagenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                if (idpeliculagenerada != 0)
                {
                    usuarioHubProxy.Invoke("NotificarCambio");
                }
            }
            catch (Exception ex)
            {
                idpeliculagenerada = 0;
                Mensaje = ex.Message;
            }


            return idpeliculagenerada;
        }


        public bool Editar(Pelicula obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARPELICULA", oconexion);
                    cmd.Parameters.AddWithValue("IdPelicula", obj.IdPelicula);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Duracion", obj.Duracion);
                    cmd.Parameters.AddWithValue("IdClasificacion", obj.oClasificacion.IdClasificacion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                if (resultado)
                {
                    usuarioHubProxy.Invoke("NotificarCambio");
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }


            return resultado;
        }

        public bool Eliminar(Pelicula obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPELICULA", oconexion);
                    cmd.Parameters.AddWithValue("IdPelicula", obj.IdPelicula);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                if (respuesta)
                {
                    usuarioHubProxy.Invoke("NotificarCambio");
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
