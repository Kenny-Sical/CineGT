using CapaEntidad;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Sesion
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Sesion()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            hubConnection.Start().Wait();
        }
        public List<Sesion> Listar()
        {
            List<Sesion> lista = new List<Sesion>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select s.IDSesion, s.FechaHoraInicio, s.Estado, s.FechaHoraFin, s.IDSala, sa.Nombre as NombreSala, s.IDPelicula, p.Nombre as NombrePelicula, p.Duracion, c.Nombre as Clasificacion from Sesion s inner join Sala sa on s.IDSala = sa.IDSala inner join Pelicula p on s.IDPelicula = p.IDPelicula inner join Clasificacion c on p.IDClasificacion = c.IDClasificacion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Sesion
                            {
                                IdSesion = Convert.ToInt32(dr["IDSesion"]),
                                oPelicula = new Pelicula() { IdPelicula = Convert.ToInt32(dr["IDPelicula"]), Nombre = dr["NombrePelicula"].ToString(), Duracion = dr.GetTimeSpan(dr.GetOrdinal("Duracion")), oClasificacion = new Clasificacion() { Nombre = dr["Clasificacion"].ToString() } },
                                FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]),
                                FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]),
                                oSala = new Sala() { IdSala = Convert.ToInt32(dr["IDSala"]), Nombre = dr["NombreSala"].ToString()},
                                Estado = Convert.ToInt32(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Sesion>();
                }
            }
            return lista;
        }
        public int Registrar(Sesion obj, out string Mensaje)
        {
            int idsesiongenerada = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARSESION", oconexion);
                    cmd.Parameters.AddWithValue("FechaHoraInicio", obj.FechaHoraInicio);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("IdSala", obj.oSala.IdSala);
                    cmd.Parameters.AddWithValue("IdPelicula", obj.oPelicula.IdPelicula);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idsesiongenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                if (idsesiongenerada != 0)
                {
                    usuarioHubProxy.Invoke("NotificarCambio");
                }
            }
            catch (Exception ex)
            {
                idsesiongenerada = 0;
                Mensaje = ex.Message;
            }
            return idsesiongenerada;
        }
        public bool Editar(Sesion obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ACTUALIZARSESION", oconexion);
                    cmd.Parameters.AddWithValue("IdSesion", obj.IdSesion);
                    cmd.Parameters.AddWithValue("FechaHoraInicio", obj.FechaHoraInicio);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("IdSala", obj.oSala.IdSala);
                    cmd.Parameters.AddWithValue("IdPelicula", obj.oPelicula.IdPelicula);
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
        public bool Eliminar(Sesion obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARSESION", oconexion);
                    cmd.Parameters.AddWithValue("IdSesion", obj.IdSesion);
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
    }
}
