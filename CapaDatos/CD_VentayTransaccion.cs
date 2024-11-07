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
    public class CD_VentayTransaccion
    {
        public List<Venta> ObtenerVentaPorTransaccion(int NumeroTransaccion)
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT v.IDVenta, s.IDSesion, s.IDSala FROM Venta v INNER JOIN Sesion s ON v.IDSesion = s.IDSesion WHERE v.IDTransaccion = @NumeroTransaccion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NumeroTransaccion", NumeroTransaccion);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Venta
                            {
                                idVenta = Convert.ToInt32(dr["IDVenta"]),
                                oSesion = new Sesion() { IdSesion = Convert.ToInt32(dr["IDSesion"]), oSala = new Sala() { IdSala = Convert.ToInt32(dr["IDSala"]) } },
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Venta>();
                }
            }
            return lista;
        }
        public int Registrar(DataTable DetalleCompra, out string Mensaje)
        {
            int Resultado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARTRANSACCIONYVENTA", oconexion);
                    cmd.Parameters.Add("venta", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = 0;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
        public bool Anular(DataTable DetalleCompra, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARTRANSACCIONYANULARVENTA", oconexion);
                    cmd.Parameters.Add("venta", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
        public bool CambiarAsiento(DataTable DetalleCompra, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARTRANSACCIONYACTUALIZARVENTA", oconexion);
                    cmd.Parameters.Add("venta", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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
