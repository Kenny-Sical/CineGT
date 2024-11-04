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
    public class CD_Clasificacion
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Clasificacion()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("UsuarioHub");
            hubConnection.Start().Wait();
        }
        public List<Clasificacion> Listar()
        {
            List<Clasificacion> lista = new List<Clasificacion>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select IDClasificacion, Nombre from Clasificacion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Clasificacion
                            {
                                IdClasificacion = Convert.ToInt32(dr["IDClasificacion"]),
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Clasificacion>();
                }
            }
            return lista;
        }

        public int Registrar(Clasificacion obj, out string Mensaje)
        {
            int Resultado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCLASIFICACION", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                if (Resultado != 0)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
                }
            }
            catch (Exception ex)
            {
                Resultado = 0;
                Mensaje = ex.Message;
            }


            return Resultado;
        }


        public bool Editar(Clasificacion obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARCLASIFICACION", oconexion);
                    cmd.Parameters.AddWithValue("IDClasificacion", obj.IdClasificacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                if (Resultado)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }


            return Resultado;
        }

        public bool Eliminar(Clasificacion obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCLASIFICACION", oconexion);
                    cmd.Parameters.AddWithValue("IDClasificacion", obj.IdClasificacion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                if (Resultado)
                {
                    usuarioHubProxy.Invoke("NotificarCambioUsuarios");
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
    }
}
