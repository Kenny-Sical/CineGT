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
    public class CD_Asiento
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Asiento()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            hubConnection.Start().Wait();
        }
        public List<Asiento> Listar(int sala)
        {
            List<Asiento> lista = new List<Asiento>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select IDAsiento, NumeroAsiento, FilaAsiento, IDSala from Asiento where IDSala = @IDSala";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDSala", sala);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Asiento
                            {
                                IdAsiento = Convert.ToInt32(dr["IDAsiento"]),
                                NumeroAsiento = Convert.ToInt32(dr["NumeroAsiento"]),
                                FilaAsiento = dr["FilaAsiento"].ToString(),
                                oSala = new Sala() { IdSala = Convert.ToInt32(dr["IDSala"])},
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Asiento>();
                }
            }
            return lista;
        }
        public List<Asiento> ListarOcupados(int sesion,int sala)
        {
            List<Asiento> lista = new List<Asiento>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT a.IDAsiento, a.NumeroAsiento, a.FilaAsiento, a.IDSala FROM Venta v JOIN Asiento a ON v.IDAsiento = a.IDAsiento JOIN Sesion s ON v.IDSesion = s.IDSesion AND a.IDSala = s.IDSala WHERE s.IDSesion = @IDSesion AND a.IDSala = @IDSala";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDSesion", sesion);
                    cmd.Parameters.AddWithValue("@IDSala", sala);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Asiento
                            {
                                IdAsiento = Convert.ToInt32(dr["IDAsiento"]),
                                NumeroAsiento = Convert.ToInt32(dr["NumeroAsiento"]),
                                FilaAsiento = dr["FilaAsiento"].ToString(),
                                oSala = new Sala() { IdSala = Convert.ToInt32(dr["IDSala"]) },
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Asiento>();
                }
            }
            return lista;
        }
        public List<Asiento> ListarOcupadosPorTransaccion(int sesion, int sala, int NumeroTransaccion)
        {
            List<Asiento> lista = new List<Asiento>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT a.IDAsiento, a.NumeroAsiento, a.FilaAsiento, a.IDSala FROM Venta v JOIN Asiento a ON v.IDAsiento = a.IDAsiento JOIN Sesion s ON v.IDSesion = s.IDSesion AND a.IDSala = s.IDSala WHERE s.IDSesion = @IDSesion AND a.IDSala = @IDSala AND v.IDTransaccion = @NumeroTransaccion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDSesion", sesion);
                    cmd.Parameters.AddWithValue("@IDSala", sala);
                    cmd.Parameters.AddWithValue("@NumeroTransaccion", NumeroTransaccion);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Asiento
                            {
                                IdAsiento = Convert.ToInt32(dr["IDAsiento"]),
                                NumeroAsiento = Convert.ToInt32(dr["NumeroAsiento"]),
                                FilaAsiento = dr["FilaAsiento"].ToString(),
                                oSala = new Sala() { IdSala = Convert.ToInt32(dr["IDSala"]) },
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Asiento>();
                }
            }
            return lista;
        }
    }
}
