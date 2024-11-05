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
    public class CD_Transaccion
    {
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        public CD_Transaccion()
        {
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");
            hubConnection.Start().Wait();
        }
        public List<Transaccion> Listar()
        {
            List<Transaccion> lista = new List<Transaccion>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select T.IDTransaccion, T.NumeroTransaccion, T.FechaHora, A.IDAccion, A.Descripcion from Transaccion T inner join  Accion A on T.IDAccion = A.IDAccion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Transaccion
                            {
                                IdTransaccion = Convert.ToInt32(dr["IDTransaccion"]),
                                NumeroTransaccion = Convert.ToInt32(dr["NumeroTransaccion"]),
                                FechaHora = Convert.ToDateTime(dr["FechaHora"]),
                                oAccion = new Accion() { IdAccion = Convert.ToInt32(dr["IDAccion"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Transaccion>();
                }
            }
            return lista;
        }
        public int Registrar(Transaccion obj, out string Mensaje)
        {
            int idtransacciongenerada = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARTRANSACCION", oconexion);
                    cmd.Parameters.AddWithValue("NumeroTransaccion", obj.NumeroTransaccion);
                    cmd.Parameters.AddWithValue("FechaHora ", obj.FechaHora);
                    cmd.Parameters.AddWithValue("IdAccion ", obj.oAccion.IdAccion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idtransacciongenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                if (idtransacciongenerada != 0)
                {
                    usuarioHubProxy.Invoke("NotificarCambio");
                }
            }
            catch (Exception ex)
            {
                idtransacciongenerada = 0;
                Mensaje = ex.Message;
            }
            return idtransacciongenerada;
        }
    }
}
